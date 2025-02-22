using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Classes;

namespace BadMC_Launcher.Interfaces;

public interface IMainMenuSharchItem {
    public string ItemName { get; init; }

    public IconElement ItemIcon { get; init; }

    public List<MainSearchResultItem> Search(string searchText);
}
