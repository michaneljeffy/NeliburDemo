using Nelibur.ServiceModel.Clients;
using NeliburDemo.Client.JsonServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NeliburDemo.Client.Ship;

namespace NeliburDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new JsonServiceClient("http://localhost:9095/ShipTrackingService");
            var shipInfo = client.Post<ShipInfo>(new AddShipCommand { ShipName = "Star" });
            Console.WriteLine("The ship has added: {0}", shipInfo);

            var shipLocation = client.Get<ShipLocation>(new ShipLocationQuery { ShipId = shipInfo.Id });
            Console.WriteLine("The ship {0}", shipLocation);

            Console.ReadKey();
        }

        static void ExecuteJson()
        {
            var client = new JsonServiceClient("http://localhost:8080/webhost");

            var createRequest = new CreateClientRequest
            {
                Email = "email@email.com"
            };
            ClientResponse response = client.Post<ClientResponse>(createRequest);

            var updateRequest = new UpdateClientRequest
            {
                Email = "new@email.com",
                Id = response.Id
            };
            response = client.Put<ClientResponse>(updateRequest);

            var getClientRequest = new GetClientRequest
            {
                Id = response.Id
            };
            response = client.Get<ClientResponse>(getClientRequest);

            var deleteRequest = new DeleteClientRequest
            {
                Id = response.Id
            };
            client.Delete(deleteRequest);
        }

        static void ExecuteSoap()
        {
            var client = new SoapServiceClient("NeliburSoapService");

            var createRequest = new CreateClientRequest
            {
                Email = "email@email.com"
            };
            ClientResponse response = client.Post<ClientResponse>(createRequest);

            var updateRequest = new UpdateClientRequest
            {
                Email = "new@email.com",
                Id = response.Id
            };
            response = client.Put<ClientResponse>(updateRequest);

            var getClientRequest = new GetClientRequest
            {
                Id = response.Id
            };
            response = client.Get<ClientResponse>(getClientRequest);

            var deleteRequest = new DeleteClientRequest
            {
                Id = response.Id
            };
            client.Delete(deleteRequest);
        }
    }

    public class Ship
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Ship(string _name, Guid _id)
        {
            Id = _id;
            Name = _name;
        }
        public sealed class AddShipCommand
        {
            public string ShipName { get; set; }
        }

        public sealed class ShipLocationQuery
        {
            public Guid ShipId { get; set; }
        }
        public sealed class ShipLocation
        {
            public string Location { get; set; }
            public Guid ShipId { get; set; }
        }

        public sealed class ShipInfo
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
