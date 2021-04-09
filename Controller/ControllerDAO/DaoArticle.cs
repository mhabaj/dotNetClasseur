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
        /// <param name="Description"></param>
        /// <param name="RefSousFamille"></param>
        /// <param name="RefMarque"></param>
        /// <param name="Prix"></param>
        /// <param name="Quantite"></param>
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
                        Query.CommandText = "SELECT RefArticle FROM Articles WHERE Description = @Description and RefSousFamille = @RefSousFamille " +
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
                    System.Windows.Forms.MessageBox.Show("Problem in GetRefArticleByOtherAttributs function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }

            return RefArticleToReturn;


        }

        /// <summary>
        /// Method that returns the quantity of articles in the database.
        /// </summary>
        /// <param name="idArticle"></param>
        /// <returns></returns>
        public int GetQuantite(string idArticle)
        {
            int Quantity = 0;
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (SQLiteCommand Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "SELECT Quantite FROM Articles WHERE RefArticle = @idArticle";
                        Query.Parameters.AddWithValue("@idArticle", idArticle);
                        using (SQLiteDataReader ResultSet = Query.ExecuteReader())
                        {
                            while (ResultSet.Read())
                            {
                                if (!ResultSet.IsDBNull(0))
                                    Quantity = ResultSet.GetInt32(0);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in GetQuantite function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return Quantity;
        }

        /// <summary>
        /// Method to add an Artile to the database.
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
                        if (GetQuantite(ArticleToAdd.RefArticle) == 0)//If article doesnt already Exists

                        {
                            Query.CommandText = "INSERT INTO Articles VALUES(@idArticle,@Description,@ReferenceSousFamille,@ReferenceMarque,@Prix,@Quantite)";
                            Query.Parameters.AddWithValue("@idArticle", ArticleToAdd.RefArticle);
                            Query.Parameters.AddWithValue("@Description", ArticleToAdd.Description);
                            Query.Parameters.AddWithValue("@ReferenceSousFamille", FindReference(ArticleToAdd.SousFamille.Name, "RefSousFamille", "SousFamilles"));
                            Query.Parameters.AddWithValue("@ReferenceMarque", FindReference(ArticleToAdd.Marque.Name, "RefMarque", "Marques"));
                            Query.Parameters.AddWithValue("@Prix", ArticleToAdd.Prix);
                            Query.Parameters.AddWithValue("@Quantite", ArticleToAdd.Quantite);
                        }
                        else //add quantity to existing total quantity
                        {
                            Query.CommandText = "UPDATE Articles SET QUANTITE = @Qte WHERE RefArticle =@RefArticle";
                            Query.Parameters.AddWithValue("@Qte", GetQuantite(ArticleToAdd.RefArticle) + ArticleToAdd.Quantite);
                            Query.Parameters.AddWithValue("@RefArticle", ArticleToAdd.RefArticle);
                        }

                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in AddArticle function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Method to delete an Article from the database by giving its reference in parameter.
        /// </summary>
        /// <param name="RefArticleToRemove"></param>
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
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveArticleByRef function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }

        }

        /// <summary>
        /// Method that returns a Articles object which is a list of all the Article of the database.
        /// </summary>
        /// <returns></returns>
        public Articles ListAllArticles()
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
                            TmpArticles.AddArticle(new Article(Convert.ToString(ResultSet["RefArticle"]), Convert.ToString(ResultSet["Description"]),
                                FindSousFamilleByRef(Convert.ToInt32(ResultSet["RefSousFamille"])), FindMarqueByRef(Convert.ToInt32(ResultSet["RefMarque"])), Convert.ToDouble(ResultSet["PrixHT"]), Convert.ToInt32(ResultSet["Quantite"])));
                        }
                        
                    }
                    return TmpArticles;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in ListAllArticles function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return null;
        }
        
        /// <summary>
        /// Method the update and article of the database by giving another in parameter.
        /// </summary>
        /// <param name="Article"></param>
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
                            Query.Parameters.AddWithValue("@ReferenceSousFamille", FindReference(Article.SousFamille.Name, "RefSousFamille", "SousFamilles"));
                            Query.Parameters.AddWithValue("@ReferenceMarque", FindReference(Article.Marque.Name, "RefMarque", "Marques"));
                            Query.Parameters.AddWithValue("@Prix", Article.Prix);
                            Query.Parameters.AddWithValue("@Quantite", Article.Quantite);

                            Query.Prepare();

                            Query.ExecuteNonQuery();
                            Transaction.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Problem in ModifyArticle function : " + e.Message);
                        Transaction.Rollback();
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }

        }
    }
}
