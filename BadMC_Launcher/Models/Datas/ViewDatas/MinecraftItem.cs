using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Extensions;
using BadMC_Launcher.Classes;
using CommunityToolkit.WinUI.Controls;
using Microsoft.CodeAnalysis;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BadMC_Launcher.Models.Datas.ViewDatas;
public class MinecraftItem {
    public required MinecraftEntry MinecraftEntry { get; set; }

    public string? MinecraftName { get => MinecraftEntry.Id; init; }

    public required BitmapImage MinecraftImage { get; init; }

    public required HashSet<MetadataItem> MinecraftTags { get; init; }

    public bool IsStarred { get; set; }

    public static MinecraftItem? GetMinecraftItem(string minecraftEntryId, MinecraftPathEntry minecraftPath) {
        try {
            var minecraftParser = new MinecraftParser(minecraftPath.MinecraftPath);
            var minecraftEntry = minecraftParser.GetMinecraft(minecraftEntryId);
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
                path = @$"ms-appx:///Assets/Icons/MinecraftIcons/{minecraftEntryImageEnum.ToString()}.png";
            }
            if (minecraftPath.StarredMinecraftIds != null) {
                isStarred = minecraftPath.StarredMinecraftIds.IndexOf(minecraftEntryId) >= 0;
            }
            return new MinecraftItem() {
                MinecraftEntry = minecraftEntry,
                MinecraftImage = new BitmapImage() { UriSource = new Uri(path) },
                MinecraftTags = (HashSet<MetadataItem>)minecraftEntry.GetMinecraftEntryTags(),
                IsStarred = isStarred
            };
        }
        catch {

        }
        return null;
    }

    public static IEnumerable<MinecraftItem> GetMinecraftItems(MinecraftPathEntry minecraftPath) {
        var minecraftParser = new MinecraftParser(minecraftPath.MinecraftPath);
        var items = new ObservableCollection<MinecraftItem>();
        foreach (var entry in minecraftParser.GetMinecrafts()) {
            var isStarred = false;
            string path;
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
