using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMC_Launcher.Classes;

public class MainSearchResultItem {
    public required string ItemTitle { get; init; }

    public required string SubTitle { get; init; }

    public required IconElement ItemIcon { get; init; }

    public required Action Navigate { get; init; }
}
