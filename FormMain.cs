using Bacchus.Controller;
using System;
using System.Windows.Forms;

namespace Bacchus
{
    /// <summary>
    /// form main view class.
    /// </summary>
    public partial class FormMain : Form
    {
        private MainViewController MvController { get; set; }

        /// <summary>
        /// default constructor of the class that initialises the listview, the treeview and the statusStrip.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            MvController = new MainViewController(this.ListView1,this.treeView1, this.statusStrip1);
        }

        /// <summary>
        /// launch the import form from the toolstrip menu
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ImporterToolStripMenuItem_Click(object Sender, EventArgs Event)
        {
            Form ImportDialogue = new ImportDialogue();
            ImportDialogue.ShowDialog();
            MvController.Reload();
        }

        /// <summary>
        /// launch the export form from the toolstrip menu
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ExporterToolStripMenuItem_Click(object Sender, EventArgs Event)
        {
            Form ExportDialogue = new ExportDialogue();
            ExportDialogue.ShowDialog();
        }


        /// <summary>
        /// refresh function of the toolstrip menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActualiserToolStripMenuItem_Click(object Sender, EventArgs Event)
        {
            MvController.Reload();
        }
    }
}
