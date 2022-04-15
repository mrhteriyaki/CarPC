Module Airconditioning
    Dim StartupVentCodeSet As Boolean = False


    Dim StartupFanCodeSet As Boolean = False


    Dim VentManagement As Boolean = False
    Public Sub SetVentManagement(ByVal Mode As Boolean)
        VentManagement = Mode
    End Sub
    Function GetVentManagement() As Boolean
        Return VentManagement
    End Function



    Public Sub SetStartupFanCode()
        Dim DelayThread As New Threading.Thread(AddressOf SetFanCodeThread)
        DelayThread.Start()
    End Sub

    Private Sub SetFanCodeThread()
        'Wait 500 MS before setting initial / fanspeed target to current fan speed.
        'Use ignition on as trigger, and delay so that fan code can come through (CAN Data order is not gaurenteed, which is why requries the delay).
        Threading.Thread.Sleep(500)
        If StartupFanCodeSet = False Then
            StartupFanCodeSet = True
            FanSpeedTarget = FanSpeed
            InvokeControl(carpc_form_variable.EnginePanel.txtFanSpeed, Sub(x) x.Text = FanSpeed & "%")
        End If
    End Sub


    Public Sub FanSpeedIncrease()
        FanManagement = True
        If FanSpeedTarget < 100 Then
            FanSpeedTarget += 10
        End If
        CarPCfrm.EnginePanel.txtFanSpeed.Text = FanSpeedTarget & "%"
    End Sub
    Public Sub FanSpeedDecrease()
        FanManagement = True
        If FanSpeedTarget > 10 Then
            FanSpeedTarget -= 10
        End If
        If FanSpeedTarget = 0 Then
            FanOff()
        Else
            CarPCfrm.EnginePanel.txtFanSpeed.Text = FanSpeedTarget & "%"
        End If

    End Sub
    Public Sub TemperatureDown()
        SendAccessSerialCommand("lowertemp" & Chr(13))
    End Sub
    Public Sub TemperatureUp()
        SendAccessSerialCommand("increasetemp" & Chr(13))
    End Sub

    Public Sub FanOff()
        SetVentManagement(False) 'Disable management of vents.
        FanManagement = False 'fan off variable, AC Manager will not auto-target correct fan speed when fanoff = true.
        SendAccessSerialCommand("alloff" & Chr(13))
        CarPCfrm.EnginePanel.txtFanSpeed.Text = "Off"

        TargetVentConfiguration = VentConfigurations.Face 'Set the default vent position (FACE vents).

    End Sub
    Public Sub AirconditioningLoop()
        Do Until StartupFanCodeSet = True Or ShuttingDown = True
            Threading.Thread.Sleep(50) 'Wait until getstatus gets the current fan speed code.
        Loop

        Do Until ShuttingDown = True
            If FanManagement = True Then
                'Current Fan speed = FanSpeed variable.
                'TargetSpeed = FanSpeedTarget variable.
                If FanSpeed < FanSpeedTarget Then
                    'fan speed is slower than target speed, increase speed.
                    SendAccessSerialCommand("fan+" & Chr(13))
                ElseIf FanSpeed > FanSpeedTarget Then
                    'fan speed is faster than target, slow fan speed.
                    SendAccessSerialCommand("fan-" & Chr(13))
                End If
            End If
            Dim counter As Integer = 0
            Do Until counter = 60
                Threading.Thread.Sleep(10)
                counter += 1
            Loop
        Loop
    End Sub



End Module
