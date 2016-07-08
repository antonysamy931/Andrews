using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.DTO.CustomDTO
{
    public class LessonDTO
    {       
        public string Name { get; set; }
        public string Description { get; set; }

        public Page PageDTO { get; set; }

        public List<Page> Pages { get; set; }
    }
}
