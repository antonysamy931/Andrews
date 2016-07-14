using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class ProseActivityDL : IDisposable
    {
        private AEPEntities _context = null;
        public ProseActivityDL()
        {
            _context = new AEPEntities();
        }
        public void Insert(ProseActivity model)
        {
            _context.ProseActivities.Add(model);
        }
                
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
