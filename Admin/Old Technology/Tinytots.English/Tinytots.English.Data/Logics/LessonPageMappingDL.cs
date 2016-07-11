using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class LessonPageMappingDL : IDisposable
    {
        AEPEntities _context = null;

        public LessonPageMappingDL()
        {
            _context = new AEPEntities();
        }

        public int Insert(LessonPageMapping mapping)
        {
            mapping = _context.LessonPageMappings.Add(mapping);
            _context.SaveChanges();
            return mapping.Id;
        }

        public LessonPageMapping GetById(int id)
        {
            return _context.LessonPageMappings.Where(x => x.Id == id).FirstOrDefault();
        }        

        public List<int> GetPageIds(int id)
        {            
            return _context.LessonPageMappings.Where(x => x.LessonId.Value == id && x.PageId != null).Select(x => x.PageId.Value).ToList();         
        }

        public void Delete(int id)
        {
            if(id != 0)
            {
                LessonPageMapping mapping = _context.LessonPageMappings.Where(x => x.PageId == id).FirstOrDefault();
                if (mapping != null)
                {
                    _context.LessonPageMappings.Remove(mapping);
                    _context.SaveChanges();
                }
            }            
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
