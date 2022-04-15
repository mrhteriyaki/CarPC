Module SerialManager
    Public AccessSerial As New IO.Ports.SerialPort
    Public EngineSerial As New IO.Ports.SerialPort
    Public GPSSerialOut As New IO.Ports.SerialPort
    Public SerialRearController As New IO.Ports.SerialPort

    Public ComPortNumber As String = ""
    Public AcessComPortNumber As String = ""
    Public EngineComPortNumber As String = ""
    Public RearComPortNumber As String = ""
    Public AccessPortOpen As Boolean = False
    Public EngineComOpen As Boolean = False
    Public RearPortOpen As Boolean = False

    Public Sub SetSerialPortSettings()
        AccessSerial.BaudRate = 115200
        EngineSerial.BaudRate = 115200
        GPSSerialOut.BaudRate = 115200
        SerialRearController.BaudRate = 115200
    End Sub

    Public Sub SendAccessSerialCommand(ByVal Command As String)
        If CarPCfrm.InvokeRequired = True Then
            CarPCfrm.Invoke(New MethodInvoker(Sub() SendAccessSerialCommand(Command)))
        Else
            Try
                AccessSerial.Write(Command)
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub SendEngineSerialCommand(ByVal Command As String)
        If CarPCfrm.InvokeRequired = True Then
            CarPCfrm.Invoke(New MethodInvoker(Sub() SendEngineSerialCommand(Command)))
        Else
            Try
                If EngineComOpen = True Then
                    EngineSerial.Write(Command)
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub
    Public Sub SendRearControllerSerialCommand(ByVal Command As String)
        If CarPCfrm.InvokeRequired = True Then
            CarPCfrm.Invoke(New MethodInvoker(Sub() SendRearControllerSerialCommand(Command)))
        Else
            Try
                If RearPortOpen = True Then
                    SerialRearController.Write(Command)
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Function FilterSerialLine(ByRef SerialLine As String) As String
        'Filter Serial command (Verify SL:EL)
        If SerialLine.StartsWith("SL:") And SerialLine.EndsWith(":EL" & Chr(13)) Then
            'SerialLine.Substring(SerialLine.Length - 3, 3) = ":EL" (replacing 3 with 4 is to account for end of line character)
            Return SerialLine.Substring(3, SerialLine.Length - 7)
        ElseIf SerialLine.StartsWith("swcc:") Then
            Return SerialLine
        End If

        Return Nothing
    End Function



    Dim TickCycle As Integer = 1



    Public Sub OBDLoopThread()
        Do Until ShuttingDown = True
            If EngineComOpen = True Then
                If TickCycle = 1 Then
                    SendEngineSerialCommand("OBDAIRTEMP" & Chr(13))
                ElseIf TickCycle = 2 Then
                    SendEngineSerialCommand("OBDCOOLANT" & Chr(13))
                ElseIf TickCycle = 3 Then
                    SendEngineSerialCommand("OBDINTAKETEMP" & Chr(13))
                ElseIf TickCycle = 4 Then
                    SendEngineSerialCommand("OBDINTAKEPSI" & Chr(13))
                ElseIf TickCycle = 5 Then
                    SendEngineSerialCommand("OBDECUVOLTAGE" & Chr(13))
                    TickCycle = 0
                End If
                'Increment TickCycle
                TickCycle += 1
                'Cycle is to spread out OBD Queries, Limited to 250ms.
                'Cycle prevents multiple queries being sent and not responses skipped.
            End If

            Dim Counter As Integer = 0
            Do Until Counter = 30 Or ShuttingDown = True
                Threading.Thread.Sleep(10)
                Counter += 1
            Loop


        Loop

    End Sub



    Public Sub EngineSerialThread()
        EngineSerial.PortName = EngineComPortNumber
        EngineSerial.ReadTimeout = 1000
        EngineSerial.WriteTimeout = 1000
        'Reminder: Background worker will not WRITE to serial port, must use invoke to main form.

        Try
            EngineSerial.Open()
            'used to check port status for other functions to send commands.
            EngineComOpen = True
            'delay to allow time for com port to startup before sending getstatus.

            SendEngineSerialCommand("GetStatus" & Chr(13))

        Catch ex As Exception
            If DebugingEnabled = True Then
                ErrorLogQueue.Enqueue("Unable to connect to CAN serial port - " & EngineComPortNumber)
            End If
            Exit Sub
        End Try


        Dim FailureCount As Integer = 0
        Dim FailureShutdown As Boolean = False
        Do Until ShuttingDown = True And FailureShutdown = False
            Dim CanLine As String = ""
            Try

                Try
                    CanLine = EngineSerial.ReadLine

                Catch ex As TimeoutException

                End Try
                If Not CanLine = "" Then
                    If CanLine.Contains("CAN:") Then
                        'Log CAN Data
                        If DebugingEnabled = True Then
                            carpc_form_variable.LogCANLine(CanLine)
                        End If
                        'Log to Can decoder

                        If CurrentDisplay = DisplayPanels.OptionPanel Then
                            carpc_form_variable.CANDecoderPanel.DataQueue.Enqueue(CanLine)
                        End If

                    End If

                    CANLinkDataLoop(CanLine)
                End If
            Catch ex As Exception
                FailureCount = FailureCount + 1
                ErrorLogQueue.Enqueue("Failure detected on Engine Serial Worker, reason:" & ex.ToString)
                If FailureCount = 5 Then
                    ErrorLogQueue.Enqueue("Failure count reached 5, shutting down Engine Serial Worker")
                    FailureShutdown = True
                End If
            End Try

        Loop

        EngineSerial.Close()
    End Sub



    Public Sub AccessSerialThread()
        AccessSerial.PortName = AcessComPortNumber
        AccessSerial.ReadTimeout = 1000
        AccessSerial.WriteTimeout = 1000


        'Reminder: Background worker will not SEND on serial port.
        'For diagnostic data, current send commands have been placed on CAN Decoder panel button event (on Option Panel.vb)
        'Other senddata commands are onthe GetStatus timer on main form.

        Try
            AccessSerial.Open()

            'Clear CAN Data in serial buffer
            AccessPortOpen = True

            SendAccessSerialCommand("GetStatus" & Chr(13))

        Catch ex As Exception
            If DebugingEnabled = True Then
                ErrorLogQueue.Enqueue("Unable to connect to CAN serial port - " & AcessComPortNumber)
            End If
            Exit Sub
        End Try

        Dim ErrorShutdown As Boolean = False
        Dim ErrorCount As Integer = 0
        Do Until ShuttingDown = True Or ErrorShutdown = True
            Try
                Dim CanLine As String = ""
                Try
                    CanLine = FilterSerialLine(AccessSerial.ReadLine)
                Catch ex As TimeoutException

                End Try

                If Not CanLine = "" Then
                    If CanLine.Contains("CAN:") Then
                        'Log CAN Data
                        If DebugingEnabled = True Then
                            carpc_form_variable.LogCANLine(CanLine)
                        End If
                        'Log to Can decoder

                        If CurrentDisplay = DisplayPanels.OptionPanel Then
                            carpc_form_variable.CANDecoderPanel.DataQueue.Enqueue(CanLine)
                        End If

                    ElseIf CanLine.StartsWith("swcc:") Then
                        Process_Steering_Wheel_Code(CanLine)
                    Else
                        CANLinkDataLoop(CanLine)
                    End If
                End If
            Catch ex As Exception
                ErrorLogQueue.Enqueue("error with bwcarlink:" & ex.ToString)
                ErrorCount = ErrorCount + 1
                'If ErrorCount = 5 Then
                'ErrorLogQueue.Enqueue("bwCanLink worker shutting down, error count reached")
                'ErrorShutdown = True
                'End If


            End Try

        Loop


        AccessSerial.Close()
    End Sub




    Public Sub CANLinkDataLoop(ByVal CanLine As String)
        If CanLine.Contains("CAN:2024") Then
            Dim OBDPID As String = CanLine.Split(" ")(2)
            Dim OBDDATA As String = CanLine.Split(" ")(3)
            Dim OBDDATAByte2 As String = CanLine.Split(" ")(4)

            If OBDPID = "5" Then
                Dim CoolantTemp As Integer = Integer.Parse(OBDDATA) - 40
                InvokeControl(carpc_form_variable.EnginePanel.CoolantGauge, Sub(x) x.Value = CoolantTemp)
                InvokeControl(carpc_form_variable.EnginePanel.CoolantGaugeDataLabel, Sub(x) x.Text = CoolantTemp)
            ElseIf OBDPID = "11" Then
                Dim IntakePressure As Double = Integer.Parse(OBDDATA)
                IntakePressure = IntakePressure * 0.145037
                InvokeControl(carpc_form_variable.EnginePanel.AirIntakePressureGauge, Sub(x) x.Value = IntakePressure)
                InvokeControl(carpc_form_variable.EnginePanel.AirIntakePressureDataLabel, Sub(x) x.Text = IntakePressure)
            ElseIf OBDPID = "15" Then
                Dim IntakeTemp As Integer = Integer.Parse(OBDDATA) - 40
                InvokeControl(carpc_form_variable.EnginePanel.AirIntakeTempGauge, Sub(x) x.Value = IntakeTemp)
                InvokeControl(carpc_form_variable.EnginePanel.AirIntakeTempDataLabel, Sub(x) x.Text = IntakeTemp)
            End If

        ElseIf CanLine.Contains("CAN:2025") Then
            Dim OBDPID As String = CanLine.Split(" ")(2)
            Dim OBDDATA As String = CanLine.Split(" ")(3)
            Dim OBDDATAByte2 As String = CanLine.Split(" ")(4)
            If OBDPID = "66" Then
                Dim ECUVoltage As Double = Integer.Parse(OBDDATA) * 256
                ECUVoltage = ECUVoltage + Integer.Parse(OBDDATAByte2)
                ECUVoltage = ECUVoltage / 1000
                InvokeControl(carpc_form_variable.EnginePanel.ECUVoltageGauge, Sub(x) x.Value = ECUVoltage)
                InvokeControl(carpc_form_variable.EnginePanel.ECUVoltage, Sub(x) x.Text = ECUVoltage & "V")
            End If


        ElseIf CanLine.Contains("Throttle:") Then
            Throttle = Integer.Parse(CanLine.Substring(9))
            If Throttle <= 100 And Throttle >= 0 Then
                InvokeControl(carpc_form_variable.EnginePanel.ThrottleGauge, Sub(x) x.Value = Throttle)
            Else
                ErrorLogQueue.Enqueue("Throttle out of range:" & CanLine)
            End If
        ElseIf CanLine.Contains("RPM:") Then
            RPM = Integer.Parse(CanLine.Substring(4))
            InvokeControl(carpc_form_variable.EnginePanel.RPMGauge, Sub(x) x.Value = RPM / 1000)
            'Fan speed must be checked before 'Speed' otherwise Speed: will be found in Fan Speed Command.

        ElseIf CanLine.Contains("Steering:") Then
            'Steering:141x1.141x2
            'Dim Steering As String = CanLine.Replace("Steering:", "")

            Dim SteeringAngle As Double = (Double.Parse(CanLine.Replace("Steering:", "")) / 10)

            carpc_form_variable.EnginePanel.WheelAngle = SteeringAngle

            InvokeControl(carpc_form_variable.EnginePanel.SteeringAngleText, Sub(x) x.Text = SteeringAngle)


        ElseIf CanLine.Contains("gearstickpos:") Then

            Dim gearstickcode As Integer = Integer.Parse(CanLine.Substring(13))
            'Reset Font
            InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Font = New Font("Microsoft Sans Serif", 18))


            'Reverse gear in seperate if statement for camera activate.
            If gearstickcode = 28 Or gearstickcode = 16 Or gearstickcode = 31 Or gearstickcode = 240 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "R")

                'Reverse Camera activate
                If SetRActive = False Then
                    'save which panel was set prior to changing to camera
                    carpc_form_variable.SetPreviousPanel()
                    'activate camera
                    carpc_form_variable.ShowCameras()
                    carpc_form_variable.CameraPanel.SetCameraLayout(Cameras.CameraLayouts.RearOnly)
                    SetRActive = True
                End If
            Else
                'Switch Reverse camera off / back.
                If SetRActive = True Then
                    SetRActive = False
                    'Revert to previous Panel
                    carpc_form_variable.RevertPanel()
                End If
            End If

            If gearstickcode = 0 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "P")

            ElseIf gearstickcode = 32 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "N")
            ElseIf gearstickcode = 49 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "1")
            ElseIf gearstickcode = 50 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "2")
            ElseIf gearstickcode = 51 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "3")
            ElseIf gearstickcode = 52 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "4")
            ElseIf gearstickcode = 53 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "5")
            ElseIf gearstickcode = 54 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "6")
            ElseIf gearstickcode = 63 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Font = New Font("Microsoft Sans Serif", 12))
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = "Changing")
            Else
                InvokeControl(carpc_form_variable.EnginePanel.txtgear, Sub(x) x.Text = gearstickcode)
            End If



        ElseIf CanLine.Contains("fuelstatus:") Then
            'Fuel Counter Code (1079: X1,X2)
            Dim fuelcode As String = Integer.Parse(CanLine.Substring(11).Split(",")(0))
            'ignore code 2.
            Dim FuelPercentage As Double = (fuelcode / 121) * 100

            InvokeControl(carpc_form_variable.EnginePanel.txtFuelCode, Sub(x) x.Text = Math.Round(FuelPercentage, 0) & "%")

        ElseIf CanLine.Contains("Brakes:") Then
            InvokeControl(carpc_form_variable.CarStatusPanel.lblBrakes, Sub(x) x.Text = "Brakes:" & CanLine.Replace("Brakes:", ""))
            'Brakes:ON
            'Brakes:OFF


        ElseIf CanLine.Contains("Fan Speed:") Then

            Dim TmpFanSpeed As Integer = Integer.Parse(CanLine.Substring(10))

            Dim Val128 As String = ""
            Dim Val64 As String = ""
            Dim Val32 As String = ""
            Dim Val16 As String = ""

            If TmpFanSpeed >= 128 Then
                TmpFanSpeed -= 128
                Val128 = "128"
            End If

            If TmpFanSpeed >= 64 Then
                TmpFanSpeed -= 64
                Val64 = "64"
            End If

            If TmpFanSpeed >= 32 Then
                TmpFanSpeed -= 32
                Val32 = "32"
            End If

            If TmpFanSpeed >= 16 Then
                TmpFanSpeed -= 16
                Val32 = "16"
            End If

            FanSpeed = TmpFanSpeed * 10


            'Match fan speed target with current fan speed, to set correct start speed after engine start.
        ElseIf CanLine.Contains("wheelspeed:") Then
            Dim WheelSpeeds() As String = CanLine.Substring(11).Split(",")

            FrontLeftWheelSpeed = Math.Round(Integer.Parse(WheelSpeeds(0)) / 100, 2)
            carpc_form_variable.EnginePanel.FrontLeftWheelText.Text = FrontLeftWheelSpeed

            FrontRightWheelSpeed = Math.Round(Integer.Parse(WheelSpeeds(1)) / 100, 2)
            carpc_form_variable.EnginePanel.FrontRightWheelText.Text = FrontRightWheelSpeed

            RearLeftWheelSpeed = Math.Round(Integer.Parse(WheelSpeeds(2)) / 100, 2)
            carpc_form_variable.EnginePanel.RearLeftWheelText.Text = RearLeftWheelSpeed

            RearRightWheelSpeed = Math.Round(Integer.Parse(WheelSpeeds(3)) / 100, 2)
            carpc_form_variable.EnginePanel.RearRightWheelText.Text = RearRightWheelSpeed

        ElseIf CanLine.Contains("Speed:") Then

            Speed = Math.Round(Double.Parse(CanLine.Substring(6)), 0)
            Try
                InvokeControl(carpc_form_variable.EnginePanel.SpeedGauge, Sub(x) x.Value = Speed)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try




        ElseIf CanLine.Contains("OutsideTemp:") Then
            OutsideTemp = Double.Parse(CanLine.Substring(12))
            If OutsideTemp = 0 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtOutsideTemp, Sub(x) x.Text = "N/A")
            Else
                InvokeControl(carpc_form_variable.EnginePanel.txtOutsideTemp, Sub(x) x.Text = Math.Round(OutsideTemp, 1))
            End If
        ElseIf CanLine.Contains("CabinTemp:") Then
            InvokeControl(carpc_form_variable.EnginePanel.txtCabinTemp, Sub(x) x.Text = Math.Round(Double.Parse(CanLine.Substring(10)), 1))
        ElseIf CanLine.Contains("AC Temp:") Then

            HVACTemp = Double.Parse(CanLine.Substring(8))
            If HVACTemp > 0 Then
                HVACTemp = HVACTemp * 0.5
            End If

            If HVACTemp = 0 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtTemperature, Sub(x) x.Text = "Off")
            ElseIf HVACTemp = 0.5 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtTemperature, Sub(x) x.Text = "Low")
            ElseIf HVACTemp = 127 Then
                InvokeControl(carpc_form_variable.EnginePanel.txtTemperature, Sub(x) x.Text = "High")
            Else
                InvokeControl(carpc_form_variable.EnginePanel.txtTemperature, Sub(x) x.Text = HVACTemp.ToString)
            End If
        ElseIf CanLine.Contains("fanspeedcode:") Then
            carpc_form_variable.EnginePanel.txtFanMode.Text = "FanCode:" & CanLine.Substring(13) 'Update diagnostic code box in middle of screen.
        ElseIf CanLine.Contains("VentStatus:") Then


            HVACVENTCode = Integer.Parse(CanLine.Substring(11))
            'Use Decoded CAN values to calculate which vents are open.

            'Process Code
            Dim TmpHVACCode As Integer = HVACVENTCode
            If TmpHVACCode >= 128 Then
                '128 = AC Off
                AirConOn = False
                TmpHVACCode -= 128
            Else
                AirConOn = True
            End If

            Dim CloseOpenCodesString As String = ""
            If TmpHVACCode >= 64 Then
                CloseOpenCodesString = "64 "
                '64 = close cabin
                TmpHVACCode -= 64
                CloseOpenState = False
            Else
                'else is to cover open state.
                '32 also covers open state however does not address the 'neither state', which is always open.
                'the open check was left as the code minus is still needed.
                CloseOpenState = True
            End If

            If TmpHVACCode >= 32 Then
                '32 = open cabin
                CloseOpenCodesString = CloseOpenCodesString & "32 "
                CloseOpenState = True
                TmpHVACCode -= 32
            End If
            If TmpHVACCode >= 16 Then
                FaceVents = True
                TmpHVACCode -= 16
                CloseOpenCodesString = CloseOpenCodesString & "16 "
            Else
                FaceVents = False
            End If
            If TmpHVACCode >= 8 Then
                '8 = feet vents
                FeetVents = True
                TmpHVACCode -= 8
                CloseOpenCodesString = CloseOpenCodesString & "8 "
            Else
                FeetVents = False
            End If
            If TmpHVACCode >= 4 Then
                CloseOpenCodesString = CloseOpenCodesString & "4 "
                WindowVents = True
                TmpHVACCode -= 4
            Else
                WindowVents = False
            End If
            If TmpHVACCode >= 2 Then
                CloseOpenCodesString = CloseOpenCodesString & "2"
                'unknown code
                TmpHVACCode -= 2

            End If
            If TmpHVACCode = 1 Then
                FanSpeedMode = "Manual"
            Else
                FanSpeedMode = "Auto"
            End If
            CloseOpenCodes = CloseOpenCodesString

            'Work out which vent configuration is active.

            If WindowVents = False Then
                'Face Vents Only
                If FaceVents = True And FeetVents = False Then
                    CurrentVentConfiguration = VentConfigurations.Face
                End If
                'Feet Vents Only
                If FaceVents = False And FeetVents = True Then
                    CurrentVentConfiguration = VentConfigurations.Feet
                End If
                'Face and Feet Vents
                If FaceVents = True And FeetVents = True Then
                    CurrentVentConfiguration = VentConfigurations.Face_Feet
                End If
            Else
                'Window Vents Only
                If FaceVents = False And FeetVents = False Then
                    CurrentVentConfiguration = VentConfigurations.Window
                End If

                'Window and Feet Vents
                If FaceVents = False And FeetVents = True Then
                    CurrentVentConfiguration = VentConfigurations.Window_Feet
                End If

            End If



        ElseIf CanLine.Contains("Fan Speed Mode:") Then
            FanSpeedMode = CanLine.Substring(15)
        ElseIf CanLine.Contains("Rear Demister:On") Then
            RearDemister = True
        ElseIf CanLine.Contains("Rear Demister:Off") Then
            RearDemister = False
        ElseIf CanLine.Contains("Car Lock State:") Then
            LockState = Integer.Parse(CanLine.Substring(15))
        ElseIf CanLine.Contains("Cabin Lights: On") Then
            CabinLights = LightState.LightsOn
        ElseIf CanLine.Contains("Cabin Lights: Off") Then
            CabinLights = LightState.LightsOff
        ElseIf CanLine.Contains("Indicators:") Then
            Indicators = CanLine.Substring(11)
        ElseIf CanLine.Contains("Headlights:") Then
            Dim HLC As Integer = Integer.Parse(CanLine.Substring(11))
            If HLC >= 8 Then
                HighBeams = LightState.LightsOn
                HLC = HLC - 8



            Else
                HighBeams = LightState.LightsOff

            End If
            If HLC >= 4 Then
                FogLights = LightState.LightsOn
                HLC = HLC - 4
            Else
                FogLights = LightState.LightsOff
            End If
            If HLC >= 2 Then
                Headlights = LightState.LightsOn
                HLC = HLC - 2
                'Display dimmed.
                'DriveLine_AutoDimmer_Darken()
            Else
                Headlights = LightState.LightsOff
                'Display Full Brightness
                'DriveLine_AutoDimmer_Reset()
            End If
            If HLC = 1 Then
                AutoHeadLights = LightState.LightsOn
            Else
                AutoHeadLights = LightState.LightsOff
            End If
        ElseIf CanLine.Contains("Door:") Then

            If CanLine.Contains("Front Right Door: Open") Then
                DriverDoor = True
            ElseIf CanLine.Contains("Front Right Door: Closed") Then
                DriverDoor = False
            ElseIf CanLine.Contains("Front Left Door: Open") Then
                PassengerDoor = True
            ElseIf CanLine.Contains("Front Left Door: Closed") Then
                PassengerDoor = False
            ElseIf CanLine.Contains("Rear Right Door: Open") Then
                RearRightDoor = True
            ElseIf CanLine.Contains("Rear Right Door: Closed") Then
                RearRightDoor = False
            ElseIf CanLine.Contains("Rear Left Door: Open") Then
                RearLeftDoor = True
            ElseIf CanLine.Contains("Rear Left Door: Closed") Then
                RearLeftDoor = False
            End If
        ElseIf CanLine.Contains("Ignition State:") Then
            If CanLine.Contains("Ignition State: Off") Then
                IgnitionStatus = 0
                InvokeControl(carpc_form_variable.CarStatusPanel.lblIgnitionState, Sub(x) x.Text = "Ignition: Off")
            ElseIf CanLine.Contains("Ignition State: Acc") Then
                IgnitionStatus = 1
                InvokeControl(carpc_form_variable.CarStatusPanel.lblIgnitionState, Sub(x) x.Text = "Ignition: Acc")
            ElseIf CanLine.Contains("Ignition State: On") Then
                IgnitionStatus = 2
                InvokeControl(carpc_form_variable.CarStatusPanel.lblIgnitionState, Sub(x) x.Text = "Ignition: On")

                SetStartupFanCode() 'Set initial fan settings once Ignition is on.
            End If
        End If
    End Sub




End Module
