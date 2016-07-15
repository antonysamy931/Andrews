using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class QuestionSetDL : IDisposable
    {
        private AEPEntities _context = null;
        public QuestionSetDL()
        {
            _context = new AEPEntities();
        }

        public QuestionSet Get(int userid)
        {
            return _context.QuestionSets.Where(x => x.UserId == userid).OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public List<QuestionSet> GetAll(int userid)
        {
            return _context.QuestionSets.Where(x => x.UserId == userid).ToList();
        }

        public void Insert(QuestionSet model)
        {
            _context.QuestionSets.Add(model);
            _context.SaveChanges();
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
