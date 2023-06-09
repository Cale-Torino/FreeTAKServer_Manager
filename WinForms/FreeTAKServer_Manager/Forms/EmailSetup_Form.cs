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
            SMTPTextBox.Enabled = false;
            FromTextBox.Enabled = false;
            ToTextBox.Enabled = false;
            SubjectTextBox.Enabled = false;
            BodyTextBox.Enabled = false;
            UsernameTextBox.Enabled = false;
            PasswordTextBox.Enabled = false;
            if (Properties.Settings.Default.EmailPass != string.Empty)
            {
                ////Decrypt email password stored in config file
                SecureString Password = EncryptionClass.DecryptString(Properties.Settings.Default.EmailPass);
                PasswordTextBox.Text = EncryptionClass.ToInsecureString(Password);
            }
            //Write saved propertie vars to textboxes
            SMTPTextBox.Text = Properties.Settings.Default.EmailSmtp;
            FromTextBox.Text = Properties.Settings.Default.EmailFrom;
            ToTextBox.Text = Properties.Settings.Default.EmailTo;
            SubjectTextBox.Text = Properties.Settings.Default.EmailSubject;
            BodyTextBox.Text = Properties.Settings.Default.EmailBody;
            UsernameTextBox.Text = Properties.Settings.Default.EmailUsername;
        }

        private void SendEmail()
        {
            try
            {
                    MailMessage Mail = new MailMessage();
                    SmtpClient SMTPServer = new SmtpClient(SMTPTextBox.Text);

                    Mail.From = new MailAddress(FromTextBox.Text);//From address
                    Mail.To.Add(ToTextBox.Text);//To address
                    Mail.Subject = SubjectTextBox.Text;//Subject
                    Mail.Body = BodyTextBox.Text;//Body of email

                    SMTPServer.Port = 587;//SMTP port
                    SMTPServer.Credentials = new NetworkCredential(UsernameTextBox.Text, PasswordTextBox.Text);//Credentials, password and username
                    SMTPServer.EnableSsl = true;//SSL

                    SMTPServer.Send(Mail);
                    MessageBox.Show("Normal mail Sent", "Mail Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoggerClass.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Email could not be tested", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [EmailSetup_Form] ***");
            }
        }

        private void Test_button_Click(object sender, EventArgs e)
        {
            //Calls SendEmail() function
            SendEmail();
        }

        private void Savesettings_button_Click(object sender, EventArgs e)
        {
            if (SaveSettingsButton.Text == "Edit Settings")
            {
                try
                {
                    SMTPTextBox.Enabled = true;
                    FromTextBox.Enabled = true;
                    ToTextBox.Enabled = true;
                    SubjectTextBox.Enabled = true;
                    BodyTextBox.Enabled = true;
                    UsernameTextBox.Enabled = true;
                    PasswordTextBox.Enabled = true;
                    SaveSettingsButton.Text = "Save Settings";//Change button text
                    LoggerClass.WriteLine(" *** Editing email settings [EmailSetup_Form] ***");
                }
                catch (Exception Exception)
                {
                    SMTPTextBox.Enabled = false;
                    FromTextBox.Enabled = false;
                    ToTextBox.Enabled = false;
                    SubjectTextBox.Enabled = false;
                    BodyTextBox.Enabled = false;
                    UsernameTextBox.Enabled = false;
                    PasswordTextBox.Enabled = false;
                    MessageBox.Show(Exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [EmailSetup_Form] ***");
                    SaveSettingsButton.Text = "Edit Settings";//Change button text
                    return;
                }
            }
            else
            {
                //Encrypt password for storage
                Properties.Settings.Default.EmailPass = EncryptionClass.EncryptString(EncryptionClass.ToSecureString(PasswordTextBox.Text));
                //Set property vars and save them to config file
                Properties.Settings.Default.EmailSmtp = SMTPTextBox.Text;
                Properties.Settings.Default.EmailFrom = FromTextBox.Text;
                Properties.Settings.Default.EmailTo = ToTextBox.Text;
                Properties.Settings.Default.EmailSubject = SubjectTextBox.Text;
                Properties.Settings.Default.EmailBody = BodyTextBox.Text;
                Properties.Settings.Default.EmailUsername = UsernameTextBox.Text;
                Properties.Settings.Default.Save();//Set properties
                //Set textboxes to IsEnabled = false
                SMTPTextBox.Enabled = false;
                FromTextBox.Enabled = false;
                ToTextBox.Enabled = false;
                SubjectTextBox.Enabled = false;
                BodyTextBox.Enabled = false;
                UsernameTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                SaveSettingsButton.Text = "Edit Settings";//Change button text
                LoggerClass.WriteLine(" *** Saved email settings [EmailSetup_Form] ***");
            }
        }
    }
}
