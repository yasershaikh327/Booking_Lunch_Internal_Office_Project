using System.ComponentModel.DataAnnotations;

namespace FoodManagement_UI.Services.Models
{
    public class CronJobModel
    {
        [Required(ErrorMessage = "Please enter the vegetable count.")]
        public int VegCount { get; set; }

        [Required(ErrorMessage = "Please enter the non-vegetable count.")]
        public int NonvegCount { get; set; }

        [Required(ErrorMessage = "Please enter the total count.")]
        public int Count { get; set; }
    }
}