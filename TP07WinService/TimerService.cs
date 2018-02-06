using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TP07WinService
{
    public partial class TimerService : ServiceBase
    {
        int counter;
        Timer timer;

        public TimerService()
        {
            InitializeComponent();
            counter = 1;
            timer = new Timer(5000);
            timer.Elapsed += Timer_Elapsed;
        }

        protected override void OnStart(string[] args)
        {                       
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            EventLog.WriteEntry($"Timer ellapsed {counter++} since service started!");
            
        }

        protected override void OnStop()
        {
            timer.Stop();
        }
    }
}
