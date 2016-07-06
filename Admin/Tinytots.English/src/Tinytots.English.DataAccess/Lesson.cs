using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Tinytots.English.DataAccess
{
    public class Lesson
    {
        public Lesson()
        {
            LessonPageMapping = new HashSet<LessonPageMapping>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LessonPageMapping> LessonPageMapping { get; set; }
    }
}
