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

        // create a store that has vendors and items in it
        //bind the items to a binding source to show the items in a list
        // create a custom property in items to display the title and price together
        // display the data from the binding source into the listbox

        private Store store = new Store();
        BindingSource itemsBinding = new BindingSource();
        private List<Item> shoppingCartData = new List<Item>();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorBinding = new BindingSource();
        
        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items;
            itemsListBox.DataSource = itemsBinding;

            itemsListBox.DisplayMember = "Display";
            itemsListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListBox.DataSource = cartBinding;

            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            vendorBinding.DataSource = store.Vendors;
            vendorListbox.DataSource = vendorBinding;

            vendorListbox.DisplayMember = "Display";
            vendorListbox.ValueMember = "Display";
        }

        private void SetupData()
        {
            //hard coded list of items added to the store in order to populate the list
            store.Vendors.Add(new Vendor() { FirstName = "Bill", LastName = "Sparks" });
            store.Vendors.Add(new Vendor() { FirstName = "Jorel", LastName = "Smith" });
            store.Vendors.Add(new Vendor() { FirstName = "Nown", LastName = "Ali" });
            store.Items.Add(new Item()
            {
                Title = "GinGa",
                Description = "ginseng",
                Price = (decimal)2.30,
                Owner = store.Vendors[0]
            });
            store.Items.Add(new Item()
            {
                Title = "crack the codig interview",
                Description = "programming",
                Price = (decimal)3.30,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item()
            {
                Title = "greeking algorithms",
                Description = "programming",
                Price = (decimal)5.30,
                Owner = store.Vendors[2]
            });

            store.Name = "Grizzly Books";
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            //figure out what items are selected from the list box
            //copy that item from the listbox to the shopping cart
            
            Item selectedItem =  (Item)itemsListBox.SelectedItem;
            shoppingCartData.Add(selectedItem);
            //refresh list to add to the shopping cart
            cartBinding.ResetBindings(false);
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            //mark each item in the cart as sold
            // clear the cart
            foreach (Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commission * item.Price;
                store.Profit += (1-(decimal)item.Owner.Commission) * item.Price;
            }

            //show the store profit
            storeProfitValue.Text = string.Format("${0}", store.Profit);

            //clear the shopping cart after the purchase
            shoppingCartData.Clear();
            
            //bind the items to the binding source gain which are not sold.
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();

            //refresh bindings to refresh datasources to update the list
            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorBinding.ResetBindings(false);
        }
    }
}
