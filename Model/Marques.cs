using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// Marques class, which represents a list of Marque.
    /// </summary>
    class Marques :IEnumerable
    {
        public List<Marque> ListMarques { get; set; } //list of Marque.
        public int TotalSize { get { return ListMarques.Count; } } //size of the list.

        /// <summary>
        /// Default constructor of the class.
        /// </summary>
        public Marques()
        {
            ListMarques = new List<Marque>();
        }

        /// <summary>
        /// Method to add a Marque object to the list of Marques.
        /// </summary>
        /// <param name="Marque"></param>
        public void AddMarque(Marque Marque)
        {
            if (!IsMarque(Marque))
                ListMarques.Add(Marque);
        }

        /// <summary>
        /// Method that returns true if the Marque is in the list.
        /// </summary>
        /// <param name="Marque"></param>
        /// <returns></returns>
        public bool IsMarque(Marque Marque)
        {
            foreach (var CurrentMarque in ListMarques)
            {
                if (CurrentMarque.Equals(Marque))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// implementation of the Ienumerable interface to make the class foreachable.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)ListMarques).GetEnumerator();
        }
    }
}
