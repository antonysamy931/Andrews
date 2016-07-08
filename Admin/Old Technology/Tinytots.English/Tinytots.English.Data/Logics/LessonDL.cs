using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class LessonDL : IDisposable
    {
        private AEPEntities _context = null;
        public LessonDL()
        {
            _context = new AEPEntities();
        }        

        public int Insert(Lesson lesson)
        {
            lesson = _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return lesson.Id;
        }

        public Lesson GetById(int id)
        {
            return _context.Lessons.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Lesson> Get()
        {
            return _context.Lessons.ToList();
        }

        public void Update(Lesson lesson)
        {
            if(lesson != null)
            {
                Lesson oldModel = GetById(lesson.Id);
                if(oldModel != null)
                {
                    oldModel.Description = lesson.Description;
                    oldModel.Name = lesson.Name;
                    _context.SaveChanges();           
                }
            }
            
        }

        public void Delete(int id)
        {
            if(id != 0)
            {
                Lesson lesson = GetById(id);
                if (lesson != null)
                {
                    _context.Lessons.Remove(lesson);
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
