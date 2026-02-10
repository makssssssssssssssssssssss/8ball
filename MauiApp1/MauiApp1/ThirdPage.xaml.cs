using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class ThirdPage : ContentPage
{
    public static ObservableCollection<string> Items { get; private set; }

    public ThirdPage()
    {
        InitializeComponent();

        // Create the shared list only once
        if (Items == null)
        {
            Items = new ObservableCollection<string>
            {
                "Without a doubt",
                "It is certain",
                "It is decidedly so",
                "Yes defintely",
                "You may rely on it",
                "Most likely",
                "Outlook good",
                "As I see it, yes",
                "Yes",
                "Signs point to yes",
                "Very doubtful",
                "My reply is no",
                "Don't count on it",
                "Outlook not so good",
                "Better not tell you now",
                "My sources say no",
                "Ask again later",
                "Reply hazy, try again",
                "Concentrate and try again",
                "Cannot predict now"
            };
        }

        // Bind the shared list to THIS page's UI
        BindingContext = this;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        var text = UserInput.Text;

        if (!string.IsNullOrWhiteSpace(text))
        {
            Items.Add(text);
            UserInput.Text = string.Empty;
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var item = (sender as Button)?.BindingContext as string;

        if (item == null)
            return;

        if (Items.Count <= 1)
        {
            await DisplayAlert("Stop", "You must have at least one item.", "OK");
            return;
        }

        Items.Remove(item);
    }
}

