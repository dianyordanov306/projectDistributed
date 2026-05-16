using RideSharing.Data;
using RideSharing.Data.Entities;
using RideSharing.Repositories.Interfaces;

namespace RideSharing.Repositories.Implementations
{
    public class RideRequestRespostiory : Repository<RideRequestEntity>, IRideRequestRepository
    {
        public RideRequestRespostiory(IDbContext context) : base(context)
        { }
    }
}
