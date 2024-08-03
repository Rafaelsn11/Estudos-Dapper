using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens;

public class DeleteRoleScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Excluir uma tag");
        Console.WriteLine("---------------");
        Console.WriteLine("Qual o id da Tag que deseja excluir? ");
        var id = Console.ReadLine();

        Delete(int.Parse(id));
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Role>(Database.Connection);
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
