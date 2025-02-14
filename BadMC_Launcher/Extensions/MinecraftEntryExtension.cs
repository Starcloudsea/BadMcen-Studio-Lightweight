using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.WinUI.Controls;
using MinecraftLaunch.Base.Enums;
using MinecraftLaunch.Base.Models.Game;
using Uno.Extensions.Specialized;

namespace BadMC_Launcher.Extensions;
public static class MinecraftEntryExtension {
    public static MinecraftEntryImageEnum GetMinecraftImage(this MinecraftEntry minecraftEntry) {
        if (File.Exists(Path.Combine(minecraftEntry.MinecraftFolderPath, @"BadBCConfigs\icon.png"))) {
            return MinecraftEntryImageEnum.Custom;
        }
        if (minecraftEntry is VanillaMinecraftEntry vanillaEntry) {
            if (vanillaEntry.Version.Type == MinecraftVersionType.Release) {
                return MinecraftEntryImageEnum.Creeper;
            }
            else if (vanillaEntry.Version.Type == MinecraftVersionType.PreRelease || vanillaEntry.Version.Type == MinecraftVersionType.Snapshot) {
                return MinecraftEntryImageEnum.Drowned;
            }
            else if (vanillaEntry.Version.Type == MinecraftVersionType.OldAlpha || vanillaEntry.Version.Type == MinecraftVersionType.OldBeta) {
                return MinecraftEntryImageEnum.Old;
            }
            else {
                return MinecraftEntryImageEnum.Unknown;
            }
        }
        else if (minecraftEntry is ModifiedMinecraftEntry modifiedEntry) {
            if (modifiedEntry.ModLoaders.All(item => item.Type == ModLoaderType.OptiFine)) {
                return MinecraftEntryImageEnum.OptiFine;
            }
            else {
                MinecraftEntryImageEnum minecraftEntryImage = MinecraftEntryImageEnum.Drowned;
                foreach (var item in modifiedEntry.ModLoaders) {
                    switch (item.Type) {
                        case ModLoaderType.Forge:
                            minecraftEntryImage = MinecraftEntryImageEnum.Forge;
                            break;
                        case ModLoaderType.NeoForge:
                            minecraftEntryImage = MinecraftEntryImageEnum.NeoForge;
                            break;
                        case ModLoaderType.Fabric:
                            minecraftEntryImage = MinecraftEntryImageEnum.Fabric;
                            break;
                        case ModLoaderType.Quilt:
                            minecraftEntryImage = MinecraftEntryImageEnum.Quilt;
                            break;
                        case ModLoaderType.LiteLoader:
                            minecraftEntryImage = MinecraftEntryImageEnum.LiteLoader;
                            break;
                    }
                }
                return minecraftEntryImage;
            }
        }
        throw new NotImplementedException("欸等一下Σ(っ °Д °;)っ我们还没支持这个类型呢你怎么就给（*#……*！&@%！*……@");
    }
    public static IEnumerable<MetadataItem> GetMinecraftEntryTags(this MinecraftEntry minecraftEntry) {
        var tags = new HashSet<MetadataItem>() { new MetadataItem() { Label = $"{minecraftEntry.Version.Type} {minecraftEntry.Version.VersionId}" } };
        if (minecraftEntry is ModifiedMinecraftEntry modifiedEntry) {
            modifiedEntry.ModLoaders.ForEach(item => tags.Add(new MetadataItem() { Label = $"{item.Type} {item.Version}" }));
        }
        return tags;
    }
}
