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
using Windows_Database_asp.net.Model;
using Windows_Database_asp.net.DAL;
using System.Configuration;

namespace Windows_Database_asp.net
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);

        }
        

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into Product values(@id,@name,@price)";
                cmd = new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@id",Convert.ToInt32(textid.Text));
                cmd.Parameters.AddWithValue("@name",textname.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(textprice.Text));
                con.Open();
                int res=cmd.ExecuteNonQuery();
                if(res == 1)
                {
                    MessageBox.Show("Record inserted");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select*from Product where  Id=@id";
                cmd=new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textid.Text));
                con.Open();
                dr=cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        textname.Text = dr["Name"].ToString();
                        textprice.Text = dr["Price"].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("Records not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {


                string qur = "update Product set Name=@name,Price=@price where Id=@id";
                cmd = new SqlCommand(qur, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textid.Text));
                cmd.Parameters.AddWithValue("@name", textname.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(textprice.Text));
                con.Open();
                int res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    MessageBox.Show("Record Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {


                string qur = "delete from Product where Id=@id";
                cmd = new SqlCommand(qur, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textid.Text));
                
                con.Open();
                int res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    MessageBox.Show("Record Deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            try
            {


                string qur = "select max(Id)from Product";
                cmd = new SqlCommand(qur, con);
                
                con.Open();
                Object obj=cmd.ExecuteScalar();
                if (obj==DBNull.Value)
                {
                    textid.Text = "102";
                }
                else
                {
                    int id = Convert.ToInt32(obj);
                    id++;
                    textid.Text = id.ToString();
                }
                textid.Enabled = false;
                //textname.Clear;
                //textprice.Clear;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnshowallproduct_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from Product";
                cmd = new SqlCommand(qry, con);
                
                con.Open();
                dr= cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource= dt;
                }
                else
                {
                    MessageBox.Show("Records not found");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {



              textid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
              textname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

              textprice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
