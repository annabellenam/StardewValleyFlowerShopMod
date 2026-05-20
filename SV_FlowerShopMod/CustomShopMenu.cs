using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;
using StardewValley.Tools;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using System.Collections.Generic;

        
namespace StardewShopMod
{
    public class CustomShopMenu: Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.Content.AssetRequested += OnAssetRequested;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;
        }
        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.Name.IsEquivalentTo("Data/Shops"))
            {
                e.EditToInclude(ApplyShopEdits);
            }
        }

        private void ApplyShopEdits(IAssetData asset)
        {
            var data = asset.AsDictionary<string, object>().Data;

            // defines shop 
            var flowerShop = new Dictionary<string, object>
            {
                ["Owners"] = new List<object>
                {
                    new
                    {
                        Name = "Daisy Buchanan",
                        Dialogues = new List<object>
                        {
                            new
                            {
                                Id = "Example.ModId_SunnySummer",
                                Condition = "SEASON Summer, WEATHER Here Sun",
                                Dialogue = "Days like this are the perfect day to buy some beautiful flowers."
                            },
                            new
                            {
                                Id = "Example.ModId_Default",
                                Dialogue = "Welcome to the only place in town for flowers! Make your own bouquet too.."
                            }
                        }
                    }
                },
                ["Items"] = new List<object>
                {
                    new
                    {
                        Id = "Example.ModId_IceCream",
                        Condition = "SEASON Summer",
                        ItemId = "(O)233"
                    },
                    new
                    {
                        Id = "Example.ModId_Tulip",
                        ItemId = "(O)591",
                        Price = 200,
                        AvailableStock = 3,
                        AvailableStockLimit = "Player"
                    },
                    new
                    {
                        Id = "Example.ModId_SummerSpangle",
                        ItemId = "(O)593",
                        Price = 300,
                        AvailableStock = 2,
                        AvailableStockLimit = "Player"
                    },
                    new
                    {
                        Id = "Example.ModId_FairyRose",
                        ItemId = "(O)595",
                        Price = 700,
                        AvailableStock = 1,
                        AvailableStockLimit = "Player"
                    },
                    new
                    {
                        Id = "Example.ModId_BlueJazz",
                        ItemId = "(O)597",
                        Price = 100,
                        AvailableStock = 5,
                        AvailableStockLimit = "Player"
                    },
                    new
                    {
                        Id = "Example.ModId_Poppy",
                        ItemId = "(O)376",
                        Price = 50,
                        AvailableStock = 10,
                        AvailableStockLimit = "Player"
                    },
                    new
                    {
                        Id = "Example.ModId_Sunflower",
                        ItemId = "(O)421",
                        Price = 10,
                        AvailableStock = 20,
                        AvailableStockLimit = "Player"
                    },
                    new
                    {
                        Id = "Example.ModId_SweetPea",
                        ItemId = "(O)402",
                        Price = 100,
                        AvailableStock = 5,
                        AvailableStockLimit = "Player"
                    },
                    new
                    {
                        Id = "Example.ModId_Crocus",
                        ItemId = "(O)418",
                        Price = 200,
                        AvailableStock = 3,
                        AvailableStockLimit = "Player"
                    }
                }
            };
            
            data["Example.ModId_CustomShop"] = flowerShop;
        }
        
    }
}
