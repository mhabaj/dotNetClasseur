using System.Windows.Forms;

namespace Bacchus.Controller
{
    /// <summary>
    /// Main View controller class
    /// </summary>
    class MainViewController
    {
        public TreeViewController TvController { get; set; }
        public StatusStrip StatusStrip {get; set;}
        public ListViewController LvPlayerController { get; set; }
        public ListController LvController { get; set; }

        /// <summary>
        /// Class Constructor 
        /// </summary>
        /// <param name="ListView">DataList Object</param>
        /// <param name="TreeView"> TreeView Object </param>
        /// <param name="StatusStrip"> StatusStrip Object </param>
        public MainViewController(ListView ListView, TreeView TreeView, StatusStrip StatusStrip)
        {
            LvController = new ListController(ListView, this); 
            TvController = new TreeViewController(TreeView, new ListViewController(LvController));
            LvController.TvController = TvController;

            this.StatusStrip = StatusStrip;
            //Sets values in the status strip
            StatusStrip.Items[0].Text = "Articles : " + LvController.ListArticles.TotalSize; 
            StatusStrip.Items[1].Text = "Familles : " + LvController.ListFamilles.TotalSize;
            StatusStrip.Items[2].Text = "Sous Familles : " + LvController.ListSousFamilles.TotalSize;
            StatusStrip.Items[3].Text = "Marques : " + LvController.ListMarques.TotalSize;
        }

        /// <summary>
        /// Reload/Refresh/F5 Data in the view
        /// </summary>
        public void Reload()
        {
            LvController.Refresh();
            ReloadStatusStrip();
        }

        public void ReloadStatusStrip()
        {
            StatusStrip.Items[0].Text = "Articles : " + LvController.ListArticles.TotalSize;
            StatusStrip.Items[1].Text = "Familles : " + LvController.ListFamilles.TotalSize;
            StatusStrip.Items[2].Text = "Sous Familles : " + LvController.ListSousFamilles.TotalSize;
            StatusStrip.Items[3].Text = "Marques : " + LvController.ListMarques.TotalSize;

        }
    }
}
