Public Class frmModeWindow

    Private Sub tmrCloseWindow_Tick(sender As Object, e As EventArgs) Handles tmrCloseWindow.Tick
        tmrCloseWindow.Enabled = False
        ModeWindowOpen = False
        Me.Close()
    End Sub

    Private Sub frmModeWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(150, 0)
        lblMode.Text = "Mode: " & ModeState
        tmrCloseWindow.Enabled = True
    End Sub

End Class