using System;
using System.Web;

namespace lab_PriceTracker {
    class Program {
        static void Main() {
            Console.WriteLine("Jakiego towaru mam szukać?");
            var query = Console.ReadLine();

            var ceneoSearchResults = new CeneoSearchResults(query);
        }
    }
}
