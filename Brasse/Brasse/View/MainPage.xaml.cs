using Brasse.Model.Restaurant.Activity;
using Brasse.Model.Restaurant.Catering;
using Brasse.Model.Restaurant.Design;
using Brasse.Model.Restaurant.People;
using Brasse.Utilities.DataAccess;
using Brasse.Utilities.DataAccess.Files;
using Brasse.Utilities.Interfaces;
using Brasse.Utilities.Services;
using Brasse.ViewModel;
using Microsoft.Maui;
using System.Collections.ObjectModel;
using static Brasse.Model.Restaurant.People.Customer;

namespace Brasse.View
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(MainPageViewModel mainPageVM, IDataAccess dataAccessService,IAlertService alertService)
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

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";

            else
                CounterBtn.Text = $"Clicked {count} times";

            EntryCount.Text = count.ToString();

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        //private void buttonTestCreateFirstPersons_Clicked(object sender, EventArgs e)
        //{
        //    //Person firstPerson = new Person(id: 1, lastName: "Beumier", firstName: "Damien",gender: true, email: "dambeumier@gmail.com", mobilePhoneNumber: "0489142293");
        //    //Person secondPerson = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie",gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
        //    //Person ThirdPerson = new Person(3, "Jandrin", "Marc", true, "jandrinmarc@gmail.com",mobilePhoneNumber: "0485556678");
        //    //Person FourthPerson = new Person(4, "Lupant", "Sebastien");
        //    //Person FifthPerson = new Person();
        //    //Person TestPerson = new Person( lastName: "Lupant", firstName: "Sebastien");      
        //}

        //private void buttonTestEncapsulation_Clicked(object sender, EventArgs e)
        //{
           // Person p = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender:false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            //p.FirstName = "Marie-Sophie";
            //lblDebug.Text = p.FirstName;
        //}

        private void buttonTestStatic_Clicked(object sender, EventArgs e)
        {
            string mail = "mon mail@gmail.com";
            bool testMail = Person.CheckEMail(mail);
            //lblDebug.Text = $"résultat du test de validité du mail {mail} : {testMail.ToString()}";

            lblDebug.Text = $"Nombre d'instances de classe Person : {Person.TotalPersons}";

        }

        private void buttonTestTable_Clicked(object sender, EventArgs e)
        {
            Table t1 = new Table(4, 1, false);
            Table t2 = new Table(6, 2, false);
            lblDebug.Text = $"Nombre totales de sieges : {Table.TotaleSeats}";

        }

        private void buttonTestInheritance_Clicked(object sender, EventArgs e)
        {
            Customer c = new Customer(7, "Maggi", "Francesca", false,
            "francesca190@gmail.com", "0475689034", CustomerType.New);
            StaffMember staffm = new StaffMember(8, "Dries", "François", true,
            "francoisdries@gmail.com", "0485113289", "BE83 2378 9876 2390", "4, rue du marais 7030 Ghlin", 3275.0);
            Manager m = new Manager(9, "Duchief", "Marc", true, "duchiefmarc@gmail.com",
            "0491203040", "BE84 1128 9836 3518", "2, rue du pont 7000 Mons", 5200.5, "Password01");
        }

        private void buttonTestCreateItem_Clicked(object sender, EventArgs e)
        {
            //Item coca = new Item(1, "cocaa", "Mauvaise pour la santé", 2.00, "coca.png", 8.5 );
            //Item pizza = new Item(2, " pizza classique ", "Margherita", 12, "margherita.jpg",12 );

            lblDebug.Text = "Creation item ";
        }
        private void buttonTestDerivateItems_Clicked(object sender, EventArgs e)
        {
            Drink water = new Drink(3, " eau plate ", "spa", 2, "spa.png", 6, 75.0); ;
            Dish pasta = new Dish(4, "pate sauce tomate ", "spaghetti", 12, "spaghetti.jpg", 21, " azd");
            Soft sprite = new Soft(5, " Boisson gazeuse ", "sprite", 2, "sprite.png  ",6 , 75);
            Alcohol vodka = new Alcohol(6, "vodka 40%", "VODKA", 30, "vodka.jpg",21 , 75, 21);
            Beer biere = new Beer(7, " biere d'abbaye", "abbaye", 8, "abbaye.png",21 , 33, 8, false, true);

        }

        private void buttonTestCollection_Clicked(object sender, EventArgs e)
        {
            StaffMember staffm1 = new StaffMember(10, "Vandenberg", "Caroline", true,
            "carovan@gmail.com",
            "0476893029", "BE81 7345 1290 1038", "10, rue de l'eglise 7030 Ghlin", 3050.0);
            StaffMember staffm2 = new StaffMember(11, "Dries", "Francois", true,
            "francoisdries@gmail.com",
            "0485113289", "BE83 2378 9876 2390", "130, rue de binche 7030 Ghlin", 3275.0);
            Manager m = new Manager(12, "Legars", "Flavien", true, "legafla@gmail.com", "0482426671", "BE83 4435 1893 1450", "5, rue de la cle 7000 Mons", 5500.0, "Password01");
            ObservableCollection<StaffMember> staffmCol = new ObservableCollection<StaffMember>();
            staffmCol.Add(staffm1);
            staffmCol.Add(staffm2);
            staffmCol.Add(m);
            string s = $"\nnombre d'éléments dans la collection : {staffmCol.Count}";

            foreach (StaffMember sm in staffmCol)
            {
                s += $"\n{sm.FirstName} {sm.LastName} : {sm.GetType().ToString()}";

            }
            lblDebug.Text = s;
        }

        private void buttonTestOrder_Clicked(object sender, EventArgs e)
        {
            Order ord = new Order();

            Soft coca = new Soft(1, name: "Coca cola", "", 3.30, "coca.jpg", 21.0, 25);
            Beer brassTemps = new Beer(2, name: "Coca cola", "", 3.30, "biere.jpg", 21.0,25, 6.0, false, false);
            Dish spaghBolo = new Dish(3, "Spaghetti bolo", "", 15.30, "bolo.jpg", 21.0, "plat2");

            OrderItem ordItemCoca_1 = new OrderItem(coca, 1);
            OrderItem ordItemBrassTemps = new OrderItem(brassTemps, 1);
            OrderItem ordItemSpaghBolo = new OrderItem(spaghBolo, 2);
            OrderItem ordItemCoca_2 = new OrderItem(coca, 2);

            ord.AddUpdateOrderItem(ordItemCoca_1);
            ord.AddUpdateOrderItem(ordItemBrassTemps);
            ord.AddUpdateOrderItem(ordItemSpaghBolo);
            ord.AddUpdateOrderItem(ordItemCoca_2);  //2 nouveaux cocas commandés plus tard 
            string s = "";
            s = $"nombre d'orderItems : {ord.OrderItems.Count}";
            s += $"\nnombre de coca : {ord.OrderItems[0].Quantity} Prix : { ord.OrderItems[0].Price}"; 
            s += $"\nnombre de brasse temps : {ord.OrderItems[1].Quantity} Prix : { ord.OrderItems[1].Price}"; 
            s += $"\nnombre de spaghettis : {ord.OrderItems[2].Quantity} Prix : { ord.OrderItems[2].Price}"; 
            s += $"\nPrix total TVA : {ord.TotalVatCost}€";
            s += $"\nPrix total : {ord.TotalPrice}€";
            lblDebug.Text = s;
        }

        private void buttonTestLambdasOnCollection_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Drink> drinks = new ObservableCollection<Drink>();
            drinks.Add(new Soft(1, name: "Coca 25", "", 3.30, "coca.jpg", 21.0, 25));
            drinks.Add(new Soft(2, name: "Fanta 25", "", 3.30, "fanta.jpg", 21.0, 25));
            drinks.Add(new Soft(3, name: "Coca 33", "", 4.20, "coca.jpg", 21.0, 33));
            drinks.Add(new Soft(4, name: "Fanta 33", "", 4.20, "fanta.jpg", 21.0, 33));
            drinks.Add(new Soft(5, name: "Water 25cl", "", 3.10, "water25.jpg", 21.0, 25));
            drinks.Add(new Soft(6, name: "Water 50cl", "", 5.50, "water.jpg", 21.0, 50));
            drinks.Add(new Soft(7, name: "Water 1L", "", 7.00, "water.jpg", 21.0, 100));
            drinks.Add(new Soft(8, name: "Coca Zero", "", 3.50, "coca.jpg", 21.0, 25));
            drinks.Add(new Soft(9, name: "IceTea Zero", "", 3.50, "coca.jpg", 21.0, 25));
            drinks.Add(new Beer(10, name: "Ambrasse Temps 25", "", 4.20, "amb25.jpg", 21.0,25, 6.00, false, false));
            drinks.Add(new Beer(11, name: "Troll 25", "", 4.20, "troll25.jpg", 21.0, 25, 5.50,false, false));

            // match Criteria ?; 
            bool boolResult;
            boolResult = drinks.All(d => d.UnitPrice < 5.00);//all elements respect the criteria ? 
            boolResult = drinks.Any(d => d.UnitPrice >= 6.00);//exist at least one element that respect the criteria

            //sorted collections 
            ObservableCollection<Drink> orderByNameDesc = new
            ObservableCollection<Drink>(drinks.OrderByDescending(d => d.Name));
            ObservableCollection<Drink> orderByUnitPriceAsc = new
            ObservableCollection<Drink>(drinks.OrderBy(d => d.UnitPrice));

            //collection with selection          
            ObservableCollection<Drink> select25Cl = new
            ObservableCollection<Drink>(drinks.Where(d => d.Volume == 25.00));
            ObservableCollection<Drink> waters = new ObservableCollection<Drink>(drinks.Where(d=> d.Name.Contains("Water")));
            ObservableCollection<Drink> beers = new
            ObservableCollection<Drink>(drinks.OfType<Beer>());

            //find element with one or more (logical expression) criteria 
            Drink coca33 = drinks.First(d => d.Name.Contains("Coca 33"));
            Drink d = drinks.First(d => d.Volume > 25 && d.PictureName.EndsWith(".jpg"));

            //build new list from another collection 
            List<string> s = drinks.Select(d =>$"{d.Id};{d.Name};{d.Description};{d.UnitPrice};{d.Volume}").ToList();

            //compute  
            double maxUnitPrice = drinks.Max(d => d.UnitPrice);
            double average = drinks.Average(d => d.UnitPrice);
            double sum = drinks.Sum(d => d.UnitPrice);

            //do something foreach element 
            //drinks.ForEach(d => d.VatRate = 22.0);

        }

        private void buttonTestItemsCollection_Clicked(object sender, EventArgs e)
        {
            Soft coca = new Soft(1, name: "Coca cola", "", 3.30, "coca.jpg", 21.0, 25);
            Soft fanta = new Soft(2, name: "Fanta", "", 3.30, "fanta.jpg", 21.0, 25);
            Beer brassTemps = new Beer(3, name: "brassTemps", "", 3.30, "biere.jpg", 21.0,25, 6.0, false, false);
            Dish spaghBolo = new Dish(4, "Spaghetti bolo", "viande et sauce tomate", 15.30, "bolo.jpg", 21.0, "plat");
            Soft coca2 = new Soft(5, name: "Coca cola", "", 3.30, "coca.jpg", 21.0, 25);

            ItemsCollection itCol = new ItemsCollection();

            itCol.AddItem(coca);
            itCol.AddItem(fanta);
            itCol.AddItem(brassTemps);
            itCol.AddItem(spaghBolo);

            itCol.AddItem(coca2);//test to add an item who have the same name as another already in the list

            itCol.DeleteItem(brassTemps);//delete one item 

            itCol.IndexPrices(5.00); //index 5% all prices  
        }

        private void buttonExLambdaOnCollection_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<StaffMember> staff = new ObservableCollection<StaffMember>();
            staff.Add(new StaffMember(1, "Dutrieu", "Pierre", true, "dutrieur@gmail.com", "0498345678", "BE45 6781 2345 2490", "4, rue de la coupe 7000Mons", 34000));
            staff.Add(new StaffMember(2, "Lalande", "Vanessa", false, "", "0485667098", "BE806581 1145 3496", "16, rue de la loi 7080 Nivelles", 32500));
            staff.Add(new Manager(3, "Jenlain", "Fabienne", false, "jenfab23@gmail.com", "0478901322", "BE80 4394 7739 1234", "13, rue de Mons 6000 Beaumont", 59000, "Password01"));
            staff.Add(new StaffMember(4, "Baulieu", "Jean", true, "", "", "BE23 1189 1390 1193", "5, rue des tilleus 7030 Ghlin", 36500));
            staff.Add(new StaffMember(5, "Gerardin", "Isabelle", false, "", "0475671038", "BE801782 4490 9113", "120, rue des drapiers 7000 Mons", 41000));
            staff.Add(new Manager(6, "Balkan", "Fred", true, "balkan@gmail.com", "0479001280", "BE89 1190 1127 2280", "10, rue grande 6340 Nimy", 54000, "TrucMachin01"));
            staff.Add(new StaffMember(7, "Gutierez", "Manolo", true, "manolo140@gmail.com", "0498671011", "BE70 9012 1034 1931", "8, rue de la riviere 7000 Mons", 29800));


            int EmplyeesNumber = staff.Count();
            bool allHaveMobile = staff.All(s => !string.IsNullOrEmpty(s.MobilePhoneNumber));

            //Est-ce qu’il y a un membre injoignable, qui n’a pas de N° de téléphone ni d’Email renseignés ?
            bool isSomeoneUnjoinable = staff.Any(s => string.IsNullOrEmpty(s.MobilePhoneNumber) && string.IsNullOrEmpty(s.Email));

            //Le premier membre (celui du c)) (sa référence) qui n’a pas de N° de téléphone ni d’Email renseignés
            StaffMember firstUnJoingnable = staff.FirstOrDefault(s => string.IsNullOrEmpty(s.MobilePhoneNumber) && string.IsNullOrEmpty(s.Email));

            //La collection des employés n’ayant pas d’email renseigné.
            ObservableCollection<StaffMember> employeWithNoMail = new ObservableCollection<StaffMember>(staff.Where(s => string.IsNullOrEmpty(s.Email)));

            //La collection des employées(de genre féminin).
            ObservableCollection<StaffMember> womens = new ObservableCollection<StaffMember>(staff.Where(s => !s.Gender));

            //La collection des employés résidant à Mons.
            ObservableCollection<StaffMember> liveInMons = new ObservableCollection<StaffMember>(staff.Where(s => !string.IsNullOrEmpty(s.Address) && s.Address.Contains("7000")));

            // La collection des managers
            ObservableCollection<StaffMember> onlyManagers = new ObservableCollection<StaffMember>(staff.OfType<Manager>());

            //La collection des employés triés par ordre alphabétique de nom de famille.
            ObservableCollection<StaffMember> orderByNameAsc = new ObservableCollection<StaffMember>(staff.OrderBy(s => s.LastName));

            //Le pourcentage d’hommes dans le personnel (en une seule ligne de code).
            double pourcentMen = (100 * staff.Count(s => s.Gender)) / staff.Count;

            //Les employés par ordre croissant de salaire.
            //Impossible de récuperer un Protected depuis la main page

        }

        private void buttonTestReadWriteTextFileWithList_Clicked(object sender, EventArgs e)
        {
            string csvFilePath = @"C:\Users\kiros\Desktop\POO\MAUI\Brasse\Brasse\Configuration\Datas\Csv\Persons.csv";


            List<string> personsList = new List<string>();//create empty collection of string 
            personsList = File.ReadAllLines(csvFilePath).ToList();  // copy each line in the collection


            string s = "";
            foreach (string line in personsList)
            {
                s += $"\n{line}";
            }
            lblDebug.Text = s; //print collection's content 
                               //Add persons to collection. 
            personsList.Add("Customer;10;Maggi;Toni;true;maggiton@gmail.com;0491609830;Occasional"); 
            personsList.Add("Customer;11;Fernez;Jean;true;jeanfernez@gmail.com;0480458801;Regular "); 
            //write all lines in a new csv file. 
            File.WriteAllLines(@"C:\Users\kiros\Desktop\POO\MAUI\Brasse\Brasse\Configuration\Datas\Csv\PersonsRewrite.csv", personsList);
        }

        private void buttonTestPolymorphism_Clicked(object sender, EventArgs e)
        {
            Beer brasseTemps = new Beer(3, name: "Brasse Temps", "", 3.30, "biere.jpg", 21.0, 25,6.0, false, false);
            Alcohol al = brasseTemps;
            Drink d = brasseTemps;
            Item it = brasseTemps;
        }

        private void buttonTestNew_Clicked(object sender, EventArgs e)
        {
            StaffMember Lalande = new StaffMember(2, "Lalande", "Vanessa", false, "", "0485667098","BE80 6581 1145 3496", "16, rue de la loi 7080 Nivelles", 4000);
            Manager Jenlain = new Manager(3, "Jenlain", "Fabienne", false, "jenfab23@gmail.com", "0478901322", "BE80 4394 7739 1234", "13, rue de Mons 6000 Beaumont", 4000, "Password01");
            lblDebug.Text = $"\n Calcul du salaire depuis une référence de StaffMember pour { Lalande.LastName} : { Lalande.WageCalculation()}"; 
            lblDebug.Text = $"\n Calcul du salaire depuis une référence de Manager pour { Jenlain.LastName} : { Jenlain.WageCalculation()}";

            ObservableCollection<StaffMember> staff = new ObservableCollection<StaffMember>();
            staff.Add(Lalande);
            staff.Add(Jenlain);
            staff.ToList().ForEach(s => lblDebug.Text += $"\n Salaire de {s.LastName} de type {s.GetType()}: {s.WageCalculation()}");
        }

        private void buttonTestInterfaceAndDataAccess_Clicked(object sender, EventArgs e)
        {

            string CONFIG_FILE = @"C:\Users\kiros\Desktop\POO\MAUI\Brasse\Brasse\Configuration\Datas\Config.txt";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile daCsv = new DataAccessCsvFile(dataFilesManager);
            ItemsCollection items = daCsv.GetAllItems();
            items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix { it.UnitPrice.ToString()}€ -  { it.AutoDescription()}"); 
            CustomersCollection customers = daCsv.GetAllCustomers();
            customers.ToList().ForEach(c => lblDebug.Text += $"\n Client:{c.Id} {c.FirstName} { c.LastName}"); 
        }

        private void buttonTestDataAccessJsonFile_Clicked(object sender, EventArgs e)
        {

            string CONFIG_FILE = @"C:\Users\kiros\Desktop\POO\MAUI\Brasse\Brasse\Configuration\Datas\Config.txt";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessJsonFile da = new DataAccessJsonFile(dataFilesManager);

            ItemsCollection items = da.GetAllItems();

            items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix { it.UnitPrice.ToString()}€ -  { it.AutoDescription()}"); 


            items[0].Description = "on a change la description du 1er item";
            items[5].UnitPrice = 99.9; //changement du prix du 6ème item 
                                       //sauvegarde des données     
            da.UpdateAllItemsDatas(items);

        }

        private async void buttonTestDisplayAlert_Clicked(object sender, EventArgs e)
        {
            AlertServiceDisplay alertService = new AlertServiceDisplay();
            await alertService.ShowAlert("Titre de mon pop up", "voici un exemple d'alerte");

            if (await alertService.ShowConfirmation("Questionnaire", "Êtes-vous d'accord de répondre à une question ?", "Oui je suis d'accord", "Non pas maintenant"))
            {
                var userEntry = await alertService.ShowPrompt("Saisie du nom", "Votre prénom ?");
                var userChoice = await alertService.ShowQuestion("Votre brasserie préférée ?", "ORVAL", "ST FEUILLIEN", "CHIMAY");
                await alertService.ShowAlert("Choix brasserie", $"Merci {userEntry}, voici votre choix: {userChoice}");
            }
        }


    }
}

