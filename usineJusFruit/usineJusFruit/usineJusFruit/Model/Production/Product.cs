using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace usineJusFruit.Model.Production
{
    /// <summary>
    /// enumeration
    /// </summary>
    //public enum FruitType
    //{
    //    Pomme,
    //    Banane,
    //    Orange,
    //}

    public class Product
    {
        private int _id;
        private DateTime _dateCueillette;
        private string _variety;
        private int _quantity;
        private string _fruit;  // Déclaration manquante ajoutée

        // Constructeur principal
        public Product(int id , DateTime dateCueillette, string variety, int quantity ,  string fruit)
        {
            Id = id;
            DateCueillette = dateCueillette;
            Variety = variety;
            Quantity = quantity;
            Fruit = fruit;
        }

        public int Id
        {
            get => _id;
            set
            {
                if (CheckNotNegative(value))
                {
                    _id = value;
                }
            }
        }



        /// <summary>
        /// verifier que la date est dans le passé
        /// </summary>
        public DateTime DateCueillette
        {
            get { return _dateCueillette; }
            set
            {
                if (value < DateTime.Now)
                {
                    _dateCueillette = value;
                }
                else
                {
                    Console.WriteLine("La date de cueillette doit être dans le passé.");
                }
            }
        }

        public string Variety
        {
            get { return _variety; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _variety = value;
                }
                else
                {
                    Console.WriteLine("La variété ne doit pas être vide ou constituée uniquement d'espaces blancs.");
                }
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value > 0)
                {
                    _quantity = value;
                }
                else
                {
                    Console.WriteLine("La quantité doit être supérieure à 0.");
                }
            }
        }
        public string Fruit { get => _fruit; set => _fruit = value; }




        public bool CheckNotNegative(double d)
        {
            return d > 0.0;
        }
    }
}
