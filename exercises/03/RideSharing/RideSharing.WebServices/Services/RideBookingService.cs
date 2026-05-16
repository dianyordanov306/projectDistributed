using RideSharing.Contracts;
using RideSharing.Data.Entities;
using RideSharing.Repositories.Interfaces;

namespace RideSharing.WebServices.Services
{
    public class RideBookingService : IRideBookingService, IRideStatusService
    {
        private readonly ILogger<RideBookingService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RideBookingService(ILogger<RideBookingService> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void RequestRide(RideRequest request)
        {
            _logger.LogInformation(
                "Ride received - RequestId: {RequestId}, Pickup: {Pickup}, Dropoff: {Dropoff}, Status: {Status}",
                request.RequestId, request.PickupLocation, request.DropoffLocation, request.Status);

            var entity = ToEntity(request);
            _unitOfWork.RideRequests.AddAsync(entity).GetAwaiter().GetResult();
            _unitOfWork.SaveChangesAsync().GetAwaiter().GetResult();

            _logger.LogInformation("Ride {RequestId} persisted to database.", request.RequestId);
        }

        public void CancelRide(Guid requestId)
        {
            var entity = _unitOfWork.RideRequests.GetByIdAsync(requestId).GetAwaiter().GetResult();
            if (entity is null)
            {
                _logger.LogWarning("Cancel failed - Ride {RequestId} not found.", requestId);
                return;
            }

            if (entity.Status is (int)RideStatus.Completed or (int)RideStatus.Assigned)
            {
                _logger.LogWarning(
                    "Cancel failed - Ride {RequestId} is already {Status}.",
                    requestId, entity.Status);
                return;
            }

            entity.Status = (int)RideStatus.Cancelled;
            _unitOfWork.RideRequests.Update(entity);
            _unitOfWork.SaveChangesAsync().GetAwaiter().GetResult();

            _logger.LogInformation("Ride {RequestId} has been cancelled.", requestId);
        }

        public RideStatus GetRideStatus(Guid requestId)
        {
            var entity = _unitOfWork.RideRequests.GetByIdAsync(requestId).GetAwaiter().GetResult();
            if (entity is null)
            {
                _logger.LogWarning("Ride {RequestId} not found.", requestId);
                return RideStatus.Created;
            }

            _logger.LogInformation("Ride {RequestId} status: {Status}", requestId, entity.Status);
            return (RideStatus)entity.Status;
        }

        // --- Mapping helpers ---

        private static RideRequestEntity ToEntity(RideRequest contract) => new()
        {
            Id = contract.RequestId,
            PickupLocation = contract.PickupLocation,
            DropoffLocation = contract.DropoffLocation,
            Status = (int)contract.Status,
        };
    }
}