using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens;

public class UpdateRoleScreen
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

        Update(new Role
        {
            Id = int.Parse(id),
            Name = name,
            Slug = slug
        });
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    public static void Update(Role role)
    {
        try
        {
            var repository = new Repository<Role>(Database.Connection);
            repository.Update(role);
            Console.WriteLine("Perfil atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possível atualizar o Perfil");
            Console.WriteLine(ex.Message);
        }
    }
}
