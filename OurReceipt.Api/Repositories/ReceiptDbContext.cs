using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OurReceipt.Api.Repositories
{
    public class ReceiptDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        protected ReceiptDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration["Database"]);
            base.OnConfiguring(optionsBuilder);
        }
    }
}