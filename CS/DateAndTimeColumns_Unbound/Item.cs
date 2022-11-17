using DevExpress.Mvvm;
using System;

namespace DateAndTimeColumns_Unbound
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
    }
}
