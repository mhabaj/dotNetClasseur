using Bacchus.Model;
using System;
using System.Data.SQLite;

namespace Bacchus.ControllerDAO
{
    /// <summary>
    /// DAO class for the Famille row of the database, allows us to interact with the datas of that row through the functions present here.
    /// </summary>
    class DaoFamille : DaoController
    {

        /// <summary>
        /// Method the get all the Familles of the database into one list that will be returned (Familles is a list of Famille).
        /// </summary>
        /// <returns> Familles object, else null </returns>
        public Familles GetFamilles()
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
                    System.Windows.Forms.MessageBox.Show("Problem in ListAllFamilles function ");
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
        /// Modify Famille in database (by giving the old name and the new name of the Famille in parameter).
        /// </summary>
        /// <param name="OldFamilleName">Old Famille Name</param>
        /// <param name="NewFamilleName">New Famille Name</param>
        public void ModifyFamille(string OldFamilleName, string NewFamilleName)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "UPDATE Familles SET Nom = @Name Where RefFamille = @ReferenceFamille";
                        Query.Parameters.AddWithValue("@ReferenceFamille", GetRefObject(OldFamilleName, "RefFamille", "Familles"));
                        Query.Parameters.AddWithValue("@Name", NewFamilleName);
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

        /// <summary>
        /// Add a new Famille to database
        /// </summary>
        /// <param name="Name"> New Famille Name </param>
        public void AddFamille(string Name)
        {
            if (GetRefObject(Name, "RefFamille", "Familles") == 0)
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
                        System.Windows.Forms.MessageBox.Show("Problem in AddFamille function");
                        Console.WriteLine(e.Message);

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
        /// <param name="FamilyName"> string of the family name </param>
        public void RemoveFamille(string FamilyName)
        {
            //remove the all the articles of the SousFamille and all the SousFamille of the Famille.
            foreach (int ReferenceSousFamille in GetRefSousFamilleByFamille(GetRefObject(FamilyName, "RefFamille", "Familles")))
                RemoveArticleBySousFamilleRef(ReferenceSousFamille);
                RemoveSousFamilleByFamilleRef(GetRefObject(FamilyName, "RefFamille", "Familles"));

            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM FAMILLES WHERE Nom LIKE @Name"; //then remove the Famille of the database.
                        Query.Parameters.AddWithValue("@Name", FamilyName);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveFamilleByName function ");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Method to delete an Article by its SousFamille's Reference from database.
        /// </summary>
        /// <param name="RefSousFamille"> SousFamille reference </param>
        private void RemoveArticleBySousFamilleRef(int RefSousFamille)
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
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveArticleBySousFamille function");
                    Console.WriteLine(e.Message);
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
        /// <param name="RefFamilleToRemove"> int RefFamille reference </param>
        private void RemoveSousFamilleByFamilleRef(int RefFamilleToRemove)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM SOUSFAMILLES WHERE RefFamille = @ReferenceFamille";
                        Query.Parameters.AddWithValue("@ReferenceFamille", RefFamilleToRemove);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveSousFamilleByFamille function");
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
