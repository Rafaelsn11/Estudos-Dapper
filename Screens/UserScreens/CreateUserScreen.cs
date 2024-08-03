using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public static class CreateUserScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Novo usuário");
        Console.WriteLine("---------------");
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

        Create(new User
        {
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

    public static void Create(User user)
    {
        try
        {
            var repository = new Repository<User>(Database.Connection);
            repository.Create(user);
            Console.WriteLine("Usuário cadastrado com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nao foi possível salvar o usuário");
            Console.WriteLine(ex.Message);
        }
    }
}
