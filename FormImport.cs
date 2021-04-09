using Bacchus.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class FormImport : Form
    {
        private ParseurCsv CsvParseur;
        public FormImport()
        {
            InitializeComponent();
            CsvParseur = new ParseurCsv();
        }


        /// <summary>
        /// button allowing to import the csv file and to fill the textbox field with the name of the imported file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    FilePath = openFileDialog.FileName;
                    CsvParseur.Filepath = FilePath;
                }
            }
            textBox1.Text = Path.GetFileName(FilePath);
        }

        /// <summary>
        /// Codage du bouton d'intégration par écrasement.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            CsvParseur.ImportCsvFile(true, ProgressBar);
            
        }

        /// <summary>
        /// Codage du bouton d'intégration par ajout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            CsvParseur.ImportCsvFile(false, ProgressBar);
        }
    }
}
