using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiddleMovie
{
    public class WGetter
    {
        public string getURLContent(string url)
        {
            var cli = new System.Net.WebClient();
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(cli.DownloadString(url));
            StringBuilder ret = new StringBuilder();
            foreach (HtmlNode node in document.DocumentNode.ChildNodes)
            {
                if (node.Name == "html")
                {
                    foreach (HtmlNode childnode in node.ChildNodes)
                    {
                        ret.Append(node.Id);
                    }
                }
            }

            return ret.ToString();
        }
    }
}
