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
        /// Method to insert a SousFamille into the database by giving a SousFamille in parameter.
        /// </summary>
        /// <param name="SousFamilleToAdd"></param>
        public void AddSousFamille(SousFamille SousFamilleToAdd)
        {
            if (GetRefObject(SousFamilleToAdd.Name, "RefSousFamille", "SousFamilles") == 0)
            {
                int TmpRefFamille = GetRefObject(SousFamilleToAdd.Famille.ToString(), "RefFamille", "Familles");
                using (var Connection = GetSqLiteConnection())
                {
                    Connection.Open();
                    try
                    {
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
                        System.Windows.Forms.MessageBox.Show("Problem in AddSousFamille function : " + e.Message);
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }

        }

        /// <summary>
        /// Method to delete a SousFamille from the database by giving its name in parameter.
        /// </summary>
        /// <param name="Name"></param>
        public void RemoveSousFamilleByName(string Name)
        {
            int RefSousFamille = GetRefObject(Name, "RefSousFamille", "SousFamilles");
            RemoveArticleBySousFamille(RefSousFamille);
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM SOUSFAMILLES WHERE Nom = @Name";
                        Query.Parameters.AddWithValue("@Name", Name);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveSousFamilleByName function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Method to get all the SousFamilles into a SousFamilles object which is a list of SousFamille. (from the database)
        /// </summary>
        /// <returns></returns>
        public SousFamilles ListAllSousFamilles()
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
        /// Method to update a SousFamille of the database.
        /// </summary>
        /// <param name="CurrentName"></param>
        /// <param name="NewName"></param>
        /// <param name="NewFamille"></param>
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
                    System.Windows.Forms.MessageBox.Show("Problem in ModifySousFamille function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Method the delete an Article from the database by giving the Reference(id) of his SousFamille.
        /// </summary>
        /// <param name="ReferenceSousFamille"></param>
        private void RemoveArticleBySousFamille(int ReferenceSousFamille)
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
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveArticleBySousFamille function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }












    }
}
