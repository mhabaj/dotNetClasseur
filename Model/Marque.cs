using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class Marque
    {
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MarqueName"></param>
        public Marque(string MarqueName)
        {
            this.Name = MarqueName;
        }

        /// <summary>
        /// Redefinition of the equals method.
        /// </summary>
        /// <param name="Marque"></param>
        /// <returns></returns>
        public override bool Equals(object Marque)
        {
            if (Marque == null)
            {
                return false;
            }
            if (!(Marque is Marque))
            {
                return false;
            }
            return (Name == ((Marque)Marque).Name);
        }

        /// <summary>
        /// Redefinition of the gethashcode method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        /// <summary>
        /// Redefinition of the ToString method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
