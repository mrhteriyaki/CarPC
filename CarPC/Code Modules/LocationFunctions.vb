Module LocationFunctions
    Dim Home_State As Integer = -1
    Public Sub SetHome(ByVal AtHomeState As Boolean)
        If AtHomeState = True Then
            If Home_State = -1 Then
                'first time setting home status.
                Home_State = 1
            ElseIf Home_State = 0 Then
                'location has arrived home.
                Home_State = 1
                ArrivedHome()
            End If
            'Else is already same state. no change.
        Else
            If Home_State = -1 Then
                'first time setting home state.
            ElseIf Home_State = 1 Then
                'location has transactioned away from home
                Home_State = False
                LeftHome()
            End If
        End If
    End Sub


    Private Sub ArrivedHome()
        InvokeControl(carpc_form_variable.txtHomeAlert, Sub(x) x.Visible = True)
        BinCheck_Tuesday()
    End Sub

    Private Sub LeftHome()
        InvokeControl(carpc_form_variable.txtHomeAlert, Sub(x) x.Visible = False)
    End Sub


    Private Sub BinCheck_Tuesday()
        If DateTime.Today.DayOfWeek = DayOfWeek.Tuesday Then
            MsgBox("Tuesday Home Reminder - Put the bins out")
        End If

    End Sub
End Module
