using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DormMarket
{
    public partial class BrowseDormStudent : Form
    {
        public BrowseDormStudent()
        {
            InitializeComponent();
        }
        private void OwnersDorms()//Load buttons create all each row of Database
        {
            while ()
            {
                //create button for each row of database
            }//loop checking number of row
        }

        private void btnapplyfilter_Click(object sender, EventArgs e)//apply filter button
        {
            if(string.IsNullOrEmpty(searchbar))
            {
                // Apply filter logic here including database(long coding)
            }
            else
            {
                //base on apply filter list only include by the search bar text
            }
        }

    }
}
