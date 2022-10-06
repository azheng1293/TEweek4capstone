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
    }
}
