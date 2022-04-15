Imports System.Runtime.InteropServices

Module VolumeControl
    <DllImport("user32.dll")>
    Function SendMessageW(ByVal hWnd As IntPtr,
               ByVal Msg As Integer, ByVal wParam As IntPtr,
               ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Const APPCOMMAND_VOLUME_MUTE As Integer = &H80000
    Private Const APPCOMMAND_VOLUME_UP As Integer = &HA0000
    Private Const APPCOMMAND_VOLUME_DOWN As Integer = &H90000
    Private Const WM_APPCOMMAND As Integer = &H319



    Public Sub VolumeUp()
        SendMessageW(CarPCfrm.Handle, WM_APPCOMMAND,
                     CarPCfrm.Handle, New IntPtr(APPCOMMAND_VOLUME_UP))
    End Sub
    Public Sub VolumeDown()
        SendMessageW(CarPCfrm.Handle, WM_APPCOMMAND,
                     CarPCfrm.Handle, New IntPtr(APPCOMMAND_VOLUME_DOWN))
    End Sub

End Module
