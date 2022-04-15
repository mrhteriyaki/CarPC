<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MediaControls
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaControls))
        Me.tmrVolume = New System.Windows.Forms.Timer(Me.components)
        Me.btnShuffle = New System.Windows.Forms.Button()
        Me.btnFav = New System.Windows.Forms.Button()
        Me.btnVolumeDown = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnVolumeUp = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tmrVolume
        '
        Me.tmrVolume.Interval = 50
        '
        'btnShuffle
        '
        Me.btnShuffle.BackColor = System.Drawing.Color.Black
        Me.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShuffle.Image = Global.CarPC.My.Resources.Resources.Shuffle_Off
        Me.btnShuffle.Location = New System.Drawing.Point(550, 0)
        Me.btnShuffle.Name = "btnShuffle"
        Me.btnShuffle.Size = New System.Drawing.Size(110, 110)
        Me.btnShuffle.TabIndex = 11
        Me.btnShuffle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnShuffle.UseVisualStyleBackColor = False
        '
        'btnFav
        '
        Me.btnFav.BackColor = System.Drawing.Color.Black
        Me.btnFav.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFav.Image = CType(resources.GetObject("btnFav.Image"), System.Drawing.Image)
        Me.btnFav.Location = New System.Drawing.Point(660, 0)
        Me.btnFav.Name = "btnFav"
        Me.btnFav.Size = New System.Drawing.Size(110, 110)
        Me.btnFav.TabIndex = 13
        Me.btnFav.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFav.UseVisualStyleBackColor = False
        '
        'btnVolumeDown
        '
        Me.btnVolumeDown.BackColor = System.Drawing.Color.Black
        Me.btnVolumeDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolumeDown.Image = CType(resources.GetObject("btnVolumeDown.Image"), System.Drawing.Image)
        Me.btnVolumeDown.Location = New System.Drawing.Point(440, 55)
        Me.btnVolumeDown.Name = "btnVolumeDown"
        Me.btnVolumeDown.Size = New System.Drawing.Size(110, 55)
        Me.btnVolumeDown.TabIndex = 10
        Me.btnVolumeDown.UseVisualStyleBackColor = False
        '
        'btnPlay
        '
        Me.btnPlay.BackColor = System.Drawing.Color.Black
        Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlay.Image = Global.CarPC.My.Resources.Resources.Play
        Me.btnPlay.Location = New System.Drawing.Point(220, 0)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(110, 110)
        Me.btnPlay.TabIndex = 7
        Me.btnPlay.UseVisualStyleBackColor = False
        '
        'btnVolumeUp
        '
        Me.btnVolumeUp.BackColor = System.Drawing.Color.Black
        Me.btnVolumeUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolumeUp.Image = CType(resources.GetObject("btnVolumeUp.Image"), System.Drawing.Image)
        Me.btnVolumeUp.Location = New System.Drawing.Point(440, 0)
        Me.btnVolumeUp.Name = "btnVolumeUp"
        Me.btnVolumeUp.Size = New System.Drawing.Size(110, 55)
        Me.btnVolumeUp.TabIndex = 9
        Me.btnVolumeUp.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.Black
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.Location = New System.Drawing.Point(110, 0)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(110, 110)
        Me.btnStop.TabIndex = 6
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnPrevious
        '
        Me.btnPrevious.BackColor = System.Drawing.Color.Black
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Image = Global.CarPC.My.Resources.Resources.Previous
        Me.btnPrevious.Location = New System.Drawing.Point(0, 0)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(110, 110)
        Me.btnPrevious.TabIndex = 5
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.Black
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.Location = New System.Drawing.Point(330, 0)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(110, 110)
        Me.btnNext.TabIndex = 8
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'MediaControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.btnShuffle)
        Me.Controls.Add(Me.btnFav)
        Me.Controls.Add(Me.btnVolumeDown)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.btnVolumeUp)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNext)
        Me.Name = "MediaControls"
        Me.Size = New System.Drawing.Size(771, 113)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnShuffle As System.Windows.Forms.Button
    Friend WithEvents btnFav As System.Windows.Forms.Button
    Friend WithEvents btnVolumeDown As System.Windows.Forms.Button
    Friend WithEvents btnVolumeUp As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents tmrVolume As System.Windows.Forms.Timer

End Class
