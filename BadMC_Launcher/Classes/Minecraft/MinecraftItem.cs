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

namespace BadMC_Launcher.Classes.Minecraft;
public class MinecraftItem {
    public string MinecraftName { get => MinecraftEntry.Id; init; } = string.Empty;

    public required MinecraftEntry MinecraftEntry { get; set; }

    public required BitmapImage MinecraftImage { get; init; }

    public required HashSet<MetadataItem> MinecraftTags { get; init; }

    public bool IsStarred { get; set; }

    public string GetMinecraftName() => MinecraftEntry.Id;
}
