using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Tinytots.English.Data;

namespace Tinytots.English.Business.Logics
{
    public class RandomQuestionGenerator
    {
        private string[] AccentKeys = new string[] { "American", "British" };
        private string AccentText = ConfigurationManager.AppSettings["ProseActivity"].ToString();
        private string Separator = "|";
        public void RandomQuestions(List<Accent> accents, out List<string> output)
        {
            output = new List<string>();
            Dictionary<int, string> KeyGenerator = new Dictionary<int, string>();
            if (accents != null && accents.Count > 0)
            {
                int i = 1;
                while (i <= 10)
                {
                    Random random = new Random();
                    int AccentIndex = random.Next(0, accents.Count);
                    int KeyIndex = random.Next(0, AccentKeys.Length);
                    if (!KeyGenerator.Any(x => x.Key == AccentIndex))
                    {
                        KeyGenerator.Add(AccentIndex, AccentKeys[KeyIndex]);
                        i++;
                    }
                }

                foreach (var item in KeyGenerator)
                {
                    var accentObject = accents[item.Key];
                    string Question = AccentText.Replace("{Accent}", item.Value);
                    string Answer = item.Value == AccentKeys[0].ToString() ? accentObject.American : accentObject.British;
                    string outputObject = string.Concat(Question, Separator, Answer, Separator, accentObject.Id.ToString());
                    output.Add(outputObject);
                }
            }
        }
    }
}
