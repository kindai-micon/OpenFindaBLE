using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFindaBLE.Backend.Models
{
    public class Authority:BaseEntity
    {
        public string Name { get;set; } = string.Empty;

        [ForeignKey(nameof(Role))]
        public Guid RoleId { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
