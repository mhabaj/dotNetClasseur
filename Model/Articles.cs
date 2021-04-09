using System.Collections;
using System.Collections.Generic;

namespace Bacchus.Model
{
    /// <summary>
    /// Articles class which contains the methods that allows to implement the Article class into an IEnumerable interface.
    /// Author: ALHABAJ Mahmod, ANICA Sean
    /// </summary>
    class Articles :IEnumerable
    {
        public List<Article> ListArticles { get; set; }
        public int TotalSize { get { return ListArticles.Count; } }

        /// <summary>
        /// default constructor of the Articles class.
        /// </summary>
        public Articles()
        {
            ListArticles = new List<Article>();
        }

        /// <summary>
        /// Method that allows us to add an article to the Article List.
        /// </summary>
        /// <param name="Article"></param>
        public void AddArticle(Article Article)
        {
            ListArticles.Add(Article);
        }

        /// <summary>
        /// Allows us to add the IEnumerable interface to the project, thanks to that
        /// we can use the list of articles more easily, in a foreach for instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)ListArticles).GetEnumerator();
        }
    }
}
