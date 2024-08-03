using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreens;

public static class ListCategoryWithNumberPost
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listagem de categorias com quantidade de posts");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine();
        ListCategoryWithYourPosts();
        Console.ReadKey();
        MenuReportsScreen.Load();
    }

    public static void ListCategoryWithYourPosts()
    {
        var repository = new CategoryRepository(Database.Connection);
        var categoriesWithPostCounts = repository.GetCategoriesWithPostCounts();

        foreach (var category in categoriesWithPostCounts)
        {
            Console.WriteLine($"{category.Id} - {category.Name} - {category.Posts.Count}");
        }
    }
}
