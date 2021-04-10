using Bacchus.Model;
using System;
using System.Data.SQLite;

namespace Bacchus.ControllerDAO
{
    /// <summary>
    /// DataAccessObject class for the SousFamille class, allows us to interact with the database(everything related to the SousFamille row more precisely) through the functions available here.
    /// </summary>
    class DaoSousFamille : DaoController
    {
        /// <summary>
        /// default constructor of the class, does nothing.
        /// </summary>
        public DaoSousFamille()
        {

        }

        /// <summary>
        /// Return all the SousFamilles as a SousFamilles object . (from the database)
        /// </summary>
        /// <returns> SousFamilles Object </returns>
        public SousFamilles GetSousFamilles()
        {
            SousFamilles SousFamilles = new SousFamilles();
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "Select * FROM SousFamilles";
                        SQLiteDataReader ResultSet = Query.ExecuteReader();
                        while (ResultSet.Read())
                        {
                            SousFamilles.AddSousFamille(new SousFamille(Convert.ToString(ResultSet["nom"]), FindFamilleByRef(Convert.ToInt32(ResultSet["RefFamille"]))));
                        }
                    }
                    return SousFamilles;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in ListAllSousFamilles function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return SousFamilles;
        }



        /// <summary>
        /// Add a SousFamille into the database by giving a SousFamille in parameter.
        /// </summary>
        /// <param name="SousFamilleToAdd"> SousFamille Object to add </param>
        public void AddSousFamille(SousFamille SousFamilleToAdd)
        {
            if (GetRefObject(SousFamilleToAdd.Name, "RefSousFamille", "SousFamilles") == 0)
            {
                using (var Connection = GetSqLiteConnection())
                {
                    Connection.Open();
                    try
                    {
                        int TmpRefFamille = GetRefObject(SousFamilleToAdd.Famille.Name, "RefFamille", "Familles");

                        using (var Query = new SQLiteCommand(Connection))
                        {
                            Query.CommandText = "INSERT INTO SousFamilles VALUES(NULL,@RefFamille,@Name)";
                            Query.Parameters.AddWithValue("@RefFamille", TmpRefFamille);
                            Query.Parameters.AddWithValue("@Name", SousFamilleToAdd.Name);
                            Query.Prepare();
                            Query.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Problem in AddSousFamille function ");
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
        /// Modify a SousFamille in the database.
        /// </summary>
        /// <param name="CurrentName">Current SousFamille Name</param>
        /// <param name="NewName"> New SousFamille Name </param>
        /// <param name="NewFamille"> New belonging Famille </param>
        public void ModifySousFamille(string CurrentName, string NewName, Famille NewFamille)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "UPDATE SousFamilles SET Nom = @newName, RefFamille = @ReferenceFamille Where RefSousFamille = @ReferenceSousFamille";
                        Query.Parameters.AddWithValue("@ReferenceSousFamille", GetRefObject(CurrentName, "RefSousFamille", "SousFamilles"));
                        Query.Parameters.AddWithValue("@newName", NewName);
                        Query.Parameters.AddWithValue("@ReferenceFamille", GetRefObject(NewFamille.Name, "RefFamille", "Familles"));
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in ModifySousFamille function");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
        }




        /// <summary>
        /// Remove a SousFamille from the database given it's name.
        /// </summary>
        /// <param name="Name">string SousFamille Name</param>
        public void RemoveSousFamilleByName(string Name)
        {
            int RefSousFamille = GetRefObject(Name, "RefSousFamille", "SousFamilles");
            RemoveArticleBySousFamilleRef(RefSousFamille);
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM SOUSFAMILLES WHERE Nom LIKE @Name";
                        Query.Parameters.AddWithValue("@Name", Name);

                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveSousFamilleByName function ");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
        }

      

        /// <summary>
        /// Remove an Article(s) from the database by giving the Reference(id) of the SousFamille.
        /// </summary>
        /// <param name="ReferenceSousFamille"> SousFamille Reference </param>
        private void RemoveArticleBySousFamilleRef(int ReferenceSousFamille)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM ARTICLES WHERE RefSousFamille = @ReferenceSousFamille";
                        Query.Parameters.AddWithValue("@ReferenceSousFamille", ReferenceSousFamille);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveArticleBySousFamille function ");
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
