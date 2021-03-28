using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.ControllerDAO
{
    class Dao
    {
        private readonly string DatabaseFilePath = @"URI=file:..\..\Bacchus.SQLite";

        public Dao()
        {
        }

        public SQLiteConnection GetSqLiteConnection()
        {
            return new SQLiteConnection(DatabaseFilePath);//connects to the database
        }

        /// <summary>
        /// Function that allows us to empty all the tables of the database.
        /// </summary>
        public void EmptyDatabase()
        {
            using (var Connection = GetSqLiteConnection())
            {
                Connection.Open();
                string SqlCommand = "DELETE FROM Articles;" +
                                 " DELETE FROM Familles;" +
                                 " DELETE FROM SousFamilles;" +
                                 " DELETE FROM Marques";
                using (SQLiteCommand Command = new SQLiteCommand(SqlCommand, Connection))
                {
                    try
                    {
                        Command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Problem in EmptyDatabase function : " + e.Message);
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

                using (SQLiteCommand Command = new SQLiteCommand(Connection))
                {
                    if(TableName.Equals("SousFamilles")) //the table name is "SousFamilles"
                    {
                        Command.CommandText = "SELECT RefFamille FROM Familles WHERE Nom = @Name";
                        Command.Parameters.AddWithValue("@Name", Name);
                    } else if(TableName.Equals("Marques")) //the table name is "Marques"
                    {
                        Command.CommandText = "SELECT RefMarque FROM Marques WHERE Nom = @Name";
                        Command.Parameters.AddWithValue("@Name", Name);
                    }
                    else //the table name is "Familles"
                    {
                        Command.CommandText = "SELECT RefSousFamille FROM  SousFamilles WHERE Nom = @Name";
                        Command.Parameters.AddWithValue("@Name", Name);
                    }
                    Command.Prepare();

                    //reading the data fetched
                    using(SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        while(Reader.Read())
                        {
                            if(!Reader.IsDBNull(0))
                            {
                                Id = Reader.GetInt32(0); //we read the data and paste it into the Id var
                            }
                        }
                    }
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
                using (SQLiteCommand Command = new SQLiteCommand(Connection))
                {
                    Command.CommandText = "SELECT RefSousFamille FROM SousFamilles WHERE RefFamille = @IdFamille";
                    Command.Parameters.AddWithValue("@IdFamille", IdFamille);
                    Command.Prepare();

                    //reading the data fetched
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            if (!Reader.IsDBNull(0))
                            {
                                RefList.Add(Reader.GetInt32(0));
                            }
                        }
                    }
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
                using(var Command = new SQLiteCommand(Connection))
                {
                    Command.CommandText = "SELECT * FROM SousFamilles WHERE RefSousFamille=" + Reference;
                    SQLiteDataReader Reader = Command.ExecuteReader();
                    while(Reader.Read())
                    {
                        LaSousFamilleRecherchee = new SousFamille(Convert.ToString(Reader["nom"]), FindFamilleByRef(Convert.ToInt32(Reader["RefFamille"])) );
                    }
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
                using(var Command = new SQLiteCommand(Connection))
                {
                    Command.CommandText = "SELECT * FROM Familles WHERE RefFamille=" + Reference;
                    SQLiteDataReader Reader = Command.ExecuteReader();
                    while(Reader.Read())
                    {
                        LaFamilleRecherchee = new Famille(Convert.ToString(Reader["nom"]));
                    }
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
                using (var Command = new SQLiteCommand(Connection))
                {
                    Command.CommandText = "SELECT * FROM Marque WHERE RefMarque=" + Reference;
                    SQLiteDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        LaMarqueRecherchee = new Marque(Convert.ToString(Reader["nom"]));
                    }
                }
            }
            return LaMarqueRecherchee;
        }
    }
}
