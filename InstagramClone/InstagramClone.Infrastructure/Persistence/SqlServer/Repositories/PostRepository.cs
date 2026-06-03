using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class PostRepository(InstagramCloneContext context) : IPostRepository
    {
        public async Task<Post> Create(Post post)
        {
            await context.Posts.AddAsync(post);
            return post;
        }

        public async Task<List<Post>> GetPostsByUserId(Guid id)
        {
            return await context.Posts.Where(P => P.UserId == id && P.DeletedAt == null).OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public IQueryable<Post> Queryable()
        {
            return context.Posts
                .Include(p => p.User)
                .Include(p => p.Hashtags)
                .Include(p => p.Users)
                .Where(x => x.DeletedAt == null);
        }
    }
}
