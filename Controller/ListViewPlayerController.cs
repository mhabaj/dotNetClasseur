using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Model;

namespace Bacchus.Controller
{
    class ListViewPlayerController
    {
        public ListViewController ListViewController { get; set; }
        public ListView ListView { get; set; }

        public ListViewPlayerController(ListViewController LvController)
        {
            this.ListViewController = LvController;
            this.ListView = ListViewController.ListView;
        }

        public void ShowArticlesList()
        {
            ListView.BeginUpdate();
            ListView.Clear();
            foreach (Article Article in ListViewController.ListArticles)
            {
                ListViewItem Item = new ListViewItem(new string[]  { Article.Description,
                Article.SousFamille.Famille.Name,
                Article.SousFamille.Name,
                Article.Marque.Name,
                Article.Prix + "",
                Article.Quantite + "",
                Article.ReferenceArticle });

                ListView.Items.Add(Item);
            }

            // Create columns for the items 
            ListView.Columns.Add("Description", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("Famille", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("SousFamille", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("Marque", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("PrixHT", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("Quantite", -2, HorizontalAlignment.Center);

            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }

        public void ShowFamillesList()
        {
            ListView.BeginUpdate();
            ListView.Clear();
            foreach (Famille Famille in ListViewController.ListFamilles)
            {
                ListViewItem Item = new ListViewItem(Famille.Name);
                ListView.Items.Add(Item);
            }

            // Create columns for the items and subitems.
            ListView.Columns.Add("Description", -2, HorizontalAlignment.Center);

            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }

        public void ShowMarquesList()
        {

        }

        public void ShowSousFamillesListByFamille(string Famille)
        {

        }

        public void ShowArticlesListByMarque(string Marque)
        {

        }
    }
}
