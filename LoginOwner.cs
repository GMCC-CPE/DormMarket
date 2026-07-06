using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DormMarket
{
    public partial class LoginRegisterAdmin : Form
    {
        public LoginRegisterAdmin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
{
    string email = txtEmail.Text.Trim();
    string password = txtPassword.Text;

    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
    {
        MessageBox.Show("Please enter both email and password.");
        return;
    }

    bool loginOk = true;//placeholder for Database to check email and password

    if (!loginOk)
    {
        MessageBox.Show("Invalid email or password.");
        return;
    }

    var browse = new BrowseDormStudent(fullName: email);//go to Browse page with the account
    browse.Show();
    this.Hide();
}

private void btnForgotPassword_Click(object sender, EventArgs e)//Forgot password button
{
    //forgot password functionality can be implemented here
}

private void btnCreateAccount_Click(object sender, EventArgs e)// create account button that proceed to register page
{
    var register = new RegisterOwner();
    register.Show();
    this.Hide();
}
    }
}
