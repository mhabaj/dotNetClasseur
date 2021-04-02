using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// SousFamilles class, subclass of Familles
    /// </summary>
    class SousFamilles : Familles
    {
        /// <summary>
        /// default constructor of the class, does nothing.
        /// </summary>
        public SousFamilles()
        {

        }

        /// <summary>
        /// Method to add a SousFamille to the Famille.
        /// </summary>
        /// <param name="SousFamilleToAdd"></param>
        public void AddSousFamille(SousFamille SousFamilleToAdd)
        {
            AddFamille(SousFamilleToAdd);
        }
    }
}
