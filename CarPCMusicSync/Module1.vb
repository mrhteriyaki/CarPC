Imports System.Data.SqlClient

Module Module1
    Dim MusicFiles As New List(Of MusicItem)
    Dim Conn As New SqlConnection("Data Source=192.168.1.250;Initial Catalog=Media_Server; user=music_sql; password=music_sql")
    Dim MusicDir As String = ""
    Dim extensions As String() = {"mp3", "flac", "wma", "xm", "mod", "wav", "v2m", "it", "s3m", "mid", "mp4"}
    Dim SQLQuery As SqlCommand


    'used for rescan / cleanup
    Dim files As New List(Of String)

    Sub Main(ByVal args() As String)
        If Not args.Count = 1 Then
            Console.WriteLine("No arguments. exiting")
            Exit Sub
        End If

        'Read Config File
        For Each config_line In IO.File.ReadAllLines("config.ini")
            If config_line.StartsWith("music_dir=") Then
                MusicDir = config_line.Substring(10)
            End If
        Next


        If args(0) = "rescan" Then
            Rescan()
        ElseIf args(0) = "sync" Then
            SyncMusic()
        ElseIf args(0) = "cleanup" Then
            LoadFileList()
            Cleanup()
        End If





    End Sub

    Private Sub LoadFileList()
        Console.Write("Getting list of files")

        For Each file In Delimon.Win32.IO.Directory.GetFiles(MusicDir, "*", Delimon.Win32.IO.SearchOption.AllDirectories)
            For Each ext In extensions
                If file.ToLower.EndsWith(ext) Then
                    files.Add(file) 'Add supported file type to list.
                End If
            Next
        Next
        Console.WriteLine(" - Complete")
        'get array of database.
        Console.Write("Downloading database")
        Conn.Open()
        SQLQuery = New SqlCommand("select music_id,music_filename from tblMusic", Conn)
        Dim SQLOutput As SqlDataReader = SQLQuery.ExecuteReader()
        While SQLOutput.Read
            'Each entry returned is a song not on the car pc.
            Dim tmp_musicitem As New MusicItem

            tmp_musicitem.id = SQLOutput(0).ToString() 'ID number' required for return update query.
            tmp_musicitem.filename = SQLOutput(1).ToString() 'Filename
            MusicFiles.Add(tmp_musicitem)
        End While
        Conn.Close()
        Console.WriteLine(" - Complete")

    End Sub

    Private Sub Rescan()
        Console.Write("Reseting all files in database")
        'Reset all database entries.
        Conn.Open()
        Dim SQLQuery As New SqlCommand("update tblMusic SET transfered_to_car=0", Conn)
        SQLQuery.ExecuteReader()
        Conn.Close()
        Console.WriteLine(" - Complete")


        'Update database with existing files.
        'get array of existing files.


        LoadFileList()








        Console.WriteLine("Comparing Files to Database : " & NOW())


        For Each music_item In MusicFiles
            Dim FileFound As Boolean = False
            'Check item against files array
            For Each file In files
                If music_item.filename.ToLower = file.Substring(MusicDir.Length).ToLower Then
                    FileFound = True
                    Exit For
                End If
            Next

            If FileFound = True Then
                'Console.WriteLine("File Exists " & music_item.filename)
                'Update database.

                RunSQLQuery("UPDATE tblMusic SET transfered_to_car=1 WHERE music_id=" & music_item.id)
            Else
                Console.WriteLine("file missing " & music_item.id & " - " & music_item.filename)
            End If

        Next



        Cleanup()


        Console.WriteLine("Comparing files to database - Complete : " & NOW())



    End Sub

    Private Sub Cleanup()
        'check for deleted files by checking existing files against database.
        Console.WriteLine("Starting removal of files not listed in the database.")
        For Each file In files
            Dim file_not_found As Boolean = True
            For Each music_item In MusicFiles
                If music_item.filename.ToLower = file.Substring(MusicDir.Length).ToLower Then
                    file_not_found = False
                    Exit For
                End If

            Next

            If file_not_found = True Then
                Console.WriteLine("File found that is not in database:" & file)
                Console.Write("Removing File...")
                Delimon.Win32.IO.File.Delete(file)
                Console.WriteLine("Removed")

            End If


        Next
        Console.WriteLine("Removal Finished")

    End Sub

    Function NOW() As String
        Return DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss.fff")

    End Function

    Private Sub SyncMusic()
        If My.Computer.Network.Ping("192.168.1.250") = False Then
            Console.WriteLine("Server unavailable for sync")
            Exit Sub
        End If
        Console.WriteLine("Sync Server online, sending database query")

        Dim SQLQueryString As String = "select music_id,music_filename from tblMusic where transfered_to_car = 0 or transfered_to_car is null"
        Conn.Open()
        SQLQuery = New SqlCommand(SQLQueryString, Conn)
        Dim SQLOutput As SqlDataReader = SQLQuery.ExecuteReader()

        While SQLOutput.Read
            'Each entry returned is a song not on the car pc.
            Dim tmp_musicitem As New MusicItem

            tmp_musicitem.id = SQLOutput(0).ToString() 'ID number' required for return update query.
            tmp_musicitem.filename = SQLOutput(1).ToString() 'Filename
            MusicFiles.Add(tmp_musicitem)
        End While
        Conn.Close()
        Console.WriteLine("Starting file transfer")

        'Process File Transfers.
        For Each MusicFile In MusicFiles
            Console.Write("Starting transfer of:")
            Console.Write(MusicFile.filename)
            'Create directories for target location.
            Dim MusicTargetPath As String = MusicFile.filename.Substring(0, MusicFile.filename.LastIndexOf("\"))
            If Not MusicTargetPath = "" Then
                CreateSubDirectories(MusicDir & MusicTargetPath)
            End If

            'copy file
            If Delimon.Win32.IO.File.Exists(MusicDir & MusicFile.filename) Then
                Console.Write(" - File already exists. Removing existing file...")
                Delimon.Win32.IO.File.Delete(MusicDir & MusicFile.filename)
            End If

            Console.WriteLine(" - Coppied")
                Delimon.Win32.IO.File.Copy("\\192.168.1.221\Music" & MusicFile.filename, MusicDir & MusicFile.filename, False)

                'update database to show file was coppied.
                Conn.Open()
                SQLQueryString = "UPDATE tblMusic SET transfered_to_car=1 WHERE music_id=" & MusicFile.id
                SQLQuery = New SqlCommand(SQLQueryString, Conn)
                SQLQuery.ExecuteReader()
                Conn.Close()

        Next
        Console.WriteLine("File transfer complete, starting file cleanup")

        'File removal from move/delete.
        SQLQueryString = "select * from tblRemoveFileList"
        Conn.Open()
        SQLQuery = New SqlCommand(SQLQueryString, Conn)
        SQLOutput = SQLQuery.ExecuteReader()
        Dim removal_list As New List(Of MusicItem)
        While SQLOutput.Read
            Dim tmp_mi As New MusicItem
            tmp_mi.id = SQLOutput(0).ToString
            tmp_mi.filename = SQLOutput(1).ToString
            removal_list.Add(tmp_mi)
        End While
        Conn.Close()

        For Each removal In removal_list
            If Delimon.Win32.IO.File.Exists(MusicDir & removal.filename) Then
                Delimon.Win32.IO.File.Delete(MusicDir & removal.filename)
                SQLQueryString = "delete from tblRemoveFileList where cleanup_ip=" & removal.id
                Conn.Open()
                SQLQuery = New SqlCommand(SQLQueryString, Conn)
                SQLQuery.ExecuteReader()
                Conn.Close()
            Else
                Console.WriteLine("file marked for removal does not exist:" & removal.filename)
            End If


        Next


    End Sub

    Private Sub RunSQLQuery(ByVal sql_query As String)
        Conn.Open()
        SQLQuery = New SqlCommand(sql_query, Conn)
        Try
            SQLQuery.ExecuteReader()
        Catch ex As Exception
            MsgBox("Failed query: " & sql_query & Environment.NewLine & ex.ToString)
        End Try


        Conn.Close()

    End Sub

    Private Sub CleanupEmptyFolders()
        Dim tmp_files_list() As String = Delimon.Win32.IO.Directory.GetFiles(MusicDir, "*", Delimon.Win32.IO.SearchOption.AllDirectories)
        Dim tmp_folders_list() As String = Delimon.Win32.IO.Directory.GetDirectories(MusicDir, "*", Delimon.Win32.IO.SearchOption.AllDirectories)
        Dim blank_folders_list As New List(Of String)

        For Each fldr In tmp_folders_list
            Dim folder_blank As Boolean = True
            For Each file In tmp_files_list
                If file.Contains(fldr) Then
                    folder_blank = False
                    Exit For
                End If
            Next
            If folder_blank = True Then
                blank_folders_list.Add(fldr)
            End If

        Next

        'bulk delete all blank folders.
        For Each fldr In blank_folders_list
            If Delimon.Win32.IO.Directory.Exists(fldr) Then
                Delimon.Win32.IO.Directory.Delete(fldr, True)
            End If
        Next


    End Sub


    Private Sub CreateSubDirectories(ByVal path As String)
        Dim append_path As String = ""
        For Each sub_path In path.Split("\")
            append_path = append_path & sub_path & "\"
            If Delimon.Win32.IO.Directory.Exists(append_path) = False Then
                Delimon.Win32.IO.Directory.CreateDirectory(append_path)
            End If
        Next
    End Sub


End Module

Public Class MusicItem
    Public filename As String
    Public id As String

End Class
