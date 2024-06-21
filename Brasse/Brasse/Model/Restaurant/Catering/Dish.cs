using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasse.Model.Restaurant.Catering
{
    public class Dish : Item 
    {
        private string _plat;

        public Dish(int id, string name, string description, double unitPrice, string pictureName, double vatRate, string plat = " ")
            : base(id,  name,  description,  unitPrice,  pictureName,  vatRate)
        {
            Plat = plat;

        }

        public string Plat { get => _plat; set => _plat = value; }



        /// <summary> 
        /// Auto Description for this Dish 
        /// </summary> 
        public override string AutoDescription()
        {
            return $"{Name} - {Description} au prix de {UnitPrice}";
        }





    }
    
}
