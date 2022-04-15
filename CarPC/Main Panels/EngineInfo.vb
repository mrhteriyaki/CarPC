Imports System.Threading
Imports System.Drawing.Drawing2D

Public Class EngineInfo

    Public FrontLeftWheelText As New TextBox
    Dim FLWL As New Label
    Public FrontRightWheelText As New TextBox
    Dim FRWL As New Label
    Public RearLeftWheelText As New TextBox
    Dim RLWL As New Label
    Public RearRightWheelText As New TextBox
    Dim RRWL As New Label

    Public SteeringAngleText As New TextBox
    Dim SteeringAngleLabel As New Label


    Private Sub tmrACAuto_tick(sender As Object, e As EventArgs) Handles tmrACAuto.Tick
        SetACStatus()
    End Sub
    Private Sub SetACStatus()
        'Update AC Images on screen to show vent configuration, rear demister on/off, cabin close/open and AC on/off.

        If CurrentVentConfiguration = VentConfigurations.Face_Feet Then
            pbxVentLocation.Location = New Point(btnSetFeetFace.Location.X, pbxVentLocation.Location.Y)
        ElseIf CurrentVentConfiguration = VentConfigurations.Window_Feet Then
            pbxVentLocation.Location = New Point(btnSetFeetWindow.Location.X, pbxVentLocation.Location.Y)
        ElseIf CurrentVentConfiguration = VentConfigurations.Window Then
            pbxVentLocation.Location = New Point(btnWindowDefog.Location.X, pbxVentLocation.Location.Y)
        ElseIf CurrentVentConfiguration = VentConfigurations.Feet Then
            pbxVentLocation.Location = New Point(btnSetFeet.Location.X, pbxVentLocation.Location.Y)
        ElseIf CurrentVentConfiguration = VentConfigurations.Face Then
            pbxVentLocation.Location = New Point(btnSetFace.Location.X, pbxVentLocation.Location.Y)
        End If

        If CloseOpenState = True Then
            btnCloseCabin.BackgroundImage = My.Resources.Open_Cabin
        ElseIf CloseOpenState = False Then
            btnCloseCabin.BackgroundImage = My.Resources.Close_Cabin
        End If

        If RearDemister = True Then
            btnRearDefog.BackgroundImage = My.Resources.Rear_Demister_On
        Else
            btnRearDefog.BackgroundImage = My.Resources.Rear_Demister_Off
        End If

        If AirConOn = True Then
            btnACOff.Image = My.Resources.On_Button
        Else
            btnACOff.Image = Nothing
        End If
        btnCloseCabin.Text = CloseOpenCodes
    End Sub



    Private Sub btnFanDown_Click(sender As Object, e As EventArgs) Handles btnFanDown.Click
        FanSpeedDecrease()
    End Sub

    Private Sub btnFanUp_Click(sender As Object, e As EventArgs) Handles btnFanUp.Click
        FanSpeedIncrease()
    End Sub

    Private Sub btnCloseCabin_Click(sender As Object, e As EventArgs) Handles btnCloseCabin.Click
        SendAccessSerialCommand("cyclecabin" & Chr(13))
    End Sub



    '    Private Sub btnCycleVents_Click(sender As Object, e As EventArgs) Handles btnCycleVents.Click
    'SendAccessSerialCommand("cyclevents" & Chr(13))
    'End Sub

    Private Sub btnRearDefog_Click(sender As Object, e As EventArgs) Handles btnRearDefog.Click
        SendAccessSerialCommand("reardemist" & Chr(13))
    End Sub

    Private Sub btnTempDown_Click(sender As Object, e As EventArgs) Handles btnTempDown.Click
        TemperatureDown()
    End Sub

    Private Sub btnTempUp_Click(sender As Object, e As EventArgs) Handles btnTempUp.Click
        TemperatureUp()
    End Sub


    Private Sub btnOff_Click(sender As Object, e As EventArgs) Handles btnOff.Click
        FanOff()

    End Sub

    Private Sub btnACOff_Click(sender As Object, e As EventArgs) Handles btnACOff.Click
        SendAccessSerialCommand("aconoff" & Chr(13))
    End Sub


    Private Sub btnAuto_Click(sender As Object, e As EventArgs) Handles btnAuto.Click
        SendAccessSerialCommand("acauto" & Chr(13))
    End Sub


    Private Sub tmrCycleVents_Tick(sender As Object, e As EventArgs) Handles tmrCycleVents.Tick
        If GetVentManagement() = True Then
            If Not CurrentVentConfiguration = TargetVentConfiguration And AccessSerial.IsOpen = True Then
                VentTransition = True 'Variable to store vent changing.
                'if vents are not at target, send cycle command.
                'if can port open send command.
                If TargetVentConfiguration = VentConfigurations.Window Then
                    SendAccessSerialCommand("windowdefog" & Chr(13))
                Else
                    SendAccessSerialCommand("cyclevents" & Chr(13))
                End If
                'keep timer running to maintain the gap between cycles.
            ElseIf VentTransition = True Then
                VentTransition = False
            End If

            If VentTransition = True Then 'Hide Blue marker when changing vents.
                pbxVentLocation.Image = Nothing
            Else
                pbxVentLocation.Image = My.Resources.Selected
            End If
        End If


    End Sub

    Private Sub ChangeVentConfigurationTarget(ByVal VC As VentConfigurations)
        SetVentManagement(True)
        TargetVentConfiguration = VC
    End Sub

    Private Sub btnSetFace_Click(sender As Object, e As EventArgs) Handles btnSetFace.Click
        ChangeVentConfigurationTarget(VentConfigurations.Face)
    End Sub
    Private Sub btnSetFeet_Click(sender As Object, e As EventArgs) Handles btnSetFeet.Click
        ChangeVentConfigurationTarget(VentConfigurations.Feet)
    End Sub
    Private Sub btnSetFeetFace_Click(sender As Object, e As EventArgs) Handles btnSetFeetFace.Click
        ChangeVentConfigurationTarget(VentConfigurations.Face_Feet)
    End Sub
    Private Sub btnSetFeetWindow_Click(sender As Object, e As EventArgs) Handles btnSetFeetWindow.Click
        ChangeVentConfigurationTarget(VentConfigurations.Window_Feet)
    End Sub
    Private Sub btnWindowDefog_Click(sender As Object, e As EventArgs) Handles btnWindowDefog.Click
        ChangeVentConfigurationTarget(VentConfigurations.Window)
    End Sub

    Private Sub tmrGaugeLabels_Tick(sender As Object, e As EventArgs) Handles tmrGaugeLabels.Tick
        Dim SpeedVal As Integer = Math.Round(SpeedGauge.Value, 0)
        If SpeedVal < 10 Then
            SpeedLabel.Location = New Point(617, 192)
        ElseIf SpeedVal < 100 Then '11-99
            SpeedLabel.Location = New Point(607, 192)
        ElseIf SpeedVal >= 100 Then '100+
            SpeedLabel.Location = New Point(600, 192)
        End If
        SpeedLabel.Text = SpeedVal

        Dim RPMVal As Integer = Math.Round((RPMGauge.Value * 1000), 0)
        If RPMVal < 10 Then
            RPMLabel.Location = New Point(360, 192)
            RPMLabel.Width = 60
        ElseIf RPMVal < 100 Then '11-99
            RPMLabel.Location = New Point(350, 192)
            RPMLabel.Width = 80
        ElseIf RPMVal < 1000 Then '100-999
            RPMLabel.Location = New Point(343, 192)
            RPMLabel.Width = 100
        ElseIf RPMVal >= 1000 Then '1000+
            RPMLabel.Location = New Point(337, 192)
            RPMLabel.Width = 100
        End If
        RPMLabel.Text = RPMVal

        Dim ThrottleVal As Integer = Math.Round(ThrottleGauge.Value, 0)
        If ThrottleVal < 10 Then
            ThrottleLabel.Location = New Point(110, 192)
        ElseIf ThrottleVal < 100 Then
            ThrottleLabel.Location = New Point(100, 192)
        ElseIf ThrottleVal < 1000 Then
            ThrottleLabel.Location = New Point(93, 192)
        End If

        ThrottleLabel.Text = ThrottleVal

        MainBatteryGauge.Value = MainVoltage
        MainVoltageLabel.Text = MainVoltage & "V"

    End Sub

    Public Sub StartAirconVentConfiguration(ByVal AirConLoadPosition As String)
        If AirConLoadPosition = "feet" Or AirConLoadPosition = "none" Then
            CurrentVentConfiguration = VentConfigurations.Feet
            TargetVentConfiguration = VentConfigurations.Feet
        ElseIf AirConLoadPosition = "face" Then
            CurrentVentConfiguration = VentConfigurations.Face
            TargetVentConfiguration = VentConfigurations.Face
        ElseIf AirConLoadPosition = "face_feet" Then
            CurrentVentConfiguration = VentConfigurations.Face_Feet
            TargetVentConfiguration = VentConfigurations.Face_Feet
        ElseIf AirConLoadPosition = "window" Then
            CurrentVentConfiguration = VentConfigurations.Window
            TargetVentConfiguration = VentConfigurations.Window
        ElseIf AirConLoadPosition = "window_feet" Then
            CurrentVentConfiguration = VentConfigurations.Window_Feet
            TargetVentConfiguration = VentConfigurations.Window_Feet
        End If


        'enable after reading initial position
        tmrCycleVents.Enabled = True
    End Sub




    Private Sub EngineInfo_Load(sender As Object, e As EventArgs) Handles Me.Load

        DoubleBuffered = True
        'CenterPoint = New Point(gbxSteering.Location.X + 100, gbxSteering.Location.Y + 100)

        txtGPSSmell.Visible = False
        'System.IO.File.ReadAllLines()


        'Coolant Gauge
        CoolantGauge = New GaugeGraphic
        SetSmallGaugeDetails(CoolantGauge)
        CoolantGauge.Location = New Point(2, 25)
        CoolantGauge.MinValue = 0
        CoolantGauge.MaxValue = 180
        CoolantGauge.Value = 60
        gbxOBD.Controls.Add(CoolantGauge)


        'Coolant Gauge Label
        CoolantGaugeLabel = New Label
        CoolantGaugeLabel.Location = New Point(25, 135)
        CoolantGaugeLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        CoolantGaugeLabel.Text = "Coolant Temp"
        CoolantGaugeLabel.Height = 20
        gbxOBD.Controls.Add(CoolantGaugeLabel)
        CoolantGaugeLabel.BringToFront()

        'Coolant Gauge Data Label

        CoolantGaugeDataLabel.Location = New Point(50, 115)
        CoolantGaugeDataLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        CoolantGaugeDataLabel.Text = "60"
        CoolantGaugeDataLabel.Height = 20
        CoolantGaugeDataLabel.Width = 40
        gbxOBD.Controls.Add(CoolantGaugeDataLabel)
        CoolantGaugeDataLabel.BringToFront()




        AirIntakeTempGauge = New GaugeGraphic
        SetSmallGaugeDetails(AirIntakeTempGauge)
        AirIntakeTempGauge.Location = New Point(127, 25)
        AirIntakeTempGauge.MinValue = 0
        AirIntakeTempGauge.MaxValue = 180
        AirIntakeTempGauge.Value = 60
        gbxOBD.Controls.Add(AirIntakeTempGauge)

        AirIntakeGaugeLabel = New Label
        AirIntakeGaugeLabel.Location = New Point(150, 135)
        AirIntakeGaugeLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        AirIntakeGaugeLabel.Text = "Air Intake Temp"
        AirIntakeGaugeLabel.Height = 20
        gbxOBD.Controls.Add(AirIntakeGaugeLabel)
        AirIntakeGaugeLabel.BringToFront()


        AirIntakeTempDataLabel.Location = New Point(180, 115)
        AirIntakeTempDataLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        AirIntakeTempDataLabel.Text = "60"
        AirIntakeTempDataLabel.Height = 20
        AirIntakeTempDataLabel.Width = 40
        gbxOBD.Controls.Add(AirIntakeTempDataLabel)
        AirIntakeTempDataLabel.BringToFront()





        AirIntakePressureGauge = New GaugeGraphic
        SetSmallGaugeDetails(AirIntakePressureGauge)
        'Set increment to lower with lower value range.
        AirIntakePressureGauge.ScaleLinesMajorStepValue = 3
        AirIntakePressureGauge.Location = New Point(245, 25)
        AirIntakePressureGauge.MinValue = 0
        AirIntakePressureGauge.MaxValue = 30
        AirIntakePressureGauge.Value = 0
        gbxOBD.Controls.Add(AirIntakePressureGauge)

        AirIntakePressureGaugeLabel = New Label
        AirIntakePressureGaugeLabel.Location = New Point(260, 135)
        AirIntakePressureGaugeLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        AirIntakePressureGaugeLabel.Text = "Air Intake Pressure"
        AirIntakePressureGaugeLabel.Height = 20
        AirIntakePressureGaugeLabel.Width = 100
        gbxOBD.Controls.Add(AirIntakePressureGaugeLabel)
        AirIntakePressureGaugeLabel.BringToFront()


        AirIntakePressureDataLabel.Location = New Point(300, 115)
        AirIntakePressureDataLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        AirIntakePressureDataLabel.Text = "0"
        AirIntakePressureDataLabel.Height = 20
        AirIntakePressureDataLabel.Width = 40
        gbxOBD.Controls.Add(AirIntakePressureDataLabel)
        AirIntakePressureDataLabel.BringToFront()



        MainBatteryGauge = New GaugeGraphic
        SetSmallGaugeDetails(MainBatteryGauge)
        MainBatteryGauge.ScaleLinesMajorStepValue = 2
        MainBatteryGauge.Location = New Point(52, 25)
        MainBatteryGauge.MinValue = 0
        MainBatteryGauge.MaxValue = 16
        MainBatteryGauge.Value = 0
        gbxVoltaes.Controls.Add(MainBatteryGauge)

        MainBatteryGaugeLabel = New Label
        MainBatteryGaugeLabel.Location = New Point(80, 135)
        MainBatteryGaugeLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        MainBatteryGaugeLabel.Text = "Main Battery"
        MainBatteryGaugeLabel.Width = 100
        MainBatteryGaugeLabel.Height = 20
        gbxVoltaes.Controls.Add(MainBatteryGaugeLabel)
        MainBatteryGaugeLabel.BringToFront()

        MainVoltageLabel = New Label
        MainVoltageLabel.Location = New Point(95, 115)
        MainVoltageLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        MainVoltageLabel.Text = "00.0V"
        MainVoltageLabel.Width = 35
        MainVoltageLabel.Height = 20
        gbxVoltaes.Controls.Add(MainVoltageLabel)
        MainVoltageLabel.BringToFront()


        ECUVoltageGauge = New GaugeGraphic
        SetSmallGaugeDetails(ECUVoltageGauge)
        ECUVoltageGauge.ScaleLinesMajorStepValue = 2
        ECUVoltageGauge.Location = New Point(207, 25) '(250, 25)
        ECUVoltageGauge.MinValue = 0
        ECUVoltageGauge.MaxValue = 16
        ECUVoltageGauge.Value = 0
        gbxVoltaes.Controls.Add(ECUVoltageGauge)

        ECUVoltageGaugeLabel = New Label
        ECUVoltageGaugeLabel.Location = New Point(235, 135) '(280, 135)
        ECUVoltageGaugeLabel.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        ECUVoltageGaugeLabel.Text = "ECU Voltage"
        ECUVoltageGaugeLabel.Width = 100
        ECUVoltageGaugeLabel.Height = 20
        gbxVoltaes.Controls.Add(ECUVoltageGaugeLabel)
        ECUVoltageGaugeLabel.BringToFront()

        ECUVoltage = New Label
        ECUVoltage.Location = New Point(250, 115) '(295, 115)
        ECUVoltage.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        ECUVoltage.Text = "00.0V"
        ECUVoltage.Width = 35
        ECUVoltage.Height = 20
        gbxVoltaes.Controls.Add(ECUVoltage)
        ECUVoltage.BringToFront()


        ThrottleGauge = New GaugeGraphic
        SetLargeGaugeDetails(ThrottleGauge)
        ThrottleGauge.ScaleLinesMajorStepValue = 10
        ThrottleGauge.Location = New Point(2, 25)
        ThrottleGauge.MinValue = 0
        ThrottleGauge.MaxValue = 100
        ThrottleGauge.Value = 0
        gbxEngine.Controls.Add(ThrottleGauge)

        ThrottleLabel = New Label
        ThrottleLabel.Location = New Point(93, 192)
        ThrottleLabel.Font = New Drawing.Font("Microsoft Sans Serif", 22)
        ThrottleLabel.Text = "000"
        ThrottleLabel.Width = 80
        ThrottleLabel.Height = 30
        gbxEngine.Controls.Add(ThrottleLabel)
        ThrottleLabel.BringToFront()

        ThrottleNameLabel = New Label
        ThrottleNameLabel.Location = New Point(80, 225)
        ThrottleNameLabel.Font = New Drawing.Font("Microsoft Sans Serif", 18)
        ThrottleNameLabel.Text = "Throttle"
        ThrottleNameLabel.Width = 100
        ThrottleNameLabel.Height = 30
        gbxEngine.Controls.Add(ThrottleNameLabel)
        ThrottleNameLabel.BringToFront()

        RPMGauge = New GaugeGraphic
        SetLargeGaugeDetails(RPMGauge)
        RPMGauge.ScaleLinesMajorStepValue = 1
        RPMGauge.ScaleLinesMinorTicks = 4
        RPMGauge.Location = New Point(250, 25)
        RPMGauge.MinValue = 0
        RPMGauge.MaxValue = 7
        RPMGauge.Value = 0
        gbxEngine.Controls.Add(RPMGauge)

        RPMLabel = New Label
        RPMLabel.Location = New Point(335, 192)
        RPMLabel.Font = New Drawing.Font("Microsoft Sans Serif", 22)
        RPMLabel.Text = "0000"
        RPMLabel.Width = 80
        RPMLabel.Height = 35
        gbxEngine.Controls.Add(RPMLabel)
        RPMLabel.BringToFront()

        RPMNameLabel = New Label
        RPMNameLabel.Location = New Point(345, 225)
        RPMNameLabel.Font = New Drawing.Font("Microsoft Sans Serif", 18)
        RPMNameLabel.Text = "RPM"
        RPMNameLabel.Width = 150
        RPMNameLabel.Height = 30
        gbxEngine.Controls.Add(RPMNameLabel)
        RPMNameLabel.BringToFront()

        SpeedGauge = New GaugeGraphic
        SetLargeGaugeDetails(SpeedGauge)
        SpeedGauge.ScaleLinesMajorStepValue = 20
        SpeedGauge.ScaleLinesMinorTicks = 4
        SpeedGauge.Location = New Point(505, 25)
        SpeedGauge.MinValue = 0
        SpeedGauge.MaxValue = 260
        SpeedGauge.Value = 0
        gbxEngine.Controls.Add(SpeedGauge)

        SpeedLabel = New Label
        SpeedLabel.Location = New Point(600, 192)
        SpeedLabel.Font = New Drawing.Font("Microsoft Sans Serif", 22)
        SpeedLabel.Text = "000"
        SpeedLabel.Width = 80
        SpeedLabel.Height = 35
        gbxEngine.Controls.Add(SpeedLabel)
        SpeedLabel.BringToFront()

        SpeedNameLabel = New Label
        SpeedNameLabel.Location = New Point(590, 225)
        SpeedNameLabel.Font = New Drawing.Font("Microsoft Sans Serif", 18)
        SpeedNameLabel.Text = "Speed"
        SpeedNameLabel.Width = 150
        SpeedNameLabel.Height = 30
        gbxEngine.Controls.Add(SpeedNameLabel)
        SpeedNameLabel.BringToFront()





        'wheel info labels
        FrontLeftWheelText.Location = New Point(CenterPoint.X - 170, CenterPoint.Y - 130)
        SetTextboxDetails(FrontLeftWheelText)
        FLWL.Location = New Point(CenterPoint.X - 170, CenterPoint.Y - 150)

        FrontRightWheelText.Location = New Point(CenterPoint.X + 90, CenterPoint.Y - 130)
        SetTextboxDetails(FrontRightWheelText)
        FRWL.Location = New Point(CenterPoint.X + 90, CenterPoint.Y - 150)

        RearLeftWheelText.Location = New Point(CenterPoint.X - 170, CenterPoint.Y - 10)
        SetTextboxDetails(RearLeftWheelText)
        RLWL.Location = New Point(CenterPoint.X - 170, CenterPoint.Y - 30)


        RearRightWheelText.Location = New Point(CenterPoint.X + 90, CenterPoint.Y - 10)
        SetTextboxDetails(RearRightWheelText)
        RRWL.Location = New Point(CenterPoint.X + 90, CenterPoint.Y - 30)

        SteeringAngleText.Location = New Point(CenterPoint.X - 50, CenterPoint.Y - 180)
        SetTextboxDetails(SteeringAngleText)
        SteeringAngleText.Width = 100

        SteeringAngleLabel.Text = "Steering Angle"
        SteeringAngleLabel.Location = New Point(CenterPoint.X - 50, CenterPoint.Y - 200)
        SetLabelDetails(SteeringAngleLabel)

        FLWL.Text = "FL Speed:"
        FRWL.Text = "FR Speed:"
        RLWL.Text = "RL Speed:"
        RRWL.Text = "RR Speed:"

        SetLabelDetails(FLWL)
        SetLabelDetails(FRWL)
        SetLabelDetails(RLWL)
        SetLabelDetails(RRWL)

        tmrGaugeLabels.Enabled = True
        tmrACAuto.Enabled = True

    End Sub

    Private Sub SetLabelDetails(ByRef tb As Label)
        tb.BackColor = Color.Black
        tb.ForeColor = Color.White
        tb.Font = New Font("Microsoft Sans Serif", 10)
        tb.Width = 80

        Me.Controls.Add(tb)
    End Sub


    Private Sub SetTextboxDetails(ByRef tb As TextBox)

        tb.ReadOnly = True
        tb.BackColor = Color.Black
        tb.ForeColor = Color.White
        tb.Font = New Font("Microsoft Sans Serif", 16)
        tb.Width = 80

        Me.Controls.Add(tb)
    End Sub

    Public ThrottleGauge As GaugeGraphic
    Public RPMGauge As GaugeGraphic
    Public SpeedGauge As GaugeGraphic
    Public ThrottleLabel As Label
    Public RPMLabel As Label
    Public SpeedLabel As Label

    Public CoolantGauge As GaugeGraphic
    Public CoolantGaugeLabel As New Label
    Public CoolantGaugeDataLabel As New Label

    Public AirIntakeGaugeLabel As Label
    Public AirIntakeTempDataLabel As New Label

    Public AirIntakePressureGaugeLabel As Label
    Public AirIntakePressureDataLabel As New Label


    Public MainBatteryGaugeLabel As Label
    Public AuxBatteryGaugeLabel As Label
    Public ECUVoltageGaugeLabel As Label

    Public ThrottleNameLabel As Label
    Public RPMNameLabel As Label
    Public SpeedNameLabel As Label
    Public AirIntakeTempGauge As GaugeGraphic
    Public AirIntakePressureGauge As GaugeGraphic

    Public MainBatteryGauge As GaugeGraphic
    Public AuxBatteryGauge As GaugeGraphic
    Public ECUVoltageGauge As GaugeGraphic
    Public MainVoltageLabel As Label
    Public RearVoltageLabel As Label
    Public ECUVoltage As Label
    Private Sub SetLargeGaugeDetails(ByRef Gaugename As GaugeGraphic)
        Gaugename.BackColor = Color.Black
        Gaugename.BaseArcColor = Color.Silver
        Gaugename.BaseArcRadius = 100
        Gaugename.BaseArcStart = 135
        Gaugename.BaseArcSweep = 270
        Gaugename.BaseArcWidth = 10
        Gaugename.Center = New Point(125, 125)
        Gaugename.NeedleColor1 = AGaugeNeedleColor.Red
        Gaugename.NeedleColor2 = Color.Maroon
        Gaugename.NeedleRadius = 100
        Gaugename.NeedleType = NeedleType.Advance
        Gaugename.NeedleWidth = 4
        Gaugename.ScaleLinesInterColor = Color.Blue
        Gaugename.ScaleLinesInterInnerRadius = 73
        Gaugename.ScaleLinesInterOuterRadius = 80
        Gaugename.ScaleLinesInterWidth = 1
        Gaugename.ScaleLinesMajorColor = Color.Blue
        Gaugename.ScaleLinesMajorInnerRadius = 90
        Gaugename.ScaleLinesMajorOuterRadius = 100
        'Major tick value sets where numbers will go
        Gaugename.ScaleLinesMajorStepValue = 20
        Gaugename.ScaleLinesMajorWidth = 2
        Gaugename.ScaleLinesMinorColor = Color.Blue
        Gaugename.ScaleLinesMinorInnerRadius = 90
        Gaugename.ScaleLinesMinorOuterRadius = 98
        Gaugename.ScaleLinesMinorTicks = 4
        Gaugename.ScaleNumbersColor = Color.White
        Gaugename.ScaleNumbersRadius = 115
        Gaugename.ScaleNumbersRotation = 0
        Gaugename.ScaleNumbersStartScaleLine = 0
        Gaugename.ScaleNumbersStepScaleLines = 1
        Gaugename.Font = New Drawing.Font("Microsoft Sans Serif", 10)
        Gaugename.Width = 254
        Gaugename.Height = 225

    End Sub
    Private Sub SetSmallGaugeDetails(ByRef Gaugename As GaugeGraphic)
        Gaugename.BackColor = Color.Black
        Gaugename.BaseArcColor = Color.Silver
        Gaugename.BaseArcRadius = 40
        Gaugename.BaseArcStart = 135
        Gaugename.BaseArcSweep = 270
        Gaugename.BaseArcWidth = 3
        Gaugename.Center = New Point(60, 60)
        Gaugename.NeedleColor1 = AGaugeNeedleColor.Red
        Gaugename.NeedleColor2 = Color.Maroon
        Gaugename.NeedleRadius = 40
        Gaugename.NeedleType = NeedleType.Advance
        Gaugename.NeedleWidth = 3
        Gaugename.ScaleLinesInterColor = Color.Blue
        Gaugename.ScaleLinesInterInnerRadius = 33
        Gaugename.ScaleLinesInterOuterRadius = 40
        Gaugename.ScaleLinesInterWidth = 1
        Gaugename.ScaleLinesMajorColor = Color.Blue
        Gaugename.ScaleLinesMajorInnerRadius = 35
        Gaugename.ScaleLinesMajorOuterRadius = 40
        'Major tick value sets where numbers will go
        Gaugename.ScaleLinesMajorStepValue = 20
        Gaugename.ScaleLinesMajorWidth = 2
        Gaugename.ScaleLinesMinorColor = Color.Blue
        Gaugename.ScaleLinesMinorInnerRadius = 35
        Gaugename.ScaleLinesMinorOuterRadius = 40
        Gaugename.ScaleLinesMinorTicks = 2
        Gaugename.ScaleNumbersColor = Color.White
        Gaugename.ScaleNumbersRadius = 50
        Gaugename.ScaleNumbersRotation = 0
        Gaugename.ScaleNumbersStartScaleLine = 0
        Gaugename.ScaleNumbersStepScaleLines = 1
        Gaugename.Font = New Drawing.Font("Microsoft Sans Serif", 8)
        Gaugename.Width = 125
        Gaugename.Height = 120

    End Sub

    Dim CenterPoint As New Point(580, 540)

    Private FrontCrossBar As New Rectangle(CenterPoint.X - 50, CenterPoint.Y - 115, 101, 10)
    Private CenterBar As New Rectangle(CenterPoint.X - 3, CenterPoint.Y - 115, 6, 120)
    Private RearCrossBar As New Rectangle(CenterPoint.X - 50, CenterPoint.Y, 101, 10)

    Private RearLeftWheel As New Rectangle(CenterPoint.X - 75, CenterPoint.Y - 20, 30, 50)
    Private RearRightWheel As New Rectangle(CenterPoint.X + 45, CenterPoint.Y - 20, 30, 50)

    Private FrontLeftWheel As New Rectangle(CenterPoint.X - 75, CenterPoint.Y - 135, 30, 50)
    Dim FrontLeftRotatePoint As New Point(FrontLeftWheel.X + (FrontLeftWheel.Width / 2), FrontLeftWheel.Y + (FrontLeftWheel.Height / 2))

    Private FrontRightWheel As New Rectangle(CenterPoint.X + 45, CenterPoint.Y - 135, 30, 50)
    Dim FrontRightRotatePoint As New Point(FrontRightWheel.X + (FrontRightWheel.Width / 2), FrontRightWheel.Y + (FrontRightWheel.Height / 2))

    Public WheelAngle As Double = 0.0


    Private Sub PaintGo(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        Dim angle As Integer = Math.Round((WheelAngle / 12), 0)


        Dim Mybrush As Brush = New SolidBrush(Color.Blue)
        Dim MyMatrix As New Matrix

        e.Graphics.Transform = MyMatrix
        e.Graphics.FillRectangle(Mybrush, FrontCrossBar)

        MyMatrix.Dispose()
        MyMatrix = New Matrix

        e.Graphics.Transform = MyMatrix
        e.Graphics.FillRectangle(Mybrush, CenterBar)


        MyMatrix.Dispose()
        MyMatrix = New Matrix

        e.Graphics.Transform = MyMatrix
        e.Graphics.FillRectangle(Mybrush, RearCrossBar)

        MyMatrix.Dispose()
        MyMatrix = New Matrix

        e.Graphics.Transform = MyMatrix
        e.Graphics.FillRectangle(Mybrush, RearLeftWheel)

        MyMatrix.Dispose()
        MyMatrix = New Matrix

        e.Graphics.Transform = MyMatrix
        e.Graphics.FillRectangle(Mybrush, RearRightWheel)



        MyMatrix.Dispose()
        MyMatrix = New Matrix


        MyMatrix.RotateAt(angle, FrontLeftRotatePoint, MatrixOrder.Append)
        e.Graphics.Transform = MyMatrix
        e.Graphics.FillRectangle(Mybrush, FrontLeftWheel)


        MyMatrix.Dispose()
        MyMatrix = New Matrix


        MyMatrix.RotateAt(angle, FrontRightRotatePoint, MatrixOrder.Append)
        e.Graphics.Transform = MyMatrix
        e.Graphics.FillRectangle(Mybrush, FrontRightWheel)




        Mybrush.Dispose()
        MyMatrix.Dispose()


    End Sub

    Private Sub GraphicsUpdate_Tick(sender As Object, e As EventArgs) Handles GraphicsUpdate.Tick
        Me.Invalidate()

    End Sub

    Private Sub btnRecordLocation_Click(sender As Object, e As EventArgs) Handles btnRecordLocation.Click
        AddBadSmellLocation()
    End Sub
End Class
