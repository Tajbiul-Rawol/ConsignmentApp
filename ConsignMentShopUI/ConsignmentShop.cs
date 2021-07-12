using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsignMentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private Store store = new Store();
        public ConsignmentShop()
        {
            InitializeComponent();
        }

        private void SetupData()
        {
            store.Vendors.Add(new Vendor(){FirstName = "Bill",LastName = "Sparks"});
            store.Vendors.Add(new Vendor() { FirstName = "Jorel", LastName = "Smith"});
            store.Vendors.Add(new Vendor() { FirstName = "Nown", LastName = "Ali", Commission = 0.55 });
        }
    }
}
