using Blog;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.ReportsScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


static class Program
{
    private static string GetConnectionString(string name)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();
        return configuration.GetConnectionString(name);
    }
    static void Main()
    {   
        var connectionString = GetConnectionString("DefaultConnection");

        Database.Connection = new SqlConnection(connectionString);
        Database.Connection.Open();

        Load();

        Console.ReadKey();
        Database.Connection.Close();

    }

    private static void Load()
    {
        Console.Clear();
        Console.WriteLine("Meu Blog");
        Console.WriteLine("-----------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Gestão de usuário");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestão de categoria");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Vincular perfil/usuário");
        Console.WriteLine("6 - Vincular post/tag");
        Console.WriteLine("7 - Relatórios");
        Console.WriteLine("8 - Fazer um Post");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1:
                MenuUserScreen.Load();
                break;
            case 2:
                MenuRoleScreen.Load();
                break;
            case 3:
                MenuCategoryScreen.Load();
                break;
            case 4:
                MenuTagScreen.Load();
                break;
            case 5:
                LinkRoleToUserScreens.Load();
                break;
            case 6:
                LinkTagToPostScreen.Load();
                break;
            case 7:
                MenuReportsScreen.Load();
                break;
            case 8:
                CreatePostScreen.Load();
                break;
            default: Load(); break; 
        }
    }
}