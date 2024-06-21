//using CoreBluetooth;
//using Microsoft.UI.Xaml.Controls;
using usineJusFruit.Model.Production;
using usineJusFruit.Model.Usine.Calendar;
using usineJusFruit.Model.Usine.Payment;
using usineJusFruit.Utilities.DataAccess;
using usineJusFruit.Utilities.DataAccess.Files;
using usineJusFruit.Utilities.Interfaces;
using usineJusFruit.ViewModel;

namespace usineJusFruit.View
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

      

        public MainPage(MainPageViewModel mainPageVM, IDataAccess dataAccessService, IAlertService alertService)
        {
            dataAccess = dataAccessService;
            alert = alertService;
            mainPageViewModel = mainPageVM;
            // Définition du BindingContext avec le ViewModel
            BindingContext = mainPageVM;
            InitializeComponent();
        }
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IAlertService alert;
        /// <summary>
        /// keep a reference to the ViewModel for eventual testings
        /// </summary>
        private MainPageViewModel mainPageViewModel;

        ////private void OnCounterClicked(object sender, EventArgs e)
        ////{
        ////    count++;

        ////    if (count == 1)
        ////        CounterBtn.Text = $"Clicked {count} time";
        ////    else
        ////        CounterBtn.Text = $"Clicked {count} times";

        ////    EntryCount.Text = count.ToString();

        ////    SemanticScreenReader.Announce(CounterBtn.Text);
        ////}



        //private void ButtonTestInterfaceAndDataAccess_Clicked_1(object sender, EventArgs e)
        //{
        //    string CONFIG_FILE = @"C:\Users\kiros\Desktop\POO\MAUI\usineJusFruit\usineJusFruit\usineJusFruit\Configuration\Datas\ConfigCsvUsine.txt";
        //    DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
        //    DataAccessCsvFile da = new DataAccessCsvFile(dataFilesManager);
        //    //ItemsCollection items = da.GetAllItems();
        //    //items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix { it.UnitPrice.ToString()}€ - { it.AutoDescription()}");


        //    ProductsCollection products = da.GetAllProducts();
        //    products.ToList().ForEach(p => lblDebug.Text += $"\n Client:{p.Id} {p.DateCueillette}");

        //}

        //private void ButtonTest_Clicked(object sender, EventArgs e)
        //{


        //}
    }
}
