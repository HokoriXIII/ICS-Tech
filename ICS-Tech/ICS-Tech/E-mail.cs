using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace ICS_Tech
{
    public partial class E_mail : Form
    {
        public E_mail(string mail, string fio, string letter)
        {
            InitializeComponent();
            Email.Text = mail;
            Mesage.Text = fio + "\n\n\n Вы писали: \n\n" + letter;
        }

        private void Sent_Click(object sender, EventArgs e)
        {
            string from = "icsmanagers@ics-tech.kiev.ua";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(Email.Text));
                mail.Subject = Tema.Text;
                mail.Body = Mesage.Text;
                if (!string.IsNullOrEmpty(FileName.Text))
                    mail.Attachments.Add(new Attachment(FileName.Text));
                SmtpClient client = new SmtpClient();
                client.Host = "10.120.0.254";
                client.Port = 25;
                client.EnableSsl = false;
                client.Credentials = new NetworkCredential(from.Split('@')[0], "icsmanagers");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
                MessageBox.Show("Сообщение отправлено");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail.Send: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName.Text = openFileDialog1.FileName;
                //textBox2.Text = "hiddencont\\" + openFileDialog1.SafeFileName;
                //textBox5.Text = openFileDialog1.SafeFileName;
            }
        }





        /*using System;
using System.Net;
using System.Net.Mail;
/// <summary>
/// Отправка письма на почтовый ящик C# mail send
/// </summary>
/// <param name="smtpServer">Имя SMTP-сервера</param>
/// <param name="from">Адрес отправителя</param>
/// <param name="password">пароль к почтовому ящику отправителя</param>
/// <param name="mailto">Адрес получателя</param>
/// <param name="caption">Тема письма</param>
/// <param name="message">Сообщение</param>
/// <param name="attachFile">Присоединенный файл</param>
public static void SendMail(string smtpServer, string from , string password,
string mailto, string caption, string message, string attachFile = null)
{
try
{
MailMessage mail = new MailMessage();
mail.From = new MailAddress(from);
mail.To.Add(new MailAddress(mailto));
mail.Subject = caption;
mail.Body = message;
if (!string.IsNullOrEmpty(attachFile))
mail.Attachments.Add(new Attachment(attachFile));
SmtpClient client = new SmtpClient();
client.Host = smtpServer;
client.Port = 587;
client.EnableSsl = true;
client.Credentials = new NetworkCredential(from.Split('@')[0], password);
client.DeliveryMethod = SmtpDeliveryMethod.Network;
client.Send(mail);
mail.Dispose();
}
catch (Exception e)
{
throw new Exception("Mail.Send: " + e.Message);
}
}*/
    }
}
