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
            int hashCode = 1081318270;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Famille>.Default.GetHashCode(Famille);
            return hashCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "..............................." + Famille.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(SousFamille left, SousFamille right)
        {
            return EqualityComparer<SousFamille>.Default.Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(SousFamille left, SousFamille right)
        {
            return !(left == right);
        }
    }
}
