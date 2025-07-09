using Microsoft.AspNetCore.Identity;

namespace OpenFindaBLE.Backend.Models
{
    public class ApplicationRole:IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        {
            Id = Guid.NewGuid();
        }
        public ApplicationRole(string roleName) : this()
        {
            Name = roleName;
        }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public List<Authority> Authorities = new List<Authority>();
    }
}
