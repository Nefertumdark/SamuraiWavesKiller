using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace SWK
{
    class Program
    {
        static void Main(string[] args)
        {
             var corre = new ClaseCorre();
             corre.Proceso();

            Thread.Sleep(100000);
        }
    }

    public  class ClaseCorre
    {
        BackgroundWorker m_oWorker;
        public string cambioAplicar;

        public ClaseCorre()
        {
            m_oWorker = new BackgroundWorker();

            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler
                    (m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;
        }

        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Termino
        }

        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // ReportProgress() function.  
            cambioAplicar = e.ProgressPercentage.ToString();
            Console.WriteLine(cambioAplicar.ToString());
            //Hacer la magiaaaaaaaaaaaaaaaaaa
            //Hacer la magiaaaaaaaaaaaaaaaaaa
            //Hacer la magiaaaaaaaaaaaaaaaaaa
            //Hacer la magiaaaaaaaaaaaaaaaaaa
            //Hacer la magiaaaaaaaaaaaaaaaaaa
            //Hacer la magiaaaaaaaaaaaaaaaaaa
            //Hacer la magiaaaaaaaaaaaaaaaaaa
            //Hacer la magiaaaaaaaaaaaaaaaaaa
        }

        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var push = new Pusheador();
            push.Proceso(ref m_oWorker);
            m_oWorker.ReportProgress(100);
        }

        internal void Proceso()
        {
            m_oWorker.RunWorkerAsync();
        }
    }
}
