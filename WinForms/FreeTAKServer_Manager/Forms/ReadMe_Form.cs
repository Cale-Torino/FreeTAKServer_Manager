using System;
using System.IO;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    public partial class ReadMe_Form : Form
    {
        public ReadMe_Form()
        {
            InitializeComponent();
        }

        private void ReadMe_Form_Load(object sender, EventArgs e)
        {
            LoggerClass.WriteLine(" *** Notes Form Show Success [NotesForm] *** ");
            try
            {
                //Clear Richtextbox and add the content of ReadMe.txt
                ReadMeRichTextBox.Clear();
                using (var Stream = new StreamReader(@"TextFiles\ReadMe.txt"))
                {
                    ReadMeRichTextBox.Text = Stream.ReadToEnd();
                }

            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Read Me Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
