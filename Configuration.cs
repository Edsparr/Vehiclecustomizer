using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edsparr.VehicleCustomizer
{
    public class VehicleCustomizerConfiguration : IRocketPluginConfiguration
    {
        public List<VehicleItem> OverridenVehicles = new List<VehicleItem>();
        public ushort normalCost;
        public byte increaseWidth;
        public byte increaseHeight;
        public List<EachVehicle> DataStorageIGNORE = new List<EachVehicle>();
        public void LoadDefaults()
        {
            OverridenVehicles.Add(new VehicleItem(67, 10, 10, 500));
            normalCost = 250;
            increaseHeight = 5;
            increaseWidth = 5;
            DataStorageIGNORE = null;
        }
    }
}