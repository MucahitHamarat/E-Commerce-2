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
    public partial class SolTaraf : System.Web.UI.UserControl
    {
        Repository<Category> repoCategory = new Repository<Category>();
        Repository<Brand> repoBrand = new Repository<Brand>();
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterKategoriYukle();
            RepeaterMarkaYukle();
        }
        void RepeaterKategoriYukle()
        {
            RepeaterKategori.DataSource = repoCategory.GetAll().Where(w => w.CatID == 0).OrderBy(o => o.Order).ToList();
            RepeaterKategori.DataBind();
        }
        void RepeaterMarkaYukle()
        {
            RepeaterMarka.DataSource = repoBrand.GetAll().OrderBy(o => o.Name).ToList();
            RepeaterMarka.DataBind();
        }
    }
}