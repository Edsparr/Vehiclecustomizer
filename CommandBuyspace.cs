using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using Rocket.API.Extensions;
using Rocket.Unturned.Permissions;
using Rocket.Core;
using fr34kyn01535.Uconomy;

namespace Edsparr.VehicleCustomizer
{
    public class CommandBuyspace : IRocketCommand
    {
        public VehicleCustomizerPlugin plugin = VehicleCustomizerPlugin.Instance;
        #region Declarations

        public bool AllowFromConsole
        {
            get
            {
                return false;
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>()
                {
                    "buyspace"
                };
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Player;
            }
        }

        public bool RunFromConsole
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "buyspace";
            }
        }

        public string Syntax
        {
            get
            {
                return "/buyspace";
            }
        }

        public string Help
        {
            get
            {
                return "You buy extra trunkstorage for your car!";
            }
        }

        public List<string> Aliases
        {
            get
            {
                return new List<string>();
            }
        }

        #endregion





        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if(player.CurrentVehicle == null)
            {
                UnturnedChat.Say(player, VehicleCustomizerPlugin.Instance.Translate("not_in_car"), Color.red);
                return;
            }
            if(player.CurrentVehicle.trunkItems == null)
            {
                UnturnedChat.Say(player, VehicleCustomizerPlugin.Instance.Translate("no_trunk_space"), Color.red);
                return;
            }
            if(player.CurrentVehicle.trunkItems.width == 255 && player.CurrentVehicle.trunkItems.height == 255)
            {
                UnturnedChat.Say(player, VehicleCustomizerPlugin.Instance.Translate("already_maxed"), Color.red);
                return;
            }
            decimal cost = 0;
            byte newHeight = 0;
            byte newWidth = 0;

            var overridenvehicle = VehicleCustomizerPlugin.Instance.Configuration.Instance.OverridenVehicles.Find(c => (c.vehicleID == player.CurrentVehicle.asset.id));
            if (overridenvehicle != null)
            {
                cost = overridenvehicle.cost;
                int newH = player.CurrentVehicle.trunkItems.width + overridenvehicle.increaseWidth;
                if (newH > 255) newH = 255;
                newHeight = (byte)newH;

                int newW = player.CurrentVehicle.trunkItems.height + overridenvehicle.increaseHeight;
                if (newW > 255) newW = 255;
                newWidth = (byte)newW;
            }
            else
            {
                int newH = player.CurrentVehicle.trunkItems.width + VehicleCustomizerPlugin.Instance.Configuration.Instance.increaseWidth;
                if(newH > 255) newH = 255;
                newHeight = (byte)newH;

                int newW = player.CurrentVehicle.trunkItems.height + VehicleCustomizerPlugin.Instance.Configuration.Instance.increaseWidth;
                if (newW > 255) newW = 255;
                newWidth = (byte)newW;
                cost = VehicleCustomizerPlugin.Instance.Configuration.Instance.normalCost;
            }


            if(cost > Uconomy.Instance.Database.GetBalance(player.CSteamID.ToString()))
            {
                UnturnedChat.Say(player, VehicleCustomizerPlugin.Instance.Translate("cant_afford", cost), Color.red);
                return;
            }
            player.CurrentVehicle.trunkItems.resize(newWidth, newHeight);
            Uconomy.Instance.Database.IncreaseBalance(player.CSteamID.ToString(), -cost);
            UnturnedChat.Say(player, VehicleCustomizerPlugin.Instance.Translate("succesfully_bought", cost), Color.yellow);
        }
    }
}


