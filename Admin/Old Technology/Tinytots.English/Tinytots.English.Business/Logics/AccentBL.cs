using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.Data.Logics;
using Tinytots.English.DTO.CustomDTO;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Business.Logics
{
    public class AccentBL
    {
        private AccentDL _accentDL = null;
        private ImageDL _imageDL = null;

        public AccentBL()
        {
            _accentDL = new AccentDL();
            _imageDL = new ImageDL();
        }

        public List<AccentModel> GetAll()
        {
            List<AccentModel> models = new List<AccentModel>();
            var accents = _accentDL.Get();
            if(accents != null && accents.Count > 0)
            {
                foreach(var accent in accents)
                {
                    AccentModel model = new AccentModel();
                    model.American = accent.American;
                    model.British = accent.British;
                    model.Id = accent.Id;
                    model.ImageId = accent.ImageId;
                    model.Name = accent.Image.Title;
                    model.Description = accent.Image.Description;
                    models.Add(model);
                }
            }
            return models;

        }

        public AccentDTO GetAll(int? id = null)
        {
            AccentDTO model = new AccentDTO();
            model.Accents = GetAll();
            if (id != null)
            {
                model.Default = model.Accents.Where(x => x.Id == id.Value).FirstOrDefault();
                var index = model.Accents.FindIndex(x => x.Id == id.Value);
                if(index > 0)
                {
                    var nextObj = model.Accents.Skip(index + 1).FirstOrDefault();
                    if (nextObj != null)
                        model.Next = nextObj.Id.Value;
                    var preObj = model.Accents.Skip(index - 1).FirstOrDefault();
                    if (preObj != null)
                        model.Previous = preObj.Id.Value;
                }
            }
            else
            {
                model.Default = model.Accents.FirstOrDefault();
                var nextObj = model.Accents.Skip(1).FirstOrDefault();
                if (nextObj != null)
                    model.Next = nextObj.Id.Value;
            }
            return model;
        }
        public AccentModel Get(int id)
        {
            AccentModel model = new AccentModel();
            var accent = _accentDL.GetById(id);
            if(accent!= null)
            {
                model.Id = accent.Id;
                model.American = accent.American;
                model.British = accent.British;
                model.ImageId = accent.ImageId;
            }
            return model;
        }

        public int Insert(AccentModel model)
        {
            Data.Accent accent = Mapping(model);
            if (!string.IsNullOrEmpty(model.Image))
            {
                var imageId = _imageDL.Insert(ImageMapping(model));
                accent.ImageId = imageId;
            }
            var AccentId = _accentDL.Insert(accent);
            return AccentId;
        }

        public void Update(AccentModel model)
        {
            Data.Accent accent = Mapping(model);
            if (!string.IsNullOrEmpty(model.Image))
            {
                var imageId = _imageDL.Insert(ImageMapping(model));
                accent.ImageId = imageId;
            }
            _imageDL.Update(ImageMapping(model));
            _accentDL.Update(accent);
        }

        public void Delete(int id)
        {
            _accentDL.Delete(id);
        }

        private Data.Accent Mapping(AccentModel model)
        {
            var accent = new Data.Accent() {
                American = model.American,
                British = model.British                                
            };
            if(model.Id != null)
            {
                accent.Id = model.Id.Value;
            }
            return accent;
        }

        private Data.Image ImageMapping(AccentModel model)
        {
            var image = new Data.Image()
            {
                Content = model.Image,
                Title = model.Name,
                Description = model.Description
            };

            if (model.ImageId != null && model.ImageId.Value > 0)
                image.Id = model.ImageId.Value;

            return image;
        }
    }
}
