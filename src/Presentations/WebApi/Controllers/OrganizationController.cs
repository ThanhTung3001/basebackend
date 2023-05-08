using AutoMapper;
using Data.Contexts;
using Models.DbEntities.RouteBus;
using Models.DTOs.Organization;
using Services.Interfaces;

namespace WebApi.Controllers
{

    public class OrganizationController : BaseController<Organization, OrganizationDto, OrganizationCreateDto, OrganizationDto>
    {
        public OrganizationController(ApplicationDbContext dbContext, IMapper mapper, IAuthenticatedUserService userService) : base(dbContext, mapper, userService)
        {
        }
    }

}