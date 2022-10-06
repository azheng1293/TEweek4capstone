using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class UserInterface
    {
        private Store store = new Store();


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
                        SalesDisplay();
                        break;
                    case "3":
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
            DataAccess inventory = new DataAccess();
            Candy[] result = inventory.GetCandy();
            Console.WriteLine("Id".PadLeft(5) + "Name".PadLeft(7) + "Wrapper".PadLeft(19) + "Qty".PadLeft(11) + "Price".PadLeft(14));

            foreach (Candy item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("(1) Show Inventory");
            Console.WriteLine("(2) Make Sale");
            Console.WriteLine("(3) Quit");
        }
        private void MakeSalesMenu()
        {
            Console.WriteLine();
            Console.WriteLine("(1) Take Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Sale");
            Console.WriteLine("Current Customer Balance:"+ store.CustomerBalance.ToString("C"));
            

        }
        private void SalesDisplay()
        {
            MakeSalesMenu();
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    TakeMoney();
                    break;
                case "2":
                    ListInventory();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Please make a valid choice");
                    break;
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

                if (addedAmount <= 100 && (store.CustomerBalance+addedAmount<=1000))
                {

                    store.TakeMoney(addedAmount);
                    SalesDisplay();
                }
                else if((store.CustomerBalance + addedAmount > 1000))
                {
                    Console.WriteLine();
                    Console.WriteLine("Balance can't exceed $1,000.00:");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Please enter an amount up to $100.00:");
                    Console.WriteLine();
                }
            }
        }
    }
}
