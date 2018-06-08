using InventarioApp.POBject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioApp.Data
{
    interface ProductDAO : DAO<Product>
    {
        Product QueryByID(int id);
        Product QueryByName(string name);
        List<Product> QueryByCAT(Product.TYPE type);
    }
}
