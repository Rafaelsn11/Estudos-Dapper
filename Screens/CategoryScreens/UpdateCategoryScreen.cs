using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens;

public class UpdateCategoryScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Nova tag");
        Console.WriteLine("---------------");
        Console.WriteLine("id: ");
        var id = Console.ReadLine();

        Console.WriteLine("Nome: ");
        var name = Console.ReadLine();

        Console.WriteLine("Slug: ");
        var slug = Console.ReadLine();

        Update(new Category
        {
            Id = int.Parse(id),
            Name = name,
            Slug = slug
        });
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    public static void Update(Category category)
    {
        try
        {
            var repository = new Repository<Category>(Database.Connection);
            repository.Update(category);
            Console.WriteLine("Categoria atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possível atualizar a categoria");
            Console.WriteLine(ex.Message);
        }
    }
}
