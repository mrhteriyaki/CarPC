Public Class MediaInfo

    Private Sub tmrSongTime_Tick(sender As Object, e As EventArgs) Handles tmrSongTime.Tick
        If CarPCfrm.MusicPanel.WMPlayer.currentMedia.duration = 0 Or CarPCfrm.MusicPanel.WMPlayer.Ctlcontrols.currentPosition() = 0 Then
            pbSongTime.Value = 0
            lblSongTime.Text = ""
            tmrSongTimeLabel.Enabled = False
        Else
            Dim SongTimePosition As Double = (CarPCfrm.MusicPanel.WMPlayer.Ctlcontrols.currentPosition() / CarPCfrm.MusicPanel.WMPlayer.currentMedia.duration) * 100
            If SongTimePosition <= 100 And SongTimePosition >= 0 Then
                pbSongTime.Value = SongTimePosition
            End If
            tmrSongTimeLabel.Enabled = True
            End If
    End Sub

    Private Sub MediaInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbSongTime.Width = PanelWidth
        lblMediaPlayerText.Location = New Point(0, 0)
        lblSongTime.Location = New Point(PanelWidth - 250, 25)
        lblMediaPlayerText.Text = "Player Stopped"
        lblSongTime.Text = ""
    End Sub

    Private Sub tmrSongTimeLabel_Tick(sender As Object, e As EventArgs) Handles tmrSongTimeLabel.Tick
        Dim T1 As Double = Math.Round(CarPCfrm.MusicPanel.WMPlayer.Ctlcontrols.currentPosition(), 0)
        Dim T1M As Double = 0
        Dim T2 As Double = Math.Round(CarPCfrm.MusicPanel.WMPlayer.currentMedia.duration, 0)
        Dim T2M As Double = 0
        Do Until T1 < 60
            T1 -= 60
            T1M += 1
        Loop
        Do Until T2 < 60
            T2 -= 60
            T2M += 1
        Loop

        Dim T1S As String = T1
        Dim T2S As String = T2
        'Append zeros for correct time format.
        If T1 < 10 Then
            T1S = "0" & T1
        End If
        If T2 < 10 Then
            T2S = "0" & T2
        End If
        

        Dim TimeString As String = T1M & ":" & T1S & " / " & T2M & ":" & T2S

        lblSongTime.Text = "Song Time: " & TimeString
    End Sub

    Private Sub pbSongTime_Click(sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbSongTime.Click
        'Set Song time by location of mouse click on progressbar.
        Dim TargetPositionMultiplier As Double = (e.Location.X - pbSongTime.Location.X) / pbSongTime.Width
        CarPCfrm.MusicPanel.WMPlayer.Ctlcontrols.currentPosition = (TargetPositionMultiplier * CarPCfrm.MusicPanel.WMPlayer.currentMedia.duration)

    End Sub
End Class
