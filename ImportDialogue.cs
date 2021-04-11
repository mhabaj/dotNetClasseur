using Bacchus.Controller;
using System;
using System.IO;
using System.Windows.Forms;

namespace Bacchus
{
    /// <summary>
    /// Import view Class
    /// </summary>
    public partial class ImportDialogue : Form
    {
        private FileManager ImportFileManager;

        /// <summary>
        /// Constructer
        /// </summary>
        public ImportDialogue()
        {
            ImportFileManager = new FileManager();
            InitializeComponent();
            Text = "Import Data";
            ProgressBar.Visible = false;

        }


        /// <summary>
        /// button allowing to import the csv file and to fill the textbox field with the name of the imported file
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void CsvSelectButton_Click(object Sender, EventArgs Event)
        {
            var FileToImportPath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileToImportPath = openFileDialog.FileName;
                    ImportFileManager.Filepath = FileToImportPath;
                }
            }
            textBox1.Text = Path.GetFileName(FileToImportPath);
        }

        /// <summary>
        /// Import by overriding old data
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OverrideButton_Click(object Sender, EventArgs Event)
        {
            ProgressBar.Visible = true;

            ImportFileManager.ImportCsvFile(true, ProgressBar);
            
        }

        /// <summary>
        /// Import by appending data
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void AppendButton_Click(object Sender, EventArgs Event)
        {
            ProgressBar.Visible = true;

            ImportFileManager.ImportCsvFile(false, ProgressBar);
        }
    }
}
