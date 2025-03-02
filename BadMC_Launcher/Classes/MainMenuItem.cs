using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMC_Launcher.Classes;
public class MainMenuItem {
    public required string ItemName { get; set; }

    public required IconElement ItemIcon { get; set; }

    public required FrameworkElement? ItemHeader { get; set; }

    public required Brush ItemBrush { get; set; }

    public required Brush ItemSize { get; set; }

    public required Action Navigate { get; set; }
}
