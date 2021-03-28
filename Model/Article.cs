using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class Article
    {
       

        public string ReferenceArticle { get; set; }
        public string Description { get; set; }
        public SousFamille SousFamille { get; set; }
        public Marque Marque { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }




        public Article(string referenceArticle, string description, SousFamille sousFamille, Marque marque, double prix, int quantite)
        {
            ReferenceArticle = referenceArticle;
            Description = description;
            SousFamille = sousFamille;
            Marque = marque;
            Prix = prix;
            Quantite = quantite;
        }

    }
}
