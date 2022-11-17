Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.Xpf
Imports System
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace DateAndTimeColumns_UnboundEditable

    Friend Class MainViewModel
        Inherits BindableBase

        Public ReadOnly Property Source As ObservableCollection(Of Item)

        Public ReadOnly Property UnboundColumnDataCommand As ICommand(Of UnboundColumnRowArgs)

        Public Sub New()
            UnboundColumnDataCommand = New DelegateCommand(Of UnboundColumnRowArgs)(Sub(e) ColumnData(e))
            Source = New ObservableCollection(Of Item)(Enumerable.Range(0, 1000).[Select](Function(i) New Item With {.DateTime = New DateTime(1500 + i, 1 + i Mod 12, 1 + i Mod 28, i Mod 24, i Mod 60, i Mod 60)}))
        End Sub

        Private Sub ColumnData(ByVal e As UnboundColumnRowArgs)
            If e.IsGetData Then
                Select Case e.FieldName
                    Case "Date"
                        e.Value = Source(e.SourceIndex).DateTime.Date
                    Case "Time"
                        e.Value = Date.Today.AddTicks(Source(e.SourceIndex).DateTime.TimeOfDay.Ticks)
                    Case Else
                End Select

                Return
            End If

            If e.IsSetData Then
                Select Case e.FieldName
                    Case "Date"
                        Dim time = Source(e.SourceIndex).DateTime.TimeOfDay
                        Source(e.SourceIndex).DateTime =(CDate(e.Value)).Date + time
                    Case "Time"
                        Source(e.SourceIndex).DateTime = Source(e.SourceIndex).DateTime.Date.AddTicks((CDate(e.Value)).TimeOfDay.Ticks)
                    Case Else
                End Select
            End If
        End Sub
    End Class
End Namespace
