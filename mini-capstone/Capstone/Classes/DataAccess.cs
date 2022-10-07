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

        private string outputFile = @"C:\Store\log.txt";
        public void LogMoneyRecieved(decimal addMoney, decimal customerBalance)
        {
            
            using (StreamWriter sw = new StreamWriter(outputFile, true))
            {
                {
                    string line = $"{DateTime.Now} MONEY RECIEVED: {addMoney.ToString("C")}  {customerBalance.ToString("C")} ";
                    sw.WriteLine(line);
                }
            }
        }
        public void LogChangeGiven(decimal giveMoneyBack)
        {
            
            using (StreamWriter sw = new StreamWriter(outputFile, true))
            {
                {
                    string line = $"{DateTime.Now} CHANGE GIVEN {giveMoneyBack.ToString("C")}  $0.00 ";
                    sw.WriteLine(line);
                }
            }
        }
        public void LogSelection(Candy selection)
        { 
            using (StreamWriter sw = new StreamWriter(outputFile, true))
            {
                {
                    string line = $"{DateTime.Now} {selection.Qty} {selection.Name} {selection.ID} {selection.Price.ToString("C")} {(int.Parse(selection.Qty)*selection.Price).ToString("C")}";
                    sw.WriteLine(line);
                }
            }
        }



    }
}
