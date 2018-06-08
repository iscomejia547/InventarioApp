using InventarioApp.Data;
using InventarioApp.POBject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioApp.DataBase
{
    public class ProductDB : ProductDAO
    {
        private const int STREAM_SIZE = 59;
        private List<Product> products;
        private Product p;
        private FileStream fs;
        private BinaryReader putin;
        private BinaryWriter putout;

        public ProductDB()
        {
            streamCreator();
        }
        private void streamCreator()
        {
            fs = GeneralFiler.getFS();
            putin = new BinaryReader(fs);
            putout = new BinaryWriter(fs);
        }
        public bool create(Product t)
        {
            if (validate(t))
            {
                return false;
            }
            putin.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = putin.ReadInt32();
            int k = putin.ReadInt32();
            t.id = k + 1;
            if(t.id <=k || t.id <= n)
            {
                throw new ArgumentException("ID: " + t.id + " ya esta ocupado");
            }
            long pos = 8 + (t.id - 1) * STREAM_SIZE;
            putout.BaseStream.Seek(pos, SeekOrigin.Begin);
            putout.Write(t.id);
            putout.Write(nVarChar(t.name, 20));
            putout.Write(t.qty);
            putout.Write(t.price);
            putout.Write(t.getType());
            putout.BaseStream.Seek(0, SeekOrigin.Begin);
            putout.Write(++n);
            putout.Write(++k);
            return true;
        }

        public bool delete(Product t)
        {
            if (t == null)
            {
                throw new ArgumentException("Objeto nulo");
            }
            products = readAll();
            putin.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = putin.ReadInt32();
            int k = putin.ReadInt32();
            if (!products.Remove(t))
            {
                throw new ArgumentException("El objeto no existe");
            }
            //resetear archivo
            close();
            GeneralFiler.resetFile();
            streamCreator();
            putout.BaseStream.Seek(0, SeekOrigin.Begin);
            putout.Write(--n);
            putout.Write(k);
            int i = 0;
            foreach(Product p in products)
            {
                long pos = 8 + (i * STREAM_SIZE);
                putout.BaseStream.Seek(pos, SeekOrigin.Begin);
                putout.Write(t.id);
                putout.Write(nVarChar(t.name, 20));
                putout.Write(t.qty);
                putout.Write(t.price);
                putout.Write(t.getType());
                i++;
            }
            return true;
        }
        private bool validate(Product t)
        {
            /*debido a que es un inventario de productos, no pueden haber dos con exactamente
            el mismo nombre*/
            var temp = QueryByName(t.name);
            if (temp == null)
            {
                return false;
            }
            return true;
        }
        public Product QueryByID(int ID)
        {
            putin.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = putin.ReadInt32();
            if(ID>n || ID <= 0)
            {
                return null;
            }
            long pos = 8 + STREAM_SIZE * (ID - 1);
            putin.BaseStream.Seek(pos, SeekOrigin.Begin);
            p = new Product();
            p.id = putin.ReadInt32();
            p.name = putin.ReadString().Trim();
            p.qty = putin.ReadInt32();
            p.price = putin.ReadSingle();
            //MessageBox.Show(p.price.ToString());
            p.setType(putin.ReadInt32());
            return p;
        }

        public List<Product> readAll()
        {
            products = new List<Product>();

            putin.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = putin.ReadInt32();
            //id= putin.ReadInt32();

            for (int i = 1; i <= n; i++)
            {
                p = QueryByID(i);
                if (p != null)
                {
                    //autoborrador
                    products.Add(p);
                }
            }
            return products;
        }
        public void close()
        {
            if (putin != null)
            {
                putin.Close();
            }
            if (putout != null)
            {
                putout.Close();
            }
            if (fs != null)
            {
                fs.Close();
            }
        }
        public bool update(Product t)
        {
            if (t == null)
            {
                return false;
            }
            int i = t.id;
            long pos = 8 + STREAM_SIZE * (i - 1);
            putout.BaseStream.Seek(pos, SeekOrigin.Begin);
            putout.Write(t.id);
            putout.Write(nVarChar( t.name, 20));
            putout.Write(t.qty);
            putout.Write(t.price);
            putout.Write(t.getType());
            putout.BaseStream.Seek(0, SeekOrigin.Begin);
            return true;
        }
        private string nVarChar(string s, int n)
        {
            StringBuilder sb = null;
            if (s == null || s=="")
            {
                sb = new StringBuilder(n);
            }
            else
            {
                sb = new StringBuilder(s);
                sb.Length = n;
            }
            return sb.ToString();
        }

        public List<Product> QueryByCAT(Product.TYPE type)
        {
            var cat = (from Product p in readAll() where p.type.Equals(type) select p).ToList();
            return cat;
        }

        public Product QueryByName(string name)
        {
            var nam = (from Product p in readAll() where p.name.Equals(name) select p).ToArray();
            if (nam.Length==0)
            {
                return null;
            }
            return nam[0];
        }
    }
}
