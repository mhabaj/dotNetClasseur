using Bacchus.Model;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    /// <summary>
    /// View Controller class of the data List
    /// </summary>
    class TreeViewController
    {
        public ListViewController ListViewController;
        public TreeView TreeView { get; set; }
        /// <summary>
        /// View Controller class of the data List
        /// </summary>
        /// <param name="TreeView">TreeView Object</param>
        /// <param name="ListViewController">ListViewController Object</param>
        public TreeViewController(TreeView TreeView, ListViewController ListViewController)
        {
            this.TreeView = TreeView;
            this.ListViewController = ListViewController;
            TreeViewBuilder();
        }
        /// <summary>
        /// Initialize and build the TreeView 
        /// </summary>
        public void TreeViewBuilder()
        {
            TreeView.Nodes.Clear();
            // 3 Tree parts
            TreeNode Racine = new TreeNode("Tous les articles");
            TreeNode Familles = new TreeNode("Familles");
            TreeNode Marques = new TreeNode("Marques");

            TreeView.Nodes.Add(Racine);
            Racine.Nodes.Add(Familles);
            Racine.Nodes.Add(Marques);
            //Add subnodes to each node (famille then Marque).
            foreach(Famille Famille in ListViewController.ListController.ListFamilles)
            {
                TreeNode Current = new TreeNode(Famille.Name);
                Familles.Nodes.Add(Current);
                foreach(SousFamille SsFamille in ListViewController.ListController.ListSousFamilles)
                {
                    if (SsFamille.Famille.Name.Equals(Famille.Name))
                    {
                        Current.Nodes.Add(SsFamille.Name);
                    }
                }
            }
            //Marque:
            foreach (Marque Marque in ListViewController.ListController.ListMarques)
            {
                Marques.Nodes.Add(Marque.Name);
            }
            TreeView.AfterSelect += new TreeViewEventHandler(TreeViewAfterSelect);
            TreeView.SelectedNode = Racine;
            Racine.Expand();
        }
        /// <summary>
        /// Update the TreeView to the currently selected node (and show the node content)
        /// </summary>
        public void ExpandNodeContent()
        {
            ListViewController.ListController.ListView.Groups.Clear();
            //Root
            if (TreeView.SelectedNode.Level == 0)
            {
                ListViewController.ShowArticles();
            }
            else if (TreeView.SelectedNode.Level == 1) //sub Root levels..:
            {
                if (TreeView.SelectedNode.Text.ToString().Equals("Marques"))
                {
                    ListViewController.ShowMarques();
                }
                else
                {
                    ListViewController.ShowFamilles();
                }
            }
            else if (TreeView.SelectedNode.Level == 2)
            {
                if (TreeView.SelectedNode.Parent.Text.Equals("Marques"))
                {
                    ListViewController.ShowArticlesByMarque(TreeView.SelectedNode.Text);
                }
                else
                {
                    ListViewController.ShowSousFamillesByFamille(TreeView.SelectedNode.Text);
                }
            }
            else if (TreeView.SelectedNode.Level == 3)
            {
                ListViewController.ShowArticlesByMarque(TreeView.SelectedNode.Text);
            }
           
        }

      /// <summary>
      /// Add a new Node to the tree
      /// </summary>
      /// <param name="Element">Element name to add</param>

        public void AddElementToNode(string Element)
        {
            TreeView.SelectedNode.Nodes.Add(Element);
            ExpandNodeContent();
        }

        /// <summary>
        /// Modify Node text content in the tree
        /// </summary>
        /// <param name="Old">Old Name</param>
        /// <param name="New">New Name</param>
        public void ModifyNode(string Old, string New)
        {
            foreach (TreeNode Node in TreeView.SelectedNode.Nodes)
            {
                if (Node.Text.Equals(Old))
                {
                    Node.Text = New;
                }
            }
            ExpandNodeContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sender">Event Sender</param>
        /// <param name="EventArgs">Args of event</param>
        private void TreeViewAfterSelect(object Sender, TreeViewEventArgs EventArgs)
        {
            ExpandNodeContent();
        }
       
    }
}
