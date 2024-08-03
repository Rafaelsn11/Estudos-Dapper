namespace Blog.Screens.ReportsScreens;

public static class MenuReportsScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Relatórios");
        Console.WriteLine("-----------------");
        Console.WriteLine("O que deseja fazer? \n");
        Console.WriteLine("1 - Listar os usuários(Nome. Email e perfis)");
        Console.WriteLine("2 - Listar categorias com quantidade de posts");
        Console.WriteLine("3 - Listar tags com quantidade de posts");
        Console.WriteLine("4 - Listar os posts de uma categoria");
        Console.WriteLine("5 - Listar todos posts com sua categoria");
        Console.WriteLine("6 - Listar os posts com suas tags\n\n");
        

        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1: UserWithNameEmailAndRoleScreen.Load(); break;
            case 2: ListCategoryWithNumberPost.Load(); break;
            case 3: ListTagWithNumberPost.Load(); break;
            case 4: ListPostsCategory.Load(); break;
            case 5: ListEveryPostWithYourCategory.Load(); break;
            case 6: ListEveryPostWithTag.Load(); break;
            default:
                break;
        }
    }
}
