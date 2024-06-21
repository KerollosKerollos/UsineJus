namespace Brasse.Model.Restaurant.Catering
{
    public class Alcohol : Drink
    {
        private double _percentage;
        private bool _isNa; 
        const double minPercentage = 0.0;
        const double maxPercentage = 100.0;

        public Alcohol(int id, string name, string description, double unitPrice, string pictureName, double vatRate, double volume, double percentage)
      : base(id, name, description, unitPrice, pictureName, vatRate, volume)
        {
            Percentage = percentage;
            EvalNA();
        }
       
        public double Percentage
        {
            get => _percentage;
            set
            {
                if (CheckPercentage(value))
                {
                    _percentage = value;
                }
            }
        }
        
        public bool IsNa
        {
            get => _isNa; 
            set
            {
                   _isNa = value;
            }
        }
        // Vérifier le pourcentage d'alcohol 
        public static bool CheckPercentage(double level)
        {
            return level >= minPercentage && level <= maxPercentage;
        }
        //Verifier si contient de l'alcohol 
        private void EvalNA()
        {
            IsNa = Percentage == 0.0; 
        }


        /// <summary> 
        /// Auto Description for this Alcohol 
        /// </summary> 
        public override string AutoDescription()
        {
            return $"{Name} {Volume} cl, {Description} avec un % d'alcool de {Percentage} et au prix de { UnitPrice}"; 
        }



    }
}
