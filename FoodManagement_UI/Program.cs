using FoodInventoryManagement.DataAccess;
using FoodInventoryManagement.Models.Dtos.Mappers;
using FoodInventoryManagement.Repository;
using FoodManagement_UI.Clients;
using FoodManagement_UI.Helpers;
using FoodManagement_UI.MemoryManagement;
using FoodManagement_UI.Models.Dtos.Mappers;
using FoodManagement_UI.Models.UIModels.Mappers;
using FoodManagement_UI.Repository;
using FoodManagement_UI.Services;
using FoodManagement_UI.Services.Models;
using Microsoft.EntityFrameworkCore;
using Proj_EmaployeeFoodDataAccess.Service;
using Quartz;


var builder = WebApplication.CreateBuilder(args);


/*Cron Job Service*/
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();
    var jobKey1 = new JobKey("DeleteData");
    var jobKey2 = new JobKey("SendReminder");
    var jobKey22 = new JobKey("SendReminder2");
    var jobKey23 = new JobKey("SendReminder3");
    var jobKey3 = new JobKey("SendCount");

    //Job to Delete Data
    q.AddJob<RemoveBookings>(opts => opts.WithIdentity(jobKey1));
    q.AddTrigger(opts => opts
        .ForJob(jobKey1)
        .WithIdentity("DeleteData-trigger")
        .WithCronSchedule("0 0 13 ? * SUN,MON,TUE,WED,THU,FRI,SAT *"));
    

//Job to Send Reminder 1
q.AddJob<SendReminderToAllForBooking>(opts => opts.WithIdentity(jobKey2));
    q.AddTrigger(opts => opts
        .ForJob(jobKey2)
        .WithIdentity("SendReminder-trigger")
        .WithCronSchedule("0 30 8 ? * MON,TUE,WED,THU,FRI *"));


    //Job to Send Reminder 2
    q.AddJob<SendReminderToAllForBooking>(opts => opts.WithIdentity(jobKey22));
    q.AddTrigger(opts => opts
        .ForJob(jobKey22)
        .WithIdentity("SendReminder2-trigger")
         .WithCronSchedule("0 30 9 ? * MON,TUE,WED,THU,FRI *"));

    //Job to Send Reminder 3
    q.AddJob<SendReminderToAllForBooking>(opts => opts.WithIdentity(jobKey23));
    q.AddTrigger(opts => opts
        .ForJob(jobKey23)
        .WithIdentity("SendReminder3-trigger")
        .WithCronSchedule("0 15 10 ? * MON,TUE,WED,THU,FRI *"));
        

    //Send Count of Food
    q.AddJob<SendLunchCountMail>(opts => opts.WithIdentity(jobKey3));
    q.AddTrigger(opts => opts
        .ForJob(jobKey3)
        .WithIdentity("SendCount-trigger")
        .WithCronSchedule("0 31 10 ? * MON,TUE,WED,THU,FRI *"));



});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IEmailClient, EmailClient>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<ITeamsService,TeamsService>();
builder.Services.AddScoped<CronJobModel>();
builder.Services.AddScoped<MailMessageSettings>();
builder.Services.AddScoped<SendLunchCountMail>();
builder.Services.AddScoped<ILoginDtoMapper,LoginDtoMapper>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IHelper,Helper>();
builder.Services.AddScoped<IRegistrationMapper,RegistrationMapper>();
builder.Services.AddScoped<IRegistrationDtoMapper,RegistrationDtoMapper>();
builder.Services.AddScoped<IVerfiyEmailDtoMapper,VerfiyEmailDtoMapper>();
builder.Services.AddScoped< IVerifyEmailMapper,VerifyEmailMapper>();
builder.Services.AddScoped<IFoodDtoMapper, FoodDtoMapper>();
builder.Services.AddScoped<IFoodMapper, FoodMapper>();
builder.Services.AddScoped<IFeedbackMapper, FeedbackMapper>();
builder.Services.AddScoped<IFeedbackDtoMapper, FeedbackDtoMapper>();
builder.Services.AddScoped<IbookDtoMapper, BookDtoMapper>();
builder.Services.AddScoped<IBookmapper, BookMapper>();
builder.Services.AddSingleton<IOtpManagment, OtpManagement>();
builder.Services.AddDbContext<FoodManagementDB>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddDistributedMemoryCache(); // Add a distributed cache service for session storage
builder.Configuration.AddJsonFile("appSettings.json");


builder.Services.AddControllers();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true; // Set HttpOnly option for security
    options.Cookie.IsEssential = true; // Make the session cookie essential
    options.IdleTimeout = TimeSpan.FromMinutes(69); // Set the session timeout duration
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


app.UseStatusCodePages(async context =>
{

    if (context.HttpContext.Response.StatusCode == 301)
    {
        context.HttpContext.Response.Redirect("/Error/MovedPermanently");
    }
    else if (context.HttpContext.Response.StatusCode == 400)
    {
        context.HttpContext.Response.Redirect("/Error/ModelStateInvalid");
    }
    else if (context.HttpContext.Response.StatusCode == 401)
    {
        context.HttpContext.Response.Redirect("/Error/UnAuthorized");
    }
    else if (context.HttpContext.Response.StatusCode == 403)
    {
        context.HttpContext.Response.Redirect("/Error/Forbidden");
    }
    else if (context.HttpContext.Response.StatusCode == 404)
    {
        context.HttpContext.Response.Redirect("/Error/PageNotFound");
    }
    else if (context.HttpContext.Response.StatusCode == 405)
    {
        context.HttpContext.Response.Redirect("/Error/MethodStateInvalid");
    }
    else if (context.HttpContext.Response.StatusCode == 500)
    {
        context.HttpContext.Response.Redirect("/Error/ServerError");
    }
    else if (context.HttpContext.Response.StatusCode == 501)
    {
        context.HttpContext.Response.Redirect("/Error/NotImplemented");
    }
    else
    {
        context.HttpContext.Response.Redirect("/Main/Index");
    }
    // You can add more cases for other status codes as needed.
});


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");


app.UseSession();
app.Run();
