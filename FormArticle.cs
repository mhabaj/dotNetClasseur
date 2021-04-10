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
using Bacchus.Model;

namespace Bacchus
{
    public partial class FormArticle : Form
    {
       public bool Mark { get; set; }
        public FormArticle(ListViewItem ListViewItem)
        {
            Mark = false;
            InitializeComponent();
            Text = "MODIFICATION";
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            TextBox2.Text = ListViewItem.SubItems[0].Text;
            SousFamilles TmpListSsFamille = new DaoSousFamille().GetSousFamilles();
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

        private void ConfirmerButton_Click(object sender, EventArgs e)
        {
            if (!TextBox1.Text.Equals("") && !TextBox2.Text.Equals("") && !TextBox3.Text.Equals("") && !TextBox4.Text.Equals("") && !ComboBox1.SelectedItem.Equals("") && !ComboBox2.SelectedItem.Equals("") && Double.TryParse(TextBox3.Text, out double number))
            {
                if (Text.Equals("AJOUT"))
                {               
                    Mark = true;
                    SousFamille TemporarySF = new SousFamille(ComboBox1.SelectedItem.ToString(), new Famille());
                    Marque TemporaryM = new Marque(ComboBox2.SelectedItem.ToString());
                    Article Article = new Article(TextBox1.Text, TextBox2.Text, TemporarySF, TemporaryM, Convert.ToDouble(TextBox3.Text), Convert.ToInt32(TextBox4.Text));
                    new DaoArticle().AddArticle(Article);
                    Close();
                }
                else if (Text.Equals("MODIFICATION"))
                {
                    Mark = true;
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

        public FormArticle(TreeNode TNode)
        {
            Mark = false;
            InitializeComponent();
            Text = "AJOUT";
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
    }
}
