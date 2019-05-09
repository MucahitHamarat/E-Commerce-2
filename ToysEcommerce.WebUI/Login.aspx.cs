using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToysEcommerce.BLL.Repositories;
using ToysEcommerce.BOL.Entities;

namespace ToysEcommerce.WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        Repository<Admin> repoAdmin = new Repository<Admin>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGiris_Click(object sender, EventArgs e)
        {
            Admin admin = repoAdmin.GetBy(g => g.UserName == txtUserName.Value && g.Password == txtPassword.Value);
            if (admin != null)
            {
                Session["AdSoyad"] = admin.NameSurname;
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Value, chBeniHatirla.Checked);
            }
            else LabelHata.Text = "Hatalı kullanıcı adı veya şifre";
        }
    }
}