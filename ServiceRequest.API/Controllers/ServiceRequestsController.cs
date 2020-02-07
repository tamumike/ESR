using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRequest.API.Data;
using ServiceRequest.API.DTOs;
using ServiceRequest.API.Helpers;
using ServiceRequest.API.Models;

namespace ServiceRequest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestRepository _repo;
        private readonly IMapper _mapper;

        public ServiceRequestsController(IServiceRequestRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var requests = await _repo.Get();
            return Ok(requests);
        }

        [HttpGet("{RequestNumber}")]
        public async Task<IActionResult> GetServiceRequest(string requestNumber)
        {
            var request = await _repo.GetServiceRequest(requestNumber);
            return Ok(request);
        }

        // TEMPORARY
        [HttpGet("number")]
        public async Task<IActionResult> GetNewNumber()
        {
            var requests = await _repo.Get();
            var number = _repo.GenerateRequestNumber(requests);

            return Ok(number);
        }

        [HttpGet("drafts")]
        public async Task<IActionResult> GetDrafts()
        {
            string username = Request.Cookies["Username"];
            var drafts = await _repo.GetDrafts(username);
            return Ok(drafts);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitNewServiceRequest(SubmitRequestDTO submitRequestDTO)
        {
            submitRequestDTO.RequestNumber = _repo.GenerateRequestNumber(await _repo.Get());
            submitRequestDTO.Requestor = Request.Cookies["Username"];
            var requestToSubmit = _mapper.Map<Request>(submitRequestDTO);
            var submittedRequest = await _repo.SubmitNewServiceRequest(requestToSubmit);

            return Ok(submittedRequest);
        }

        [HttpPut("SaveAsDraft")]
        public async Task<IActionResult> SaveRequestAsDraft(RequestDraftDTO requestDraftDTO)
        {
            requestDraftDTO.Requestor = Request.Cookies["Username"];
            var draftToSave = _mapper.Map<RequestDraft>(requestDraftDTO);
            var savedDraft = await _repo.SaveRequestAsDraft(draftToSave);

            return Ok(savedDraft);
        }
    }
}