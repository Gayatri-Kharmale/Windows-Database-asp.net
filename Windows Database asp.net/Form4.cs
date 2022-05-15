using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Database_asp.net
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;


        public Form4()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);

        }
        public DataSet GetEmps()
        { 
            da=new SqlDataAdapter("select * from Emp",con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb=new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "emp");
            return ds;
        }
        
        


        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            ds=GetEmps();
            DataRow row=ds.Tables["emp"].NewRow();
            row["Name"] = textname.Text;
            row["Salary"] = textsalary.Text;
            ds.Tables["emps"].Rows.Add(row);
            int res = da.Update(ds.Tables["emp"]);
            if (res == 1)
                MessageBox.Show("Records saved");
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            ds= GetEmps();
            DataRow row = ds.Tables["emp"].Rows.Find(Convert.ToInt32(textid.Text)); 
            if(row != null)
            {
                textname.Text= row["Name"].ToString();
                textsalary.Text= row["Salary"].ToString();
            }
            else
            {
                MessageBox.Show("Record not found");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            ds = GetEmps();
            DataRow row = ds.Tables["emp"].Rows.Find(Convert.ToInt32(textid.Text));
            if (row != null)
            {
                row["Name"] = textname.Text;
                row["Salary"]=textsalary.Text;
                int res = da.Update(ds.Tables["emp"]);
                if (res == 1)
                    MessageBox.Show("records Updated");

            }
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            ds = GetEmps();
            DataRow row = ds.Tables["emp"].Rows.Find(Convert.ToInt32(textid.Text));
            if (row != null)
            {
                row.Delete();
                int res = da.Update(ds.Tables["emp"]);
                if (res == 1)
                    MessageBox.Show("records Updated");

            }
            else
            {
                MessageBox.Show("Record not found");
            }
        }
    }
}
