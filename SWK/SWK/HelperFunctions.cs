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
            foreach (var list in lista)
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
        /// <summary>
        /// Función para colocar el tipo de personaje
        /// </summary>
        /// <param name="lista"></param>
        public void EvaluateTypeMB(List<EventSong> lista)
        {
            foreach (var list in lista)
            {
                //list.Position = 1;
                list.sType = list.Velocity > 100 ? 'M' : 'B';
            }
        }

        public void EvaluateResulr(List<EventSong> lista)
        {
            foreach (var list in lista)
            {
                //list.Position = 1;
                list.Result = (short)((list.Position) * 10 + (list.sType == 'M' ? 1 : 2));
            }
        }

        /// <summary>
        /// Asigna la posición en las cooredenadas de 5 bloques de la pantalla
        /// </summary>
        /// <param name="lista"></param>
        public void EvaluatePosition(List<EventSong> lista)
        {
            foreach (var list in lista)
            {
                list.Position = (short)(list.Note - 95);
            }
        }
    }
}
