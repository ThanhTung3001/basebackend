using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Identity.Contexts;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Menu;
using Models.DTOs.Response;
using Models.Enums;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IdentityContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _userService;
        public MenuController(IdentityContext identityContext, RoleManager<ApplicationRole> roleManager, IMapper mapper, IAuthenticatedUserService userService, UserManager<ApplicationUser> userManager)
        {
            _context = identityContext;
            _roleManager = roleManager;
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // var role =  _roleManager.Roles.FirstOrDefault(e => roleName.ToUpper().Equals(e.Name.ToUpper()));
            // if (role == null)
            // {
            //    // return ServiceResult.Failed<object>(ServiceError.NotFound);
            //    return BadRequest();
            // }
            var user = await _userManager.FindByNameAsync(_userService.UserName);

            var roles = await _userManager.GetRolesAsync(user);
            // var roles = user.UserRoles.Select(e => e.Role.Name).ToList(); 

            var menuList = _context.ApplicationMenus
                .Include(m => m.Children)
                .ThenInclude(cm => cm.Children)
               .OrderByDescending((e => e.Index))
                .Where(e => e.Parent == null)
                .Where(e => (e.MenuRoles.Any(menu => roles.Contains(menu.Role.Name))))
                .ToList();
            var response = menuList.GroupBy(e => e.Id).ToList();

            var listMenu = new List<ApplicationMenu>();
            foreach (var group in response)
            {
                var menu = new ApplicationMenu
                {
                    Id = group.Key,
                    Name = group.First().Name,
                    Icon = group.First().Icon,
                    Path = group.First().Path,
                    Children = group.SelectMany(e => e.Children).Select(child => new ApplicationMenu
                    {
                        Id = child.Id,
                        Name = child.Name,
                        Icon = child.Icon,
                        Path = child.Path
                        // add any other properties you want to map
                    }).ToList()
                };
                listMenu.Add(menu);
            }
            return Ok(ServiceResult.Success<object>(listMenu));

        }
        /// <summary>
        /// IconType = 1,2,3,4 as
        /// Bootstrap,Devexpress,FontAwesome,AntDesign
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(MenuDtoCreate create)
        {
            try
            {
                var entity = _mapper.Map<ApplicationMenu>(create);
                var role = await _roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
                // entity.MenuRoles.Add(role);
                entity.CreateUTC = DateTime.Now;
                var response = await _context.ApplicationMenus.AddAsync(entity);
                var menuRole = new ApplicationMenuRole()
                {
                    Role = role,
                    Menu = entity
                };
                var resposeInsertRole = await _context.ApplicationMenuRole.AddAsync(menuRole);
                await _context.SaveChangesAsync();
                return Ok(ServiceResult.Success<MenuDto>(_mapper.Map<MenuDto>(response.Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(ServiceResult.Failed<object>(new
                {
                    Message = "Create Menu fail: " + e,
                    code = 400
                }, ServiceError.DefaultError));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(MenuDtoUpdate update, int id)
        {
            try
            {

                //var entity = _mapper.Map<ApplicationMenu>(update);
                var entityFind = await _context.ApplicationMenus.FindAsync(id);
                var entity = _mapper.Map(update, entityFind);
                entity.Id = id;
                entity.UpdateTime = DateTime.Now;
                var response = _context.ApplicationMenus.Update(entity);
                await _context.SaveChangesAsync();
                return Ok(ServiceResult.Success<MenuDto>(_mapper.Map<MenuDto>(response.Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(ServiceResult.Failed<object>(new
                {
                    Message = "Update Menu fail: " + e,
                    code = 400
                }, ServiceError.DefaultError));
            }
        }

        [HttpPut("Position")]
        public async Task<IActionResult> UpdatePosition(int menuId, int parrentId)
        {
            try
            {

                var item = _context.ApplicationMenus.FirstOrDefault(e => e.Id == menuId);
                var parent = _context.ApplicationMenus.Include(e => e.Parent).FirstOrDefault(e => e.Id == parrentId);
                if (parent is { Parent: { } })
                {
                    return BadRequest(ServiceResult.Failed<object>(new
                    {
                        Message = "Not allow update",
                        code = 400
                    }, ServiceError.DefaultError));
                }
                if (item == null)
                {
                    return BadRequest(ServiceResult.Failed<object>(new
                    {
                        Message = "Menu not found",
                        code = 404
                    }, ServiceError.DefaultError));
                }
                item.ParrentId = parrentId;
                var response = _context.ApplicationMenus.Update(item);
                await _context.SaveChangesAsync();
                return Ok(ServiceResult.Success<MenuDto>(_mapper.Map<MenuDto>(response.Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(ServiceResult.Failed<object>(new
                {
                    Message = "Update Menu fail: " + e,
                    code = 400
                }, ServiceError.DefaultError));
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = _context.ApplicationMenus.FirstOrDefault(e => e.Id == id);
                if (item == null)
                {
                    return BadRequest(ServiceResult.Failed<object>(new
                    {
                        Message = "Menu not found",
                        code = 404
                    }, ServiceError.DefaultError));
                }
                var response = _context.ApplicationMenus.Remove(item);
                await _context.SaveChangesAsync();
                return Ok(ServiceResult.Success<MenuDto>(_mapper.Map<MenuDto>(response.Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(ServiceResult.Failed<object>(new
                {
                    Message = "Delete Menu fail: " + e,
                    code = 400
                }, ServiceError.DefaultError));
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            // var role =  _roleManager.Roles.FirstOrDefault(e => roleName.ToUpper().Equals(e.Name.ToUpper()));
            // if (role == null)
            // {
            //    // return ServiceResult.Failed<object>(ServiceError.NotFound);
            //    return BadRequest();
            // }
            var user = await _userManager.FindByNameAsync(_userService.UserName);
            var roles = await _userManager.GetRolesAsync(user);
            // var roles = user.UserRoles.Select(e => e.Role.Name).ToList(); 

            var menuList = _context.ApplicationMenus
                .Include(m => m.Children)
                .ThenInclude(cm => cm.Children)
                .Include(m => m.Parent)
                .ThenInclude(m => m.Parent)
                .Include(m => m.MenuRoles)
                .ToList();
            var response = menuList.GroupBy(e => e.Id).ToList();

            var listMenu = new List<ApplicationMenu>();
            foreach (var group in response)
            {
                var menu = new ApplicationMenu
                {
                    Id = group.Key,
                    Name = group.First().Name,
                    Icon = group.First().Icon,
                    Path = group.First().Path,
                    Children = group.SelectMany(e => e.Children).Select(child => new ApplicationMenu
                    {
                        Id = child.Id,
                        Name = child.Name,
                        Icon = child.Icon,
                        Path = child.Path
                        // add any other properties you want to map
                    }).ToList()
                };
                listMenu.Add(menu);
            }
            return Ok(ServiceResult.Success<object>(listMenu));

        }
    }
}
