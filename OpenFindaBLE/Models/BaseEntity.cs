using System.ComponentModel.DataAnnotations;

namespace OpenFindaBLE.Backend.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
        }

    }
}
