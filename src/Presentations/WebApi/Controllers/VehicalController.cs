using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbEntities.RouteBus;
using Models.DTOs.Organization;
using Models.Paging;
using Services.Interfaces;

namespace WebApi.Controllers
{

    public class VehicalController : BaseController<Vehicle, VehicalDto, VehicalCreateDto, VehicalUpdateDto>
    {
        public VehicalController(ApplicationDbContext dbContext, IMapper mapper, IAuthenticatedUserService userService) : base(dbContext, mapper, userService)
        {
        }
        /// <para>PageNumber,pageSize,Keyword</para>
        [HttpGet("GetAllByName")]
        public async Task<ActionResult<IEnumerable<VehicalDto>>> GetAllByName([FromQuery] PaginationSearchDto request)
        {
            var models = new List<Vehicle>();
            if (request.Keyword.Trim() != "")
            {
                models = await _dbContext.Vehicles.Include(e => e.Organization)
                .Where(e => (e.Model.Contains(request.Keyword) || e.PlateNumber.Contains(request.Keyword)))
                .Skip((request.PageNumber - 1) * request.PageSize) // Skip the number of items on previous pages
               .Take(request.PageSize) // Take the number of items for the current page
               .ToListAsync();
            }
            else
            {
                models = await _dbContext.Vehicles.Include(e => e.Organization)
              .Skip((request.PageNumber - 1) * request.PageSize) // Skip the number of items on previous pages
             .Take(request.PageSize) // Take the number of items for the current page
             .ToListAsync();
            }

            var modelDTOs = _mapper.Map<IEnumerable<VehicalDto>>(models);
            var totalItems = _dbContext.Vehicles.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);
            var response = new PaginationReponseDto<IEnumerable<VehicalDto>>()
            {
                TotalItem = totalItems,
                TotalPage = totalPages,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Data = modelDTOs
            };

            return Ok(response);


        }
    }

}