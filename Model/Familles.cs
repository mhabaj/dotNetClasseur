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

        public void AddFamille(Famille Famille)
        {
            if (!IsFamille(Famille))
                ListFamilles.Add(Famille);
        }

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

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)ListFamilles).GetEnumerator();
        }
    }
}
