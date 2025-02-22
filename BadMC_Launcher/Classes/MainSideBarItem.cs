using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMC_Launcher.Classes;

public class MainSideBarItem {
    public required string ItemName { get; set; }

    public required IconElement ItemIcon { get; set; }

    public required Type NavigatePage { get; set; }

    public InfoBadge? ItemInfoBadge { get; set; }
}
