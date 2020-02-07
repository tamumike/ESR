using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceRequest.API.Helpers;
using ServiceRequest.API.Models;

namespace ServiceRequest.API.Data
{
    public interface IServiceRequestRepository
    {
        Task<IEnumerable<Request>> Get();
        Task<Request> GetServiceRequest(string requestNumber);
        string GenerateRequestNumber(IEnumerable<Request> requestsFromDatabase);
        Task<Request> SubmitNewServiceRequest(Request request);
        Task<RequestDraft> SaveRequestAsDraft(RequestDraft requestDraft);
        Task<IEnumerable<RequestDraft>> GetDrafts(string username);
    }
}