﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.DTO.ViewModel
{
    public class ProseActivityModel
    {
        public int Id { get; set; }
        public string American { get; set; }
        public string British { get; set; }
        public string Question { get; set; }
        public bool? Result { get; set; }
        public int ImageId { get; set; }
        public int Next { get; set; }
        public int Prv { get; set; }
    }
}
