using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class ThirdPage : ContentPage
{
    public ThirdPage()
    {
        InitializeComponent();

        // Bind the shared list to the UI
        BindingContext = this;
    }

    // Expose DataStore.Items to XAML
    public ObservableCollection<string> Items => DataStore.Items;

    private void OnAddClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(UserInput.Text))
        {
            DataStore.Items.Add(UserInput.Text);
            UserInput.Text = "";
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var item = (sender as Button)?.BindingContext as string;

        if (item == null)
            return;

        if (DataStore.Items.Count <= 1)
        {
            await DisplayAlert("Stop", "You must have at least one item.", "OK");
            return;
        }

        DataStore.Items.Remove(item);
    }
}
