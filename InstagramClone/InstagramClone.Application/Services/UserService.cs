using InstagramClone.Application.Helpers;
using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests.Users;
using InstagramClone.Application.Models.Responses;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Interfaces.Repositories;
using InstagramClone.Shared.Helper;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Application.Services
{
    public class UserService(IUserRepository repository, ITypeUserRepository typeUserRepository) : IUserService
    {
        public async Task<GenericResponse<UserDTO>> Create(CreateUserRequest model)
        {
            var typeUser = await typeUserRepository.Get(model.TypeUser); // obtiene el tipo de usuario especificado en la tabla TypeUser
            var userEntity = new Domain.Database.SqlServer.Entities.User // crea una nueva entidad de usuario con los datos proporcionados en el modelo de solicitud
            {
                NameUser = model.NameUser,
                Email = model.Email,
                Password = model.Password,
                Visibility = model.Visibility,
                TypeUserId = typeUser.IdTypeUser,
                CreatedAt = DateTimeHelper.UtcNow(),
                UpdatedAt = DateTimeHelper.UtcNow(),
            };

            var created = await repository.Create(userEntity); // guarda la nueva entidad de usuario en la base de datos utilizando el repositorio de usuarios
            return ResponseHelper.Create(Map(created));
        }


        public async Task<GenericResponse<List<UserDTO>>> GetUser(GetUsersRequest model)
        {
            var queryable = repository.Queryable();
            //filtrado de nombre
            if (!string.IsNullOrWhiteSpace(model.NameUser))
            {
                queryable = queryable.Where(x => x.NameUser.Contains(model.NameUser ?? ""));
            }
            //filtrado de id
            if (!string.IsNullOrWhiteSpace(model.Id.ToString()))
            {
                queryable = queryable.Where(x => x.IdUser == model.Id);
            }

            //realizar paginacion y consulta
            var users = await queryable
                            //en este caso este include no es necesario porque el mapeo del DTO se hace con el IdTypeUser, pero si quisieramos traer la informacion completa del tipo de usuario si seria necesario este include
                            //.Include(u => u.TypeUser)//lo que hace esto es traer la informacion completa del tipo de usuario para poder mapearlo en el DTO
                            .Skip(model.offset)
                            .Take(model.limit)
                            .ToListAsync();
            //mapear colaboradores y guardarlos en una lista
            List<UserDTO> mapped = [];
            foreach (var user in users)
            {
                mapped.Add(Map(user));
            }

            return ResponseHelper.Create(mapped);

        }

        public async Task<GenericResponse<UserDTO?>> GetUserById(Guid UserId)
        {
            var UserEntity = await GetTheUser(UserId);
            return ResponseHelper.Create(Map(UserEntity));
        }

        public async Task<User> GetTheUser(Guid UserId)
        {
            return await repository.GetUserById(UserId)
                ?? throw new Exception("no hay usuario bro");
        }

        private static UserDTO Map(User user)
        {
            return new UserDTO
            {
                IdUser = user.IdUser,
                NameUser = user.NameUser,
                Email = user.Email,
                Password = user.Password,
                Visibility = user.Visibility,
                TypeUser = user.TypeUser?.IdTypeUser.ToString() ?? user.TypeUserId.ToString(), //la primera opcion es porque el metodo crear usuario hace un llamado a la tabla de TypeUser para comparar pero el segundo llamado es porque el get no hace ese llamado ya que debe usar el id que ya esta en la tabla User por eso el primer llamado va a dar null
                CreatedAt = user.CreatedAt,
            };
        }
    }
}
