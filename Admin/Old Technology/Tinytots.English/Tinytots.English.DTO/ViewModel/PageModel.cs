using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tinytots.English.DTO.ViewModel
{
    public class PageModel
    {       
        public int? Id { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public int? LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public Page Mapping()
        {
            Page _page = new Page();
            _page.Content = this.Content;
            if (this.Id != null)
                _page.Id = this.Id.Value;
            return _page;    
        }
    }
}
