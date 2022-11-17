Imports DevExpress.Mvvm

Namespace DateAndTimeColumns_Properties

    Public Class Item
        Inherits BindableBase

        Private dateTimeField As Date

        Public Property DateTime As Date
            Get
                Return dateTimeField
            End Get

            Set(ByVal value As Date)
                dateTimeField = value
                RaisePropertiesChanged()
            End Set
        End Property

        Public Property [Date] As Date
            Get
                Return dateTimeField.Date
            End Get

            Set(ByVal value As Date)
                Dim time = dateTimeField.TimeOfDay
                DateTime = value.Date + time
                RaisePropertiesChanged()
            End Set
        End Property

        Public Property Time As Date
            Get
                Return Date.Today.AddTicks(dateTimeField.TimeOfDay.Ticks)
            End Get

            Set(ByVal value As Date)
                DateTime = dateTimeField.Date.AddTicks(value.TimeOfDay.Ticks)
                RaisePropertiesChanged()
            End Set
        End Property
    End Class
End Namespace
