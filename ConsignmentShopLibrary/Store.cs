using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Store
    {
        public string Name { get; set; }
        public List<Vendor> Vendors { get; set; }
        public List<Item> Items { get; set; }


        public Store()
        {
            //create list of vendors and items otherwise will show null reference
            // when adding items into the store
            Vendors = new List<Vendor>();
            Items = new List<Item>();
        }

    }
}
