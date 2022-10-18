using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
//using OpenPop.Pop3;


namespace Mail_Sistemi
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string DosyaYolu;

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("demir44_cilak97@hotmail.com", "burcubaris4497");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesaj.To.Add(textBox1.Text);
            mesaj.From = new MailAddress("demir44_cilak97@hotmail.com");
            mesaj.Subject = textBox2.Text;
            mesaj.Body = textBox3.Text;
            if (DosyaYolu != null)
            {
                mesaj.Attachments.Add(new Attachment(DosyaYolu));
            }
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
            }

            istemci.Send(mesaj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Title = "İçerik";
            dosya.ShowDialog();
            DosyaYolu = dosya.FileName;           
            label3.Text = "Dosya Eklendi";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
//201913709097 Barış ÇİLAK
//201913709044 Ekim Burcu DEMİR