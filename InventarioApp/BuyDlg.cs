using PObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class BuyDlg : Form
    {
        private List<Product> products;
        public void setProducts(List<Product> t)
        {
            products = t;
        }
        public BuyDlg()
        {
            InitializeComponent();
        }

        private void BuyDlg_Shown(object sender, EventArgs e)
        {
            List<String> s = new List<String>();
            s.Add("Seleccione un producto");
            foreach (var x in products)
            {
                s.Add(x.idpname());
            }
            ProductCMB.DataSource = s;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (ProductCMB.SelectedIndex == 0)
            {
                return;
            }
            foreach (Control item in FieldPanel.Controls)
            {
                TextBox txt = item as TextBox;
                if (txt != null)
                {
                    if (txt.Text == "")
                    {
                        return;
                    }
                }
                else
                {
                    break;
                }
            }
            products.Sort();
            var prod = (from it in products where it.id == (ProductCMB.SelectedIndex - 1) select it).ToArray();
            Product p = prod[0] as Product;
            if (p != null)
            {
                p.qty += Int32.Parse(qtytxt.Text);
                p.price = (p.price + float.Parse(pricetxt.Text)) / 2;
            }
            products.RemoveAt(p.id);
            products.Insert(p.id, p);
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }
    }
}
