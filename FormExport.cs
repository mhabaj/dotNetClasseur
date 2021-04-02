using Bacchus.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class FormExport : Form
    {
        private ParseurCsv CsvParseur;
        public FormExport()
        {
            InitializeComponent();
            CsvParseur = new ParseurCsv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CsvParseur.ExportCsvFile(textBox1.Text);
        }
    }
}
