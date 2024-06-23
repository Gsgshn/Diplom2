using Diplom.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Contracts
{
    public interface IApp
    {
        Task AddApp(AppDTO appDTO); 
        Task DeleteApp(AppDTO appDTO);
        Task UpdateApp(AppUpdateDTO appDTO);
        Task AddUserToApp(AppUpdateDTO appDTO, Guid Id);
    }
}
