Public Class CANDecoder

    Public DataQueue As New Queue
    Public CANNode() As String
    Public CANTextBoxes() As TextBox
    Public CANUpdateTime() As Double

    Public CANNodeCount As Integer = 0
    Public LoopStart As Integer = 0

    'position data
    Public FieldTop As Integer = 10
    Public FieldLeft As Integer = 10
    Public FieldCount As Integer = -1


    Private Sub CANDecoder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bwProcessData.RunWorkerAsync()


    End Sub

    Private Sub bwProcessData_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwProcessData.DoWork
        Try
            'Generate preset list of codes order
            Dim ListFile() As String = IO.File.ReadAllLines(RunLocation & "\list.txt")
            For Each Code In ListFile
                If Code.Contains(",") Then
                    ProcessDataLine(Code.Split(",")(0) & ",0 0 0 0 0 0 0 0")

                    Dim NewNoteLabel As New Label
                    NewNoteLabel.Text = Code.Split(",")(1)
                    NewNoteLabel.Top = FieldTop - 30
                    NewNoteLabel.Left = 550
                    NewNoteLabel.Width = 200
                    NewNoteLabel.Font = New Drawing.Font("Microsoft Sans Serif", 16)
                    NewLabel = NewNoteLabel
                    AddLabel()

                Else
                    ProcessDataLine(Code & ",0 0 0 0 0 0 0 0")
                End If

            Next
        Catch ex As Exception

        End Try
        Do Until bwProcessData.CancellationPending = True Or ShuttingDown = True
            Try
                If DataQueue.Count > 0 Then
                    ProcessDataLine(DataQueue.Dequeue)
                End If
            Catch ex As Exception
                ErrorLogQueue.Enqueue("CAN Decoder error:" & ex.ToString)
            End Try
        Loop
    End Sub

    Private Sub ProcessDataLine(ByVal DataString As String)
        DataString = DataString.Replace("ICCCAN:", "")
        DataString = DataString.Replace("CAN:", "")
        Dim CANID As Integer = Integer.Parse(DataString.Split(",")(0))
        Dim CANDATA() As String = DataString.Split(",")(1).Split(" ")



        Dim ExistingNodeData As Boolean = False
        If Not CANNode Is Nothing Then
            For Each NodeID In CANNode
                If NodeID = CANID Then
                    ExistingNodeData = True
                End If
            Next
        End If



        If ExistingNodeData = False Then
            'New Node, Insert
            CANNodeCount += 1
            ReDim Preserve CANNode(CANNodeCount)
            CANNode(CANNodeCount) = CANID

            'Generate Text Fields

            Dim TBCount As Integer = (CANNodeCount * 9) - 1

            ReDim Preserve CANTextBoxes(TBCount)
            ReDim Preserve CANUpdateTime(TBCount)



            LoopStart = TBCount - 9
            Dim Counter As Integer = -1
            Do Until LoopStart = TBCount
                Counter += 1
                LoopStart += 1

                CANTextBoxes(LoopStart) = New TextBox
                CANTextBoxes(LoopStart).Name = "txtNode" & CANID & Counter
                If Counter = 0 Then
                    CANTextBoxes(LoopStart).Text = CANID
                Else
                    CANTextBoxes(LoopStart).Text = CANDATA(Counter - 1)
                End If
                CANTextBoxes(LoopStart).Top = FieldTop
                CANTextBoxes(LoopStart).Left = FieldLeft + (60 * Counter)
                CANTextBoxes(LoopStart).Font = New Drawing.Font("Microsoft Sans Serif", 14)
                CANTextBoxes(LoopStart).Width = 55
                CANTextBoxes(LoopStart).BackColor = Color.Black
                CANTextBoxes(LoopStart).ForeColor = Color.White
                CANUpdateTime(LoopStart) = DateTime.Now.Ticks

                AddTextBox()

            Loop


            'move position for next can node.

            FieldTop += 30
            FieldCount += 1
            'shift fields across when nodes count past 28.
            'If FieldCount = 25 Then
            'FieldTop = 10
            'FieldLeft += 500
            'End If

        Else

            'Update Node Data
            Dim Counter As Integer = -1
            For Each CN In CANNode
                If CN = CANID Then
                    Exit For
                End If
                Counter += 1
            Next

            Dim DataCounter As Integer = (Counter * 9)
            Dim MinorCounter As Integer = -1

            Do Until MinorCounter = 7
                MinorCounter += 1
                DataCounter += 1
                'MsgBox(DataCounter)
                If Not CANTextBoxes(DataCounter).Text = CANDATA(MinorCounter) Then
                    'update text
                    InvokeControl(CANTextBoxes(DataCounter), Sub(x) x.Text = CANDATA(MinorCounter))
                    CANUpdateTime(DataCounter) = DateTime.Now.Ticks
                End If



            Loop

        End If
    End Sub

    Private Sub AddTextBox()
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf AddTextBox))
        Else
            Me.Controls.Add(CANTextBoxes(LoopStart))

        End If
    End Sub
    Dim NewLabel As Label
    Private Sub AddLabel()
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf AddLabel))
        Else
            Me.Controls.Add(NewLabel)

        End If
    End Sub

    Sub InvokeControl(Of T As Control)(ByVal Control As T, ByVal Action As Action(Of T))
        If Control.InvokeRequired Then
            Try
                Control.Invoke(New Action(Of T, Action(Of T))(AddressOf InvokeControl), New Object() {Control, Action})
            Catch ex As Exception
            End Try
        Else
            Action(Control)
        End If
    End Sub



    Private Sub tmrCheckUpdateTime_Tick(sender As Object, e As EventArgs) Handles tmrCheckUpdateTime.Tick

        Try



            If CANUpdateTime Is Nothing Then
                Exit Sub
            End If

            Dim Counter As Integer = 0
            Do Until Counter = CANUpdateTime.Count

                Dim Difference As Long = (DateTime.Now.Ticks - CANUpdateTime(Counter)) / 10000

                If Difference < 1000 Then
                    'Difference is in MS
                    CANTextBoxes(Counter).BackColor = Color.Gray
                Else
                    CANTextBoxes(Counter).BackColor = Color.Black
                End If
                Counter += 1
            Loop

        Catch ex As Exception

        End Try

    End Sub


End Class
