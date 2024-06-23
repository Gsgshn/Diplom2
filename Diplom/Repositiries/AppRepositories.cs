using Diplom.Contracts;
using Diplom.Data;
using Diplom.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Diplom.DTO.ServiceResponses;

namespace Diplom.Repositiries
{
    public class AppRepositories : IApp
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        

        public AppRepositories(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task AddApp(AppDTO appDTO)
        {
            
           
            App app = new App { Id = Guid.NewGuid(), Name = appDTO.Name };

            
             await _context.Apps.AddAsync(app);
            
             await _context.SaveChangesAsync(); 
           
           
        }

        public async Task DeleteApp(AppDTO appDTO)
        {
             await _context.Apps.Where(c => c.Name == appDTO.Name).ExecuteDeleteAsync();

        }

        public async Task UpdateApp(AppUpdateDTO appDTO, Guid Id)
        {

            if (string.IsNullOrWhiteSpace(appDTO.NewName)) { appDTO.NewName = appDTO.Name; }


            await _context.Apps
                .Where(c => c.Name == appDTO.Name)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Name, appDTO.NewName)
                .SetProperty(c => c.UserId, Id));
        }

        
    }
}
