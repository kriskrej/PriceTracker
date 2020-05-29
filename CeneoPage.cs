using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace lab_PriceTracker {
    public class CeneoPage {
        List<ShopItem> shopItems = new List<ShopItem>();
        public CeneoPage(string url) {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var products = doc.DocumentNode.SelectNodes("/html/body/div[2]/div[3]/div[2]/div[2]/div/section/div[3]/div");
            foreach (var product in products) {
                var item = new ShopItem(product);
                if(item.name != "unknown")
                    shopItems.Add(item);
            }

            foreach (var item in shopItems)
                Console.WriteLine(" * " + item.name);
        }
    }

    internal class ShopItem {
        public string name = "unknown";

        public ShopItem(HtmlNode node) {
            var currentNode = node.SelectSingleNode("div[1]");
            if (currentNode == null)
                return;
            currentNode = currentNode.SelectSingleNode("div[2]");
            if (currentNode == null)
                return;
            currentNode = currentNode.SelectSingleNode("div/div/div/strong/a");
            if (currentNode == null)
                return;

            if (currentNode != null)
                name = currentNode.InnerText;
                
        }
    }
}