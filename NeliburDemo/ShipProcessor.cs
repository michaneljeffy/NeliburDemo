using Nelibur.ServiceModel.Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using static NeliburDemo.Ship;

namespace NeliburDemo
{
    public class ShipProcessor: IPost<AddShipCommand>,
                                    IGet<ShipLocationQuery>
    {
        private static readonly Dictionary<Guid, Ship> _ships = new Dictionary<Guid, Ship>();

        public object Get(ShipLocationQuery request)
        {
            if (_ships.ContainsKey(request.ShipId))
            {
                return new ShipLocation
                {
                    Location = "Sheldonopolis",
                    ShipId = request.ShipId
                };
            }
            throw new WebFaultException(HttpStatusCode.BadRequest);
        }

        public object Post(AddShipCommand request)
        {
            var ship = new Ship(request.ShipName, Guid.NewGuid());
            _ships[ship.Id] = ship;
            return new ShipInfo
            {
                Id = ship.Id,
                Name = ship.Name
            };
        }
    }
}
