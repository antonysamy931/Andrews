using System.ComponentModel.DataAnnotations;

namespace Tinytots.English.DTO.ViewModel
{
    public class VocabularyModel
    {        
        public int? Id { get; set; }
        
        [Required]
        public string Word { get; set; }

        [Required]
        public string Synonym { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int? ImageId { get; set; }
    }
}
