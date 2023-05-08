using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Contexts;
using Models.DbEntities;
using Services.Interfaces;
using Models.DTOs;
using Models.Paging;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TModelDto, TCreateModel, TUpdateModel> : ControllerBase
        where TModel : BaseEntity
        where TModelDto : BaseDto
        where TCreateModel : class
        where TUpdateModel : BaseDto
    {
        public readonly IMapper _mapper;
        public readonly ApplicationDbContext _dbContext;
        private readonly IAuthenticatedUserService _userService;


        public BaseController(ApplicationDbContext dbContext, IMapper mapper, IAuthenticatedUserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TModelDto>>> GetAll([FromQuery] PaginationDto request)
        {
            var models = await _dbContext.Set<TModel>().Skip((request.PageNumber - 1) * request.PageSize) // Skip the number of items on previous pages
                .Take(request.PageSize) // Take the number of items for the current page
                .ToListAsync();
            var modelDTOs = _mapper.Map<IEnumerable<TModelDto>>(models);
            var totalItems = _dbContext.Set<TModel>().Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);
            var response = new PaginationReponseDto<IEnumerable<TModelDto>>()
            {
                TotalItem = totalItems,
                TotalPage = totalPages,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Data = modelDTOs
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TModelDto>> GetById(int id)
        {
            var model = await _dbContext.Set<TModel>().FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var modelDTO = _mapper.Map<TModelDto>(model);
            return Ok(modelDTO);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TModelDto>> Create(TCreateModel createModel)
        {
            var model = _mapper.Map<TModel>(createModel);
            model.CreateBy = _userService.UserName;
            _dbContext.Set<TModel>().Add(model);
            await _dbContext.SaveChangesAsync();
            var modelDTO = _mapper.Map<TModelDto>(model);
            return CreatedAtAction(nameof(GetById), new { id = modelDTO.Id }, modelDTO);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, TUpdateModel updateModel)
        {
            if (id != updateModel.Id)
            {
                return BadRequest();
            }

            var model = await _dbContext.Set<TModel>().FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            model.CreateBy = _userService.UserName;
            _mapper.Map(updateModel, model);

            _dbContext.Entry(model).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var updatedModelDTO = _mapper.Map<TModelDto>(model);
            return Ok(updatedModelDTO);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TModelDto>> Delete(int id)
        {
            var model = await _dbContext.Set<TModel>().FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _dbContext.Set<TModel>().Remove(model);
            await _dbContext.SaveChangesAsync();
            var modelDTO = _mapper.Map<TModelDto>(model);
            return Ok(modelDTO);
        }

        private bool ModelExists(int id)
        {
            return _dbContext.Set<TModel>().Any(e => e.Id == id);
        }
    }
}