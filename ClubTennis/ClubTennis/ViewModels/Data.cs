﻿using System;
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
        private const string SAVEIDPATH = "Data/remember.club";
        private const string PATH = "Data/saves.club";
        private const string PASSWORDPATH = "Data/passwords.club";

        private string _remember;
        private List<User> _users;
        private List<Save> _saves;
        private List<string> _saveTitles;
        private BinaryFormatter _serializer;

        public string Remember
        {
            get
            {
                return this._remember;
            }
            set
            {
                this._remember = value;
            }
        }
        public List<User> Users
        {
            get
            {
                return this._users;
            }
            set
            {
                this._users = value;
            }
        }
        public Data()
        {
            this._serializer = new BinaryFormatter();
        }
      
        /// <summary>
        /// Recupération de l'identifiant sauvegarder
        /// </summary>
        public void LoadRemember()
        {
            try
            {
                Stream stream = new FileStream(SAVEIDPATH, FileMode.Open, FileAccess.Read);
                this._remember = (string)this._serializer.Deserialize(stream);

                stream.Close();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Enregistrement de l'identifiant sauvegarder
        /// </summary>
        public void WriteRemember()
        {
            Stream stream = new FileStream(SAVEIDPATH, FileMode.OpenOrCreate, FileAccess.Write);
            this._serializer.Serialize(stream, this._remember);

            stream.Close();
        }
        /// <summary>
        /// Recupération des identifiants et mot de passe des utilisateurs existants
        /// </summary>
        public void LoadID()
        {
            try
            {
                Stream stream = new FileStream(PASSWORDPATH, FileMode.Open, FileAccess.Read);
                this._users = (List<User>)this._serializer.Deserialize(stream);

                stream.Close();
            }
            catch(Exception ex)
            {

            }
        }

        public void WriteID()
        {
            try
            {
                Stream stream = new FileStream(PASSWORDPATH, FileMode.OpenOrCreate, FileAccess.Write);
                this._serializer.Serialize(stream, this._users);
                stream.Close();
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// Déserialisation des données  (Lecture persistante)
        /// </summary>
        public void Load()
        {
            try
            {
                LoadTitles();
                LoadData();
            }
            catch(Exception ex)
            {
                File.WriteAllText("error.txt", ex.Message); //Pas pour le debug
            }
        }

        private void LoadData()
        {
            for(int i = 0;
                i < this._saveTitles.Count;
                i++)
            {
                Stream stream = new FileStream(this._saveTitles[i], FileMode.Open, FileAccess.Read);
                Save save = (Save)this._serializer.Deserialize(stream);
                stream.Close();
            }
        }
        /// <summary>
        /// Chaque titre équivaux à une sauvegarde d'un club different
        /// </summary>
        private void LoadTitles()
        {
            Stream stream = new FileStream(PATH, FileMode.Open, FileAccess.Read);
            this._saveTitles = (List<string>)this._serializer.Deserialize(stream);

            stream.Close();
        }

        private void WriteTitles()
        {
            this._saveTitles = new List<string>();

            foreach(Save save in this._saves)
            {
                this._saveTitles.Add(save.Club.Name);
            }
            Stream stream = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.Write);

            this._serializer.Serialize(stream, this._saveTitles);
            stream.Close();
        }

        private void WriteData()
        {
            foreach (Save save in this._saves)
            {
                Stream stream = new FileStream(save.GetPath(), FileMode.OpenOrCreate, FileAccess.Write);
                this._serializer.Serialize(stream, save);
                stream.Close();
            }          
        }
        /// <summary>
        /// Serialisation des données (Ecriture persistante)
        /// </summary>
        public void Write()
        {
            try
            {
                WriteTitles();
                WriteData();
            }
            catch(Exception ex)
            {
                File.WriteAllText("error.txt", ex.Message); //Pas pour le debug
            }
        }

       
    }
}
