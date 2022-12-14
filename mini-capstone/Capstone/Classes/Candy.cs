using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy
    {
        public string ID { get; private set; }
        public string Type { get; set; }
        public string Name { get; private set; }
        public string Wrapper { get; private set; }
        public string Qty { get; set; } = "100";
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
        public string RegisterString()
        {
            return $"{Qty.PadLeft(0)}  {Name.PadRight(18)} {Type.PadRight(15)} {Price.ToString("C").PadLeft(8)}  {(Price*int.Parse(Qty)).ToString("C").PadRight(6)}";
        }

    }
}
