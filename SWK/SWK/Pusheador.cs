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
            helpers.EvaluateResulr(elements);
            var delay = int.Parse(ConfigurationManager.AppSettings["msdelay"]);
            helpers.SyncTimeList(elements, delay);
        }

        internal void Proceso(ref System.ComponentModel.BackgroundWorker m_oWorker)
        {
            m_oWorker.ReportProgress(elements[0].Result);
            //Inicializar Whatcher
            for (int i = 0; i <= elements.Count; i++)
            {
                Thread.Sleep(elements[i + 1].Time - elements[i].Time);
                m_oWorker.ReportProgress(elements[i + 1].Result);
            }
        }
    }
}
