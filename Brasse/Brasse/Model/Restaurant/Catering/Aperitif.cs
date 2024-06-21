//using Android.Icu.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasse.Model.Restaurant.Catering
{
    public class Aperitif : Alcohol
    {

        public Aperitif(string name, string description, int id, double unitPrice, double vatRate, string pictureName, double volume, double percentage)
           : base(id, name, description, unitPrice, pictureName, vatRate, volume , percentage )
        {
      
        }
    }
}
