using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class SousFamilles : Familles
    {
        
        public SousFamilles()
        {

        }

        
        public void AddSousFamille(SousFamille SousFamilleToAdd)
        {
            AddFamille(SousFamilleToAdd);
        }
    }
}
