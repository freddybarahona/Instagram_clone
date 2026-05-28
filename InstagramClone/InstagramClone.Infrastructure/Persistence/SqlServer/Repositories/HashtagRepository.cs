using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Interfaces.Repositories;

namespace InstagramClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class HashtagRepository(InstagramCloneContext context) : IHashtagRepository
    {
        // en casos dentro del repo donde no necesites retornar nada ya que puede no ejecutar
        //asi que en vez de usar public async void usa public async Task como retorno en
        //metodos de repo
        public async Task Create(Hashtag hashtag)
        {
            try
            {
                await context.Hashtags.AddAsync(hashtag);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
