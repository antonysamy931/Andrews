using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tinytots.English.Business.Logics;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Teacher.Controllers
{
    public class VocabularyController : Controller
    {
        private VocabularyBL _VocabularyBL = null;
        public VocabularyController()
        {
            _VocabularyBL = new VocabularyBL();
        }
        // GET: Vocabulary
        public ActionResult Index(int? page = null)
        {
            var model = _VocabularyBL.GetAll(page);
            return View(model);
        }
    }
}