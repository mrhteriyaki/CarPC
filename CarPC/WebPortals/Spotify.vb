Imports System.Runtime.InteropServices
Public Class Spotify
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Private Const KEYEVENTF_KEYDOWN As Integer = &H0
    Private Const KEYEVENTF_KEYUP As Integer = &H2
    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer

    <DllImport("user32.dll")>
    Public Shared Function SetActiveWindow(ByVal hwnd As Integer) As Integer
    End Function

    Dim proc As New Process

    <DllImport("user32.dll")> _
    Private Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean
    End Function

    Structure RECT
        Dim Left As Integer '       // x position of upper-left corner
        Dim Top As Integer '        // y position of upper-left corner
        Dim Right As Integer '      // x position of lower-right corner
        Dim Bottom As Integer '     // y position of lower-right corner
    End Structure
    Private Sub Spotify_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadSpotify()
    End Sub


    Private Sub LoadSpotify()
        If My.Computer.FileSystem.FileExists("C:\Users\Mitchell\AppData\Roaming\Spotify\Spotify.exe") = True Then
            Dim Program As String = "C:\Users\Mitchell\AppData\Roaming\Spotify\Spotify.exe"
            proc.StartInfo.FileName = Program
            proc.Start()
            proc.WaitForInputIdle()
            Me.Cursor = Cursors.WaitCursor
            Threading.Thread.Sleep(2500)
            Me.Cursor = Cursors.Default
            SetParent(proc.MainWindowHandle, CarPCfrm.SpotifyPanel.Handle)
            SetParent(proc.Handle, CarPCfrm.SpotifyPanel.Handle)

            Dim wRect As RECT = New RECT
            GetWindowRect(proc.MainWindowHandle, wRect)
            MoveWindow(proc.MainWindowHandle, 0, 0, PanelWidth, PanelHeight, True)

        End If
    End Sub

    Private Sub SetFocusSpotify()
        Dim SpotifyProcessDiag As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("Spotify").FirstOrDefault
        SetActiveWindow(SpotifyProcessDiag.MainWindowHandle)
    End Sub

    Public Sub NextSong()
        SetFocusSpotify()
        Call keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYDOWN, 0)
        Call keybd_event(Keys.Right, 0, KEYEVENTF_KEYDOWN, 0)
        Call keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0)
        Call keybd_event(Keys.Right, 0, KEYEVENTF_KEYUP, 0)
    End Sub
    Public Sub PlayPause()
        SetFocusSpotify()
        Call keybd_event(Keys.Space, 0, 0, 0)
    End Sub

    Public Sub PreviousSong()
        SetFocusSpotify()
        Call keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYDOWN, 0)
        Call keybd_event(Keys.Left, 0, KEYEVENTF_KEYDOWN, 0)
        Call keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0)
        Call keybd_event(Keys.Left, 0, KEYEVENTF_KEYUP, 0)
    End Sub


End Class
