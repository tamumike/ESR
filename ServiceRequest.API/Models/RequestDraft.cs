using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceRequest.API.Models
{
    public class RequestDraft
    {
        [Key]
        public int Id { get; set; }
        public string Requestor { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Deliverables { get; set; }
        public DateTime RequestDate { get; set; }
        public string AFE { get; set; }
        public string PropertyCode { get; set; }
        public decimal ApprovedBudget { get; set; }
        public decimal ExpectedCost { get; set; }
        public string RequestorComment { get; set; }
    }
}