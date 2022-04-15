Module ThreadingControl


    Public Sub InvokeControl(Of T As Control)(ByVal Control As T, ByVal Action As Action(Of T))
        If Control.InvokeRequired Then
            Try
                Control.Invoke(New Action(Of T, Action(Of T))(AddressOf InvokeControl), New Object() {Control, Action})
            Catch ex As Exception
            End Try
        Else
            Action(Control)
        End If
    End Sub

End Module
