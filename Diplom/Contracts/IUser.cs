using Diplom.DTO;
using static Diplom.DTO.ServiceResponses;

namespace Diplom.Contracts
{
    public interface IUser
    {
        Task<GeneralResponse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
