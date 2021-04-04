using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.ControllerDAO;

namespace Bacchus
{
    public partial class FormMarque : Form
    {
        public string New { get; set; }
        public string OldDescription { get; set; }
        public string ToAdd { get; set; }

        public FormMarque()
        {
            ToAdd = "";
            InitializeComponent();
            Text = "AJOUT";
        }

        public FormMarque(ListViewItem ListViewItem)
        {
            New = OldDescription = "";
            InitializeComponent();
            Text = "MODIFICATION";
            TextBox1.Text = OldDescription = ListViewItem.SubItems[0].Text;
        }

        private void ConfirmerButton_Click(object sender, EventArgs e)
        {
            if (!TextBox1.Text.Equals("") && (TextBox1.Text.Length < 100))
            {
                if (Text.Equals("AJOUT"))
                {
                    new DaoFamille().AddFamille(TextBox1.Text);
                    ToAdd = TextBox1.Text;
                    Close();
                }
                else if (Text.Equals("MODIFICATION"))
                {
                    new DaoFamille().ModifyFamille(OldDescription, TextBox1.Text);
                    New = TextBox1.Text;
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
