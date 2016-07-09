using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.Data.Logics;
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
                    models.Add(model);
                }
            }
            return models;
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
