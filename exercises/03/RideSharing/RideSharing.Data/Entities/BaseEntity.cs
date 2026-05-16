using System.ComponentModel.DataAnnotations;

namespace RideSharing.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid UpdateBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
