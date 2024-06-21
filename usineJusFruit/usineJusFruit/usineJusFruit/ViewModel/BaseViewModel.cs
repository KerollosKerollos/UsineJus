using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usineJusFruit.Utilities.Interfaces;

namespace usineJusFruit.ViewModel
{
    public class BaseViewModel : ObservableObject
    {

        public BaseViewModel(IAlertService alertService)
        {
            
            this.alertService = alertService;
            //MainInfos = new MainInformations("My Restaurant", "4, rue de la Lys 7000 Mons", "BE 0563.191.043", "http://myrestaurant.be");
        }

        protected IAlertService alertService;

        public DateTime Today { get; } = DateTime.Now;
        public string TodayDate => Today.Date.ToString("d-M-yyyy");
    }
}
