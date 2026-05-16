namespace RideSharing.Data.Entities
{
    public class RideRequestEntity : BaseEntity
    {
        public string? PickupLocation { get; set; }
        public string? DropoffLocation { get; set; }
        public int Status { get; set; }
    }
}