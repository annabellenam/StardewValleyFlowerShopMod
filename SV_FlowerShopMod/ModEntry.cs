using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using xTile;
using xTile.Tiles;
using xTile.Layers;
using xTile.Dimensions;
namespace SV_FLowerShopMod
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry: Mod
    {
        /*********
         ** Public methods
         *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
        }

        private void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
        {
            if (e.Name.IsEquivalentTo("Maps/Forest"))
            {
                e.Edit(asset =>
                {
                    IAssetDataForMap editor = asset.AsMap();
                    Map map = editor.Data;

                    var customMap = this.Helper.Content.Load<Map>("assets/Forest.tmx");
                });
            }

            if (e.Name.IsEquivalentTo("Maps/FlowerMapInterior"))
            {
                e.Edit(asset =>
                {
                    IAssetDataForMap editor = asset.AsMap();
                    Map map = editor.Data;
                    var customMap = this.Helper.Content.Load<Map>("assets/FlowerMapInterior.tmx");
                    //make sure to name is FlowerMapInterior bc i marked warp to that map
                };
            }
        }
        private Tile GetTile(Map map, string layerName, int tileX, int tileY)
        {
            Layer layer = map.GetLayer(layerName);
            Location pixelPosition = new Location(tileX * Game1.tileSize, tileY * Game1.tileSize);

            return layer.PickTile(pixelPosition, Game1.viewport.Size);
        }

        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
         //https://gamedev.stackexchange.com/questions/157885/smapi-add-warp-to-existing-map-stardew-valley
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;
            if (!e.Button.IsActionButton()) return; //not action/ready

            // idk if we need this later but i jsut tagged it out
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        } 
    }
}