Public Class SoundCloud




    Private Sub SoundCloud_Load(sender As Object, e As EventArgs) Handles Me.Load
        WebBrowserControl.Focus()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SendKeys.Send("^-")
        Timer1.Enabled = False
    End Sub
End Class
