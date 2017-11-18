using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edsparr.VehicleCustomizer
{
    public class VehicleItem
    {
        public ushort vehicleID;
        public byte increaseWidth;
        public byte increaseHeight;
        public decimal cost;
        public VehicleItem(ushort vehicleID, byte increaseWidth, byte increaseHeight, decimal cost)
        {
            this.vehicleID = vehicleID;
            this.increaseWidth = increaseWidth;
            this.increaseHeight = increaseHeight;
            this.cost = cost;
        }
        public VehicleItem() { }
    }
}