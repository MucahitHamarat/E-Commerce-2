using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToysEcommerce.BLL.Repositories;
using ToysEcommerce.BOL.Entities;

namespace ToysEcommerce.WebUI
{
    public partial class Iletisim : System.Web.UI.Page
    {
        Repository<Contact> repoContact = new Repository<Contact>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonGonder_Click(object sender, EventArgs e)
        {
            //Subject = selectKonu.Value;
            //root yolu=Server.MapPath()
            fileUploadDosya.PostedFile.SaveAs(Server.MapPath("/contents/"+fileUploadDosya.Value));
            repoContact.Add(new Contact {
                Subject = DropDownListKonu.SelectedValue,
                NameSurname = textAdSoyad.Value,
                MailAddress = textMail.Value,
                OrderNo = textSiparisNo.Value,
                Messagge = textMesaj.Value,
                FilePath = "/contents/" + fileUploadDosya.Value
            });
            MailGonder();
            ScriptManager.RegisterStartupScript(this.Page,this.GetType(), "key_kaydedildi", "<script>alert('Mesajınız başarıyla iletildi')</script>", false);
        }
        void MailGonder()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("test@biltekno.com");
                mail.To.Add(new MailAddress("umran.cakal1@gmail.com"));
                mail.To.Add(new MailAddress("mucahithamarat@gmail.com"));
                mail.Subject = DropDownListKonu.SelectedValue;
                sb.Append("Aşağıda bilgileri bulunan bir ziyaretçinizden mesaj aldınız.<br/>");
                sb.Append("Adı Soyadı: "+textAdSoyad.Value+ "<br/>");
                sb.Append("Mail Adresi: "+textMail.Value + "<br/>");
                sb.Append("Sipariş Numarası: "+textSiparisNo.Value + "<br/>");
                sb.Append("Mesajı: "+textMesaj.Value);
                mail.Body = sb.ToString();
                mail.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("mail.biltekno.com", 587);
                //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //smtpClient.EnableSsl=true GMAIL için
                smtpClient.Credentials = new NetworkCredential("test@biltekno.com", "şifreeeeeeee");
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key_mailGonderilemedi", "<script>alert('Mesajınız mail olarak gönderilemedi, Hata:"+ex.Message+"')</script>", false);
            }
        }
    }
}