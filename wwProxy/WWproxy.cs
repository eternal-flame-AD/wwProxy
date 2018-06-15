using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using AngleSharp.Scripting.JavaScript;
using AngleSharp;

namespace wwProxy
{
    class WWProxyProvider
    {
        public bool spy1enabled { get; set; }
        private SpyOneProvider sp1;
        public List<Country> GetCountryList()
        {
            List<Country> res = new List<Country>();
            if (this.spy1enabled)
            {
                sp1 = new SpyOneProvider();
                sp1.GetCountryList(res);
            }
            return res;
        }
        public ProxyCollection GetProxyByCountry(Country country)
        {
            return sp1.GetProxyByCountry(country);
        }
    }
    class Country
    {
        public string abb { get; }
        public string name { get; }
        public Country(string abb, string name)
        {
            this.abb = abb;
            this.name = name;
        }
    }
    class Proxy
    {
        public string ip;
        public string port;
        public string protocol;
        public bool anonymous;
        public bool display = true;
        public override string ToString()
        {
            return String.Format("{0}://{1}:{2}", protocol, ip, port);
        }
    }
    class ProxyCollection: List<Proxy>
    {
        public void FilterByProtocol(string protocol)
        {
            foreach (Proxy proxy in this)
            {
                proxy.display = proxy.protocol.Equals(protocol);
            }
        }
    }
    interface ProxyProvider
    {
        void GetCountryList(List<Country> res);
        ProxyCollection GetProxyByCountry(Country country);
    }
    class SpyOneProvider: ProxyProvider
    {
        private WebClient client = new WebClient();
        public void GetCountryList(List<Country> res)
        {
            string response = client.DownloadString("http://spys.one/en/");
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(response);
            HtmlNode countrysel = html.DocumentNode.SelectSingleNode(@"//select[@name='tldc']");
            foreach (Match node in Regex.Matches(countrysel.InnerHtml, @"(\w+)\s-\s(\w+)"))
            {
                var country = new Country(node.Value.Substring(0, node.Value.IndexOf(@" ")), node.Value);
                res.Add(country);
            }
        }

        public ProxyCollection GetProxyByCountry(Country country)
        {
            string url = String.Format("http://spys.one/free-proxy-list/{0}/", country.abb);
            string response = client.DownloadString(url);
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(response);
            JavaScriptEngine parser = new JavaScriptEngine();
            var jscontext = new AngleSharp.Parser.Html.HtmlParser().Parse(response);
            parser.EvaluateScript(jscontext,html.DocumentNode.SelectSingleNode(@"/html/body/script").InnerText);
            var res = new ProxyCollection();
            foreach (Match proxyitem in Regex.Matches(response, @"((\d+)\.(\d+)\.(\d+)\.(\d+))(<script(.*?)</script>)(.*?)(HTTP</font></a>|HTTP</font><font|SOCKS5)"))
            {
                var proxy = new Proxy();
                string port = (string)parser.EvaluateScript(jscontext, "\"\"+"+Regex.Match(proxyitem.Value, @"(?<=\+)(.*?)(?=\)</script)").Value);
                string ip = Regex.Match(proxyitem.Value, @"(\d+)\.(\d+)\.(\d+)\.(\d+)").Value;
                proxy.ip = ip;
                proxy.port = port;
                switch (proxyitem.Groups[9].Value)
                {
                    case @"HTTP</font></a>": proxy.protocol = "http"; break;
                    case @"HTTP</font><font": proxy.protocol = "https"; break;
                    case @"SOCKS5": proxy.protocol = "socks5"; break;
                    default: proxy.protocol = "unknown"; break;
                }
                res.Add(proxy);
            }
            return res;
        }
    }
}
