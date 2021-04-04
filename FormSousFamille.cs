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
using Bacchus.Model;

namespace Bacchus
{
    public partial class FormSousFamille : Form
    {
        public string New { get; set; }
        public string OldDescription { get; set; }
        public string ToAdd { get; set; }

        public FormSousFamille(string FName)
        {
            ToAdd = "";
            InitializeComponent();
            Text = "AJOUT";

            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Famille Famille in new DaoFamille().ListAllFamilles())
            {
                ComboBox1.Items.Add(Famille.Name);
            }
            ComboBox1.SelectedItem = FName;
        }

        public FormSousFamille(ListViewItem ListViewItem, string FName)
        {
            New = OldDescription = "";
            InitializeComponent();
            Text = "MODIFICATION";
            TextBox1.Text = OldDescription = ListViewItem.SubItems[0].Text;

            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


            foreach (Famille Famille in new DaoFamille().ListAllFamilles())
            {
                ComboBox1.Items.Add(Famille.Name);
            }
            ComboBox1.SelectedItem = FName;
        }

        private void ConfirmerButton_Click_1(object sender, EventArgs e)
        {
            if (!TextBox1.Text.Equals("") && (TextBox1.Text.Length < 100))
            {
                if (Text.Equals("AJOUT"))
                {
                    new DaoSousFamille().AddSousFamille(new SousFamille(TextBox1.Text, new Famille(ComboBox1.SelectedItem.ToString())));
                    ToAdd = TextBox1.Text;
                    Close();
                }
                else if (Text.Equals("MODIFICATION"))
                {
                    new DaoSousFamille().ModifySousFamille(OldDescription, TextBox1.Text, new Famille(ComboBox1.SelectedItem.ToString()));
                    New = TextBox1.Text;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Erreur : champ invalide ou > 100 caractères");
            }
        }
    }
}
