using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PObject;

namespace UI
{
    public partial class Main : Form
    {
        private int id;
        private List<Product> products; 
        public Main()
        {
            InitializeComponent();
            id = 0;
            products = new List<Product>();
            products.Add(new Product(0, "Leche Lala", 5, 18, Product.TYPE.Food));
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            foreach (Product item in products)
            {
                Gride.Rows.Add(item.toArray());
               
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddDlg dialog = new AddDlg();
            dialog.setProducts(products);
            dialog.setId(++id);
            dialog.Visible = true;
        }
    }
}
