using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.NetworkInformation;

namespace wwProxy
{
    delegate void ProxyMonitorReturn(string rtt);
    class ProxyMonitor
    {
        private string ip;
        private string result;
        private Thread monitorthread;
        public ProxyMonitor(string ip)
        {
            this.ip = ip;
        }
        public void StartMonitor(ProxyMonitorReturn ret)
        {
            ThreadStart threads = new ThreadStart(()=>this.Monitor(ret));
            monitorthread = new Thread(threads);
            monitorthread.Start();
        }
        private void Monitor(ProxyMonitorReturn ret)
        {
            while (true)
            {
                Ping tester = new Ping();
                PingReply reply = tester.Send(ip, 5);
                if (reply.Status == IPStatus.Success)
                {
                    ret(reply.RoundtripTime.ToString() + "ms");
                } else
                {
                    ret(reply.Status.ToString());
                }
                Thread.Sleep(3000);
            }
        }
        public void Destroy()
        {
            monitorthread.Abort();
        }
    }
}
