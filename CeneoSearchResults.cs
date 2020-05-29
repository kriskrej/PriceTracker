using System;
using System.Web;

namespace lab_PriceTracker {
    internal class CeneoSearchResults {
        private string query;

        public CeneoSearchResults(string query) {
            this.query = query;
            for (int i = 0; i < 5; ++i) {
                var page = DownloadPageNr(i);
                if (page.shopItems.Count == 0)
                    return;
                //Console.ReadLine();

            }
        }

        private CeneoPage DownloadPageNr(int pageNr) {
            return new CeneoPage(GetPageUrl(pageNr));

        }

        private string GetPageUrl(int pageNr) {
            var q = HttpUtility.UrlEncode(query);
            return $"https://www.ceneo.pl/;szukaj-{q};0020-30-0-0-{pageNr}.htm";
        }
    }
}