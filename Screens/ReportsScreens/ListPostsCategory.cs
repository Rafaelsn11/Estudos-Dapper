using Blog.Repositories;

namespace Blog.Screens.ReportsScreens;

public static class ListPostsCategory
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Digite o Id da Categoria que vocẽ quer analisar os posts: ");
        var categoryId = Console.ReadLine();
        ListPostsOfCategory(int.Parse(categoryId));
        Console.ReadKey();
        MenuReportsScreen.Load();
    }

    public static void ListPostsOfCategory(int categoryId)
    {
        var repository = new CategoryRepository(Database.Connection);
        var posts = repository.GetPostsByCategoryId(categoryId);

        foreach (var post in posts)
        {
            Console.WriteLine($"{post.Id} - {post.Title} - {post.Category.Name}");
        }
    }
}
