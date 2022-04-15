Public Class MusicLibrary


    Public SelectedLibrary As LibrarySelected = LibrarySelected.Playlists
    Enum LibrarySelected
        FileBrowser
        Playlists
        Search
    End Enum


    Private Sub btnLibFileBrowse_Click(sender As Object, e As EventArgs) Handles btnLibFileBrowse.Click
        SelectedLibrary = LibrarySelected.FileBrowser
        CarPCfrm.SetMusicLibraryType(SelectedLibrary)
    End Sub

    Private Sub btnClearPlaylist_Click(sender As Object, e As EventArgs) Handles btnClearPlaylist.Click
        CarPCfrm.PlaylistPanel.ResetPlaylist()
    End Sub

    Private Sub btnPlaylists_Click(sender As Object, e As EventArgs) Handles btnPlaylists.Click
        SelectedLibrary = LibrarySelected.Playlists
        CarPCfrm.SetMusicLibraryType(SelectedLibrary)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SelectedLibrary = LibrarySelected.Search
        CarPCfrm.SetMusicLibraryType(SelectedLibrary)
    End Sub



End Class
