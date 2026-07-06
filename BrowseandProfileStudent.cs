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
      private void ManangeProfileStudent_Load(object sender, EventArgs e)//Load profile infos
        {
            //Load the profile infos
        }

        private void btnChangePhoto_Click(object sender, EventArgs e) //change photo button
        {
            
        }

        private void btnSaveChanges_Click(object sender, EventArgs e) //save changes button
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Text = //database value Name;
                return;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Text = //database value Phone;
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.Text = //database value Phone;
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                txtAddress.Text = //database value Phone;
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Text = //database value Phone;
                return;
            }
            //edit a row of student profile database with the new values from the textboxes
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var role = new Role();
            role.Show();
            this.Hide();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var browse = new BrowseDormStudent();
            browse.Show();
            this.Hide();
        }
    }
}
