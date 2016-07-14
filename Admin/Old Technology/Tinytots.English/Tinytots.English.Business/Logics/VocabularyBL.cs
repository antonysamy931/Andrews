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
    public class VocabularyBL
    {
        private VocabularyDL _vocabularyDL = null;
        private ImageDL _imageDL = null;
        public VocabularyBL()
        {
            _vocabularyDL = new VocabularyDL();
            _imageDL = new ImageDL();
        }
        
        public List<VocabularyModel> GetAll()
        {
            List<VocabularyModel> models = new List<VocabularyModel>();
            var vocabularies = _vocabularyDL.Get();
            if(vocabularies != null && vocabularies.Count > 0)
            {
                foreach(var item in vocabularies)
                {
                    VocabularyModel model = new VocabularyModel();
                    model.Id = item.Id;
                    model.Word = item.Word;
                    model.Synonym = item.Synonym;
                    model.ImageId = item.ImageId;
                    models.Add(model);
                }
            }
            return models;
        }

        public VocabularyDTO GetAll(int? id = null)
        {
            VocabularyDTO model = new VocabularyDTO();
            model.Vocabularies = GetAll();
            if(id != null)
            {
                model.Default = model.Vocabularies.Where(x => x.Id == id.Value).FirstOrDefault();
                var index = model.Vocabularies.FindIndex(x => x.Id == id.Value);
                if(index > 0)
                {
                    var nextObj = model.Vocabularies.Skip(index + 1).FirstOrDefault();
                    if (nextObj != null)
                        model.Next = nextObj.Id.Value;
                    var preObj = model.Vocabularies.Skip(index - 1).FirstOrDefault();
                    if (preObj != null)
                        model.Previous = preObj.Id.Value;
                }
            }
            else
            {
                model.Default = model.Vocabularies.FirstOrDefault();
                var nextObj = model.Vocabularies.Skip(1).FirstOrDefault();
                if (nextObj != null)
                    model.Next = nextObj.Id.Value;
            }
            return model;
        }

        public VocabularyModel Get(int id)
        {
            VocabularyModel model = new VocabularyModel();
            var Vocabulary = _vocabularyDL.GetById(id);
            if(Vocabulary!= null)
            {
                model.Word = Vocabulary.Word;
                model.Synonym = Vocabulary.Synonym;
                model.ImageId = Vocabulary.ImageId;
                model.Id = Vocabulary.Id;
            }
            return model;
        }

        public int Insert(VocabularyModel model)
        {
            if (!string.IsNullOrEmpty(model.Image))
            {
                var imageId = _imageDL.Insert(ImageMapping(model));
                model.ImageId = imageId;
            }
            var id = _vocabularyDL.Insert(Mapping(model));
            return id;
        }

        public void Update(VocabularyModel model)
        {
            if (!string.IsNullOrEmpty(model.Image))
            {
                var imageId = _imageDL.Insert(ImageMapping(model));
                model.ImageId = imageId;
            }
            _vocabularyDL.Update(Mapping(model));
        }

        public void Delete(int id)
        {
            _vocabularyDL.Delete(id);
        }
        private Data.Vocabulary Mapping(VocabularyModel model)
        {
            var Vocabulary = new Data.Vocabulary()
            {
                Word = model.Word,
                Synonym = model.Synonym                
            };
            if(model.ImageId != null)
            {
                Vocabulary.ImageId = model.ImageId;
            }
            if(model.Id != null)
            {
                Vocabulary.Id = model.Id.Value;
            }
            return Vocabulary;
        }

        private Data.Image ImageMapping(VocabularyModel model)
        {
            return new Data.Image()
            {
                Content = model.Image,
                Title = model.Name,
                Description = model.Description
            };
        }

    }
}
