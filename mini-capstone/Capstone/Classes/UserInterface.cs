using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class UserInterface
    {
        
        public Store store = new Store();


        /// <summary>
        /// Provides all communication with human user.
        /// 
        /// All Console.Readline() and Console.WriteLine() statements belong in this class.
        /// 
        /// NO Console.Readline() and Console.WriteLine() statements should be in any other class
        /// 
        /// </summary>
        public void Run()
        {

            bool done = false;
            
            while (!done)
            {
                DisplayMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ListInventory();
                        break;
                    case "2":
                        MakeSalesMenu();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid choice");
                        break;
                }

            }
        }

        private void ListInventory()
        {
           
            Console.WriteLine("Id".PadLeft(5) + "Name".PadLeft(7) + "Wrapper".PadLeft(19) + "Qty".PadLeft(11) + "Price".PadLeft(14));

            for (int i =0;i<store.Candy.Count;i++)
            {
                Console.WriteLine(store.Candy[i].ToString());
            }
        }
       
     
        public void CandySelection()
        {
            ListInventory();
            Console.WriteLine("What would you like? (Please type candy ID) ");
            string candySelected = Console.ReadLine();
            int canTheyBuy = 0;

            if (store.Purchase(candySelected)!="")
            {

                canTheyBuy = store.PurchaseAmount(HowMany(), candySelected);
                switch (canTheyBuy)
                {
                    case 1:
                        MakeSalesMenu();
                        break;
                    case 2:
                        Console.WriteLine("Insufficient Stock");
                        break;
                    case 3:
                        Console.WriteLine("Insufficient Funds");
                        break;
                }
            }
            else
            {
                Console.WriteLine("The product you have selected does NOT exist, please select again ");
                MakeSalesMenu();
            }
        }
        public int HowMany()
        {
            Console.Write("How many would you like? ");
            int quantity = 0;
            try
            {
                quantity = int.Parse(Console.ReadLine());
                
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return quantity;
        }
        
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("(1) Show Inventory");
            Console.WriteLine("(2) Make Sale");
            Console.WriteLine("(3) Quit");
        }
        private void SalesDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("(1) Take Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Sale");
            Console.WriteLine("Current Customer Balance:"+ store.CustomerBalance.ToString("C"));
        }
        private void MakeSalesMenu()
        {
            bool done = false;

            while (!done)
            {
                SalesDisplay();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        TakeMoney();
                        break;
                    case "2":
                        CandySelection();
                        break;
                    case "3":
                        CompleteSale();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid choice");
                        break;
                }
            }
        }
        private void TakeMoney()
        {
            Console.WriteLine();
            Console.Write("Amount to be added up to $100.00:");
            bool loop = true;
            decimal addedAmount = 0;
            while (loop)
            {
                try
                {
                    addedAmount = decimal.Parse(Console.ReadLine());
                    
                }
                catch (FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter in number format:");

                }

                if (addedAmount <= 100 && addedAmount >=0 && (store.CustomerBalance + addedAmount <= 1000))
                {

                    store.TakeMoney(addedAmount);
                    MakeSalesMenu();
                }
                else if((store.CustomerBalance + addedAmount > 1000))
                {
                    Console.WriteLine();
                    Console.WriteLine("Balance can't exceed $1,000.00:");
                    Console.WriteLine();
                }
                else if(addedAmount < 0)
                {
                    Console.WriteLine("Please enter an amount greater than $0.00");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Please enter an amount up to $100.00:");
                    Console.WriteLine();
                }
            }
    
        }
        public void CompleteSale()
        { decimal total = 0;
            store.changeType();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < store.Cart.Count; i++)
            {
                Console.WriteLine(store.Cart[i].RegisterString());
                total = (int.Parse(store.Cart[i].Qty) * store.Cart[i].Price);
            }
            DataAccess printChange = new DataAccess();
            printChange.LogChangeGiven(store.CustomerBalance);
            Console.WriteLine("Total: " +total.ToString("C"));
            Console.WriteLine();
            Console.WriteLine("Change: "+store.CustomerBalance.ToString("C"));
            Console.WriteLine(store.ChangeDefiner(store.CustomerBalance));
            store.CustomerBalance = 0;
            Run();
        }
    }

}
