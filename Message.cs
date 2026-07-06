using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DormMarket
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }
    }
    private void btnProfile_Click((object sender, EventArgs e)
    {
        var profile = new ManageProfileStudent();
        profile.Show();
        this.Hide();
    }
}
