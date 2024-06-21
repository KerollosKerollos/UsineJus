using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IramImmo.Model;
using IramImmo.Utilities.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IramImmo.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(DataAccess dataAccessService)
        {
            // classe principale + methode dans le data access 
            BiensImmobiliers = dataAccessService.GetBiensEnVente();
        }


        //B majuscule 
        //AVEC S 
        public BiensEnVente BiensImmobiliers { get; set; }

        [ObservableProperty]

        //b miniuscule bienImmobilierSelection 
       
        private BienImmobilier bienImmobilierSelection;

        //[RelayCommand]
        //private void TestBindingShowProperties()
        //{
        //    int i = 6;
        //}


    }


}
