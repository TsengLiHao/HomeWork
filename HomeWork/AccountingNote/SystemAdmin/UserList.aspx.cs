using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)                             
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }
            var dt =UserInfoManager.GetUserInfoList(currentUser.ID);

            if (dt.Rows.Count > 0)
            {
                this.gvUserInfoList.DataSource = dt;
                this.gvUserInfoList.DataBind();
            }
            else
            {
                this.gvUserInfoList.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        protected void btnCreate_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/UserDetail.aspx");
        }

    }
}