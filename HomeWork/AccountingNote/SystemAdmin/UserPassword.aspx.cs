using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AccountingNote.SystemAdmin
{
    public partial class UserPassword : System.Web.UI.Page
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

            string idText = this.Request.QueryString["UID"];
            int uid;
            if (int.TryParse(idText, out uid))
            {
                var drUser = UserInfoManager.GetUser(uid, currentUser.ID);

                this.ltAccount.Text = drUser["Account"].ToString();
            }
        }
        protected void btnChangePWD_Click1(object sender, EventArgs e)
        {
            var currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)                             
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }
            string id = currentUser.ID;
            string account = this.ltAccount.Text;
            string pwdText = this.txtPWD.Text;
            string cPWDText = this.txtCheckPWD.Text;



            string idText = this.Request.QueryString["UID"];

            string npwd = this.txtNewPWD.Text;
            int uid;
            if (int.TryParse(idText, out uid))
            {
                if (string.Compare(pwdText, cPWDText, false) == 0)
                {
                    // Execute 'update db'
                    UserInfoManager.UpdateUserPWD(uid, npwd);

                    this.ltAccount.Text = currentUser.Account;

                }
                else
                {
                    ltMsg.Text = "Please input password again..";
                }

                if(npwd.Length >= 8 && npwd.Length <= 16)
                {
                    MessageBox.Show("修改密碼成功");
                    Response.Redirect("/SystemAdmin/UserList.aspx");
                }
                else
                {
                    MessageBox.Show("密碼長度須為 8~16 碼");
                    return;
                }
                
            }
        }
    }
}