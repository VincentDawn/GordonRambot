namespace GordonRambot
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

         public async void OnStartCookingClicked(object sender, EventArgs e)
        {
          await Navigation.PushAsync(new AllergensPage());
        }
    }
}
