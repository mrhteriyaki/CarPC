Imports USBMeasure

Module VoltMeter



    Public Sub VoltageMonitorThread()
        Try

            device = New CUSBMeasureMain()
            device.USBMOpen()
            Do Until ShuttingDown = True
                Try
                    device.USBMGetData()

                    MainVoltage = Math.Round(device.UnitData, 1)
                    'Dim Voltage2 As Double = Math.Round(device.UnitData2, 1)

                Catch ex As Exception
                    If DebugingEnabled = True Then
                        ErrorLogQueue.Enqueue("Voltage read failure: " & ex.ToString)
                    End If

                End Try

                Dim counter As Integer = 0
                Do Until counter = 30 Or ShuttingDown = True
                    counter += 1
                    Threading.Thread.Sleep(10)
                Loop
                'sleep 300ms broken up into 10ms breaks.
            Loop
        Catch ex As Exception
            'If DebugingEnabled = True Then
            ErrorLogQueue.Enqueue("Failure to connect to voltmeter")
            'End If

        End Try

    End Sub
End Module
