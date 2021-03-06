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
                if (this.Request.QueryString["ID"] == null)
                {
                    this.btnDelete.Visible = false;
                    this.btnChangePWD.Visible = false;
                }
                else
                {
                    
                    this.btnDelete.Visible = true;
                    this.btnChangePWD.Visible =true;

                    string idText = this.Request.QueryString["ID"];
                    
                    if (idText != null)
                    {
                        var drUser = UserInfoManager.GetUser(currentUser.ID);

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
                        this.ltMsg.Text = "ID is required.";
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
            string pwd = this.txtPWD.Text;


            string idText = this.Request.QueryString["ID"];
            if (string.IsNullOrWhiteSpace(idText))
            {
                UserInfoManager.CreateUser(id, name,pwd,account, email, userlevel);
                if (pwd.ToString().Length >= 8 && pwd.ToString().Length <= 16)
                {
                    MessageBox.Show("新增成功");
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
                
                if (idText != null)
                {
                    UserInfoManager.UpdateUserInfo(account, name, email);

                    this.txtAccount.Text = currentUser.Account;
                }
            }

            Response.Redirect("/SystemAdmin/UserList.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string account = this.txtAccount.Text;
            var currentUser = AuthManager.GetCurrentUser();
            string idText = this.Request.QueryString["ID"];

            if (string.IsNullOrWhiteSpace(idText))
                return;
            else
            {
                UserInfoManager.DeleteUser(account);
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

            string idText = this.Request.QueryString["ID"];

            if (idText != null)
            { 
                Response.Redirect("/SystemAdmin/UserPassword.aspx?ID=" + idText.ToString());

            }

        }

       
    }
}