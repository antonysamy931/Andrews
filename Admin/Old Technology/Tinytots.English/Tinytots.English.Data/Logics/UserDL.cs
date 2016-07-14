using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class UserDL : IDisposable
    {
        private AEPEntities _context = null;

        public UserDL()
        {
            _context = new AEPEntities();
        }
        public int CheckUser(string userName, string password)
        {
            int userId = 0;
            var user =_context.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (user != null)
                userId = user.Id;
            return userId;
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(User user)
        {
            var User =_context.Users.Add(user);
            _context.SaveChanges();
            return User.Id;
        }

        public void Update(User user)
        {
            var userobj = _context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if(userobj != null)
            {
                userobj.FirstName = user.FirstName;
                userobj.LastName = user.LastName;
                userobj.Address = user.Address;
                userobj.Email = user.Email;
                userobj.Phone = user.Phone;
                userobj.UserName = user.UserName;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if(user!= null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
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
