using Microsoft.EntityFrameworkCore;
using ServiceRequest.API.Models;

namespace ServiceRequest.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDraft> RequestDrafts { get; set; }
    }
}