using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;

namespace NextGenSoft
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod]
        public static void SaveEnquiry(Enquiry enquiry)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO m_Enquiry VALUES(@Name, @Email,@PhoneNo,@Description,@IsActive,@CreatedDate)"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", enquiry.Name);
                    cmd.Parameters.AddWithValue("@Email", enquiry.Email);
                    cmd.Parameters.AddWithValue("@PhoneNo", enquiry.PhoneNo);
                    cmd.Parameters.AddWithValue("@Description", enquiry.Description);
                    cmd.Parameters.AddWithValue("@IsActive", true);
                    cmd.Parameters.AddWithValue("@CreatedDate", "");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}