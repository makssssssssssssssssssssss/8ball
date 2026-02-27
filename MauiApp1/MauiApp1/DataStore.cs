using System.Collections.ObjectModel;

namespace MauiApp1;

public static class DataStore
{
    public static ObservableCollection<string> Items { get; private set; }

    static DataStore()
    {
        Items = new ObservableCollection<string>
        {
            "Without a doubt",
            "It is certain",
            "It is decidedly so",
            "Yes definitely",
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
}
