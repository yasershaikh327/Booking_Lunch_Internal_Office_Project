using Quartz;

namespace FoodManagement_UI.MemoryManagement
{
    public class OtpManagement : IOtpManagment
    {
        private Dictionary<string, string> _data;

        public OtpManagement()
        {
            _data = new Dictionary<string, string>();
        }

        public void AddOtp(string email, string value)
        {
            if (_data.ContainsKey(email))
            {
                _data.Remove(email);
            }
            _data.Add(email, value);
        }

        public bool CheckOtp(string email, string otpValue)
        {
            if (_data.ContainsKey(email))
            {
                return _data[email] == otpValue;
            }

            return false;
        }
    }
}
