Public Class Playlist

    Dim TopIndex As Integer = 0

    Dim MusicAutoPlay As Boolean = True

    Public Sub setPlaylistIndex(ByVal index As Integer, ByVal AutoPlayMusic As Boolean)
        If AutoPlayMusic = True Then
            MusicAutoPlay = True
        Else
            MusicAutoPlay = False
        End If
        lbxPlaylist.SelectedIndex = index
        MusicAutoPlay = True 'reset auto-play back to on, after song is set.
    End Sub


    Private Sub lbxPlaylist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxPlaylist.SelectedIndexChanged
        If Not lbxPlaylist.SelectedIndex = -1 Then
            TopIndex = lbxPlaylist.SelectedIndex
            If MusicAutoPlay = True Then
                'Play selected item
                CarPCfrm.MusicPanel.PlayMusic(MusicArr(lbxPlaylist.SelectedIndex))
                CarPCfrm.MediaControlPanel.btnFav.Enabled = True
            End If
        End If
    End Sub


    Private Sub btnUpPlaylist_Click(sender As Object, e As EventArgs)
        'btnUpPlaylist.Enabled = False
        TopIndex -= 10
        If TopIndex < 0 Then
            TopIndex = 0
        End If
        lbxPlaylist.TopIndex = TopIndex
        tmrButtonPressDelay.Enabled = True
    End Sub


    Private Sub btnDownPlaylist_Click(sender As Object, e As EventArgs)
        'btnDownPlaylist.Enabled = False
        TopIndex += 10

        If TopIndex > lbxPlaylist.Items.Count Then
            TopIndex = lbxPlaylist.Items.Count - 10
        End If
        lbxPlaylist.TopIndex = TopIndex
        tmrButtonPressDelay.Enabled = True
    End Sub

    

    Private Sub Playlist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbxPlaylist.ScrollAlwaysVisible = False

        lbxPlaylist.Width = Me.Width - 70
        lbxPlaylist.Height = Me.Height

        'btnUpPlaylist.Location = New Point(lbxPlaylist.Location.X + lbxPlaylist.Width, 0)
        'btnDownPlaylist.Location = New Point(lbxPlaylist.Location.X + lbxPlaylist.Width, lbxPlaylist.Location.Y + lbxPlaylist.Height - 70)



    End Sub

    Public Sub LoadStartupPlaylist()
        'Add list of previous playing files into playlist
        If My.Computer.FileSystem.FileExists(RunLocation & "\Playlist.carpc") = True Then
            For Each Line In IO.File.ReadAllLines(RunLocation & "\Playlist.carpc")
                AddMusictoPlaylist(Line)
            Next
        End If

    End Sub

    Public Sub AddMusictoPlaylist(ByVal FileName As String)
        'Validate media file
        If CarPCfrm.CheckValidMediaFile(FileName) = True Then
            'Increase music array size
            MusicCount += 1
            ReDim Preserve MusicArr(MusicCount)
            'add filename to music array
            MusicArr(MusicCount) = FileName
            'get music title name
            Dim MusicTitle As String = getFileName(FileName)
            For Each FT In MediaFileTypes
                MusicTitle = MusicTitle.Replace("." & FT, Nothing)
            Next

            'ID3 disabled as requires access to each file when loading, causing massive delay.
            'Future re-integration if filedata is cached with search engine load.
            'Use id3 title if possible.
            'Try
            'Dim MP3File As TagLib.File = TagLib.File.Create(FileName)
            ' If Not MP3File.Tag.Title.Replace(" ", "") = "" Then
            'MusicTitle = MP3File.Tag.AlbumArtists(0) & " - " & MP3File.Tag.Title
            ' End If

            '  Catch ex As Exception
            '
            ' End Try

            'add file to playlist
            CarPCfrm.PlaylistPanel.lbxPlaylist.Items.Add(MusicTitle)
        End If

    End Sub

    Public Sub ResetPlaylist()
        MusicCount = -1
        ReDim MusicArr(0)
        CarPCfrm.PlaylistPanel.lbxPlaylist.Items.Clear()
        CarPCfrm.MusicPanel.WMPlayer.URL = Nothing
        ReDim RandomHistory(0)
        RandomHistoryCount = -1
        CarPCfrm.PlaylistPanel.TopIndex = 0
        CarPCfrm.MusicFileBrowser.btnAddFolder.Enabled = True

    End Sub




    Private Sub Playlist_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        '70, 90 offset for button size.
        lbxPlaylist.Width = Me.Width
        lbxPlaylist.Height = Me.Height
        'btnUpPlaylist.Location = New Point(lbxPlaylist.Location.X + lbxPlaylist.Width, 0)
        'btnDownPlaylist.Location = New Point(lbxPlaylist.Location.X + lbxPlaylist.Width, lbxPlaylist.Location.Y + lbxPlaylist.Height - 70)
    End Sub

    Private Sub tmrButtonPressDelay_Tick(sender As Object, e As EventArgs) Handles tmrButtonPressDelay.Tick
        'btnDownPlaylist.Enabled = True
        'btnUpPlaylist.Enabled = True
        tmrButtonPressDelay.Enabled = False
    End Sub

  
End Class
