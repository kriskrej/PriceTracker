using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace lab_PriceTracker {
    public class CeneoPage {
        public List<ShopItem> shopItems = new List<ShopItem>();
        public CeneoPage(string url) {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var products = doc.DocumentNode.SelectNodes("/html/body/div[2]/div[3]/div[2]/div[2]/div/section/div[3]/div");
            if (products == null)
                products = doc.DocumentNode.SelectNodes("/html/body/div[2]/div[3]/div[2]/div[2]/div/section/div[2]/div");
            if (products == null)
                Console.WriteLine("Nic nie znalazłem :(");
            else foreach (var product in products) {
                    var item = new ShopItem(product);
                    if (item.name != "unknown")
                        shopItems.Add(item);
                }

            foreach (var item in shopItems)
                Console.WriteLine($" * {item.name} - {item.price}");
        }
    }

    public class ShopItem {
        public string name = "unknown";
        public string price;

        public ShopItem(HtmlNode node) {
            AssignName(node);
            AssignPrice(node);
        }

        private void AssignPrice(HtmlNode node) {
            var span1 = node.SelectSingleNode("div[1]/div[2]/div[2]/a/span[1]");
            var span2 = node.SelectSingleNode("div[1]/div[2]/div[2]/a/span[2]");
            if (span1 != null && span1.InnerText.Contains("zł")) {
                price = span1.InnerText;
                return;
            }
            if (span2 != null && span2.InnerText.Contains("zł")) {
                price = span2.InnerText;
                return;
            }
        }

        private void AssignName(HtmlNode node) {
            var currentNode = node.SelectSingleNode("div[1]/div[2]/div/div/div/strong/a");
            if (currentNode != null)
                name = currentNode.InnerText;
        }
    }
}