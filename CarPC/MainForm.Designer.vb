<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CarPCfrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CarPCfrm))
        Me.tmrLabels = New System.Windows.Forms.Timer(Me.components)
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.gbxGPS = New System.Windows.Forms.GroupBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.btnSoundCloud = New System.Windows.Forms.Button()
        Me.btnCamera = New System.Windows.Forms.Button()
        Me.btnDebug = New System.Windows.Forms.Button()
        Me.btnCarSystems = New System.Windows.Forms.Button()
        Me.btnMusic = New System.Windows.Forms.Button()
        Me.btnGPS = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtHomeAlert = New System.Windows.Forms.TextBox()
        Me.gbxGPS.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrLabels
        '
        Me.tmrLabels.Enabled = True
        '
        'txtTime
        '
        Me.txtTime.BackColor = System.Drawing.Color.Black
        Me.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTime.ForeColor = System.Drawing.Color.White
        Me.txtTime.Location = New System.Drawing.Point(0, 3)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(150, 55)
        Me.txtTime.TabIndex = 17
        Me.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTime.Visible = False
        '
        'gbxGPS
        '
        Me.gbxGPS.Controls.Add(Me.txtHomeAlert)
        Me.gbxGPS.Controls.Add(Me.lblLocation)
        Me.gbxGPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxGPS.ForeColor = System.Drawing.Color.White
        Me.gbxGPS.Location = New System.Drawing.Point(156, 0)
        Me.gbxGPS.Name = "gbxGPS"
        Me.gbxGPS.Size = New System.Drawing.Size(590, 62)
        Me.gbxGPS.TabIndex = 19
        Me.gbxGPS.TabStop = False
        Me.gbxGPS.Text = "GPS Location"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(6, 24)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(0, 20)
        Me.lblLocation.TabIndex = 0
        '
        'btnSoundCloud
        '
        Me.btnSoundCloud.BackColor = System.Drawing.Color.Black
        Me.btnSoundCloud.BackgroundImage = CType(resources.GetObject("btnSoundCloud.BackgroundImage"), System.Drawing.Image)
        Me.btnSoundCloud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSoundCloud.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSoundCloud.Location = New System.Drawing.Point(216, 75)
        Me.btnSoundCloud.Name = "btnSoundCloud"
        Me.btnSoundCloud.Size = New System.Drawing.Size(110, 110)
        Me.btnSoundCloud.TabIndex = 18
        Me.btnSoundCloud.UseVisualStyleBackColor = False
        Me.btnSoundCloud.Visible = False
        '
        'btnCamera
        '
        Me.btnCamera.BackColor = System.Drawing.Color.Black
        Me.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCamera.Image = Global.CarPC.My.Resources.Resources.Camera
        Me.btnCamera.Location = New System.Drawing.Point(432, 75)
        Me.btnCamera.Name = "btnCamera"
        Me.btnCamera.Size = New System.Drawing.Size(110, 110)
        Me.btnCamera.TabIndex = 16
        Me.btnCamera.Text = "Cameras"
        Me.btnCamera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCamera.UseVisualStyleBackColor = False
        Me.btnCamera.Visible = False
        '
        'btnDebug
        '
        Me.btnDebug.BackColor = System.Drawing.Color.Black
        Me.btnDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDebug.Image = Global.CarPC.My.Resources.Resources.Options
        Me.btnDebug.Location = New System.Drawing.Point(540, 75)
        Me.btnDebug.Name = "btnDebug"
        Me.btnDebug.Size = New System.Drawing.Size(110, 110)
        Me.btnDebug.TabIndex = 15
        Me.btnDebug.Text = "Options"
        Me.btnDebug.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDebug.UseVisualStyleBackColor = False
        Me.btnDebug.Visible = False
        '
        'btnCarSystems
        '
        Me.btnCarSystems.BackColor = System.Drawing.Color.Black
        Me.btnCarSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCarSystems.Image = Global.CarPC.My.Resources.Resources.Engine
        Me.btnCarSystems.Location = New System.Drawing.Point(325, 75)
        Me.btnCarSystems.Name = "btnCarSystems"
        Me.btnCarSystems.Size = New System.Drawing.Size(110, 110)
        Me.btnCarSystems.TabIndex = 14
        Me.btnCarSystems.Text = "Car Systems"
        Me.btnCarSystems.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCarSystems.UseVisualStyleBackColor = False
        Me.btnCarSystems.Visible = False
        '
        'btnMusic
        '
        Me.btnMusic.BackColor = System.Drawing.Color.Black
        Me.btnMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMusic.Image = Global.CarPC.My.Resources.Resources.Music
        Me.btnMusic.Location = New System.Drawing.Point(108, 75)
        Me.btnMusic.Name = "btnMusic"
        Me.btnMusic.Size = New System.Drawing.Size(110, 110)
        Me.btnMusic.TabIndex = 3
        Me.btnMusic.Text = "Music"
        Me.btnMusic.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMusic.UseVisualStyleBackColor = False
        Me.btnMusic.Visible = False
        '
        'btnGPS
        '
        Me.btnGPS.BackColor = System.Drawing.Color.Black
        Me.btnGPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGPS.Image = Global.CarPC.My.Resources.Resources.GPS
        Me.btnGPS.Location = New System.Drawing.Point(0, 75)
        Me.btnGPS.Name = "btnGPS"
        Me.btnGPS.Size = New System.Drawing.Size(110, 110)
        Me.btnGPS.TabIndex = 20
        Me.btnGPS.Text = "Navigator"
        Me.btnGPS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGPS.UseVisualStyleBackColor = False
        Me.btnGPS.Visible = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Black
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Image = Global.CarPC.My.Resources.Resources._Exit
        Me.btnExit.Location = New System.Drawing.Point(648, 75)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(110, 110)
        Me.btnExit.TabIndex = 21
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExit.UseVisualStyleBackColor = False
        Me.btnExit.Visible = False
        '
        'txtHomeAlert
        '
        Me.txtHomeAlert.BackColor = System.Drawing.Color.Black
        Me.txtHomeAlert.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeAlert.ForeColor = System.Drawing.Color.White
        Me.txtHomeAlert.Location = New System.Drawing.Point(498, 14)
        Me.txtHomeAlert.Name = "txtHomeAlert"
        Me.txtHomeAlert.Size = New System.Drawing.Size(84, 38)
        Me.txtHomeAlert.TabIndex = 1
        Me.txtHomeAlert.Text = "Home"
        Me.txtHomeAlert.Visible = False
        '
        'CarPCfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(789, 271)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnGPS)
        Me.Controls.Add(Me.gbxGPS)
        Me.Controls.Add(Me.btnSoundCloud)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.btnCamera)
        Me.Controls.Add(Me.btnDebug)
        Me.Controls.Add(Me.btnCarSystems)
        Me.Controls.Add(Me.btnMusic)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "CarPCfrm"
        Me.Text = "CarPC by Mitchell Hayden"
        Me.gbxGPS.ResumeLayout(False)
        Me.gbxGPS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMusic As System.Windows.Forms.Button
    Friend WithEvents AxWindowsMediaPlayer As WMPLib.WindowsMediaPlayer
    Friend WithEvents tmrLabels As System.Windows.Forms.Timer
    Friend WithEvents btnCarSystems As System.Windows.Forms.Button
    Friend WithEvents btnDebug As System.Windows.Forms.Button
    Friend WithEvents btnCamera As System.Windows.Forms.Button
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents btnSoundCloud As System.Windows.Forms.Button
    Friend WithEvents gbxGPS As System.Windows.Forms.GroupBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents btnGPS As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents txtHomeAlert As TextBox
End Class
