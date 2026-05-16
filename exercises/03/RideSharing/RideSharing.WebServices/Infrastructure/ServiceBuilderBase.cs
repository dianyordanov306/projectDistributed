using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using RideSharing.Contracts;
using RideSharing.WebServices.Services;

namespace RideSharing.WebServices.Infrastructure
{
    public static class ServiceBuilderBase
    {
        public static IServiceBuilder WcfServiceBuilder(this IServiceBuilder serviceBuilder)
        {
            // Existing HTTP service
            serviceBuilder.AddService<Service>();
            serviceBuilder.AddServiceEndpoint<Service, IService>(
                new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/Service.svc");

            // RabbitMQ ride booking service
            serviceBuilder.AddService<RideBookingService>();
            serviceBuilder.AddServiceEndpoint<RideBookingService, IRideBookingService>(
                new RabbitMqBinding(),
                new Uri("net.amqp://localhost/ride_booking_exchange/ride_booking_queue"));

            // HTTP endpoint for request-reply ride status queries
            serviceBuilder.AddServiceEndpoint<RideBookingService, IRideStatusService>(
                new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/RideStatusService.svc");

            return serviceBuilder;
        }
    }
}
