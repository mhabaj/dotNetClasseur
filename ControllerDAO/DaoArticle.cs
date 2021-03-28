using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.ControllerDAO
{
    class DaoArticle : DaoController
    {
        public DaoArticle()
        {

        }

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


        public void AddArticle(Article ArticleToAdd)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();

                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        if (GetQuantite(ArticleToAdd.ReferenceArticle) == 0)//If article doesnt already Exists

                        {
                            Query.CommandText = "INSERT INTO Articles VALUES(@idArticle,@Description,@ReferenceSousFamille,@ReferenceMarque,@Prix,@Quantite)";
                            Query.Parameters.AddWithValue("@idArticle", ArticleToAdd.ReferenceArticle);
                            Query.Parameters.AddWithValue("@Description", ArticleToAdd.Description);
                            Query.Parameters.AddWithValue("@ReferenceSousFamille", FindReference(ArticleToAdd.SousFamille.Name, "RefSousFamille", "SousFamilles"));
                            Query.Parameters.AddWithValue("@ReferenceMarque", FindReference(ArticleToAdd.Marque.Name, "RefMarque", "Marques"));
                            Query.Parameters.AddWithValue("@Prix", ArticleToAdd.Prix);
                            Query.Parameters.AddWithValue("@Quantite", ArticleToAdd.Quantite);
                        }
                        else //add quantity to existing total quantity
                        {
                            Query.CommandText = "UPDATE Articles SET QUANTITE = @Qte WHERE RefArticle =@RefArticle";
                            Query.Parameters.AddWithValue("@Qte", GetQuantite(ArticleToAdd.ReferenceArticle) + ArticleToAdd.Quantite);
                            Query.Parameters.AddWithValue("@RefArticle", ArticleToAdd.ReferenceArticle);
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







    }
}
