using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class Marques :IEnumerable
    {
        public List<Marque> ListMarques { get; set; }
        public int TotalSize { get { return ListMarques.Count; } }

        public Marques()
        {
            ListMarques = new List<Marque>();
        }


        public void AddMarque(Marque Marque)
        {
            if (!IsMarque(Marque))
                ListMarques.Add(Marque);
        }

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

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)ListMarques).GetEnumerator();
        }
    }
}
