using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using System.Security.Claims;

namespace WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserEmail = httpContextAccessor.HttpContext?.User?.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
          
        }//http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name

        public string UserEmail { get; }
        
        public string UserName { get; }
    }
}
