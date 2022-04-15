Public Class JourneyLogs
    Dim SelectedLog As String = ""
    Dim Directory As String = CarDataPath.ToLower & "\Journeys\"
    Private Sub JourneyLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Filter end \ on config directory
        Directory = Directory.Replace("\\", "\").ToLower

        If My.Computer.FileSystem.DirectoryExists(Directory) = True Then
            For Each File In My.Computer.FileSystem.GetFiles(Directory, FileIO.SearchOption.SearchTopLevelOnly)
                Dim FileName As String = File.Replace(".txt", "").ToLower
                FileName = FileName.Replace(Directory & "journey ", "")
                lbxJourneys.Items.Add(FileName.Replace(Directory.ToLower, Nothing))
            Next
        Else
            ErrorLogQueue.Enqueue("Journey Logger: Error with directory: " & Directory)
        End If

    End Sub

    Private Sub lbxJourneys_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxJourneys.SelectedIndexChanged
        SelectedLog = Directory & "Journey " & lbxJourneys.SelectedItem & ".txt"
    End Sub

    Private Sub btnOpenLog_Click(sender As Object, e As EventArgs) Handles btnOpenLog.Click
        If My.Computer.FileSystem.FileExists(SelectedLog) = True Then
            If My.Computer.FileSystem.FileExists("map.html") = True Then
                My.Computer.FileSystem.DeleteFile("map.html")
            End If
            GenerateMap(SelectedLog, RunLocation & "\map.html")
            Process.Start("map.html")
        End If
    End Sub

    Private Sub GenerateMap(ByVal InputFile As String, ByVal OutputFile As String)
        Try

        
        If My.Computer.FileSystem.FileExists(Inputfile) = False Then
            Console.WriteLine("File not found:" & Inputfile)
        End If

        Dim ReadFile() As String = IO.File.ReadAllLines(Inputfile)

        'Center position of map / zoomed
        Dim CenterLocation As String = ReadFile(1).Split(";")(1)

        Dim NewJourneyMap As IO.StreamWriter = IO.File.CreateText(OutputFile)
        NewJourneyMap.WriteLine("<html>")

        NewJourneyMap.WriteLine("<meta name=" & Chr(34) & "viewport" & Chr(34) & " content=" & Chr(34) & _
        "initial-scale=1.0, user-scalable=now" & Chr(34) & ">")

        NewJourneyMap.WriteLine("<meta charset=" & Chr(34) & "utf-8" & Chr(34) & ">")

        NewJourneyMap.WriteLine("<title>Journey Log</title>")

        NewJourneyMap.WriteLine("<style>")
        NewJourneyMap.WriteLine("html, body, #map-canvas {")
        NewJourneyMap.WriteLine("height: 100%;")
        NewJourneyMap.WriteLine("margin: 0px;")
        NewJourneyMap.WriteLine("padding: 0px")
        NewJourneyMap.WriteLine("}")
        NewJourneyMap.WriteLine("</style>")

        NewJourneyMap.WriteLine("<script src=" & Chr(34) & "https://maps.googleapis.com/maps/api/js?v=3.exp" & Chr(34) & _
                                "></script>")

        NewJourneyMap.WriteLine("<script>")

        NewJourneyMap.WriteLine()
        NewJourneyMap.WriteLine("function initialize() {")
        NewJourneyMap.WriteLine("var mapOptions = {")
        NewJourneyMap.WriteLine("zoom: 15,")
        NewJourneyMap.WriteLine("center: new google.maps.LatLng(" & CenterLocation & "),")
        NewJourneyMap.WriteLine("mapTypeId: google.maps.MapTypeId.TERRAIN")
        NewJourneyMap.WriteLine("};")
        NewJourneyMap.WriteLine()
        NewJourneyMap.WriteLine("var map = new google.maps.Map(document.getElementById('map-canvas'),")
        NewJourneyMap.WriteLine("mapOptions);")
        NewJourneyMap.WriteLine()
        NewJourneyMap.WriteLine("var flightPlanCoordinates = [")


            Dim Counter As Integer = -1
            Dim PreviousGPS As String = ""
            Dim LocationLines As String = ""
        For Each Line In ReadFile
            Counter += 1
                If Counter > 0 Then

                    Try
                        Dim LocationStr As String = Line.Split(";")(1)
                        If Not PreviousGPS = LocationStr Then
                            LocationLines &= "new google.maps.LatLng(" & LocationStr & ")"
                            If Counter < ReadFile.Length Then
                                LocationLines &= "," & Environment.NewLine
                            Else
                                LocationLines &= Environment.NewLine
                            End If
                            PreviousGPS = LocationStr
                        End If

                    Catch ex As Exception
                        'Problem with data
                    End Try
                End If
        Next
            'Validate end charactor is not ,
            If LocationLines.Substring(LocationLines.Length - 1, 1) = "," Then
                LocationLines = LocationLines.Substring(0, LocationLines.Length - 1)
            End If
            NewJourneyMap.WriteLine(LocationLines)
            


        NewJourneyMap.WriteLine("];")
        NewJourneyMap.WriteLine("var flightPath = new google.maps.Polyline({")
        NewJourneyMap.WriteLine("path: flightPlanCoordinates,")
        NewJourneyMap.WriteLine("geodesic: true,")
        'Line Colour
        NewJourneyMap.WriteLine("strokeColor: '#0000A0',")
        NewJourneyMap.WriteLine("strokeOpacity: 1.0,")
        NewJourneyMap.WriteLine("strokeWeight: 3")
        NewJourneyMap.WriteLine("});")

        NewJourneyMap.WriteLine("flightPath.setMap(map);")
        NewJourneyMap.WriteLine("}")
        NewJourneyMap.WriteLine()
        NewJourneyMap.WriteLine("google.maps.event.addDomListener(window, 'load', initialize);")
        NewJourneyMap.WriteLine()
        NewJourneyMap.WriteLine("</script>")
        NewJourneyMap.WriteLine("</head>")
        NewJourneyMap.WriteLine("<body>")
        NewJourneyMap.WriteLine("<div id=" & Chr(34) & "map-canvas" & Chr(34) & "></div>")
        NewJourneyMap.WriteLine("</body>")
        NewJourneyMap.WriteLine("</html>")



        NewJourneyMap.Close()
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error generating map for journey file:" & SelectedLog)
        End Try

    End Sub

  
End Class
