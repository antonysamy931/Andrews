using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.Data.Logics;
using Tinytots.English.DTO;

namespace Tinytots.English.Business.Logics
{
    public class ImageBL
    {
        ImageDL _imageDL = null;

        public ImageBL()
        {
            _imageDL = new ImageDL();
        }

        public Image Get(int id)
        {
            Image model = new Image();
            var image = _imageDL.GetById(id);
            model.Content = image.Content;
            model.Description = image.Description;
            model.Title = image.Title;
            return model;
        }
    }
}
