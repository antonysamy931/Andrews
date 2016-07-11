using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class PageDL : IDisposable
    {
        private AEPEntities _context = null;
        private LessonPageMappingDL _mapping = null;

        public PageDL()
        {
            _context = new AEPEntities();
            _mapping = new LessonPageMappingDL();
        }

        public int Insert(Page page)
        {
            page = _context.Pages.Add(page);
            _context.SaveChanges();
            return page.Id;
        }

        public Page GetById(int id)
        {
            return _context.Pages.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Page> GetByLessonId(int id)
        {
            return (from o in _context.LessonPageMappings
                    join oo in _context.Pages
                    on o.PageId equals oo.Id
                    where o.LessonId == id
                    select oo).ToList();
        }

        public List<Page> Get()
        {
            return _context.Pages.ToList();
        }

        public void Update(Page page)
        {
            if(page != null)
            {
                Page oldPage = GetById(page.Id);
                if (oldPage != null)
                {
                    oldPage.Content = page.Content;
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            if(id != 0)
            {
                Page page = GetById(id);
                if(page != null)
                {
                    _mapping.Delete(page.Id);
                    _context.Pages.Remove(page);
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
