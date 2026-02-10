using Android.App;
using Android.OS;
using Android.Views;
using Android.Content.PM;


namespace MauiApp1;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    ConfigurationChanges =
        Android.Content.PM.ConfigChanges.ScreenSize
        | Android.Content.PM.ConfigChanges.Orientation
        | Android.Content.PM.ConfigChanges.UiMode
        | Android.Content.PM.ConfigChanges.ScreenLayout
        | Android.Content.PM.ConfigChanges.SmallestScreenSize
)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var window = this.Window;
        RequestedOrientation = ScreenOrientation.Portrait;

        window.SetStatusBarColor(Android.Graphics.Color.Transparent);
        window.AddFlags(WindowManagerFlags.LayoutNoLimits);
    }
}
