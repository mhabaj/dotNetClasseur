using Bacchus.Model;
using System.Windows.Forms;

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
        /// <param name="ListController">ListController Object</param>
        public ListViewController(ListController ListController)
        {
            this.ListController = ListController;
            this.ListView = this.ListController.ListView;
        }

        /// <summary>
        /// Adds Articles & Table structure to ListView
        /// </summary>
        public void ShowArticles()
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
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("Famille", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("SousFamille", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("Marque", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("Prix(H.T.)", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("Quantité", 0, HorizontalAlignment.Left);

            //Auto Resize columns by Column entry Content value &/or column name (if empty)
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
        /// <summary>
        /// Adds Familles Data & Table structure to ListView 
        /// </summary>
        public void ShowFamilles()
        {
            ListView.BeginUpdate();
            ListView.Clear();
            foreach (Famille Famille in ListController.ListFamilles)
            {
                ListViewItem Item = new ListViewItem(Famille.Name);
                ListView.Items.Add(Item);
            }

            // Add columns names for every Attribute 
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Left);

            //Auto Resize columns by Column entry Content value &/or column name (if empty)
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
        /// <summary>
        /// Adds Marques Data & Table structure to ListView 
        /// </summary>
        public void ShowMarques()
        {
            ListView.BeginUpdate();
            ListView.Clear();
            foreach (Marque Marque in ListController.ListMarques)
            {
                ListViewItem Item = new ListViewItem(Marque.Name);
                ListView.Items.Add(Item);
            }

            // Add columns names for every Attribute 
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Left);

            //Auto Resize columns by Column entry Content value &/or column name (if empty)
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
        /// <summary>
        /// Adds SousFamille of the selected Famille & Table structure to ListView 
        /// </summary>
        /// <param name="Famille">Famille Name</param>
        public void ShowSousFamillesByFamille(string Famille)
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
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Left);


            //Auto Resize columns by Column entry Content value &/or column name (if empty)
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
        /// <summary>
        /// Adds Articles of the selected Marque & Table structure to ListView 
        /// </summary>
        /// <param name="Marque"></param>
        public void ShowArticlesByMarque(string Marque)
        {
            ListView.BeginUpdate();
            ListView.Clear();

            foreach (Article Article in ListController.ListArticles)
            {
                if (Article.Marque.Name.Equals(Marque) || Article.SousFamille.Famille.Name.Equals(Marque) || Article.SousFamille.Name.Equals(Marque))
                {
                    ListViewItem Item = new ListViewItem(
                        new string[]  
                        { 
                            Article.Description,
                            Article.SousFamille.Famille.Name,
                            Article.SousFamille.Name,
                            Article.Marque.Name,
                            Article.Prix + "",
                            Article.Quantite + "",
                            Article.RefArticle 
                        }
                        );

                    ListView.Items.Add(Item);

                }
            }
            // Add columns names for every Attribute 
            ListView.Columns.Add("Description", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("Famille", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("SousFamille", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("Marque", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("Prix(H.T.)", 0, HorizontalAlignment.Left);
            ListView.Columns.Add("Quantité", 0, HorizontalAlignment.Left);

            //Auto Resize columns by Column entry Content value &/or column name (if empty)
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListView.EndUpdate();
        }
    }
}
