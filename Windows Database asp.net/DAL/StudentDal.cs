using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_Database_asp.net.Model;

namespace Windows_Database_asp.net.DAL
{
    public class ProductDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDal()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }
        public DataTable GetAllstudent()
        {
            DataTable table = new DataTable();
            string qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            table.Load(dr);
            con.Close();
            return table;
        }
        public Student GetStudentByRollno(int rollno)
        {
            Student stud = new Student();
            string qry = "select * from Student where Rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    stud.Rollno = Convert.ToInt32(dr["Rollno"]);
                    stud.Name = dr["Name"].ToString();
                    stud.Branch = dr["branch"].ToString();
                    stud.Per = Convert.ToInt32(dr["Per"]);

                }
            }
            con.Close();
            return stud;
        }
        public int Save(Student stud)
        {
            string qry = "insert into Student values(@name,@branch,@per)";

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@designation", stud.Branch);

            cmd.Parameters.AddWithValue("@per", stud.Per);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Student stud)
        {
            string qry = "update from Student set Name=@name,Branch=@branch,Per=@per)";

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@branch", stud.Branch);

            cmd.Parameters.AddWithValue("@per", stud.Per);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int rollno)
        {
            string qry = "delete from Student where Rollno=@rollno ";

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", rollno);


            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }

    

}
