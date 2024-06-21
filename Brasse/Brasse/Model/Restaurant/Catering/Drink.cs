using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasse.Model.Restaurant.Catering
{
    public class Drink : Item
    {
        private double _volume;
        const int  minQuantity = 1;

        public Drink(int id, string name, string description, double unitPrice, string pictureName, double vatRate, double volume)
        : base(id, name, description, unitPrice, pictureName, vatRate)
        {
            Volume = volume;
        }



        public double Volume
        {
            get => _volume;
            set
            {
                if (ChceckVolume(value))
                {
                    _volume = value;
                }
            }
        }


        public static bool ChceckVolume (double quantity )
        {
            return quantity >= minQuantity; 
        }


        /// <summary> 
        /// Auto Description for this Drink 
        /// </summary> 
        public override string AutoDescription()
        {
            return $"{Name} {Volume} cl, {Description} au prix de {UnitPrice}";
        }



    }
}
