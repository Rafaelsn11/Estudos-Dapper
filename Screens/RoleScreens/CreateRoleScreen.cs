using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens;

public class CreateRoleScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Novo perfil");
        Console.WriteLine("---------------");
        Console.WriteLine("Nome: ");
        var name = Console.ReadLine();

        Console.WriteLine("Slug: ");
        var slug = Console.ReadLine();

        Create(new Role
        {
            Name = name,
            Slug = slug
        });
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    public static void Create(Role role)
    {
        try
        {
            var repository = new Repository<Role>(Database.Connection);
            repository.Create(role);
            Console.WriteLine("perfil cadastrada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possível salvar a perfil");
            Console.WriteLine(ex.Message);
        }
    }
}
