Module Module1

    Sub Main(ByVal args() As String)
        Dim InputFile As String = args(0)
        Dim OutputFile As String = args(1)
        
        If My.Computer.FileSystem.FileExists(InputFile) = False Then
            Console.WriteLine("File not found:" & InputFile)
        End If

        Dim ReadFile() As String = IO.File.ReadAllLines(InputFile)

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
        For Each Line In ReadFile
            Counter += 1
            If Counter > 0 Then
                Try
                    NewJourneyMap.Write("new google.maps.LatLng(" & Line.Split(";")(1) & ")")
                Catch ex As Exception
                    'Problem with data
                End Try
                If Counter < ReadFile.Length Then
                    NewJourneyMap.WriteLine(",")
                Else
                    NewJourneyMap.WriteLine()
                End If
            End If
        Next

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


    End Sub

End Module
