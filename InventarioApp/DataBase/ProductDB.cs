using InventarioApp.Data;
using InventarioApp.POBject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioApp.DataBase
{
    class ProductDB : ProductDAO
    {
        private const int STREAM_SIZE = 59;
        private List<Product> products;
        private Product p;
        private FileStream fs;
        private BinaryReader putin;
        private BinaryWriter putout;

        public ProductDB()
        {
            fs = GeneralFiler.getFS();
            putin = new BinaryReader(fs);
            putout = new BinaryWriter(fs);
        }
        public bool create(Product t)
        {
            putin.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = putin.ReadInt32();
            int k = putin.ReadInt32();
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
            throw new NotImplementedException();
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
            p.price = putin.ReadInt32();
            p.setType(putin.ReadInt32());
            return p;
        }

        public List<Product> readAll()
        {
            products = new List<Product>();

            putin.BaseStream.Seek(0, SeekOrigin.Begin);
            int n = putin.ReadInt32();
            int k = putin.ReadInt32();

            for (int i = 1; i <= n; i++)
            {
                p = QueryByID(i);
                if (p != null)
                {
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
            throw new NotImplementedException();
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

        List<Product> ProductDAO.QueryByCAT(Product.TYPE type)
        {
            throw new NotImplementedException();
        }

        List<Product> ProductDAO.QueryByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
