using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using Steamworks;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using SDG.Unturned;
using fr34kyn01535.Uconomy;
using System.Text;
using Rocket.Unturned.Events;
using Rocket.API;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Permissions;

namespace Edsparr.VehicleCustomizer
{
    public class VehicleCustomizerPlugin : RocketPlugin<VehicleCustomizerConfiguration>
    {

        public Vector3 pos;

        public static string version = "1.0";
        public static VehicleCustomizerPlugin Instance;

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList(){
                {"not_in_car","You're not in a car!"},
                {"already_maxed","You have already maded the storage as big as possible!"},
                {"cant_afford","You can't afford to buy extra space for this vehicle!"},
                {"succesfully_bought","You succesfully bought {0} in extra width and {1} extra in height for {2]!"},
                {"no_trunk_space","This car doesn't have any portable storage unit!"},
                {"invalid_syntax_unban","/punban <steamId>"},
                {"succesfully_unbanned","You paid {0} {1} {2}"}
                };
            }
        }

        protected override void Load()
        {
            VehicleCustomizerPlugin.Instance = this;
            loadAllVehicles();
        }
        private void loadAllVehicles()
        {
            foreach(var item in Configuration.Instance.DataStorageIGNORE)
            {
                var vehicle = VehicleManager.getVehicle(item.instanceID);
                if (vehicle == null) continue;
                vehicle.trunkItems.resize(item.width, item.height);
            }
            Configuration.Instance.DataStorageIGNORE.Clear();
            Configuration.Save();
        }
        protected override void Unload()
        {
            saveAllVehicles();
        }

        private void saveAllVehicles()
        {
            Configuration.Instance.DataStorageIGNORE.Clear();
            Configuration.Save();
            foreach (var vehicle in VehicleManager.vehicles)
            {
                Configuration.Instance.DataStorageIGNORE.Add(new EachVehicle(vehicle.instanceID, vehicle.trunkItems.width, vehicle.trunkItems.height));
            }
            Configuration.Save();
        }
    }

}







