using System;
using System.Collections.Generic;

namespace Tinytots.English.DataAccess
{
    public partial class Page
    {
        public Page()
        {
            LessonPageMapping = new HashSet<LessonPageMapping>();
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public virtual ICollection<LessonPageMapping> LessonPageMapping { get; set; }
    }
}
