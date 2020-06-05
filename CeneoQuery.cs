using System;
using System.Web;

namespace lab_PriceTracker {
    public class CeneoQuery {
        string searchWords;

        public int minimalPrice = -1;
        public int maximalPrice = -1;

        public CeneoQuery(string searchWords) {
            this.searchWords = searchWords;
        }


        internal string GetPageUrl(int pageNr) {
            var q = HttpUtility.UrlEncode(searchWords);
            var url = "https://" + $"www.ceneo.pl/;szukaj-{q};0020-30-0-0-{pageNr};0112-1";
            if (minimalPrice >= 0)
                url += ";m" + minimalPrice;
            if (maximalPrice >= 0)
                url += ";n" + maximalPrice;
            return url + ".htm";
        }
    }
}