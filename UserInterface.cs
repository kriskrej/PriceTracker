using System;

namespace lab_PriceTracker {
    public class UserInterface {
        

        public string AskUserForString(string question) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(question);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ");
            var line = Console.ReadLine();
            Console.WriteLine();
            return line;
        }

        public int AskUserForInt(string question) {
            var txt = AskUserForString(question);
            if (int.TryParse(txt, out int amount))
                return amount;
            else
                return -1;

        }
    }
}