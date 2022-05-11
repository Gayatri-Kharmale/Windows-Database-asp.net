using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms;
using System.Data.SqlClient;
using Windows_Database_asp.net.Model;
using Windows_Database_asp.net.DAL;

namespace Windows_Database_asp.net
{
    public partial class Form2 : Form
    {
        EmpDal empdal = new EmpDal();
        public Form2()
        {
            InitializeComponent();

        }

        private void btncreate_Click(object sender, EventArgs e)
        {
           


                Emp emp = new Emp();
                emp.Name = textname.Text;
                emp.Designation = textdesignation.Text;
                emp.Salary = Convert.ToDouble(textsalary.Text); 
                int res=empdal.Save(emp);
                if (res == 1)
                {
                    MessageBox.Show("Record inserted");

                    
                }
            
            
            
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            
                Emp emp = empdal.GetEmpById(Convert.ToInt32(textid.Text));
            if (emp.Id > 0)
            {
                textname.Text = emp.Name;
                textdesignation.Text = emp.Designation;
                textsalary.Text = emp.Salary.ToString();
            }
            else
            {
                MessageBox.Show("Records not found");
            }
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            


                Emp emp = new Emp();
                emp.Id= Convert.ToInt32(textid.Text);
                emp.Name = textname.Text;
                emp.Designation = textdesignation.Text;
                emp.Salary = Convert.ToDouble(textsalary.Text);
                int res = empdal.Save(emp);
                if (res == 1)
                {
                    MessageBox.Show("Record updated");


                }
        }
            
            
     

        private void btnsalary_Click(object sender, EventArgs e)
        {
            

               
                int res = empdal.Delete(Convert.ToInt32(textid.Text));
                if (res == 1)
                {
                    MessageBox.Show("Record Deleted");


                }
            
            
        }
    }
}
