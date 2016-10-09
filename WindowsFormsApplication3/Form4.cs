using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 o = new Form1();
            o.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FullName.Items.Clear();
            BloodGroup.Items.Clear();
            Location.Items.Clear();
            City.Items.Clear();

            string x="",cmb,area,ct;
            if (textBox1.Text.Equals(x) || textBox2.Text.Equals(x) || !(comboBox1.SelectedIndex > -1))
            {
                MessageBox.Show("Enter all fields");
            }
            else
            {
                cmb = comboBox1.SelectedItem.ToString();
                area = textBox2.Text;
                ct = textBox1.Text;
                SqlConnection con = new SqlConnection("server=VIREN;initial catalog=donor;integrated security=true");
                con.Open();
                string SQL = String.Format("select * from donate where bgrp = '{0}' and location = '{1}' and city = '{2}'", cmb,area,ct); 
                SqlDataAdapter ad = new SqlDataAdapter(SQL, con);
                DataSet ds = new DataSet();
                ad.Fill(ds, "try");
                int i = ds.Tables[0].Rows.Count, k; 
                for (k = 0; k < i; k++ )
                    FullName.Items.Add(Convert.ToString(ds.Tables[0].Rows[k][0]));
                for (k = 0; k < i; k++)
                    BloodGroup.Items.Add(Convert.ToString(ds.Tables[0].Rows[k][3]));
                for (k = 0; k < i; k++)
                    City.Items.Add(Convert.ToString(ds.Tables[0].Rows[k][4]));
                for (k = 0; k < i; k++)
                    Location.Items.Add(Convert.ToString(ds.Tables[0].Rows[k][5]));
                for (k = 0; k < i; k++)
                    Phone.Items.Add(Convert.ToString(ds.Tables[0].Rows[k][7]));
               /* SqlCommand cmd = new SqlCommand("select * from donate", con);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    FullName.Items.Add(r[0].ToString());
                    BloodGroup.Items.Add(r[3].ToString());
                    City.Items.Add(r[4].ToString());
                    Location.Items.Add(r[5].ToString());
                }
*/            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(textBox1.Text,textBox2.Text);
            f.Show();
        }
    }
}
