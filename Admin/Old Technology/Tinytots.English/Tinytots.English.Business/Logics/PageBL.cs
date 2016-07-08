using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.Data.Logics;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Business.Logics
{
    public class PageBL
    {
        PageDL _pageDL = null;
        LessonDL _lessonDL = null;
        LessonPageMappingDL _mapping = null;
        public PageBL()
        {
            _pageDL = new PageDL();
            _lessonDL = new LessonDL();
            _mapping = new LessonPageMappingDL();
        }

        public PageModel Get(int pageid, int lessonId)
        {
            PageModel model = new PageModel();
            var page = _pageDL.GetById(pageid);
            if(page != null)
            {
                model.Content = page.Content;
                model.Id = page.Id;
            }
            var lesson = _lessonDL.GetById(lessonId);
            if(lesson != null)
            {
                model.Lesson = new DTO.Lesson()
                {
                    Description = lesson.Description,
                    Id = lesson.Id,
                    Name = lesson.Name
                };
                model.LessonId = lesson.Id;
            }
            return model;
        }

        public int Insert(PageModel model)
        {
            var PageId = _pageDL.Insert(PreparePage(model));
            _mapping.Insert(PrepareLessonPageMapping(model.LessonId, PageId));
            return model.LessonId;
        }

        public void Update(PageModel model)
        {
            _pageDL.Update(PreparePage(model));
        }

        public void Delete(int id)
        {
            _pageDL.Delete(id);
            _mapping.Delete(id);
        }

        private Data.Page PreparePage(PageModel model)
        {
            var page = new Data.Page()
            {
                Content = model.Content             
            };

            if (model.Id != null)
                page.Id = model.Id.Value;

            return page;
        }

        private Data.LessonPageMapping PrepareLessonPageMapping(int lessonId, int pageId)
        {
            return new Data.LessonPageMapping()
            {
                LessonId = lessonId,
                PageId = pageId
            };
        }
    }
}
