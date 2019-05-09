using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToysEcommerce.BLL.Repositories;
using ToysEcommerce.BOL.Entities;

namespace ToysEcommerce.WebUI
{
    public partial class Products : System.Web.UI.Page
    {
        //Repository<Product> repoProduct = new Repository<Product>();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (IsPostBack == false)// if(!IsPostBack)
        //    {
        //        Yukle();
        //    }


        //}
        //void Yukle ()
        //{

        //        GridView1.DataSource = repoProduct.GetAll().OrderBy(o => o.Name).ToList();
        //        GridView1.DataBind();

        //}


        //protected void ButtonEkle_Click(object sender, EventArgs e)
        //{
        //    repoProduct.Add(new Product { Name = txtName.Text , Description = txtDescripton.Text, Stock = Convert.ToInt16(txtStock.Text), Price = Convert.ToDecimal(txtPrice.Text), Picture=txtPicture.Text , BrandID=Convert.ToInt16(txtBrandId.Text)});
        //    Yukle();
        //   txtName.Text = ""; txtDescripton.Text = ""; txtStock.Text = ""; txtPrice.Text = ""; txtPicture.Text = ""; txtBrandId.Text = "";
        //}


        //2.YOL

        Repository<Product> repoProduct = new Repository<Product>();
        Repository<Brand> repoBrand = new Repository<Brand>();
        Repository<Category> repoCategory = new Repository<Category>();
        Repository<ProductCategory> repoProductCategory = new Repository<ProductCategory>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Yukle();
            }
        }
        void Yukle()
        {
            if (Request.QueryString["MarkaID"] == null)
            {
                GridView1.DataSource = repoProduct.GetAll().AsEnumerable().OrderBy(o => o.Name).Select(s => new { s.ID, s.Name, s.Picture, s.Price, Marka = s.Brand.Name, StokBilgi = s.Stock <= 0 ? "TÜKENDİ" : s.Stock.ToString(), Kategorileri = string.Join(",", s.ProductCategory.Select(pc => pc.Category.Name)) }).ToList();

            }
            else
            {
                int BrandID = Convert.ToInt32(Request.QueryString["MarkaID"]);
                GridView1.DataSource = repoProduct.GetAll().AsEnumerable().OrderBy(o => o.Name).Where(w => w.BrandID == BrandID).Select(s => new { s.ID, s.Name, s.Picture, s.Price, Marka = s.Brand.Name, StokBilgi = s.Stock <= 0 ? "TÜKENDİ" : s.Stock.ToString(), Kategorileri = string.Join(",", s.ProductCategory.Select(pc => pc.Category.Name)) }).ToList();
                h1Baslik.InnerText = Request.QueryString["MarkaAd"].ToUpper() + " ÜRÜNLERİ";
            }
            GridView1.DataBind();
            DropDownListBrand.DataSource = repoBrand.GetAll().OrderBy(o => o.Name).ToList();
            DropDownListBrand.DataBind();

            CheckBoxListKategori.DataSource = repoCategory.GetAll().OrderBy(o => o.Name).ToList();
            CheckBoxListKategori.DataBind();
        }

        protected void ButtonEkle_Click(object sender, EventArgs e)
        {
            int sonID = 0;
            Product sonUrun = repoProduct.GetAll().OrderByDescending(o => o.ID).FirstOrDefault();
            if (sonUrun != null) sonID = sonUrun.ID;
            sonID++;

            if (Directory.Exists(Server.MapPath("contents")) == false) Directory.CreateDirectory(Server.MapPath("contents"));
            //Directory.Delete(Server.MapPath("contents")) Klasör Silme

            string dosya = "/contents/" + DosyaYoluOlustur(fileUploadDosya.Value, sonID.ToString());

            Product yeniUrun = new Product { Name = txtName.Text, Description = txtDescripton.Text, Stock = Convert.ToInt16(txtStock.Text), Price = Convert.ToDecimal(txtPrice.Text), Picture = dosya, BrandID = Convert.ToInt32(DropDownListBrand.SelectedValue) };


            fileUploadDosya.PostedFile.SaveAs(Server.MapPath(dosya));
            repoProduct.Add(yeniUrun);

            foreach (ListItem hbi in CheckBoxListKategori.Items)
            {
                if (hbi.Selected)
                {
                    int catID = Convert.ToInt32(hbi.Value);
                    repoProductCategory.Add(new ProductCategory { ProductID = yeniUrun.ID, CategoryID = catID });
                }
            }

            Response.Redirect("Products.aspx");
            //Yukle();

            //txtName.Text = ""; txtDescripton.Text = ""; txtStock.Text = ""; txtPrice.Text = ""; DropDownListBrand.SelectedIndex=-1;
            txtName.Text = DosyaYoluOlustur("ÇANAKKALE BOĞAZI.gif", "8");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Iletisim.aspx");
        }
        string DosyaYoluOlustur(string DosyaAdi, string UrunID)
        {
            string geri = DosyaAdi.ToLower().Replace(" ", "").Replace("ç", "c").Replace("ğ", "g").Replace("ş", "s").Replace("ı", "i").Replace("ö", "o").Replace("ü", "u");
            geri = Path.GetFileNameWithoutExtension(geri) + UrunID + Path.GetExtension(DosyaAdi);
            return geri;
        }

        protected void ButtonSil_Click(object sender, EventArgs e)
        {
            Button tiklayan = (Button)sender;
            LabelUrunID.Text = tiklayan.CommandArgument;
            int UrunID = Convert.ToInt32(LabelUrunID.Text);
            string dosya = repoProduct.GetBy(g => g.ID == UrunID).Picture;
            repoProduct.Remove(repoProduct.GetBy(g => g.ID == UrunID));//SQL silme işlemi
            if (File.Exists(Server.MapPath(dosya))) File.Delete(Server.MapPath(dosya));//Dosya Silme işlemi
            Yukle();


        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            LinkButton tiklayan = (LinkButton)sender;
            LabelUrunID.Text = tiklayan.CommandArgument;
            int UrunID = Convert.ToInt32(LabelUrunID.Text);
            Product arananUrun = repoProduct.GetBy(g => g.ID == UrunID);
            txtName.Text = arananUrun.Name;
            txtDescripton.Text = arananUrun.Description;
            txtPrice.Text = arananUrun.Price.ToString();
            txtStock.Text = arananUrun.Stock.ToString();
            DropDownListBrand.SelectedValue = arananUrun.BrandID.ToString();
            imgUrun.Src = arananUrun.Picture;

            CheckBoxListKategori.DataSource = repoCategory.GetAll().OrderBy(o => o.Name).ToList();
            CheckBoxListKategori.DataBind();

            foreach (ListItem hbi in CheckBoxListKategori.Items)
            {
                int hbiID = Convert.ToInt32(hbi.Value);
                if (arananUrun.ProductCategory.Select(s => s.CategoryID).Contains(hbiID)) hbi.Selected = true;
            }

        }

        protected void ButtonGuncelle_Click(object sender, EventArgs e)
        {
            int UrunID = Convert.ToInt32(LabelUrunID.Text);
            Product arananUrun = repoProduct.GetBy(g => g.ID == UrunID);
            arananUrun.Name = txtName.Text;
            arananUrun.Price = Convert.ToDecimal(txtPrice.Text);

            if (fileUploadDosya.Value != null)
            {
                if (Directory.Exists(Server.MapPath("contents")) == false) Directory.CreateDirectory(Server.MapPath("contents"));
                string dosya = "/contents/" + DosyaYoluOlustur(fileUploadDosya.Value, UrunID.ToString());
                arananUrun.Picture = dosya;
                fileUploadDosya.PostedFile.SaveAs(Server.MapPath(dosya));
            }
            repoProduct.Update(arananUrun);

            ICollection<ProductCategory> silinecekler = repoProductCategory.GetAll().Where(w => w.ProductID == arananUrun.ID).ToList();
            repoProductCategory.RemoveRange(silinecekler);


            foreach (ListItem hbi in CheckBoxListKategori.Items)
            {
                if (hbi.Selected)
                {   
                    int catID = Convert.ToInt32(hbi.Value);
                    repoProductCategory.Add(new ProductCategory { ProductID = arananUrun.ID, CategoryID = catID });
                }
            }
             
            Yukle();
        }
    }
}