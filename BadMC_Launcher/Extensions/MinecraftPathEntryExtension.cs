using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Classes.Minecraft;
using BadMC_Launcher.Constants.Enums;
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
                string path;

                var minecraftEntryImageEnum = minecraftEntry.GetMinecraftImage();
                if (minecraftEntryImageEnum == MinecraftEntryImageEnum.Custom) {
                    path = Path.Combine(minecraftEntry.MinecraftFolderPath, @"BadBCConfigs\icon.png");
                    if (!File.Exists(path)) {
                        throw new FileNotFoundException($"\"{path}\" is not found.");
                    }
                }
                else {
                    path = @$"ms-appx:///Assets/Icons/MinecraftIcons/{minecraftEntryImageEnum.ToString().ToLower()}.png";
                }
                if (minecraftPath.StarredMinecraftIds != null) {
                    isStarred = minecraftPath.StarredMinecraftIds.IndexOf(minecraftEntry.Id) >= 0;
                }
                return new MinecraftItem() {
                    MinecraftEntry = minecraftEntry,
                    MinecraftImage = new BitmapImage() { UriSource = new Uri(path) },
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
            var minecraftEntryImageEnum = entry.GetMinecraftImage();
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
