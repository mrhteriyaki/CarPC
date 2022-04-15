Module SteeringWheelControls
    Public SteeringWheelSetup As Boolean = False
    Public ButtonValues As String()

    Dim SetupCount As Integer = -1
    Dim SetupOffset As Integer = 40
    Dim LowPoint As Integer = -1

    Public Sub Process_Steering_Wheel_Code(ByVal canline As String)

        canline = canline.Substring(5) 'Remove SWCC:
        'Steeringwheel control button pressed.
        If canline.Contains("Return to low val:") Then
            'Process return to low value.
            Dim LowValPoint As Integer = Integer.Parse(canline.Substring(16))
            SetAnalogLowPoint(LowValPoint)
        Else
            'Proccess SWCC Code.
            Dim SWCode As Integer = Integer.Parse(canline)
            LogSWCCData(SWCode) 'Log Code
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtSteeringWheelData, Sub(x) x.Text = SWCode.ToString)
            If SteeringWheelSetup = True Then
                SetupSWCC(SWCode)
            Else
                ProcessSWCC(SWCode)
            End If
        End If
    End Sub

    Private Sub LogSWCCData(ByVal SWCode As String)
        Dim ExistingData As New List(Of String)
        If IO.File.Exists("swcc-log.txt") Then
            For Each line In IO.File.ReadAllLines("swcc-log.txt")
                ExistingData.Add(line)
            Next
            My.Computer.FileSystem.RenameFile("swcc-log.txt", "swcc-log.txt.old")
        End If
        'Save existing data
        Dim swf As New IO.StreamWriter("swcc-log.txt") 'setup new file
        For Each ln In ExistingData
            swf.WriteLine(ln)
        Next

        'Current format DateTime,MainVoltage,analog lowpoint,Data
        'Write the New Data
        swf.Write(DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss-ffff"))
        swf.Write(",")
        swf.Write(MainVoltage.ToString)
        swf.Write(",")
        swf.Write(LowPoint)
        swf.Write(",")
        swf.WriteLine(SWCode)


        swf.Close() 'close new file


        If My.Computer.FileSystem.FileExists("swcc-log.txt.old") Then
            My.Computer.FileSystem.DeleteFile("swcc-log.txt.old") 'remove backup of old file
        End If

    End Sub


    Private Sub SetAnalogLowPoint(ByVal SWCode As Integer)
        LowPoint = SWCode
        InvokeControl(carpc_form_variable.ButtonControlPanel.txtLowPointVal, Sub(x) x.Text = SWCode.ToString)
    End Sub


    Private Sub ProcessSWCC(ByVal SWCode As Integer)
        If SWCode >= ButtonValues(0) And SWCode <= ButtonValues(1) Then
            'Seek Button
            If ModeState = 1 Then
                carpc_form_variable.MusicPanel.NextSong()
            ElseIf ModeState = 2 Then
                TemperatureUp()
            End If
        ElseIf SWCode >= ButtonValues(2) And SWCode <= ButtonValues(3) Then
            'Volume Up Button
            If ModeState = 1 Then
                VolumeUp()
            ElseIf ModeState = 2 Then
                FanSpeedIncrease()
            End If
        ElseIf SWCode >= ButtonValues(4) And SWCode <= ButtonValues(5) Then
            'Volume Down Button
            If ModeState = 1 Then
                VolumeDown()
            ElseIf ModeState = 2 Then
                FanSpeedDecrease()
            End If
        ElseIf SWCode >= ButtonValues(6) And SWCode <= ButtonValues(7) Then
            'Phone Button
            If ModeState = 1 Then
                carpc_form_variable.MediaControlPanel.PlayFunction()
            ElseIf ModeState = 2 Then
                TemperatureDown()
            End If
        ElseIf SWCode >= ButtonValues(8) And SWCode <= ButtonValues(9) Then
            'Mode Button

            If ModeWindowOpen = False Then
                'Modestate count is 2 (was 3)
                If ModeState = 2 Then
                    ModeState = 1
                Else
                    ModeState += 1
                End If
                ModeWindowOpen = True
                Try
                    carpc_form_variable.ShowModeForm()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try


            End If
        End If
    End Sub



    Private Sub SetupSWCC(ByVal SWCode As Integer)
        SetupCount += 1
        ButtonValues(SetupCount) = SWCode
        If SetupCount = 0 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtSeekMin, Sub(x) x.Text = Integer.Parse(SWCode - SetupOffset).ToString)
        ElseIf SetupCount = 1 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtSeekMax, Sub(x) x.Text = Integer.Parse(SWCode + SetupOffset).ToString)
        ElseIf SetupCount = 2 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtVolumeUpMin, Sub(x) x.Text = Integer.Parse(SWCode - SetupOffset).ToString)
        ElseIf SetupCount = 3 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtVolumeUpMax, Sub(x) x.Text = Integer.Parse(SWCode + SetupOffset).ToString)
        ElseIf SetupCount = 4 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtVolumeDownMin, Sub(x) x.Text = Integer.Parse(SWCode - SetupOffset).ToString)
        ElseIf SetupCount = 5 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtVolumeDownMax, Sub(x) x.Text = Integer.Parse(SWCode + SetupOffset).ToString)
        ElseIf SetupCount = 6 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtMediaMin, Sub(x) x.Text = Integer.Parse(SWCode - SetupOffset).ToString)
        ElseIf SetupCount = 7 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtMediaMax, Sub(x) x.Text = Integer.Parse(SWCode + SetupOffset).ToString)
        ElseIf SetupCount = 8 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtModeMin, Sub(x) x.Text = Integer.Parse(SWCode - SetupOffset).ToString)
        ElseIf SetupCount = 9 Then
            InvokeControl(carpc_form_variable.ButtonControlPanel.txtModeMax, Sub(x) x.Text = Integer.Parse(SWCode + SetupOffset).ToString)
            'reset setup.
            SteeringWheelSetup = False
            SetupCount = -1
        End If
    End Sub


    Public Sub SaveSteeringWheelControlValues()
        If My.Computer.FileSystem.FileExists(RunLocation & "\values.ini.old") = True Then
            My.Computer.FileSystem.DeleteFile(RunLocation & "\values.ini.old")
        End If
        My.Computer.FileSystem.RenameFile(RunLocation & "\values.ini", "values.ini.old")
        Dim ValuesFile As IO.StreamWriter = IO.File.CreateText(RunLocation & "\values.ini")
        ValuesFile.WriteLine(ButtonValues(0))
        ValuesFile.WriteLine(ButtonValues(1))
        ValuesFile.WriteLine(ButtonValues(2))
        ValuesFile.WriteLine(ButtonValues(3))
        ValuesFile.WriteLine(ButtonValues(4))
        ValuesFile.WriteLine(ButtonValues(5))
        ValuesFile.WriteLine(ButtonValues(6))
        ValuesFile.WriteLine(ButtonValues(7))
        ValuesFile.WriteLine(ButtonValues(8))
        ValuesFile.WriteLine(ButtonValues(9))
        ValuesFile.Close()
    End Sub

End Module
