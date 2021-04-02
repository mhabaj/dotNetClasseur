using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// Class Familles, which integrates the IEnumerable interface to make the class browsable
    /// </summary>
    class Familles :IEnumerable
    {
        public List<Famille> ListFamilles { get; set; }
        public int TotalSize { get { return ListFamilles.Count; } }

        /// <summary>
        /// default constructor of the Familles class. (instantiates the family List)
        /// </summary>
        public Familles()
        {
            ListFamilles = new List<Famille>();
        }

        /// <summary>
        /// Method to add a Famille to the Familles object.
        /// </summary>
        /// <param name="Famille"></param>
        public void AddFamille(Famille Famille)
        {
            if (!IsFamille(Famille))
                ListFamilles.Add(Famille);
        }

        /// <summary>
        /// Method that returns true if the current Famille is equal to the one in parameter.
        /// </summary>
        /// <param name="Famille"></param>
        /// <returns></returns>
        public bool IsFamille(Famille Famille)
        {
            foreach (var CurrentFamille in ListFamilles)
            {
                if (CurrentFamille.Equals(Famille))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Implementation of the getEnumerator interface to make the list usable with foreach. 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)ListFamilles).GetEnumerator();
        }
    }
}
