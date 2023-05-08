using System.Threading.Tasks;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Response;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var roles = await _roleManager.Roles.Include(e => e.MenuRoles).ThenInclude(mr => mr.Menu).ToListAsync();
            return Ok(ServiceResult.Success<object>(roles));

        }

    }

}