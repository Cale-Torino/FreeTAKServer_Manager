using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    /// <summary>
    /// Interaction logic for EmailSetupWindow.xaml
    /// </summary>
    public partial class EmailSetupWindow : Window
    {
        public EmailSetupWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Set textboxes to IsEnabled = false
            Smtp_TextBox.IsEnabled = false;
            From_TextBox.IsEnabled = false;
            To_TextBox.IsEnabled = false;
            Subject_TextBox.IsEnabled = false;
            Body_TextBox.IsEnabled = false;
            Username_TextBox.IsEnabled = false;
            Password_TextBox.IsEnabled = false;
            if (Properties.Settings.Default.emailPass != string.Empty)
            {
                //Decrypt email password stored in config file
                SecureString password = EncryptionClass.DecryptString(Properties.Settings.Default.emailPass);
                Password_TextBox.Text = EncryptionClass.ToInsecureString(password);
            }
            //Write saved propertie vars to textboxes
            Smtp_TextBox.Text = Properties.Settings.Default.emailSmtp;
            From_TextBox.Text = Properties.Settings.Default.emailFrom;
            To_TextBox.Text = Properties.Settings.Default.emailTo;
            Subject_TextBox.Text = Properties.Settings.Default.emailSubject;
            Body_TextBox.Text = Properties.Settings.Default.emailBody;
            Username_TextBox.Text = Properties.Settings.Default.emailUsername;
        }
        private void SendEmail()
        {
            try
            {
                MailMessage Mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Smtp_TextBox.Text);

                Mail.From = new MailAddress(From_TextBox.Text);//From address
                Mail.To.Add(To_TextBox.Text);//To address
                Mail.Subject = Subject_TextBox.Text;//Subject
                Mail.Body = Body_TextBox.Text;//Body of email

                SmtpServer.Port = 587;//SMTP port
                SmtpServer.Credentials = new NetworkCredential(Username_TextBox.Text, Password_TextBox.Text);//Credentials, password and username
                SmtpServer.EnableSsl = true;//SSL

                SmtpServer.Send(Mail);
                MessageBox.Show("Normal mail Sent", "Mail Status", MessageBoxButton.OK, MessageBoxImage.Information);
                LoggerClass.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Email could not be tested", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [EmailSetup_Form] ***");
            }
        }
        private void Test_button_click(object sender, RoutedEventArgs e)
        {
            //Calls SendEmail() function
            SendEmail();
        }
        private bool clickedOnce = true;//global var
        private void Savesettings_button_click(object sender, RoutedEventArgs e)
        {
            if (clickedOnce == true)
            {
                try
                {
                    //Set textboxes to IsEnabled = true
                    clickedOnce = false;
                    Smtp_TextBox.IsEnabled = true;
                    From_TextBox.IsEnabled = true;
                    To_TextBox.IsEnabled = true;
                    Subject_TextBox.IsEnabled = true;
                    Body_TextBox.IsEnabled = true;
                    Username_TextBox.IsEnabled = true;
                    Password_TextBox.IsEnabled = true;
                    Savesettings_Button.Content = "Save Settings";//Change button text
                    LoggerClass.WriteLine(" *** Editing email settings [EmailSetup_Form] ***");
                }
                catch (Exception Exception)
                {
                    //Set textboxes to IsEnabled = false
                    clickedOnce = true;
                    Smtp_TextBox.IsEnabled = false;
                    From_TextBox.IsEnabled = false;
                    To_TextBox.IsEnabled = false;
                    Subject_TextBox.IsEnabled = false;
                    Body_TextBox.IsEnabled = false;
                    Username_TextBox.IsEnabled = false;
                    Password_TextBox.IsEnabled = false;
                    MessageBox.Show(Exception.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [EmailSetup_Form] ***");
                    Savesettings_Button.Content = "Edit Settings";//Change button text
                    return;
                }
            }
            else
            {
                clickedOnce = true;
                //Encrypt password for storage
                Properties.Settings.Default.emailPass = EncryptionClass.EncryptString(EncryptionClass.ToSecureString(Password_TextBox.Text));
                //Set property vars and save them to config file
                Properties.Settings.Default.emailSmtp = Smtp_TextBox.Text;
                Properties.Settings.Default.emailFrom = From_TextBox.Text;
                Properties.Settings.Default.emailTo = To_TextBox.Text;
                Properties.Settings.Default.emailSubject = Subject_TextBox.Text;
                Properties.Settings.Default.emailBody = Body_TextBox.Text;
                Properties.Settings.Default.emailUsername = Username_TextBox.Text;
                Properties.Settings.Default.Save();//Set properties
                //Set textboxes to IsEnabled = false
                Smtp_TextBox.IsEnabled = false;
                From_TextBox.IsEnabled = false;
                To_TextBox.IsEnabled = false;
                Subject_TextBox.IsEnabled = false;
                Body_TextBox.IsEnabled = false;
                Username_TextBox.IsEnabled = false;
                Password_TextBox.IsEnabled = false;
                Savesettings_Button.Content = "Edit Settings";//Change button text
                LoggerClass.WriteLine(" *** Saved email settings [EmailSetup_Form] ***");
            }
        }
    }
}
