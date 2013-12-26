using AutoFinder.DataMining.Application;
using AutoFinder.DataMining.Domain;
using System;
using System.Collections.Generic;

internal class MinableDealersManager : IApplicationMenu {
#region Private Members
    private MiningServices _services;
#endregion

#region Public Methods
#region Constructor(s)
    public MinableDealersManager() {
        this._services = new MiningServices();
    }
#endregion

#region Interface Method(s)
    public void DisplayMenu() {
        while (true) {
            Console.Clear();

            Console.WriteLine("**************************************************");
            Console.WriteLine("* Manage Minable Dealers                         *");
            Console.WriteLine("**************************************************");
            Console.WriteLine();
            Console.WriteLine("1. View All Minable Dealers");
            Console.WriteLine("2. Add New Minable Dealer");
            Console.WriteLine("3. Update Minable Dealer");
            Console.WriteLine("4. Remove Minable Dealer");
            Console.WriteLine();
            Console.WriteLine("5. Return to Main Menu");
            Console.WriteLine();
            Console.Write(">> ");

            bool shouldExit = false;
            string selectedOption = Console.ReadLine();

            switch (selectedOption) {
                case "1": { ShowAllMinableDealersScreen(); } break;
                case "2": { ShowAddNewDealerScreen(); } break;
                case "3": { ShowUpdateDealerScreen(); } break;
                case "4": { ShowRemoveDealerScreen(); } break;
                case "5": { shouldExit = true; } break;
                default: { } break;
            }

            if (shouldExit) {
                break;
            }
        }
    }
#endregion
#endregion

#region Private Methods
    private void ShowAllMinableDealersScreen() {
        Console.Clear();
        Console.Write("Retrieving all minable dealers... ");

        List<MinableDealer> dealers = this._services.GetAllMinableDealers();

        Console.Clear();

        if (dealers.Count > 0) {
            Console.WriteLine("--------------------------------------------------");
        }

        foreach (MinableDealer dealer in dealers) {
            Console.WriteLine("  Id: " + dealer.DealerId);
            Console.WriteLine("Name: " + dealer.DealerName);
            Console.WriteLine(" Url: " + dealer.DealerUrl);
            Console.WriteLine("MPTN: " + dealer.MiningPageTypeName);
            Console.WriteLine("--------------------------------------------------");

            dealer.MiningPage.Mine();
        }

        Console.Write("Press any key to continue... ");
        Console.ReadKey(true);
    }

    private void ShowAddNewDealerScreen() {
        bool didAddNewDealer = false;
        while (!didAddNewDealer) {
            Console.Clear();

            Console.WriteLine("**************************************************");
            Console.WriteLine("* Add New Minable Dealer                         *");
            Console.WriteLine("**************************************************");
            Console.WriteLine();

            Console.Write("Dealer Name: ");
            string dealerName = Console.ReadLine();

            if (dealerName.ToLower() == "q") { break; }

            Console.Write("Dealer Url: ");
            string dealerUrl = Console.ReadLine();

            if (dealerUrl.ToLower() == "q") { break; }

            Console.Write("Dealer Mining Page Type: ");
            string dealerMiningPageType = Console.ReadLine();

            if (dealerMiningPageType.ToLower() == "q") { break; }

            Console.WriteLine();
            Console.Write("Adding new minable dealer... ");

            this._services.AddMinableDealer(dealerName, dealerUrl, dealerMiningPageType);

            didAddNewDealer = true;
        }
    }

    private void ShowUpdateDealerScreen() {
        bool didUpdateDealer = false;
        while (!didUpdateDealer) {
            Console.Clear();

            Console.WriteLine("**************************************************");
            Console.WriteLine("* Update Minable Dealer                          *");
            Console.WriteLine("**************************************************");
            Console.WriteLine();

            Console.Write("Dealer Id: ");
            string dealerId = Console.ReadLine();

            if (dealerId.ToLower() == "q") { break; }

            Console.WriteLine();
            Console.Write("Retrieving minable dealer... ");

            MinableDealer dealerToUpdate = this._services.GetMinableDealer(dealerId);
            if (dealerToUpdate != null) {
                Console.CursorLeft = 0;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("  Id: " + dealerToUpdate.DealerId);
                Console.WriteLine("Name: " + dealerToUpdate.DealerName);
                Console.WriteLine(" Url: " + dealerToUpdate.DealerUrl);
                Console.WriteLine("MPTN: " + dealerToUpdate.MiningPageTypeName);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine();

                Console.Write("New Dealer Name: ");
                string newDealerName = Console.ReadLine();

                if (newDealerName.ToLower() == "q") { break; }

                Console.Write("New Dealer Url: ");
                string newDealerUrl = Console.ReadLine();

                if (newDealerUrl.ToLower() == "q") { break; }

                Console.Write("New Dealer Mining Page Type: ");
                string newDealerMiningPageType = Console.ReadLine();

                if (newDealerMiningPageType.ToLower() == "q") { break; }

                Console.WriteLine();
                Console.Write("Updating minable dealer... ");
                
                this._services.UpdateMinableDealer(
                    new MinableDealer(dealerToUpdate.DealerId, newDealerName, newDealerUrl, newDealerMiningPageType)
                );

                didUpdateDealer = true;
            }
            else {
                string shouldTryAgainOption = string.Empty;
                do {
                    Console.CursorLeft = 0;
                    Console.Write("Could not locate minable dealer, try again (Y/N)? ");
                    shouldTryAgainOption = Console.ReadLine().ToLower();
                } while (shouldTryAgainOption != "y" && shouldTryAgainOption != "n");

                if (shouldTryAgainOption == "n") {
                    break;
                }
            }
        }
    }

    private void ShowRemoveDealerScreen() {
        bool didRemoveDealer = false;
        while (!didRemoveDealer) {
            Console.Clear();

            Console.WriteLine("**************************************************");
            Console.WriteLine("* Remove Minable Dealer                          *");
            Console.WriteLine("**************************************************");
            Console.WriteLine();

            Console.Write("Dealer Id: ");
            string dealerId = Console.ReadLine();

            if (dealerId.ToLower() == "q") { break; }

            Console.WriteLine();
            Console.Write("Removing minable dealer... ");

            MinableDealer dealerToRemove = this._services.GetMinableDealer(dealerId);
            if (dealerToRemove != null) {
                this._services.RemoveMinableDealer(dealerToRemove);
                didRemoveDealer = true;
            }
            else {
                string shouldTryAgainOption = string.Empty;
                do {
                    Console.CursorLeft = 0;
                    Console.Write("Could not locate minable dealer, try again (Y/N)? ");
                    shouldTryAgainOption = Console.ReadLine().ToLower();
                } while (shouldTryAgainOption != "y" && shouldTryAgainOption != "n");

                if (shouldTryAgainOption == "n") {
                    break;
                }
            }
        }
    }
#endregion
}