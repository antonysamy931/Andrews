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
    public class ProseActivityBL
    {
        private ProseActivityDL _ProseActivityDL = null;
        private QuestionSetDL _QuestionSetDL = null;
        private RandomQuestionGenerator _Prepare = null;
        private AccentDL _AccentDL = null;
        public ProseActivityBL()
        {
            _ProseActivityDL = new ProseActivityDL();
            _QuestionSetDL = new QuestionSetDL();
            _Prepare = new RandomQuestionGenerator();
            _AccentDL = new AccentDL();
        }

        public void Insert(int userId)
        {
            if (!_ProseActivityDL.CheckComplete(userId))
            {
                List<int> ProseActivities = new List<int>();
                var accents = _AccentDL.Get();
                List<string> Questions = null;
                _Prepare.RandomQuestions(accents, out Questions);
                foreach (var item in Questions)
                {
                    var SplitItem = item.Split('|');
                    if (SplitItem.Length > 0)
                    {
                        ProseActivity model = new ProseActivity();
                        model.Question = SplitItem[0];
                        model.Answer = SplitItem[1];
                        model.AccentId = Convert.ToInt32(SplitItem[2]);
                        model.Datetime = DateTime.UtcNow;
                        model.UserId = userId;
                        var proseId = _ProseActivityDL.Insert(model);
                        ProseActivities.Add(proseId);
                    }
                }

                var proseIds = string.Join(",", ProseActivities.ToArray());
                QuestionSet questionSet = new QuestionSet();
                questionSet.QuestionId = proseIds;
                questionSet.UserId = userId;
                questionSet.DateCreated = DateTime.UtcNow;
                _QuestionSetDL.Insert(questionSet);
            }
        }

        public ProseActivityModel GetById(int userid, int? id, bool skipPaging = false)
        {
            ProseActivityModel model = new ProseActivityModel();
            List<string> questionIds = null;

            if (!skipPaging)
            {
                var questions = _QuestionSetDL.Get(userid);
                if (questions != null)
                {
                    questionIds = questions.QuestionId.Split(',').ToList();
                    if (id == null)
                    {
                        id = Convert.ToInt32(questionIds.FirstOrDefault());
                    }
                }
            }

            model.Id = id.Value;
            var proseActivity = _ProseActivityDL.Get(model.Id);
            model.Question = proseActivity.Question;
            model.Result = proseActivity.Result;

            var accent = _AccentDL.GetById(proseActivity.AccentId.Value);
            model.American = accent.American;
            model.British = accent.British;
            model.ImageId = accent.ImageId.Value;
            if (!skipPaging)
            {
                var index = questionIds.FindIndex(x => x == id.Value.ToString());
                if (index > 0)
                {
                    var nextObj = questionIds.Skip(index + 1).FirstOrDefault();
                    if (!string.IsNullOrEmpty(nextObj))
                        model.Next = Convert.ToInt32(nextObj);
                    var preObj = questionIds.Skip(index - 1).FirstOrDefault();
                    if (!string.IsNullOrEmpty(preObj))
                        model.Prv = Convert.ToInt32(preObj);
                }
                else
                {
                    var nextObj = questionIds.Skip(1).FirstOrDefault();
                    if (!string.IsNullOrEmpty(nextObj))
                        model.Next = Convert.ToInt32(nextObj);
                }
            }
            return model;
        }

        public List<ProseActivityModel> Get(int userid)
        {
            List<ProseActivityModel> model = new List<ProseActivityModel>();
            var questions = _QuestionSetDL.Get(userid);
            if (questions != null)
            {
                var questionIds = questions.QuestionId.Split(',').ToList();
                foreach (var item in questionIds)
                {
                    var activity = GetById(userid, Convert.ToInt32(item), true);
                    model.Add(activity);
                }
            }
            return model;
        }

        public void Update(int id, string answer)
        {
            _ProseActivityDL.Update(id, answer);
        }
    }
}
