using Bacchus.ControllerDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Model;
using System.IO;

namespace Bacchus.Controller
{
    /// <summary>
    /// Class ParseurCsv, contains that methods to read and treat the data contained into the csv files.
    /// </summary>
    class ParseurCsv
    {
        public string Filepath { get; set; } //path of the file in the system.

        /// <summary>
        /// default constructor of class, does nothing.
        /// </summary>
        public ParseurCsv()
        {

        }

        /// <summary>
        /// Method to import a csv file, read it and use it's data to fill the database, there are 2 integration modes (by adding the data to the database or overwriting the database wwith new data).
        /// </summary>
        /// <param name="IntegrationMode"></param>
        /// <param name="ProgressBar"></param>
        public void ImportCsvFile(bool IntegrationMode, ProgressBar ProgressBar)
        {
            //set the ProgressBar values
            ProgressBar.Value = 0;
            ProgressBar.Refresh();
            ProgressBar.Step = 1;

            if (IntegrationMode == true) //verify the integration mode chosen by the user true = overwrite with new data, false = add without overwriting.
            {
                DaoController DAO = new DaoController();
                DAO.EmptyDatabase();
            }

            //variables that will recieve that data and that will be used in a foreach loop.
            Familles Familles = new Familles();
            Marques Marques = new Marques();
            SousFamilles SousFamilles = new SousFamilles();
            Articles Articles = new Articles();

            try
            {
                using (var Read = new StreamReader(Filepath, Encoding.Default))
                {
                    //section of code that reads the csv file and set a separator which is ";" in this case.
                    while (!Read.EndOfStream)
                    {
                        var Separator = Read.ReadLine().Split(';');
                        if (Double.TryParse(Separator[5], out double number))
                        {
                            Famille Famille = new Famille(Separator[3]);
                            Familles.AddFamille(Famille);
                            Marque Marque = new Marque(Separator[2]);
                            Marques.AddMarque(Marque);
                            SousFamille SousFamille = new SousFamille(Separator[4], Famille);
                            SousFamilles.AddSousFamille(SousFamille);
                            Article Article = new Article(Separator[1], Separator[0], SousFamille, Marque, Convert.ToDouble(Separator[5]));
                            Articles.AddArticle(Article);
                        }
                    }
                }
                ProgressBar.Maximum = Familles.TotalSize + SousFamilles.TotalSize + Articles.TotalSize + Marques.TotalSize;

                //section of the code that go through each variables and constructs the whole family into the database
                foreach (Famille Famille in Familles)
                {
                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                    new DaoFamille().AddFamille(Famille.Name); //add Famille in the database
                }
                foreach (Marque Marque in Marques)
                {
                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                    new DaoMarque().AddMarque(Marque.Name); //add Marche in the database
                }
                foreach (SousFamille SousFamille in SousFamilles)
                {
                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                    new DaoSousFamille().AddSousFamille(SousFamille); //add SousFamille in the database
                }
                foreach (Article Article in Articles)
                {
                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                    new DaoArticle().AddArticle(Article); //add Article in the database
                }
                MessageBox.Show("Les données ont été importées correctement.");
            }
            catch (Exception e)
            {
                MessageBox.Show("ERREUR : fichier non selectionné ou non valide." + e);
            }
        }

        /// <summary>
        /// Method used to export the data of the sqllite database into a csv file, you must specify the name of the file in the parameters.
        /// </summary>
        /// <param name="NameOfExportedFile"></param>
        public void ExportCsvFile(string NameOfExportedFile)
        {
            try
            {
                var CsvFile = new StringBuilder(); //set the csv file

                var Categories = string.Format("{0};{1};{2};{3};{4};{5}", "Description", "Ref", "Marque", "Famille", "Sous-Famille", "Prix H.T."); //name of the rows
                CsvFile.AppendLine(Categories);
                Articles tmpArticles = new DaoArticle().ListAllArticles(); //get all the articles of the database
                
                if (tmpArticles != null)
                {
                    foreach (Article Article in tmpArticles)
                    {
                        var Adding = string.Format("{0};{1};{2};{3};{4};{5}", Article.Description, Article.ReferenceArticle, Article.Marque.Name, Article.SousFamille.Famille.Name, Article.SousFamille.Name, Article.Prix);
                        CsvFile.AppendLine(Adding); //append each article into the csv file.
                    }
                    File.WriteAllText(NameOfExportedFile + ".csv", CsvFile.ToString(), Encoding.Default); //generate the csv file

                    MessageBox.Show("Données exportées correctement.");
                }
                else
                {
                    MessageBox.Show("problèmes avec les données à importer : donnée vide.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERREUR : export impossible: "+ e.Message);
            }


        }
    }
}
