using Microsoft.EntityFrameworkCore;
using Quartz;
using FoodInventoryManagement.DataAccess;
using FoodManagement_UI.Services.Models;
using FoodManagement_UI.Services;


//SINGLE RESPONSIBILITY PRINCIPLE

namespace Proj_EmaployeeFoodDataAccess.Service
{
    public interface Iservice1
    {
        //Cron Job Services
        public void CountLunch(CronJobModel cronJobModel, MailMessageSettings mailMessageSettings);
    }


    public interface Iservice2
    {
        //Cron Job Services
        public void DeleteAllFoodItem();
    }


    public interface Iservice3
    {
        //Cron Job Services
        Task Reminder();
    }

    //Count the Lunch
    public class SendLunchCountMail : IJob,Iservice1
    {

        private readonly FoodManagementDB _context;
        private readonly CronJobModel cronJobModel;
        private readonly MailMessageSettings _mailMessage;
        private readonly IEmailService _emailService;

        public SendLunchCountMail(FoodManagementDB context1, CronJobModel cronJobModel2, MailMessageSettings mailMessageSettings,IEmailService emailService)
        {
            _context = context1;
            cronJobModel = cronJobModel2;
            _mailMessage = mailMessageSettings;
            _emailService = emailService;
        }

        //Execute Function
        public Task Execute(IJobExecutionContext context)
        {
            //Write your custom code here
            CountLunch(cronJobModel, _mailMessage);
            return Task.FromResult(true);
        }


        public void CountLunch(CronJobModel cronJobModel, MailMessageSettings mailMessageSettings)
        {
            try
            {
                cronJobModel.VegCount = _context.BookLunchDto.Count(b => b.VegNonVegSelection == "Veg");               //Count of Veg
                cronJobModel.NonvegCount = _context.BookLunchDto.Count(b => b.VegNonVegSelection == "NonVeg");  //Count of Non Veg
                cronJobModel.Count = cronJobModel.VegCount + cronJobModel.NonvegCount;
                _emailService.CountLunch(cronJobModel.VegCount, cronJobModel.NonvegCount, cronJobModel.Count);
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }


    //Empty All Booking Records
    public class RemoveBookings : IJob,Iservice2
    {

        private readonly FoodManagementDB _context;
        public RemoveBookings(FoodManagementDB context)
        {
            _context = context;

        }


        //Execute Function
        public Task Execute(IJobExecutionContext context)
        {
            //Write your custom code here
            DeleteAllFoodItem();
            return Task.FromResult(true);
        }

        //Delete Food Item
        public void DeleteAllFoodItem()
        {
            _context.BookLunchDto.RemoveRange(_context.BookLunchDto);
            _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('BookLunch', RESEED, 0)");
            _context.SaveChanges();
        }

    }


    //Send Reminder to Everyone
    public class SendReminderToAllForBooking : IJob,Iservice3
    {
        private readonly ITeamsService _teamsservice;
        public SendReminderToAllForBooking(ITeamsService teamsservice)
        {
            _teamsservice = teamsservice;
        }


        //Execute Function
        public Task Execute(IJobExecutionContext context)
        {
            //Write your custom code here
            //Send reminder
            Reminder();
            return Task.FromResult(true);
        }

        //Send Reminder
        public async Task Reminder()
        {
            try
            {
                _teamsservice.SendPing();   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        
    }
}

