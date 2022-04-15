Module BadSmellZone




    'Bad Smell Zone
    Dim BadSmellLat(0) As Double
    Dim BadSmellLong(0) As Double
    Dim BadSmellCount As Integer = -1
    Dim ZoneRange As Double = 0.02
    Dim BadSmellClosedCabin As Boolean = False



    Public Sub LoadBadSmellLocations()
        'Load list of locations
        For Each GPSLocation In IO.File.ReadAllLines(RunLocation & "\BadSmellLocations.txt")
            If Not GPSLocation = "" Then
                BadSmellCount += 1
                ReDim Preserve BadSmellLat(BadSmellCount)
                BadSmellLat(BadSmellCount) = GPSLocation.Split(",")(0)
                ReDim Preserve BadSmellLong(BadSmellCount)
                BadSmellLong(BadSmellCount) = GPSLocation.Split(",")(1)
            End If
        Next
    End Sub
    Public Sub BadSmellLoop()
        Do Until ShuttingDown = True
            Dim Counter As Integer = 0
            Do Until Counter = 200
                Threading.Thread.Sleep(10)
                Counter += 1
            Loop
            If Not GPSLongitude = 0 And Not GPSLatitude = 0 Then
                'No GPS Signal

                Dim Count As Integer = -1
                Dim NoZoneDetectTick As Boolean = True
                Do Until Count = BadSmellCount
                    Count += 1

                    'Compare current co-ordinates to +-0.02 range of bad smell co-ords, must meet lat AND long ranges.
                    Dim BSLatLB As Double = BadSmellLat(Count) - ZoneRange
                    Dim BSLatUB As Double = BadSmellLat(Count) + ZoneRange
                    Dim BSLongLB As Double = BadSmellLong(Count) - ZoneRange
                    Dim BSLongUB As Double = BadSmellLong(Count) + ZoneRange

                    If (GPSLatitude > BSLatLB And GPSLatitude < BSLatUB) And (GPSLongitude > BSLongLB And GPSLongitude < BSLongUB) Then
                        'IF GPS co-ords are within range of listed bad zone
                        InvokeControl(carpc_form_variable.EnginePanel.txtGPSSmell, Sub(x) x.Visible = True)
                        'nozonedetectick - if still within zone, prevent function to re-open cabin from running.
                        NoZoneDetectTick = False
                        If CloseOpenState = True And BadSmellClosedCabin = False Then
                            'BadSmellClosedCabin variable records if smell zone function has closed cabin, if it has auto re-open once out of zone.
                            BadSmellClosedCabin = True
                            SendAccessSerialCommand("cyclecabin" & Chr(13))
                        End If
                        'stop loop
                        Exit Do
                    End If
                Loop

                'Check if out of zone
                If NoZoneDetectTick = True And BadSmellClosedCabin = True Then
                    'Open Cabin if closed by Zone Detect, and no longer within any zones.
                    If CloseOpenState = False Then
                        SendAccessSerialCommand("cyclecabin" & Chr(13))
                    End If
                    BadSmellClosedCabin = False
                    InvokeControl(carpc_form_variable.EnginePanel.txtGPSSmell, Sub(x) x.Visible = False)
                ElseIf NoZoneDetectTick = True Then
                    'If out of zone but cabin was already closed
                    BadSmellClosedCabin = False
                    InvokeControl(carpc_form_variable.EnginePanel.txtGPSSmell, Sub(x) x.Visible = False)
                End If
            End If
        Loop
    End Sub




    Public Sub AddBadSmellLocation()
        If GPSLatitude = 0 Or GPSLongitude = 0 Then
            'Invalid / GPS Not active.
            Exit Sub
        End If

        If My.Computer.FileSystem.FileExists(RunLocation & "\BadSmellLocations.txt") = False Then
            Dim BadSmellFile As IO.StreamWriter = IO.File.CreateText(RunLocation & "\BadSmellLocations.txt")
            BadSmellFile.WriteLine()
            BadSmellFile.Close()
        End If
        My.Computer.FileSystem.RenameFile(RunLocation & "\BadSmellLocations.txt", "BadSmellLocations.txt.old")
        Dim BadSmellFileNew As IO.StreamWriter = IO.File.CreateText(RunLocation & "\BadSmellLocations.txt")
        Dim CurrentDataStr As String() = IO.File.ReadAllLines(RunLocation & "\BadSmellLocations.txt.old")
        For Each line In CurrentDataStr
            BadSmellFileNew.WriteLine(line)
        Next
        BadSmellFileNew.WriteLine(GPSLatitude & "," & GPSLongitude)
        BadSmellFileNew.Close()
        My.Computer.FileSystem.DeleteFile(RunLocation & "\BadSmellLocations.txt.old")

        'Reload bad smell zones
        LoadBadSmellLocations()


    End Sub

End Module
