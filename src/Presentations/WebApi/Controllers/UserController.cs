using System.Collections.Generic;
using System;
using System.Linq;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Paging;
using Models.DTOs.Response;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class UserController : ControllerBase
    {

        public UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        /// <param name="PageSize">Number of item in 1 page</param>
        /// <param name="PageNumber">PageIndex</param>
        /// <returns>List UserInfo order by Page</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationDto request)
        {
            var users = await _userManager.Users.OrderBy(p => p.Id).Skip((request.PageNumber - 1) * request.PageSize) // Skip the number of items on previous pages
                .Take(request.PageSize) // Take the number of items for the current page
                .ToListAsync();
            var totalItems = _userManager.Users.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);
            var response = new PaginationReponseDto<List<ApplicationUser>>()
            {
                TotalItem = totalItems,
                TotalPage = totalPages,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Data = users
            };
            return Ok(ServiceResult.Success<PaginationReponseDto<List<ApplicationUser>>>(response));

        }
    }
}