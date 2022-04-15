Module WiFi_Scanner

    Public WiFiScannerStop As Boolean = False
    Public WifiScansData As String = ""


    Private Sub WiFiScan()
        Try


            If My.Computer.FileSystem.DirectoryExists(RunLocation & "\WifiScans") = False Then
                My.Computer.FileSystem.CreateDirectory(RunLocation & "\WifiScans")
            End If

            Dim netsh As New Process
            netsh.StartInfo.FileName = "netsh.exe"
            netsh.StartInfo.Arguments = "wlan show networks mode=bssid"
            netsh.StartInfo.RedirectStandardError = True
            netsh.StartInfo.RedirectStandardOutput = True
            netsh.StartInfo.UseShellExecute = False
            netsh.StartInfo.CreateNoWindow = True
            Dim NetworkCount As Integer = -1
            Dim SSID(0) As String
            Dim Channel(0) As String
            Dim Signal(0) As String
            Dim Authentication(0) As String

            'check if wifi network interface available
            netsh.Start()
            If netsh.StandardOutput.ReadToEnd.ToString.Contains("There is no wireless interface on the system.") = True Then
                WiFiScannerStop = True
            End If

            Do Until WiFiScannerStop = True
                Try

                    netsh.Start()
                    Dim str As String = netsh.StandardOutput.ReadToEnd
                    Dim strArr() As String = str.Split(Environment.NewLine)
                    Dim strArrCount As Integer = strArr.Count
                    Dim Count As Integer = 4

                    Do Until Count = strArrCount - 1
                        'SSID
                        NetworkCount += 1
                        ReDim Preserve SSID(NetworkCount)
                        SSID(NetworkCount) = strArr(Count).Split(":")(1).Substring(1)

                        'Auth Type
                        ReDim Preserve Authentication(NetworkCount)
                        Count += 2
                        Authentication(NetworkCount) = strArr(Count).Split(":")(1).Substring(1)

                        'Signal Level
                        ReDim Preserve Signal(NetworkCount)
                        Count += 3
                        Signal(NetworkCount) = strArr(Count).Split(":")(1).Substring(1)

                        'Channel
                        ReDim Preserve Channel(NetworkCount)
                        Count += 2
                        Channel(NetworkCount) = strArr(Count).Split(":")(1).Substring(1)
                        Count += 4

                        'Log Output
                        If WifiScansData.Contains(SSID(NetworkCount) & ";" & Authentication(NetworkCount) & ";" & Channel(NetworkCount) & ";" & GPSLatitude & "," & GPSLongitude) = False Then
                            WifiScansData &= SSID(NetworkCount) & ";" & Authentication(NetworkCount) & ";" & Channel(NetworkCount) & ";" & GPSLatitude & "," & GPSLongitude & ";" & Signal(NetworkCount) & Environment.NewLine
                        End If

                    Loop
                    Threading.Thread.Sleep(1000)
                Catch ex As Exception
                    If DebugingEnabled = True Then
                        ErrorLogQueue.Enqueue("Wifi Scanner Crash: " & ex.ToString)
                    End If
                    'Stop Scanner
                    WiFiScannerStop = True
                End Try
            Loop

        Catch ex As Exception
            If DebugingEnabled = True Then
                ErrorLogQueue.Enqueue("Wifi Scanner BW Crash: " & ex.ToString)
            End If

        End Try
    End Sub



End Module
