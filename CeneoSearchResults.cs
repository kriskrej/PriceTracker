using System;
using System.Collections.Generic;
using System.Web;

namespace lab_PriceTracker {
    internal class CeneoSearchResults {
        CeneoQuery query;
        List<ShopItem> items = new List<ShopItem>(); 

        public CeneoSearchResults(CeneoQuery query) {
            this.query = query;
            var firstPage = DownloadPageNr(0);
            items.AddRange(firstPage.shopItems);
            var pagesCount = GetPagesCount(firstPage);

            for (int i = 1; i < pagesCount; ++i) {
                var page = DownloadPageNr(i);
                items.AddRange(page.shopItems);
            }
        }

        public string ToTsv() {
            var tsv = "";

            foreach (var item in items) {
                var name = item.name.Replace("\t", " ");
                var value = item.price.Replace("\t", " ");
                tsv += $"{name}\t{value}\n";
            }


            return tsv;
        }

        private int GetPagesCount(CeneoPage firstPage) {
            var node = firstPage.html.DocumentNode.SelectSingleNode("//div[@class=\"pagination-top\"]");
            if (node != null) {
                var text = node.InnerText;
                if (!text.Contains("z "))
                    return 1;
                
                text = text.Substring(text.IndexOf("z ")+2);
                text = text.Substring(0, text.IndexOf("\n") - 1);
                int amount = 0;
                if (int.TryParse(text, out amount))
                    return amount;
            }
            return 1;
        }

        private CeneoPage DownloadPageNr(int pageNr) {
            return new CeneoPage(query.GetPageUrl(pageNr));

        }
    }
}