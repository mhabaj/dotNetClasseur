using Bacchus.ControllerDAO;
using Bacchus.Model;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bacchus.Controller
{
    /// <summary>
    /// Class FileManager, contains that methods to read and treat the data contained into the csv files.
    /// </summary>
    class FileManager
    {

        public string Filepath { get; set; } //path of the file in the system.

        /// <summary>
        /// Default constructor of class
        /// </summary>
        public FileManager()
        {
            
        }

        /// <summary>
        /// Import a csv file, read it and use it's data to fill the database, there are 2 integration modes (by adding the data to the database or overwriting the database wwith new data).
        /// </summary>
        /// <param name="IntegrationMode">True : overwrite, false: append</param>
        /// <param name="ProgressBar">progress bar to fill</param>
        public void ImportCsvFile(bool IntegrationMode, ProgressBar ProgressBar)
        {
          
            //variables that will recieve that data and that will be used in a foreach loop.
            Familles Familles = new Familles();
            Marques Marques = new Marques();
            SousFamilles SousFamilles = new SousFamilles();
            Articles Articles = new Articles();

            //set the ProgressBar values
            ProgressBar.Value = 0;
            ProgressBar.Refresh();
            ProgressBar.Step = 1;

            try
            {
                if (IntegrationMode == true) //verify the integration mode chosen by the user true = overwrite with new data, false = add without overwriting.
                {
                    new DaoController().EmptyDatabase();
                }

                using (var DataSource = new StreamReader(Filepath, Encoding.Default))
                {
                    //section of code that reads the csv file and set a separator which is ";" in this case.
                    while (!DataSource.EndOfStream)
                    {
                        var Separator = DataSource.ReadLine().Split(';');
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
                    new DaoFamille().AddFamille(Famille.Name); //add Famille in the database

                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                }
                foreach (Marque Marque in Marques)
                {
                    new DaoMarque().AddMarque(Marque.Name); //add Marche in the database

                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                }
                foreach (SousFamille SousFamille in SousFamilles)
                {
                    new DaoSousFamille().AddSousFamille(SousFamille); //add SousFamille in the database

                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                }
                foreach (Article Article in Articles)
                {
                    new DaoArticle().AddArticle(Article); //add Article in the database

                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                }

                MessageBox.Show("Données importées correctement.");
            }
            catch (Exception e)
            {
                MessageBox.Show("ERREUR : fichier non selectionné ou non valide! ");
                ProgressBar.Visible = false;
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Export the data of the sqllite database into a csv file, you must specify the name of the file in the parameters.
        /// </summary>
        /// <param name="NameOfExportedFile"> Name of the exported File </param>
        public void ExportCsvFile(string NameOfExportedFile)
        {
            try
            {
                var CsvFile = new StringBuilder(); //set the csv file

                var Categories = string.Format("{0};{1};{2};{3};{4};{5}", "Description", "Ref", "Marque", "Famille", "Sous-Famille", "Prix H.T."); //name of the rows
                CsvFile.AppendLine(Categories);
                Articles tmpArticles = new DaoArticle().GetArticles(); //get all the articles of the database
                
                if (tmpArticles != null)
                {
                    foreach (Article Article in tmpArticles)
                    {
                        var Adding = string.Format("{0};{1};{2};{3};{4};{5}", Article.Description, Article.RefArticle, Article.Marque.Name, Article.SousFamille.Famille.Name, Article.SousFamille.Name, Article.Prix);
                        CsvFile.AppendLine(Adding); //append each article into the csv file.
                    }
                    File.WriteAllText(NameOfExportedFile + ".csv", CsvFile.ToString(), Encoding.Default); //generate the csv file

                    MessageBox.Show("Données exportées correctement.");
                }
                else
                {
                    MessageBox.Show("Problèmes avec les données à importer : données vide.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERREUR : export impossible");
                Console.WriteLine(e.Message);
            }
        }
    }
}
