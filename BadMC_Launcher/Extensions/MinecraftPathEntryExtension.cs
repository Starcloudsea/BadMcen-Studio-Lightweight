using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Classes.Minecraft;
using BadMC_Launcher.Enums;
using BadMC_Launcher.Services;
using CommunityToolkit.WinUI.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;

namespace BadMC_Launcher.Extensions;
public static class MinecraftPathEntryExtension {
    public static MinecraftItem? GetMinecraftItem(this MinecraftPathEntry minecraftPath, string minecraftEntryId) {
        try {
            return minecraftPath.GetMinecraftItem(minecraftPath.GetMinecraftParser().GetMinecraft(minecraftEntryId));
        }
        catch {

        }
        return null;
    }

    public static MinecraftItem? GetMinecraftItem(this MinecraftPathEntry minecraftPath, MinecraftEntry minecraftEntry) {
        try {
            if (minecraftEntry != null) {
                var isStarred = false;
                var minecraftEntryImageEnum = minecraftEntry.GetMinecraftImageEnum();
                BitmapImage? image = null;
                if (minecraftEntryImageEnum == MinecraftEntryImageEnum.Custom) {
                    var path = Path.Combine(minecraftEntry.MinecraftFolderPath, @"BadBCConfigs\icon.png");
                    if (File.Exists(path)) {
                        image = new(new Uri(path));
                    }
                }
                else {
                    if (App.GetService<AppAssetsService>().MinecraftImageInstance[minecraftEntryImageEnum].Value.TryGetTarget(out BitmapImage? instance)) {
                        image = instance;
                    }
                }

                if (image == null) {
                    //TODO: Dialog Ex
                    image = new(new Uri($@"ms-appx:///Assets/Icons/MinecraftIcons/{MinecraftEntryImageEnum.Unknown.ToString().ToLower()}.png"));
                }

                if (minecraftPath.StarredMinecraftIds != null) {
                    isStarred = minecraftPath.StarredMinecraftIds.IndexOf(minecraftEntry.Id) >= 0;
                }

                return new MinecraftItem() {
                    MinecraftEntry = minecraftEntry,
                    MinecraftImage = image,
                    MinecraftTags = (HashSet<MetadataItem>)minecraftEntry.GetMinecraftEntryTags(),
                    IsStarred = isStarred
                };
            }

        }
        catch {

        }
        return null;
    }

    public static IEnumerable<MinecraftItem> GetMinecraftItems(this MinecraftPathEntry minecraftPath) {
        var minecraftParser = minecraftPath.GetMinecraftParser();
        var items = new ObservableCollection<MinecraftItem>();
        foreach (var entry in minecraftParser.GetMinecrafts()) {
            var isStarred = false;
            string path;

            //Get Minecraft Icon
            var minecraftEntryImageEnum = entry.GetMinecraftImageEnum();
            if (minecraftEntryImageEnum == MinecraftEntryImageEnum.Custom) {
                path = Path.Combine(entry.MinecraftFolderPath, @"BadBCConfigs\icon.png");
                if (!File.Exists(path)) {
                    throw new FileNotFoundException($"\"{path}\" is not found.");
                }
            }
            else {
                path = @$"ms-appx:///Assets/Icons/MinecraftIcons/{minecraftEntryImageEnum.ToString()}.png";
            }

            //IsStarred
            if (minecraftPath.StarredMinecraftIds != null) {
                isStarred = minecraftPath.StarredMinecraftIds.IndexOf(entry.Id) >= 0;
            }
            items.Add(new MinecraftItem() {
                MinecraftEntry = entry,
                MinecraftImage = new BitmapImage() { UriSource = new Uri(path) },
                MinecraftTags = (HashSet<MetadataItem>)entry.GetMinecraftEntryTags(),
                IsStarred = isStarred,
            });
        }
        return items;
    }

   
}
