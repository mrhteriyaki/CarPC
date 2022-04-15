Public Class PlaylistLibrary

    Private Sub PlaylistLibrary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GeneratePlaylistButtons()
    End Sub
    Private Sub GeneratePlaylistButtons()
        Dim ButtonWidth As Integer = 200
        Dim ButtonHeight As Integer = 59
        Dim ButtonColumnItem As Integer = 15

        Dim ButtonX As Integer = 7
        Dim ButtonY As Integer = 20
        Dim ButtonCount As Integer
        If My.Computer.FileSystem.DirectoryExists(PlaylistsDirectory) Then

            'Generate first button - Favourites
            Dim NewPlayListButton As New Button
            NewPlayListButton.Name = "Favourites"
            NewPlayListButton.Width = ButtonWidth
            NewPlayListButton.Height = ButtonHeight
            NewPlayListButton.Location = New Point(ButtonX, ButtonY)
            NewPlayListButton.Text = "Favourites"
            NewPlayListButton.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
            AddHandler NewPlayListButton.Click, AddressOf PlayListButton_Click
            gbxPlayLists.Controls.Add(NewPlayListButton)
            ButtonY += ButtonHeight
            ButtonCount += 1
            If ButtonCount = ButtonColumnItem Then
                ButtonX += ButtonWidth
                ButtonY = 20
                ButtonCount = 0
            End If


            'Generate Playlist buttons

            For Each Playlist In My.Computer.FileSystem.GetFiles(PlaylistsDirectory)
                Playlist = Playlist.Replace(".playlist", "").Replace(PlaylistsDirectory, Nothing) 'Remove file extension and directory
                If Not Playlist.ToLower = "favourites" Then
                    NewPlayListButton = New Button
                    NewPlayListButton.Name = Playlist
                    NewPlayListButton.Width = ButtonWidth
                    NewPlayListButton.Height = ButtonHeight
                    NewPlayListButton.Location = New Point(ButtonX, ButtonY)
                    NewPlayListButton.Text = Playlist
                    NewPlayListButton.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
                    AddHandler NewPlayListButton.Click, AddressOf PlayListButton_Click
                    gbxPlayLists.Controls.Add(NewPlayListButton)
                    ButtonY += ButtonHeight
                    ButtonCount += 1
                    If ButtonCount = ButtonColumnItem Then
                        ButtonX += ButtonWidth
                        ButtonY = 20
                        ButtonCount = 0
                    End If
                End If
            Next


        End If


    End Sub
    Private Sub PlayListButton_Click(ByVal sender As System.Object, e As System.EventArgs)
        Dim ButtonPressed As String = sender.ToString.Replace("System.Windows.Forms.Button, Text: ", "") & ".playlist" 'append file extension
        'Reverse order of favourites playlist, all others normal
        If ButtonPressed.Contains("Favourites") Then
            Dim ReverseList(0) As String
            Dim ReverseListCount As Integer = -1
            For Each Line In IO.File.ReadAllLines(PlaylistsDirectory & ButtonPressed)
                If Not Line.Contains("#EXT") Then
                    ReverseListCount += 1
                    ReDim Preserve ReverseList(ReverseListCount)
                    ReverseList(ReverseListCount) = Line
                End If
            Next
            Do Until ReverseListCount = -1
                CarPCfrm.PlaylistPanel.AddMusictoPlaylist(MusicDirectory & ReverseList(ReverseListCount))
                ReverseListCount -= 1
            Loop
        Else
            For Each Line In IO.File.ReadAllLines(PlaylistsDirectory & ButtonPressed)
                If Not Line.Contains("#EXT") And Not Line = "" Then
                    CarPCfrm.PlaylistPanel.AddMusictoPlaylist(MusicDirectory & Line)
                End If
            Next
        End If

    End Sub

    Private Sub PlaylistLibrary_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        gbxPlayLists.Height = Me.Height - 3
        gbxPlayLists.Width = Me.Width - 3
    End Sub

   
    Private Sub gbxPlayLists_Enter(sender As Object, e As EventArgs) Handles gbxPlayLists.Enter

    End Sub
End Class
