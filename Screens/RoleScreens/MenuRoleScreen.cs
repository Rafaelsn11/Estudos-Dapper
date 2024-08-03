namespace Blog.Screens.RoleScreens;

public class MenuRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de perfis");
        Console.WriteLine("-----------------");
        Console.WriteLine("O que deseja fazer? \n");
        Console.WriteLine("1 - Listar perfis");
        Console.WriteLine("2 - Cadastrar perfis");
        Console.WriteLine("3 - Atualizar perfil");
        Console.WriteLine("4 - Excluir perfil\n\n");

        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1: ListRolesScreen.Load(); break;
            case 2: CreateRoleScreen.Load(); break;
            case 3: UpdateRoleScreen.Load(); break;
            case 4: DeleteRoleScreen.Load(); break;
            default:
                break;
        }
    }
}
