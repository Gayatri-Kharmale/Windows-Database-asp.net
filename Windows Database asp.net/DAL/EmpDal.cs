using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Windows_Database_asp.net.Model;

namespace Windows_Database_asp.net.DAL
{
   public  class EmpDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmpDal()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);

        }
        public DataTable GetAllEmps()
        {
            DataTable table=new DataTable();
            string qry = "select * from Emp";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            table.Load(dr);
            con.Close();
            return table;
        }
        public Emp GetEmpById(int id)
        {
            Emp emp = new Emp();
            string qry = "select * from Emp where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
                dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.Name=dr["Name"].ToString();
                    emp.Designation = dr["Designation"].ToString();
                    emp.Salary = Convert.ToInt32(dr["Salary"]);

                }
            }
            con.Close();
            return emp;
        }
        public int Save(Emp emp)
        {
            string qry = "insert into Emp values(@name,@designation,@salary)";

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@designation", emp.Designation);

            cmd.Parameters.AddWithValue("@salary", emp.Salary);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Emp emp)
        {
            string qry = "update from Emp set Name=@name,Designation=@designation,Salary=@salary)";

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@designation", emp.Designation);

            cmd.Parameters.AddWithValue("@salary", emp.Salary);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int id)
        {
            string qry = "delete from Emp where Id=@id ";

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id",id);


            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
