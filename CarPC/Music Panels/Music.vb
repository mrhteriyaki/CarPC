Imports WMPLib

Public Class Music





    Private Sub WMPlayer_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles WMPlayer.PlayStateChange
        'When song finish move to next. - requires delay otherwise song starts and stops.
        If WMPlayer.playState = WMPPlayState.wmppsMediaEnded Then
            CarPCfrm.SetPlayerState(CarPCfrm.MediaState.Stopped)

            tmrMediaFinished.Enabled = True
        End If

    End Sub





    Public Sub PlayMusic(ByVal FileName As String)


        'ID3 Tag, Title, Artist, Album
        Try
            VideoMode = False 'reset to default & check if video type for panel resize.
            For Each videotype In VideoFileTypes
                If FileName.Substring(FileName.LastIndexOf(".") + 1).ToLower = videotype.ToLower Then
                    VideoMode = True
                End If
            Next

            'Music Mode, look for image.
            UpdateMusicImage(FileName)

            'mute while change to stop spikes.
            Dim TmpVolumeLevel As Integer = WMPlayer.settings.volume
            WMPlayer.settings.volume = 0

            Try
                Dim MP3File As TagLib.File = TagLib.File.Create(FileName)
                Album = MP3File.Tag.Album
                Title = MP3File.Tag.Title
                If Title = "" Then
                    Title = FileName.Replace(MusicDirectory, "")
                End If
                Artist = ""
                For Each Peformer In MP3File.Tag.Performers
                    Artist &= Peformer & ", "
                Next
                If Artist.Length > 0 Then
                    Artist = Microsoft.VisualBasic.Left(Artist, Artist.Length - 2)
                End If

                CarPCfrm.MediaInfoPanel.lblMediaPlayerText.Text = "Title: " & Title & Environment.NewLine & "Artist: " & Artist & Environment.NewLine & "Album: " & Album

            Catch ex As Exception
                If DebugingEnabled = True Then
                    ErrorLogQueue.Enqueue("Unable to get ID3 data for: " & FileName & Environment.NewLine & ex.ToString)
                End If

            End Try

            WMPlayer.URL = FileName
            CarPCfrm.SetPlayerState(CarPCfrm.MediaState.Play)
            CarPCfrm.SetMusicPanelLayout(CarPCfrm.MusicPanelLayout.PlayerandPlaylist)
            CarPCfrm.MediaInfoPanel.tmrSongTime.Enabled = True
            CarPCfrm.MediaInfoPanel.tmrSongTimeLabel.Enabled = True
            'restore volume to prevent spikes
            WMPlayer.settings.volume = TmpVolumeLevel
        Catch ex As Exception
            'failure to play song
            If DebugingEnabled = True Then
                ErrorLogQueue.Enqueue(ex.ToString)
            End If

            NextSong()
            End Try
     

    End Sub

    Private Sub UpdateMusicImage(ByRef FileName As String)
        If VideoMode = False Then
            Dim Filepath As New IO.FileInfo(FileName)
            Dim Filefound As Boolean = False
            For Each file In Delimon.Win32.IO.Directory.GetFiles(Filepath.Directory.FullName, "*.jpg")
                pbxMusicImage.Image = Image.FromFile(file)
                Filefound = True
                Exit For
            Next

            'No image found, set to blank.
            If Filefound = False Then
                NoPicture = True
                pbxMusicImage.Image = Nothing
            Else
                NoPicture = False
            End If
            UpdatePlayerImageSize()

        End If


    End Sub
    Public Sub NextSong()

        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf NextSong))
        Else
            If CurrentDisplay = DisplayPanels.Spotify Then
                CarPCfrm.SpotifyPanel.NextSong()
            Else
                If CarPCfrm.PlaylistPanel.lbxPlaylist.Items.Count = (RandomHistoryCount + 1) Then
                    'reset random list if complete playthrough
                    ReDim RandomHistory(0)
                    RandomHistoryCount = -1
                End If

                If Not CarPCfrm.PlaylistPanel.lbxPlaylist.Items.Count = 0 And Not (CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex + 1 = CarPCfrm.PlaylistPanel.lbxPlaylist.Items.Count) And MusicRandom = False Then
                    'Standard playmode
                    CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex += 1
                ElseIf Not CarPCfrm.PlaylistPanel.lbxPlaylist.Items.Count = 0 And MusicRandom = True Then
                    'Random Playlist
                    Dim NextIndex As Integer = -1
                    '   Randomize() function is run at form load to initiate the random number generator.
                    'If not run the random number follows a predictable sequence.
                    NextIndex = Math.Floor(Rnd() * (CarPCfrm.PlaylistPanel.lbxPlaylist.Items.Count - 1))
                    RandomHistoryCount += 1
                    ReDim Preserve RandomHistory(RandomHistoryCount)
                    RandomHistory(RandomHistoryCount) = NextIndex
                    CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex = NextIndex
                End If
            End If
        End If


    End Sub

    Public Sub PreviousSong()
        If CurrentDisplay = DisplayPanels.Spotify Then
            CarPCfrm.SpotifyPanel.PreviousSong()
        Else
            If Not CarPCfrm.PlaylistPanel.lbxPlaylist.Items.Count = 0 And Not CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex <= 0 Then
                If MusicRandom = False Then
                    CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex -= 1
                Else
                    'back through random
                    If Not RandomHistoryCount <= 0 Then
                        RandomHistoryCount -= 1
                        ReDim Preserve RandomHistory(RandomHistoryCount)
                        PlayMusic(MusicArr(RandomHistory(RandomHistoryCount)))
                        CarPCfrm.PlaylistPanel.lbxPlaylist.SelectedIndex = RandomHistory(RandomHistoryCount)
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub tmrMediaFinished_Tick(sender As Object, e As EventArgs) Handles tmrMediaFinished.Tick
        tmrMediaFinished.Enabled = False
        NextSong()
    End Sub



    Private Sub Music_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        UpdatePlayerImageSize()

    End Sub
    Private Sub UpdatePlayerImageSize()
        WMPlayer.Height = Me.Height
        pbxMusicImage.Height = WMPlayer.Height
        If VideoMode = True Or NoPicture = True Then
            WMPlayer.Width = Me.Width
            pbxMusicImage.Visible = False
        Else
            WMPlayer.Width = Math.Round(Me.Width / 2)
            pbxMusicImage.Width = Math.Round(Me.Width / 2)
            pbxMusicImage.Location = New Point(WMPlayer.Width + 3, 3)
            pbxMusicImage.Visible = True
        End If
    End Sub


End Class
