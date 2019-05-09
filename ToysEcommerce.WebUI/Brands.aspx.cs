using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToysEcommerce.BLL.Repositories;
using ToysEcommerce.BOL.Entities;

namespace ToysEcommerce.WebUI
{
    public partial class Brands : System.Web.UI.Page
    {
        Repository<Brand> repoBrand = new Repository<Brand>();
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterBrand.DataSource = repoBrand.GetAll().ToList();
            RepeaterBrand.DataBind();
        }

        protected void ButtonBilgiGonder_Click(object sender, EventArgs e)
        {
            //Session["indirim"] = "10";
            //Response.Redirect("Hakkimizda.aspx");

            //Cookie Oluşturma
            HttpCookie kukim = new HttpCookie("MyCookie");
            kukim["Ad"] = "Erkan";
            kukim["Sepet"] = "10 Ürüne baktı";
            kukim.Expires = DateTime.Now.AddYears(5);
            Response.Cookies.Add(kukim);
        }
    }
}