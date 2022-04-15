Module Logging
    Public DebugingEnabled As Boolean = False
    Public ErrorLogQueue As New Queue
    Public DebugCANList As New List(Of String)
    Public Sub StartLoggers()
        Dim ErrorLogThread As New Threading.Thread(AddressOf ErrorLogWriteProcess)
        ErrorLogThread.Start()

        Dim JourneyLogThread As New Threading.Thread(AddressOf WriteJourneyLog)
        JourneyLogThread.Start()

        Dim CanLoggerThread As New Threading.Thread(AddressOf WriteCANDebug)
        CanLoggerThread.Start()
    End Sub

    Dim RunJourneyLogger As Boolean = False

    Public Sub WriteCANDebug()
        If My.Computer.FileSystem.DirectoryExists(CarDataPath) = False Then
            My.Computer.FileSystem.CreateDirectory(CarDataPath)
        End If

        If DebugingEnabled = True Then
            Dim CANDebugLogPath As String = (CarDataPath & "CANDebug " & DateTime.Now.ToString.Replace("/", "-").Replace(":", "-") & ".txt").Replace("\\", "\")
            Dim NewCANDebugFile As IO.StreamWriter = IO.File.CreateText(CANDebugLogPath)
            Do Until ShuttingDown = True
                If DebugCANList.Count > 0 Then
                    Dim CANCount As Integer = DebugCANList.Count
                    While CANCount > 0
                        NewCANDebugFile.WriteLine(DebugCANList.Item(CANCount - 1))
                        CANCount -= 1
                    End While
                    Threading.Thread.Sleep(10000)
                End If
            Loop
            NewCANDebugFile.Close()
        End If
    End Sub




    Private Sub WriteJourneyLog()
        Dim JourneyFileDirectory As String = CarDataPath & "\Journeys"
        If My.Computer.FileSystem.DirectoryExists(JourneyFileDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(JourneyFileDirectory)
        End If
        Dim JourneyFile As IO.StreamWriter = IO.File.CreateText(JourneyFileDirectory & "\Journey " & DateTime.Now.ToString.Replace("/", "-").Replace(":", "-") & ".txt")
        JourneyFile.WriteLine("Time;GPS;Speed;RPM;Throttle")


        Try
            'Log journey, time, location, speed, rpm and throttle.
            Do Until ShuttingDown = True
                Dim JourneyEvent As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & ";" &
                   GPSLatitude & "," & GPSLongitude & ";" & Speed & ";" & RPM & ";" & Throttle
                Threading.Thread.Sleep(1000)
                JourneyFile.WriteLine(JourneyEvent)
            Loop
            JourneyFile.Close()
        Catch ex As Exception
            ' If DebugingEnabled = True Then
            ErrorLogQueue.Enqueue("Error with Journey File:" & ex.ToString)
            ' End If
        End Try
    End Sub





    Private Sub ErrorLogWriteProcess()
        Dim DebugLogPath As String = CarDataPath & "\Errors.txt"
        Do Until ShuttingDown = True
            'Write Debug Log
            If ErrorLogQueue.Count > 0 Then
                Dim tmpdatalist As New List(Of String)
                If My.Computer.FileSystem.FileExists(DebugLogPath) Then
                    For Each line In IO.File.ReadAllLines(DebugLogPath)
                        tmpdatalist.Add(line)
                    Next
                    'delete existing old file
                    If My.Computer.FileSystem.FileExists(DebugLogPath & ".old") Then
                        My.Computer.FileSystem.DeleteFile(DebugLogPath & ".old")
                    End If
                    'rename current file to old
                    My.Computer.FileSystem.RenameFile(DebugLogPath, "Errors.txt.old")
                End If

                'write error log
                Dim ErrorLogFile As IO.StreamWriter = IO.File.CreateText(DebugLogPath)

                For Each line In tmpdatalist
                    ErrorLogFile.WriteLine(line)
                Next
                Do Until ErrorLogQueue.Count = 0
                    ErrorLogFile.WriteLine(ErrorLogQueue.Dequeue)
                Loop

                ErrorLogFile.Close()
            End If
            Threading.Thread.Sleep(2000)
        Loop

    End Sub





End Module
