using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens;

public static class DeleteCategoryScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Excluir uma categoria");
        Console.WriteLine("---------------");
        Console.WriteLine("Qual o id da categoria que deseja excluir? ");
        var id = Console.ReadLine();

        Delete(int.Parse(id));
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Category>(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Perfil excluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possível excluir a perfil");
            Console.WriteLine(ex.Message);
        }
    }
}
