using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests;
using InstagramClone.Application.Models.Responses;

namespace InstagramClone.Application.Interfaces.Services
{
    public interface IUserService
    {
        public GenericResponse<UserDTO> Create(CreateUserRequest Model);
        public GenericResponse<UserDTO> UpdateUser(Guid id, UpdateUserRequest Model);
        public GenericResponse<UserDTO> UpdatePasswordUser(Guid id, UpdatePasswordUserRequest Model);
    }
}
