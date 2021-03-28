using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class Articles : IEnumerable
    {
        public List<Article> ListeArticles { get; set; }
        public int Count { get { return ListeArticles.Count; } }
      

        public Articles()
        {
            ListeArticles = new List<Article>();
        }
     


        public void AddArticle(Article Article)
        {
            ListeArticles.Add(Article);
        }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
