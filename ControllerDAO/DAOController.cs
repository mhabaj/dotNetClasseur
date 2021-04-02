using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.ControllerDAO
{
    class DaoController
    {
        private readonly string DatabaseFilePath = @"URI=file:..\..\Bacchus.SQLite";

        public DaoController()
        {
        }

        public SQLiteConnection GetSqLiteConnection()
        {
            SQLiteConnection DbConnection = new SQLiteConnection(DatabaseFilePath);//connects to the database
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
                                 " DELETE FROM Marques";
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
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ColumnName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public int FindReference(string Name, string ColumnName, string TableName)
        {
            int Id = 0; //in the Database the Id is Ref<NameOfTheTable>

            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                try
                {
                    using (SQLiteCommand Query = new SQLiteCommand(Connection))
                    {
                        if (TableName.Equals("SousFamilles")) //the table name is "SousFamilles"
                        {
                            Query.CommandText = "SELECT RefFamille FROM Familles WHERE Nom LIKE @Name";
                            Query.Parameters.AddWithValue("@Name", Name);
                        }
                        else if (TableName.Equals("Marques")) //the table name is "Marques"
                        {
                            Query.CommandText = "SELECT RefMarque FROM Marques WHERE Nom LIKE @Name";
                            Query.Parameters.AddWithValue("@Name", Name);
                        }
                        else //the table name is "Familles"
                        {
                            Query.CommandText = "SELECT RefSousFamille FROM  SousFamilles WHERE Nom LIKE @Name";
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
                                    Id = ResultSet.GetInt32(0); //we read the data and paste it into the Id var
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
            return Id;
        }

        /// <summary>
        /// 
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
        /// Method to find the "SousFamille" using its Reference(Id)
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
        /// Method to find the "Famille" using its Reference(Id)
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
        /// Method to find the "Marque" using its Reference(Id)
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
