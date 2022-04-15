
Imports TagLib


'Imports SpeechLib
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.ComponentModel


Public Class CarPCfrm

    'Panels
    Public MusicPanel As Music
    Public MediaControlPanel As MediaControls
    Public PlaylistPanel As Playlist
    Public MediaInfoPanel As MediaInfo
    Public MusicLibraryPanel As New MusicLibrary
    Public MusicFileBrowser As FileBrowser
    Public MusicPlaylistLibrary As PlaylistLibrary
    Public CANDecoderPanel As CANDecoder
    Public SearchPanel As SearchControl
    Public EnginePanel As New EngineInfo
    Public CameraPanel As Cameras
    Public NavigationPanel As Navigation
    Public OptionPanel As Option_Panel
    Public CarStatusPanel As Car_Status
    Public ErrorLogPanel As ErrorLog
    Public ButtonControlPanel As SWControls
    Public JourneyLogPanel As JourneyLogs
    Public CameraSetupPanel As CameraSetup

    Public KeyboardPanel As Keyboard




    Public SoundCloudPanel As SoundCloud
    Public SpotifyPanel As Spotify
    Public YoutubePanel As YouTube
    Public FacebookPanel As Facebook


    <DllImport("user32.dll")>
    Shared Function SetActiveWindow(ByVal hwnd As Integer) As Integer
    End Function

    Dim test As Integer = 0

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carpc_form_variable = Me



        'Possible startup delay from win 10 caused by:
        'HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Serialize
        'Add dword StartupDelayinMSec
        'value = 0



        'Initiate random number generator
        Randomize()
        'Set Serial port settings.
        SetSerialPortSettings()

        LoadConfigurationFile()



        If ResX = -1 Or ResY = -1 Then
            ResX = 768
            ResY = 1366
        End If
        If FullScreen = True Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        End If

        Me.Width = ResX + 20
        Me.Height = ResY
        Me.Location = New Point(0, 0)


        'Load Configuration File config.ini


        btnGPS.Location = New Point(0, (PanelHeight - btnGPS.Height) + 63)
        btnMusic.Location = New Point(110, (PanelHeight - btnMusic.Height + 63))
        btnSoundCloud.Location = New Point(220, (PanelHeight - btnSoundCloud.Height) + 63)
        btnCarSystems.Location = New Point(330, (PanelHeight - btnCarSystems.Height) + 63)
        btnCamera.Location = New Point(440, (PanelHeight - btnCamera.Height) + 63)
        btnDebug.Location = New Point(550, (PanelHeight - btnDebug.Height) + 63)
        btnExit.Location = New Point(660, (PanelHeight - btnExit.Height) + 63)



        'Reduce panel height for button size
        PanelHeight -= btnExit.Height

        'Setup Panels
        InitializePanels()

        'gpbxAudioControls.Location = New Point(((ResX / 2) - ((gpbxAudioControls.Width) / 2)) + 100, ResY - 180) 'offset center

        'Start Serial COM Link threads.

        Dim enginecomthread As New Threading.Thread(Sub() EngineSerialThread())
        enginecomthread.Start()

        Dim accesscomthread As New Threading.Thread(Sub() AccessSerialThread())
        accesscomthread.Start()



        'Initialize camera page (Required to startup video feeds and recordings)
        ShowCameras()


        'Load car systems as primary page
        ShowCarSystems()



        MusicPanel.WMPlayer.settings.volume = 100 '(AudioAPI.OUT_MasterScalar * 100)
        MusicPanel.WMPlayer.settings.autoStart = True
        MusicPanel.WMPlayer.Location = New Point(3, 3)
        MusicPanel.WMPlayer.uiMode = "none" 'sets wmplayer to just show the media (no controls)




        If My.Computer.FileSystem.DirectoryExists(MusicDirectory) = True Then
            'Load Root folders for file browser.
            For Each Folder In Delimon.Win32.IO.Directory.GetDirectories(MusicDirectory)
                Dim FolderItem As String = Folder.Replace(MusicDirectory, Nothing)
                If Not FolderItem = "Playlists" Then
                    MusicFileBrowser.lbxCurrentFolder.Items.Add(FolderItem)
                End If
            Next
            MusicFileBrowser.ListFiles()
        End If

        'Load Last State / Status to Resume Playback
        If My.Computer.FileSystem.FileExists(RunLocation & "\Status.carpc") = True Then
            Dim StatusFile() As String = IO.File.ReadAllLines(RunLocation & "\Status.carpc")
            'set playback of file indicated by index number. 3 = play, 1 = stopped.
            If StatusFile(1) = "1" Then
                PlaylistPanel.setPlaylistIndex(StatusFile(0), False)
            Else
                PlaylistPanel.setPlaylistIndex(StatusFile(0), True)
            End If


            MusicPanel.WMPlayer.Ctlcontrols.currentPosition = StatusFile(2)
            If StatusFile.Count >= 4 Then
                If StatusFile(3).ToLower.Contains("airconvents=") Then
                    EnginePanel.StartAirconVentConfiguration(StatusFile(3).Replace("airconvents=", ""))
                Else
                    EnginePanel.StartAirconVentConfiguration("NONE")
                End If
            Else
                EnginePanel.StartAirconVentConfiguration("NONE")
            End If

        End If


        txtTime.Visible = True
        btnGPS.Visible = True
        btnMusic.Visible = True
        btnCarSystems.Visible = True
        btnCamera.Visible = True
        btnDebug.Visible = True
        btnExit.Visible = True
        btnSoundCloud.Visible = True



        Dim DelayedStartupThread As System.Threading.Thread = New System.Threading.Thread(AddressOf DelayedStartup)
        DelayedStartupThread.Start()





    End Sub


    Public Sub ShowModeForm()
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf ShowModeForm))
        Else
            frmModeWindow.Show()
        End If
    End Sub
    Private Sub DelayedStartup()
        StartLoggers() 'Start logging threads for error logs, can logs and journey logs.

        SetLogitechWebcamSettings()

        'AC Management
        Dim ACLoopThread As New Threading.Thread(Sub() AirconditioningLoop())
        ACLoopThread.Start()

        'Prevent lockup if starting up and exiting.
        If ShuttingDown = True Then
            Exit Sub
        End If
        'Delayed processes that are not required at imediate start, improving the load time of form.

        StartGPSRelay() 'Start GPS relay thread

        If RemoteGPSTracking = True Then
            'Start GPS Tracker if configured in config file.
            StartTracking()
        End If

        'Start thread that sends OBD Queries
        Dim OBDThread As New Threading.Thread(AddressOf OBDLoopThread)
        OBDThread.Start()

        'Volt Meter thread
        Dim StartVoltThread As New System.Threading.Thread(Sub() VoltageMonitorThread())
        StartVoltThread.Start()


        'Rear Auxillary Arduino control link
        Dim AuxThread As New System.Threading.Thread(AddressOf RunRearControl)
        AuxThread.Start()


        'Load Bad Smell Zone Checker
        LoadBadSmellLocations()
        'start thread to loop location check.
        Dim BadSmellThread As Threading.Thread = New Threading.Thread(Sub() BadSmellLoop())
        BadSmellThread.Start()

        'music search index
        Dim StartSearchIndexThread As New Threading.Thread(Sub() SearchIndexThread())
        StartSearchIndexThread.Start()



    End Sub






    Private Sub InitializePanels()
        'Navigation panel is initilized by first button press.
        'Offset panelheight by clock field (clockfield is 63 height).

        MediaControlPanel = New MediaControls
        Controls.Add(MediaControlPanel)
        'May need to be changed as media control buttons are located at the bottom
        MediaControlPanel.Location = New Point(0, PanelHeight + 173)

        'Engine Panel
        Controls.Add(EnginePanel)
        EnginePanel.Visible = False
        EnginePanel.Location = New Point(0, 63)
        EnginePanel.Height = PanelHeight



        'Music Panels
        'Windows Media Player Panel
        MusicPanel = New Music
        MusicPanel.Visible = False
        MusicPanel.Location = New Point(-1, 63)
        MusicPanel.Height = (PanelHeight - 90)
        Controls.Add(MusicPanel)


        'Currently playing Audio information panel
        MediaInfoPanel = New MediaInfo
        MediaInfoPanel.Visible = False
        MediaInfoPanel.Location = New Point(0, MusicPanel.Height + 63)
        MediaInfoPanel.Height = 90 'Use offset of musicpanel (-90)
        MediaInfoPanel.Width = PanelWidth
        Controls.Add(MediaInfoPanel)

        'Current playlist panel
        PlaylistPanel = New Playlist
        PlaylistPanel.Visible = False
        PlaylistPanel.Location = New Point(415, 138)
        PlaylistPanel.Height = PanelHeight
        Controls.Add(PlaylistPanel)
        'Load playlist data.
        PlaylistPanel.LoadStartupPlaylist()



        'Music - Media Library Panels
        MusicFileBrowser = New FileBrowser
        MusicFileBrowser.Visible = False
        MusicFileBrowser.Location = New Point(0, 75 + 63)
        'MusicFileBrowser.Height = PanelHeight 
        Controls.Add(MusicFileBrowser)


        MusicLibraryPanel.Visible = False
        MusicLibraryPanel.Location = New Point(0, 63)
        MusicLibraryPanel.Height = 75
        Controls.Add(MusicLibraryPanel)

        MusicPlaylistLibrary = New PlaylistLibrary
        MusicPlaylistLibrary.Visible = False
        MusicPlaylistLibrary.Location = New Point(0, 75 + 63)
        MusicPlaylistLibrary.Height = (PanelHeight - 75)
        MusicPlaylistLibrary.Width = 415
        Controls.Add(MusicPlaylistLibrary)

        'Search Panel
        SearchPanel = New SearchControl
        SearchPanel.Location = New Point(0, 60 + 63)
        SearchPanel.Visible = False
        'Height is default panel size
        'SearchPanel.Height = PanelHeight
        Controls.Add(SearchPanel)

        'Camera Panels
        CameraPanel = New Cameras
        CameraPanel.DashCamRecording = LocalVideoRecord
        CameraPanel.DashCamRecordPath = LocalVideoPathDirectory
        CameraPanel.Visible = False
        CameraPanel.Location = New Point(0, 63)
        CameraPanel.Width = PanelWidth + 15
        CameraPanel.Height = PanelHeight
        Controls.Add(CameraPanel)

        'Keyboard Panel
        KeyboardPanel = New Keyboard
        KeyboardPanel.Visible = False
        KeyboardPanel.Location = New Point(0, 0)
        KeyboardPanel.Width = PanelWidth
        KeyboardPanel.Height = 240
        Controls.Add(KeyboardPanel)




        OptionPanel = New Option_Panel
        OptionPanel.Visible = False
        Controls.Add(OptionPanel)
        OptionPanel.Location = New Point(0, 63)
        OptionPanel.Height = PanelHeight


        CarStatusPanel = New Car_Status
        CarStatusPanel.Visible = False
        Controls.Add(CarStatusPanel)
        CarStatusPanel.Location = New Point(0, 60 + 63)
        CarStatusPanel.Height = (PanelHeight - CarStatusPanel.Location.Y)

        ErrorLogPanel = New ErrorLog
        ErrorLogPanel.Visible = False
        Controls.Add(ErrorLogPanel)
        ErrorLogPanel.Location = New Point(0, 60 + 63)
        ErrorLogPanel.Height = (PanelHeight - ErrorLogPanel.Location.Y)

        ButtonControlPanel = New SWControls
        ButtonControlPanel.Visible = False
        Controls.Add(ButtonControlPanel)
        ButtonControlPanel.Location = New Point(0, 60 + 63)
        ButtonControlPanel.Height = (PanelHeight - ButtonControlPanel.Location.Y)

        CameraSetupPanel = New CameraSetup
        CameraSetupPanel.Visible = False
        Controls.Add(CameraSetupPanel)
        CameraSetupPanel.Location = New Point(0, 60 + 63)
        CameraSetupPanel.Height = (PanelHeight - CameraSetupPanel.Location.Y)



        JourneyLogPanel = New JourneyLogs
        JourneyLogPanel.Visible = False
        Controls.Add(JourneyLogPanel)
        JourneyLogPanel.Location = New Point(0, 60 + 63)
        JourneyLogPanel.Height = (PanelHeight - JourneyLogPanel.Location.Y)


        'CAN Decoder
        CANDecoderPanel = New CANDecoder
        CANDecoderPanel.Visible = False
        CANDecoderPanel.Location = New Point(0, 60 + 63)
        CANDecoderPanel.Height = (PanelHeight - CANDecoderPanel.Location.Y) + 50


        Controls.Add(CANDecoderPanel)


    End Sub

    Private Sub LoadConfigurationFile()
        Dim TextFile As String() = IO.File.ReadAllLines(RunLocation & "\config.ini")
        For Each Line In TextFile
            If Line.ToLower.Contains("resolution=") Then
                'ResX x ResY
                ResX = Line.ToLower.Replace("resolution=", Nothing).Split("x")(0)
                PanelWidth = ResX
                ResY = Line.ToLower.Replace("resolution=", Nothing).Split("x")(1)
                PanelHeight = ResY - 173
            End If
            If Line.ToLower.Contains("accesscom=") Then
                AcessComPortNumber = Line.ToLower.Replace("accesscom=", Nothing)
            End If
            If Line.ToLower.Contains("enginecom=") Then
                EngineComPortNumber = Line.ToLower.Replace("enginecom=", Nothing)
            End If
            If Line.ToLower.Contains("rearcom=") Then
                RearComPortNumber = Line.ToLower.Replace("rearcom=", Nothing)
            End If

            If Line.ToLower.Contains("musicdir=") Then
                MusicDirectory = Line.Replace("musicdir=", Nothing)
                If Not MusicDirectory.Substring(MusicDirectory.Count - 1) = "\" Then
                    MusicDirectory = MusicDirectory & "\"
                End If
                CurrentDirectory = MusicDirectory
            End If


            If Line.ToLower.Contains("playlists=") Then
                PlaylistsDirectory = Line.Replace("playlists=", Nothing)
            End If

            If Line.ToLower.Contains("gpsserialout=") Then
                GPSPortOut = Line.Replace("gpsserialout=", Nothing)
            End If

            If Line.ToLower.Contains("cardata=") Then
                CarDataPath = Line.Replace("cardata=", Nothing)
            End If

            If Line.ToLower.Contains("debug=true") Then
                DebugingEnabled = True
            End If

            If Line.ToLower.Contains("hscandebug=true") Then
                SendHSCAN = True
            End If

            If Line.ToLower.Contains("lscandebug=true") Then
                SendLSCAN = True
            End If

            If Line.ToLower.Contains("wifiscanner=true") Then
                EnableWifiMapper = True
            End If

            If Line.ToLower.Contains("fullscreen=false") Then
                FullScreen = False
            End If

            If Line.ToLower.Contains("tracking=true") Then
                RemoteGPSTracking = True
            End If


            If Line.ToLower.Contains("dashcamstorage=") Then
                LocalVideoPathDirectory = Line.Replace("dashcamstorage=", "")
                'strip \ if last character is \
                If LocalVideoPathDirectory.Substring(LocalVideoPathDirectory.Length - 1, 1) = "\" Then
                    LocalVideoPathDirectory = LocalVideoPathDirectory.Substring(0, LocalVideoPathDirectory.Length - 1)
                End If
            End If
            If Line.ToLower.Contains("dashcamrecording=true") Then
                LocalVideoRecord = True
            End If


            If Line.ToLower.StartsWith("homepos=") Then
                Dim home_Data As String = Line.Substring(8)
                HomeLatitude = Double.Parse(home_Data.Split(",")(0))
                HomeLongitude = Double.Parse(home_Data.Split(",")(1))
            End If

        Next

        If Not CarDataPath.Substring(CarDataPath.Count - 1) = "\" Then
            CarDataPath = CarDataPath & "\"
        End If

        If My.Computer.FileSystem.FileExists(RunLocation & "\values.ini") = True Then
            ButtonValues = IO.File.ReadAllLines(RunLocation & "\values.ini")
        End If

    End Sub





    Private Sub MainForm_Closing(sender As Object, e As EventArgs) Handles Me.FormClosing
        ShutdownProcedure()
    End Sub

    Private Sub ShutdownProcedure()

        ShuttingDown = True
        'Wait for dashcam recorder to finish up (Needs to write out file).
        Do Until CameraPanel.Recording_Worker_Ready_For_Shutdown = True
            Threading.Thread.Sleep(50)
        Loop

        WriteStatusFile()
        WritePlaylistFile()

        If GPSLoaded = True Then
            Process.Start("taskkill", "/f /im PC_Navigator.exe")
        End If


    End Sub

    Private Sub WritePlaylistFile()
        If My.Computer.FileSystem.FileExists(RunLocation & "\Playlist.carpc") = True Then
            My.Computer.FileSystem.DeleteFile(RunLocation & "\Playlist.carpc")
        End If

        Dim PlaylistFile As IO.StreamWriter
        PlaylistFile = IO.File.CreateText(RunLocation & "\Playlist.carpc")
        For Each File In MusicArr
            PlaylistFile.WriteLine(File)
        Next
        PlaylistFile.Close()
    End Sub
    Private Sub WriteStatusFile()
        If My.Computer.FileSystem.FileExists(RunLocation & "\Status.carpc") = True Then
            My.Computer.FileSystem.DeleteFile(RunLocation & "\Status.carpc")
        End If

        'Save Current State of Music Player
        Dim StatusFile As IO.StreamWriter
        StatusFile = IO.File.CreateText(RunLocation & "\Status.carpc")
        StatusFile.WriteLine(PlaylistPanel.lbxPlaylist.SelectedIndex) '0
        StatusFile.WriteLine(MusicPanel.WMPlayer.playState) '1
        StatusFile.WriteLine(MusicPanel.WMPlayer.Ctlcontrols.currentPosition) '2
        'Aircon status '3
        If CurrentVentConfiguration = VentConfigurations.Face Then
            StatusFile.WriteLine("airconvents=face")
        ElseIf CurrentVentConfiguration = VentConfigurations.Feet Then
            StatusFile.WriteLine("airconvents=feet")
        ElseIf CurrentVentConfiguration = VentConfigurations.Face_Feet Then
            StatusFile.WriteLine("airconvents=face_feet")
        ElseIf CurrentVentConfiguration = VentConfigurations.Window Then
            StatusFile.WriteLine("airconvents=window")
        ElseIf CurrentVentConfiguration = VentConfigurations.Window_Feet Then
            StatusFile.WriteLine("airconvents=window_feet")
        End If

        StatusFile.Close()
    End Sub
    Private Sub btnGPS_Click(sender As Object, e As EventArgs) Handles btnGPS.Click
        ShowGPS()
    End Sub
    Public Sub ShowGPS()
        If GPSLoaded = False Then
            'Navigation Panel
            NavigationPanel = New Navigation
            NavigationPanel.Visible = False
            NavigationPanel.Location = New Point(0, 63)
            NavigationPanel.Height = PanelHeight
            NavigationPanel.Width = PanelWidth
            Controls.Add(NavigationPanel)
            GPSLoaded = True
        End If

        btnGPS.Enabled = False
        HidePanels()
        NavigationPanel.Visible = True
        NavigationPanel.BringToFront()
        btnGPS.Enabled = True
        CurrentDisplay = DisplayPanels.GPS


    End Sub

    Private Sub HidePanels()
        If GPSLoaded = True Then
            NavigationPanel.Visible = False
        End If
        EnginePanel.Visible = False
        SearchPanel.Visible = False
        CameraPanel.Visible = False


        PlaylistPanel.Visible = False
        MusicPanel.Visible = False
        MediaInfoPanel.Visible = False
        MusicFileBrowser.Visible = False
        MusicLibraryPanel.Visible = False
        MusicPlaylistLibrary.Visible = False


        OptionPanel.Visible = False
        CarStatusPanel.Visible = False
        ErrorLogPanel.Visible = False
        ButtonControlPanel.Visible = False
        CameraSetupPanel.Visible = False

        JourneyLogPanel.Visible = False
        CANDecoderPanel.Visible = False


        If SoundCloudLoaded = True Then
            SoundCloudPanel.Visible = False
        End If

        If SpotifyLoaded = True Then
            SpotifyPanel.Visible = False
        End If

        If YoutubeLoaded = True Then
            YoutubePanel.Visible = False
        End If

        If FacebookLoaded = True Then
            FacebookPanel.Visible = False
        End If
        KeyboardPanel.Visible = False


    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnMusic_Click(sender As Object, e As EventArgs) Handles btnMusic.Click
        ShowMusicPanel()
    End Sub

    Public Sub ShowMusicPanel()

        btnMusic.Enabled = False
        HidePanels()
        MusicPanel.Visible = True
        MediaInfoPanel.Visible = True
        MusicPanel.BringToFront()
        MediaInfoPanel.BringToFront()
        MediaControlPanel.BringToFront()
        btnMusic.Enabled = True


        If CurrentDisplay = DisplayPanels.Music Then
            'If current display is in music panel, cycle through the music sub-panels.
            If CurrentMusicPanelLayout = MusicPanelLayout.None Then
                SetMusicPanelLayout(MusicPanelLayout.PlayerandPlaylist)
            ElseIf CurrentMusicPanelLayout = MusicPanelLayout.PlayerandPlaylist Then
                SetMusicPanelLayout(MusicPanelLayout.PlayerOnly)
            ElseIf CurrentMusicPanelLayout = MusicPanelLayout.PlayerOnly Then
                SetMusicPanelLayout(MusicPanelLayout.MusicBrowser)
            ElseIf CurrentMusicPanelLayout = MusicPanelLayout.MusicBrowser Then
                SetMusicPanelLayout(MusicPanelLayout.PlayerandPlaylist)
            End If

        Else
            CurrentDisplay = DisplayPanels.Music
            'If panel is not music panel, go to player and playlist.
            If PlayerState = MediaState.Stopped Or PlayerState = MediaState.Pause Then
                SetMusicPanelLayout(MusicPanelLayout.MusicBrowser)
            Else
                SetMusicPanelLayout(MusicPanelLayout.PlayerandPlaylist)
            End If

        End If




    End Sub



    Private Sub tmrLabels_Tick(sender As Object, e As EventArgs) Handles tmrLabels.Tick
        txtTime.Text = DateTime.Now.ToString("HH:mm")
        If GPSLongitude = 0 Or GPSLatitude = 0 Then
            lblLocation.Text = "No GPS Signal"
        Else
            lblLocation.Text = "Longitude:" & GPSLongitude & " , Latitude:" & GPSLatitude
        End If


    End Sub





    Private Sub btnCarSystems_Click(sender As Object, e As EventArgs) Handles btnCarSystems.Click
        ShowCarSystems()
    End Sub
    Public Sub ShowCarSystems()
        btnCarSystems.Enabled = False
        HidePanels()
        EnginePanel.Visible = True
        EnginePanel.BringToFront()
        btnCarSystems.Enabled = True
        CurrentDisplay = DisplayPanels.EngineInfo

        MediaInfoPanel.Visible = True
        MediaInfoPanel.Location = New Point(0, (EnginePanel.Location.Y + EnginePanel.Height) - 93)
        MediaInfoPanel.BringToFront()
    End Sub

    Public Sub SetPreviousPanel()
        PreviousPanel = CurrentDisplay
    End Sub


    Public Sub ShowCameras()

        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf ShowCameras))
        Else
            If Not CurrentDisplay = DisplayPanels.Cameras Then
                HidePanels()
                CameraPanel.Visible = True
                CameraPanel.BringToFront()
                CurrentDisplay = DisplayPanels.Cameras
            Else
                CameraPanel.CycleCameraLayout()
            End If
        End If
    End Sub



    Function CheckValidMediaFile(ByVal File As String) As Boolean
        For Each FT In MediaFileTypes
            If File.EndsWith(FT, StringComparison.OrdinalIgnoreCase) = True Then
                Return True
            End If
        Next
        Return False
    End Function


    Private Sub btnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        ShowOptionPanels()
    End Sub
    Public Sub ShowOptionPanels()
        'First time intialize panels, moved from inital form_load event to reduce startup time for non-essential panels.


        If Not CurrentDisplay = DisplayPanels.OptionPanel Then
            btnDebug.Enabled = False
            HidePanels()
            OptionPanel.Visible = True
            OptionPanel.BringToFront()
            ShowCarStatus()
            btnDebug.Enabled = True
            CurrentDisplay = DisplayPanels.OptionPanel
        End If
    End Sub




    Public Sub RevertPanel()
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf RevertPanel))
        Else
            SetPanel(PreviousPanel)
        End If
    End Sub

    'SetRAACtive = reverse gear selected
    Dim PreviousPanel As DisplayPanels


    Private Sub btnCamera_Click(sender As Object, e As EventArgs) Handles btnCamera.Click
        ShowCameras()
    End Sub


    Dim GPSOpen As Boolean = False

    Public Sub ShowCANDecoder()
        HideOptionPanels()
        CANDecoderPanel.Visible = True
        CANDecoderPanel.BringToFront()
    End Sub
    Public Sub ShowCarStatus()
        HideOptionPanels()
        CarStatusPanel.Visible = True
        CarStatusPanel.BringToFront()
    End Sub
    Public Sub ShowErrorLog()
        HideOptionPanels()
        ErrorLogPanel.Visible = True
        ErrorLogPanel.BringToFront()
    End Sub

    Public Sub ShowButtonControls()
        HideOptionPanels()
        ButtonControlPanel.Visible = True
        ButtonControlPanel.BringToFront()
    End Sub

    Public Sub ShowCameraSetup()
        HideOptionPanels()
        CameraSetupPanel.Visible = True
        CameraSetupPanel.BringToFront()
    End Sub

    Public Sub ShowJourneyLog()
        HideOptionPanels()
        JourneyLogPanel.Visible = True
        JourneyLogPanel.BringToFront()
    End Sub

    Public Sub HideOptionPanels()
        CarStatusPanel.Visible = False
        ErrorLogPanel.Visible = False
        ButtonControlPanel.Visible = False
    End Sub


    'Set positions for Music Panels
    Enum MusicPanelLayout
        None
        PlayerOnly
        PlayerandPlaylist
        MusicBrowser
    End Enum
    Dim CurrentMusicPanelLayout As MusicPanelLayout = MusicPanelLayout.None

    Public Sub SetMusicPanelLayout(ByVal LayoutType As MusicPanelLayout)
        If Not CurrentDisplay = DisplayPanels.Music Then
            Exit Sub
        End If


        If LayoutType = MusicPanelLayout.PlayerOnly Then
            MusicPanel.Width = PanelWidth
            MusicPanel.Height = PanelHeight
            MusicPanel.Visible = True
            MediaInfoPanel.Visible = False
            PlaylistPanel.Visible = False
            'PlaylistPanel.Height = (PanelHeight - 90) 

            SearchPanel.Visible = False
            MusicLibraryPanel.Visible = False
            MusicFileBrowser.Visible = False
            MusicPlaylistLibrary.Visible = False
        End If

        If LayoutType = MusicPanelLayout.PlayerandPlaylist Then
            Dim TotalPanelHeight As Integer = PanelHeight - 90
            'Video Panel sizing
            Dim HeightCalc As Integer = Math.Round(TotalPanelHeight / 2, 0)
            If VideoMode = False Then
                HeightCalc = Math.Round(TotalPanelHeight / 4, 0)
            End If


            MusicPanel.Width = PanelWidth
            MusicPanel.Height = HeightCalc
            MusicPanel.Visible = True

            MediaInfoPanel.Visible = True
            MediaInfoPanel.Location = New Point(0, MusicPanel.Location.Y + MusicPanel.Height)


            PlaylistPanel.Visible = True
            PlaylistPanel.Height = TotalPanelHeight - MusicPanel.Height
            PlaylistPanel.Width = PanelWidth
            PlaylistPanel.Location = New Point(MusicPanel.Location.X, MediaInfoPanel.Location.Y + MediaInfoPanel.Height)

            SearchPanel.Visible = False
            MusicLibraryPanel.Visible = False
            MusicFileBrowser.Visible = False
            MusicPlaylistLibrary.Visible = False
        End If

        If LayoutType = MusicPanelLayout.MusicBrowser Then
            MusicLibraryPanel.Visible = True

            PlaylistPanel.Visible = True
            PlaylistPanel.Location = New Point(895, 0)

            PlaylistPanel.Height = PanelHeight

            MusicPanel.Visible = False
            MediaInfoPanel.Visible = False

            SetMusicLibraryType(MusicLibraryPanel.SelectedLibrary)
        End If

        CurrentMusicPanelLayout = LayoutType
    End Sub




    Public Sub LogCANLine(ByVal LogData As String)
        'canline is Dim variable.
        Dim HourSeconds As Double = Integer.Parse(DateTime.Now.ToString("HH")) * 3600
        Dim MinuteSeconds As Double = Integer.Parse(DateTime.Now.ToString("mm")) * 60
        Dim Seconds As Double = HourSeconds + MinuteSeconds + Integer.Parse(DateTime.Now.ToString("ss"))
        DebugCANList.Add(Seconds & "." & DateTime.Now.ToString("fff") & ";" & LogData)
    End Sub













    'Dim SpotifyPanel As spot
    Private Sub btnSoundCloud_OnClick(sender As Object, e As EventArgs) Handles btnSoundCloud.Click
        WebPortalPrompt.Show()
        WebPortalPrompt.BringToFront()
        'Init on first load.
    End Sub
    Public Sub LoadWebPanel()
        If WebsiteShow = Websites.SoundCloud Then
            ShowSoundCloud()
        ElseIf WebsiteShow = Websites.Spotify Then
            ShowSpotifyPanel()
        ElseIf WebsiteShow = Websites.Youtube Then
            ShowYouTubePanel()
        ElseIf WebsiteShow = Websites.Facebook Then
            ShowFacebookPanel()
        End If
    End Sub
    Public Sub ShowSoundCloud()
        If SoundCloudLoaded = False Then
            'Web STreamer
            SoundCloudPanel = New SoundCloud
            Controls.Add(SoundCloudPanel)
            SoundCloudPanel.Location = New Point(0, 63)
            SoundCloudPanel.Height = PanelHeight - 240
            SoundCloudPanel.Width = PanelWidth + 15


            KeyboardPanel.Location = New Point(0, SoundCloudPanel.Location.Y + SoundCloudPanel.Height)

            SoundCloudLoaded = True
        End If

        SoundCloudPanel.Show()
        KeyboardPanel.Show()
        SoundCloudPanel.BringToFront()
        KeyboardPanel.BringToFront()
        KeyboardPanel.Visible = True
        SoundCloudPanel.Visible = True
        CurrentDisplay = DisplayPanels.SoundCloud
    End Sub
    Public Sub ShowSpotifyPanel()
        If SpotifyLoaded = False Then
            'Web STreamer
            SpotifyPanel = New Spotify
            Controls.Add(SpotifyPanel)
            SpotifyPanel.Location = New Point(0, 63)
            SpotifyPanel.Height = PanelHeight
            SpotifyPanel.Width = PanelWidth + 15

            SpotifyLoaded = True
        End If
        SpotifyPanel.Show()
        SpotifyPanel.BringToFront()
        SpotifyPanel.Visible = True
        CurrentDisplay = DisplayPanels.Spotify
    End Sub
    Public Sub ShowYouTubePanel()
        If YoutubeLoaded = False Then
            'Web STreamer
            YoutubePanel = New YouTube
            Controls.Add(YoutubePanel)
            YoutubePanel.Location = New Point(0, 63)
            YoutubePanel.Height = PanelHeight - 240
            YoutubePanel.Width = PanelWidth + 15


            KeyboardPanel.Location = New Point(0, YoutubePanel.Location.Y + YoutubePanel.Height)
            YoutubeLoaded = True


        End If
        YoutubePanel.Show()
        KeyboardPanel.Show()

        KeyboardPanel.BringToFront()
        YoutubePanel.BringToFront()
        KeyboardPanel.Visible = True
        YoutubePanel.Visible = True
        CurrentDisplay = DisplayPanels.Youtube

    End Sub

    Public Sub ShowFacebookPanel()
        If FacebookLoaded = False Then
            'Web STreamer
            FacebookPanel = New Facebook
            Controls.Add(FacebookPanel)
            FacebookPanel.Location = New Point(0, 63)
            FacebookPanel.Height = PanelHeight - 240
            FacebookPanel.Width = PanelWidth + 15

            KeyboardPanel.Location = New Point(0, FacebookPanel.Location.Y + FacebookPanel.Height)

            FacebookLoaded = True
        End If
        FacebookPanel.Show()
        KeyboardPanel.Show()
        CurrentDisplay = DisplayPanels.Facebook

        FacebookPanel.BringToFront()
        KeyboardPanel.BringToFront()

        FacebookPanel.Visible = True
        KeyboardPanel.Visible = True
    End Sub



    Dim KeyboardOpen As Boolean = False
    Dim KeyboardProcess As Process
    Public Sub KeyboardShowHide()
        If KeyboardOpen = False Then
            KeyboardProcess = New Process
            KeyboardProcess.StartInfo.FileName = "C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe"
            KeyboardProcess.Start()

            KeyboardOpen = True
        Else
            Dim Processes() As Process = Process.GetProcessesByName("TabTip")
            For Each proc In Processes
                proc.Kill()

            Next
            KeyboardOpen = False
        End If
    End Sub


    Public Sub SetMusicLibraryType(ByVal LS As MusicLibrary.LibrarySelected)
        If LS = MusicLibrary.LibrarySelected.FileBrowser Then
            MusicFileBrowser.Visible = True
            MusicPlaylistLibrary.Visible = False
            SearchPanel.Visible = False
            PlaylistPanel.Location = New Point(MusicFileBrowser.Location.X, MusicFileBrowser.Location.Y + MusicFileBrowser.Height)
            PlaylistPanel.Width = MusicFileBrowser.Width
            PlaylistPanel.Height = PanelHeight - MusicFileBrowser.Height
        ElseIf LS = MusicLibrary.LibrarySelected.Playlists Then
            MusicFileBrowser.Visible = False
            MusicPlaylistLibrary.Visible = True
            PlaylistPanel.Location = New Point(MusicPlaylistLibrary.Location.X + MusicPlaylistLibrary.Width, MusicPlaylistLibrary.Location.Y)
            PlaylistPanel.Width = PanelWidth - MusicPlaylistLibrary.Width
            PlaylistPanel.Height = MusicPlaylistLibrary.Height
            SearchPanel.Visible = False
        ElseIf LS = MusicLibrary.LibrarySelected.Search Then
            MusicFileBrowser.Visible = False
            MusicPlaylistLibrary.Visible = False
            SearchPanel.Visible = True
            PlaylistPanel.Location = New Point(MusicFileBrowser.Location.X, SearchPanel.Location.Y + SearchPanel.Height)
            PlaylistPanel.Width = SearchPanel.Width
            PlaylistPanel.Height = PanelHeight - PlaylistPanel.Location.Y
        End If
    End Sub


    Public PlayerState As MediaState = MediaState.Stopped
    Enum MediaState
        Play
        Pause
        Stopped
    End Enum


    Public Sub SetPlayerState(ByVal NewState As MediaState)
        If NewState = MediaState.Play Then
            MediaControlPanel.btnPlay.Image = CarPC.My.Resources.Resources.Pause
            PlayerState = MediaState.Play
        ElseIf NewState = MediaState.Pause Then
            MediaControlPanel.btnPlay.Image = CarPC.My.Resources.Resources.Play
            PlayerState = MediaState.Pause
        ElseIf NewState = MediaState.Stopped Then
            MediaControlPanel.btnPlay.Image = CarPC.My.Resources.Resources.Play
            PlayerState = MediaState.Stopped
        End If

    End Sub


End Class

'progress bar, only vertical
Public Class MyVerticalProgessBar
    Inherits ProgressBar
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or &H4
            Return cp
        End Get
    End Property
End Class

'List box without scrollbar
Public Class MyListBox
    Inherits ListBox
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style And Not &H200000   ' Turn off WS_VSCROLL style
            Return cp
        End Get
    End Property
End Class


Public Class GaugeGraphic
    Inherits AGauge
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style
            Return cp
        End Get
    End Property
End Class


