using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// Class Famille, contains the methods related to the Family objects containing several Article objects.
    /// Author : Sean Anica & Alhabaj Mahmod
    /// </summary>
    class Famille
    {
        public string Name { get; set; }

        /// <summary>
        /// default consructor of the Famille class.
        /// </summary>
        public Famille()
        {

        }

        /// <summary>
        /// comfort constructor of the Famille class, initializes a Family using a family name
        /// </summary>
        /// <param name="FamName"></param>
        public Famille(string FamName)
        {
            this.Name = FamName;
        }

        /// <summary>
        /// Redifinition of the equals method in order to compare 2 family objects
        /// </summary>
        /// <param name="famille"></param>
        /// <returns></returns>
        public override bool Equals(object famille)
        {
            if (famille == null)
            {
                return false;
            }
            if (!(famille is Famille))
            {
                return false;
            }
            return (Name == ((Famille)famille).Name);
        }

        /// <summary>
        /// redefinition of the getHashCode method to remove the warnings during compilation.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        /// <summary>
        /// redefinition of the == operator in order to compare 2 family objects
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Famille left, Famille right)
        {
            return EqualityComparer<Famille>.Default.Equals(left, right);
        }

        /// <summary>
        /// redefinition of the != operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Famille left, Famille right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
