using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Tinytots.English.DataAccess
{
    public class ProseActivity
    {
        public int Id { get; set; }
        public int? AccentId { get; set; }
        public string Answer { get; set; }
        public DateTime? Datetime { get; set; }
        public string Identity { get; set; }
        public string Question { get; set; }
        public bool? Result { get; set; }

        public virtual Accent Accent { get; set; }
    }
}
