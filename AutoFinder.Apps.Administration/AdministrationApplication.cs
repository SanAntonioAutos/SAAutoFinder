using AutoFinder.DataMining.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFinder.Apps.Administration {
    public class AdministrationApplication {
#region Application Entry
        public static void Main(string[] args) {
            while (true) {
                bool shouldExit = false;
                string selectedOption = DisplayMainMenu();

                IApplicationMenu selectedMenu = null;

                switch (selectedOption) {
                    case "1": { selectedMenu = new MinableDealersManager(); } break;
                    case "2": { shouldExit = true; } break;
                    default: { } break;
                }

                if (shouldExit) {
                    break;
                }
                else if (selectedMenu != null) {
                    selectedMenu.DisplayMenu();
                }
            }
        }
#endregion

#region Application Helper Methods
        private static string DisplayMainMenu() {
            Console.Clear();

            Console.WriteLine("**************************************************");
            Console.WriteLine("* AutoFinder Administration Application          *");
            Console.WriteLine("**************************************************");
            Console.WriteLine();
            Console.WriteLine("1. Manage Minable Dealers");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
            Console.Write(">> ");

            return Console.ReadLine();
        }
#endregion
    }
}