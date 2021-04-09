using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Model;

namespace Bacchus.Controller
{
    /// <summary>
    /// View Controller class of the data List
    /// </summary>
    class ListViewController
    {
        public ListController ListController { get; set; }
        public ListView ListView { get; set; }
        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="LvController">ListController Object</param>
        public ListViewController(ListController LvController)
        {
            this.ListController = LvController;
            this.ListView = ListController.ListView;
        }

        /// <summary>
        /// Adds Articles Data to ListView
        /// </summary>
        public void ShowArticlesList()
        {
            ListView.BeginUpdate();
            ListView.Clear(); 
            //For every Article Entry, add data to the column.
            foreach (Article Article in ListController.ListArticles)
            {
                
                ListViewItem Item = new ListViewItem(new string[]  { 
                Article.Description,
                Article.SousFamille.Famille.Name,
                Article.SousFamille.Name,
                Article.Marque.Name,
                Article.Prix + "",
                Article.Quantite + "",
                Article.RefArticle });

                ListView.Items.Add(Item);
            }

            // Add columns names for every Attribute 
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Center);
            ListView.Columns.Add("Famille", 0, HorizontalAlignment.Center);
            ListView.Columns.Add("SousFamille", 0, HorizontalAlignment.Center);
            ListView.Columns.Add("Marque", 0, HorizontalAlignment.Center);
            ListView.Columns.Add("Prix(HT)", 0, HorizontalAlignment.Center);
            ListView.Columns.Add("Quantite", 0, HorizontalAlignment.Center);

            //Auto Resize columns by Column entry Content value &/or column name 
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
        /// <summary>
        /// Adds Familles Data to ListView
        /// </summary>
        public void ShowFamillesList()
        {
            ListView.BeginUpdate();
            ListView.Clear();
            foreach (Famille Famille in ListController.ListFamilles)
            {
                ListViewItem Item = new ListViewItem(Famille.Name);
                ListView.Items.Add(Item);
            }

            // Add columns names for every Attribute 
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Center);

            //Auto Resize columns by Column entry Content value &/or column name 
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
        /// <summary>
        /// Adds Marques Data to ListView
        /// </summary>
        public void ShowMarquesList()
        {
            ListView.BeginUpdate();
            ListView.Clear();
            foreach (Marque Marque in ListController.ListMarques)
            {
                ListViewItem Item = new ListViewItem(Marque.Name);
                ListView.Items.Add(Item);
            }

            // Add columns names for every Attribute 
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Center);
            //Auto Resize columns by Column entry Content value &/or column name 

            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
        /// <summary>
        /// Adds SousFamille of the selected Famille Data to ListView
        /// </summary>
        /// <param name="Famille">Famille Name</param>
        public void ShowSousFamillesListByFamille(string Famille)
        {
            ListView.BeginUpdate();
            ListView.Clear();
            foreach (SousFamille SousFamille in ListController.ListSousFamilles)
            {
                if (SousFamille.Famille.Name.Equals(Famille))
                {
                    ListViewItem Item = new ListViewItem(SousFamille.Name);
                    ListView.Items.Add(Item);
                }
            }
            // Add columns names for every Attribute 
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Center);
            //Auto Resize columns by Column entry Content value &/or column name 

            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }

        public void ShowArticlesListByMarque(string Marque)
        {
            ListView.BeginUpdate();
            ListView.Clear();

            foreach (Article Article in ListController.ListArticles)
            {
                if (Article.Marque.Name.Equals(Marque) || Article.SousFamille.Famille.Name.Equals(Marque) || Article.SousFamille.Name.Equals(Marque))
                {
                    ListViewItem Item = new ListViewItem(new string[]  { Article.Description,
                    Article.SousFamille.Famille.Name,
                    Article.SousFamille.Name,
                    Article.Marque.Name,
                    Article.Prix + "",
                    Article.Quantite + "",
                    Article.RefArticle });

                    ListView.Items.Add(Item);

                }
            }
            // Add columns names for every Attribute 
            ListView.Columns.Add("Description", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("Famille", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("SousFamille", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("Marque", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("PrixHT", -2, HorizontalAlignment.Center);
            ListView.Columns.Add("Quantite", -2, HorizontalAlignment.Center);
            //Auto Resize columns by Column entry Content value &/or column name 

            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
    }
}
