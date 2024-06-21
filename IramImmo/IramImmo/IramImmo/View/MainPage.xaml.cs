using IramImmo.ViewModel;

namespace IramImmo.View

{

    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageVM)
        {
            BindingContext = mainPageVM;
            InitializeComponent();
        }


    }


}
