//using Android.Icu.Text;
//using Org.Apache.Http.Impl.Conn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasse.Model.Restaurant.Catering
{
    public class Beer : Alcohol
    {
        private bool _isAbbeyBeer; 
        private bool _isTrappistBeer;

        public Beer(int id, string name, string description, double unitPrice, string pictureName, double vatRate, double volume, double percentage, bool isTrappistBeer, bool isAbbeyBeer)
        : base(id, name, description, unitPrice, pictureName, vatRate, volume, percentage)
        {
            IsTrappistBeer = isTrappistBeer;
            IsAbbeyBeer = isAbbeyBeer;
        }

        public bool IsAbbeyBeer { get => _isAbbeyBeer; set => _isAbbeyBeer = value; }
        public bool IsTrappistBeer { get => _isTrappistBeer; set => _isTrappistBeer = value; }

        /// <summary> 
        /// Auto Description for this Beer 
        /// </summary> 
        public override string AutoDescription()
        {
            return $"{Name} {Volume}cl, {Description}  avec un taux d'alcool de {Percentage}%, bière d'abbaye : {IsAbbeyBeer} Trappiste : {IsTrappistBeer} et au prix de {UnitPrice}"; 
        }


    }
}
