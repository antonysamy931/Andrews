using System.ComponentModel.DataAnnotations;

namespace Tinytots.English.DTO.ViewModel
{
    public class AccentModel
    {
        public int? Id { get; set; }

        [Display(Name ="British Word")]
        [Required]
        public string British { get; set; }

        [Display(Name = "American Word")]
        [Required]
        public string American { get; set; }

        public int? ImageId { get; set; }

        public string Name { get; set; }

        public string Description {get;set;}
                
        public string Image { get; set; }        
    }
}
