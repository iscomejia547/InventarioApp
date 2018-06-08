
using InventarioApp.DataBase;
using InventarioApp.POBject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioApp.UI
{
    public partial class BuyDlg : Form
    {
        public bool isBuy { get; set; }
        private ProductDB db;
        private List<Product> products;
        public void setDB(ProductDB t)
        {
            db= t;
        }
        public BuyDlg()
        {
            InitializeComponent();
        }

        private void BuyDlg_Shown(object sender, EventArgs e)
        {
            List<String> s = new List<String>();
            s.Add("Seleccione un producto");
            products = db.readAll();
            foreach (var x in products)
            {
                s.Add(x.name);
            }
            ProductCMB.DataSource = s;
            if (!isBuy)
            {
                pricetxt.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (ProductCMB.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione un producto a modificar!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Control item in FieldPanel.Controls)
            {
                TextBox txt = item as TextBox;
                if (txt != null)
                {
                    if (txt.Text == "")
                    {
                        MessageBox.Show("Rellene todos los campos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        return;
                    }

                }
                else
                {
                    break;
                }
            }
            Product p = db.QueryByName(ProductCMB.SelectedItem.ToString());
            if (p != null)
            {
                if (isBuy)
                {
                    p.qty += Int32.Parse(qtytxt.Text);
                    p.price = (p.price + float.Parse(pricetxt.Text)) / 2;
                }
                else
                {
                    p.qty -= Int32.Parse(qtytxt.Text);
                }
            }

            if (db.update(p))
            {
                MessageBox.Show("Se actualizó correctamente");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Ha habido un error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
