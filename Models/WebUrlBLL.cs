using System;
using System.Collections.Generic;
using System.Net;
using HtmlAgilityPack;

namespace Website1.Models
{
    public class WebUrlBLL
    {
        public ListUrlReturn LURGetImageUrls(string url)
        {
            ListUrlReturn LURReturnObj = new ListUrlReturn();
            LURReturnObj.ImgUrl = new List<string>();
            List<string> lListUrls = new List<string>();

            Uri uUri = new Uri(url);
            string sBaseUrl = uUri.GetLeftPart(System.UriPartial.Authority);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
            WebResponse response = request.GetResponse();
            var stream = response.GetResponseStream();

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(stream);
            var htmlNodeColl = htmlDoc.DocumentNode.SelectNodes("//img[@src]");

            foreach (HtmlNode node in htmlNodeColl)
            {
                if (node != null)
                {

                    string sSrc = node.Attributes["src"].Value;

                    if (sBaseUrl.EndsWith("/"))
                    {
                        sBaseUrl = sBaseUrl.Substring(0, url.Length - 1);
                    }
                    if (sSrc.StartsWith("//"))
                    {
                        sSrc = sSrc.Substring((2));
                    }
                    if (sSrc.EndsWith("/"))
                    {
                        sSrc = sSrc.Substring(0, sSrc.Length - 1);
                    }
                    if (sSrc.Contains("?"))
                    {
                        sSrc = sSrc.Remove(sSrc.IndexOf("?"));
                    }
                    else
                    {
                        LURReturnObj.ImgUrl.Add(sBaseUrl + sSrc);
                    }
                }
                else
                {
                    LURReturnObj.ErrorMessage = "An Error Occured";
                }
            }

            lListUrls = LURReturnObj.ImgUrl;
            return LURReturnObj;
        }
    }
}