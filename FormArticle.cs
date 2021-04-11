using Bacchus.ControllerDAO;
using Bacchus.Model;
using System;
using System.Windows.Forms;

namespace Bacchus
{
    /// <summary>
    /// Form article view class.
    /// </summary>
    public partial class FormArticle : Form
    {
       public bool Chosen { get; set; }
        private int Status;

        /// <summary>
        /// comfort constructor taking a new node in parameter.
        /// </summary>
        /// <param name="TNode"></param>

        public FormArticle(TreeNode TNode)
        {
            Chosen = false;
            InitializeComponent();
            Text = "Ajout d'un nouvel Article";
            Status = 0;
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (SousFamille SousFamille in new DaoSousFamille().GetSousFamilles())
            {
                ComboBox1.Items.Add(SousFamille.Name);
            }
            if (TNode.Parent != null && TNode.Parent.Parent != null && TNode.Parent.Parent.Text.Equals("Familles")) ComboBox1.SelectedItem = TNode.Text;
            foreach (Marque Marque in new DaoMarque().GetMarques())
            {

                ComboBox2.Items.Add(Marque.Name);
            }
            if (TNode.Parent != null && TNode.Parent.Text.Equals("Marques")) ComboBox2.SelectedItem = TNode.Text;

        }
        /// <summary>
        /// comfort constructor of the class. Initializes the components and the textfields.
        /// </summary>
        /// <param name="ListViewItem"></param>
        public FormArticle(ListViewItem ListViewItem)
        {
            Chosen = false;
            InitializeComponent();
            Text = "Modification d'article";
            Status = 1;

            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            TextBox2.Text = ListViewItem.SubItems[0].Text;

            SousFamilles TmpListSsFamille = new DaoSousFamille().GetSousFamilles();

            //rempli les listes déroulables
            foreach (SousFamille SsFamille in TmpListSsFamille)
            {
                ComboBox1.Items.Add(SsFamille.Name);
            }

            ComboBox1.SelectedItem = ListViewItem.SubItems[2].Text;
            Marques TmpListMarque = new DaoMarque().GetMarques();

            foreach (Marque Marque in TmpListMarque)
            {
                ComboBox2.Items.Add(Marque.Name);
            }

            ComboBox2.SelectedItem = ListViewItem.SubItems[3].Text;

            TextBox3.Text = ListViewItem.SubItems[4].Text;
            TextBox1.Text = ListViewItem.SubItems[6].Text;
            TextBox1.Enabled = false;
            TextBox4.Text = ListViewItem.SubItems[5].Text;
        }

        /// <summary>
        /// event of the confirmation button of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmerButton_Click(object sender, EventArgs e)
        {
            if (!TextBox1.Text.Equals("") && !TextBox2.Text.Equals("") && !TextBox3.Text.Equals("") && !TextBox4.Text.Equals("") && !ComboBox1.SelectedItem.Equals("") && !ComboBox2.SelectedItem.Equals("") && Double.TryParse(TextBox3.Text, out double number))
            {
                if (Status == 0)
                {               
                    Chosen = true;
                    SousFamille TemporarySF = new SousFamille(ComboBox1.SelectedItem.ToString(), new Famille());
                    Marque TemporaryM = new Marque(ComboBox2.SelectedItem.ToString());
                    Article Article = new Article(TextBox1.Text, TextBox2.Text, TemporarySF, TemporaryM, Convert.ToDouble(TextBox3.Text), Convert.ToInt32(TextBox4.Text));
                    new DaoArticle().AddArticle(Article);
                    Close();
                }
                else if (Status == 1)
                {
                    Chosen = true;
                    SousFamille TemporarySF = new SousFamille(ComboBox1.SelectedItem.ToString(), new Famille());
                    Marque TemporaryM = new Marque(ComboBox2.SelectedItem.ToString());
                    Article Article = new Article(TextBox1.Text, TextBox2.Text, TemporarySF, TemporaryM, Convert.ToDouble(TextBox3.Text), Convert.ToInt32(TextBox4.Text));
                    new DaoArticle().ModifyArticle(Article);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Erreur dans l'un des champs");
            }
        }

       
    }
}
