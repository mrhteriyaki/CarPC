<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Music
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Music))
        Me.tmrMediaFinished = New System.Windows.Forms.Timer(Me.components)
        Me.WMPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.pbxMusicImage = New System.Windows.Forms.PictureBox()
        CType(Me.WMPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxMusicImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrMediaFinished
        '
        Me.tmrMediaFinished.Interval = 300
        '
        'WMPlayer
        '
        Me.WMPlayer.Enabled = True
        Me.WMPlayer.Location = New System.Drawing.Point(3, 3)
        Me.WMPlayer.Name = "WMPlayer"
        Me.WMPlayer.OcxState = CType(resources.GetObject("WMPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WMPlayer.Size = New System.Drawing.Size(459, 340)
        Me.WMPlayer.TabIndex = 17
        '
        'pbxMusicImage
        '
        Me.pbxMusicImage.Location = New System.Drawing.Point(468, 0)
        Me.pbxMusicImage.Name = "pbxMusicImage"
        Me.pbxMusicImage.Size = New System.Drawing.Size(342, 343)
        Me.pbxMusicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxMusicImage.TabIndex = 18
        Me.pbxMusicImage.TabStop = False
        '
        'Music
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.pbxMusicImage)
        Me.Controls.Add(Me.WMPlayer)
        Me.Name = "Music"
        Me.Size = New System.Drawing.Size(810, 350)
        CType(Me.WMPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxMusicImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WMPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents tmrMediaFinished As System.Windows.Forms.Timer
    Friend WithEvents pbxMusicImage As PictureBox
End Class
