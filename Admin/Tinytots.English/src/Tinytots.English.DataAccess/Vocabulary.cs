using System;
using System.Collections.Generic;

namespace Tinytots.English.DataAccess
{
    public partial class Vocabulary
    {
        public int Id { get; set; }
        public int? ImageId { get; set; }
        public string Synonym { get; set; }
        public string Word { get; set; }

        public virtual Image Image { get; set; }
    }
}
