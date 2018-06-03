using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PObject
{
    public class Product
    {
        private int id { get; set; }
        private string name { get; set; }
        private int qty { get; set; }
        private int price { get; set; }
        private TYPE type { get; set; }

        public enum TYPE
        {
            Food, Cleaning, Personal_Hygiene, Drinks
        }
        public Product(int id, string name, int qty, int price, TYPE type)
        {
            this.id = id;
            this.name = name;
            this.qty = qty;
            this.price = price;
            this.type = type;
        }
        public String[] toArray()
        {
            String [] array = { this.id.ToString(),
            this.name.ToString(),
            this.qty.ToString(),
            this.price.ToString(),
            this.type.ToString()
            };
            return array;
        }
    }
}
