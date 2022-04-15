
Module LogitechWebcamSettings
    Public Sub SetLogitechWebcamSettings()
        Try
            Dim cam_device_list As New List(Of String)
            Dim class_location As String = "System\CurrentControlSet\Control\Class\{6bdd1fc6-810f-11d0-bec7-08002be2092f}"
            For Each subkey In My.Computer.Registry.LocalMachine.OpenSubKey(class_location).GetSubKeyNames()
                If Not subkey = "Properties" And Not subkey = "Configuration" Then
                    If My.Computer.Registry.LocalMachine.OpenSubKey(class_location & "\" & subkey).GetValue("FriendlyName") = "Logitech HD Pro Webcam C920" Then
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\" & class_location & "\" & subkey & "\Settings", "LVUVC_AFOn", "0", Microsoft.Win32.RegistryValueKind.DWord)
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\" & class_location & "\" & subkey & "\Settings", "LVUVC_AFValue", "0", Microsoft.Win32.RegistryValueKind.DWord)
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("Failure to disable focus on Logitech Webcam (Likely registry access issue)" & ex.ToString)
        End Try
    End Sub


End Module
