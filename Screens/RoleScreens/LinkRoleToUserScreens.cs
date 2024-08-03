using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreens;

public static class LinkRoleToUserScreens
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Vinculando perfil/Usuário");
        Console.WriteLine("------------------------------");

        Console.WriteLine();
        Console.WriteLine("Escolha qual usuário irá ser vinculado(Pelo Id)");
        var idUser = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine("Agora escolha o perfil para esse usuário escolhido(Pelo Id)");
        var idRole = Console.ReadLine();

        Insert(int.Parse(idUser), int.Parse(idRole));
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    public static void Insert(int idUser, int idRole)
    {
        try
        {
            var repository = new UserRepository(Database.Connection);
            repository.AddRoleToUSer(idUser, idRole);
            Console.WriteLine("Vinculo feito com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro no vinculo");
            Console.WriteLine(ex.Message);
        }
        
    }
}


