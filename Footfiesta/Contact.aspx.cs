using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

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
            if (!IsPostBack)
            {
                connection();
                fillgrid();
            }
        }

        void connection()
        {
            cc = new ContectClass();
            cc.connection();
        }

        protected void contectsubmit_Click(object sender, EventArgs e)
        {
            connection();

            if (contectsubmit.Text == "Submit")
            {
                cc.insert(contectfirstname.Text, contectlastname.Text, contectemailid.Text, contectsubject.Text, contectmessage.Text);
            }
            else
            {
                cc.update(Convert.ToInt32(ViewState["Id"]), contectfirstname.Text, contectlastname.Text, contectemailid.Text, contectsubject.Text, contectmessage.Text);
                contectsubmit.Text = "Submit"; // Reset button text after update
            }

            ClearFields();
            fillgrid();
        }

        void fillgrid()
        {
            cc = new ContectClass();
            GridView1.DataSource = cc.fillgrid();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            connection();
            if (e.CommandName == "Cmd_Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["Id"] = id;
                contectsubmit.Text = "Update";
                filltext();
            }
            else
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["Id"] = id;
                contectsubmit.Text = "Delete";
                cc = new ContectClass();
                cc.delete(Convert.ToInt32(ViewState["Id"]));
                fillgrid();
                ClearFields();
                contectsubmit.Text = "Submit";
            }

        }

        void filltext()
        {
            cc = new ContectClass();
            ds = cc.select(Convert.ToInt32(ViewState["Id"]));

            if (ds.Tables[0].Rows.Count > 0)
            {
                contectfirstname.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                contectlastname.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                contectemailid.Text = ds.Tables[0].Rows[0]["Email-Id"].ToString();
                contectsubject.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
                contectmessage.Text = ds.Tables[0].Rows[0]["Message"].ToString();
            }
        }

        void ClearFields()
        {
            contectfirstname.Text = "";
            contectlastname.Text = "";
            contectemailid.Text = "";
            contectsubject.Text = "";
            contectmessage.Text = "";
        }
    }
}
