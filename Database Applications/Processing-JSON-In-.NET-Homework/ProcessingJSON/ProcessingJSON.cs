namespace ProcessingJSON
{
    using System;
    using System.Linq;
    using System.Net;
    using System.IO;
    using System.Diagnostics;
    using System.Xml;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class ProcessingJSON
    {
        static void Main()
        {
            //DownloadSoftUniRSSFeed();

            var json = ParseXMLToJSON();

            var titles = SelectAllTitles(json);
            foreach (var title in titles)
            {
                //Console.WriteLine(title);
            }

            var pocos = titles.Select(item => JsonConvert.DeserializeObject<POCO>(item.ToString())).ToList();

            PocoToHtml(pocos);
            Process.Start(@"..\..\..\output\news.html");
        }

        public static void DownloadSoftUniRSSFeed()
        {
            var client = new WebClient();
            Directory.CreateDirectory(@"..\..\..\output");
            client.DownloadFile("https://softuni.bg/Feed/News", @"..\..\..\output\news.xml");
            Process.Start(@"..\..\..\output\news.xml");
        }

        public static string ParseXMLToJSON()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\output\news.xml");
            var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static List<JToken> SelectAllTitles(string json)
        {
            var jsonObj = JObject.Parse(json);
            var titles = jsonObj["rss"]["channel"]["item"].ToList();
            return titles;
        }

        public static void PocoToHtml(List<POCO> pocos)
        {
            var result = new StringBuilder();
            result.Append("<!DOCTYPE html><html><head></head><body>");
            foreach (var jsonToPoco in pocos)
            {
                result.Append(jsonToPoco.ToString());
            }

            result.Append("</body></html>");
            File.WriteAllText(@"..\..\..\output\news.html", result.ToString());
        }
    }
}
