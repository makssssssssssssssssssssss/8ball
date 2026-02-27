namespace MauiApp1;

public static class DataStore
{
    public static List<string> Items { get; private set; } = new();

    static DataStore()
    {
        // Load default items here
        Items = new List<string>
        {
            "Yes",
            "No",
            "Ask again later",
            "Definitely",
            "Uncertain"
        };
    }
}
