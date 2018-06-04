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
    public partial class AddDlg : Form
    {
        private List<Product> products { get; set; }
        private int id { get; set; }
        public void setProducts(List<Product> p)
        {
            products = p;
        }
        public void setId(int idn)
        {
            id = idn;
        }
        public AddDlg()
        {
            InitializeComponent();
        }

        private void AddDlg_Shown(object sender, EventArgs e)
        {
            EnumCMB.DataSource = Enum.GetValues(typeof(Product.TYPE));
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            //validation
            foreach(Control x in LabelPanel.Controls)
            {
                TextBox tmp = x as TextBox;
                if(tmp != null)
                {
                    if (tmp.Text=="")
                    {
                        return;
                    }
                }
            }
            Product nuevo = new Product(id, NameTxt.Text, Int16.Parse(qtyTxt.Text), float.Parse(priceTxt.Text),
                (Product.TYPE)Enum.Parse(typeof(Product.TYPE), EnumCMB.SelectedItem.ToString()));
            products.Add(nuevo);
            this.Close(); 
        }
    }
}
