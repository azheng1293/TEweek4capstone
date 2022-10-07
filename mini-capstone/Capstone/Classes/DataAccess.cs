using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    class DataAccess
    {
        private string filename = @"C:\Store\inventory.csv";

        public Candy[] GetCandy()
        {
            List<Candy> candies = new List<Candy>();

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split('|');

                    Candy candy = new Candy();
                    candy.Type = split[0];
                    candy.ID = split[1];
                    candy.Name = split[2];
                    candy.Price = decimal.Parse(split[3]);
                    candy.Wrapper = candy.IfWrapper(split[4]);
                    
                    candies.Add(candy);
                }
            }
            return candies.ToArray();
        }

        //public bool SetCandyAmount(Candy[] updatedCandyAmount)
        //{
        //    bool result = false;

        //    using (StreamWriter sw = new StreamWriter(filename, false))
        //    {
        //        foreach (Candy item in updatedCandyAmount)
        //        {
        //            string line = $"{item.Type}|{item.ID}|{item.Name}|{item.Price}|{item.Wrapper}";
        //            sw.WriteLine(line);
        //        }
        //    }
        //    result = true;

        //    return result;
        //}


    }
}
