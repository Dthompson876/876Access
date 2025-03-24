using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _876Access.Models;
using Microsoft.AspNetCore.Identity;

namespace _876Access.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<_876Access.Models.Establishments> Establishments { get; set; } = default!;
    }
}
