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
        public decimal CustomerBalance { get; set; } = 0;

        public decimal TakeMoney(decimal addMoney)
        {
            CustomerBalance += addMoney;


            return CustomerBalance;
        }
        public void Purchase(string selection)
        {//todo
            DataAccess inventory = new DataAccess();
            Candy[] result = inventory.GetCandy();
            
            for(int i = 0; i < result.Length; i++)
            {
                if (result[i].ID == selection)
                {
                    
                }
            }


        } 
    }
}
