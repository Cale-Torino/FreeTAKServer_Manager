using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static FreeTAKServer_Manager_WPF.LoggerClass;

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
            Smtp_textBox.IsEnabled = false;
            From_textBox.IsEnabled = false;
            To_textBox.IsEnabled = false;
            Subject_textBox.IsEnabled = false;
            Body_textBox.IsEnabled = false;
            Username_textBox.IsEnabled = false;
            Password_textBox.IsEnabled = false;
            if (Properties.Settings.Default.emailPass != string.Empty)
            {
                //Decrypt email password stored in config file
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
                MessageBox.Show("Normal mail Sent", "Mail Status", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Email could not be tested", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [EmailSetup_Form] ***");
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
                    Smtp_textBox.IsEnabled = true;
                    From_textBox.IsEnabled = true;
                    To_textBox.IsEnabled = true;
                    Subject_textBox.IsEnabled = true;
                    Body_textBox.IsEnabled = true;
                    Username_textBox.IsEnabled = true;
                    Password_textBox.IsEnabled = true;
                    Savesettings_button.Content = "Save Settings";//Change button text
                    Logger.WriteLine(" *** Editing email settings [EmailSetup_Form] ***");
                }
                catch (Exception ex)
                {
                    //Set textboxes to IsEnabled = false
                    clickedOnce = true;
                    Smtp_textBox.IsEnabled = false;
                    From_textBox.IsEnabled = false;
                    To_textBox.IsEnabled = false;
                    Subject_textBox.IsEnabled = false;
                    Body_textBox.IsEnabled = false;
                    Username_textBox.IsEnabled = false;
                    Password_textBox.IsEnabled = false;
                    MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [EmailSetup_Form] ***");
                    Savesettings_button.Content = "Edit Settings";//Change button text
                    return;
                }
            }
            else
            {
                clickedOnce = true;
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
                Smtp_textBox.IsEnabled = false;
                From_textBox.IsEnabled = false;
                To_textBox.IsEnabled = false;
                Subject_textBox.IsEnabled = false;
                Body_textBox.IsEnabled = false;
                Username_textBox.IsEnabled = false;
                Password_textBox.IsEnabled = false;
                Savesettings_button.Content = "Edit Settings";//Change button text
                Logger.WriteLine(" *** Saved email settings [EmailSetup_Form] ***");
            }
        }
    }
}
