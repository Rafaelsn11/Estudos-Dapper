using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens;

public static class CreatePostScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("id do Autor: ");
        var author = Console.ReadLine();
        Console.WriteLine("Qual a categoria do seu post: ");
        var category = Console.ReadLine();
        Console.WriteLine("Diga o titulo do post: ");
        var title = Console.ReadLine();
        Console.WriteLine("Digite o sumário do seu post: ");
        var summary = Console.ReadLine();
        Console.WriteLine("Digite o conteúdo do seu post: ");
        var body = Console.ReadLine();
        Console.WriteLine("Digite o Slug");
        var slug = Console.ReadLine();


        var repositoryAuthor = new Repository<User>(Database.Connection);
        var authorUser = repositoryAuthor.Get(int.Parse(author));

        var repositoryCategory = new Repository<Category>(Database.Connection);
        var categoryCategory = repositoryCategory.Get(int.Parse(category));

        Create(new Post
        {
            Title = title,
            Summary = summary,
            Body = body,
            Slug = slug,
            CreateDate = DateTime.Now.Date,
            LastUpdateDate = DateTime.Now.Date,
            AuthorId = int.Parse(author),
            CategoryId = int.Parse(category),
            Category = categoryCategory,
            Author = authorUser
        });
    }

    public static void Create(Post post)
    {
        try
        {
            var repository = new Repository<Post>(Database.Connection);
            repository.Create(post);
            Console.WriteLine("Post criado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Post não criado");
            Console.WriteLine(ex.Message);
        }
    }
}
