using Microsoft.Maui.Devices.Sensors;

namespace MauiApp1;

public partial class SecondPage : ContentPage
{
    private readonly Random _random = new Random();
    private bool hasResponded = false;

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

    private async void OnShakeDetected(object sender, EventArgs e)
    {
        if (hasResponded)
            return;

        hasResponded = true;

        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            // 1. Shake animation for the 8-ball
            await EightBallImage.RotateTo(-15, 80);
            await EightBallImage.RotateTo(15, 80);
            await EightBallImage.RotateTo(-10, 60);
            await EightBallImage.RotateTo(10, 60);
            await EightBallImage.RotateTo(0, 80);

            // 2. Pick a random response
            if (ThirdPage.Items != null && ThirdPage.Items.Count > 0)
            {
                int index = _random.Next(ThirdPage.Items.Count);
                ResponseLabel.Text = ThirdPage.Items[index];
            }
            else
            {
                ResponseLabel.Text = "ERROR";
            }

            // 3. Fade in the response
            await ResponseLabel.FadeTo(1, 1200);

            // 4. Disable shake detection
            Accelerometer.Stop();

            // 5. Show Try Again button
            TryAgainButton.IsVisible = true;
        });
    }

    private async void TryAgainButton_Clicked(object sender, EventArgs e)
    {
        // Fade out the old response
        await ResponseLabel.FadeTo(0, 500);

        ResponseLabel.Text = "";
        hasResponded = false;

        // Re-enable shake detection
        Accelerometer.Start(SensorSpeed.Game);

        // Hide the Try Again button
        TryAgainButton.IsVisible = false;
    }
}
