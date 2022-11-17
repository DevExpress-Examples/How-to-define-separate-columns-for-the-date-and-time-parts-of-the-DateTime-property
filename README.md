# How to define separate columns for the date and time parts of the DateTime property

In this example, we illustrate how to show separate columns for different parts of DateTime objects. There are three ways to accomplish the task:

1. Adjust the implementation of the data item class and add extra Date and Time properties. Use these properties as wrappers for the DateTime property:

    ```cs
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
    ```

---

2. Define the Date and Time unbound columns and use [UnboundExpresssions](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.UnboundExpression) to show the corresponding date and time values:

    ```xaml
    <dxg:GridControl.Columns>
        <dxg:GridColumn FieldName="Date"
                        Header="Date"
                        UnboundType="DateTime"
                        UnboundExpression="GetDate([DateTime])"
                        AllowEditing="False"/>
        <dxg:GridColumn FieldName="Time" 
                        Header="Time"
                        UnboundType="DateTime" 
                        UnboundExpression="AddTicks(Today(), GetTimeOfDay([DateTime]))"
                        AllowEditing="False">
            <dxg:GridColumn.EditSettings>
                <dxe:DateEditSettings DisplayFormat="T">
                    <dxe:DateEditSettings.StyleSettings>
                        <dxe:DateEditTimePickerStyleSettings/>
                    </dxe:DateEditSettings.StyleSettings>
                </dxe:DateEditSettings>
            </dxg:GridColumn.EditSettings>
        </dxg:GridColumn>
    </dxg:GridControl.Columns>
    ```

    **IMPORTANT:**
    With this solution, cells in these columns are read-only. If editing is required, consider using solution #1 or #3.

---

3. Define the unbound Date and Time columns and utilize the [CustomUnboundColumnData](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomUnboundColumnData) event or [CustomUnboundColumnDataCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomUnboundColumnDataCommand) to execute the required conversion:

    ```cs
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
                    Source[e.SourceIndex].DateTime = Source[e.SourceIndex].DateTime.Date
                          .AddTicks(((DateTime)e.Value).TimeOfDay.Ticks);
                    break;
                default:
                    break;
            }
        }
    }
    ```

---

**See also:**
[Unbound Columns](https://docs.devexpress.com/WPF/6124/controls-and-libraries/data-grid/grid-view-data-layout/columns-and-card-fields/unbound-columns)
