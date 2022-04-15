Public Class Option_Panel

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If My.Computer.FileSystem.FileExists(RunLocation & "\Update.bat") = True Then
            My.Computer.FileSystem.DeleteFile(RunLocation & "\Update.bat")
        End If

        Dim UpdateScript As IO.StreamWriter = IO.File.CreateText(RunLocation & "\Update.bat")
        UpdateScript.WriteLine("taskkill /im carpc.exe")
        UpdateScript.WriteLine("timeout 5")
        UpdateScript.WriteLine("copy \\mitchell-pc\Debug\CarPc.exe C:\CarPC\CarPC.exe /y")
        UpdateScript.WriteLine("timeout 3")
        UpdateScript.WriteLine("start carpc.exe")
        UpdateScript.WriteLine("exit")
        UpdateScript.Close()

        Dim RunUpdate As New Process
        RunUpdate.StartInfo.FileName = RunLocation & "\update.bat"
        RunUpdate.StartInfo.WorkingDirectory = RunLocation
        RunUpdate.Start()

    End Sub

   

    

    Private Sub btnErrorLog_Click(sender As Object, e As EventArgs) Handles btnErrorLog.Click
        CarPCfrm.ShowErrorLog()
    End Sub

    Private Sub btnButtonControls_Click(sender As Object, e As EventArgs) Handles btnButtonControls.Click
        CarPCfrm.ShowButtonControls()
    End Sub
    Private Sub btnCameraSetupPanel_Click(sender As Object, e As EventArgs) Handles btnCameraSetupPanel.Click
        CarPCfrm.ShowCameraSetup()
    End Sub


    Private Sub btnCarStatus_Click(sender As Object, e As EventArgs) Handles btnCarStatus.Click
        CarPCfrm.ShowCarStatus()

    End Sub

    
    Private Sub btnJourneylog_Click(sender As Object, e As EventArgs) Handles btnJourneylog.Click
        CarPCfrm.ShowJourneyLog()
    End Sub


    Private Sub btnCANDecoder_Click(sender As Object, e As EventArgs) Handles btnCANDecoder.Click
        CarPCfrm.ShowCANDecoder()
               If EngineComOpen = True Then
            If SendHSCAN = True Then
                SendEngineSerialCommand("SENDMAINCAN" & Chr(13)) 'Engine CAN
            End If
            If SendLSCAN = True Then
                SendAccessSerialCommand("SENDCAN" & Chr(13)) 'ICC CAN
            End If
        End If
    End Sub

    Private Sub Option_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class
