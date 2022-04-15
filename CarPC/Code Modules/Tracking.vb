Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Module Tracking

    Dim UDPClient As New UdpClient
    Dim IPAdd As IPAddress
    Dim Message As String = ""
    Dim ByteData As Byte() = New Byte() {}

    Dim LastLat As Double = 0.0
    Dim LastLong As Double = 0.0

    Dim SendingTrackUpdate As Boolean = False

    Dim StopTrack As Boolean = False

    Public Sub StartTracking()
        Dim TrackProcess As Thread = New Thread(AddressOf UpdateTracking)
        TrackProcess.Start()
    End Sub


    Public Sub StopTracking()
        StopTrack = True
    End Sub

    Private Sub TrackingLoop()
        Do Until StopTrack = True
            UpdateTracking()
            Thread.Sleep(60000) '60 Seconds Loop
        Loop
    End Sub


    Private Sub UpdateTracking()
        If GPSLatitude = 0 Or GPSLongitude = 0 Or SendingTrackUpdate = True Then
            Exit Sub
        End If

        SendingTrackUpdate = True

        Try
            'Validate Lat/Long is not tangent value.
            Dim LatDiff As Double = GPSLatitude - LastLat
            If LatDiff < 0 Then
                LatDiff = LatDiff * -1
            End If
            Dim LongDiff As Double = GPSLongitude - LastLong
            If LongDiff < 0 Then
                LongDiff = LongDiff * -1
            End If

            If LatDiff < 3 And LongDiff < 3 Then
                Dim host As IPHostEntry = Dns.GetHostEntry("DNS ADDRESS GOES HERE")
                Dim ip As IPAddress() = host.AddressList

                UDPClient.Connect(IPAddress.Parse(ip(0).ToString), 23548)
                ByteData = Encoding.ASCII.GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & ";" & GPSLatitude.ToString & ";" & GPSLongitude.ToString & ";" &
                                                   Speed.ToString & ";" & RPM.ToString & ";" & Throttle.ToString)
                UDPClient.Client.SendTimeout = 1000
                UDPClient.Send(ByteData, ByteData.Length)
            End If

            LastLat = GPSLatitude
            LastLong = GPSLongitude
        Catch ex As SocketException

        End Try

        SendingTrackUpdate = False

    End Sub


End Module
