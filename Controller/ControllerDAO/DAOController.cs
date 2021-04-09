using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Function that allows us to empty all the tables of the database.
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
                        System.Windows.Forms.MessageBox.Show("Problem in EmptyDatabase function : " + e.Message);
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Method to find the reference of any table and collumn name and return it(int).
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ColumnName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public int FindReference(string Name, string ColumnName, string TableName)
        {
            int idToReturn = 0; //in the Database the idToReturn is Ref<NameOfTheTable>

            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (SQLiteCommand Query = new SQLiteCommand(Connection))
                    {
                        if (TableName.Equals("Familles"))
                        {
                            Query.CommandText = "SELECT RefFamille FROM FAMILLES WHERE Nom LIKE @NOM";
                            Query.Parameters.AddWithValue("@Nom", Name);
                        }
                        else if (TableName.Equals("SousFamilles"))
                        {
                            Query.CommandText = "SELECT RefSousFamille FROM SOUSFAMILLES WHERE Nom LIKE @NOM";
                            Query.Parameters.AddWithValue("@Nom", Name);
                        }
                        else
                        {
                            Query.CommandText = "SELECT RefMarque FROM Marques WHERE Nom LIKE @NOM";
                            Query.Parameters.AddWithValue("@Nom", Name);
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
                    System.Windows.Forms.MessageBox.Show("Problem in FindReference function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return idToReturn;
        }

        /// <summary>
        /// Method to find the "SousFamille" using its Famille's Reference(idToReturn) and return the concerned list of SousFamille References(ids).
        /// </summary>
        /// <param name="IdFamille"></param>
        /// <returns></returns>
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
                    System.Windows.Forms.MessageBox.Show("Problem in GetRefSousFamilleByFamille function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return RefList;
        }

        /// <summary>
        /// Method to find the "SousFamille" using its Reference(idToReturn) and return the concerned SousFamille Object.
        /// </summary>
        /// <param name="Reference"></param>
        /// <returns></returns>
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
                        Query.CommandText = "SELECT * FROM SousFamilles WHERE RefSousFamille=" + Reference;
                        SQLiteDataReader ResultSet = Query.ExecuteReader();
                        while (ResultSet.Read())
                        {
                            LaSousFamilleRecherchee = new SousFamille(Convert.ToString(ResultSet["nom"]), FindFamilleByRef(Convert.ToInt32(ResultSet["RefFamille"])));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in FindSousFamilleByRef function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return LaSousFamilleRecherchee;
        }

        /// <summary>
        /// Method to find the "Famille" using its Reference(idToReturn) and return the Famille object concerned.
        /// </summary>
        /// <param name="Reference"></param>
        /// <returns></returns>
        public Famille FindFamilleByRef(int Reference)
        {
            Famille LaFamilleRecherchee = null;
            using(var Connection = GetSqLiteConnection())
            {
                Connection.Open();

                try
                {
                    using (var Command = new SQLiteCommand(Connection))
                    {
                        Command.CommandText = "SELECT * FROM Familles WHERE RefFamille=" + Reference;
                        SQLiteDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            LaFamilleRecherchee = new Famille(Convert.ToString(Reader["nom"]));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in FindFamilleByRef function : " + e.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            return LaFamilleRecherchee;
        }

        /// <summary>
        /// Method to find the "Marque" using its Reference(idToReturn) and return the Marque object concerned.
        /// </summary>
        /// <param name="Reference"></param>
        /// <returns></returns>
        public Marque FindMarqueByRef(int Reference)
        {
            Marque LaMarqueRecherchee = null;
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();

                try
                {
                    using (var Command = new SQLiteCommand(Connection))
                    {
                        Command.CommandText = "SELECT * FROM Marques WHERE RefMarque=" + Reference;
                        SQLiteDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            LaMarqueRecherchee = new Marque(Convert.ToString(Reader["nom"]));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problem in FindMarqueByRef function : " + e.Message);
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
