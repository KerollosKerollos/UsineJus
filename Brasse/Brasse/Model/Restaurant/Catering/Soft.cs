using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasse.Model.Restaurant.Catering
{
    public class Soft : Drink
    {

        public Soft(int id, string name, string description, double unitPrice, string pictureName, double vatRate, double volume)
        : base(id, name, description, unitPrice, pictureName, vatRate, volume)
        {

        }
    }
}
