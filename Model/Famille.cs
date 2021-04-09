using System.Collections.Generic;

namespace Bacchus.Model
{
    /// <summary>
    /// Class Famille, contains the methods related to the Family objects containing several Article objects.
    /// Author : ALHABAJ Mahmod, ANICA Sean
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
        /// Compare 2 family objects by overriding the original Equals.
        /// </summary>
        /// <param name="famille"></param>
        /// <returns> true if same, else false. </returns>
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

        public override string ToString()
        {
            return Name;
        }
    }
}
