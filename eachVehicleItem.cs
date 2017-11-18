using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edsparr.VehicleCustomizer
{
    public class EachVehicle
    {
        public uint instanceID;
        public byte width;
        public byte height;

        public EachVehicle(uint instanceID, byte width, byte height)
        {
            this.instanceID = instanceID;
            this.width = width;
            this.height = height;
        }
        public EachVehicle() { }
    }
}