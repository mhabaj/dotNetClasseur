using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class SousFamille : Famille
    {
        public Famille SelectedFamille { get; set; }

       
        public SousFamille(string SousFamName, Famille Famille) : base(SousFamName)
        {
            this.SelectedFamille = Famille;
        }

        public SousFamille()
        {
        }


        public override bool Equals(object Famille)
        {
            return base.Equals(Famille);
        }

       
        public override int GetHashCode()
        {
            int hashCode = 1081318270;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Famille>.Default.GetHashCode(SelectedFamille);
            return hashCode;
        }

       
        public override string ToString()
        {
            return base.ToString() + "SOUSFAMILLE: " + SelectedFamille.ToString();
        }

        public static bool operator ==(SousFamille left, SousFamille right)
        {
            return EqualityComparer<SousFamille>.Default.Equals(left, right);
        }

        public static bool operator !=(SousFamille left, SousFamille right)
        {
            return !(left == right);
        }
    }
}
