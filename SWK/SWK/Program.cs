using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SWK
{
    class Program
    {
        static void Main(string[] args)
        {
            var oAlpha = new ThreadGame();
            Thread oThread = new Thread(new ThreadStart(oAlpha.Ejecuta));
            oThread.Start();
        }
    }

    public class ThreadGame
    {
        // This method that will be called when the thread is started
        public void Ejecuta()
        {
            var push = new Pusheador();
            push.Proceso();
        }
    }

}
