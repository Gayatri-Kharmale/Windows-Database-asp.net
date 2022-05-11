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
using Windows_Database_asp.net.DAL;
using Windows_Database_asp.net.Model;

namespace Windows_Database_asp.net
{
    public partial class Form3 : Form
    {
        ProductDal studentdal = new ProductDal();
        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            


                Student stud= new Student();
                stud.Name =textname.Text;
                stud.Branch = textbranch.Text;
                stud.Per = Convert.ToInt32(textper.Text);
                 int res = studentdal.Save(stud);

            if (res == 1)
                {
                    MessageBox.Show("Record inserted");


                }
            
            
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            Student stud = studentdal.GetStudentByRollno(Convert.ToInt32(textrollno.Text));
            if (stud.Rollno > 0)
            {
                textname.Text = stud.Name;
                textbranch.Text = stud.Branch;
                textper.Text = stud.Per.ToString();
            }
            else
            {
                MessageBox.Show("Records not found");
            }


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Student stud = new Student();
            stud.Rollno = Convert.ToInt32(textrollno.Text);
            stud.Name = textname.Text;
            stud.Branch = textbranch.Text;
            stud.Per = Convert.ToInt32(textper.Text);
            int res = studentdal.Save(stud);
            if (res == 1)
            {
                MessageBox.Show("Record updated");


            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int res = studentdal.Delete(Convert.ToInt32(textrollno.Text));
            if (res == 1)
            {
                MessageBox.Show("Record Deleted");


            }

        }
    }
}
