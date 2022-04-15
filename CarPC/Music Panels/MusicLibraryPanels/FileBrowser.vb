Public Class FileBrowser


    Private Sub btnAddFile_Click(sender As Object, e As EventArgs) Handles btnAddFile.Click
        If lbxDownFolder.SelectedIndex > -1 Then
            CarPCfrm.PlaylistPanel.AddMusictoPlaylist(CurrentDirectory & lbxDownFolder.SelectedItem.ToString)
        End If
    End Sub

    Public Sub ListFiles()
        'Get new directory contents
        lbxDownFolder.Items.Clear()
        For Each File In Delimon.Win32.IO.Directory.GetFiles(CurrentDirectory, "*")
            If CarPCfrm.CheckValidMediaFile(File) = True Then
                Dim MusicFile As String = File.Replace(CurrentDirectory, Nothing)
                lbxDownFolder.Items.Add(MusicFile)
            End If
        Next


    End Sub
    Private Sub btnUpDirectory_Click(sender As Object, e As EventArgs) Handles btnUpDirectory.Click
        If Not CurrentDirectory = MusicDirectory Then
            If CurrentDirectory.EndsWith("\") Then
                CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.Length - 1)
            End If
            CurrentDirectory = getParentFolder(CurrentDirectory) & "\"
            lbxCurrentFolder.Items.Clear()
            For Each Folder In Delimon.Win32.IO.Directory.GetDirectories(CurrentDirectory)
                Dim NewFolderItem As String = Folder.Replace(CurrentDirectory, Nothing)
                If Not NewFolderItem = "Playlists" Then
                    lbxCurrentFolder.Items.Add(NewFolderItem)
                End If
            Next
            ListFiles()
        End If
        If CurrentDirectory = MusicDirectory Then
            btnUpDirectory.Enabled = False
        End If
    End Sub
    Private Sub btnAddFolder_Click(sender As Object, e As EventArgs) Handles btnAddFolder.Click
        btnAddFolder.Enabled = False
       
        Try
            If CurrentDirectory = MusicDirectory And lbxCurrentFolder.SelectedIndex = -1 Then

                'Add all music files (root), use search index for quicker add if search index complete.
                If SearchIndexState = True Then
                    For Each file In SearchList
                        CarPCfrm.PlaylistPanel.AddMusictoPlaylist(file)
                    Next
                Else
                    For Each file In Delimon.Win32.IO.Directory.GetFiles(MusicDirectory, "*", Delimon.Win32.IO.SearchOption.AllDirectories)
                        CarPCfrm.PlaylistPanel.AddMusictoPlaylist(file)
                    Next
                End If

            Else

                If lbxCurrentFolder.SelectedIndex = -1 Then
                    'if no folder selected use current folder
                    AddFolderofMusic(CurrentDirectory)
                Else
                    'add items in selected folder
                    AddFolderofMusic(CurrentDirectory & lbxCurrentFolder.SelectedItem & "\")
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'btnAddFolder.Enabled = True
    End Sub
    Private Sub AddFolderofMusic(ByVal Folder As String)

        For Each File In Delimon.Win32.IO.Directory.GetFiles(Folder, "*", Delimon.Win32.IO.SearchOption.AllDirectories)
            If CarPCfrm.CheckValidMediaFile(File) = True Then
                CarPCfrm.PlaylistPanel.AddMusictoPlaylist(File)
            End If
        Next


    End Sub

    Private Sub btnDownFolder_Click(sender As Object, e As EventArgs) Handles btnDownFolder.Click
        If Not lbxCurrentFolder.SelectedIndex = -1 Then
            CurrentDirectory = CurrentDirectory & lbxCurrentFolder.SelectedItem & "\"
            lbxCurrentFolder.Items.Clear()
            For Each Folder In Delimon.Win32.IO.Directory.GetDirectories(CurrentDirectory)
                Dim NewFolderItem As String = Folder.Replace(CurrentDirectory, Nothing)
                If Not NewFolderItem = "Playlists" Then
                    lbxCurrentFolder.Items.Add(NewFolderItem)
                End If
            Next
            ListFiles()
        End If
        If Not CurrentDirectory = MusicDirectory Then
            btnUpDirectory.Enabled = True
        End If

    End Sub




    Private Sub btnFolderlistUp_Click(sender As Object, e As EventArgs)
        If Not lbxCurrentFolder.SelectedIndex <= 0 Then
            lbxCurrentFolder.SelectedIndex -= 1
        End If
    End Sub


    Private Sub btnFolderlistDown_Click(sender As Object, e As EventArgs)
        If (lbxCurrentFolder.SelectedIndex + 1) < lbxCurrentFolder.Items.Count Then
            lbxCurrentFolder.SelectedIndex += 1
        End If
    End Sub

    Private Sub btnFileListUp_Click(sender As Object, e As EventArgs)
        If Not lbxDownFolder.SelectedIndex <= 0 Then
            lbxDownFolder.SelectedIndex -= 1
        End If
    End Sub

    Private Sub btnFileListDown_Click(sender As Object, e As EventArgs)
        If (lbxDownFolder.SelectedIndex + 1) < lbxDownFolder.Items.Count Then
            lbxDownFolder.SelectedIndex += 1
        End If
    End Sub


  




    Function getParentFolder(ByVal SubFolder As String) As String
        Dim Index As Integer = SubFolder.LastIndexOf("\")
        Return SubFolder.Substring(0, Index)
    End Function









    Private Sub lbxDownFolder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxDownFolder.SelectedIndexChanged
        Dim indexprev As Integer = lbxDownFolder.SelectedIndex
        lbxCurrentFolder.SelectedIndex = -1
        lbxDownFolder.SelectedIndex = indexprev
        btnAddFolder.Enabled = True
    End Sub

    Private Sub lbxCurrentFolder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxCurrentFolder.SelectedIndexChanged
        Dim indexprev As Integer = lbxCurrentFolder.SelectedIndex
        lbxDownFolder.SelectedIndex = -1
        lbxCurrentFolder.SelectedIndex = indexprev
        btnAddFolder.Enabled = True
    End Sub

   
End Class
