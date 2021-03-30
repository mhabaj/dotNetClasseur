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
    /// ParseurCsv class which contains the methods used to import and export csv files and populate or save the elements of the database.
    /// </summary>
    class ParseurCsv
    {
        public string Filepath { get; set; }

        /// <summary>
        /// default constructor of the ParseurCsv class.
        /// </summary>
        public ParseurCsv()
        {

        }

        /// <summary>
        /// Method to import the datas of a csv file, we have to specify the integration mode (by overwrite or add).
        /// </summary>
        /// <param name="IntegrationMode"></param>
        /// <param name="ProgressBar"></param>
        public void ImportCsvFile(bool IntegrationMode, ProgressBar ProgressBar)
        {
            //set the ProgressBar 
            ProgressBar.Value = 0;
            ProgressBar.Refresh();
            ProgressBar.Step = 1;

            if (IntegrationMode.Equals(true))
            {
                DaoController DAO = new DaoController();
                DAO.EmptyDatabase();
            }

            //les variables qui vont recevoir les données et qui seront parcourues
            Familles Familles = new Familles();
            Marques Marques = new Marques();
            SousFamilles SousFamilles = new SousFamilles();
            Articles Articles = new Articles();

            try
            {
                using (var Read = new StreamReader(Filepath, Encoding.Default))
                {
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
                            SousFamilles.AddFamille(SousFamille);
                            Article Article = new Article(Separator[1], Separator[0], SousFamille, Marque, Convert.ToDouble(Separator[5]));
                            Articles.AddArticle(Article);
                        }
                    }
                }
                ProgressBar.Maximum = Familles.TotalSize + SousFamilles.TotalSize + Articles.TotalSize + Marques.TotalSize;

                foreach (Famille Famille in Familles)
                {
                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                    new DaoFamille().AddFamille(Famille.Name);
                }
                foreach (Marque Marque in Marques)
                {
                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                    new DaoMarque().AddMarque(Marque.Name);
                }
                foreach (SousFamille SousFamille in SousFamilles)
                {
                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                    new DaoSousFamille().AddSousFamille(SousFamille);
                }
                foreach (Article Article in Articles)
                {
                    ProgressBar.PerformStep();
                    ProgressBar.Update();
                    new DaoArticle().AddArticle(Article);
                }
                MessageBox.Show("Les données ont été importées correctement.");
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Problem ImportCsvFile function : " + e.Message);

                MessageBox.Show("ERREUR : fichier non selectionné ou non valide." +
                    "");
            }
        }

        /// <summary>
        /// Method to export data from the database to a CSV file.
        /// </summary>
        /// <param name="IntegrationMode"></param>
        /// <param name="ProgressBar"></param>
        public void ExportCsvFile()
        {
            try
            {
                var CsvFile = new StringBuilder();
                var Categories = string.Format("{0};{1};{2};{3};{4};{5}", "Description", "Ref", "Marque", "Famille", "Sous-Famille", "Prix H.T.");
                CsvFile.AppendLine(Categories);
                foreach (Article Article in new DaoArticle().ListAllArticles())
                {
                    var Adding = string.Format("{0};{1};{2};{3};{4};{5}", Article.Description, Article.ReferenceArticle, Article.Marque.Name, Article.SousFamille.SelectedFamille.Name, Article.SousFamille.Name, Article.Prix);
                    CsvFile.AppendLine(Adding);
                }
                File.WriteAllText("ExportedDatas.csv", CsvFile.ToString(), Encoding.Default);

                MessageBox.Show("Données exportées correctement.");
            }
            catch
            {
                MessageBox.Show("ERREUR : export impossible");
            }


        }
    }
}
