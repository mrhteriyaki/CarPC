<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CANDecoder
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.bwProcessData = New System.ComponentModel.BackgroundWorker()
        Me.tmrCheckUpdateTime = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bwProcessData
        '
        Me.bwProcessData.WorkerSupportsCancellation = True
        '
        'tmrCheckUpdateTime
        '
        Me.tmrCheckUpdateTime.Enabled = True
        Me.tmrCheckUpdateTime.Interval = 50
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(657, 902)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CANDecoder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.Button1)
        Me.Name = "CANDecoder"
        Me.Size = New System.Drawing.Size(753, 947)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bwProcessData As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrCheckUpdateTime As Timer
    Friend WithEvents Button1 As Button
End Class
