

Public Class Car_Status

    Private Sub tmrUpdate_Tick(sender As Object, e As EventArgs) Handles tmrUpdate.Tick


        'rtbCanData.Text = "TESTING"
        'rtbCanData.Select(1, 3)
        'rtbCanData.SelectionColor = Color.Red
        'DisplayonDebug - additional debugging info that isn't logged.



        Try
            'Lights
            If CabinLights = LightState.LightsOff Then

                btnLights.BackgroundImage = My.Resources.LightsOff

            ElseIf CabinLights = LightState.LightsOn Then

                btnLights.BackgroundImage = My.Resources.LightsOn

            End If


            'Doors
            If DriverDoor = True Then
                lblDriverDoor.Text = "Driver Door: Open"
            Else
                lblDriverDoor.Text = "Driver Door: Closed"
            End If
            If PassengerDoor = True Then
                lblPassengerDoor.Text = "Passenger Door: Open"
            Else
                lblPassengerDoor.Text = "Passenger Door: Closed"
            End If
            If RearRightDoor = True Then
                lblRearRightDoor.Text = "Rear Right Door: Open"
            Else
                lblRearRightDoor.Text = "Rear Right Door: Closed"
            End If
            If RearLeftDoor = True Then
                lblRearLeftDoor.Text = "Rear Left Door: Open"
            Else
                lblRearLeftDoor.Text = "Rear Left Door: Closed"
            End If

        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error with Car Status: Door State - Error:" & ex.ToString)
        End Try
        Try
            'Lock Stats
            If LockState = -1 Then
                lblLockState.Text = "Lock State Code: N/A"
            ElseIf LockState < 20 Then
                lblLockState.Text = "Lock State Code: Open"
            ElseIf LockState > 200 Then
                lblLockState.Text = "Lock State Code: Closed"
            End If
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error with Car Status: Lock State - Error:" & ex.ToString)
        End Try

        Try
            If CabinLights = LightState.LightsOn Then
                lblInteriorLights.Text = "Interior Lights: On"
            ElseIf CabinLights = LightState.LightsOff Then
                lblInteriorLights.Text = "Interior Lights: Off"
            End If
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error with Car Status: Cabin Lights - Error:" & ex.ToString)
        End Try

        Try

            lblIndicators.Text = "Indicators: " & Indicators
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error with Car Status: Indicators - Error:" & ex.ToString)
        End Try

        Try


            If Headlights = LightState.LightsOn Then
                lblHeadlights.Text = "Headlights: On"
            ElseIf Headlights = LightState.LightsOff Then
                lblHeadlights.Text = "Headlights: Off"
            End If
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error with Car Status: Headlights - Error:" & ex.ToString)
        End Try



        Try


            If FogLights = LightState.LightsOn Then
                lblFogLights.Text = "Fog Lights: On"
            ElseIf FogLights = LightState.LightsOff Then
                lblFogLights.Text = "Fog Lights: Off"
            End If
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error with Car Status: Fog Lights - Error:" & ex.ToString)
        End Try
        Try
            If AutoHeadLights = LightState.LightsOn Then
                lblAutoLights.Text = "Automatic Headlights: On"
            ElseIf AutoHeadLights = LightState.LightsOn Then
                lblAutoLights.Text = "Automatic Headlights: Off"
            End If
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error with Car Status: Auto Lights - Error:" & ex.ToString)
        End Try
        Try
            If HighBeams = LightState.LightsOn Then
                lblHighBeams.Text = "High Beams: On"
            ElseIf HighBeams = LightState.LightsOff Then
                lblHighBeams.Text = "High Beams: Off"
            End If
        Catch ex As Exception
            ErrorLogQueue.Enqueue("Error with Car Status: High Beams - Error:" & ex.ToString)
        End Try

    End Sub






    Private Sub btnRelay1ON_Click(sender As Object, e As EventArgs) Handles btnRelay1ON.Click
        SendRearControllerSerialCommand("MONITOR:OFF" & Chr(13))
    End Sub

    Private Sub btnRelay1OFF_Click(sender As Object, e As EventArgs) Handles btnRelay1OFF.Click
        SendRearControllerSerialCommand("MONITOR:ON" & Chr(13))
    End Sub

    Private Sub btnRelay2ON_Click(sender As Object, e As EventArgs) Handles btnRelay2ON.Click
        SendRearControllerSerialCommand("RELAY:ON" & Chr(13))
    End Sub

    Private Sub btnRelay2OFF_Click(sender As Object, e As EventArgs) Handles btnRelay2OFF.Click
        SendRearControllerSerialCommand("RELAY:OFF" & Chr(13))
    End Sub

    Private Sub btnHazards_Click(sender As Object, e As EventArgs) Handles btnHazards.Click
        SendAccessSerialCommand("hazardlights" & Chr(13))
    End Sub

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click
        SendAccessSerialCommand("lock" & Chr(13))
    End Sub

    Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
        SendAccessSerialCommand("unlock" & Chr(13))
    End Sub

    Private Sub btnLights_Click(sender As Object, e As EventArgs) Handles btnLights.Click
        SendAccessSerialCommand("interiorlights" & Chr(13))
    End Sub

    Private Sub btnDSC_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDSC.MouseDown
        tmrDSC.Enabled = True
    End Sub

    Private Sub btnDSC_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDSC.MouseUp
        tmrDSC.Enabled = False
    End Sub

    Private Sub tmrDSC_Tick(sender As Object, e As EventArgs) Handles tmrDSC.Tick
        SendAccessSerialCommand("dsc" & Chr(13))
    End Sub

    Private Sub btnDSC_Click(sender As Object, e As EventArgs) Handles btnDSC.Click
        SendAccessSerialCommand("dsc" & Chr(13))
    End Sub

    Private Sub btnSaveHomeGPS_Click(sender As Object, e As EventArgs) Handles btnSaveHomeGPS.Click
        HomeLatitude = GPSLatitude
        HomeLongitude = GPSLongitude


        Dim current_config() As String = IO.File.ReadAllLines("config.ini")
        Dim new_config_file As New IO.StreamWriter("config.ini.new")
        For Each line In current_config
            If Not line.StartsWith("homepos=") Then
                new_config_file.WriteLine(line)
            End If
        Next
        new_config_file.WriteLine("homepos=" & GPSLatitude & "," & GPSLongitude)
        new_config_file.Close()

        My.Computer.FileSystem.RenameFile("config.ini", "config.ini.old") 'Backup old file
        My.Computer.FileSystem.RenameFile("config.ini.new", "config.ini") 'move in new file
        My.Computer.FileSystem.DeleteFile("config.ini.old") 'remove old file


    End Sub

    Private Sub Car_Status_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
