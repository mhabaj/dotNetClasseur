namespace Bacchus.Model
{
    /// <summary>
    /// Article class which contains the methods related to an article object.
    /// Author : ALHABAJ Mahmod, ANICA Sean
    /// </summary>
    class Article
    {
        public string RefArticle { get; set; }
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
            this.RefArticle = RefArticle;
            this.Description = DescrArticle;
            this.SousFamille = SsFamille;
            this.Marque = MarqueArticle;
            this.Prix = PrixArticle;
            this.Quantite = QuantiteArticle;
        }
    }
}
