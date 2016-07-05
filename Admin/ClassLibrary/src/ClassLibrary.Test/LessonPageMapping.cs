using System;
using System.Collections.Generic;

namespace ClassLibrary.Test
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
