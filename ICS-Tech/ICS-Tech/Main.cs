using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ICS_Tech
{
    public partial class Main : Form
    {
        public Main(string manager)
        {
            InitializeComponent();
            textBox1.Text = manager;
        }

        private void kurs_Click(object sender, EventArgs e)
        {

            Kurs frm = new Kurs(textBox1.Text);
            frm.Owner = this;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        /*
        private void users_Click(object sender, EventArgs e)
        {

            Users frm = new Users(textBox1.Text);
            frm.Owner = this;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }*/

        private void zakazi_Click(object sender, EventArgs e)
        {

            Zakazi frm = new Zakazi(textBox1.Text);
            frm.Owner = this;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        
        private void messages_Click(object sender, EventArgs e)
        {
            Messages frm = new Messages(textBox1.Text);
            frm.Owner = this;
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
