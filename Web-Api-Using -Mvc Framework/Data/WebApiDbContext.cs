using Microsoft.EntityFrameworkCore;

namespace Web_Api_Using__Mvc_Framework.Data
{
   
        public class WebApiDbContext : DbContext
        {
            public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
            {

            }

            public DbSet<UserManagement> UserManagements { get; set; } = default!;
        }
    
}
