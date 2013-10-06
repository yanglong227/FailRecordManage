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
    public partial class Form1 : Form
    {

        public static string strCon = "server=.;user id = sa; pwd = sa; database = yanglongTest";
        SqlConnection thisConenction = new SqlConnection(strCon);
        //thisConenction.Open();
        

        private void RefreshWindow()
        {
            thisConenction.Open();
            SqlDataAdapter sap = new SqlDataAdapter("select * from FailRecord", thisConenction);
            DataSet ds = new DataSet();
            sap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            thisConenction.Close();
        }

        public Form1()
        {
            InitializeComponent();
            RefreshWindow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                   MessageBox.Show("请选中一行再删除！！！");
            else
            {
                string deleteStr = @"delete from FailRecord where FailDev='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() +
                    "' and FailStartTime='" + dataGridView1.CurrentRow.Cells[1].Value +
                    "' and FailEndTime='" + dataGridView1.CurrentRow.Cells[2].Value +
                    "' and FailClass='" + dataGridView1.CurrentRow.Cells[3].Value +
                    "' and FailLevel='" + dataGridView1.CurrentRow.Cells[4].Value +
                    "' and FailReason='" + dataGridView1.CurrentRow.Cells[5].Value +
                    "' and FailAppear='" + dataGridView1.CurrentRow.Cells[6].Value +
                    "' and Deal='" + dataGridView1.CurrentRow.Cells[7].Value +
                    "' and Result='" + dataGridView1.CurrentRow.Cells[8].Value +
                    "' and DealPeople='" + dataGridView1.CurrentRow.Cells[9].Value +
                    "' and RecordPeople='" + dataGridView1.CurrentRow.Cells[10].Value +
                    "' and RecordTime='" + dataGridView1.CurrentRow.Cells[11].Value + "'";

                thisConenction.Open();
                SqlCommand sqlcmd = new SqlCommand(deleteStr, thisConenction);
                int result = sqlcmd.ExecuteNonQuery();
                thisConenction.Close();
                RefreshWindow();
                MessageBox.Show(result.ToString());
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this,dataGridView1);
            f2.Show();
            this.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("请选中一行再修改！！！");
            else
            {
                Form3 f3 = new Form3(this, dataGridView1, dataGridView1.CurrentRow);
                f3.Show();
                this.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(this);
            f4.Show();
            this.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(this);
            f5.Show();
            this.Enabled = false;
        }
    }
}
