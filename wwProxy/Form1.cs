using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace wwProxy
{
    public partial class Form1 : Form
    {
        private WWProxyProvider wwproxy = new WWProxyProvider();
        List<Country> countrylist;
        ProxyCollection proxylist;
        ProxyMonitor proxymonitor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.RefreshSourceSel();
            this.RefreshProxyStatus();
        }

        private void RefreshSourceSel()
        {
            wwproxy.spy1enabled = source1.Enabled;
            this.RefreshCountryList();
        }

        private void RefreshCountryList()
        {
            this.StartBusy("Refreshing country list...");
            countrylist = wwproxy.GetCountryList();
            this.countrySelection.Items.Clear();
            foreach (Country country in countrylist)
            {
                this.countrySelection.Items.Add(String.Format("{0} - {1}", country.name, country.abb));
            }
            this.StopBusy();
        }

        private void StartBusy()
        {
            this.StartBusy("Busy...");
        }

        private void StartBusy(string message)
        {
            this.countrySelection.Enabled = false;
            this.proxySelection.Enabled = false;
            this.StatusLabel.Text = message;
        }

        private void StopBusy()
        {
            this.StopBusy("Idle...");
        }

        private void StopBusy(string message)
        {
            System.GC.Collect();
            this.countrySelection.Enabled = true;
            this.proxySelection.Enabled = true;
            this.StatusLabel.Text = message;
        }

        private void RefreshProxyStatus()
        {
            string proxy = ProxySwitcher.GetProxy();
            if (proxy.Equals(""))
            {
                this.proxyStatusLabel.Text = "No Active Proxy...";
            }
            else
            {
                this.proxyStatusLabel.Text = "http://" + proxy;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void source1_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshSourceSel();
        }

        private void countrySelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.StartBusy("Downloading proxy list...");
            proxylist = wwproxy.GetProxyByCountry(countrylist[(int)this.countrySelection.SelectedIndex]);
            this.proxySelection.Items.Clear();
            foreach (Proxy proxy in proxylist)
            {
                this.proxySelection.Items.Add(proxy);
            }
            this.StopBusy();
        }

        private void btnSetProxy_Click(object sender, EventArgs e)
        {
            this.StartBusy();
            var SelectedProxy = proxylist[this.proxySelection.SelectedIndex];
            if (SelectedProxy.protocol == "http")
            {
                ProxySwitcher.SetProxyOn(String.Format("{0}:{1}", SelectedProxy.ip, SelectedProxy.port));
                this.StopBusy("Successfully set proxy.");
            } else
            {
                errorProvider.SetError(btnSetProxy, "Only support http proxy for now");
                this.StopBusy("Only support http proxy for now");
            }
            this.RefreshProxyStatus();
        }

        private void btnClearProxy_Click(object sender, EventArgs e)
        {
            this.StartBusy();
            ProxySwitcher.SetProxyOff();
            this.StopBusy("Successfully cleared proxy settings.");
            this.RefreshProxyStatus();
        }

        private void proxySelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedProxy = proxylist[this.proxySelection.SelectedIndex];
            if (this.proxymonitor!=null) {
                this.proxymonitor.Destroy();
            }
            this.proxymonitor = new ProxyMonitor(SelectedProxy.ip);
            this.proxymonitor.StartMonitor(new ProxyMonitorReturn(delegate(string ret) { this.StatusLabel.Text = SelectedProxy.ip + " " + ret; }));
        }
    }
}
