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
    public partial class AddDlg : Form
    {
        private ProductDB db { get; set; }
        public void setDB(ProductDB d)
        {
            db = d;
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
                        MessageBox.Show("Rellene todos los campos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            Product nuevo = new Product(0, NameTxt.Text, Int16.Parse(qtyTxt.Text), float.Parse(priceTxt.Text),
                EnumCMB.SelectedIndex);
            if (db.create(nuevo))
            {
                MessageBox.Show("Se ha agregado correctamente");
            }
            else
            {
                MessageBox.Show("Ha habido un error\nNo deben haber nombres repetidos", "",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close(); 
        }
    }
}
