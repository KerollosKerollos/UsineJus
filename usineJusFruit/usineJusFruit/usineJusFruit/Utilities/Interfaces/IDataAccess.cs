using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usineJusFruit.Model.Production;
using usineJusFruit.Model.Usine.Calendar;
using usineJusFruit.Model.Usine.Payment;
using usineJusFruit.Model.Usine.People;

namespace usineJusFruit.Utilities.Interfaces
{
    public interface IDataAccess
    {

        /// <summary>
        /// Access string to the external source (file path, connection string ...)
        /// </summary>
        string AccessPath
        {
            get;
            set;
        }


        
        ProductsCollection GetAllProducts();
       
        ReservationsCollection GetAllReservations();
       
        FacturesCollection GetAllFactures();

        TicketsCollection GetAllTickets();

        //ClientsCollection GetAllClients();



        //Methode a faire pour mettre a jour les reservations 
        // bool UpdateAllReservations(ReservationsCollection reservations);    A faire et 



    }
}
