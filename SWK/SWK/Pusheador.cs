using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;

namespace SWK
{
    public class Pusheador
    {
        private Deserializer algo = new Deserializer();
        private HelperFunctions helpers = new HelperFunctions();
        private List<EventSong> elements;

        public Pusheador()
        {
            elements = algo.DeserializeSong();
            helpers.AddTimeSeconds(elements);
            helpers.EvaluatePosition(elements);
            helpers.EvaluateTypeMB(elements);
            var delay = int.Parse(ConfigurationManager.AppSettings["msdelay"]);
            helpers.SyncTimeList(elements, delay);
        }

        public void Proceso()
        {
            Console.WriteLine("Inicia!!!");
            Console.WriteLine("Nota: ", elements.First().Note);
            //Inicializar Whatcher
            for (int i = 0; i <= elements.Count; i++)
            {
                Thread.Sleep(elements[i+1].Time - elements[i].Time);
                Console.WriteLine(elements[i + 1].Type.ToString() + elements[i + 1].Position.ToString());
            }
        }
    }
}
