using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenFindaBLE.Backend.Models;

namespace OpenFindaBLE.Backend
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser,ApplicationRole, Guid>
    {
        public DbSet<Authority> Authorities { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
    }
}
