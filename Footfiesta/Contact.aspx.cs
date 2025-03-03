using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Footfiesta
{
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        ContectClass cc;
        protected void Page_Load(object sender, EventArgs e)
        {
            connection();
        }
        void connection() {
            cc = new ContectClass();
            cc.connection();
        }

        protected void contectsubmit_Click(object sender, EventArgs e)
        {
            connection();
            cc.insert(contectfirstname.Text, contectlastname.Text, contectemailid.Text, contectsubject.Text, contectmessage.Text);
        }
    }
}