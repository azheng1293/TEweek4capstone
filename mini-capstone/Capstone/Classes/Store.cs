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
        List<Candy> candyList = new List<Candy>();

        public decimal CustomerBalance { get; set; } = 0;

        public Store()
        {
            List<Candy> candyList = new List<Candy>();
            Candy[] candyresult = inventory.GetCandy();
            for (int i = 0; i < candyresult.Length; i++)
            {
                candyList.Add(candyresult[i]);
            }
        }
        public decimal TakeMoney(decimal addMoney)
        {
            CustomerBalance += addMoney;

            return CustomerBalance;
        }
        public string Purchase(string selection)
        {//todo
           
            
            string result = "";
            for (int i = 0; i < candyList.Count; i++)
            {
                if (candyList[i].ID == selection)
                {
                    result = selection;
                }
            }
            return result;
        }

        public int PurchaseAmount(int amountInput, string selection)
        {    
            
            for (int i = 0; i < candyList.Count; i++)
            {
                if (candyList[i].Qty >= amountInput && candyList[i].ID == selection)
                {
                    bool result = HasEnoughMoney(candyList[i].Price * amountInput);
                    if (result)
                    {
                        Candy newCartCandy = new Candy();
                        newCartCandy = candyList[i];
                        newCartCandy.Qty = amountInput;
                        AddToCart(newCartCandy);
                        candyList[i].Qty -= amountInput;
                        return 1;
                    }
                    else
                    {
                        return 3;
                    }
                    
                }
                else if(candyList[i].Qty < amountInput && candyList[i].ID == selection)
                {
                    return 2;
                }
            }
            return 3;
            
        }

        public bool HasEnoughMoney(decimal costOfCandy)
        {
            if (CustomerBalance >= costOfCandy)
            {
                CustomerBalance -= costOfCandy;
                return true;
            }
            return false;

        }

        List<Candy> cart = new List<Candy>();
        public void AddToCart(Candy itemCandy)
        {
            cart.Add(itemCandy);
        }
    }
}
