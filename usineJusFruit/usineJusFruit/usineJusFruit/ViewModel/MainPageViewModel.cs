using CommunityToolkit.Mvvm.ComponentModel;
//using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usineJusFruit.Model.Production;
using usineJusFruit.Utilities.Interfaces;

namespace usineJusFruit.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {

        public MainPageViewModel(IDataAccess dataAccessService, IAlertService alertService) : base(alertService)
        {
            dataAccess = dataAccessService;
            Products = dataAccess.GetAllProducts(); //get user's collection datas from chosen DataAccessSource (excel, csv, json...).                                             
                                                            //Tables = DataAccess.GetTables(); //get table's collection datas from chosen DataAccessSource (excel, csv, json...).
        }

        /// </summary>
        private IDataAccess dataAccess;

        /// <summary>
        /// collection of all StaffMembers
        /// </summary>
        public ProductsCollection Products { get; set; }

        /// <summary>
        /// Staff Member selected in the listview
        /// </summary>
        [ObservableProperty]
        private Product productSelection;

    }
}
