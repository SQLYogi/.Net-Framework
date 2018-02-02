using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TP09WCFService;

using System.ServiceModel;

namespace TP09WCFServiceHost
{
    public partial class BooksServiceHost : ServiceBase
    {
        ServiceHost svcHost;

        public BooksServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            svcHost = new ServiceHost(typeof(BookService));
            svcHost.Open();
           
        }

        protected override void OnStop()
        {
            svcHost.Close();
        }
    }
}
