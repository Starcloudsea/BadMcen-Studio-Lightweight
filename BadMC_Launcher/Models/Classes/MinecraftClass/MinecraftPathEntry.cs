using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMC_Launcher.Models.Classes.MinecraftClass;
public record MinecraftPathEntry {
    public required string MinecraftPath { get; set; }

    public required string MinecraftName { get; set; }

    public JsonList<string>? StarredMinecrafts { get; set; }
}
