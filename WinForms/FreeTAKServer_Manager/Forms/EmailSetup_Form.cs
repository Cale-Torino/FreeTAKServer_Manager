using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Windows.Forms;
using static FreeTAKServer_Manager.LoggerClass;

namespace FreeTAKServer_Manager
{
    public partial class EmailSetup_Form : Form
    {
        public EmailSetup_Form()
        {
            InitializeComponent();
        }

        private void EmailSetup_Form_Load(object sender, EventArgs e)
        {
            Smtp_textBox.Enabled = false;
            From_textBox.Enabled = false;
            To_textBox.Enabled = false;
            Subject_textBox.Enabled = false;
            Body_textBox.Enabled = false;
            Username_textBox.Enabled = false;
            Password_textBox.Enabled = false;
            if (Properties.Settings.Default.emailPass != string.Empty)
            {
                //Decrypt
                SecureString password = EncryptionClass.DecryptString(Properties.Settings.Default.emailPass);
                Password_textBox.Text = EncryptionClass.ToInsecureString(password);
            }
            Smtp_textBox.Text = Properties.Settings.Default.emailSmtp;
            From_textBox.Text = Properties.Settings.Default.emailFrom;
            To_textBox.Text = Properties.Settings.Default.emailTo;
            Subject_textBox.Text = Properties.Settings.Default.emailSubject;
            Body_textBox.Text = Properties.Settings.Default.emailBody;
            Username_textBox.Text = Properties.Settings.Default.emailUsername;
        }

        private void SendEmail()
        {
            try
            {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(Smtp_textBox.Text);

                    mail.From = new MailAddress(From_textBox.Text);
                    mail.To.Add(To_textBox.Text);
                    mail.Subject = Subject_textBox.Text;
                    mail.Body = Body_textBox.Text;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new NetworkCredential(Username_textBox.Text, Password_textBox.Text);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Normal mail Sent", "Mail Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Email could not be tested", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [EmailSetup_Form] ***");
            }
        }

        private void Test_button_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void Savesettings_button_Click(object sender, EventArgs e)
        {
            if (Savesettings_button.Text == "Edit Settings")
            {
                try
                {
                    Smtp_textBox.Enabled = true;
                    From_textBox.Enabled = true;
                    To_textBox.Enabled = true;
                    Subject_textBox.Enabled = true;
                    Body_textBox.Enabled = true;
                    Username_textBox.Enabled = true;
                    Password_textBox.Enabled = true;
                    Savesettings_button.Text = "Save Settings";
                    Logger.WriteLine(" *** Editing email settings [EmailSetup_Form] ***");
                }
                catch (Exception ex)
                {
                    Smtp_textBox.Enabled = false;
                    From_textBox.Enabled = false;
                    To_textBox.Enabled = false;
                    Subject_textBox.Enabled = false;
                    Body_textBox.Enabled = false;
                    Username_textBox.Enabled = false;
                    Password_textBox.Enabled = false;
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [EmailSetup_Form] ***");
                    Savesettings_button.Text = "Edit Settings";
                    return;
                }
            }
            else
            {
                //Encrypt
                Properties.Settings.Default.emailPass = EncryptionClass.EncryptString(EncryptionClass.ToSecureString(Password_textBox.Text));
                Properties.Settings.Default.emailSmtp = Smtp_textBox.Text;
                Properties.Settings.Default.emailFrom = From_textBox.Text;
                Properties.Settings.Default.emailTo = To_textBox.Text;
                Properties.Settings.Default.emailSubject = Subject_textBox.Text;
                Properties.Settings.Default.emailBody = Body_textBox.Text;
                Properties.Settings.Default.emailUsername = Username_textBox.Text;
                Properties.Settings.Default.Save();
                Smtp_textBox.Enabled = false;
                From_textBox.Enabled = false;
                To_textBox.Enabled = false;
                Subject_textBox.Enabled = false;
                Body_textBox.Enabled = false;
                Username_textBox.Enabled = false;
                Password_textBox.Enabled = false;
                Savesettings_button.Text = "Edit Settings";
                Logger.WriteLine(" *** Saved email settings [EmailSetup_Form] ***");
            }
        }
    }
}
