using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usineJusFruit.Model.Usine.People
{
    public class ClientsCollection : ObservableCollection<Client>
    {

        public ClientsCollection() { }

        public bool AddClient(Client cl)
        {
            if (this.Count == 0 || !this.Any(clientInTheCollection => clientInTheCollection.Id == cl.Id || (clientInTheCollection.LastName == cl.LastName && clientInTheCollection.FirstName == cl.FirstName)))
            {
                this.Add(cl);
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool RemoveClient(Client cl)
        {
            if (this.Any(clientInTheCollection => clientInTheCollection.Id == cl.Id || (clientInTheCollection.LastName == cl.LastName && clientInTheCollection.FirstName == cl.FirstName)))
            {
                this.Remove(cl);
                return true;

            }
            else
            {
                //if StaffMember not in the collection 
                return false;
            }
        }

    }


}
