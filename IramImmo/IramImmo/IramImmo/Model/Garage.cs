using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IramImmo.Model
{
    public class Garage : BienImmobilier
    { 


    private const double COMMISSION_FORFAITAIRE = 500.0;
    private const double PCT_COMMISSION = 10.0;

        //Champ
    private bool _electricShutter;


    private const string TYPE_BIEN = "Garage";

    public Garage(string proprioName, double prixNet, bool electricShutter)
        : base(proprioName, prixNet)
    {
        ElectricShutter = electricShutter;
    }

        //get set 
    public bool ElectricShutter { get => _electricShutter; set => _electricShutter = value; }
    public override void CalculCommision()
    {
        Commission = COMMISSION_FORFAITAIRE + (PrixNet * PCT_COMMISSION / 100.0);
    }




    public override string BienProprio => $"{TYPE_BIEN} {ProprioName}";


    }
      
}
