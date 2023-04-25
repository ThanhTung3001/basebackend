namespace Services.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserEmail { get; }
        string UserName { get; }
    }
}
