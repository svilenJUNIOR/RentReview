using System.ComponentModel.DataAnnotations;

namespace RentReview.Models.DataModels.Property
{
    public class EditPropertyDataModel : PropertyDataModel
    {
        public string Id { get; set; }

        [Required]
        public string PictureUrl { get; set; }
    }
}
