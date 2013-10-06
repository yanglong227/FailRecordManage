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
    public partial class Form5 : Form
    {
        Form parentPointer = null;

        public static string strCon = "server=.;user id = sa; pwd = sa; database = yanglongTest";
        SqlConnection thisConnection = new SqlConnection(strCon);
        public Form5(Form par)
        {
            InitializeComponent();
            parentPointer = par;
            textBox1.Text = "YYYY-MM-DD";
            textBox2.Text = "YYYY-MM-DD";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 ||
              textBox4.Text.Trim().Length == 0)
                MessageBox.Show("查询条件不能为空！！");
            else
            {
                string sql = "select * from FailRecord where FailDev in ("+
                    "select Name from DevInfo where Dep='"+
                    textBox4.Text.Trim()+"' and Sys='"+
                    textBox3.Text.Trim()+"') and FailStartTime > '"+ textBox1.Text.Trim()+
                    "' and FailEndTime < '"+ textBox2.Text.Trim()+"'";

                thisConnection.Open();
                try
                {
                    SqlDataAdapter sap = new SqlDataAdapter(sql, thisConnection);
                    DataSet ds = new DataSet();
                    sap.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    thisConnection.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentPointer.Enabled = true;
        }
    }
}
