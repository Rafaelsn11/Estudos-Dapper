using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class TagRepository : Repository<Tag>
{
    private readonly SqlConnection _connection;

    public TagRepository(SqlConnection connection)
    : base(connection)
        => _connection = connection;

    public void AddPostToTag(int idPost, int idTag)
    {
        var query = "INSERT INTO [PostTag] (PostId, TagId) VALUES(@PostId, @TagId)";
        var pars = new {PostId = idPost, TagId = idTag};

        _connection.Execute(query, pars);
    }

    public IEnumerable<Tag> GetTagWithPostCounts()
    {
        var query = @"
        SELECT
            [Tag].[Id],
            [Tag].[Name],
            [Tag].[Slug],
            COUNT([Post].[Id]) AS PostCount
        FROM
            [Tag]
            LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
            LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]
        GROUP BY
            [Tag].[Id],
            [Tag].[Name],
            [Tag].[Slug]
        ";

        var tagsWithPostCount = _connection.Query(query)
        .Select(row => new
        {
            Id = row.Id,
            Name = row.Name,
            Slug = row.Slug,
            PostCount = (int)row.PostCount
        }).ToList();

        var tags = tagsWithPostCount.Select(item => new Tag
        {
            Id = item.Id,
            Name = item.Name,
            Slug = item.Slug,
            Posts = new List<Post>(Enumerable.Repeat(new Post(), item.PostCount))
        }).ToList();

        return tags;
    }

    public List<Post> GetEveryPostWithYourTag()
    {
        var query = @"
        SELECT
            [Post].[Id],
            [Post].[Title],
            [Tag].[Id] AS [TagId],
            [Tag].[Name] 
        FROM
            [Tag]
            LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
            LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]
        ";

        var posts = new List<Post>();

        var items = _connection.Query<Post, Tag, Post>(
            query,
            (post, tag) =>
            {
                var pos = posts.FirstOrDefault(x => x.Id == post.Id);
                if (pos == null)
                {
                    pos = post;
                    if (tag != null)
                        pos.Tags.Add(tag);
                    
                    posts.Add(pos);
                }
                else
                    pos.Tags.Add(tag);

                return post;
            }, splitOn: "TagId");

        return posts;
    }
}
