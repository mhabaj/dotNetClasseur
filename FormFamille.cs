using Bacchus.ControllerDAO;
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
    public partial class FormFamille : Form
    {
        public string New { get; set; }
        public string OldDescription { get; set; }
        public string ToAdd { get; set; }
        public FormFamille()
        {
            ToAdd = "";
            InitializeComponent();
            Text = "AJOUT";
        }

        public FormFamille(ListViewItem ListViewItem)
        {
            New = OldDescription = "";
            InitializeComponent();
            Text = "MODIFICATION";
            DescriptionTextFamille.Text = OldDescription = ListViewItem.SubItems[0].Text;
        }

        private void ConfirmerButton_Click(object sender, EventArgs e)
        {
            if (!DescriptionTextFamille.Text.Equals("") && (DescriptionTextFamille.Text.Length < 100))
            {
                if (Text.Equals("AJOUT"))
                {
                    new DaoFamille().AddFamille(DescriptionTextFamille.Text);
                    ToAdd = DescriptionTextFamille.Text;
                    Close();
                }
                else if (Text.Equals("MODIFICATION"))
                {
                    new DaoFamille().ModifyFamille(OldDescription, DescriptionTextFamille.Text);
                    New = DescriptionTextFamille.Text;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Erreur : champs vide ou > 100 caractères.");
            }
        }
    }
}
