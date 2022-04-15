Public Class SearchControl



    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Check blank search
        If Not txtSearchQuery.Text.Replace(" ", "") = "" Then
            btnSearch.Enabled = False
            btnSearch.Text = "Searching"
            lbxSearch.Items.Clear()
            SearchForMusic(txtSearchQuery.Text)
            btnSearch.Text = "Search"
            btnSearch.Enabled = True
        End If

    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtSearchQuery.Text = ""
        lbxSearch.Items.Clear()
    End Sub


    Private Sub btnAddSelected_Click(sender As Object, e As EventArgs) Handles btnAddSelected.Click
        If lbxSearch.SelectedIndex > -1 Then
            CarPCfrm.PlaylistPanel.AddMusictoPlaylist(SearchResults(lbxSearch.SelectedIndex))
        End If

    End Sub

    Private Sub btnAddtoPlaylist_Click(sender As Object, e As EventArgs) Handles btnAddtoPlaylist.Click
        For Each File In SearchResults
            CarPCfrm.PlaylistPanel.AddMusictoPlaylist(File)
        Next
    End Sub


    Private Sub btnKeyboard_Click(sender As Object, e As EventArgs) Handles btnKeyboard.Click

        CarPCfrm.KeyboardShowHide()
        txtSearchQuery.Focus()
    End Sub

End Class
