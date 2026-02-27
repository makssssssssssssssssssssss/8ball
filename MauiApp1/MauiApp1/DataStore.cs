using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp1;

public static class DataStore
{
    private const string StorageKey = "Magic8BallItems";

    public static ObservableCollection<string> Items { get; private set; }

    static DataStore()
    {
        // Load saved list if it exists
        if (Preferences.ContainsKey(StorageKey))
        {
            try
            {
                var json = Preferences.Get(StorageKey, "");
                var list = JsonSerializer.Deserialize<List<string>>(json);

                Items = new ObservableCollection<string>(list ?? new List<string>());
            }
            catch
            {
                Items = LoadDefaultItems();
            }
        }
        else
        {
            Items = LoadDefaultItems();
        }

        // Auto-save whenever the list changes
        Items.CollectionChanged += (_, __) => Save();
    }

    private static ObservableCollection<string> LoadDefaultItems()
    {
        return new ObservableCollection<string>
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

    private static void Save()
    {
        var json = JsonSerializer.Serialize(Items.ToList());
        Preferences.Set(StorageKey, json);
    }

    public static void ResetToDefault()
    {
        // Replace the list with a fresh default set
        Items = LoadDefaultItems();

        // Reattach auto-save
        Items.CollectionChanged += (_, __) => Save();

        // Save immediately
        Save();
    }
}
