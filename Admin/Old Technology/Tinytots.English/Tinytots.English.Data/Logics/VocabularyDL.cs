using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinytots.English.Data.Logics
{
    public class VocabularyDL : IDisposable
    {
        private AEPEntities _context = null;

        public VocabularyDL()
        {
            _context = new AEPEntities();
        }

        public int Insert(Vocabulary vocabulary)
        {
            vocabulary = _context.Vocabularies.Add(vocabulary);
            _context.SaveChanges();
            return vocabulary.Id;
        }

        public Vocabulary GetById(int id)
        {
            return _context.Vocabularies.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Vocabulary> Get()
        {
            return _context.Vocabularies.ToList();
        }

        public void Update(Vocabulary vocabulary)
        {
            if (vocabulary != null)
            {
                Vocabulary oldVocabulary = GetById(vocabulary.Id);
                oldVocabulary.Word = vocabulary.Word;
                oldVocabulary.Synonym = vocabulary.Synonym;
                if (vocabulary.ImageId != null)
                    oldVocabulary.ImageId = vocabulary.ImageId;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            if (id != 0)
            {
                Vocabulary vocabulary = GetById(id);
                if (vocabulary != null)
                {
                    _context.Vocabularies.Remove(vocabulary);
                    _context.SaveChanges();
                }
            }            
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
