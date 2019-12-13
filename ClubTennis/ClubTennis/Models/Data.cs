using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class Data
    {
        private const string PATH = "Data/Peoples.txt";
        private List<People> _peoples;

        public List<People> Peoples //TODO FOR TEST
        {
            get
            {
                return this._peoples;
            }
            set
            {
                this._peoples = value;
            }
        }
        public void WriteData()
        {
            try
            {
                File.WriteAllLines(PATH, ConvertFromPeopleListToStringArray(this._peoples));
            }
            catch(Exception ex)
            {
                File.WriteAllText("error.txt", ex.Message); //Pas pour le debug
            }
        }
        /// <summary>
        /// Methode permettant de convertir 
        /// une liste de données personnes en tableau de string 
        /// </summary>
        /// <param name="peoples"></param>
        /// <returns></returns>
        private string[] ConvertFromPeopleListToStringArray(List<People> peoples) 
            //On aurait pu se passer du parametre car peoples est une variance d'instance 
            //mais on sait jamais on pourrait utiliser la methode ailleur
        {
            string[] array = new string[peoples.Count];

            for (int i = 0;
                i < array.Length;
                i++)
            {
                array[i] = peoples[i].ToString();
            }

            return array;
        }
        /// <summary>
        /// Methode permettant de convertir les données d'une personne en string
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        private string ConvertFromPeopleToString(People people)
        {
            return people.ToString();
        }
    }
}
