using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Extensions;
using CommunityToolkit.WinUI.Controls;
using Microsoft.CodeAnalysis;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Game;

namespace BadMC_Launcher.Models.ViewDatas;
public class MinecraftItem {
    public required MinecraftEntry MinecraftEntry { get; set; }

    public string? MinecraftName { get => MinecraftEntry.Id; init; }

    public required string MinecraftImagePath { get; init; }

    public required HashSet<MetadataItem> MinecraftTags { get; init; }

    public static MinecraftItem GetMinecraftItem(MinecraftEntry minecraftEntry) {
        string path;
        var minecraftEntryImageEnum = minecraftEntry.GetMinecraftImage();
        if (minecraftEntryImageEnum == MinecraftEntryImageEnum.Custom) {
            path = Path.Combine(minecraftEntry.MinecraftFolderPath, @"BadBCConfigs\icon.png");
            if (!File.Exists(path)) {
                throw new FileNotFoundException($"\"{path}\" is not found.");
            }
        }
        else {
            path = Path.Combine(minecraftEntry.MinecraftFolderPath, @$"\Assets\Icons\MinecraftIcons\{minecraftEntryImageEnum.ToString()}.png");
        }
        return new MinecraftItem() {
            MinecraftEntry = minecraftEntry,
            MinecraftImagePath = path,
            MinecraftTags = (HashSet<MetadataItem>)minecraftEntry.GetMinecraftEntryTags()
        };
    }

    public static IEnumerable<MinecraftItem> GetMinecraftItems(IEnumerable<MinecraftEntry> minecraftEntries) {
        var items = new ObservableCollection<MinecraftItem>();
        foreach (var entry in minecraftEntries) {
            string path;
            var minecraftEntryImageEnum = entry.GetMinecraftImage();
            if (minecraftEntryImageEnum == MinecraftEntryImageEnum.Custom) {
                path = Path.Combine(entry.MinecraftFolderPath, @"BadBCConfigs\icon.png");
                if (!File.Exists(path)) {
                    throw new FileNotFoundException($"\"{path}\" is not found.");
                }
            }
            else {
                path = Path.Combine(entry.MinecraftFolderPath, @$"\Assets\Icons\MinecraftIcons\{minecraftEntryImageEnum.ToString()}.png");
            }
            items.Add(new MinecraftItem() {
                MinecraftEntry = entry,
                MinecraftImagePath = path,
                MinecraftTags = (HashSet<MetadataItem>)entry.GetMinecraftEntryTags()
            });
        }
        return items;
    }
}
