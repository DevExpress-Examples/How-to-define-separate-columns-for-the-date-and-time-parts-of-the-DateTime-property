Imports DevExpress.Mvvm
Imports System
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace DateAndTimeColumns_Unbound

    Friend Class MainViewModel
        Inherits BindableBase

        Public ReadOnly Property Source As ObservableCollection(Of Item)

        Public Sub New()
            Source = New ObservableCollection(Of Item)(Enumerable.Range(0, 1000).[Select](Function(i) New Item With {.DateTime = New DateTime(1500 + i, 1 + i Mod 12, 1 + i Mod 28, i Mod 24, i Mod 60, i Mod 60)}))
        End Sub
    End Class
End Namespace
