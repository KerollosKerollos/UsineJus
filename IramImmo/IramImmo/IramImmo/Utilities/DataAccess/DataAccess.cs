using IramImmo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IramImmo.Utilities.DataAccess
{
    public class DataAccess
    {
        public BiensEnVente GetBiensEnVente()
        {
            MaisondHabitation maisonDurant = new MaisondHabitation("Durant", 250000.0, 12);
            MaisondHabitation maisonBlavier = new MaisondHabitation("Blavier", 325000.0, 15);
            MaisondHabitation maisonDevezon = new MaisondHabitation("Devezon", 450000.0, 20);
            Garage garageDelava = new Garage("Delava", 10000, false);
            Garage garageSurquin = new Garage("Surquin", 5000, true);
            Garage garageFrequin = new Garage("Frequin", 12000, true);

            BiensEnVente biens = new BiensEnVente();

            biens.Add(maisonDurant);
            biens.Add(maisonBlavier);
            biens.Add(maisonDevezon);
            biens.Add(garageDelava);
            biens.Add(garageSurquin);
            biens.Add(garageFrequin);

            return biens;
        }


    }
}
