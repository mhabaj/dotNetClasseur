using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    /// <summary>
    /// Main View controller class
    /// </summary>
    class GeneralViewController
    {
        public TreeViewController TvController { get; set; }
        public StatusStrip StatusStrip {get; set;}
        public ListViewPlayerController LvPlayerController { get; set; }
        public ListViewController LvController { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="ListView"></param>
        /// <param name="TreeView"> TreeView Object </param>
        /// <param name="StatusStrip"> StatusStrip </param>
        public GeneralViewController(ListView ListView, TreeView TreeView, StatusStrip StatusStrip)
        {
            LvController = new ListViewController(ListView); 
            TvController = new TreeViewController(TreeView, new ListViewPlayerController(LvController));
            LvController.TvController = TvController;

            this.StatusStrip = StatusStrip;
            //Sets values in the status strip
            StatusStrip.Items[0].Text = "Articles : " + LvController.ListArticles.TotalSize; 
            StatusStrip.Items[1].Text = "Familles : " + LvController.ListFamilles.TotalSize;
            StatusStrip.Items[2].Text = "Sous Familles : " + LvController.ListSousFamilles.TotalSize;
            StatusStrip.Items[3].Text = "Marques : " + LvController.ListMarques.TotalSize;
        }

        /// <summary>
        /// Reload Data in the StatusStrip from dataBase
        /// </summary>
        public void Reload()
        {
            LvController.Refresh();
            StatusStrip.Items[0].Text = "Articles : " + LvController.ListArticles.TotalSize;
            StatusStrip.Items[1].Text = "Familles : " + LvController.ListFamilles.TotalSize;
            StatusStrip.Items[2].Text = "Sous Familles : " + LvController.ListSousFamilles.TotalSize;
            StatusStrip.Items[3].Text = "Marques : " + LvController.ListMarques.TotalSize;
        }
    }
}
