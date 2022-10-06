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
        public bool Wrapper { get; set; }
        public int Qty { get; } = 100;
        public decimal Price { get; set; }

        public Candy (string id, string type, string name, decimal price, bool wrapper)
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

        public bool IfWrapper(string haveWrapper)
        {
      
                if (haveWrapper == "T")
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public override string ToString()
        {
            return $"{ID} - {Name} - {Wrapper} - {Qty} - {Price.ToString("C")}";
        }

    }
}
