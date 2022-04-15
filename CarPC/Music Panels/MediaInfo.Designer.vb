<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MediaInfo
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
        Me.components = New System.ComponentModel.Container()
        Me.lblSongTime = New System.Windows.Forms.Label()
        Me.pbSongTime = New System.Windows.Forms.ProgressBar()
        Me.lblMediaPlayerText = New System.Windows.Forms.Label()
        Me.tmrSongTime = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSongTimeLabel = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblSongTime
        '
        Me.lblSongTime.AutoSize = True
        Me.lblSongTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSongTime.ForeColor = System.Drawing.Color.White
        Me.lblSongTime.Location = New System.Drawing.Point(332, 0)
        Me.lblSongTime.Name = "lblSongTime"
        Me.lblSongTime.Size = New System.Drawing.Size(95, 24)
        Me.lblSongTime.TabIndex = 24
        Me.lblSongTime.Text = "Time Text"
        '
        'pbSongTime
        '
        Me.pbSongTime.Location = New System.Drawing.Point(7, 73)
        Me.pbSongTime.Name = "pbSongTime"
        Me.pbSongTime.Size = New System.Drawing.Size(100, 21)
        Me.pbSongTime.TabIndex = 23
        '
        'lblMediaPlayerText
        '
        Me.lblMediaPlayerText.AutoSize = True
        Me.lblMediaPlayerText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMediaPlayerText.ForeColor = System.Drawing.Color.White
        Me.lblMediaPlayerText.Location = New System.Drawing.Point(3, 0)
        Me.lblMediaPlayerText.Name = "lblMediaPlayerText"
        Me.lblMediaPlayerText.Size = New System.Drawing.Size(130, 24)
        Me.lblMediaPlayerText.TabIndex = 22
        Me.lblMediaPlayerText.Text = "MetaData Text"
        '
        'tmrSongTime
        '
        '
        'tmrSongTimeLabel
        '
        Me.tmrSongTimeLabel.Interval = 1000
        '
        'MediaInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.lblSongTime)
        Me.Controls.Add(Me.pbSongTime)
        Me.Controls.Add(Me.lblMediaPlayerText)
        Me.Name = "MediaInfo"
        Me.Size = New System.Drawing.Size(694, 106)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSongTime As System.Windows.Forms.Label
    Friend WithEvents pbSongTime As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMediaPlayerText As System.Windows.Forms.Label
    Friend WithEvents tmrSongTime As System.Windows.Forms.Timer
    Friend WithEvents tmrSongTimeLabel As System.Windows.Forms.Timer

End Class
