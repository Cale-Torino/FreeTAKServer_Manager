using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Windows.Forms;

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
            //Set textboxes to IsEnabled = false
            Smtp_textBox.Enabled = false;
            From_textBox.Enabled = false;
            To_textBox.Enabled = false;
            Subject_textBox.Enabled = false;
            Body_textBox.Enabled = false;
            Username_textBox.Enabled = false;
            Password_textBox.Enabled = false;
            if (Properties.Settings.Default.emailPass != string.Empty)
            {
                ////Decrypt email password stored in config file
                SecureString password = EncryptionClass.DecryptString(Properties.Settings.Default.emailPass);
                Password_textBox.Text = EncryptionClass.ToInsecureString(password);
            }
            //Write saved propertie vars to textboxes
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

                    mail.From = new MailAddress(From_textBox.Text);//From address
                    mail.To.Add(To_textBox.Text);//To address
                    mail.Subject = Subject_textBox.Text;//Subject
                    mail.Body = Body_textBox.Text;//Body of email

                    SmtpServer.Port = 587;//SMTP port
                    SmtpServer.Credentials = new NetworkCredential(Username_textBox.Text, Password_textBox.Text);//Credentials, password and username
                    SmtpServer.EnableSsl = true;//SSL

                    SmtpServer.Send(mail);
                    MessageBox.Show("Normal mail Sent", "Mail Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoggerClass.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Email could not be tested", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [EmailSetup_Form] ***");
            }
        }

        private void Test_button_Click(object sender, EventArgs e)
        {
            //Calls SendEmail() function
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
                    Savesettings_button.Text = "Save Settings";//Change button text
                    LoggerClass.WriteLine(" *** Editing email settings [EmailSetup_Form] ***");
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
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [EmailSetup_Form] ***");
                    Savesettings_button.Text = "Edit Settings";//Change button text
                    return;
                }
            }
            else
            {
                //Encrypt password for storage
                Properties.Settings.Default.emailPass = EncryptionClass.EncryptString(EncryptionClass.ToSecureString(Password_textBox.Text));
                //Set property vars and save them to config file
                Properties.Settings.Default.emailSmtp = Smtp_textBox.Text;
                Properties.Settings.Default.emailFrom = From_textBox.Text;
                Properties.Settings.Default.emailTo = To_textBox.Text;
                Properties.Settings.Default.emailSubject = Subject_textBox.Text;
                Properties.Settings.Default.emailBody = Body_textBox.Text;
                Properties.Settings.Default.emailUsername = Username_textBox.Text;
                Properties.Settings.Default.Save();//Set properties
                //Set textboxes to IsEnabled = false
                Smtp_textBox.Enabled = false;
                From_textBox.Enabled = false;
                To_textBox.Enabled = false;
                Subject_textBox.Enabled = false;
                Body_textBox.Enabled = false;
                Username_textBox.Enabled = false;
                Password_textBox.Enabled = false;
                Savesettings_button.Text = "Edit Settings";//Change button text
                LoggerClass.WriteLine(" *** Saved email settings [EmailSetup_Form] ***");
            }
        }
    }
}
