using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.DbEntities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TModelDto, TCreateModel, TUpdateModel> : ControllerBase
        where TModel : BaseEntity
        where TModelDto : BaseEntity
        where TCreateModel : BaseEntity
        where TUpdateModel :BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public BaseController(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TModelDto>>> GetAll()
        {
            var models = await _dbContext.Set<TModel>().ToListAsync();
            var modelDTOs = _mapper.Map<IEnumerable<TModelDto>>(models);
            return Ok(modelDTOs);
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