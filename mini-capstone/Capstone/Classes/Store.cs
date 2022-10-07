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
        public List<Candy> Candy
        { get
            {
                return candyList;
            } 
        }
        public List<Candy> Cart
        {
            get
            {
                return cart;
            }
        }
        public decimal CustomerBalance { get; set; } = 0;

        public Store()
        {
           
            Candy[] candyresult = inventory.GetCandy();
            for (int i = 0; i < candyresult.Length; i++)
            {
                candyList.Add(candyresult[i]);
            }
        }
        public void changeType()
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Type == "CH")
                {
                    cart[i].Type = "Choclate Confectionery";
                }
                else if (cart[i].Type == "SR")
                {
                    cart[i].Type = "Sour Flavored Candies";
                }
                else if (cart[i].Type == "HC")
                {
                    cart[i].Type = "Hard Tack Confectionary";
                }
                else if(cart[i].Type=="LI")
                {
                    cart[i].Type = "Licorice and Jellies";
                }
            }

        }
        public decimal TakeMoney(decimal addMoney)
        {
            DataAccess additinalFunds = new DataAccess();
            
            CustomerBalance += addMoney;
            additinalFunds.LogMoneyRecieved(addMoney, CustomerBalance);

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
                if (int.Parse(candyList[i].Qty) >= amountInput && candyList[i].ID == selection)
                {
                    bool result = HasEnoughMoney(candyList[i].Price * amountInput);
                    if (result)
                    {
                        Candy newCartCandy = new Candy();
                        newCartCandy.Type = candyList[i].Type;
                        newCartCandy.ID = candyList[i].ID;
                        newCartCandy.Name = candyList[i].Name;
                        newCartCandy.Wrapper = candyList[i].Wrapper;
                        newCartCandy.Price = candyList[i].Price;
                        newCartCandy.Qty = amountInput.ToString();
                        AddToCart(newCartCandy);
                       int subQty =(int.Parse(candyList[i].Qty) - amountInput);
                        if (int.Parse(candyList[i].Qty) == 0 || subQty<0)
                        {
                            candyList[i].Qty = "SOLD OUT";
                            return 2;
                        }
                        else if (subQty == 0)
                        {
                            candyList[i].Qty = "SOLD OUT";
                            return 1;
                        }
                        else
                        {
                            candyList[i].Qty = subQty.ToString();
                        }
                        return 1;
                    }
                    else

                    {
                        return 3;
                    }
                    
                }
          
                else if((int.Parse(candyList[i].Qty) < amountInput || candyList[i].Qty=="SOLD OUT" )&& candyList[i].ID == selection)
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
            DataAccess cartAddition = new DataAccess();
            cartAddition.LogSelection(itemCandy);
            cart.Add(itemCandy);
        }
        public string ChangeDefiner(decimal change)
        {   
            int twenties = 0;
            int tens = 0;
            int fives = 0;
            int ones = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
           
            twenties = (int)(change / 20);
            change = change - (twenties * 20);
            tens = (int)(change / 10);
            change = change - (tens * 10);
            fives = (int)(change / 5);
            change = change - (fives * 5);
            ones = (int)(change / 1);
            change = change - (ones * 1);
            quarters = (int)(change / .25M);
            change = change - (quarters * .25M);
            dimes = (int)(change / .10M);
            change = change - (dimes * .10M);
            nickels = (int)(change / .05M);
            change = change - (nickels * .05M);
            string totalTwenties = $"({twenties}) Twenties,";
            string  totalTens = $" ({tens}) Tens,";
            string totalFives = $" ({fives}) Fives,";
            string totalOnes = $" ({ones}) Ones,";
            string totalQuarters = $" ({quarters}) Quarters,";
            string totalDimes = $" ({dimes}) Dimes,";
            string totalNickels = $" ({nickels}) Nickels";
            if (twenties == 0)
            {
                totalTwenties = "";
            }
            if (tens == 0)
            {
                totalTens = "";
            }
            if (fives == 0)
            {
                totalFives = "";
            }
            if (ones == 0)
            {
                totalOnes = "";
            }
            if (quarters == 0)
            {
                totalQuarters = "";
            }
            if (dimes== 0)
            {
                totalDimes = "";
            }
            if (nickels == 0)
            {
                totalNickels = "";
            }

            return totalTwenties+totalTens+totalFives+totalOnes+totalQuarters+totalDimes+totalNickels;
        }
      
    }
}
