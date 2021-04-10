using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Bacchus.ControllerDAO
{
    /// <summary>
    /// DAO Controller class, mother class of all the other DAO classes, concentrates the general méthods of all the rows of the database.
    /// </summary>
    class DaoController
    {
        private string DatabaseFilePath; //path of the SQLite database.

        /// <summary>
        /// default constructor of the class, does nothing.
        /// </summary>
        public DaoController()
        {
            // Recover the Executable Path In the system and replace it's name with the database file name.
            string AppDefaultDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"Bacchus.SQLite");
            DatabaseFilePath = AppDefaultDirectory;
            
        }

        /// <summary>
        /// Method the create a connection to the database.
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetSqLiteConnection()
        {
            SQLiteConnection DbConnection = new SQLiteConnection("data source=" + DatabaseFilePath);//connects to the database
            return DbConnection;
        }

        /// <summary>
        /// Empty all the tables of the database.
        /// </summary>
        public void EmptyDatabase()
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                string SqlToExecute = "DELETE FROM Articles;" +
                                 " DELETE FROM Familles;" +
                                 " DELETE FROM SousFamilles;" +
                                 " DELETE FROM Marques;" +
                                 "UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME = 'Familles';" +
                                 "UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME = 'Articles';" +
                                 "UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME = 'SousFamilles';" +
                                 "UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME = 'Marques'";
                using (SQLiteCommand Query = new SQLiteCommand(SqlToExecute, Connection))
                {
                    try
                    {
                        Query.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Problem in EmptyDatabase function ");
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
        /// Method to find the reference of any object(Famille, SousFamille, Marque) given it's name, the table and column name in database.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ColumnName"></param>
        /// <param name="TableName"></param>
        /// <returns>Id of the required object</returns>
        public int GetRefObject(string Name, string ColumnName, string TableName)
        {
            int idToReturn = 0; //in the Database the idToReturn is Ref<NameOfTheTable>

            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (SQLiteCommand Query = new SQLiteCommand(Connection))
                    {if (TableName.Equals("SousFamilles"))
                        {
                            Query.CommandText = "SELECT RefSousFamille FROM SOUSFAMILLES WHERE Nom LIKE @Name";
                            Query.Parameters.AddWithValue("@Name", Name);
                        }
                        else if (TableName.Equals("Familles"))
                        {
                            Query.CommandText = "SELECT RefFamille FROM FAMILLES WHERE Nom LIKE @Name";
                            Query.Parameters.AddWithValue("@Name", Name);
                        }
                        else
                        {
                            Query.CommandText = "SELECT RefMarque FROM Marques WHERE Nom LIKE @Name";
                            Query.Parameters.AddWithValue("@Name", Name);
                        }
                        Query.Prepare();

                        //reading the data fetched
                        using (SQLiteDataReader ResultSet = Query.ExecuteReader())
                        {
                            while (ResultSet.Read())
                            {
                                if (!ResultSet.IsDBNull(0))
                                {
                                    idToReturn = ResultSet.GetInt32(0); //we read the data and paste it into the idToReturn variable.
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in GetRefObject function ");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
            return idToReturn;
        }

        /// <summary>
        /// Method to find the "SousFamille" using its Famille's Reference(IdFamille) and return the concerned list of SousFamille References(ids).
        /// </summary>
        /// <param name="IdFamille">Famille reference</param>
        /// <returns>the concerned list of SousFamille References(ids)</returns>
        public List<int> GetRefSousFamilleByFamille(int IdFamille)
        {
            List<int> RefList = new List<int>();
            using(var Connection = GetSqLiteConnection())
            {
                Connection.Open();

                try
                {
                    using (SQLiteCommand Query = new SQLiteCommand(Connection))
                    {
                        Query.CommandText = "SELECT RefSousFamille FROM SousFamilles WHERE RefFamille = @IdFamille";
                        Query.Parameters.AddWithValue("@IdFamille", IdFamille);
                        Query.Prepare();

                        //reading the data fetched
                        using (SQLiteDataReader ResultSet = Query.ExecuteReader())
                        {
                            while (ResultSet.Read())
                            {
                                if (!ResultSet.IsDBNull(0))
                                {
                                    RefList.Add(ResultSet.GetInt32(0));
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in GetRefSousFamilleByFamille function ");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
            return RefList;
        }

        /// <summary>
        /// Find the "SousFamille" using its Reference(Reference) and return the concerned SousFamille Object.
        /// </summary>
        /// <param name="Reference"> SousFamille Reference </param>
        /// <returns> the concerned SousFamille Object </returns>
        public SousFamille FindSousFamilleByRef(int Reference)
        {
            SousFamille LaSousFamilleRecherchee = null;
            using(var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                
                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                       
                        Query.CommandText = "SELECT * FROM SousFamilles WHERE RefSousFamille = @IdSousFamille";
                        Query.Parameters.AddWithValue("@IdSousFamille", Reference);
                        Query.Prepare();


                        SQLiteDataReader ResultSet = Query.ExecuteReader();
                        while (ResultSet.Read())
                        {
                            LaSousFamilleRecherchee = new SousFamille(Convert.ToString(ResultSet["nom"]), FindFamilleByRef(Convert.ToInt32(ResultSet["RefFamille"])));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in FindSousFamilleByRef function");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
            return LaSousFamilleRecherchee;
        }

        /// <summary>
        /// Method to find the "Famille" using its Reference(Reference) and return the Famille object concerned.
        /// </summary>
        /// <param name="Reference"> Famille Reference </param>
        /// <returns> the concerned Famille Object </returns>
        public Famille FindFamilleByRef(int Reference)
        {
            Famille LaFamilleRecherchee = null;
            using(var Connection = GetSqLiteConnection())
            {
                Connection.Open();

                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                      
                        Query.CommandText = "SELECT * FROM Familles WHERE RefFamille = @IdFamille";
                        Query.Parameters.AddWithValue("@IdFamille", Reference);
                        Query.Prepare();
                       
                        SQLiteDataReader ResultSet = Query.ExecuteReader();
                        while (ResultSet.Read())
                        {
                            LaFamilleRecherchee = new Famille(Convert.ToString(ResultSet["nom"]));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in FindFamilleByRef function ");
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Connection.Close();
                }
            }
            return LaFamilleRecherchee;
        }

        /// <summary>
        /// Find the "Marque" using its Reference(Reference) and return the Marque object concerned.
        /// </summary>
        /// <param name="Reference"> Reference Marque </param>
        /// <returns> Marque Object found </returns>
        public Marque FindMarqueByRef(int Reference)
        {
            Marque LaMarqueRecherchee = null;
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();

                try
                {
                    using (var Query = new SQLiteCommand(Connection))
                    {
                        
                        Query.CommandText = "SELECT * FROM Marques WHERE RefMarque = @IdMarque";
                        Query.Parameters.AddWithValue("@IdMarque", Reference);
                        Query.Prepare();

                        SQLiteDataReader Reader = Query.ExecuteReader();
                        while (Reader.Read())
                        {
                            LaMarqueRecherchee = new Marque(Convert.ToString(Reader["nom"]));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in FindMarqueByRef function ");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return LaMarqueRecherchee;
        }
    }
}
