using System;
using System.Windows.Forms;

namespace DormMarket
{
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
        }

        private void btnStudentContinue_Click(object sender, EventArgs e)// student continue button
        {
            var login = new LoginStudent();
            login.Show();
            this.Hide();
        }

        private void btnOwnerContinue_Click(object sender, EventArgs e)//Owner continue button
        {
            var owner = new LoginOwner();
            owner.Show();
            this.Hide();
        }
    }
}
