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
    public partial class Default : System.Web.UI.Page
    {
        Repository<Slider> repoSlider = new Repository<Slider>();
        Repository<Product> repoProduct = new Repository<Product>();
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterSlider_Yukle();
            RepeaterProducts_Yukle();
        }
        void RepeaterSlider_Yukle()
        {
            RepeaterSlider.DataSource = repoSlider.GetAll().OrderBy(o => o.Order).ToList();
            RepeaterSlider.DataBind();
        }
        void RepeaterProducts_Yukle()
        {
            RepeaterProducts.DataSource = repoProduct.GetAll().Select(s=>new {s.ID,s.Name,s.Picture,s.Description,s.Price,s.Stock,Brand=s.Brand.Name }).OrderByDescending(o => o.ID).ToList();
            RepeaterProducts.DataBind();
        }
    }
}