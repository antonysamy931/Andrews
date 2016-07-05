using System;
using System.Collections.Generic;

namespace Tinytots.English.DataAccess
{
    public partial class ProseActivity
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
