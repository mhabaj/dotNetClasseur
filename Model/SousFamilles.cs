using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// 
    /// </summary>
    class SousFamilles : Familles
    {
        /// <summary>
        /// 
        /// </summary>
        public SousFamilles()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SousFamilleToAdd"></param>
        public void AddSousFamille(SousFamille SousFamilleToAdd)
        {
            AddFamille(SousFamilleToAdd);
        }
    }
}
