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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=VIREN;initial catalog=donor;integrated security=true");
            con.Open();
            string x = "",gender,cmb;
            if (textBox1.Text.Equals(x) || textBox2.Text.Equals(x) || textBox3.Text.Equals(x) || textBox4.Text.Equals(x) || textBox6.Text.Equals(x) || (radioButton1.Checked == false && radioButton2.Checked == false) || !(comboBox2.SelectedIndex > -1))
            {
                MessageBox.Show("Insert all fields!");

            }
            else
            {
                try
                {
                    cmb = comboBox2.SelectedItem.ToString();
                    if (radioButton1.Checked == true)
                        gender = "M";
                    else
                    {
                        gender = "F";
                    }
                    SqlCommand insert = new SqlCommand("Insert into donate(name,age,gender,bgrp,city,location,disease,phone) values (@name,@age,@gender,@bgrp,@city,@location,@disease,@phone)", con);
                    insert.Parameters.AddWithValue("name", textBox1.Text);
                    insert.Parameters.AddWithValue("phone", textBox6.Text);
                    insert.Parameters.AddWithValue("age", textBox3.Text);
                    insert.Parameters.AddWithValue("gender", gender);
                    insert.Parameters.AddWithValue("city", textBox4.Text);
                    insert.Parameters.AddWithValue("location", textBox2.Text);
                    insert.Parameters.AddWithValue("bgrp", cmb);
                    insert.Parameters.AddWithValue("disease", textBox5.Text);
                    insert.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                this.Hide();
                MessageBox.Show("Record Inserted!");
                Form3 o = new Form3();
                o.Show();
            }
            con.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           // comboBox2.
        }
    }
}
