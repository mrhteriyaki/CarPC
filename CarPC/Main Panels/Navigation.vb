Imports System.Runtime.InteropServices
Public Class Navigation
    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    'below 3 lines have been commented out to test if they are needed.
    'Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    'Private Const WM_SYSCOMMAND As Integer = 274
    'Private Const SC_MAXIMIZE As Integer = 61488


    <DllImport("user32.dll")>
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean
    End Function

    Structure RECT
        Dim Left As Integer '       // x position of upper-left corner
        Dim Top As Integer '        // y position of upper-left corner
        Dim Right As Integer '      // x position of lower-right corner
        Dim Bottom As Integer '     // y position of lower-right corner
    End Structure



    Private Sub Navigation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadNavigator()
    End Sub


    Dim proc As New Process
    Private Sub LoadNavigator()
        If My.Computer.FileSystem.FileExists("C:\Program Files (x86)\Navigator16\PC_Navigator\PC_Navigator.exe") = True Then
            Dim StartX As Decimal = 0
            Dim StartY As Decimal = 63
            Dim Program As String = "C:\Program Files (x86)\Navigator16\PC_Navigator\PC_Navigator.exe"
            Dim Arguments As String = "--atlas='C:\ProgramData\Navigator\16.0\atlas_pcn_free.idc' --window_border=no --window_position=" &
                                 StartX & "," & StartY & "," & Me.Width _
                                 & "," & Me.Height
            '(Me.Width - (5 + StartX)) & "," & (Me.Height - StartY)


            proc.StartInfo.FileName = Program
            proc.StartInfo.Arguments = Arguments

            'proc = Process.Start(Program, Arguments)
            proc.Start()
            proc.WaitForInputIdle()


            Me.Cursor = Cursors.WaitCursor
            Threading.Thread.Sleep(2500)
            Me.Cursor = Cursors.Default
            SetParent(proc.MainWindowHandle, CarPCfrm.NavigationPanel.Handle)
            SetParent(proc.Handle, CarPCfrm.NavigationPanel.Handle)

            Dim wRect As RECT = New RECT
            GetWindowRect(proc.MainWindowHandle, wRect)
            MoveWindow(proc.MainWindowHandle, 0, 0, wRect.Right - wRect.Left, wRect.Bottom - wRect.Top, True)
            GPSLoaded = True
        Else
            MsgBox("Failure loading PC Navigator")
        End If
    End Sub

   
End Class
