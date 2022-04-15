Public Class MediaControls




    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        PlayFunction()
    End Sub

    Public Sub PlayFunction()
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf PlayFunction))
        Else
            If CurrentDisplay = DisplayPanels.Spotify Then
                CarPCfrm.SpotifyPanel.PlayPause()
            Else
                If CarPCfrm.PlayerState = CarPCfrm.MediaState.Pause Then
                    'Resume Playback
                    CarPCfrm.MusicPanel.WMPlayer.Ctlcontrols.play()
                    CarPCfrm.SetPlayerState(CarPCfrm.MediaState.Play)
                    CarPCfrm.SetMusicPanelLayout(CarPCfrm.MusicPanelLayout.PlayerandPlaylist)

                ElseIf CarPCfrm.PlayerState = CarPCfrm.MediaState.Play Then
                    'Pause Playback
                    'CarPCfrm.SetMusicPanelLayout(CarPCfrm.MusicPanelLayout.MusicBrowser)
                    CarPCfrm.MusicPanel.WMPlayer.Ctlcontrols.pause()
                    CarPCfrm.SetPlayerState(CarPCfrm.MediaState.Pause)

                ElseIf CarPCfrm.PlayerState = CarPCfrm.MediaState.Stopped Then
                    'Start Playback

                    If Not CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex = -1 Then
                        CarPCfrm.MusicPanel.PlayMusic(MusicArr(CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex))
                    Else
                        CarPCfrm.MusicPanel.NextSong()
                    End If
                End If

            End If
        End If



    End Sub








    Dim VolType As Boolean
    Private Sub btnVolumeUp_Click(sender As Object, e As EventArgs) Handles btnVolumeUp.Click
        VolumeUp()
    End Sub

    Private Sub btnVolumeUp_MouseDown(sender As Object, e As EventArgs) Handles btnVolumeUp.MouseDown
        VolType = True
        tmrVolume.Enabled = True
    End Sub
    Private Sub btnVolumeUp_MouseUp(sender As Object, e As EventArgs) Handles btnVolumeUp.MouseUp
        tmrVolume.Enabled = False
        tmrVolume.Dispose()
    End Sub
    Private Sub btnVolumeDown_Click(sender As Object, e As EventArgs) Handles btnVolumeDown.Click
        VolumeDown()
    End Sub
    Private Sub btnVolumeDown_MouseDown(sender As Object, e As EventArgs) Handles btnVolumeDown.MouseDown
        VolType = False
        tmrVolume.Enabled = True
    End Sub
    Private Sub btnVolumeDown_MouseUp(sender As Object, e As EventArgs) Handles btnVolumeDown.MouseUp
        tmrVolume.Enabled = False
        tmrVolume.Dispose()
    End Sub

    Private Sub tmrVolume_Tick(sender As Object, e As EventArgs) Handles tmrVolume.Tick
        'Function to increase / decrease volume when button is held.
        'Each tick increases or decreases volume, release disables the timer and resets.
        If VolType = True Then
            VolumeUp()
        Else
            VolumeDown()
        End If
    End Sub

    Private Sub btnShuffle_Click(sender As Object, e As EventArgs) Handles btnShuffle.Click
        If MusicRandom = False Then
            MusicRandom = True
            btnShuffle.Image = My.Resources.Shuffle_On
        Else
            MusicRandom = False
            btnShuffle.Image = My.Resources.Shuffle_Off
            RandomHistoryCount = -1
            ReDim RandomHistory(0)

        End If
    End Sub

    Private Sub btnFav_Click(sender As Object, e As EventArgs) Handles btnFav.Click
        Dim TempHardFile As IO.StreamWriter
        If My.Computer.FileSystem.FileExists(PlaylistsDirectory & "Favourites.playlist") = True Then
            Dim Favourites As String() = IO.File.ReadAllLines(PlaylistsDirectory & "Favourites.playlist")

            If My.Computer.FileSystem.FileExists(PlaylistsDirectory & "Favourites.playlist.old") = True Then
                If MsgBox("Backup file of Favourites list has been detected, delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    My.Computer.FileSystem.DeleteFile(PlaylistsDirectory & "Favourites.playlist.old")
                    Exit Sub
                End If

            End If

            My.Computer.FileSystem.RenameFile(PlaylistsDirectory & "Favourites.playlist", "Favourites.playlist.old")
            TempHardFile = IO.File.CreateText(PlaylistsDirectory & "Favourites.playlist")

            Dim Exists As Boolean = False

            'Check if new entry is already in favourites list.
            For Each Fav In Favourites
                TempHardFile.WriteLine(Fav)
                If Fav.Contains(MusicArr(CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex)) Then
                    Exists = True
                End If
            Next
            'Scan complete, if =false then write new entry
            If Exists = False Then
                TempHardFile.WriteLine(MusicArr(CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex).Replace(MusicDirectory, ""))
            End If
        Else
            'No favourites list detected.
            TempHardFile = IO.File.CreateText(PlaylistsDirectory & "Favourites.playlist")
            TempHardFile.WriteLine(MusicArr(CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex).Replace(MusicDirectory, ""))
        End If


        'Close File
        TempHardFile.Close()
        btnFav.Enabled = False
        If My.Computer.FileSystem.FileExists(PlaylistsDirectory & "Favourites.playlist.old") = True Then
            My.Computer.FileSystem.DeleteFile(PlaylistsDirectory & "Favourites.playlist.old")
        End If

    End Sub


    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        CarPCfrm.MusicPanel.WMPlayer.Ctlcontrols.stop()
        CarPCfrm.SetPlayerState(CarPCfrm.MediaState.Stopped)
        CarPCfrm.SetMusicPanelLayout(CarPCfrm.MusicPanelLayout.MusicBrowser)
    End Sub


    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        CarPCfrm.MusicPanel.NextSong()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        CarPCfrm.MusicPanel.PreviousSong()
    End Sub






End Class
