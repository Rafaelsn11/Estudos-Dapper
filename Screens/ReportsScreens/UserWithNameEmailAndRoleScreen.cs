using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreens;

public static class UserWithNameEmailAndRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listagem do Usuário pelo nome, email e perfil: ");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine();
        ListUserWithNameEmailAndRole();
        Console.ReadLine();
        MenuReportsScreen.Load();
    }

    private static void ListUserWithNameEmailAndRole()
    {
        var repository = new UserRepository(Database.Connection);
        var users = repository.GetWithRoles();

        foreach (var user in users)
        {
            Console.Write($"\n{user.Name}, {user.Email}, ");
            foreach (var item in user.Roles)
            {
                Console.Write($"{item.Name} \n");
            }
        }
    }
}
