using Bacchus.ControllerDAO;
using System;
using System.Windows.Forms;

namespace Bacchus
{
    /// <summary>
    /// form famille view class.
    /// </summary>
    public partial class FormFamille : Form
    {
        public string NewName { get; set; }
        public string OldDescription { get; set; }
        public string ToAdd { get; set; }
        private int Status;

        /// <summary>
        /// default constructor of the class.
        /// initializes the text variables.
        /// </summary>
        public FormFamille()
        {
            ToAdd = "";
            InitializeComponent();

            this.Text = "Ajouter une nouvelle famille";
            label1.Text = "Ajouter une nouvelle famille";
            Status = 0;

        }


        /// <summary>
        /// comfort constructor of the class, taking a listviewitem in parameter. initializes the description of the famille.
        /// </summary>
        /// <param name="ListViewItem">ListViewItem to work with</param>
        public FormFamille(ListViewItem ListViewItem)
        {
            NewName = OldDescription = "";
            InitializeComponent();

            Text = "Modifier la famille";
            label1.Text = "Modifier la famille..";

            DescriptionTextFamille.Text = OldDescription = ListViewItem.SubItems[0].Text;
            Status = 1;
        }

        /// <summary>
        /// confirm button, allows to confirm the changes made in a famille object. you can either add a famille or modify one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmerButton_Click(object Sender, EventArgs Event)
        {
            if (!DescriptionTextFamille.Text.Equals("") && (DescriptionTextFamille.Text.Length < 100))
            {
                if (Status == 0)
                {
                    new DaoFamille().AddFamille(DescriptionTextFamille.Text);
                    ToAdd = DescriptionTextFamille.Text;
                    Close();
                }
                else if (Status == 1)
                {
                    new DaoFamille().ModifyFamille(OldDescription, DescriptionTextFamille.Text);
                    NewName = DescriptionTextFamille.Text;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Erreur : Entrée incorrect ou > 100 caractères.");
            }
        }
    }
}
