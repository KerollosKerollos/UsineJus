using Brasse.Model.Restaurant.Catering;
using Brasse.Model.Restaurant.Design;
using Brasse.Model.Restaurant.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasse.Utilities.Interfaces
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
        /// <summary> 
        /// retrieve items informations from the external source 
        /// </summary> 
        /// <returns>an ItemsCollection </returns> 
        ItemsCollection GetAllItems();

        /// <summary> 
        /// retrieve tables informations (Id numbers and seats number) from the external source
        /// </summary> 
        /// <returns>an TablesCollection</returns> 
      TablesCollection GetTables();

        /// <summary> 
        /// retrieve customers informations from the external source 
        /// </summary> 
        /// <returns>a CustomersCollection </returns> 
        CustomersCollection GetAllCustomers();

        /// <summary> 
        /// retrieve staff members informations from the external source 
        /// </summary> 
        /// <returns>a StaffMembersCollection </returns> 
        StaffMembersCollection GetAllStaffMembers();

        //All CRUD methods must be added here
    }
}
