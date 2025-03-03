using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Footfiesta
{
    public class ContectClass
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        String s = ConfigurationManager.ConnectionStrings["Footfiesta"].ToString();

        public void connection() {
            con = new SqlConnection(s);
            con.Open();
        }

        public void insert(string fname, string lname, string email, string sub, string msg) {
            cmd = new SqlCommand("insert into Contect_tbl(FirstName,LastName,[Email-Id],Subject,Message)values('"+fname+ "', '" + lname + "', '" + email + "', '" + sub + "', '" + msg + "')", con);
            cmd.ExecuteNonQuery();

        }
    }
}