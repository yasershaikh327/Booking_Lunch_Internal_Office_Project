using FoodManagement_UI.Models.UIModels;
using System.Globalization;

namespace FoodManagement_UI.Helpers
{
    public interface IHelper
    {
        public int GetIso8601WeekOfYear();
        public string Base64Encode(string PlainPassword);
        public string GnerateString();
        public int Randompassword();
        public int IsUserAuthenticated(Login login);
        public bool TimeStamp();
    }
    public class Helper : IHelper
    {
        private readonly IConfiguration _configuration;
        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //Get Week of the month
        public int GetIso8601WeekOfYear()
        {
            var currentDate = DateTime.Now;
            var firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var culture = CultureInfo.CurrentCulture;
            var calendar = culture.Calendar;

            int currentWeekOfMonth = calendar.GetWeekOfYear(currentDate, culture.DateTimeFormat.CalendarWeekRule, culture.DateTimeFormat.FirstDayOfWeek) -
                                    calendar.GetWeekOfYear(firstDayOfMonth, culture.DateTimeFormat.CalendarWeekRule, culture.DateTimeFormat.FirstDayOfWeek) + 1;
             currentWeekOfMonth = (currentWeekOfMonth == 5) ? 1 : currentWeekOfMonth;
            return currentWeekOfMonth;
        }


        //Encrypt Password
        public string Base64Encode(string PlainPassword)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainPassword);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        //Generate Random String
        public string GnerateString()
        {
            Random res = new Random();
            String str = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%_";
            int size = 16;
            string randomstring = "";
            int x;
            for (int i = 0; i < size; i++)
            {
                x = res.Next(str.Length);
                randomstring = randomstring + str[x];
            }
            return randomstring;
        }


        //FInd The User As Admin/Employee
        public int IsUserAuthenticated(Login login)
        {
            var credentials = _configuration.GetSection("SmtpClientSettings:Credentials").Get<Credentials>();
            if (login.Email.Contains(credentials.Username) && login.Password.Contains(credentials.Password))
                return -2;
            return -1;
        }

        //TimeStamp
        public bool TimeStamp()
        {
            // Check if the current time is within the allowed time range
            DateTime currentTime = DateTime.Now;
            TimeSpan startTime = new TimeSpan(0, 0, 0); // 12:00 am
            TimeSpan endTime = new TimeSpan(10, 30, 0); // 10:30 am
            bool isWithinTimeRange = currentTime.TimeOfDay >= startTime && currentTime.TimeOfDay <= endTime;

            // Check if the current day is Monday to Friday
            bool isWeekday = currentTime.DayOfWeek >= DayOfWeek.Monday && currentTime.DayOfWeek <= DayOfWeek.Friday;
            if (isWithinTimeRange && isWeekday)
                return true;
            return false;
        }

        //Get Random 6 Digit Integer Number
        public int Randompassword()
        {
            var random = new Random();
            return random.Next(100000, 999999); 
        }
    }
}
