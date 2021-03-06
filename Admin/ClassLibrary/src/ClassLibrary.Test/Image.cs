using System;
using System.Collections.Generic;

namespace ClassLibrary.Test
{
    public partial class Image
    {
        public Image()
        {
            Accent = new HashSet<Accent>();
            Vocabulary = new HashSet<Vocabulary>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Accent> Accent { get; set; }
        public virtual ICollection<Vocabulary> Vocabulary { get; set; }
    }
}
