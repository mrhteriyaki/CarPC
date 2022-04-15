Module Search
    Public SearchList As New List(Of String)
    Public SearchResults As List(Of String)
    Public SearchIndexState As Boolean = False

    Public Sub SearchIndexThread()
        If My.Computer.FileSystem.DirectoryExists(MusicDirectory) = True Then
            For Each File In Delimon.Win32.IO.Directory.GetFiles(MusicDirectory, "*", Delimon.Win32.IO.SearchOption.AllDirectories)
                If CarPCfrm.CheckValidMediaFile(File) = True Then
                    SearchList.Add(File)
                End If
                If ShuttingDown = True Then
                    Exit For
                End If
            Next
            InvokeControl(carpc_form_variable.MusicLibraryPanel.btnSearch, Sub(x) x.Enabled = True)



        End If


    End Sub


    Public Sub SearchForMusic(ByVal SearchString As String)
        SearchResults = New List(Of String)
        For Each File In SearchList
            If File.ToLower.Contains(SearchString.ToLower) Then
                Dim FileInfo As New Delimon.Win32.IO.FileInfo(File)
                For Each FT In MediaFileTypes
                    If FileInfo.Extension = "." & FT Then
                        SearchResults.Add(FileInfo.FullName)
                        InvokeControl(CarPCfrm.SearchPanel.lbxSearch, Sub(x) x.Items.Add(FileInfo.Name))
                    End If
                Next
            End If
        Next

        'InvokeControl(CarPCfrm.SearchPanel.btnSearch, Sub(x) x.Text = "Search")
        'InvokeControl(CarPCfrm.SearchPanel.btnSearch, Sub(x) x.Enabled = True)
    End Sub
End Module
