Imports Emgu.CV

Imports Emgu.CV.Structure

Imports DirectShowLib
Imports System.Threading

Public Class Cameras
    'Camera0 = Front Bar
    'Camera1 = Dash
    'Camera2 = Rear


    Dim Camera0 As Capture
    Dim Camera0Init As Boolean = False
    Dim CameraImage0 As Image(Of Bgr, Byte) 'These are EmguCV image types, not system types


    Dim Camera0IntGUID As Integer = -1


    Dim Camera1 As Capture
    Dim Camera1Init As Boolean = False
    Dim CameraImage1 As Image(Of Bgr, Byte)
    Dim CameraImage1Mat As Mat

    Dim Camera1IntGUID As Integer = -1

    'Once RecordOK = true, capture will start.
    Dim RecordOK As Boolean = False
    Dim FootagePath As String = ""


    Dim Camera2 As Capture
    Dim Camera2Init As Boolean = False
    Dim CameraImage2 As Image(Of Bgr, Byte)

    Dim Camera2IntGUID As Integer = -1

    'Video Capture Variable
    Public DashCamRecordPath As String = "D:\Dashcam"


    'Variable is coppied to local Camera panel as background worker cannot access primary thread.
    Public DashCamRecording As Boolean = False


    Private Sub Cameras_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Try
            Camera0.Dispose()
        Catch ex As Exception

        End Try
        Try
            Camera1.Dispose()
        Catch ex As Exception

        End Try
        Try
            Camera2.Dispose()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Cameras_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim SystemCameras() As DsDevice = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)
        Dim CameraLocations As String() = IO.File.ReadAllLines(RunLocation & "\CameraGUID.ini")
        'Set Normal Layout
        SetCameraLayout(CameraLayouts.Normal)

        'Match Cam.DevicePath to Camera integer
        Dim Count As Integer = -1
        For Each Camera In SystemCameras
            Count += 1
            If Camera.DevicePath = CameraLocations(0).Replace("Front=", "") Then
                'Match Camera Device Location with Front Camera
                Camera0IntGUID = Count
                'Start Camera Initialisation
                If CameraLocations(0).ToLower.Contains("off") Then
                    pbxFrontBar.Visible = False
                Else
                    bwCamera0.RunWorkerAsync()
                End If



            ElseIf Camera.DevicePath = CameraLocations(1).Replace("Dash=", "") Then
                Camera1IntGUID = Count
                If CameraLocations(1).ToLower.Contains("off") Then
                    pbxDashCam.Visible = False
                Else
                    bwCamera1.RunWorkerAsync()
                End If

            ElseIf Camera.DevicePath = CameraLocations(2).Replace("Rear=", "") Then
                Camera2IntGUID = Count
                If CameraLocations(2).ToLower.Contains("off") Then
                    pbxRearCamera.Visible = False
                Else
                    bwCamera2.RunWorkerAsync()
                End If

            End If
        Next

        'Set CameraIntGUID to assign correct cameras to front/rear/dash


        'Check conditions ok to start recording.
        If DashCamRecording = True Then
            Dim SaveDirectory As String = DashCamRecordPath & "\" & DateTime.Today.ToString("yyyy-MM-dd") & "\"
            FootagePath = SaveDirectory & "DashCam-"
            Dim LocationOK As Boolean = True
            If My.Computer.FileSystem.DirectoryExists(SaveDirectory) = False Then
                Try
                    My.Computer.FileSystem.CreateDirectory(SaveDirectory)
                Catch ex As Exception
                    'Failure to access directory, disable recording, exit sub.
                    LocationOK = False
                End Try
            End If


            If GetFreeSpace() > 10 And LocationOK = True Then
                'Freespace less than 30gb, disable recording
                RecordOK = True
                bwDashRecorder.RunWorkerAsync()
            Else

                RecordOK = False
            End If
        End If

    End Sub

    'Limit Loop retrys - possible issues with memory filling up causing crash.
    Dim Retry0 As Integer = 3
    Dim Retry1 As Integer = 3
    Dim Retry2 As Integer = 3

    Private Sub bwCamera0_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwCamera0.DoWork
        Do Until Camera0Init = True Or Retry0 = 0 Or ShuttingDown = True
            Retry0 -= 1
            Try
                Camera0 = New Capture(Camera0IntGUID)
                Camera0Init = True
            Catch ex As Exception
                'Failure to init camera capture, retry in 2 seconds.
            End Try
            If Camera0Init = False Then
                Threading.Thread.Sleep(50)
            End If
        Loop

        If Camera0Init = True Then
            Do Until ShuttingDown = True
                Try
                    CameraImage0 = Camera0.QueryFrame.ToImage(Of Bgr, Byte)
                    CameraImage0 = CameraImage0.Flip(CvEnum.FlipType.Vertical)

                    If CameraImage0 IsNot Nothing Then
                        InvokeControl(pbxFrontBar, Sub(x) x.Image = CameraImage0.ToBitmap)
                    End If

                    Threading.Thread.Sleep(34)
                Catch ex As Exception

                End Try
            Loop

        End If

    End Sub



    Dim FrameResolution As New Size(1280, 720)

    Private Sub bwCamera1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwCamera1.DoWork
        'Dash Camera

        'Connect to camera.
        Do Until Camera1Init = True Or Retry1 = 0
            Retry1 -= 1
            Try

                Camera1 = New Capture(Camera1IntGUID)


                'Camera1 = New Capture()
                'Camera1.SetCaptureProperty(CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 1920)
                'Camera1.SetCaptureProperty(CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 1080)
                'Camera1.SetCaptureProperty(CvEnum.CapProp.FrameWidth, 960)
                'Camera1.SetCaptureProperty(CvEnum.CapProp.FrameHeight, 540)
                Camera1.SetCaptureProperty(CvEnum.CapProp.FrameWidth, FrameResolution.Width)
                Camera1.SetCaptureProperty(CvEnum.CapProp.FrameHeight, FrameResolution.Height)
                Camera1Init = True
            Catch ex As Exception
                'Failure to init camera capture, retry in 2 seconds.
            End Try
            If Camera1Init = False Then
                Threading.Thread.Sleep(50)
            End If
        Loop



        'Loop and display images.
        If Camera1Init = True Then
            'Set Camera Resolution
            Do Until ShuttingDown = True
                Try
                    CameraImage1Mat = Camera1.QueryFrame
                    CameraImage1 = CameraImage1Mat.ToImage(Of Bgr, Byte)
                    If CameraImage1 IsNot Nothing Then
                        InvokeControl(pbxDashCam, Sub(x) x.BackgroundImage = CameraImage1.ToBitmap)
                    End If
                Catch ex As Exception

                End Try
            Loop
        End If
    End Sub

    Private Sub bwCamera2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwCamera2.DoWork
        Do Until Camera2Init = True Or Retry2 = 0
            Retry2 -= 1
            Try
                Camera2 = New Capture(Camera2IntGUID)
                Camera2Init = True
            Catch ex As Exception
                'Failure to init camera capture, retry in 2 seconds.
            End Try
            If Camera2Init = False Then
                Threading.Thread.Sleep(50)
            End If

            If Camera2Init = True Then
                Do Until ShuttingDown = True
                    Try

                        CameraImage2 = Camera2.QueryFrame.ToImage(Of Bgr, Byte)
                        If CameraImage2 IsNot Nothing Then
                            InvokeControl(pbxRearCamera, Sub(x) x.Image = CameraImage2.ToBitmap)
                        End If

                        Threading.Thread.Sleep(34)
                    Catch ex As Exception

                    End Try
                Loop
            End If
        Loop
    End Sub


    Enum CameraLayouts
        Normal
        FrontOnly
        DashOnly
        RearOnly
    End Enum
    Dim CurrentCameraLayout As CameraLayouts = CameraLayouts.Normal

    Public Sub CycleCameraLayout()
        If CurrentCameraLayout = CameraLayouts.Normal Then
            SetCameraLayout(CameraLayouts.FrontOnly)
        ElseIf CurrentCameraLayout = CameraLayouts.FrontOnly Then
            SetCameraLayout(CameraLayouts.DashOnly)
        ElseIf CurrentCameraLayout = CameraLayouts.DashOnly Then
            SetCameraLayout(CameraLayouts.RearOnly)
        ElseIf CurrentCameraLayout = CameraLayouts.RearOnly Then
            SetCameraLayout(CameraLayouts.Normal)
        End If
    End Sub
    Public Sub SetCameraLayout(ByVal Layout As CameraLayouts)
        CurrentCameraLayout = Layout
        If Layout = CameraLayouts.Normal Then
            Dim HalfWidth As Integer = CInt(Me.Width / 2)
            Dim HalfHeight As Integer = CInt(Me.Height / 2)

            'Place at 0,0
            pbxFrontBar.Width = Me.Width
            pbxFrontBar.Height = CInt(Me.Height / 3)
            pbxFrontBar.Location = New Point(0, 0)
            'Place next to front bar image.
            pbxDashCam.Width = Me.Width
            pbxDashCam.Height = CInt(Me.Height / 3)
            pbxDashCam.Location = New Point(0, pbxFrontBar.Location.Y + pbxFrontBar.Height)
            'Place below other cameras, centered between the 2 images.
            Dim CentrePosition As Integer = CInt(HalfWidth / 2)
            pbxRearCamera.Width = Me.Width
            pbxRearCamera.Height = CInt(Me.Height / 3)
            pbxRearCamera.Location = New Point(0, pbxDashCam.Location.Y + pbxDashCam.Height)

            pbxFrontBar.Visible = True
            pbxDashCam.Visible = True
            pbxRearCamera.Visible = True
        ElseIf Layout = CameraLayouts.FrontOnly Then
            pbxFrontBar.Width = Me.Width
            pbxFrontBar.Height = Me.Height
            pbxFrontBar.Location = New Point(0, 0)

            pbxFrontBar.Visible = True
            pbxDashCam.Visible = False
            pbxRearCamera.Visible = False
        ElseIf Layout = CameraLayouts.DashOnly Then
            pbxDashCam.Width = Me.Width
            pbxDashCam.Height = Me.Height
            pbxDashCam.Location = New Point(0, 0)

            pbxFrontBar.Visible = False
            pbxDashCam.Visible = True
            pbxRearCamera.Visible = False
        ElseIf Layout = CameraLayouts.RearOnly Then
            pbxRearCamera.Width = Me.Width
            pbxRearCamera.Height = Me.Height
            pbxRearCamera.Location = New Point(0, 0)

            pbxFrontBar.Visible = False
            pbxDashCam.Visible = False
            pbxRearCamera.Visible = True
        End If
    End Sub

    Function GetFreeSpace() As String


        'free space / 1073741824 = gigabytes
        Dim Freespace As Double = -1
        For Each Driveinf As System.IO.DriveInfo In My.Computer.FileSystem.Drives
            If Driveinf.Name.Contains(DashCamRecordPath.Substring(0, 3)) Then
                Freespace = Double.Parse(Driveinf.AvailableFreeSpace) / 1073741824
            End If
        Next
        Return Freespace

    End Function
    Function GetOldestVideoFile() As String
        Dim OldestDate As DateTime = DateTime.Now
        Dim OldestFile As String = ""
        For Each FileName In My.Computer.FileSystem.GetFiles(DashCamRecordPath, FileIO.SearchOption.SearchAllSubDirectories)
            Dim FileInfo As New System.IO.FileInfo(FileName)
            If FileInfo.LastWriteTime < OldestDate Then
                OldestDate = FileInfo.LastWriteTime
                OldestFile = FileName
            End If
        Next

        Return OldestFile

    End Function
    Function GetVideoFolderSize() As Double
        Dim FolderSize As Double = 0
        For Each FileName In My.Computer.FileSystem.GetFiles(DashCamRecordPath, FileIO.SearchOption.SearchAllSubDirectories)
            Dim FileInfo As New System.IO.FileInfo(FileName)
            FolderSize += FileInfo.Length
        Next
        FolderSize = FolderSize / 1073741824
        Return FolderSize
    End Function
    Function GetVideoCount() As Integer
        Return My.Computer.FileSystem.GetFiles(DashCamRecordPath, FileIO.SearchOption.SearchAllSubDirectories).Count
    End Function
    Private Sub CleanupVideoStorage()
        If My.Computer.FileSystem.DirectoryExists(DashCamRecordPath) = False Then
            MsgBox("Dashcam Record Directory does not exist")
            Exit Sub

        End If

        'Validate video storage size

        'If video folder is larger than limit in gigabytes.
        Dim Limit As Integer = 20

        If GetVideoCount() >= 5 Then
            'Remove oldest videos until only either lattest 5 remain, or if video folder is under the GB Limit
            Do Until GetVideoCount() <= 5 Or GetVideoFolderSize() < Limit

                My.Computer.FileSystem.DeleteFile(GetOldestVideoFile)
            Loop
        End If

    End Sub

    Dim Recording_Worker_Started As Boolean = False
    Dim Recording_Worker_Complete_Shutdown As Boolean = False

    Public Function Recording_Worker_Ready_For_Shutdown() As Boolean
        If Recording_Worker_Started = False Then
            Return True 'Recording worker never started, return ok for shutdown
        End If

        If Recording_Worker_Started = True And Recording_Worker_Complete_Shutdown = True Then
            Return True 'recording started and completed, return ok for shutdown.
        End If

        'Recording worker running and not finished.
        Return False
    End Function

    Private Sub bwDashRecorder_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwDashRecorder.DoWork


        'Loop until camera is ready.
        Do Until Camera1Init = True Or ShuttingDown = True
            Threading.Thread.Sleep(200)
        Loop
        If ShuttingDown = True Then
            Exit Sub
        End If


        'Worker started (shutdown function will hold until finished).
        'Must run after camera1init = true loop (otherwise shutdown will hang).
        Recording_Worker_Started = True


        'Dim Camera1Writer As VideoWriter = New VideoWriter(FootagePath, CvInvoke.CV_FOURCC("D", "I", "V", "3"), 30, Width, Height, True)
        ' CvInvoke.CV_FOURCC("D", "I", "V", "3")

        '-1 = user select
        'Testing logitech codec = CvInvoke.CV_FOURCC("I", "4", "2", "0")
        'CV_FOURCC("P","I&quo­t;,"M","1") = MPEG-1
        'CV_FOURCC("M","J&quo­t;,"P","G") = motion-jpeg
        'CV_FOURCC("M", "P", "4", "2") = MPEG-4.2
        'CV_FOURCC("D", "I", "V", "3") = MPEG-4.3
        'CV_FOURCC("D", "I", "V", "X") = MPEG-4
        'CV_FOURCC("U", "2", "6", "3") = H263
        'CV_FOURCC("I", "2", "6", "3") = H263I
        'CV_FOURCC("F", "L", "V", "1") = FLV1

        Try
            If RecordOK = True And DashCamRecording = True Then
                'Secondary loop to split files into 10 minute blocks.
                Do Until ShuttingDown = True
                    'Cleanup video files to ensure disk space ok.
                    CleanupVideoStorage()
                    If GetFreeSpace() < 10 Then
                        ErrorLogQueue.Enqueue("Free Space on Dashcam disk is less than 10gb, record process stopped.")
                        Exit Do
                    End If

                    Dim FINALPath As String = FootagePath & DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-f") & ".avi"

                    Dim Counter As Integer = -1
                    'CvInvoke.CV_FOURCC("X", "2", "6", "4")

                    'Dim Camera1Writer As VideoWriter = New VideoWriter(FINALPath, CvInvoke.CV_FOURCC("X", "2", "6", "4"), 15, RecordWidth, RecordHeight, True)
                    Dim Camera1Writer As VideoWriter = New VideoWriter(FINALPath, VideoWriter.Fourcc("X", "2", "6", "4"), 15, FrameResolution, True)

                    'Camera1Writer.Dispose()

                    Do Until ShuttingDown = True Or Counter > 4500 '4500 = 5 minute blocks '27000
                        Dim StartFrameTime As Integer = Integer.Parse(DateTime.Now.ToString("fff"))
                        Counter += 1
                        If CameraImage1Mat IsNot Nothing Then
                            Dim TmpMat As Mat = CameraImage1Mat 'Copy Mat into temporary variable to prevent memory corruption issue.
                            Camera1Writer.Write(TmpMat)
                        End If
                        '41 = 24fps
                        '66 = 15fps
                        Dim Duration As Integer = 0
                        Do Until Duration > 66
                            Dim TimeNow As Integer = Integer.Parse(DateTime.Now.ToString("fff"))
                            If StartFrameTime > TimeNow Then
                                StartFrameTime -= 1000
                            End If
                            Duration = TimeNow - StartFrameTime
                        Loop
                    Loop
                    Camera1Writer.Dispose()

                    If My.Computer.FileSystem.FileExists(FINALPath) Then
                        Dim FinalFileInfo As New IO.FileInfo(FINALPath)
                        'Less than 200 bytes, delete file. (Either too small for use or crashed file.)
                        If FinalFileInfo.Length < 200 Then
                            My.Computer.FileSystem.DeleteFile(FINALPath)
                        End If
                    End If
                Loop
            End If
        Catch ex As Exception
            MsgBox("Dash recorder processor fail:" & ex.ToString)
        End Try

        Recording_Worker_Complete_Shutdown = True
    End Sub





End Class
