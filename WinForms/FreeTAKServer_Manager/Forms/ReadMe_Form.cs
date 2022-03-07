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
                ReadMe_richTextBox.Clear();
                ReadMe_richTextBox.Text = File.ReadAllText("ReadMe.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Read Me Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
