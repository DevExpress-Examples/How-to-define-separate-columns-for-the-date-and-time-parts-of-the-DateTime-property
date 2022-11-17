using DevExpress.Mvvm;
using System;

namespace DateAndTimeColumns_Properties
{
    public class Item : BindableBase
    {
        private DateTime dateTime;
        public DateTime DateTime {
            get => dateTime;
            set {
                dateTime = value;
                RaisePropertiesChanged();
            }
        }

        public DateTime Date {
            get => dateTime.Date;
            set {
                var time = dateTime.TimeOfDay;
                DateTime = value.Date + time;
                RaisePropertiesChanged();
            }
        }

        public DateTime Time {
            get => DateTime.Today.AddTicks(dateTime.TimeOfDay.Ticks);
            set {
                DateTime = dateTime.Date.AddTicks(value.TimeOfDay.Ticks);
                RaisePropertiesChanged();
            }
        }
    }
}
