using Blog.Repositories;

namespace Blog.Screens.ReportsScreens;

public static class ListTagWithNumberPost
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listagem de tags com quantidade de posts");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine();
        ListTagWithYourPosts();
        Console.ReadKey();
        MenuReportsScreen.Load();
    }

    public static void ListTagWithYourPosts()
    {
        var repository = new TagRepository(Database.Connection);
        var tagsWithPostCount = repository.GetTagWithPostCounts();

        foreach (var tag in tagsWithPostCount)
        {
            Console.WriteLine($"{tag.Id} - {tag.Name} - {tag.Posts.Count}");
        }
    }
}
