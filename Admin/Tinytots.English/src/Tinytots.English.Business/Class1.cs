using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tinytots.English.DataAccess;

namespace Tinytots.English.Business
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Class1
    {
        private AEPContext _context;
        public Class1()
        {
            _context = new AEPContext();
        }

        public List<Image> Get()
        {
            return _context.Image.ToList();
        }
    }
}
