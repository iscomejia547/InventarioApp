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
    public partial class Main : Form
    {
        private ProductDB database;
        
        public Main()
        {
            InitializeComponent();
            database = new ProductDB();
            //database.create(new Product(0, "Leche Lala", 5, 18, 0));
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            updateTable(database.readAll());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddDlg dialog = new AddDlg();
            dialog.setDB(database);
            dialog.ShowDialog();
            updateTable(database.readAll());
        }
        private void updateTable(List<Product> p)
        {
            Gride.Rows.Clear();
            foreach (var item in p)
            {
                Gride.Rows.Add(item.toArray());
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            /*BuyDlg dialog = new BuyDlg();
            dialog.setProducts(products);
            dialog.isBuy = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Se ha agregado la compra correctamente");
            }
            updateTable(products);*/
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            updateTable(database.readAll());
        }
    }
}
