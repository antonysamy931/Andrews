using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Tinytots.English.DataAccess
{
    public class Accent
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
