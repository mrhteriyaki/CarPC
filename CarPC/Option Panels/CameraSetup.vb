Imports DirectShowLib
Public Class CameraSetup
    Dim camera_label_list As New List(Of Camera_Label)
    Dim button_list As New List(Of ButtonSetCamera)
    Private Sub CameraSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim count As Integer = -1
        For Each CID In DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)
            count += 1
            Dim YPoint As Integer = (count * 250) + 30

            Dim cid_label As New Camera_Label
            cid_label.camera_name = "Camera: " & CID.Name
            cid_label.Width = 450
            cid_label.Location = New Point(20, YPoint)
            cid_label.ForeColor = Color.White
            cid_label.camera_id = CID.DevicePath
            cid_label.Name = "CAMLabel" & count
            cid_label.label_count = count

            camera_label_list.Add(cid_label)
            Me.Controls.Add(cid_label)

            Dim SetFront As New ButtonSetCamera
            Dim SetDash As New ButtonSetCamera
            Dim SetRear As New ButtonSetCamera

            SetBtnDetails(SetFront)
            SetBtnDetails(SetDash)
            SetBtnDetails(SetRear)

            SetFront.Text = "Set Front"
            SetDash.Text = "Set Dash"
            SetRear.Text = "Set Rear"

            SetFront.Name = "btnSetFront" & count
            SetDash.Name = "btnSetDash" & count
            SetRear.Name = "btnSetRear" & count


            SetFront.camera_id = CID.DevicePath
            SetDash.camera_id = CID.DevicePath
            SetRear.camera_id = CID.DevicePath

            SetFront.Location = New Point(500, YPoint)
            SetDash.Location = New Point(500, YPoint + 50)
            SetRear.Location = New Point(500, YPoint + 100)
            AddHandler SetFront.Click, AddressOf ClickSetButton
            AddHandler SetDash.Click, AddressOf ClickSetButton
            AddHandler SetRear.Click, AddressOf ClickSetButton

            Me.Controls.Add(SetFront)
            Me.Controls.Add(SetDash)
            Me.Controls.Add(SetRear)

            button_list.Add(SetFront)
            button_list.Add(SetDash)
            button_list.Add(SetRear)

        Next

        RefreshSetCameras()
    End Sub

    Private Sub ClickSetButton(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ButtonSetCamera = DirectCast(sender, ButtonSetCamera)

        If btn.Text = "Set Front" Then
            UpdateCameraID(btn.camera_id, "Front=")
        ElseIf btn.Text = "Set Dash" Then
            UpdateCameraID(btn.camera_id, "Dash=")
        ElseIf btn.Text = "Set Rear" Then
            UpdateCameraID(btn.camera_id, "Rear=")
        End If
        RefreshSetCameras()
    End Sub

    Private Sub UpdateCameraID(ByVal new_string As String, ByVal replace_value As String)
        Dim tmp_file() As String = IO.File.ReadAllLines(RunLocation & "\CameraGUID.ini")
        Dim new_file As New IO.StreamWriter(RunLocation & "\CameraGUID.tmp")
        For Each line In tmp_file
            If line.StartsWith(replace_value) Then
                new_file.WriteLine(replace_value & new_string)
            Else
                'remove camera from any other locations and set to off.
                'Replace does nothing if the camera is another, leaving the setting as-is.
                new_file.WriteLine(line.Replace(new_string, "off"))

            End If
        Next
        new_file.Close()

        My.Computer.FileSystem.RenameFile(RunLocation & "\CameraGUID.ini", "CameraGUID.old")
        My.Computer.FileSystem.RenameFile(RunLocation & "\CameraGUID.tmp", "CameraGUID.ini")
        My.Computer.FileSystem.DeleteFile(RunLocation & "\CameraGUID.old")

    End Sub

    Private Sub SetBtnDetails(ByRef button As ButtonSetCamera)
        button.ForeColor = Color.White
        button.BackColor = Color.Black
        button.Size = New Size(200, 50)
    End Sub


    Private Sub RefreshSetCameras()
        Dim current_camera_config As String() = IO.File.ReadAllLines(RunLocation & "\CameraGUID.ini")

        'Reset all labels.
        For Each camera_label In camera_label_list
            Me.Controls(camera_label.Name).Text = camera_label.camera_name
        Next
        For Each camera_btn In button_list
            Me.Controls(camera_btn.Name).BackColor = Color.Black
        Next


        For Each cam_id In current_camera_config
            If cam_id.StartsWith("Front=") Or cam_id.StartsWith("Dash=") Or cam_id.StartsWith("Rear=") Then
                Dim cid As String = cam_id.Split("=")(1)
                For Each camera_label In camera_label_list
                    If camera_label.camera_id = cid Then
                        Me.Controls(camera_label.Name).Text = camera_label.camera_name & "(Currently Set as:" & cam_id.Split("=")(0) & "Camera)"
                        If cam_id.StartsWith("Front=") Then
                            Me.Controls("btnSetFront" & camera_label.label_count).BackColor = Color.DarkGray
                        ElseIf cam_id.StartsWith("Dash=") Then
                            Me.Controls("btnSetDash" & camera_label.label_count).BackColor = Color.DarkGray
                        ElseIf cam_id.StartsWith("Rear=") Then
                            Me.Controls("btnSetRear" & camera_label.label_count).BackColor = Color.DarkGray
                        End If
                    End If
                Next
            End If
        Next

    End Sub

End Class


Class ButtonSetCamera
    Inherits Button
    Public camera_id As String

End Class

Class Camera_Label
    Inherits Label
    Public label_count As String
    Public camera_id As String
    Public camera_name As String
End Class