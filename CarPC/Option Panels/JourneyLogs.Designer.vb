<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JourneyLogs
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbxJourneys = New System.Windows.Forms.ListBox()
        Me.btnOpenLog = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbxJourneys
        '
        Me.lbxJourneys.BackColor = System.Drawing.Color.Black
        Me.lbxJourneys.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbxJourneys.ForeColor = System.Drawing.Color.White
        Me.lbxJourneys.FormattingEnabled = True
        Me.lbxJourneys.ItemHeight = 31
        Me.lbxJourneys.Location = New System.Drawing.Point(12, 12)
        Me.lbxJourneys.Name = "lbxJourneys"
        Me.lbxJourneys.Size = New System.Drawing.Size(325, 531)
        Me.lbxJourneys.TabIndex = 0
        '
        'btnOpenLog
        '
        Me.btnOpenLog.BackColor = System.Drawing.Color.Black
        Me.btnOpenLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenLog.ForeColor = System.Drawing.Color.White
        Me.btnOpenLog.Location = New System.Drawing.Point(360, 12)
        Me.btnOpenLog.Name = "btnOpenLog"
        Me.btnOpenLog.Size = New System.Drawing.Size(147, 50)
        Me.btnOpenLog.TabIndex = 1
        Me.btnOpenLog.Text = "Open Log"
        Me.btnOpenLog.UseVisualStyleBackColor = False
        '
        'JourneyLogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.btnOpenLog)
        Me.Controls.Add(Me.lbxJourneys)
        Me.Name = "JourneyLogs"
        Me.Size = New System.Drawing.Size(750, 555)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbxJourneys As System.Windows.Forms.ListBox
    Friend WithEvents btnOpenLog As System.Windows.Forms.Button

End Class
