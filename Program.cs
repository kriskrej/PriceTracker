using System;
using System.IO;
using System.Web;

namespace lab_PriceTracker {
    class Program {
        static void Main() {
            var ui = new UserInterface();
            
            var input = ui.AskUserForString("Jakiego towaru mam szukać?");
            var query = new CeneoQuery(input);
            query.minimalPrice = ui.AskUserForInt("Za jaką cenę minimalną?");
            query.maximalPrice = ui.AskUserForInt("Za jaką cenę maksymalną?");

            var ceneoSearchResults = new CeneoSearchResults(query);
            string csv = ceneoSearchResults.ToCsv();
            var date = DateTime.Now;
            var path = $"{date.ToString("yyyy-MM-dd")} - {input}.csv";
            File.WriteAllText(path , csv);
        }
    }
}
