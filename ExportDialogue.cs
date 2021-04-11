using Bacchus.Controller;
using System;
using System.Windows.Forms;

namespace Bacchus
{

    /// <summary>
    /// form export view class.
    /// </summary>
    public partial class ExportDialogue : Form
    {
        private FileManager CsvParseur;


        /// <summary>
        /// default constructor of the class.
        /// </summary>
        public ExportDialogue()
        {
            InitializeComponent();
            CsvParseur = new FileManager();
        }
        /// <summary>
        /// button triggering the method to export the data of the app into a csv file.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ExportButtonClick(object Sender, EventArgs Event)
        {
            CsvParseur.ExportCsvFile(textBox1.Text);
        }
    }
}
