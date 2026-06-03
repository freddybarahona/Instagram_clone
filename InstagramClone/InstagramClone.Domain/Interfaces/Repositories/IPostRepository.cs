using InstagramClone.Domain.Database.SqlServer.Entities;

namespace InstagramClone.Domain.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<Post> Create(Post post);
        IQueryable<Post> Queryable();
        Task<List<Post>> GetPostsByUserId(Guid id);
    }
}
