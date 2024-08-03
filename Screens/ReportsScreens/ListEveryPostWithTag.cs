using Blog.Repositories;

namespace Blog.Screens.ReportsScreens;

public static class ListEveryPostWithTag
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listagem de post com quantidade de tag");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine();
        ListPostWithYourTag();
        Console.ReadKey();
        MenuReportsScreen.Load();
    }

    public static void ListPostWithYourTag()
    {
        var repository = new TagRepository(Database.Connection);
        var postWithYourTag = repository.GetEveryPostWithYourTag();

        foreach (var post in postWithYourTag)
        {
            Console.Write($"{post.Id} - {post.Title} - ");
            foreach (var item in post.Tags)
            {
                Console.Write($"{item.Name}\n"); 
            }
        }
    }
}
