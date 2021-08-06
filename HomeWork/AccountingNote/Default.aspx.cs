using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)                           // 可能是按鈕跳回本頁，所以要判斷 postback
            {
                if (!AuthManager.IsLogined())                // 如果尚未登入，導至登入頁
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                var currentUser = AuthManager.GetCurrentUser();

                if (currentUser == null)                             // 如果帳號不存在，導至登入頁
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                DataRow dr = AccountingManager.GetMinCreateDate();
                DataRow lastdr = AccountingManager.GetMaxCreateDate();
                DataRow value = AccountingManager.GetValueOfAccounting();
                DataRow mValue = UserInfoManager.GetValueOfMember();



                if (dr == null)
                {
                    HttpContext.Current.Session["UserLoginInfo"] = null;
                }

                this.ltFirsttime.Text = dr["CreateDate"].ToString();
                this.ltLasttime.Text = lastdr["CreateDate"].ToString();
                this.ltValueOfExpense.Text = $"共 {value["ID"].ToString()} 筆";
                this.ltValueOfMember.Text = $"共 {mValue["ID"].ToString()} 人";


            }
        }
    }
}