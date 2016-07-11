using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.DTO.ViewModel
{
    public class LessonModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? Id { get; set; }

        public Lesson Mapping()
        {
            Lesson _lesson = new Lesson();
            _lesson.Name = this.Name;
            _lesson.Description = this.Description;
            if (this.Id != null && this.Id.Value > 0)
                _lesson.Id = this.Id.Value;
            return _lesson;
        }
    }
}
