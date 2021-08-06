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
    public partial class UserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string account = this.Session["UserLoginInfo"] as string;
            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)                            
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            if (!this.IsPostBack)
            {
                if (this.Request.QueryString["UID"] == null)
                {
                    this.btnDelete.Visible = false;
                    this.btnChangePWD.Visible = false;
                }
                else
                {
                    
                    this.btnDelete.Visible = true;
                    this.btnChangePWD.Visible =true;

                    string idText = this.Request.QueryString["UID"];
                    int uid;
                    if (int.TryParse(idText, out uid))
                    {
                        var drUser = UserInfoManager.GetUser(uid, currentUser.ID);

                        if (drUser == null)
                        {
                            this.ltMsg.Text = "Data doesn't exist";
                            this.btnSave.Visible = false;
                            this.btnDelete.Visible = false;
                        }
                        else
                        {
                            this.txtAccount.Text = drUser["Account"].ToString();
                            this.txtName.Text = drUser["Name"].ToString();
                            this.txtEmail.Text = drUser["Email"].ToString();
                            this.ddlActType.SelectedItem.Value = drUser["UserLevel"].ToString();
                            this.txtPWD.Text = "******";

                            //int p = drUser["PWD"].ToString().Length;
                            //for(int i = 0 ; i <= p ; i++)
                            //{
                            //    this.txtPWD.Text += "*";
                            //}
                            this.txtPWD.ReadOnly = true;

                            this.txtAccount.ReadOnly = true;
                        }
                    }
                    else
                    {
                        this.ltMsg.Text = "UID is required.";
                        this.btnSave.Visible = false;
                        this.btnDelete.Visible = false;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string id = currentUser.ID;
            string name = this.txtName.Text;
            string account = this.txtAccount.Text;
            string email = this.txtEmail.Text;
            string userlevel = this.ddlActType.SelectedItem.Value;
            string pwdText = this.txtPWD.Text;


            string idText = this.Request.QueryString["UID"];
            if (string.IsNullOrWhiteSpace(idText))
            {

                int pwd = Convert.ToInt32(pwdText);
                UserInfoManager.CreateUser(id, name,pwd,account, email, userlevel);
                if (pwd.ToString().Length >= 8 && pwd.ToString().Length <= 16)
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
            else
            {
                int uid;
                if (int.TryParse(idText, out uid))
                {
                    UserInfoManager.UpdateUserInfo(uid, id, name, account, email, userlevel);

                    this.txtAccount.Text = currentUser.Account;
                }
            }

            Response.Redirect("/SystemAdmin/UserList.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idText = this.Request.QueryString["UID"];

            if (string.IsNullOrWhiteSpace(idText))
                return;

            int uid;
            if (int.TryParse(idText, out uid))
            {
                UserInfoManager.DeleteUser(uid);
            }

            Response.Redirect("/SystemAdmin/UserList.aspx");
        }

        protected void btnChangePWD_Click(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string idText = this.Request.QueryString["UID"];

            if (idText != null)
            { 
                Response.Redirect("/SystemAdmin/UserPassword.aspx?UID=" + idText.ToString(), true);

            }
            else
            {
                this.ltMsg.Text = "UID is required.";
                this.btnSave.Visible = false;
                this.btnDelete.Visible = false;
            }

        }

       
    }
}