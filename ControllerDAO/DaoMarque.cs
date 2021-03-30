using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.ControllerDAO
{
    class DaoMarque : DaoController
    {


        public DaoMarque()
        {

        }

        public void AddMarque(string Name)
        {
            if (FindReference(Name, "RefMarque", "Marques") == 0)
            {
                using (var Connection = GetSqLiteConnection())
                {
                    Connection.Open();
                    try
                    {
                        using (var Query = new SQLiteCommand(Connection))
                        {
                            Query.CommandText = "INSERT INTO MARQUES VALUES(NULL,@Name)";
                            Query.Parameters.AddWithValue("@Name", Name);
                            Query.Prepare();
                            Query.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Problem in AddMarque function : " + e.Message);
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }
        }
        private void RemoveArticleByMarque(int ReferenceMarque)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM ARTICLES WHERE RefMarque = @ReferenceMarque";
                        Query.Parameters.AddWithValue("@ReferenceMarque", ReferenceMarque);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveArticleByMarque function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        public void RemoveMarqueByName(string Name)
        {
            // Delete les articles qui ont la marque passée en paramètre
            RemoveArticleByMarque(FindReference(Name, "RefMarque", "Marques"));
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM MARQUES WHERE Nom = @Name";
                        Query.Parameters.AddWithValue("@Name", Name);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveMarqueByName function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }


        public Marques ListAllMarques()
        {
            Marques TmpMarques = new Marques();
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "Select * FROM Marques";
                        SQLiteDataReader ResultSet = Query.ExecuteReader();
                        while (ResultSet.Read())
                        {
                            TmpMarques.AddMarque(new Marque(Convert.ToString(ResultSet["nom"])));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in ListAllMarques function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return TmpMarques;
        }

        public void ModifyMarque(string CurrentName, string NewName)
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Cmd = new SQLiteCommand(Connection))
                    {
                        Cmd.CommandText = "UPDATE Marques SET Nom = @NewName Where RefMarque = @ReferenceMarque";
                        Cmd.Parameters.AddWithValue("@ReferenceMarque", FindReference(CurrentName, "RefMarque", "Marques"));
                        Cmd.Parameters.AddWithValue("@NewName", NewName);
                        Cmd.Prepare();
                        Cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in ModifyMarque function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }



    }
}
