using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceRequest.API.Models;

namespace ServiceRequest.API.Data
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly DataContext _context;
        public ServiceRequestRepository(DataContext context)
        {
            _context = context;

        }

        public string GenerateRequestNumber(IEnumerable<Request> requestsFromDatabase)
        {
            requestsFromDatabase = requestsFromDatabase.ToList();
            int[] requestNumbers = new int[requestsFromDatabase.Count()];
            string generatedRequestNumber = null;
            int maxNumber = 1;
            if (requestsFromDatabase?.Any() ?? false)
            {
                for (var i = 0; i < requestNumbers.Count(); i++)
                {
                    int number;
                    string requestNumber = requestsFromDatabase.ElementAt(i).RequestNumber.Split("-")[1];
                    if (Int32.TryParse(requestNumber, out number)) requestNumbers[i] = number;
                }                
                maxNumber += requestNumbers.Max();
            }

            string converted = maxNumber.ToString().PadLeft(3, '0');
            DateTime currentDate = DateTime.Now.Date;
            string twoDigitYear = currentDate.ToString("yy");
            generatedRequestNumber = $"{twoDigitYear}-{converted}";
            
            return generatedRequestNumber;
        }

        public async Task<IEnumerable<Request>> Get()
        {
            IEnumerable<Request> requests = await _context.Requests.ToListAsync();
            return requests;
        }

        public async Task<IEnumerable<RequestDraft>> GetDrafts(string user)
        {
            var drafts = await _context.RequestDrafts.ToListAsync();
            drafts = drafts.Where(d => d.Requestor == user).ToList();
            return drafts;
        }

        public async Task<Request> GetServiceRequest(string requestNumber)
        {
            Request request = await _context.Requests.FirstOrDefaultAsync(r => r.RequestNumber == requestNumber);
            return request;
        }

        public async Task<RequestDraft> SaveRequestAsDraft(RequestDraft requestDraft)
        {
            await _context.RequestDrafts.AddAsync(requestDraft);
            await _context.SaveChangesAsync();

            return requestDraft;
        }

        public async Task<Request> SubmitNewServiceRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }

        // TODO: Get all requests that user has requested
        // TODO: Get all requests assigned to user
    }
}