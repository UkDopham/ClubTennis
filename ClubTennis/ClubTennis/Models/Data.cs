using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClubTennis.Models
{
    public class Data
    {
        private const string PATH = "Data/Peoples.clubtennis"; //CUSTOM extension 
        private List<People> _peoples;
        private BinaryFormatter _serializer;

        public Data()
        {
            this._serializer = new BinaryFormatter();
        }
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
        /// <summary>
        /// Déserialisation des données de la liste de personnne (Lecture persistante)
        /// </summary>
        public void LoadData()
        {
            try
            {
                Stream stream = new FileStream(PATH, FileMode.Open, FileAccess.Read);

                List<People> people = (List<People>)this._serializer.Deserialize(stream);
                stream.Close();
            }
            catch(Exception ex)
            {
                File.WriteAllText("error.txt", ex.Message); //Pas pour le debug
            }
        }
        /// <summary>
        /// Serialisation des données de la liste de personnne (Ecriture persistante)
        /// </summary>
        public void WriteData()
        {
            try
            {
                Stream stream = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.Write);

                this._serializer.Serialize(stream, this._peoples);
                stream.Close();
            }
            catch(Exception ex)
            {
                File.WriteAllText("error.txt", ex.Message); //Pas pour le debug
            }
        }

       
    }
}
