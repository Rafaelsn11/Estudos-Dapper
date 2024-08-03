using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class CategoryRepository : Repository<Category>
{
    private readonly SqlConnection _connection;

    public CategoryRepository(SqlConnection connection)
    : base(connection)
        => _connection = connection;

    public IEnumerable<Category> GetCategoriesWithPostCounts()
    {
        var query = @"
        SELECT
            [Category].[Id],
            [Category].[Name],
            [Category].[Slug],
            COUNT([Post].[Id]) AS PostCount
        FROM
            [Category]
            LEFT JOIN [Post] ON [Category].[Id] = [Post].[CategoryId]
        GROUP BY
            [Category].[Id],
            [Category].[Name],
            [Category].[Slug]
        ";

        var categoriesWithPostCounts = _connection.Query(query)
        .Select(row => new
        {
            Id = row.Id,
            Name = row.Name,
            Slug = row.Slug,
            PostCount = (int)row.PostCount
        }).ToList();

        var categories = categoriesWithPostCounts.Select(item => new Category
        {
            Id = item.Id,
            Name = item.Name,
            Slug = item.Slug,
            Posts = new List<Post>(Enumerable.Repeat(new Post(), item.PostCount))
        }).ToList();

        return categories;
    }

    public List<Post> GetEveryPostWithYourCategory()
    {
        var query = @"
        SELECT
            [Post].[Id],
            [Post].[Title],
            [Category].[Id] AS [CategoryId],
            [Category].[Name] 
        FROM
            [Post]
            LEFT JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
        ";

        var posts = _connection.Query<Post, Category, Post>(
            query,
            (post, category) =>
            {
                post.Category = category;
                return post;
            },
            splitOn: "CategoryId"
        ).ToList();

        return posts;
    }

    public List<Post> GetPostsByCategoryId(int categoryId)
    {
        var query = @"
        SELECT
            [Post].[Id],
            [Post].[Title],
            [Category].[Id] AS [CategoryId],
            [Category].[Name]
        FROM
            [Post]
            INNER JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
        WHERE
            [Post].[CategoryId] = @CategoryId
        ";

        var posts = _connection.Query<Post, Category, Post>(
            query,
            (post, category) =>
            {
                post.Category = category;
                return post;
            },
            new {CategoryId = categoryId},
            splitOn: "CategoryId"
        ).ToList();

        return posts;
    }
}
