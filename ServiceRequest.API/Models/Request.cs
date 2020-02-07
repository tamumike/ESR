using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceRequest.API.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string Requestor { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Deliverables { get; set; }
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime CoupaApprovedDate { get; set; }
        public string AFE { get; set; }
        public string PropertyCode { get; set; }
        public string Engineer { get; set; }
        public string EngineerComment { get; set; }
        public bool Approved { get; set; }
        public decimal ApprovedBudget { get; set; }
        public DateTime PromiseDate { get; set; }
        public decimal ExpectedCost { get; set; }
        public string RequestorComment { get; set; }
    }
}