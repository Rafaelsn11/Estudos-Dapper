using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public static class DeleteUserScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Excluir uma usuário");
        Console.WriteLine("---------------");
        Console.WriteLine("Qual o id do usuário que deseja excluir? ");
        var id = Console.ReadLine();

        Delete(int.Parse(id));
        Console.ReadKey();
        MenuUserScreen.Load();
    }

    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<User>(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Usuário excluído com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possível excluir o usuário");
            Console.WriteLine(ex.Message);
        }
    }
}
