using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApplication3
{
    public partial class Form5 : Form
    {
        string f, s;
        public Form5(string p, string q)
        {
            InitializeComponent();
            f = q;
            s = p;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("https://www.google.co.in/maps?=q");
                query.Append(f + "," + "+");
                query.Append(s + "," + "+");
                webBrowser1.Navigate(query.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
