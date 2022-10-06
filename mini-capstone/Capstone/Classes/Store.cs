using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// Most of the "work" (the data and the methods) of dealing with inventory and money 
    /// should be created or controlled from this class
    /// </summary>
    public class Store
    {


        DataAccess inventory = new DataAccess();
        public decimal CustomerBalance { get; set; } = 0;

        public decimal TakeMoney(decimal addMoney)
        {
            CustomerBalance += addMoney;

            return CustomerBalance;
        }
        public string Purchase(string selection)
        {//todo
           
           
            Candy[] candyresult = inventory.GetCandy();
            string result = "";
            for (int i = 0; i < candyresult.Length; i++)
            {
                if (candyresult[i].ID == selection)
                {
                    result = selection;
                }
            }
            return result;
        }

        public bool PurchaseAmount(int amountInput, string selection)
        {
            
            
            Candy[] candyresult = inventory.GetCandy();
            for (int i = 0; i < candyresult.Length; i++)
            {
                if (candyresult[i].Qty >= amountInput)
                {
                    IsNotPoor(candyresult[i].Price * amountInput);
                    candyresult[i].Qty = amountInput;
                    AddToCart(candyresult[i]);
                    
                }
            }
            return false;
        }

        public void IsNotPoor(decimal costOfCandy)
        {
            UserInterface ui = new UserInterface();
            if (CustomerBalance >= costOfCandy)
            {
                CustomerBalance -= costOfCandy;
            }
            else
            {
                ui.IsPoor();
            }
        }

        List<Candy> cart = new List<Candy>();
        public void AddToCart(Candy itemCandy)
        {
            cart.Add(itemCandy);
        }
    }
}
