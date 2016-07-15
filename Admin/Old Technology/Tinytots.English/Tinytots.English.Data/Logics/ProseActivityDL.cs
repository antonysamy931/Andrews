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

        public int Insert(ProseActivity model)
        {
            model = _context.ProseActivities.Add(model);
            _context.SaveChanges();
            return model.Id;
        }

        public void Update(int id, string answer)
        {
            bool Result = false;
            var proseObject = _context.ProseActivities.Where(x => x.Id == id).FirstOrDefault();
            if(proseObject != null)
            {
                if (proseObject.Answer.ToLower().Equals(answer.ToLower()))
                {
                    Result = true;
                }
                proseObject.Result = Result;
                _context.SaveChanges();
            }
        }

        public bool CheckComplete(int userid)
        {
            return _context.ProseActivities.Any(x => x.UserId == userid &&  x.Result == null);
        }
        
        public ProseActivity Get(int id)
        {
            return _context.ProseActivities.Where(x => x.Id == id).FirstOrDefault();
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
