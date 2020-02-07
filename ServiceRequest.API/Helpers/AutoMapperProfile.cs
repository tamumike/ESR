using AutoMapper;
using ServiceRequest.API.DTOs;
using ServiceRequest.API.Models;

namespace ServiceRequest.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SubmitRequestDTO, Request>();
            CreateMap<RequestDraftDTO, RequestDraft>();
        }
    }
}