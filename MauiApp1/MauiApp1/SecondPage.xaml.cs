using Microsoft.Maui.Devices.Sensors;

namespace MauiApp1;

public partial class SecondPage : ContentPage
{
    private readonly Random _random = new Random();

    public SecondPage()
    {
        InitializeComponent();
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        Accelerometer.ShakeDetected += OnShakeDetected;
        Accelerometer.Start(SensorSpeed.Game);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        Accelerometer.ShakeDetected -= OnShakeDetected;
        Accelerometer.Stop();
    }

    private void OnShakeDetected(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            // Make sure the list exists and has items
            if (ThirdPage.Items != null && ThirdPage.Items.Count > 0)
            {
                int index = _random.Next(ThirdPage.Items.Count);
                string randomItem = ThirdPage.Items[index];

                // Update the label on the page
                ResponseLabel.Text = randomItem;
            }
            else
            {
                ResponseLabel.Text = "ERROR";
            }
        });
    }
}
