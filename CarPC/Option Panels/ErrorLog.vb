Public Class ErrorLog

    'Dim PeformanceTimer As System.Timers.Timer



    Private Sub tmrErrorLog_Tick(sender As Object, e As EventArgs) Handles tmrErroLog.Tick
        Dim DebugString As String = ""
        Dim DebugLineCount As Integer = 20

        If ErrorLogQueue.Count < DebugLineCount And ErrorLogQueue.Count > 0 Then
            'If less than 20 items are in the list.
            'Display last items first.
            '-1 is used on .Item as .count is not zerobased, array is.
            Dim ListCount As Integer = ErrorLogQueue.Count
            Do Until ListCount = 0
                '''''''''  DebugString &= CarPCfrm.ErrorLogQueue.Item(ListCount - 1) & Environment.NewLine
                ListCount -= 1
            Loop
        ElseIf ErrorLogQueue.Count >= DebugLineCount Then
            'Only display lattest 20 items.
            Dim Counter As Integer = ErrorLogQueue.Count - 1

            'Loop until counter is less than 20 items lower than list count.
            Do Until Counter <= (ErrorLogQueue.Count - DebugLineCount)
                ''''''''''''  DebugString &= CarPCfrm.ErrorLogQueue.Item(Counter - 1) & Environment.NewLine
                Counter -= 1
            Loop
        End If


        txtDebugLog.Text = DebugString & Environment.NewLine & "Updated:" & DateTime.Now.ToString

        txtDebugLog.SelectionStart = txtDebugLog.Text.Length
        txtDebugLog.ScrollToCaret()
    End Sub

 
    Private Sub btnDebugModeOn_Click(sender As Object, e As EventArgs) Handles btnDebugModeOn.Click
        SetDebugMode(True)
    End Sub
    Private Sub btnDebugModeOff_Click(sender As Object, e As EventArgs) Handles btnDebugModeOff.Click
        SetDebugMode(False)
    End Sub
    Private Sub SetDebugMode(ByVal ModeState As Boolean)
        Dim ConfigFile() As String = IO.File.ReadAllLines("config.ini")
        If My.Computer.FileSystem.FileExists("config.ini.bak") = True Then
            MsgBox("Backup exists - please cleanup manually.")
        Else
            My.Computer.FileSystem.RenameFile("config.ini", "config.ini.bak")
            Dim NewConfigFile As IO.StreamWriter = New IO.StreamWriter("config.ini")
            For Each line In ConfigFile
                If line.Contains("debug=") Then
                    If ModeState = True Then
                        NewConfigFile.WriteLine("debug=true")
                    ElseIf ModeState = False Then
                        NewConfigFile.WriteLine("debug=false")
                    End If
                Else
                    NewConfigFile.WriteLine(line)
                End If
            Next
            NewConfigFile.Close()
            My.Computer.FileSystem.DeleteFile("config.ini.bak")
        End If
    End Sub

   
   
    Private Sub ErrorLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    
End Class
