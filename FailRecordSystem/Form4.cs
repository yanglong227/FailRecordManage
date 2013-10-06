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
    public partial class Form4 : Form
    {
        public static string strCon = "server=.;user id = sa; pwd = sa; database = yanglongTest";
        SqlConnection thisConnection = new SqlConnection(strCon);

        Form parentPointer = null;
        public Form4(Form parten)
        {
            InitializeComponent();
            parentPointer = parten;

            thisConnection.Open();
            SqlDataAdapter sap = new SqlDataAdapter("select * from DevInfo", thisConnection);
            DataSet ds = new DataSet();
            sap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            thisConnection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentPointer.Enabled = true;
            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentPointer.Enabled = true;
        }
    }
}
