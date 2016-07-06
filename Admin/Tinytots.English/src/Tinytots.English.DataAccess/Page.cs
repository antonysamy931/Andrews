using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Tinytots.English.DataAccess
{
    public class Page
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
