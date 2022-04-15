Imports System.Text.RegularExpressions

Public Class Keyboard
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    'Const KEYEVENTF_KEYUP As Long = &H2

    Dim KeyboardLetters As String() = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J" _
                                      , "K", "L", "Z", "X", "C", "V", "B", "N", "M"}
    Dim CapsButton As New Button
    Private Sub Keyboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim KeyboardWidth As Integer = Math.Round((PanelWidth / 10), 0)
        Dim LocationX As Integer = 0
        Dim LocationY As Integer = 0

        For Each Letter In KeyboardLetters
            Dim GenerateButton As New Button
            GenerateButton.Name = "btn" & Letter
            GenerateButton.Width = KeyboardWidth
            GenerateButton.Height = 60
            GenerateButton.Top = LocationY
            GenerateButton.Left = LocationX
            GenerateButton.Text = Letter
            AddHandler GenerateButton.Click, AddressOf Button_Click
            Me.Controls.Add(GenerateButton)
            LocationX += KeyboardWidth

            If LocationX = (KeyboardWidth * 10) And LocationY = 0 Then
                LocationX = 0
                LocationY = 60
            ElseIf LocationX = (KeyboardWidth * 10) And LocationY = 60 Then
                LocationX = Math.Round(KeyboardWidth / 2, 0)

                LocationY = 120

            ElseIf LocationX = ((KeyboardWidth * 9) + Math.Round(KeyboardWidth / 2, 0)) And LocationY = 120 Then

                CapsButton.Name = "btnCaps"
                CapsButton.Width = Math.Round(KeyboardWidth * 1.5, 0)
                CapsButton.Height = 60
                CapsButton.Location = New Point(0, 180)
                CapsButton.Text = "Caps"
                AddHandler CapsButton.Click, AddressOf Caps_Click
                Me.Controls.Add(CapsButton)
                LocationX = Math.Round(KeyboardWidth * 1.5, 0)
                LocationY = 180
            End If

        Next
        Dim BackspaceButton As New Button
        BackspaceButton.Name = "btnBackspace"
        BackspaceButton.Width = Math.Round(KeyboardWidth * 1.5, 0)
        BackspaceButton.Height = 60
        BackspaceButton.Text = "Backspace"
        BackspaceButton.Location = New Point(LocationX, 180)
        AddHandler BackspaceButton.Click, AddressOf BackSpace_Click
        Me.Controls.Add(BackspaceButton)
    End Sub

    Private Sub BackSpace_Click(ByVal sender As System.Object, e As System.EventArgs)
        If CurrentDisplay = DisplayPanels.Youtube Then
            CarPCfrm.YoutubePanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.SoundCloud Then
            CarPCfrm.SoundCloudPanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.Facebook Then
            CarPCfrm.FacebookPanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.Spotify Then
            CarPCfrm.SpotifyPanel.Focus()
        End If
        Call keybd_event(Keys.Back, 0, 0, 0)
        If CurrentDisplay = DisplayPanels.Youtube Then
            CarPCfrm.YoutubePanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.SoundCloud Then
            CarPCfrm.SoundCloudPanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.Facebook Then
            CarPCfrm.FacebookPanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.Spotify Then
            CarPCfrm.SpotifyPanel.Focus()
        End If
    End Sub
    Private Sub Caps_Click(ByVal sender As System.Object, e As System.EventArgs)
        If CurrentDisplay = DisplayPanels.Youtube Then
            CarPCfrm.YoutubePanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.SoundCloud Then
            CarPCfrm.SoundCloudPanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.Facebook Then
            CarPCfrm.FacebookPanel.Focus()
        End If

        Call keybd_event(System.Windows.Forms.Keys.CapsLock, &H14, 1, 0)
        Call keybd_event(System.Windows.Forms.Keys.CapsLock, &H14, 3, 0)
        'Allow keyboard event to run before checking caps-lock state.
        My.Application.DoEvents()

        If Control.IsKeyLocked(Keys.CapsLock) Then
            CapsButton.Text = "Caps: ON"
        Else
            CapsButton.Text = "Caps"
        End If


        If CurrentDisplay = DisplayPanels.Youtube Then
            CarPCfrm.YoutubePanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.SoundCloud Then
            CarPCfrm.SoundCloudPanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.Facebook Then
            CarPCfrm.FacebookPanel.Focus()
        End If
    End Sub
    Private Sub Button_Click(ByVal sender As System.Object, e As System.EventArgs)
        Dim ButtonPressed = sender.ToString.Replace("System.Windows.Forms.Button, Text: ", "")
        Dim KeyPress As Keys = GetKeyFromText(ButtonPressed)

        If CurrentDisplay = DisplayPanels.Youtube Then
            CarPCfrm.YoutubePanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.SoundCloud Then
            CarPCfrm.SoundCloudPanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.Facebook Then
            CarPCfrm.FacebookPanel.Focus()
        End If


        Call keybd_event(KeyPress, 0, 0, 0)

        If CurrentDisplay = DisplayPanels.Youtube Then
            CarPCfrm.YoutubePanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.SoundCloud Then
            CarPCfrm.SoundCloudPanel.Focus()
        ElseIf CurrentDisplay = DisplayPanels.Facebook Then
            CarPCfrm.FacebookPanel.Focus()
        End If
    End Sub

    Function GetKeyFromText(ByVal text As String) As System.Windows.Forms.Keys
        text = text.ToLower

        If text = "a" Then
            Return Keys.A
        ElseIf text = "b" Then
            Return Keys.B
        ElseIf text = "c" Then
            Return Keys.C
        ElseIf text = "d" Then
            Return Keys.D
        ElseIf text = "e" Then
            Return Keys.E
        ElseIf text = "f" Then
            Return Keys.F
        ElseIf text = "g" Then
            Return Keys.G
        ElseIf text = "h" Then
            Return Keys.H
        ElseIf text = "i" Then
            Return Keys.I
        ElseIf text = "j" Then
            Return Keys.J
        ElseIf text = "k" Then
            Return Keys.K
        ElseIf text = "l" Then
            Return Keys.L
        ElseIf text = "m" Then
            Return Keys.M
        ElseIf text = "n" Then
            Return Keys.N
        ElseIf text = "o" Then
            Return Keys.O
        ElseIf text = "p" Then
            Return Keys.P
        ElseIf text = "q" Then
            Return Keys.Q
        ElseIf text = "r" Then
            Return Keys.R
        ElseIf text = "s" Then
            Return Keys.S
        ElseIf text = "t" Then
            Return Keys.T
        ElseIf text = "u" Then
            Return Keys.U
        ElseIf text = "v" Then
            Return Keys.V
        ElseIf text = "w" Then
            Return Keys.W
        ElseIf text = "x" Then
            Return Keys.X
        ElseIf text = "y" Then
            Return Keys.Y
        ElseIf text = "z" Then
            Return Keys.Z
        ElseIf text = "0" Then
            Return Keys.D0
        ElseIf text = "1" Then
            Return Keys.D1
        ElseIf text = "2" Then
            Return Keys.D2
        ElseIf text = "3" Then
            Return Keys.D3
        ElseIf text = "4" Then
            Return Keys.D4
        ElseIf text = "5" Then
            Return Keys.D5
        ElseIf text = "6" Then
            Return Keys.D6
        ElseIf text = "7" Then
            Return Keys.D7
        ElseIf text = "8" Then
            Return Keys.D8
        ElseIf text = "9" Then
            Return Keys.D9

        End If


        Return Keys.None
    End Function

End Class
