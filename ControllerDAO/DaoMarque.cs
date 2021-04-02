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
    /// DAO class of for the Marque object, allows us to interact with the database (related to the Marque row).
    /// </summary>
    class DaoMarque : DaoController
    {
        /// <summary>
        /// default constructor of the class. Does nothing.
        /// </summary>
        public DaoMarque()
        {

        }

        /// <summary>
        /// method to add a Marque in the database at the row concerned. (Name in parameter)
        /// </summary>
        /// <param name="Name"></param>
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

        /// <summary>
        /// method to delete a Marque from the the database by giving its ReferenceMarque(id) into the parameters.
        /// </summary>
        /// <param name="ReferenceMarque"></param>
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

        /// <summary>
        /// method to delete a Marque from the database using its Name.
        /// </summary>
        /// <param name="Name"></param>
        public void RemoveMarqueByName(string Name)
        {
            // Delete the articles containing the marque in them.
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

        /// <summary>
        /// method to get all the Marques of the database and return it as a List of Marque (Marques object)
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method to update the values of a Marque in the database.
        /// </summary>
        /// <param name="CurrentName"></param>
        /// <param name="NewName"></param>
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
