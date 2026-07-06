using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DormMarket
{
    public partial class BrowseDetailStudent : Form
    {
        public BrowseDetailStudent()
        {
            InitializeComponent();
        }
        private void loadDormDetails()//Load dorm details from database
        {
            //load dorm details from database a the button
        }
        private void btnMessageOwner_Click(object sender, EventArgs e)//message button
        {
            var message = new Registerstudent();
            message.Show();
            this.Hide();
        }
        private void btnProfile_Click((object sender, EventArgs e)
        {
            var profile = new ManageProfileStudent();
            profile.Show();
            this.Hide();
        }
    }
}
