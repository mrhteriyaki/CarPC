Module AuxController 'Aux / Rear Controller

    Public Sub RunRearControl()
        SerialRearController.PortName = RearComPortNumber
        SerialRearController.ReadTimeout = 1000
        SerialRearController.WriteTimeout = 1000

        Try
            SerialRearController.Open()
            RearPortOpen = True
        Catch ex As Exception
            'Fail to open rear controller com port
        End Try

        If RearPortOpen = True Then
            Try
                Do Until ShuttingDown = True
                    Try
                        Dim RCL As String = SerialRearController.ReadLine
                        ProcessRearControl(RCL)
                    Catch ex As TimeoutException

                    End Try
                Loop
                SerialRearController.Close()
            Catch ex As Exception
                'Force Close will cause exception (ThreadClose)
            End Try
        End If
    End Sub


    Private Sub ProcessRearControl(ByRef readline As String)
        If readline.StartsWith("$GP") Then 'GPS 
            'GPS Data from GPS Rec
            'if GGA NMEA GPS Co-ord data
            'Write out GPS data for Navigation software.
            GPSSerialOutBuffer.Enqueue(readline)
        End If

    End Sub



End Module
