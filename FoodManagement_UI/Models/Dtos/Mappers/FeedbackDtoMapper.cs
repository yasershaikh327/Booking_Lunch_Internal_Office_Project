using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Models.Dtos.Mappers
{
    public interface IFeedbackDtoMapper
    {
        FeedbackDto Map(Feedback feedback);
    }
    public class FeedbackDtoMapper : IFeedbackDtoMapper
    {
        public FeedbackDto Map(Feedback feedback)
        {
            var feedbackDto = new FeedbackDto();
            feedbackDto.Id = feedback.Id;
            feedbackDto.Day = feedback.Day;
            feedbackDto.Week = feedback.Week;  
            feedbackDto.Rating = feedback.Rating;
            feedbackDto.Comments = feedback.Comments;
            return feedbackDto;
        }
    }
}
