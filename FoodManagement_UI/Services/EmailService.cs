using FoodManagement_UI.Clients;
using FoodManagement_UI.Services.Models;
using System.Net.Mail;

namespace FoodManagement_UI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailClient _emailClient;

        public EmailService(IEmailClient emailClient)
        {
            _emailClient = emailClient;
        }
        public void SendMail(MailMessageSettings mailMessageSettings)
        {
            try
            {
                var mailMessage = new MailMessageSettings
                {
                    Body = mailMessageSettings.Body,
                    To = mailMessageSettings.To,
                };
                _emailClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        public void ComfirmEmail(string email, string oTP)
        {
            var mailMessageSettings = new MailMessageSettings();
            mailMessageSettings.To = new MailAddress(email);
            mailMessageSettings.Body = oTP;
            SendMail(mailMessageSettings);
        }

        public void BookingComfirmEmail(string email, bool typeSelection, string name, int id,string date)
        {
            var mailMessage = new MailMessageSettings();
            mailMessage.To = new MailAddress(email);
            mailMessage.Body = "<table  style='font-family:Bahnschrift;border-collapse: collapse;margin: 25px 0;font-size: 0.9em;min-width: 400px;border-radius: 5px 5px 0 0;overflow-x: auto;box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);'> \r\n     <thead style='background: linear-gradient(135deg,#eb5d5d,hsl(28, 100%, 50%, 0.537));color: #ffffff;text-align: left;font-weight: bold;'> \r\n         <tr style='background: #171c24;color: #ffffff;text-align: left; color: #fff;font-size: 30px;font-weight: 600;border-bottom: 1px solid #dddddd;'> \r\n             <th colspan='2' style='font-family:Bahnschrift;padding: 12px 15px;font-size: 35px;'><center>Zapcom Lunch Coupon</center></th> \r\n         </tr> \r\n       <tr style='border-bottom: 1px solid #dddddd;background: #171c24;color: #ffffff;text-align: left;font-weight: bold;'> \r\n         <td colspan='1' style='font-family:Bahnschrift;padding: 12px 15px;font-size: large;'><center>" + id + "</center> </td> \r\n\r\n       </tr> \r\n        <tr style='border-bottom: 1px solid #dddddd;background: #171c24;color: #ffffff;text-align: left;font-weight: bold;'> \r\n          <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: large;'><center>" + name + "</center></td> \r\n \r\n        </tr> \r\n         <tr style='border-bottom: 1px solid #dddddd;background: #1f2417;color: #ffffff;text-align: left;font-weight: bold;'> \r\n             <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: large;'><center>" + date + "</center></td> \r\n     \r\n            </tr> \r\n            <tr style='border-bottom: 1px solid #dddddd;background: red;color: #ffffff;text-align: left;font-weight: bold;'> \r\n              <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: x-large;'><center>Non Veg</center></td> \r\n      \r\n             </tr> \r\n     </thead> \r\n   </table>";
            if (typeSelection)
                mailMessage.Body = "<table  style='font-family:Bahnschrift;border-collapse: collapse;margin: 25px 0;font-size: 0.9em;min-width: 400px;border-radius: 5px 5px 0 0;overflow-x: auto;box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);'> \r\n     <thead style='background: linear-gradient(135deg,#eb5d5d,hsl(28, 100%, 50%, 0.537));color: #ffffff;text-align: left;font-weight: bold;'> \r\n         <tr style='background: #171c24;color: #ffffff;text-align: left; color: #fff;font-size: 30px;font-weight: 600;border-bottom: 1px solid #dddddd;'> \r\n             <th colspan='2' style='font-family:Bahnschrift;padding: 12px 15px;font-size: 35px;'><center>Zapcom Lunch Coupon</center></th> \r\n         </tr> \r\n       <tr style='border-bottom: 1px solid #dddddd;background: #171c24;color: #ffffff;text-align: left;font-weight: bold;'> \r\n         <td colspan='1' style='font-family:Bahnschrift;padding: 12px 15px;font-size: large;'><center>" + id + "</center> </td> \r\n\r\n       </tr> \r\n        <tr style='border-bottom: 1px solid #dddddd;background: #171c24;color: #ffffff;text-align: left;font-weight: bold;'> \r\n          <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: large;'><center>" + name + "</center></td> \r\n \r\n        </tr> \r\n         <tr style='border-bottom: 1px solid #dddddd;background: #1f2417;color: #ffffff;text-align: left;font-weight: bold;'> \r\n             <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: large;'><center>" + date + "</center></td> \r\n     \r\n            </tr> \r\n            <tr style='border-bottom: 1px solid #dddddd;background: #02b120;color: #ffffff;text-align: left;font-weight: bold;'> \r\n              <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: x-large;'><center>Veg</center></td> \r\n      \r\n             </tr> \r\n     </thead> \r\n   </table>";
            SendMail(mailMessage);
        }

        public void CountLunch(int VegCount, int NonVegCount, int TotalCount)
        {
            var mailMessage = new MailMessageSettings();
            mailMessage.To = new MailAddress("zapcomlunch@zapcg.com");
            mailMessage.Body = "<table  style='font-family:Bahnschrift;border-collapse: collapse;margin: 25px 0;font-size: 0.9em;min-width: 400px;border-radius: 5px 5px 0 0;overflow-x: auto;box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);'> \r\n     <thead style='background: linear-gradient(135deg,#eb5d5d,hsl(28, 100%, 50%, 0.537));color: #ffffff;text-align: left;font-weight: bold;'> \r\n         <tr style='background: #171c24;color: #ffffff;text-align: left; color: #fff;font-size: 30px;font-weight: 600;border-bottom: 1px solid #dddddd;'> \r\n             <th colspan='2' style='font-family:Bahnschrift;padding: 12px 15px;font-size: 47px;'><center>Zapcom Lunch</center></th> \r\n         </tr> \r\n       <tr style='border-bottom: 1px solid #dddddd;background: #171c24;color: #ffffff;text-align: left;font-weight: bold;'> \r\n         <td colspan='1' style='font-family:Bahnschrift;padding: 12px 15px;color:greenyellow;font-size: x-large;'>Veg </td> \r\n         <td colspan='1' style='font-family:Bahnschrift;padding: 12px 15px;font-size: x-large;'><center>" + VegCount + "</center> </td> \r\n\r\n       </tr> \r\n        <tr style='border-bottom: 1px solid #dddddd;background: #171c24;color: #ffffff;text-align: left;font-weight: bold;'> \r\n          <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;color: red;font-size: x-large;'>NonVeg </td> \r\n          <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: x-large;'><center>" + NonVegCount + "</center></td> \r\n \r\n        </tr> \r\n         <tr style='border-bottom: 1px solid #dddddd;background: #171c24;color: #ffffff;text-align: left;font-weight: bold;'> \r\n              <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: x-large;'>Total </td> \r\n              <td colspan='' style='font-family:Bahnschrift;padding: 12px 15px;font-size: x-large;'><center>" + TotalCount + "</center></td> \r\n     \r\n            </tr> \r\n        \r\n     </thead> \r\n   </table>";
            SendMail(mailMessage);
        }

        public void ForgetPassWordEmail(string email, string randompassword)
        {
            //Send Mail
            try
            {
                var mailMessage = new MailMessageSettings();
                mailMessage.To = new MailAddress(email);
                mailMessage.Body = "<table  style='font-family:Bahnschrift;border-collapse: collapse;margin: 25px 0;font-size: 0.9em;min-width: 400px;border-radius: 5px 5px 0 0;overflow-x: auto;box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);'> \r\n     <thead style='background: linear-gradient(135deg,#eb5d5d,hsl(28, 100%, 50%, 0.537));color: #ffffff;text-align: left;font-weight: bold;'> \r\n         <tr style='background: #171c24;color: #ffffff;text-align: left; color: #fff;font-size: 30px;font-weight: 600;border-bottom: 1px solid #dddddd;'> \r\n             <th colspan='2' style='font-family:Bahnschrift;padding: 12px 15px;font-size: 35px;'><center>Password Recovery</center></th> \r\n         </tr> \r\n       <tr style='border-bottom: 1px solid #dddddd;background: #171c24;color: greenyellow;text-align: left;font-weight: bold;'> \r\n         <td colspan='1' style='font-family:Bahnschrift;padding: 12px 15px;font-size: large;'><center>" + randompassword + "</center> </td> \r\n       </tr>\r\n     \r\n     </thead> \r\n   </table>";
                SendMail(mailMessage);        
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}