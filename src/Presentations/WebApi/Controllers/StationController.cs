using AutoMapper;
using Data.Contexts;
using Models.DbEntities.RouteBus;
using Models.DTOs.Station;
using Services.Interfaces;

namespace WebApi.Controllers
{
    public class StationController : BaseController<Station, StationDto, StationDtoCreate, StationDtoUpdate>
    {
        public StationController(ApplicationDbContext dbContext, IMapper mapper, IAuthenticatedUserService userService) : base(dbContext, mapper, userService)
        {
        }
    }
}