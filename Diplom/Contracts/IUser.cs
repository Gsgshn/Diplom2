using Diplom.Data;
using Diplom.DTO;
using static Diplom.DTO.ServiceResponses;

namespace Diplom.Contracts
{
    public interface IUser
    {
        Task<GeneralResponse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
        Task<App?> FindApp(string appName);
        Task<List<User>> GetAllAccount();
        Task<User> GetUser(Guid Id);
        Task AddAppToUser(UserUpdateDTO userDTO, Guid Id);
    }
}
