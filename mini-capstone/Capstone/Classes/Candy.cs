using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Wrapper { get; set; }
        public int Qty { get; } = 100;
        public decimal Price { get; set; }

        public Candy (string id, string type, string name, decimal price, string wrapper)
        {
            ID = id;
            Type = type;
            Name = name;
            Price = price;
            Wrapper = wrapper;
            
        }
        public Candy()
        {

        }

        public string IfWrapper(string haveWrapper)
        {
      
                if (haveWrapper == "T")
                {
                    return "Y";
                }
                else
                {
                    return "N";
                }
        }

        public override string ToString()
        {
            return $"{ID.PadLeft(5)}  {Name.PadRight(20)} {Wrapper.PadRight(10)} {Qty.ToString().PadRight(10)}  {Price.ToString("C").PadRight(50)}";
        }

    }
}
