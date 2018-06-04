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
    }
}
