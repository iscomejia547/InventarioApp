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
            putout.Write(t.type);

        }

        public bool delete(Product t)
        {
            throw new NotImplementedException();
        }

        public Product QueryByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Product> readAll()
        {
            throw new NotImplementedException();
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
