using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.DTO.CustomDTO
{
    public class AccentDTO
    {
        public List<AccentModel> Accents { get; set; }
        public AccentModel Default { get; set; }
        public int Next { get; set; }
        public int Previous { get; set; }
    }
}
