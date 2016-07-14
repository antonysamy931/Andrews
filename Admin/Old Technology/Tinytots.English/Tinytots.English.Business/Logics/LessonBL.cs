using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.Data.Logics;
using Tinytots.English.DTO;
using Tinytots.English.DTO.CustomDTO;
using Tinytots.English.DTO.ViewModel;

namespace Tinytots.English.Business.Logics
{
    public class LessonBL
    {
        LessonDL _lessonDL = null;
        PageDL _pageDL = null;
        LessonPageMappingDL _LessonPageMappingDL = null;
        public LessonBL()
        {
            _lessonDL = new LessonDL();
            _pageDL = new PageDL();
            _LessonPageMappingDL = new LessonPageMappingDL();
        }

        public List<LessonDTO> Get()
        {
            List<LessonDTO> models = new List<LessonDTO>();
            var lessons = _lessonDL.Get();
            if (lessons != null && lessons.Count > 0)
            {
                foreach (var item in lessons)
                {
                    LessonDTO model = new LessonDTO();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Description = item.Description;
                    models.Add(model);
                }
            }
            return models;
        }

        public LessonDTO Detail(int id, int? pageId = null)
        {
            LessonDTO lessonDTO = new LessonDTO();
            var lesson = _lessonDL.GetById(id);
            if (lesson != null)
            {
                lessonDTO.Id = lesson.Id;
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

            if (lessonDTO.Pages != null && lessonDTO.Pages.Count > 0)
            {
                if (pageId != null)
                {
                    lessonDTO.PageDTO = lessonDTO.Pages.Where(x => x.Id == pageId.Value).FirstOrDefault();
                    var index = lessonDTO.Pages.FindIndex(x => x.Id == pageId.Value);
                    if (index > 0)
                    {
                        var nextObj = lessonDTO.Pages.Skip(index + 1).FirstOrDefault();
                        if (nextObj != null)
                            lessonDTO.Next = nextObj.Id;
                        var preObj = lessonDTO.Pages.Skip(index - 1).FirstOrDefault();
                        if (preObj != null)
                            lessonDTO.Previous = preObj.Id;
                    }
                }
                else
                {
                    lessonDTO.PageDTO = lessonDTO.Pages.FirstOrDefault();

                    var nextObj = lessonDTO.Pages.Skip(1).FirstOrDefault();
                    if (nextObj != null)
                        lessonDTO.Next = nextObj.Id;
                }
            }
            return lessonDTO;
        }

        public LessonModel GetById(int id)
        {
            LessonModel model = new LessonModel();
            var lesson = _lessonDL.GetById(id);
            if (lesson != null)
            {
                model.Id = lesson.Id;
                model.Name = lesson.Name;
                model.Description = lesson.Description;
            }
            return model;
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

        public void Delete(int id)
        {
            List<int> PageIds = _LessonPageMappingDL.GetPageIds(id);
            if (PageIds != null && PageIds.Count > 0)
            {
                foreach (var item in PageIds)
                {
                    _pageDL.Delete(item);
                    _LessonPageMappingDL.Delete(item);
                }
            }
            _lessonDL.Delete(id);
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
