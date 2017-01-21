using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWK
{
    public class HelperFunctions
    {
        public void AddTimeSeconds(List<EventSong> lista)
        { 
            foreach(var list in lista)
            {
                list.Time = GetMilisecontsFromTicks(list.TimeAbs);
            }
        }

        private TimeSpan GetMilisecontsFromTicks(long p)
        {
            //Aqui
            TimeSpan t = TimeSpan.FromMilliseconds(p);
            return t;
        }

        public void SyncTimeList(List<EventSong> lista, int dif)
        {
            foreach (var list in lista)
            {
                list.TimeAbs += dif;
            }
            AddTimeSeconds(lista);
        }

        public void EvaluateTypeMB(List<EventSong> lista)
        {
            foreach (var list in lista)
            {
                list.Position = 1;
            }
        }

        public void EvaluatePosition(List<EventSong> lista)
        {
            foreach (var list in lista)
            {
                list.Type = 'B';
            }
        }
    }
}
