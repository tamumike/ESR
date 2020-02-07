using System;
using System.ComponentModel.DataAnnotations;
using ServiceRequest.API.Helpers;

namespace ServiceRequest.API.DTOs
{
    public class SubmitRequestDTO
    {
        public string Requestor { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Deliverables { get; set; }
        public string RequestNumber { get; set; }

        [Required]
        [FutureDateAttribute(ErrorMessage = "Invalid Date")]
        public DateTime RequestDate { get; set; }

        [Required]
        public string AFE { get; set; }

        [Required]
        public string PropertyCode { get; set; }
        public bool Approved { get; set; }
        public decimal ApprovedBudget { get; set; }
        public string RequestorComment { get; set; }

        public SubmitRequestDTO()
        {
            Approved = false;
            ApprovedBudget = 25000.00M;
            CreatedDate = DateTime.Now.Date;
        }

    }
}