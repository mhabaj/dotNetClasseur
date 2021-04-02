using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.ControllerDAO
{
    class DaoSousFamille : DaoController
    {

        public DaoSousFamille()
        {

        }


        public void AddSousFamille(SousFamille SousFamilleToAdd)
        {
            if (FindReference(SousFamilleToAdd.Name, "RefSousFamille", "SousFamilles") == 0)
            {
                int TmpRefFamille = FindReference(SousFamilleToAdd.Famille.ToString(), "RefFamille", "Familles");
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
        public void RemoveSousFamilleByName(string Name)
        {
            int RefSousFamille = FindReference(Name, "RefSousFamille", "SousFamilles");
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
                        Query.Parameters.AddWithValue("@ReferenceSousFamille", FindReference(CurrentName, "RefSousFamille", "SousFamilles"));
                        Query.Parameters.AddWithValue("@newName", NewName);
                        Query.Parameters.AddWithValue("@ReferenceFamille", FindReference(NewFamille.Name, "RefFamille", "Familles"));
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
