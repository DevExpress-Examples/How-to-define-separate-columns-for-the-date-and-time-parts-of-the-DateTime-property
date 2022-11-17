using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DateAndTimeColumns_Properties
{
    internal class MainViewModel : BindableBase
    {
        public ObservableCollection<Item> Source { get; }

        public MainViewModel() {
            Source = new ObservableCollection<Item>(Enumerable.Range(0, 1000).Select(i => new Item {
                DateTime = new DateTime(1500 + i, 1 + i % 12, 1 + i % 28, i % 24, i % 60, i % 60)
            }));
        }
    }
}
