using System;
using System.IO;
using System.Windows.Forms;
using static FreeTAKServer_Manager.LoggerClass;

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
            Logger.WriteLine(" *** Notes Form Show Success [NotesForm] *** ");
            try
            {
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
