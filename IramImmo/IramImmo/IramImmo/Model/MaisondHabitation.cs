using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IramImmo.Model
{
    public class MaisondHabitation : BienImmobilier
    {
        private double _facadeMeters;
        private const string TYPE_BIEN = "Maison";
        public MaisondHabitation(string proprioName, double prixNet, double facadeMeters)
            : base(proprioName, prixNet)
        {
            FacadeMeters = facadeMeters;
        }
        public double FacadeMeters { get => _facadeMeters; set => _facadeMeters = value; }
        public override string BienProprio => $"{TYPE_BIEN} {ProprioName}";
    }


}
