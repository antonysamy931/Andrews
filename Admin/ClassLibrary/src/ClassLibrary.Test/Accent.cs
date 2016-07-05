using System;
using System.Collections.Generic;

namespace ClassLibrary.Test
{
    public partial class Accent
    {
        public Accent()
        {
            ProseActivity = new HashSet<ProseActivity>();
        }

        public int Id { get; set; }
        public string American { get; set; }
        public string British { get; set; }
        public int? ImageId { get; set; }

        public virtual ICollection<ProseActivity> ProseActivity { get; set; }
        public virtual Image Image { get; set; }
    }
}
