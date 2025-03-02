using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BadMC_Launcher.Extensions;
public class ObservableDataList<T> : ObservableCollection<T> {

    public ObservableDataList(IEnumerable<T> initialData) : base(initialData) {

    }
    public ObservableDataList() {

    }
    protected override void InsertItem(int index, T item) {
        if (!Contains(item)) {
            base.InsertItem(index, item);
        }
    }
    protected override void SetItem(int index, T item) {
        if (!Contains(item)) {
            base.SetItem(index, item);
        }
    }
}
