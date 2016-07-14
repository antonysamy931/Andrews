using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;
using System.Threading.Tasks;

namespace Tinytots.English.Teacher.Controllers
{
    public class SpeechController : Controller
    {
        public Task<FileStreamResult> Speak(string text)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var synthesizer = new SpeechSynthesizer())
                {
                    var ms = new MemoryStream();
                    synthesizer.Rate = 1;                    
                    synthesizer.SetOutputToWaveStream(ms);
                    synthesizer.Speak(text);

                    ms.Position = 0;
                    return new FileStreamResult(ms, "audio/wav");
                }
            });
        }
    }
}