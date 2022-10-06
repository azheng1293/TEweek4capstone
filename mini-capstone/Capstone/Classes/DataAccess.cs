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


            //for (int i =0;i<candies.Count;i++)
            //{
            //    if (candies[i].ID[0] == 'C')
            //    {
            //        if(candies[i].ID[1] == '1')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[0];
            //            candies[0] = interum;
            //        }
            //        else if (candies[i].ID[1] == '2')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[1];
            //            candies[0] = interum;
            //        }
            //        else if (candies[i].ID[1] == '3')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[2];
            //            candies[0] = interum;
            //        }
            //        else 
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[3];
            //            candies[0] = interum;
            //        }
            //    }
            //    else if (candies[i].ID[0] == 'H')
            //    {
            //        if (candies[i].ID[1] == '1')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[0];
            //            candies[0] = interum;
            //        }
            //        else if (candies[i].ID[1] == '2')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[1];
            //            candies[0] = interum;
            //        }
            //        else if (candies[i].ID[1] == '3')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[2];
            //            candies[0] = interum;
            //        }
            //        else
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[3];
            //            candies[0] = interum;
            //        }
            //    }
            //    else if (candies[i].ID[0] == 'L')
            //    {
            //        if (candies[i].ID[1] == '1')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[0];
            //            candies[0] = interum;
            //        }
            //        else if (candies[i].ID[1] == '2')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[1];
            //            candies[0] = interum;
            //        }
            //        else if (candies[i].ID[1] == '3')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[2];
            //            candies[0] = interum;
            //        }
            //        else
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[3];
            //            candies[0] = interum;
            //        }
            //    }
            //    else if (candies[i].ID[0] == 'S')
            //    {

            //        if (candies[i].ID[1] == '1')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[0];
            //            candies[0] = interum;
            //        }
            //        else if (candies[i].ID[1] == '2')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[1];
            //            candies[0] = interum;
            //        }
            //        else if (candies[i].ID[1] == '3')
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[2];
            //            candies[0] = interum;
            //        }
            //        else
            //        {
            //            Candy interum = new Candy();
            //            interum = candies[i];
            //            candies[i] = candies[3];
            //            candies[0] = interum;
            //        }
            //    }

            //}

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
