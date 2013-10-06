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
    public partial class Form3 : Form
    {
        public static string strCon = "server=.;user id = sa; pwd = sa; database = yanglongTest";
        SqlConnection thisConnection = new SqlConnection(strCon);
        
        Form parentPointer = null;
        DataGridView parentGridPointer = null;
        DataGridViewRow currentRow = null;
        public Form3(Form parent,DataGridView parentGridView,DataGridViewRow par)
        {
            InitializeComponent();
            parentPointer = parent;
            parentGridPointer = parentGridView;
            currentRow = par;
            this.textBox1.Text = currentRow.Cells[0].Value.ToString();
            this.textBox2.Text = currentRow.Cells[1].Value.ToString();
            this.textBox3.Text = currentRow.Cells[2].Value.ToString();
            this.textBox4.Text = currentRow.Cells[3].Value.ToString();
            this.textBox5.Text = currentRow.Cells[4].Value.ToString();
            this.textBox6.Text = currentRow.Cells[5].Value.ToString();
            this.textBox7.Text = currentRow.Cells[6].Value.ToString();
            this.textBox8.Text = currentRow.Cells[7].Value.ToString();
            this.textBox9.Text = currentRow.Cells[8].Value.ToString();
            this.textBox10.Text = currentRow.Cells[9].Value.ToString();
            this.textBox11.Text = currentRow.Cells[10].Value.ToString();
            this.textBox12.Text = currentRow.Cells[11].Value.ToString();

            this.textBox1.Text = this.textBox1.Text.Trim();
            this.textBox2.Text = this.textBox2.Text.Trim();
            this.textBox3.Text = this.textBox3.Text.Trim();
            this.textBox4.Text = this.textBox4.Text.Trim();
            this.textBox5.Text = this.textBox5.Text.Trim();
            this.textBox6.Text = this.textBox6.Text.Trim();
            this.textBox7.Text = this.textBox7.Text.Trim();
            this.textBox8.Text = this.textBox8.Text.Trim();
            this.textBox9.Text = this.textBox9.Text.Trim();
            this.textBox10.Text = this.textBox10.Text.Trim();
            this.textBox11.Text = this.textBox11.Text.Trim();
            this.textBox12.Text = this.textBox12.Text.Trim();

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                    string sql = "update FailRecord SET FailDev='" + textBox1.Text.Trim() + "', FailStartTime='" + textBox2.Text.Trim() +
                        "', FailEndTime='" + textBox3.Text.Trim() + "', FailClass='" + textBox4.Text.Trim() +
                        "', FailLevel='" + textBox5.Text.Trim() + "', FailReason='" + textBox6.Text.Trim() + "', FailAppear='" +
                        textBox7.Text.Trim() + "',Deal='" + textBox8.Text.Trim() + "', Result='" + textBox9.Text.Trim() +
                        "', DealPeople='" + textBox10.Text.Trim() + "', RecordPeople='" + textBox11.Text.Trim() + "', RecordTime='" +
                        textBox12.Text.Trim() + "' where FailDev = '"+ currentRow.Cells[0].Value.ToString()+ 
                        "'and FailStartTime='" + currentRow.Cells[1].Value +
                        "' and FailEndTime='" + currentRow.Cells[2].Value + "' and FailClass='" + currentRow.Cells[3].Value+
                        "' and FailLevel='" + currentRow.Cells[4].Value + "' and FailReason='" + currentRow.Cells[5].Value+
                        "' and FailAppear='" + currentRow.Cells[6].Value + "' and Deal='" + currentRow.Cells[7].Value+
                        "' and Result='" + currentRow.Cells[8].Value + "' and DealPeople='" + currentRow.Cells[9].Value+
                        "' and RecordPeople='" + currentRow.Cells[10].Value + "' and RecordTime='" + currentRow.Cells[11].Value+"'";
                        
                       
                        //"' where FailDev = '" + currentRow.Cells[0].Value + "'";
                    
                    SqlCommand sqlcmd = new SqlCommand(sql, thisConnection);
                    int result = 0;
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
                    if (result != 0)
                    {
                        MessageBox.Show("修改成功");
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentPointer.Enabled = true;
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentPointer.Enabled = true;
        }
    }
}
