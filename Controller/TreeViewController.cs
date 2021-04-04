using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Model;

namespace Bacchus.Controller
{
    class TreeViewController
    {
        public ListViewPlayerController ListViewPlayerController;
        public TreeView TreeView { get; set; }

        public TreeViewController(TreeView TreeView, ListViewPlayerController ListViewPlayerController)
        {
            this.TreeView = TreeView;
            this.ListViewPlayerController = ListViewPlayerController;
            TreeViewBuilder();
        }

        public void TreeViewBuilder()
        {
            TreeView.Nodes.Clear();
            TreeNode Racine = new TreeNode("Tous les articles");
            TreeNode Familles = new TreeNode("Familles");
            TreeNode Marques = new TreeNode("Marques");

            TreeView.Nodes.Add(Racine);
            Racine.Nodes.Add(Familles);
            Racine.Nodes.Add(Marques);

            foreach(Famille Famille in ListViewPlayerController.ListViewController.ListFamilles)
            {
                TreeNode Current = new TreeNode(Famille.Name);
                Familles.Nodes.Add(Current);
                foreach(SousFamille SsFamille in ListViewPlayerController.ListViewController.ListSousFamilles)
                {
                    if (SsFamille.Famille.Name.Equals(Famille.Name))
                    {
                        Current.Nodes.Add(SsFamille.Name);
                    }
                }
            }

            foreach (Marque Marque in ListViewPlayerController.ListViewController.ListMarques)
            {
                Marques.Nodes.Add(Marque.Name);
            }
            TreeView.AfterSelect += new TreeViewEventHandler(TreeViewAfterSelect);
            TreeView.SelectedNode = Racine;
            Racine.Expand();
        }

        private void TreeViewAfterSelect(object Sender, TreeViewEventArgs E)
        {
            DisplayElementsOfNode();
        }

        public void UpdateNode(string Old, string New)
        {
            foreach(TreeNode TNode in TreeView.SelectedNode.Nodes)
            {
                if (TNode.Text.Equals(Old))
                {
                    TNode.Text = New;
                }
            }
        }

        public void AddElementToNode(string Element)
        {
            TreeView.SelectedNode.Nodes.Add(Element);
            DisplayElementsOfNode();
        }

        public TreeView GetTreeView()
        {
            return TreeView;
        }

        public void DisplayElementsOfNode()
        {
            ListViewPlayerController.ListViewController.ListView.Groups.Clear();
            if(TreeView.SelectedNode.Level == 0)
            {
                ListViewPlayerController.ShowArticlesList();
            }else if(TreeView.SelectedNode.Level == 1)
            {
                if (TreeView.SelectedNode.Text.ToString().Equals("Marques"))
                {
                    ListViewPlayerController.ShowArticlesList();
                }
                else
                {
                    ListViewPlayerController.ShowFamillesList();
                }
            }else if (TreeView.SelectedNode.Level == 2)
            {
                if (TreeView.SelectedNode.Text.Equals("Marques"))
                {
                    ListViewPlayerController.ShowArticlesListByMarque(TreeView.SelectedNode.Text);
                }
                else
                {
                    ListViewPlayerController.ShowSousFamillesListByFamille(TreeView.SelectedNode.Text);
                }
            }else if (TreeView.SelectedNode.Level == 3)
            {
                ListViewPlayerController.ShowArticlesListByMarque(TreeView.SelectedNode.Text);
            }
            else
            {
                return;
            }
        }
    }
}
