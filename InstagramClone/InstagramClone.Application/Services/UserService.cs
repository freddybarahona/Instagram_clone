using InstagramClone.Application.Helpers;
using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests.Users;
using InstagramClone.Application.Models.Responses;
using InstagramClone.Domain.Database.SqlServer.Entities;
using InstagramClone.Domain.Interfaces.Repositories;
using InstagramClone.Shared.Helper;

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
            var users = queryable.Skip(model.offset).Take(model.limit).ToList();
            //mapear colaboradores y guardarlos en una lista
            List<UserDTO> mapped = [];
            foreach (var user in users)
            {
                mapped.Add(Map(user));// el error esta aqui revisalo
            }

            return ResponseHelper.Create(mapped);

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
                TypeUser = user.TypeUser.ToString(),
                CreatedAt = user.CreatedAt,
            };
        }
    }
}
