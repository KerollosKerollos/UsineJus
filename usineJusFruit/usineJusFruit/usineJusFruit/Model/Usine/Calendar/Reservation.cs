//using HealthKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using usineJusFruit.Model.Production;

namespace usineJusFruit.Model.Usine.Calendar
{
    public class Reservation : INotifyPropertyChanged
    {
        // Champs privés
        private string _client;
        private DateTime _date;
        private DateTime _deliveryEffectifDate;
        private DateTime _estimatedDate;
        private Product _reservedProduct;
        private Conditioning _conditioning;
        private double _effectifLitresReceived;

        public event PropertyChangedEventHandler? PropertyChanged;



        public Reservation(string client, DateTime date, DateTime deliveryEffectifDate, Product reservedProduct, Conditioning conditioning)
        {
            

            Client = client;
            Date = date;
            DeliveryEffectifDate = deliveryEffectifDate;
            //EstimatedDate = estimatedDate; 

            ReservedProduct = reservedProduct;
            Conditioning = conditioning;
            //
            //EffectifLitresReceived = effectifLitresReceived;

            EstimatedDate = CalculateEstimatedDate(deliveryEffectifDate);

            EffectifLitresReceived = CalculateEffectifLitresReceived();



            //CalculateEffectifLitresReceived(); 
        }

        // a enlever estimated date ,, effectiflitrericeved


        public string Client
        {
            get => _client;
            set => _client = value;
        }
        public DateTime Date { get => _date; set => _date = value; }

        public DateTime DeliveryEffectifDate
        {
            get => _deliveryEffectifDate;
            set
            {
                if (CanAcceptReservation(value, ReservedProduct.Quantity))
                {
                    _deliveryEffectifDate = value;
                    EstimatedDate = CalculateEstimatedDate(_deliveryEffectifDate); // Calculate estimated date
                }
                else
                {
                    throw new Exception("The factory cannot accept more than 100 KG of fruits per day.");
                }
            }
        }


        public DateTime EstimatedDate
        {
            get => _estimatedDate;
            set
            {
                _estimatedDate = value;
                OnPropertyChanged(nameof(EstimatedDate));

            }
        }
        //INOTIFY
        //public DateTime EstimatedDate
        //{
        //    get => _estimatedDate;
        //    private set => _estimatedDate = CalculateEstimatedDate(_deliveryEffectifDate); // Call the method
        //}




        public Product ReservedProduct
        {
            get => _reservedProduct;
            set => _reservedProduct = value;

           
        }

        public Conditioning Conditioning
        {
            get => _conditioning;
            set => _conditioning = value;
        }


        public double EffectifLitresReceived
        {
            get => _effectifLitresReceived;
            set
            {
                _effectifLitresReceived = value;
                OnPropertyChanged(nameof(EffectifLitresReceived));

            }
        }


        //INOTIFIYPROPERTYCHANGED 
        //public double EffectifLitresReceived
        //{
        //    get => _effectifLitresReceived;
        //    set => _effectifLitresReceived = CalculateEffectifLitresReceived(); // Calcul automatique
        //}

        public bool CanAcceptReservation(DateTime date, int quantity)
        {
            double totalQuantityForDay = GetTotalQuantityForDay(date);
            return (totalQuantityForDay + quantity) <= 100;
        }

        public double GetTotalQuantityForDay(DateTime date)
        {
            // Assuming the CSV file path is known and fixed
            string csvFilePath = "path/to/reservations.csv";
            if (!File.Exists(csvFilePath))
            {
                return 0;
            }

            var lines = File.ReadAllLines(csvFilePath);
            double totalQuantity = 0;

            foreach (var line in lines)
            {
                var fields = line.Split(',');
                DateTime reservationDate = DateTime.Parse(fields[0]);
                double reservationQuantity = double.Parse(fields[1]);

                if (reservationDate.Date == date.Date)
                {
                    totalQuantity += reservationQuantity;
                }
            }

            return totalQuantity;
        }

        public DateTime CalculateEstimatedDate(DateTime deliveryDate)
        {
            return deliveryDate.AddDays(7);
        }


        public double CalculateEffectifLitresReceived()
        {
            if (ReservedProduct != null)
            {
                double weightInKg = ReservedProduct.Quantity;
                double weightInGrams = weightInKg * 1000;
                double juiceWeightInGrams = weightInGrams * 0.60; // 60% of weight
                double juiceVolumeInLiters = juiceWeightInGrams / 1000; // Convert grams to liters
                return juiceVolumeInLiters;
            }
            return 0;
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }






    }
}
