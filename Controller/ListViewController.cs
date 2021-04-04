using Bacchus.ControllerDAO;
using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    class ListViewController
    {

        public ListView ListView { get; set; }
        public TreeViewController TvController { get; set; }
        public ElementBuilderController EbController { get; set; }
        public Articles ListArticles { get; set; }
        public Marques ListMarques { get; set; }
        public Familles ListFamilles { get; set; }
        public SousFamilles ListSousFamilles { get; set; }

        public ListViewController(ListView LView)
        {
            this.ListView = LView;
            BuildListView();
        }

        public void ReloadDataFromDatabase()
        {
            ListArticles = new DaoArticle().ListAllArticles();
            ListMarques = new DaoMarque().ListAllMarques();
            ListSousFamilles = new DaoSousFamille().ListAllSousFamilles();
            ListFamilles = new DaoFamille().ListAllFamilles();
        }
        public void BuildListView()
        {
            EbController = new ElementBuilderController(ListView);
            ReloadDataFromDatabase();

            ListView.AllowColumnReorder = true;
            ListView.Sorting = SortOrder.Descending;
            ListView.GridLines = true;
            ListView.FullRowSelect = true;
            ListView.Sort();
            ListView.ColumnClick += new ColumnClickEventHandler(ListView1ColumnClick);
            ListView.MouseClick += new MouseEventHandler(ListView1MouseClick);
            ListView.KeyDown += new KeyEventHandler(ListView1KeyDown);
            ListView.MouseDoubleClick += new MouseEventHandler(ListView1MouseDoubleClick);
        }

        private void ListView1MouseDoubleClick(object Sender, MouseEventArgs E)
        {
            UpdateElement();
        }

        private void ListView1KeyDown(object Sender, KeyEventArgs E)
        {
            if(E.KeyCode == Keys.Delete)
            {
                DeleteElement();
            }
            if(E.KeyCode == Keys.F5)
            {
                Refresh();
            }
            if(E.KeyCode == Keys.Enter)
            {
                UpdateElement();
            }
        }

        private void ListView1MouseClick(object Sender, MouseEventArgs E)
        {
            if(E.Button == MouseButtons.Right)
            {
                ListView.ContextMenu = new ContextMenu();
                ListView.ContextMenu.MenuItems.Add(new MenuItem("Ajouter", MenuItemAddEvent));
                ListView.ContextMenu.MenuItems.Add(new MenuItem("modifier", MenuItemUpdateEvent));
                ListView.ContextMenu.MenuItems.Add(new MenuItem("supprimer", MenuItemDeleteEvent));
                ListView.ContextMenu.Show(ListView, new System.Drawing.Point(E.X, E.Y));
            }
        }

        private void MenuItemAddEvent(object Sender, EventArgs E)
        {
            AddElement();
        }

        private void MenuItemUpdateEvent(object Sender, EventArgs E)
        {
            UpdateElement();
        }

        private void MenuItemDeleteEvent(object Sender, EventArgs E)
        {
            DeleteElement();
        }

        private void ListView1ColumnClick(object Sender, ColumnClickEventArgs E)
        {
            if(ListView.Sorting == SortOrder.Descending)
            {
                ListView.Sorting = SortOrder.Ascending;
            }
            else
            {
                ListView.Sorting = SortOrder.Descending;
            }

            EbController.SetTable(E.Column);
            ListView.BeginUpdate();
            ListView.Sort();
            ListView.Update();
            ListView.Refresh();
            ListView.EndUpdate();
        }

        public void UpdateElementPart(string Prev, string New)
        {
            ReloadDataFromDatabase();
            TvController.UpdateNode(Prev, New);
        }

        public void Refresh()
        {
            ReloadDataFromDatabase();
            TvController.TreeViewBuilder();
        }

        public void UpdateDisplayInWindow(string ToAdd)
        {
            ReloadDataFromDatabase();
            TvController.AddElementToNode(ToAdd);
        }

        private void AddElement()
        {
            if (TvController.GetTreeView().SelectedNode.Text.Equals("Familles"))
            {
                FormFamille FormFamille = new FormFamille();
                FormFamille.ShowDialog();
                if (!FormFamille.ToAdd.Equals(""))
                    UpdateDisplayInWindow(FormFamille.ToAdd);

            }
            else if (TvController.GetTreeView().SelectedNode.Text.Equals("Marques"))
            {
                FormMarque FormMarque = new FormMarque();
                FormMarque.ShowDialog();
                if (!FormMarque.ToAdd.Equals(""))
                    UpdateDisplayInWindow(FormMarque.ToAdd);

            }
            else if (TvController.GetTreeView().SelectedNode.Parent != null && TvController.GetTreeView().SelectedNode.Parent.Text.Equals("Familles"))
            {
                FormSousFamille FormSousFamille = new FormSousFamille(TvController.GetTreeView().SelectedNode.Text);
                FormSousFamille.ShowDialog();
                if (!FormSousFamille.ToAdd.Equals(""))
                    UpdateDisplayInWindow(FormSousFamille.ToAdd);

            }
            else
            {
                FormArticle FormArticle = new FormArticle(TvController.GetTreeView().SelectedNode);
                FormArticle.ShowDialog();

                if (FormArticle.Mark)
                {
                    ReloadDataFromDatabase();
                    TvController.DisplayElementsOfNode();
                }
            }
        }

        private void UpdateElement()
        {
            if (ListView.SelectedItems.Count == 0) return;
            if (ListView.SelectedItems.Count == 1 && ListView.SelectedItems[0].SubItems.Count != 1)
            {
                FormArticle FormArticle = new FormArticle(ListView.SelectedItems[0]);
                FormArticle.ShowDialog();
                if (FormArticle.Mark)
                {
                    ReloadDataFromDatabase();
                    TvController.DisplayElementsOfNode();
                }
            }
            else if (TvController.GetTreeView().SelectedNode.Text.Equals("Familles"))
            {

                FormFamille FormFamille = new FormFamille(ListView.SelectedItems[0]);
                FormFamille.ShowDialog();
                if (!FormFamille.New.Equals("") && !FormFamille.OldDescription.Equals(""))
                {
                    UpdateElementPart(FormFamille.OldDescription, FormFamille.New);
                }
            }
            else if (TvController.GetTreeView().SelectedNode.Text.Equals("Marques"))
            {
                FormMarque FormMarque = new FormMarque(ListView.SelectedItems[0]);
                FormMarque.ShowDialog();
                if (!FormMarque.New.Equals("") && !FormMarque.OldDescription.Equals(""))
                {
                    UpdateElementPart(FormMarque.OldDescription, FormMarque.New);
                }
            }
            else if (TvController.GetTreeView().SelectedNode.Parent.Text.Equals("Familles"))
            {
                FormSousFamille FormSousFamille = new FormSousFamille(ListView.SelectedItems[0], TvController.GetTreeView().SelectedNode.Text);
                FormSousFamille.ShowDialog();
                if (!FormSousFamille.New.Equals("") && !FormSousFamille.OldDescription.Equals(""))
                {
                    UpdateElementPart(FormSousFamille.OldDescription, FormSousFamille.New);
                }
            }
        }

        private void DeleteElement()
        {
            if (ListView.SelectedItems.Count == 0) return;
            var Confirmation = MessageBox.Show("SUPPRIMER ? ", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Confirmation == DialogResult.Yes)
            {
                foreach (ListViewItem Items in ListView.SelectedItems)
                {
                    if (TvController.GetTreeView().SelectedNode.Text.Equals("Familles"))
                    {
                        foreach (TreeNode node in TvController.GetTreeView().SelectedNode.Nodes)
                        {
                            if (node != null && node.Text.Equals(Items.SubItems[0].Text))
                            {
                                TvController.GetTreeView().SelectedNode.Nodes.Remove(node);
                                TvController.GetTreeView().Update();
                                TvController.GetTreeView().Refresh();
                            }
                        }
                        new DaoFamille().RemoveFamilleByName(Items.SubItems[0].Text);
                    }
                    else if (TvController.GetTreeView().SelectedNode.Text.Equals("Marques"))
                    {
                        foreach (TreeNode Node in TvController.GetTreeView().SelectedNode.Nodes)
                        {
                            if (Node != null && Node.Text.Equals(Items.SubItems[0].Text))
                            {
                                TvController.GetTreeView().SelectedNode.Nodes.Remove(Node);
                                TvController.GetTreeView().Update();
                                TvController.GetTreeView().Refresh();
                            }
                        }
                        new DaoMarque().RemoveMarqueByName(Items.SubItems[0].Text);
                    }
                    else if (TvController.GetTreeView().SelectedNode.Parent != null && TvController.GetTreeView().SelectedNode.Parent.Text.Equals("Familles"))
                    {
                        foreach (TreeNode node in TvController.GetTreeView().SelectedNode.Nodes)
                        {
                            if (node != null && node.Text.Equals(Items.SubItems[0].Text))
                            {
                                TvController.GetTreeView().SelectedNode.Nodes.Remove(node);
                                TvController.GetTreeView().Update();
                                TvController.GetTreeView().Refresh();
                            }
                        }
                        new DaoSousFamille().RemoveSousFamilleByName(Items.SubItems[0].Text);
                    }
                    else
                    {
                        new DaoArticle().RemoveArticleByRef(Items.SubItems[5].Text);
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
