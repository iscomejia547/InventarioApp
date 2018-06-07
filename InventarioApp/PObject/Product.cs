using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioApp.POBject
{
    public class Product : IComparable<Product>
    {
        public int id { get; set; }//4
        public string name { get; set; }//43
        public int qty { get; set; }//4
        public float price { get; set; }//4
        public TYPE type { get; set; }//4
        //Stream size=59
        public enum TYPE
        {
            //0,1,2,3
            Food, Cleaning, Personal_Hygiene, Drinks
        }
        public Product()
        {

        }
        public Product(int id, string name, int qty, float price, int type)
        {
            this.id = id;
            this.name = name;
            this.qty = qty;
            this.price = price;
            this.setType(type);
        }

        public void setType(int type)
        {
            switch (type)
            {
                case 0: this.type = TYPE.Food;break;
                case 1: this.type = TYPE.Cleaning;break;
                case 2: this.type = TYPE.Personal_Hygiene;break;
                case 3: this.type = TYPE.Drinks;break;
                default:throw new ArgumentException("ENUM no válido");
            }
        }
        public int getType()
        {
            switch (this.type)
            {
                case TYPE.Food:return 1;
                case TYPE.Cleaning:return 2;
                case TYPE.Personal_Hygiene: return 3;
                case TYPE.Drinks: return 4;
                default:throw new ArgumentException("No hay un argumento valido");
            }
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
