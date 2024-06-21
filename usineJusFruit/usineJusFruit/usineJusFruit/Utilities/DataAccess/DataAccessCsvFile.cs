//using AndroidX.Emoji2.Text.FlatBuffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usineJusFruit.Model.Production;
using usineJusFruit.Model.Usine.Calendar;
using usineJusFruit.Model.Usine.Payment;
using usineJusFruit.Utilities.DataAccess.Files;
using usineJusFruit.Utilities.Interfaces;

namespace usineJusFruit.Utilities.DataAccess
{
    public class DataAccessCsvFile : DataAccess, IDataAccess
    {

        public DataAccessCsvFile(string filePath) : base(filePath)
        {
        }
        /// <summary>
        /// Constructor associated with a datafileManager, it contains path to a config text file
        /// wich contains path to csv files
        /// </summary>
        /// <param name="dfm"></param>
        public DataAccessCsvFile(DataFilesManager dfm) : base(dfm) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override TicketsCollection GetAllTickets()
        {
            List<string> listToRead = new List<string>();
            TicketsCollection tickets = new TicketsCollection();
            string? AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("TICKETS");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Ticket t = GetTicket(s);
                    if (t != null)
                    {
                        tickets.AddTicket(t);
                    }
                }
                return tickets;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }

        private static Ticket GetTicket(string csvline)
        {
            string[] fields = csvline.Split(';');
            if (!string.IsNullOrEmpty(fields[0]))
            {
                Ticket t = new Ticket(idSerial: int.Parse(fields[1]) , totalWeight: int.Parse(fields[1]), litreQuantity: int.Parse(fields[2]), totalPrice: int.Parse(fields[1]));
                return t;
            }
            else
            {
                return null;
            }
        }

        public override FacturesCollection GetAllFactures()
        {
            List<string> listToRead = new List<string>();
            FacturesCollection factures = new FacturesCollection();
            string? AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("FACTURES");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Facture f = GetFacture(s);
                    if (f != null)
                    {
                        factures.AddFacture(f);
                    }
                }
                return factures;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }
        private static Facture GetFacture(string csvline)
        {
            string[] fields = csvline.Split(';');
            if (!string.IsNullOrEmpty(fields[0]))
            {
                Facture f = new Facture(idSerial: int.Parse(fields[1]), totalWeight: int.Parse(fields[2]), litreQuantity: int.Parse(fields[3]), totalPrice: int.Parse(fields[4]), vatNumber: fields[5]);
                return f;
            }
            else
            {
                return null;
            }
        }



        public override ProductsCollection GetAllProducts()
        {
            List<string> listToRead = new List<string>();
            ProductsCollection products = new ProductsCollection();
            string? AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("PRODUCTS");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Product P = GetProduct(s);
                    if (P != null)
                    {
                        products.AddProduct(P);
                    }
                }
                return products;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }
 
        private static Product GetProduct(string csvline)
        {
            string[] fields = csvline.Split(';');
            if (!string.IsNullOrEmpty(fields[0]))
            {
                Product p = new Product(id: int.Parse(fields[1]), dateCueillette: DateTime.Parse(fields[2]), variety: fields[3] , quantity: int.Parse(fields[4]), fruit:fields[5]);
                return p;
            }
            else
            {
                return null;
            }
        }

        public override ReservationsCollection GetAllReservations()
        {
            List<string> listToRead = new List<string>();
            ReservationsCollection resrvations = new ReservationsCollection();
            string? AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("RESERVATIONS");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Reservation R = GetReservation(s);
                    if (R != null)
                    {
                        resrvations.AddReservation(R);
                    }
                }
                return resrvations;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }


        private static Reservation GetReservation(string csvline)
        {
            string[] fields = csvline.Split(';');
            if (!string.IsNullOrEmpty(fields[0]))
            {
                // Lire les champs pour le client, la date et la date de livraison effective
                string client = fields[0];
                DateTime date = DateTime.Parse(fields[1]);
                DateTime deliveryEffectifDate = DateTime.Parse(fields[2]);

                // Lire les champs pour le produit
                int productId = int.Parse(fields[3]);
                DateTime productDateCueillette = DateTime.Parse(fields[4]);
                string productVariety = fields[5];
                int productQuantity = int.Parse(fields[6]);
                string productFruit = fields[7]; // Changement de FruitType à string

                // Créer l'objet Product
                Product reservedProduct = new Product(productId, productDateCueillette, productVariety, productQuantity, productFruit);

                // Lire les champs pour le conditionnement
                string conditioningName = fields[8];  // Assuming name is in field 8
                double conditioningVolume = double.Parse(fields[9]); // Assuming volume is in field 9
                double conditioningUnitPrice = double.Parse(fields[10]); // Assuming unit price is in field 10

                // Créer l'objet Conditioning
                Conditioning conditioning = new Conditioning(conditioningName, conditioningVolume, conditioningUnitPrice);

                // Créer l'objet Reservation
                Reservation R = new Reservation(client: client, date: date, deliveryEffectifDate: deliveryEffectifDate, reservedProduct: reservedProduct, conditioning: conditioning);
                return R;
            }
            else
            {
                return null;
            }
        }






    }       
}
