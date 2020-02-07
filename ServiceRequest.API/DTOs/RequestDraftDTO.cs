using System;
using System.ComponentModel.DataAnnotations;
using ServiceRequest.API.Helpers;

namespace ServiceRequest.API.DTOs
{
    public class RequestDraftDTO
    {
        public string Requestor { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Deliverables { get; set; }

        [FutureDateAttribute(ErrorMessage = "Invalid Date")]
        public DateTime RequestDate { get; set; }
        public string AFE { get; set; }
        public string PropertyCode { get; set; }
        public decimal ApprovedBudget { get; set; }
        public decimal ExpectedCost { get; set; }
        public string RequestorComment { get; set; }

        public RequestDraftDTO()
        {
            ApprovedBudget = 25000.00M;
        }
    }
}