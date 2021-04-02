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
    class SousFamille : Famille
    {
        /// <summary>
        /// 
        /// </summary>
        public Famille Famille { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SousFamName"></param>
        /// <param name="Famille"></param>
        public SousFamille(string SousFamName, Famille Famille) : base(SousFamName)
        {
            this.Famille = Famille;
        }

        /// <summary>
        /// 
        /// </summary>
        public SousFamille()
        {
            this.Famille = new Famille();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Famille"></param>
        /// <returns></returns>
        public override bool Equals(object Famille)
        {
            return base.Equals(Famille);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "..............................." + Famille.ToString();
        }

    }
}
