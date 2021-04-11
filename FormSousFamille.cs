using Bacchus.ControllerDAO;
using Bacchus.Model;
using System;
using System.Windows.Forms;

namespace Bacchus
{
    /// <summary>
    /// form SousFamille view class.
    /// </summary>
    public partial class FormSousFamille : Form
    {
        public string New { get; set; }
        public string OldDescription { get; set; }
        public string ToAdd { get; set; }
        private int Status;

        /// <summary>
        /// comfort constructor of the class, initialises the textfields and the components.
        /// </summary>
        /// <param name="FName"> Famille Name </param>
        public FormSousFamille(string FName)
        {
            ToAdd = "";
            InitializeComponent();
            Text = "Ajouter une nouvelle sousfamille";
            label3.Text = "Ajouter une nouvelle sousfamille..";
            Status = 0;

            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Famille Famille in new DaoFamille().GetFamilles())
            {
                ComboBox1.Items.Add(Famille.Name);
            }
            ComboBox1.SelectedItem = FName;
        }

        /// <summary>
        /// constructor that takes a listitemview and a string in parameter in order to update a SousFamille.
        /// </summary>
        /// <param name="ListViewItem"></param>
        /// <param name="FName"></param>
        public FormSousFamille(ListViewItem ListViewItem, string FName)
        {
            New = OldDescription = "";
            InitializeComponent();
            Text = "Modifier la sousfamille";
            label3.Text = "Modifier la sousfamille..";

            Status = 1;
            TextBox1.Text = OldDescription = ListViewItem.SubItems[0].Text;

            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


            foreach (Famille Famille in new DaoFamille().GetFamilles())
            {
                ComboBox1.Items.Add(Famille.Name);
            }
            ComboBox1.SelectedItem = FName;
        }
        /// <summary>
        /// button to confirm the action of either adding or modifing a SousFamille.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ConfirmerButton_Click_1(object Sender, EventArgs Event)
        {
            if (!TextBox1.Text.Equals("") && (TextBox1.Text.Length < 100))
            {
                if (Status == 0)
                {
                    new DaoSousFamille().AddSousFamille(new SousFamille(TextBox1.Text, new Famille(ComboBox1.SelectedItem.ToString())));
                    ToAdd = TextBox1.Text;
                    Close();
                }
                else if (Status == 1)
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
