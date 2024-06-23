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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { }
           
           
        }

        public async Task DeleteApp(AppDTO appDTO)
        {
             await _context.Apps.Where(c => c.Name == appDTO.Name).ExecuteDeleteAsync();

        }

        public async Task UpdateApp(AppUpdateDTO appDTO)
        {

            if (string.IsNullOrWhiteSpace(appDTO.NewName)) { appDTO.NewName = appDTO.Name; }

            var app = await _context.Apps.Where(c => c.Name == appDTO.Name).FirstOrDefaultAsync();
             
            if(appDTO.NewName != null) app.Name = appDTO.NewName;
            
             await _context.SaveChangesAsync();
            
        }

        

        public async Task AddUserToApp(AppUpdateDTO appDTO, Guid Id)
        {
            var app = await _context.Apps.Where(c => c.Name == appDTO.Name).FirstOrDefaultAsync();
            var userApp =  new UserApp { AppId = app.Id, UserId = Id };
            await _context.UserApps.AddAsync(userApp);
            await _context.SaveChangesAsync();
        }

        


    }
}
