Public Class SWControls



    Private Sub Steering_Wheel_Controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ButtonValues As String() = IO.File.ReadAllLines(RunLocation & "\values.ini")
        txtSeekMin.Text = ButtonValues(0)
        txtSeekMax.Text = ButtonValues(1)
        txtVolumeUpMin.Text = ButtonValues(2)
        txtVolumeUpMax.Text = ButtonValues(3)
        txtVolumeDownMin.Text = ButtonValues(4)
        txtVolumeDownMax.Text = ButtonValues(5)
        txtMediaMin.Text = ButtonValues(6)
        txtMediaMax.Text = ButtonValues(7)
        txtModeMin.Text = ButtonValues(8)
        txtModeMax.Text = ButtonValues(9)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ButtonValues(0) = txtSeekMin.Text
        ButtonValues(1) = txtSeekMax.Text
        ButtonValues(2) = txtVolumeUpMin.Text
        ButtonValues(3) = txtVolumeUpMax.Text
        ButtonValues(4) = txtVolumeDownMin.Text
        ButtonValues(5) = txtVolumeDownMax.Text
        ButtonValues(6) = txtMediaMin.Text
        ButtonValues(7) = txtMediaMax.Text
        ButtonValues(8) = txtModeMin.Text
        ButtonValues(9) = txtModeMax.Text



        SaveSteeringWheelControlValues()

    End Sub

    Private Sub btnOSK_Click(sender As Object, e As EventArgs)
        Process.Start("C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe")
    End Sub

    Private Sub btnGetValue_Click(sender As Object, e As EventArgs) Handles btnGetValue.Click
        SendAccessSerialCommand("GETVALUE" & Chr(13))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CarPCfrm.KeyboardShowHide()
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click

    End Sub

    Private Sub txtSeekMin_TextChanged(sender As Object, e As EventArgs) Handles txtSeekMin.TextChanged

    End Sub
End Class
