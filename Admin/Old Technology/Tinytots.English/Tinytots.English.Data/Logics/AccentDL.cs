using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class AccentDL : IDisposable
    {
        private AEPEntities _context = null;
        public AccentDL()
        {
            _context = new AEPEntities();
        }

        public int Insert(Accent accent)
        {
            accent = _context.Accents.Add(accent);
            _context.SaveChanges();
            return accent.Id;
        }

        public Accent GetById(int id)
        {
            return _context.Accents.Where(x => x.Id == id).FirstOrDefault();
        }
        
        public List<Accent> Get()
        {
            return _context.Accents.ToList();
        }

        public void Update(Accent accent)
        {
            if(accent != null)
            {
                Accent oldAccent = GetById(accent.Id);
                if (oldAccent != null)
                {
                    oldAccent.American = accent.American;
                    oldAccent.British = accent.British;
                    if (accent.ImageId != null)
                        oldAccent.ImageId = accent.ImageId;
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            if (id != 0)
            {
                Accent accent = GetById(id);
                if (accent != null)
                {
                    _context.Accents.Remove(accent);
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
