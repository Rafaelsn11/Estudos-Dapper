using Blog.Repositories;

namespace Blog.Screens.ReportsScreens;

public static class ListEveryPostWithYourCategory
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listagem de post com quantidade de categoria");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine();
        ListPostWithYourCategory();
        Console.ReadKey();
        MenuReportsScreen.Load();
    }

    public static void ListPostWithYourCategory()
    {
        var repository = new CategoryRepository(Database.Connection);
        var postWithYourCategory = repository.GetEveryPostWithYourCategory();

        foreach (var post in postWithYourCategory)
        {
            Console.WriteLine($"{post.Id} - {post.Title} - {post.Category.Name}");
        }
    }
}
