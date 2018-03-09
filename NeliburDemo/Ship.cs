using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeliburDemo
{
    public class Ship
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Ship(string _name,Guid _id)
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
