using FoodInventoryManagement.Models.Dtos;
using FoodInventoryManagement.Models.UIModels;
using FoodManagement_UI.Models.Dtos;

namespace FoodManagement_UI.Models.UIModels.Mappers
{
    public interface IFeedbackMapper
    {
        public Feedback Map(FeedbackDto feedbackDto);
        public List<Feedback> Map(List<FeedbackDto> feedbackDto);
    }
    public class FeedbackMapper : IFeedbackMapper
    {
        public Feedback Map(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback();
            feedback.Id = feedbackDto.Id;
            feedback.Week = feedbackDto.Week;
            feedback.Day = feedbackDto.Day;
            feedback.Rating = feedbackDto.Rating;
            feedback.Comments = feedbackDto.Comments;
            return feedback;
        }

        public List<Feedback> Map(List<FeedbackDto> feedbackDto)
        {
            var feedback = new List<Feedback>();
            foreach (var dto in feedbackDto)
            {
                var feedbackItem = new Feedback
                {
                    Id = dto.Id,
                    Comments = dto.Comments,
                    Day = dto.Day,
                    Rating = dto.Rating,
                    Week = dto.Week
                };

                feedback.Add(feedbackItem);
            }
            return feedback;
        }
    }
}