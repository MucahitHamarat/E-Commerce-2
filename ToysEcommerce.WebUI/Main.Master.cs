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
    public partial class Main : System.Web.UI.MasterPage
    {
        Repository<Category> repoCategory = new Repository<Category>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["indirim"] != null) Label1.Text = Session["indirim"].ToString();
            sepetSayisi.InnerText = "0";
            RepeaterCategory_Yukle();
        }
        void RepeaterCategory_Yukle()
        {
            RepeaterCategory.DataSource = repoCategory.GetAll().Where(w => w.CatID == 0).ToList();
            RepeaterCategory.DataBind();
        }

        protected void RepeaterCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)//e herbir satır
        {
            Repeater RepeaterSubCategory = (Repeater)e.Item.FindControl("RepeaterSubCategory");
            int hbiID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID"));
            RepeaterSubCategory.DataSource = repoCategory.GetAll().Where(w => w.CatID == hbiID).ToList();
            RepeaterSubCategory.DataBind();
        }
    }
}