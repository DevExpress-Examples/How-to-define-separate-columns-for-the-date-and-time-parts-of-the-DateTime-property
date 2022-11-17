using DevExpress.Mvvm;
using System;

namespace DateAndTimeColumns_UnboundEditable
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
