using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tinytots.English.Master.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public string ConvertByteToString(byte[] image)
        {
            return Convert.ToBase64String(image);
        }

        public byte[] CovertStringToByte(string image)
        {
            return Convert.FromBase64String(image);
        }

        public byte[] ConvertStreamToByte(Stream stream)
        {
            byte[] data;
            using (Stream inputStream = stream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            return data;
        }
    }
}