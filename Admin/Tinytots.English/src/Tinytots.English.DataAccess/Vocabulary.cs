using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Tinytots.English.DataAccess
{
    public class Vocabulary
    {
        public int Id { get; set; }
        public int? ImageId { get; set; }
        public string Synonym { get; set; }
        public string Word { get; set; }

        public virtual Image Image { get; set; }
    }
}
