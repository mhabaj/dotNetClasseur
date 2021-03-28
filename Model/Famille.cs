using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class Famille 
    {
        public string Name { get; set; }


        public Famille()
        {

        }
       
        public Famille(string FamName)
        {
            this.Name = FamName;
        }


        

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

  

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public static bool operator ==(Famille left, Famille right)
        {
            return EqualityComparer<Famille>.Default.Equals(left, right);
        }

        public static bool operator !=(Famille left, Famille right)
        {
            return !(left == right);
        }
    }
}
