using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Interfaces.Repositories;

namespace InstagramClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class PostRepository(InstagramCloneContext context) : IPostRepository
    {
        public async Task<Post> Create(Post post)
        {
            try
            {
                await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();
                return post;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
