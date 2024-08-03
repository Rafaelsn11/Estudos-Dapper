using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;

namespace Blog.Screens.TagScreens;

public static class LinkTagToPostScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Vinculando post/tag");
        Console.WriteLine("------------------------------");

        Console.WriteLine();
        Console.WriteLine("Escolha qual post irá ser vinculado(Pelo Id)");
        var idPost = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine("Agora escolha a tag para esse post escolhido(Pelo Id)");
        var idTag = Console.ReadLine();

        Insert(int.Parse(idPost), int.Parse(idTag));
        Console.ReadKey();
        MenuTagScreen.Load();
    }

    public static void Insert(int idPost, int idTag)
    {
        try
        {
            var repository = new TagRepository(Database.Connection);
            repository.AddPostToTag(idPost, idTag);
            Console.WriteLine("Vinculo realizado");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Vinculo não realizado");
            Console.WriteLine(ex.Message);
        }
    }
}
