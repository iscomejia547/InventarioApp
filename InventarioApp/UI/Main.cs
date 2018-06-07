﻿using InventarioApp.POBject;
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
        private int id;
        private Dictionary<int, Product> products; 
        public Main()
        {
            InitializeComponent();
            id = 0;
            products = new Dictionary<int, Product>();
            products.Add(0, new Product(0, "Leche Lala", 5, 18, Product.TYPE.Food));
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            updateTable(products);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddDlg dialog = new AddDlg();
            dialog.setProducts(products);
            dialog.setId(++id);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Se ha agregado el producto correctamente");
            }
            updateTable(products);
        }
        private void updateTable(Dictionary<int, Product> p)
        {
            Gride.Rows.Clear();
            foreach (KeyValuePair<int, Product> x in p)
            {
                Gride.Rows.Add(x.Value.toArray());
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BuyDlg dialog = new BuyDlg();
            dialog.setProducts(products);
            dialog.isBuy = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Se ha agregado la compra correctamente");
            }
            updateTable(products);
        }
    }
}