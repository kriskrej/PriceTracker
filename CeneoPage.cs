using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;

namespace lab_PriceTracker {
    public class CeneoPage {
        public CeneoPage(string url) {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            File.WriteAllText("pobrane.txt", doc.Text);
            var products = doc.DocumentNode.SelectNodes("/html/body/div[2]/div[3]/div[2]/div[2]/div/section/div[3]");

            Console.WriteLine(products.Count);


        }
    }
}