using DevExpress.Mvvm;
using DevExpress.Mvvm.Xpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DateAndTimeColumns_UnboundEditable
{
    internal class MainViewModel : BindableBase
    {
        public ObservableCollection<Item> Source { get; }

        public ICommand<UnboundColumnRowArgs> UnboundColumnDataCommand { get; }

        public MainViewModel() {
            UnboundColumnDataCommand = new DelegateCommand<UnboundColumnRowArgs>((e) => ColumnData(e));

            Source = new ObservableCollection<Item>(Enumerable.Range(0, 1000).Select(i => new Item {
                DateTime = new DateTime(1500 + i, 1 + i % 12, 1 + i % 28, i % 24, i % 60, i % 60)
            }));
        }

        private void ColumnData(UnboundColumnRowArgs e) {

            if (e.IsGetData) {
                switch (e.FieldName) {
                    case "Date":
                        e.Value = Source[e.SourceIndex].DateTime.Date;
                        break;
                    case "Time":
                        e.Value = DateTime.Today.AddTicks(Source[e.SourceIndex].DateTime.TimeOfDay.Ticks);
                        break;
                    default:
                        break;
                }

                return;
            }

            if (e.IsSetData) {
                switch (e.FieldName) {
                    case "Date":
                        var time = Source[e.SourceIndex].DateTime.TimeOfDay;
                        Source[e.SourceIndex].DateTime = ((DateTime)e.Value).Date + time;
                        break;
                    case "Time":
                        Source[e.SourceIndex].DateTime = Source[e.SourceIndex].DateTime.Date.AddTicks(((DateTime)e.Value).TimeOfDay.Ticks);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
