using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// Article class which contains the methods related to an article object.
    /// Author : Sean Anica & Alhabaj Mahmod
    /// </summary>
    class Article
    {
        public string ReferenceArticle { get; set; }
        public string Description { get; set; }
        public SousFamille SousFamille { get; set; }
        public Marque Marque { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        
        /// <summary>
        /// comfort constructor of the Article class, initializes the variables of the class.
        /// </summary>
        /// <param name="RefArticle"></param>
        /// <param name="DescrArticle"></param>
        /// <param name="SsFamille"></param>
        /// <param name="MarqueArticle"></param>
        /// <param name="PrixArticle"></param>
        /// <param name="QuantiteArticle"></param>
        public Article(string RefArticle, string DescrArticle, SousFamille SsFamille, Marque MarqueArticle, double PrixArticle, int QuantiteArticle = 1)
        {
            ReferenceArticle = RefArticle;
            Description = DescrArticle;
            SousFamille = SsFamille;
            Marque = MarqueArticle;
            Prix = PrixArticle;
            Quantite = QuantiteArticle;
        }
    }
}
