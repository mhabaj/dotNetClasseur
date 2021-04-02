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

        public Marque(string MarqueName)
        {
            this.Name = MarqueName;
        }

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
