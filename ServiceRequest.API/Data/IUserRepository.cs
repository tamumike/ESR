using System.Threading.Tasks;

namespace ServiceRequest.API.Data
{
    public interface IUserRepository
    {
        string GetUsername();
        string GetUserInformation();
    }
}