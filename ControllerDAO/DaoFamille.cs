using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.ControllerDAO
{
    /// <summary>
    /// DAO class for the Famille row of the database, allows us to interact with the datas of that row through the functions present here.
    /// </summary>
    class DaoFamille : DaoController
    {
        public void AddFamille(string Name)
        {
            if (FindReference(Name, "RefFamille", "Familles") == 0)
            {
                using (var Connection = GetSqLiteConnection())
                {
                    Connection.Open();
                    try
                    {
                        using (var Query = new SQLiteCommand(Connection))
                        {
                            Query.CommandText = "INSERT INTO Familles VALUES(NULL,@Name)";
                            Query.Parameters.AddWithValue("@Name", Name);
                            Query.Prepare();
                            Query.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Problem in AddFamille function : " + e.Message);
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Method to delete a Famille object by its Name.
        /// </summary>
        /// <param name="Name"></param>
        public void RemoveFamilleByName(string Name)
        {
            //remove the all the articles of the SousFamille and all the SousFamille of the Famille.
            foreach (int ReferenceSousFamille in GetRefSousFamilleByFamille(FindReference(Name, "RefFamille", "Familles")))
                RemoveArticleBySousFamille(ReferenceSousFamille);
                RemoveSousFamilleByFamille(FindReference(Name, "RefFamille", "Familles"));

            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM FAMILLES WHERE Nom = @Name"; //then remove the Famille of the database.
                        Query.Parameters.AddWithValue("@Name", Name);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveFamilleByName function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Method to delete an Article by its SousFamille's Reference from that database.
        /// </summary>
        /// <param name="RefSousFamille"></param>
        private void RemoveArticleBySousFamille(int RefSousFamille)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM ARTICLES WHERE RefSousFamille = @RefSousFamille";
                        Query.Parameters.AddWithValue("@RefSousFamille", RefSousFamille);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveArticleBySousFamille function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Method the delete a SousFamille by its Famille's Reference.
        /// </summary>
        /// <param name="RefFamille"></param>
        private void RemoveSousFamilleByFamille(int RefFamille)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM SOUSFAMILLES WHERE RefFamille = @ReferenceFamille";
                        Query.Parameters.AddWithValue("@ReferenceFamille", RefFamille);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveSousFamilleByFamille function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Method the get all the Familles of the database into one list that will be returned (Familles is a list of Famille).
        /// </summary>
        /// <returns></returns>
        public Familles ListAllFamilles()
        {
            Familles Familles = new Familles();
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "Select * FROM Familles";
                        SQLiteDataReader ResultSet = Query.ExecuteReader();
                        while (ResultSet.Read())
                        {
                            Familles.AddFamille(new Famille(Convert.ToString(ResultSet["nom"])));
                        }
                    }
                    return Familles;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in ListAllFamilles function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return null;
        }

        /// <summary>
        /// Method the update the Famille in the database (by giving the old name and the new name of the Famille in parameter).
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="NewName"></param>
        public void ModifyFamille(string Name, string NewName)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "UPDATE Familles SET Nom = @Name Where RefFamille = @ReferenceFamille";
                        Query.Parameters.AddWithValue("@ReferenceFamille", FindReference(Name, "RefFamille", "Familles"));
                        Query.Parameters.AddWithValue("@Name", NewName);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in ModifyFamille function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }















    }
}
