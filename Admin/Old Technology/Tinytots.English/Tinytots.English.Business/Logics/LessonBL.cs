using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.Data.Logics;
using Tinytots.English.DTO;
using Tinytots.English.DTO.CustomDTO;

namespace Tinytots.English.Business.Logics
{
    public class LessonBL
    {
        LessonDL _lessonDL = null;
        PageDL _pageDL = null;
        public LessonBL()
        {
            _lessonDL = new LessonDL();
            _pageDL = new PageDL();
        }

        public LessonDTO GetById(int id, int? pageId = null)
        {
            LessonDTO lessonDTO = new LessonDTO();
            var lesson = _lessonDL.GetById(id);
            if (lesson != null)
            {
                lessonDTO.Name = lesson.Name;
                lessonDTO.Description = lesson.Description;
            }

            var pages = _pageDL.GetByLessonId(id);
            if (pages != null && pages.Count > 0)
            {
                lessonDTO.Pages = pages.Select(x => new Page
                {
                    Content = x.Content,
                    Id = x.Id
                }).ToList();
            }

            if (pageId != null)
            {
                lessonDTO.PageDTO = lessonDTO.Pages.Where(x => x.Id == pageId.Value).FirstOrDefault();
            }
            else
            {
                lessonDTO.PageDTO = lessonDTO.Pages.FirstOrDefault();
            }

            return lessonDTO;
        }

        public int Insert(Lesson lesson)
        {            
            var id = _lessonDL.Insert(Mapping(lesson));
            return id;
        }

        public int Update(Lesson lesson)
        {
            _lessonDL.Update(Mapping(lesson));
            return lesson.Id;
        }

        public void Delete(Lesson lesson)
        {
            _lessonDL.Delete(lesson.Id);
        }

        private Data.Lesson Mapping(Lesson lesson)
        {
            Data.Lesson _lesson = new Data.Lesson();
            _lesson.Description = lesson.Description;
            _lesson.Name = lesson.Name;
            if (lesson.Id != 0)
                _lesson.Id = lesson.Id;
            return _lesson;
        }
    }
}
