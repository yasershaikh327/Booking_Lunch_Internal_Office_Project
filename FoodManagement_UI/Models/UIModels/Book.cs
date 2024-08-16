namespace FoodManagement_UI.Models.UIModels
{
    public class Book
    {
        public string VegNonVegSelection { get; set; }
        public string Employee { get; set; }

    }

    public enum BookingStatus{ 
    
        Booked,
        TimedOut,
        PreBooked
    }
}
