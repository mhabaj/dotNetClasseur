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
    public partial class FormMain : Form
    {
        private GeneralViewController GeneralViewController;
        public FormMain()
        {
            InitializeComponent();
            GeneralViewController = new GeneralViewController(this.ListView1,this.treeView1, this.statusStrip1);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormImport = new FormImport();
            FormImport.ShowDialog();
        }

        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormExport = new FormExport();
            FormExport.ShowDialog();
        }

        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralViewController.Reload();
        }
    }
}
