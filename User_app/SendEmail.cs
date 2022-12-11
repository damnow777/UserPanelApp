using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_app
{
    public partial class SendEmail : Form
    {
        public SendEmail()
        {
            InitializeComponent();
           
        }

        public void sendEmail()
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from.Text);
                message.Subject = subject.Text;
                message.Body = body.Text;
                message.To.Add(to.Text);
               

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential(from.Text, password.Text);
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 465;
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
                MessageBox.Show("Email został wysłany");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendEmail();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelUzytkownika panel = new PanelUzytkownika();
            this.Close();
            panel.Show();
        }

       
    }

    
}
