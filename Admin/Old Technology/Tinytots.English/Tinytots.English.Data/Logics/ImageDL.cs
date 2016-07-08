using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class ImageDL : IDisposable
    {
        AEPEntities _context = null;
        public ImageDL()
        {
            _context = new AEPEntities();
        }        

        public int Insert(Image image)
        {
            image = _context.Images.Add(image);
            _context.SaveChanges();
            return image.Id;
        }

        public Image GetById(int id)
        {
            return _context.Images.Where(x => x.Id == id).FirstOrDefault();        
        }

        public void Update(Image image)
        {
            if(image!= null)
            {
                Image oldImage = GetById(image.Id);
                if(oldImage!= null)
                {
                    oldImage.Description = image.Description;
                    oldImage.Title = image.Title;
                    _context.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            if (id != 0)
            {
                Image image = GetById(id);
                if (image != null)
                {
                    _context.Images.Remove(image);
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
