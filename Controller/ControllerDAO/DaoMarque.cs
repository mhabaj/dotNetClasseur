using Bacchus.Model;
using System;
using System.Data.SQLite;

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
        /// Return all the Marques of the database and as a List of Marque (Marques object)
        /// </summary>
        /// <returns>Marques Object</returns>
        public Marques GetMarques()
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
                    System.Windows.Forms.MessageBox.Show("Problem in ListAllMarques function");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
            return TmpMarques;
        }

        /// <summary>
        /// Add a Marque in the database at the row concerned. (Name in parameter)
        /// </summary>
        /// <param name="Name">Marque Name</param>
        public void AddMarque(string Name)
        {
            if (GetRefObject(Name, "RefMarque", "Marques") == 0)
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
                        System.Windows.Forms.MessageBox.Show("Problem in AddMarque function");
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
        /// Modify values of a Marque in the database.
        /// </summary>
        /// <param name="CurrentName">Current Marque Name</param>
        /// <param name="NewName">New Marque Name</param>
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
                        Cmd.Parameters.AddWithValue("@ReferenceMarque", GetRefObject(CurrentName, "RefMarque", "Marques"));
                        Cmd.Parameters.AddWithValue("@NewName", NewName);
                        Cmd.Prepare();
                        Cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in ModifyMarque function");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// method to delete a Marque from the the database by giving its ReferenceMarque(id) into the parameters.
        /// </summary>
        /// <param name="ReferenceMarque"> Marque Reference </param>
        private void RemoveArticleByMarqueRef(int ReferenceMarque)
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
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveArticleByMarque function");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
        }



        /// <summary>
        /// Remove a Marque from the database using its Name.
        /// </summary>
        /// <param name="Name">Marque Name</param>
        public void RemoveMarqueByName(string Name)
        {
            // Delete the articles containing the marque in them.
            RemoveArticleByMarqueRef(GetRefObject(Name, "RefMarque", "Marques"));
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "DELETE FROM MARQUES WHERE Nom LIKE @Name";
                        Query.Parameters.AddWithValue("@Name", Name);
                        Query.Prepare();
                        Query.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in RemoveMarqueByName function ");
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
