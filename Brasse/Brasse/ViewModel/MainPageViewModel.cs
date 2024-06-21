using Brasse.Model.Restaurant.Catering;
using Brasse.Utilities.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasse.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        
         
      public MainPageViewModel(IDataAccess dataAccessService, IAlertService alertService) : base(alertService)
        {

            dataAccess = dataAccessService;

            Items = dataAccess.GetAllItems(); //get user's collection datas from chosen 
            //DataAccessSource(excel, csv, json...).
            //Tables = DataAccess.GetTables(); //get 
            //table's collection datas from chosen DataAccessSource (excel, csv, json...). 
      }


        /// <summary> 
        /// Manager to the data access (Csv, Json, XAML, SQL...) 
        /// </summary> 
        private IDataAccess dataAccess;

        /// <summary> 
        /// Collection of all users in the databse (source file) 
        /// </summary> 
        public ItemsCollection Items { get; set; }

        [ObservableProperty]
        private Item itemUserSelection;


        [RelayCommand()]
        private async void ShowItemDetails()
        {
            await alertService.ShowAlert("Selection", $"Voitre choix :\n{ItemUserSelection.Name}\n " +$"{ItemUserSelection.Description}\n{ItemUserSelection.PictureName}");
        }

    }
}
