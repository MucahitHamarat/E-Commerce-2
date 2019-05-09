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
    public partial class Hakkimizda : System.Web.UI.Page
    {
        Repository<Brand> repoBrand = new Repository<Brand>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["indirim"] != null) h1Baslik.InnerText = Session["indirim"].ToString();

            //Cookie OKUMA
            //if (Request.Cookies["MyCookie"] != null)
            //{
            //    HttpCookie kukim = Request.Cookies["MyCookie"];
            //    LabelAd.Text = kukim["Ad"];
            //    LabelSepet.Text = kukim["Sepet"];
            //}
            if (Request.Cookies["MyCookie"] != null)
            {
                LabelAd.Text = Request.Cookies["MyCookie"]["Ad"];
                LabelSepet.Text = Request.Cookies["MyCookie"]["Sepet"];
            }

            if (IsPostBack == false)// if(!IsPostBack)
            {
                CheckBoxList1.DataSource = repoBrand.GetAll().OrderBy(o => o.Name).ToList();
    CheckBoxList1.DataBind();

                RadioButtonList1.DataSource = repoBrand.GetAll().OrderBy(o => o.Name).ToList();
    RadioButtonList1.DataBind();

                DropDownList1.DataSource = repoBrand.GetAll().OrderBy(o => o.Name).ToList();
    DropDownList1.DataBind();

                GridView1.DataSource = repoBrand.GetAll().OrderBy(o => o.Name).ToList();
    GridView1.DataBind();
            }
        }
        protected void ButtonGonder_Click(object sender, EventArgs e)
{
    Label1.Text = "";
    foreach (ListItem hbi in CheckBoxList1.Items)
    {
        if (hbi.Selected) Label1.Text += hbi.Text;
    }
}

protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
{
    if (DropDownList1.SelectedItem.Text == "Roboto") ButtonGonder.Visible = false;
    else ButtonGonder.Visible = true;
}

protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
{
    if (CheckBoxList1.SelectedIndex != -1) h1Baslik.InnerText = CheckBoxList1.SelectedItem.Text;
}
    }
}