'Format of Incoming String
'TIME:YYYY-MM-DD HH-mm-SS.fff;LATITUDE;LONGITUDE;SPEED;RPM;THROTTLE


'Imports for Network Data
Imports System.Net.Sockets.Socket
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.Timers
Imports System.Data
Imports System.Data.SqlClient

Public Class CarPCServer
    'Datagram Variables to Receive
    Dim IPReceive As New IPEndPoint(IPAddress.Any, 0)
    Dim RecData As Byte() = New Byte() {}

    Dim StopRec As Integer = 0
    Dim UDPRec As UdpClient = New System.Net.Sockets.UdpClient(23548)
    Dim Ending As Integer = 0
    Dim SenderIP As String = ""
   
    Dim IncomingMessages As New Queue

    Dim conn As SqlConnection

    Dim tmrProcessMessages As Timer
    Protected Overrides Sub OnStart(ByVal args() As String)
        conn = New SqlConnection("Data Source=LOCALHOST\CARPC;Initial Catalog=CARPC; user=carpc; password=carpc")
        bwReceiver.RunWorkerAsync()
        tmrProcessMessages = New Timer(50)
        AddHandler tmrProcessMessages.Elapsed, New ElapsedEventHandler(AddressOf tmrProcessMessages_Tick)
        tmrProcessMessages.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Ending = 1
    End Sub

    Private Sub bwReceiver_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bwReceiver.DoWork
        Do Until Ending = 1
            Try
                UDPRec.Client.ReceiveTimeout = 500
                RecData = New Byte() {}
                RecData = UDPRec.Receive(IPReceive)
                SenderIP = IPReceive.Address.ToString

                'Declare message = UDP Packet in ASCII
             
                IncomingMessages.Enqueue(System.Text.Encoding.ASCII.GetString(RecData))
               
            Catch ex As Exception
                Console.Write(ex)
            End Try
        Loop
    End Sub


    Dim LastLat As Double = 0.0
    Dim LastLong As Double = 0.0

    Private Sub tmrProcessMessages_Tick(sender As Object, e As EventArgs)
       
        If Not IncomingMessages.Count = 0 Then
            Try
                Dim Message As String = IncomingMessages.Dequeue()




                Dim SplitMessage() As String = Message.Split(";")
                Dim Time As String = SplitMessage(0)
                Dim Lattitude As String = SplitMessage(1)
                Dim Longitude As String = SplitMessage(2)
                Dim Speed As String = SplitMessage(3)
                Dim RPM As String = SplitMessage(4)
                Dim Throttle As String = SplitMessage(5)

                Dim LatDiff As Double = Double.Parse(Lattitude) - LastLat
                If LatDiff < 0 Then
                    LatDiff = LatDiff * -1
                End If
                Dim LongDiff As Double = Double.Parse(Longitude) - LastLong
                If LongDiff < 0 Then
                    LongDiff = LongDiff * -1
                End If

                If LatDiff < 3 And LongDiff < 3 Then



                    'Insert data into SQL
                    conn.Open()

                    Dim QUERY As String = "USE [CARPC] INSERT INTO tblJourney ([Time],[Lattitude],[Longitude],[Speed],[RPM],[Throttle]) VALUES " & _
                        "('" & Time & "','" & Lattitude & "','" & Longitude & "','" & Speed & "','" & RPM & "','" & Throttle & "')"

                    Dim SQLQueryINSERT As New SqlCommand(QUERY, conn)

                    Try
                        SQLQueryINSERT.ExecuteReader()
                    Catch ex As Exception
                        Dim SQLLOG As New IO.StreamWriter("C:\CARPCSERVER\SQL.LOG")
                        SQLLOG.WriteLine("QUERY:" & QUERY)
                        SQLLOG.WriteLine()
                        SQLLOG.WriteLine(ex.ToString)
                        SQLLOG.Close()
                    End Try

                    conn.Close()
              
                End If

                LastLat = Double.Parse(Lattitude)
                LastLong = Double.Parse(Longitude)

            Catch ex As Exception
                Dim SQLLOG As New IO.StreamWriter("C:\CARPCSERVER\ERROR.LOG")
                SQLLOG.WriteLine(ex.ToString)
                SQLLOG.Close()
            End Try
        End If

    End Sub
End Class
