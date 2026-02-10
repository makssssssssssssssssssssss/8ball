namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SecondPage));
        }
        private async void OnThirdPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThirdPage());
        }
        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private async void ListButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThirdPage());
        }


    }

}
