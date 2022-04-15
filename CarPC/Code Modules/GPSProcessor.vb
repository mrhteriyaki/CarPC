Module GPSProcessor
    'Home Co-oridnates saved in config file.
    Public HomeLatitude As Double
    Public HomeLongitude As Double





    Dim GPSOutOpen As Boolean = False

    Public Sub StartGPSRelay()
        Dim GPSRelayThread As New Threading.Thread(AddressOf GPSRelayProcess)
        GPSRelayThread.Start()
    End Sub

    Private Sub GPSRelayProcess()
        'Setup GPS Out / relay port.

        Try
            GPSSerialOut.PortName = GPSPortOut
            GPSSerialOut.WriteTimeout = 1000
            GPSSerialOut.ReadTimeout = 1000
            GPSSerialOut.Open()
            GPSOutOpen = True
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error opening GPS Out port" & ex.ToString)
            'exit if fails
            Exit Sub
        End Try


        Do Until ShuttingDown = True
            If GPSSerialOutBuffer.Count > 0 Then
                'Process Serial Write
                Dim Output As String = GPSSerialOutBuffer.Dequeue

                'MsgBox(Output)
                If GPSLoaded = True Then
                    Try
                        WriteGPSSerialOUT(Output)
                    Catch ex As Exception
                        'Serial timeout
                        MsgBox(ex.ToString)
                    End Try
                End If
                Try


                    If Output.StartsWith("$GPGGA") = True Then

                        If Output.Split(",")(2).Replace(".", "") = "" Or Output.Split(",")(4).Replace(".", "") = "" Then
                            'If no gps co-ords detected
                            GPSLatitude = 0
                            GPSLongitude = 0

                        Else
                            'Process gps co-ords into variables.

                            '1 degree = 108KM
                            '1 minute = 1.8km
                            '1 second = 30 metres

                            'Latitude
                            Dim LatString As String = Output.Split(",")(2)
                            Dim LatDegrees As Integer = Integer.Parse(LatString.Substring(0, 2))
                            Dim LatMinutes As Double = Double.Parse(LatString.Substring(2, LatString.Length - 2))
                            LatMinutes = Math.Round((LatMinutes / 60), 6)
                            GPSLatitude = LatDegrees + LatMinutes
                            If Output.Split(",")(3).Contains("S") Then
                                GPSLatitude = GPSLatitude * -1
                            End If



                            'Longitude
                            Dim LongString As String = Output.Split(",")(4)
                            Dim LongDegrees As Integer = Integer.Parse(LongString.Substring(0, 3))
                            Dim LongMinutes As Double = Double.Parse(LongString.Substring(3, LongString.Length - 3))
                            LongMinutes = Math.Round((LongMinutes / 60), 6)
                            GPSLongitude = LongDegrees + LongMinutes

                            If Output.Split(",")(5).Contains("W") Then
                                GPSLongitude = GPSLongitude * -1
                            End If


                            'Within Home Co-oridnates check.

                            Dim range As Double = 0.001 'Distance from point.
                            Dim CheckLong As Boolean = RangeCheck(GPSLongitude, HomeLongitude, range)
                            Dim CheckLat As Boolean = RangeCheck(GPSLatitude, HomeLatitude, range)

                            If CheckLong = True And CheckLat = True Then
                                'Home Detected.
                                SetHome(True)
                            Else
                                SetHome(False)
                            End If


                        End If
                    End If
                Catch ex As Exception
                    'gps failed to process
                End Try
            End If


        Loop
        GPSSerialOut.Close()
    End Sub

    Private Sub WriteGPSSerialOUT(ByVal input As String)
        If CarPCfrm.InvokeRequired = True Then
            CarPCfrm.Invoke(New MethodInvoker(Sub() WriteGPSSerialOUT(input)))
        Else
            Try
                If GPSOutOpen = True Then
                    GPSSerialOut.WriteLine(input)
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

End Module
