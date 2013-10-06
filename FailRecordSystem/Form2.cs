using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FailRecordSystem
{
    public partial class Form2 : Form
    {
        public static string strCon = "server=.;user id = sa; pwd = sa; database = yanglongTest";
        SqlConnection thisConnection = new SqlConnection(strCon);

        Form parentPointer = null;
        DataGridView parentGridPointer = null;
        public Form2(Form parent,DataGridView parentGridView)
        {
            InitializeComponent();
            parentPointer = parent;
            parentGridPointer = parentGridView;
            textBox2.Text = "YYYY-MM-DD";
            textBox3.Text = "YYYY-MM-DD";
            textBox12.Text = "YYYY-MM-DD";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 ||
               textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0 ||
               textBox7.Text.Trim().Length == 0 || textBox8.Text.Trim().Length == 0 || textBox9.Text.Trim().Length == 0 ||
               textBox10.Text.Trim().Length == 0 || textBox11.Text.Trim().Length == 0 || textBox12.Text.Trim().Length == 0)
            {
                MessageBox.Show("任何一个字段都不能为空");
            } 
            else
            {
                thisConnection.Open();
                string sql = "insert into FailRecord values('" + textBox1.Text.Trim().ToString() + "','" +
                    textBox2.Text.Trim().ToString() + "','" +
                    textBox3.Text.Trim().ToString() + "','" +
                    textBox4.Text.Trim().ToString() + "','" +
                    textBox5.Text.Trim().ToString() + "','" +
                    textBox6.Text.Trim().ToString() + "','" +
                    textBox7.Text.Trim().ToString() + "','" +
                    textBox8.Text.Trim().ToString() + "','" +
                    textBox9.Text.Trim().ToString() + "','" +
                    textBox10.Text.Trim().ToString() + "','" +
                    textBox11.Text.Trim().ToString() + "','" +
                    textBox12.Text.Trim().ToString() + "')";
                
                SqlCommand sqlcmd = new SqlCommand(sql, thisConnection);
                int result=0;
                try
                {
                    result = sqlcmd.ExecuteNonQuery();
                    thisConnection.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    thisConnection.Close();
                }
                if (result!=0)
                {
                    MessageBox.Show("插入成功");
                    parentPointer.Enabled = true;

                    thisConnection.Open();
                    SqlDataAdapter sap = new SqlDataAdapter("select * from FailRecord", thisConnection);
                    DataSet ds = new DataSet();
                    sap.Fill(ds);
                    parentGridPointer.DataSource = ds.Tables[0];
                    thisConnection.Close();

                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentPointer.Enabled = true;
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentPointer.Enabled = true;
        }
    }
}
