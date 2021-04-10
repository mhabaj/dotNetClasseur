using Bacchus.Model;
using System;
using System.Data.SQLite;

namespace Bacchus.ControllerDAO
{
    class DaoArticle : DaoController
    {
        /// <summary>
        /// Default constructor of the class, does nothing.
        /// </summary>
        public DaoArticle()
        {

        }
        /// <summary>
        /// Retrieve Article Reference by it's attributes
        /// </summary>
        /// <param name="Description">string Article's description</param>
        /// <param name="RefSousFamille">string Article's sousFamille reference</param>
        /// <param name="RefMarque">string Article's Marque reference</param>
        /// <param name="Prix">string Article's Prix</param>
        /// <param name="Quantite">string Article's Quantite</param>
        /// <returns>string Article Reference</returns>
        public string GetRefArticleByOtherAttributs(string Description, int RefSousFamille, int RefMarque, string Prix, string Quantite)
        {
            string RefArticleToReturn = "";

            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (SQLiteCommand Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "SELECT RefArticle FROM Articles WHERE Description like @Description and RefSousFamille = @RefSousFamille " +
                            "and RefMarque = @RefMarque and PrixHT = @Prix and Quantite = @Quantite";
                        Query.Parameters.AddWithValue("@Description", Description);
                        Query.Parameters.AddWithValue("@RefSousFamille", RefSousFamille);
                        Query.Parameters.AddWithValue("@RefMarque", RefMarque);
                        Query.Parameters.AddWithValue("@Prix", Prix);
                        Query.Parameters.AddWithValue("@Quantite", Quantite);
                        using (SQLiteDataReader ResultSet = Query.ExecuteReader())
                        {
                            while (ResultSet.Read())
                            {
                                if (!ResultSet.IsDBNull(0))
                                    RefArticleToReturn = Convert.ToString(ResultSet["RefArticle"]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in GetRefArticleByOtherAttributs function");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }

            return RefArticleToReturn;


        }

        /// <summary>
        /// Method to add an Article to the database.
        /// </summary>
        /// <param name="ArticleToAdd"></param>
        public void AddArticle(Article ArticleToAdd)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();

                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        if (GetQuantite(ArticleToAdd.RefArticle) == 0)//If article doesnt already Exists, we perform the insert, else we just add more quantity

                        {
                            Query.CommandText = "INSERT INTO Articles VALUES(@idArticle,@Description,@ReferenceSousFamille,@ReferenceMarque,@Prix,@Quantite)";
                            Query.Parameters.AddWithValue("@idArticle", ArticleToAdd.RefArticle);
                            Query.Parameters.AddWithValue("@Description", ArticleToAdd.Description);
                            Query.Parameters.AddWithValue("@ReferenceSousFamille", GetRefObject(ArticleToAdd.SousFamille.Name, "RefSousFamille", "SousFamilles"));
                            Query.Parameters.AddWithValue("@ReferenceMarque", GetRefObject(ArticleToAdd.Marque.Name, "RefMarque", "Marques"));
                            Query.Parameters.AddWithValue("@Prix", ArticleToAdd.Prix);
                            Query.Parameters.AddWithValue("@Quantite", ArticleToAdd.Quantite);
                        }
                        else
                        {
                            Query.CommandText = "UPDATE Articles SET QUANTITE = @Quantite WHERE RefArticle like @ReferenceArticle";
                            Query.Parameters.AddWithValue("@Quantite", GetQuantite(ArticleToAdd.RefArticle) + ArticleToAdd.Quantite);
                            Query.Parameters.AddWithValue("@ReferenceArticle", ArticleToAdd.RefArticle);
                        }

                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in AddArticle function");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
        }


        /// <summary>
        /// Method that returns the quantity of an article.
        /// </summary>
        /// <param name="idArticle"> string Article's reference </param>
        /// <returns></returns>
        public int GetQuantite(string idArticle)
        {
            int Quantite = 0;
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (SQLiteCommand Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "SELECT Quantite FROM Articles WHERE RefArticle like @idArticle";
                        Query.Parameters.AddWithValue("@idArticle", idArticle);
                        using (SQLiteDataReader ResultSet = Query.ExecuteReader())
                        {
                            while (ResultSet.Read())
                            {
                                if (!ResultSet.IsDBNull(0))
                                    Quantite = ResultSet.GetInt32(0);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in GetQuantite function ");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return Quantite;
        }

       


        /// <summary>
        /// Method that returns a Articles object which is a list of all the Article of the database.
        /// </summary>
        /// <returns> Articles Object with all Articles in the database, else null </returns>
        public Articles GetArticles()
        {
            Articles TmpArticles = new Articles();
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "Select * FROM Articles";
                        SQLiteDataReader ResultSet = Query.ExecuteReader();
                        while (ResultSet.Read())
                        {
                            TmpArticles.AddArticle(new Article(Convert.ToString(ResultSet["RefArticle"]), 
                                Convert.ToString(ResultSet["Description"]),
                                FindSousFamilleByRef(Convert.ToInt32(ResultSet["RefSousFamille"])), 
                                FindMarqueByRef(Convert.ToInt32(ResultSet["RefMarque"])), 
                                Convert.ToDouble(ResultSet["PrixHT"]), 
                                Convert.ToInt32(ResultSet["Quantite"])
                                ));
                        }
                        
                    }
                    return TmpArticles;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in GetArticles function ");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
            return null;
        }
        /// <summary>
        /// Modify Article in the database by giving another in parameter.
        /// </summary>
        /// <param name="Article">Article to modify</param>
        public void ModifyArticle(Article Article)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                using (var Transaction = Connection.BeginTransaction())
                {
                    try
                    {
                        using (var Query = new SQLiteCommand(Connection))
                        {
                            Query.CommandText = "UPDATE Articles SET Description = @Description, RefSousFamille = @ReferenceSousFamille, " +
                            "RefMarque = @ReferenceMarque, PrixHt = @Prix, Quantite = @Quantite Where RefArticle = @RefArticle";
                            Query.Parameters.AddWithValue("@RefArticle", Article.RefArticle);
                            Query.Parameters.AddWithValue("@Description", Article.Description);
                            Query.Parameters.AddWithValue("@ReferenceSousFamille", GetRefObject(Article.SousFamille.Name, "RefSousFamille", "SousFamilles"));
                            Query.Parameters.AddWithValue("@ReferenceMarque", GetRefObject(Article.Marque.Name, "RefMarque", "Marques"));
                            Query.Parameters.AddWithValue("@Prix", Article.Prix);
                            Query.Parameters.AddWithValue("@Quantite", Article.Quantite);

                            Query.Prepare();

                            Query.ExecuteNonQuery();
                            Transaction.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Problem in ModifyArticle function ");
                        Console.WriteLine(e.Message);
                        Transaction.Rollback();

                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }

        }
        /// <summary>
        /// Method to remove an Article from the database by giving its given reference.
        /// </summary>
        /// <param name="RefArticleToRemove">Article Reference</param>
        public void RemoveArticleByRef(string RefArticleToRemove)
        {

            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM ARTICLES WHERE RefArticle Like @Reference";
                        Query.Parameters.AddWithValue("@Reference", RefArticleToRemove);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveArticleByRef function ");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }

        }

       
    }
}
