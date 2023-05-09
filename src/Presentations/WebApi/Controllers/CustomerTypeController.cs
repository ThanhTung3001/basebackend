

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbEntities.Customer;
using Models.DTOs.Customer;
using Models.Paging;
using Services.Interfaces;

namespace WebApi.Controllers
{
    public class CustomerTypeController : BaseController<CustomerType, CustomerDto, CustomerDtoCreate, CustomerDtoUpdate>
    {
        public CustomerTypeController(ApplicationDbContext dbContext, IMapper mapper, IAuthenticatedUserService userService) : base(dbContext, mapper, userService)
        {
        }

        public override async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll([FromQuery] PaginationDto request)
        {
            var response = await _dbContext.CustomerTypes
            .Skip((request.PageNumber - 1) * request.PageSize) // Skip the number of items on previous pages
            .Take(request.PageSize)
             .Where(e => request.Search.Equals("") ? true : e.Name.Contains(request.Search)).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(response));
        }
        [HttpGet("GetAllByName")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllByName([FromQuery] PaginationDto request)
        {
            var response = await _dbContext.CustomerTypes
            .Skip((request.PageNumber - 1) * request.PageSize) // Skip the number of items on previous pages
            .Take(request.PageSize)
             .Where(e => request.Search.Equals("") ? true : e.Name.Contains(request.Search)).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(response));
        }

    }

}