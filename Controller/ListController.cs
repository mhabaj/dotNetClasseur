using Bacchus.ControllerDAO;
using Bacchus.Model;
using System;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    /// <summary>
    /// List View Class controller
    /// </summary>
    class ListController
    {

        public ListView ListView { get; set; }
        public TreeViewController TvController { get; set; }
        public ElementBuilderController EbController { get; set; }
        public Articles ListArticles { get; set; }
        public Marques ListMarques { get; set; }
        public Familles ListFamilles { get; set; }
        public SousFamilles ListSousFamilles { get; set; }

        /// <summary>
        /// ListController Constructer
        /// </summary>
        /// <param name="LView"></param>
        public ListController(ListView LView)
        {
            this.ListView = LView;
            BuildListView();
        }
        /// <summary>
        /// Reload Data from DataBase
        /// </summary>
        public void ReloadDataFromDatabase()
        {
            // Update Local Data with new Data from dataBase
            ListArticles = new DaoArticle().GetArticles();
            ListMarques = new DaoMarque().GetMarques();
            ListSousFamilles = new DaoSousFamille().GetSousFamilles();
            ListFamilles = new DaoFamille().GetFamilles();
        }
        /// <summary>
        /// Initializes ListView 
        /// </summary>
        public void BuildListView()
        {
            EbController = new ElementBuilderController(ListView);
            ReloadDataFromDatabase();
            //Specific Parameters: show lines, sort..
            ListView.AllowColumnReorder = true;
            ListView.Sorting = SortOrder.Descending;
            ListView.GridLines = true;
            ListView.FullRowSelect = true;
            ListView.Sort();
            ListView.ColumnClick += new ColumnClickEventHandler(ListView1ColumnClick);
            ListView.MouseClick += new MouseEventHandler(ListView1MouseClick);
            ListView.KeyDown += new KeyEventHandler(ListView1KeyPressed);
            ListView.MouseDoubleClick += new MouseEventHandler(ListView1MouseDoubleClick);
        }
        /// <summary>
        /// Detects Double Click event on element
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ListView1MouseDoubleClick(object Sender, MouseEventArgs Event)
        {
            UpdateElement();
        }

        /// <summary>
        /// Specific keys pressed events: Delete, F5, Enter
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ListView1KeyPressed(object Sender, KeyEventArgs Event)
        {
            if(Event.KeyCode == Keys.Delete)
            {
                DeleteElement();
            }
            if(Event.KeyCode == Keys.F5)
            {
                Refresh();
            }
            if(Event.KeyCode == Keys.Enter)
            {
                UpdateElement();
            }
        }
        /// <summary>
        /// Custom on mouse right click action
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ListView1MouseClick(object Sender, MouseEventArgs Event)
        {
            if(Event.Button == MouseButtons.Right)
            {
                ListView.ContextMenu = new ContextMenu();
                ListView.ContextMenu.MenuItems.Add(new MenuItem("Ajouter", MenuItemAddEvent));
                ListView.ContextMenu.MenuItems.Add("-");
                ListView.ContextMenu.MenuItems.Add(new MenuItem("modifier", MenuItemUpdateEvent));
                ListView.ContextMenu.MenuItems.Add(new MenuItem("supprimer", MenuItemDeleteEvent));
                ListView.ContextMenu.Show(ListView, new System.Drawing.Point(Event.X, Event.Y));
            }
        }
        /// <summary>
        /// Calls AddElement if action is requested (via right mouse click for example)
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void MenuItemAddEvent(object Sender, EventArgs Event)
        {
            AddElement();
        }
        /// <summary>
        /// Calls UpdateElement if action is requested (via right mouse click for example)
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void MenuItemUpdateEvent(object Sender, EventArgs Event)
        {
            UpdateElement();
        }
        /// <summary>
        /// Calls DeleteElement if action is requested (via right mouse click for example)
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void MenuItemDeleteEvent(object Sender, EventArgs Event)
        {
            DeleteElement();
        }
        /// <summary>
        /// Sort on column click
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ListView1ColumnClick(object Sender, ColumnClickEventArgs Event)
        {
            if(ListView.Sorting == SortOrder.Descending)
            {
                ListView.Sorting = SortOrder.Ascending;
            }
            else
            {
                ListView.Sorting = SortOrder.Descending;
            }

            EbController.SetGroups(Event.Column);
            ListView.BeginUpdate();
            ListView.Sort();
            ListView.Update();
            ListView.Refresh();
            ListView.EndUpdate();
        }
        /// <summary>
        /// Refresh the node and local Data from DataBase
        /// </summary>
        /// <param name="Prev"></param>
        /// <param name="New"></param>
        public void UpdateElementPart(string Prev, string New)
        {
            ReloadDataFromDatabase();
            TvController.ModifyNode(Prev, New);
        }
        /// <summary>
        /// Refresh TreeView
        /// </summary>
        public void Refresh()
        {
            ReloadDataFromDatabase();
            TvController.TreeViewBuilder();
        }

        /// <summary>
        /// Refresh for adding a new entry event
        /// </summary>
        /// <param name="ToAdd"></param>
        public void UpdateDisplayInWindow(string ToAdd)
        {
            ReloadDataFromDatabase();
            TvController.AddElementToNode(ToAdd);
        }
        /// <summary>
        /// Add a new Entry from the selected node
        /// </summary>
        private void AddElement()
        {
            // Look for the right row type and add a new element into it
            if (TvController.TreeView.SelectedNode.Text.Equals("Familles"))
            {
                FormFamille FormFamille = new FormFamille();
                FormFamille.ShowDialog();
                if (!FormFamille.ToAdd.Equals(""))
                    UpdateDisplayInWindow(FormFamille.ToAdd);

            }
            else if (TvController.TreeView.SelectedNode.Text.Equals("Marques"))
            {
                FormMarque FormMarque = new FormMarque();
                FormMarque.ShowDialog();
                if (!FormMarque.ToAdd.Equals(""))
                    UpdateDisplayInWindow(FormMarque.ToAdd);

            }
            else if (TvController.TreeView.SelectedNode.Parent != null && TvController.TreeView.SelectedNode.Parent.Text.Equals("Familles"))
            {
                FormSousFamille FormSousFamille = new FormSousFamille(TvController.TreeView.SelectedNode.Text);
                FormSousFamille.ShowDialog();
                if (!FormSousFamille.ToAdd.Equals(""))
                    UpdateDisplayInWindow(FormSousFamille.ToAdd);

            }
            else
            {
                FormArticle FormArticle = new FormArticle(TvController.TreeView.SelectedNode);
                FormArticle.ShowDialog();

                if (FormArticle.Mark)
                {
                    ReloadDataFromDatabase();
                    TvController.ExpandNodeContent();
                }
            }
        }
        /// <summary>
        /// Edit element from selected node
        /// </summary>
        private void UpdateElement()
        {
            //Look for the current selected row/node and edit the element depending on the Object type (Familles, Marques..)
            if (ListView.SelectedItems.Count == 0) return;
            if (ListView.SelectedItems.Count == 1 && ListView.SelectedItems[0].SubItems.Count != 1)
            {
                FormArticle FormArticle = new FormArticle(ListView.SelectedItems[0]);
                FormArticle.ShowDialog();
                if (FormArticle.Mark)
                {
                    ReloadDataFromDatabase();
                    TvController.ExpandNodeContent();
                }
            }
            else if (TvController.TreeView.SelectedNode.Text.Equals("Familles"))
            {

                FormFamille FormFamille = new FormFamille(ListView.SelectedItems[0]);
                FormFamille.ShowDialog();
                if (!FormFamille.New.Equals("") && !FormFamille.OldDescription.Equals(""))
                {
                    UpdateElementPart(FormFamille.OldDescription, FormFamille.New);
                    
                }
            }
            else if (TvController.TreeView.SelectedNode.Text.Equals("Marques"))
            {
                FormMarque FormMarque = new FormMarque(ListView.SelectedItems[0]);
                FormMarque.ShowDialog();
                if (!FormMarque.New.Equals("") && !FormMarque.OldDescription.Equals(""))
                {
                    UpdateElementPart(FormMarque.OldDescription, FormMarque.New);
                    
                }
            }
            else if (TvController.TreeView.SelectedNode.Parent.Text.Equals("Familles"))
            {
                FormSousFamille FormSousFamille = new FormSousFamille(ListView.SelectedItems[0], TvController.TreeView.SelectedNode.Text);
                FormSousFamille.ShowDialog();
                if (!FormSousFamille.New.Equals("") && !FormSousFamille.OldDescription.Equals(""))
                {
                    UpdateElementPart(FormSousFamille.OldDescription, FormSousFamille.New);
                    
                }
            }
        }
        /// <summary>
        /// Look for the selected row and delete the element.
        /// </summary>
        private void DeleteElement()
        {
            // Look for the selected object and delete the entry (after confirmation message)
            if (ListView.SelectedItems.Count == 0) return;
            var Confirmation = MessageBox.Show("SUPPRIMER ? ", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Confirmation == DialogResult.Yes)
            {
                //remove from the ListView each specific Node type
                foreach (ListViewItem Items in ListView.SelectedItems)
                {
                    if (TvController.TreeView.SelectedNode.Text.Equals("Familles"))
                    {
                        foreach (TreeNode node in TvController.TreeView.SelectedNode.Nodes)
                        {
                            if (node != null && node.Text.Equals(Items.SubItems[0].Text))
                            {
                                TvController.TreeView.SelectedNode.Nodes.Remove(node);
                                TvController.TreeView.Update();
                                TvController.TreeView.Refresh();
                            }
                        }
                        //remove from dataBase...
                        new DaoFamille().RemoveFamille(Items.SubItems[0].Text);
                    }
                    else if (TvController.TreeView.SelectedNode.Text.Equals("Marques"))
                    {
                        foreach (TreeNode Node in TvController.TreeView.SelectedNode.Nodes)
                        {
                            if (Node != null && Node.Text.Equals(Items.SubItems[0].Text))
                            {
                                TvController.TreeView.SelectedNode.Nodes.Remove(Node);
                                TvController.TreeView.Update();
                                TvController.TreeView.Refresh();
                            }
                        }
                        new DaoMarque().RemoveMarqueByName(Items.SubItems[0].Text);
                    }
                    else if (TvController.TreeView.SelectedNode.Parent != null && TvController.TreeView.SelectedNode.Parent.Text.Equals("Familles"))
                    {
                        foreach (TreeNode node in TvController.TreeView.SelectedNode.Nodes)
                        {
                            if (node != null && node.Text.Equals(Items.SubItems[0].Text))
                            {
                                TvController.TreeView.SelectedNode.Nodes.Remove(node);
                                TvController.TreeView.Update();
                                TvController.TreeView.Refresh();
                            }
                        }
                        new DaoSousFamille().RemoveSousFamilleByName(Items.SubItems[0].Text);
                    }
                    else
                    {
                       
                        new DaoArticle().RemoveArticleByRef(
                            new DaoArticle().GetRefArticleByOtherAttributs(
                            Items.SubItems[0].Text, 
                            new DaoController().GetRefObject(Items.SubItems[2].Text, "RefSousFamille", "SousFamilles"), 
                            new DaoController().GetRefObject(Items.SubItems[3].Text, "RefMarque", "Marques"), 
                            Items.SubItems[4].Text.Replace(',', '.'), 
                            Items.SubItems[5].Text)
                            );
                    }

                    for (int i = ListView.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem itm = ListView.SelectedItems[i];
                        ListView.Items[itm.Index].Remove();
                    }
                }
                ReloadDataFromDatabase();
            }
        }

    }
}
