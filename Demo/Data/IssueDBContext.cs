using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class IssueDBContext : DbContext
    {
        public IssueDBContext(DbContextOptions<IssueDBContext> options)
            :base(options)
        {

        }
        public DbSet<Issue> Issues { get; set; }
    }
}
