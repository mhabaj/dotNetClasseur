using System.Collections;
using System.Collections.Generic;

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
            if (!FamilleExists(Famille))
                ListFamilles.Add(Famille);
        }

        /// <summary>
        /// Method that returns true if the Famille exists already.
        /// </summary>
        /// <param name="Famille"></param>
        /// <returns> true if exists, else false </returns>
        public bool FamilleExists(Famille Famille)
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
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)ListFamilles).GetEnumerator();
        }
    }
}
