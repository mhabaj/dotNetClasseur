using Bacchus.ControllerDAO;
using System;
using System.Windows.Forms;

namespace Bacchus
{
    /// <summary>
    /// form marque view class.
    /// </summary>
    public partial class FormMarque : Form
    {
        public string New { get; set; }
        public string OldDescription { get; set; }
        public string ToAdd { get; set; }
        private int Status;

        /// <summary>
        /// default constructor of the class that initialises the textfields and the components.
        /// </summary>
        public FormMarque()
        {
            ToAdd = "";
            InitializeComponent();
            this.Text = "Ajouter une nouvelle Marque";
            Status = 0;
            label1.Text = "Ajouter la nouvelle Marque..";
        }
        /// <summary>
        /// constructor that initialises the form with a listitemview in parameter.
        /// </summary>
        /// <param name="ListViewItem"></param>
        public FormMarque(ListViewItem ListViewItem)
        {
            New = OldDescription = "";
            InitializeComponent();
            Text = "Modifier la Marque";
            TextBox1.Text = OldDescription = ListViewItem.SubItems[0].Text;
            Status = 1;
            label1.Text = "Modifier la Marque..";

        }

        /// <summary>
        /// confirm button, to confirm adding or modifications.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmerButton_Click_1(object Sender, EventArgs Event)
        {
            if (!TextBox1.Text.Equals("") && (TextBox1.Text.Length < 100))
            {
                if (Status == 0)
                {
                    new DaoMarque().AddMarque(TextBox1.Text);
                    ToAdd = TextBox1.Text;
                    Close();
                }
                else if (Status == 1)
                {
                    new DaoMarque().ModifyMarque(OldDescription, TextBox1.Text);
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
