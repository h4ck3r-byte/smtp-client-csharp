using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Threading;

namespace email_sender_portable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string s = txtSender.Text + "@gmail.com";
            string r = txtReceiver.Text + "@gmail.com";

            lblSent.Text = "Transmitting...";
            lblSent.Visible = true;
           
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                MailMessage mail = new MailMessage();

                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(s, txtPassword.Text);
                smtp.EnableSsl = true;

                mail.From = new MailAddress(s);
                mail.To.Add(r);
                mail.Subject = txtSubject.Text;
                mail.Body = txtMessage.Text;


                if (chkCaseID.Checked)
                {
                    mail.Subject += "Case ID: " + rand().ToString();
                }

                smtp.Send(mail);

                lblSent.Text = "Transmitted...";

           










            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "OOps.. error encountered...");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int rand()
        {

            Random number = new Random();
            int n = number.Next();
            return n;
        }
    }
}
