using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMC_Launcher.Interfaces;
public interface IConfigClass {
    public bool SyncSettingGet();

    public bool SyncSettingSet();
}
