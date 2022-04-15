
Imports System.Runtime.InteropServices


Module CarPCShared
    Public ShuttingDown As Boolean = False

    Public FullScreen As Boolean = True
    Public ResX As Integer = -1
    Public ResY As Integer = -1

    'Panel dimensions
    Public PanelWidth As Integer = -1
    Public PanelHeight As Integer = -1



    Public RunLocation As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Replace("file:\", "")


    'Engine Data Process Dataqueue
    Public EngineDataQueue As New Queue


    'GPS Config
    Public GPSPortOut As String = ""

    Public GPSLongitude As Double = 0
    Public GPSLatitude As Double = 0

    'Enable WiFi Mapper
    Public EnableWifiMapper As Boolean = False

    'Voltemeter
    Public ReverseVoltage As Double = 0
    Public MainVoltage As Double = 0
    Public device As USBMeasure.CUSBMeasureMain

    Public carpc_form_variable As CarPCfrm
    'Aircon Variables

    '1 = Feet Only
    '2 = Face Only
    '3 = Window Only
    '4 = Feet and Face
    '5 = Feet and Window




    'GPS Serial buffer, for relaying to Navigation Software.
    Public GPSSerialOutBuffer As New Queue



    'Music Variables

    Public MusicDirectory As String
    Public PlaylistsDirectory As String
    Public CurrentDirectory As String



    Public GPSLoaded As Boolean = False



    Public CarDataPath As String = "D:\CarData\"

    'Debug Panel variable
    Public DisplayonDebug As String = ""



    Public ModeState As Integer = 1
    Public ModeWindowOpen As Boolean = False


    Public CurrentDisplay As DisplayPanels


    'Video Path
    Public LocalVideoPathDirectory As String = "D:\DashCam"
    Public LocalVideoRecord As Boolean = False

    'Volume Functions
    Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    'Const KEYEVENTF_KEYUP As Long = &H2
    Public Declare Function waveOutGetVolume Lib "Winmm" (ByVal wDeviceID As Integer, dwVolume As Long) As Integer


    'AC Variables
    Public CurrentVentConfiguration As VentConfigurations = VentConfigurations.Feet
    Public TargetVentConfiguration As VentConfigurations = VentConfigurations.Feet

    Public VentTransition As Boolean = False
    Public FanManagement As Boolean = False
    Public FanSpeedTarget As Integer = 10

    Public WebsiteShow As Websites = Websites.Facebook


    'Engine Variables
    Public RPM As Integer = 0
    Public Speed As Integer = 0
    Public Throttle As Integer = 0

    'Tracking
    Public RemoteGPSTracking As Boolean = False
    'Reverse Camera
    Public SetRActive As Boolean = False

    Enum DisplayPanels
        GPS
        Music
        SoundCloud
        Youtube
        Facebook
        Spotify
        EngineInfo
        Cameras
        OptionPanel
    End Enum
    Enum Websites
        SoundCloud
        Spotify
        Youtube
        Facebook
    End Enum



    Enum VentConfigurations
        Feet
        Face
        Window
        Window_Feet
        Face_Feet
    End Enum

    Public Sub SetPanel(ByVal Panel As DisplayPanels)
        If Panel = DisplayPanels.Cameras Then
            CarPCfrm.ShowCameras()
        ElseIf Panel = DisplayPanels.EngineInfo Then
            CarPCfrm.ShowCarSystems()
        ElseIf Panel = DisplayPanels.Facebook Then
            CarPCfrm.ShowFacebookPanel()
        ElseIf Panel = DisplayPanels.GPS Then
            CarPCfrm.ShowGPS()
        ElseIf Panel = DisplayPanels.Music Then
            CarPCfrm.ShowMusicPanel()
        ElseIf Panel = DisplayPanels.OptionPanel Then
            CarPCfrm.ShowOptionPanels()
        ElseIf Panel = DisplayPanels.SoundCloud Then
            CarPCfrm.ShowSoundCloud()
        ElseIf Panel = DisplayPanels.Spotify Then
            CarPCfrm.ShowSpotifyPanel()
        ElseIf Panel = DisplayPanels.Youtube Then
            CarPCfrm.ShowYouTubePanel()
        End If
    End Sub


End Module
