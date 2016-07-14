using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.Data;
using Tinytots.English.Data.Logics;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Business.Logics
{
    public class UserBL
    {
        public UserDL _UserDL = null;
        public UserBL()
        {
            _UserDL = new UserDL();
        }

        public List<UserModel> Get()
        {
            List<UserModel> models = new List<UserModel>();
            var Users = _UserDL.Get();
            if(Users != null && Users.Count > 0)
            {
                foreach (var user in Users)
                {
                    var model = new UserModel()
                    {
                        Address = user.Address,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        Id = user.Id,
                        LastName = user.LastName,
                        Phone = Convert.ToInt32(user.Phone),
                        UserName = user.UserName
                    };
                    models.Add(model);
                }
            }
            return models;
        }

        public UserModel GetById(int id)
        {
            UserModel model = new UserModel();
            var user = _UserDL.GetById(id);
            if(user != null)
            {
                model.Address = user.Address;
                model.Email = user.Email;
                model.FirstName = user.FirstName;
                model.Id = user.Id;
                model.LastName = user.LastName;
                model.Phone = Convert.ToInt32(user.Phone);
                model.UserName = user.UserName;
            }
            return model;
        }

        public void Create(UserModel model)
        {
            var user = UserMapping(model);
            _UserDL.Insert(user);
        }

        public void Update(UserModel model)
        {
            _UserDL.Update(UserMapping(model));            
        }

        public void Delete(int id)
        {
            _UserDL.Delete(id);
        }

        public int CheckUser(LoginModel model)
        {
            return _UserDL.CheckUser(model.Username, GetBase64String(model.Password));
        }

        private User UserMapping(UserModel model)
        {
            var user = new User()
            {
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                IsActive = true,
                LastName = model.LastName,
                Phone = Convert.ToString(model.Phone),
                UserName = model.UserName
            };

            if(model.Id != null && model.Id > 0)
            {
                user.Id = model.Id.Value;
            }

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = GetBase64String(model.Password);
            }
            return user;
        }

        private string GetBase64String(string value)
        {
            return Convert.ToBase64String(GetByte(value));
        }
        private byte[] GetByte(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

    }
}
