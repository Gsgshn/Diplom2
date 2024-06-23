using Diplom.Contracts;
using Diplom.Data;
using Diplom.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Diplom.DTO.ServiceResponses;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppsController(IApp app, UserManager<User> userManager) : ControllerBase
    {
        

        [HttpPost ("CreateApp")]
        public async Task<GeneralResponse> CreateApp(AppDTO appDTO)
        {
            if (appDTO == null) return new GeneralResponse(false, "Model is empty");

            
            app.AddApp (appDTO);
           
               
            
            return new GeneralResponse(true, "App created");
           
        }

        [HttpDelete ("DeleteApp")]
        public async Task<GeneralResponse> DeleteApp(AppDTO appDTO)
        {
            if (appDTO == null) return new GeneralResponse(false, "Model is empty");

            app.DeleteApp (appDTO);
            return new GeneralResponse(true, "App deleted");
        }

        [HttpPost ("UpdateApp")]
        public async Task<GeneralResponse> UpdateApp(AppUpdateDTO appDTO)
        {
            var user = await userManager.FindByEmailAsync(appDTO.EmailUser);
            if (appDTO == null) return new GeneralResponse(false, "Model is empty");
            app.UpdateApp (appDTO,user.Id);
            return new GeneralResponse(true, "App updated");
        }

        //[HttpGet("GetAllApps")]
        //public async Task<List<App>> GetAllApps()
        //{
        //   return  context.Apps.ToList();
        //}
    }
}
