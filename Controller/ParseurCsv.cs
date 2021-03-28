using Bacchus.ControllerDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    class ParseurCsv
    {
        public string FilePath { get; set; }

        /// <summary>
        /// default constructor of the ParseurCsv class.
        /// </summary>
        public ParseurCsv()
        {

        }

        /// <summary>
        /// Method to import the datas of a csv file, we have to specify the integration mode (by overwrite or add).
        /// </summary>
        /// <param name="IntegrationMode"></param>
        /// <param name="ProgressBar"></param>
        public void ImportData(bool IntegrationMode, ProgressBar ProgressBar)
        {
            //set the ProgressBar 
            ProgressBar.Value = 0;
            ProgressBar.Refresh();
            ProgressBar.Step = 1;

            if(IntegrationMode.Equals(true))
            {
                Dao DAO = new Dao();
                DAO.EmptyDatabase();
            }
        }
    }
}
