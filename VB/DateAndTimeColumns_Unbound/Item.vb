Imports DevExpress.Mvvm

Namespace DateAndTimeColumns_Unbound

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
    End Class
End Namespace
