using System;
using System.Collections.Generic;

namespace Tinytots.English.DataAccess
{
    public partial class LessonPageMapping
    {
        public int Id { get; set; }
        public int? LessonId { get; set; }
        public int? PageId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Page Page { get; set; }
    }
}
