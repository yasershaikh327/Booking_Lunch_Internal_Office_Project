namespace FoodManagement_UI.Models.Dtos
{
    public class FeedbackDto
    {
        public FeedbackDto() { }
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Day { get; set; }
        public int Week { get; set; }
        public string Comments { get; set; }
    }

    public class FeedbackDtos
    {
        FeedbackDtos feedbackDtos { get; set; }
        public FeedbackDtos() { 
            feedbackDtos = new FeedbackDtos();
        }
    }
}
