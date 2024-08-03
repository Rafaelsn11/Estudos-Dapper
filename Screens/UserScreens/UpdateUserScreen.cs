using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public class UpdateUserScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Novo usuário");
        Console.WriteLine("---------------");

        Console.WriteLine("Id: ");
        var id = Console.ReadLine();

        Console.WriteLine("Nome: ");
        var name = Console.ReadLine();

        Console.WriteLine("Slug: ");
        var slug = Console.ReadLine();

        Console.WriteLine("Email: ");
        var email = Console.ReadLine();

        Console.WriteLine("Password Hash: ");
        var passwordHash = Console.ReadLine();

        Console.WriteLine("Bio: ");
        var bio = Console.ReadLine();

        Console.WriteLine("Image: ");
        var image = Console.ReadLine();

        Update(new User
        {
            Id = int.Parse(id),
            Name = name,
            Slug = slug,
            Email = email,
            PasswordHash = passwordHash,
            Bio = bio,
            Image = image
        });
        Console.ReadKey();
        MenuUserScreen.Load();
    }

    public static void Update(User user)
    {
        try
        {
            var repository = new Repository<User>(Database.Connection);
            repository.Update(user);
            Console.WriteLine("Usuário atualizado com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possível atualizar o usuário");
            Console.WriteLine(ex.Message);
        }
    }
}
