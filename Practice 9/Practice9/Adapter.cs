using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice9
{
    public interface IInternalDeliveryService
    {
        void DeliverOrder(string orderId);
        string GetDeliveryStatus(string orderId);
    }

    public class InternalDeliveryService : IInternalDeliveryService
    {
        public void DeliverOrder(string orderId)
        {
            Console.WriteLine($"Delivering order {orderId} using internal service.");
        }

        public string GetDeliveryStatus(string orderId)
        {
            return $"Status of order {orderId} using internal service.";
        }
    }
    public class ExternalLogisticsServiceA
    {
        public void ShipItem(int itemId) { }
        public string TrackShipment(int shipmentId) { return "Tracking info for A"; }
    }

    public class ExternalLogisticsServiceB
    {
        public void SendPackage(string packageInfo) { }
        public string CheckPackageStatus(string trackingCode) { return "Tracking info for B"; }
    }
    public class LogisticsAdapterA : IInternalDeliveryService
    {
        private ExternalLogisticsServiceA _externalService;

        public LogisticsAdapterA()
        {
            _externalService = new ExternalLogisticsServiceA();
        }

        public void DeliverOrder(string orderId)
        {
            _externalService.ShipItem(int.Parse(orderId));
        }

        public string GetDeliveryStatus(string orderId)
        {
            return _externalService.TrackShipment(int.Parse(orderId));
        }
    }
    public class LogisticsAdapterB : IInternalDeliveryService
    {
        private ExternalLogisticsServiceB _externalService;

        public LogisticsAdapterB()
        {
            _externalService = new ExternalLogisticsServiceB();
        }

        public void DeliverOrder(string orderId)
        {
            _externalService.SendPackage(orderId);
        }

        public string GetDeliveryStatus(string orderId)
        {
            return _externalService.CheckPackageStatus(orderId);
        }
    }
    public class DeliveryServiceFactory
    {
        public IInternalDeliveryService GetDeliveryService(string serviceType)
        {
            switch (serviceType)
            {
                case "Internal":
                    return new InternalDeliveryService();
                case "ExternalA":
                    return new LogisticsAdapterA();
                case "ExternalB":
                    return new LogisticsAdapterB();
                default:
                    throw new ArgumentException("Invalid service type");
            }
        }
    }
    public class DeliveryManager
    {
        private DeliveryServiceFactory _factory;

        public DeliveryManager()
        {
            _factory = new DeliveryServiceFactory();
        }

        public void ProcessOrder(string orderId, string serviceType)
        {
            IInternalDeliveryService deliveryService = _factory.GetDeliveryService(serviceType);
            deliveryService.DeliverOrder(orderId);
            Console.WriteLine(deliveryService.GetDeliveryStatus(orderId));
        }
    }

}
