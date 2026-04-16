using InstagramClone.Application.Helpers;
using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests;
using InstagramClone.Application.Models.Responses;
using InstagramClone.Shared.Helper;

namespace InstagramClone.Application.Services
{
    public class UserService : IUserService
    {
        public GenericResponse<UserDTO> Create(CreateUserRequest Model)
        {
            var User = new UserDTO
            {
                IdUser = Guid.NewGuid(),
                NameUser = Model.NameUser,
                Email = Model.Email,
                Password = Model.Password,
                //TypeUserId = en proceso porque hay que conectar la tabla TypeUser
                Visibility = Model.Visibility,
                CreatedAt = DateTimeHelper.UtcNow()
            };
            return ResponseHelper.Create(User, "Usuario creado exitosamente");
        }

        public GenericResponse<UserDTO> UpdatePasswordUser(Guid id, UpdatePasswordUserRequest Model)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<UserDTO> UpdateUser(Guid id, UpdateUserRequest Model)
        {
            throw new NotImplementedException();
        }
    }
}
