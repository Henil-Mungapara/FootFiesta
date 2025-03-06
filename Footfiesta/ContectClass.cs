using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Footfiesta
{
    public class ContectClass
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        String s = ConfigurationManager.ConnectionStrings["Footfiesta"].ToString();

        public void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        public void insert(string fname, string lname, string email, string sub, string msg)
        {
            cmd = new SqlCommand("insert into Contect_tbl(FirstName,LastName,[Email-Id],Subject,Message)values('" + fname + "', '" + lname + "', '" + email + "', '" + sub + "', '" + msg + "')", con);
            cmd.ExecuteNonQuery();
        }
        public DataSet fillgrid()
        {
            connection();
            da = new SqlDataAdapter("select * from Contect_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public DataSet select(int id)
        {
            connection();
            da = new SqlDataAdapter("select * from Contect_tbl where Contect_Id = @Id", con);
            da.SelectCommand.Parameters.AddWithValue("@Id", id);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public void update(int id, string fname, string lname, string email, string sub, string msg)
        {
            connection();
            cmd = new SqlCommand("update Contect_tbl set FirstName='" + fname + "', LastName='" + lname + "',[Email-Id]='" + email + "', Subject='" + sub + "', Message='" + msg + "' where Contect_Id = '" + id + "'  ", con);
            cmd.ExecuteNonQuery();
        }

        public void delete(int id) {
            connection();
            cmd = new SqlCommand("delete from Contect_tbl where Contect_Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
