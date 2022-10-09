using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq; 

namespace Capstone.Classes
{ 
    class DataAccess
    {
        private string filename = @"C:\Store\inventory.csv";

        public Candy[] GetCandy()
        {
            List<Candy> candies = new List<Candy>();
            List<Candy> sortingCandy = new List<Candy>();
            Candy wrapper = new Candy();
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split('|');

                    Candy candy = new Candy(split[1], split[0], split[2], decimal.Parse(split[3]),wrapper.IfWrapper(split[4])) ; 
                    
                    candies.Add(candy);
                }
            }
            sortingCandy = candies.OrderBy(x => x.ID).ToList(); //sorted in alphabetical order
            return sortingCandy.ToArray();
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
