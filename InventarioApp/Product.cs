using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PObject
{
    public class Product : IComparable<Product>
    {
        public int id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public float price { get; set; }
        public TYPE type { get; set; }

        public enum TYPE
        {
            Food, Cleaning, Personal_Hygiene, Drinks
        }
        public Product()
        {

        }
        public Product(int id, string name, int qty, float price, TYPE type)
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
        public string idpname()
        {
            return "ID: "+this.id.ToString() + "| Prod: " + this.name;
        }

        public int CompareTo(Product other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.id.CompareTo(other.id);
        }
    }
}
