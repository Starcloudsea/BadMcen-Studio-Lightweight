using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Classes.Minecraft;
using BadMC_Launcher.Extensions;
using BadMC_Launcher.Interfaces;
using BadMC_Launcher.Servicess.Settings;
using MinecraftLaunch.Base.Models.Game;
using Uno.Extensions.Specialized;

namespace BadMC_Launcher.Classes.MainSearch;
public class MainMenuSearchMinecraftEntryFilter : IMainMenuSharchFilterItem {
    public required string ItemName { get; init; }

    public required string IconGlyph { get; init; }

    public IEnumerable<MainMenuSearchResultItem> Search(string searchText) {
        var returnList = new List<MainMenuSearchResultItem>();
        //Get MinecraftPaths
        App.GetService<MinecraftConfigService>().MinecraftPaths.ForEach(minecraftPath => {
            MinecraftPathEntry pathEntry = minecraftPath;
            foreach (var minecraftEntry in pathEntry.GetMinecrafts().Where(item => item.Id.Contains(searchText))) {
                var viewItem = pathEntry.GetMinecraftItem(minecraftEntry);
                if (viewItem != null) {
                    returnList.Add(new MainMenuSearchResultItem() {
                        ItemTitle = viewItem.MinecraftId,
                        ItemSubTitle = viewItem.MinecraftEntry.MinecraftFolderPath,
                        ItemIcon = new Image() {
                            Source = viewItem.MinecraftImage,
                            Stretch = Stretch.UniformToFill
                        },
                        Navigate = NavigateTo(viewItem),
                    });
                }
            }
        });
        return returnList;
    }

    public Action NavigateTo(MinecraftItem minecraftItem) {
        return () => {
            Debug.WriteLine($"诶诶还妹写呢Σ(っ °Д °;)っ {minecraftItem.MinecraftId}");
        };
        //throw new NotImplementedException("诶诶还妹写呢Σ(っ °Д °;)っ");
        //TODO: 弹出特定的版本页面
    }
}
