<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Car_Status
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Car_Status))
        Me.gbxCarStatus = New System.Windows.Forms.GroupBox()
        Me.lblBrakes = New System.Windows.Forms.Label()
        Me.lblIgnitionState = New System.Windows.Forms.Label()
        Me.lblHighBeams = New System.Windows.Forms.Label()
        Me.lblAutoLights = New System.Windows.Forms.Label()
        Me.lblFogLights = New System.Windows.Forms.Label()
        Me.lblIndicators = New System.Windows.Forms.Label()
        Me.lblInteriorLights = New System.Windows.Forms.Label()
        Me.lblHeadlights = New System.Windows.Forms.Label()
        Me.lblLockState = New System.Windows.Forms.Label()
        Me.lblRearRightDoor = New System.Windows.Forms.Label()
        Me.lblRearLeftDoor = New System.Windows.Forms.Label()
        Me.lblPassengerDoor = New System.Windows.Forms.Label()
        Me.lblDriverDoor = New System.Windows.Forms.Label()
        Me.tmrUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.btnRelay1ON = New System.Windows.Forms.Button()
        Me.btnRelay2ON = New System.Windows.Forms.Button()
        Me.btnRelay2OFF = New System.Windows.Forms.Button()
        Me.btnRelay1OFF = New System.Windows.Forms.Button()
        Me.btnLights = New System.Windows.Forms.Button()
        Me.btnDSC = New System.Windows.Forms.Button()
        Me.btnLock = New System.Windows.Forms.Button()
        Me.btnUnlock = New System.Windows.Forms.Button()
        Me.btnHazards = New System.Windows.Forms.Button()
        Me.tmrDSC = New System.Windows.Forms.Timer(Me.components)
        Me.btnSaveHomeGPS = New System.Windows.Forms.Button()
        Me.gbxCarStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxCarStatus
        '
        Me.gbxCarStatus.Controls.Add(Me.lblBrakes)
        Me.gbxCarStatus.Controls.Add(Me.lblIgnitionState)
        Me.gbxCarStatus.Controls.Add(Me.lblHighBeams)
        Me.gbxCarStatus.Controls.Add(Me.lblAutoLights)
        Me.gbxCarStatus.Controls.Add(Me.lblFogLights)
        Me.gbxCarStatus.Controls.Add(Me.lblIndicators)
        Me.gbxCarStatus.Controls.Add(Me.lblInteriorLights)
        Me.gbxCarStatus.Controls.Add(Me.lblHeadlights)
        Me.gbxCarStatus.Controls.Add(Me.lblLockState)
        Me.gbxCarStatus.Controls.Add(Me.lblRearRightDoor)
        Me.gbxCarStatus.Controls.Add(Me.lblRearLeftDoor)
        Me.gbxCarStatus.Controls.Add(Me.lblPassengerDoor)
        Me.gbxCarStatus.Controls.Add(Me.lblDriverDoor)
        Me.gbxCarStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxCarStatus.ForeColor = System.Drawing.Color.White
        Me.gbxCarStatus.Location = New System.Drawing.Point(3, 164)
        Me.gbxCarStatus.Name = "gbxCarStatus"
        Me.gbxCarStatus.Size = New System.Drawing.Size(352, 365)
        Me.gbxCarStatus.TabIndex = 30
        Me.gbxCarStatus.TabStop = False
        Me.gbxCarStatus.Text = "Car Status"
        '
        'lblBrakes
        '
        Me.lblBrakes.AutoSize = True
        Me.lblBrakes.Location = New System.Drawing.Point(7, 310)
        Me.lblBrakes.Name = "lblBrakes"
        Me.lblBrakes.Size = New System.Drawing.Size(79, 24)
        Me.lblBrakes.TabIndex = 14
        Me.lblBrakes.Text = "Brakes:"
        '
        'lblIgnitionState
        '
        Me.lblIgnitionState.AutoSize = True
        Me.lblIgnitionState.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIgnitionState.Location = New System.Drawing.Point(6, 22)
        Me.lblIgnitionState.Name = "lblIgnitionState"
        Me.lblIgnitionState.Size = New System.Drawing.Size(136, 24)
        Me.lblIgnitionState.TabIndex = 12
        Me.lblIgnitionState.Text = "Ignition State:"
        '
        'lblHighBeams
        '
        Me.lblHighBeams.AutoSize = True
        Me.lblHighBeams.Location = New System.Drawing.Point(6, 280)
        Me.lblHighBeams.Name = "lblHighBeams"
        Me.lblHighBeams.Size = New System.Drawing.Size(129, 24)
        Me.lblHighBeams.TabIndex = 11
        Me.lblHighBeams.Text = "High Beams:"
        '
        'lblAutoLights
        '
        Me.lblAutoLights.AutoSize = True
        Me.lblAutoLights.Location = New System.Drawing.Point(7, 254)
        Me.lblAutoLights.Name = "lblAutoLights"
        Me.lblAutoLights.Size = New System.Drawing.Size(213, 24)
        Me.lblAutoLights.TabIndex = 10
        Me.lblAutoLights.Text = "Automatic Headlights:"
        '
        'lblFogLights
        '
        Me.lblFogLights.AutoSize = True
        Me.lblFogLights.Location = New System.Drawing.Point(7, 230)
        Me.lblFogLights.Name = "lblFogLights"
        Me.lblFogLights.Size = New System.Drawing.Size(114, 24)
        Me.lblFogLights.TabIndex = 9
        Me.lblFogLights.Text = "Fog Lights:"
        '
        'lblIndicators
        '
        Me.lblIndicators.AutoSize = True
        Me.lblIndicators.Location = New System.Drawing.Point(6, 184)
        Me.lblIndicators.Name = "lblIndicators"
        Me.lblIndicators.Size = New System.Drawing.Size(106, 24)
        Me.lblIndicators.TabIndex = 8
        Me.lblIndicators.Text = "Indicators:"
        '
        'lblInteriorLights
        '
        Me.lblInteriorLights.AutoSize = True
        Me.lblInteriorLights.Location = New System.Drawing.Point(6, 158)
        Me.lblInteriorLights.Name = "lblInteriorLights"
        Me.lblInteriorLights.Size = New System.Drawing.Size(142, 24)
        Me.lblInteriorLights.TabIndex = 7
        Me.lblInteriorLights.Text = "Interior Lights:"
        '
        'lblHeadlights
        '
        Me.lblHeadlights.AutoSize = True
        Me.lblHeadlights.Location = New System.Drawing.Point(6, 206)
        Me.lblHeadlights.Name = "lblHeadlights"
        Me.lblHeadlights.Size = New System.Drawing.Size(115, 24)
        Me.lblHeadlights.TabIndex = 5
        Me.lblHeadlights.Text = "Headlights:"
        '
        'lblLockState
        '
        Me.lblLockState.AutoSize = True
        Me.lblLockState.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLockState.Location = New System.Drawing.Point(6, 133)
        Me.lblLockState.Name = "lblLockState"
        Me.lblLockState.Size = New System.Drawing.Size(112, 24)
        Me.lblLockState.TabIndex = 6
        Me.lblLockState.Text = "Lock State:"
        '
        'lblRearRightDoor
        '
        Me.lblRearRightDoor.AutoSize = True
        Me.lblRearRightDoor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRearRightDoor.Location = New System.Drawing.Point(6, 112)
        Me.lblRearRightDoor.Name = "lblRearRightDoor"
        Me.lblRearRightDoor.Size = New System.Drawing.Size(165, 24)
        Me.lblRearRightDoor.TabIndex = 4
        Me.lblRearRightDoor.Text = "Rear Right Door:"
        '
        'lblRearLeftDoor
        '
        Me.lblRearLeftDoor.AutoSize = True
        Me.lblRearLeftDoor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRearLeftDoor.Location = New System.Drawing.Point(6, 89)
        Me.lblRearLeftDoor.Name = "lblRearLeftDoor"
        Me.lblRearLeftDoor.Size = New System.Drawing.Size(150, 24)
        Me.lblRearLeftDoor.TabIndex = 3
        Me.lblRearLeftDoor.Text = "Rear Left Door:"
        '
        'lblPassengerDoor
        '
        Me.lblPassengerDoor.AutoSize = True
        Me.lblPassengerDoor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassengerDoor.Location = New System.Drawing.Point(6, 66)
        Me.lblPassengerDoor.Name = "lblPassengerDoor"
        Me.lblPassengerDoor.Size = New System.Drawing.Size(166, 24)
        Me.lblPassengerDoor.TabIndex = 2
        Me.lblPassengerDoor.Text = "Passenger Door:"
        '
        'lblDriverDoor
        '
        Me.lblDriverDoor.AutoSize = True
        Me.lblDriverDoor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDriverDoor.Location = New System.Drawing.Point(6, 45)
        Me.lblDriverDoor.Name = "lblDriverDoor"
        Me.lblDriverDoor.Size = New System.Drawing.Size(122, 24)
        Me.lblDriverDoor.TabIndex = 1
        Me.lblDriverDoor.Text = "Driver Door:"
        '
        'tmrUpdate
        '
        Me.tmrUpdate.Enabled = True
        Me.tmrUpdate.Interval = 1500
        '
        'btnRelay1ON
        '
        Me.btnRelay1ON.BackColor = System.Drawing.Color.Black
        Me.btnRelay1ON.ForeColor = System.Drawing.Color.White
        Me.btnRelay1ON.Location = New System.Drawing.Point(361, 177)
        Me.btnRelay1ON.Name = "btnRelay1ON"
        Me.btnRelay1ON.Size = New System.Drawing.Size(190, 77)
        Me.btnRelay1ON.TabIndex = 31
        Me.btnRelay1ON.Text = "Monitor Off"
        Me.btnRelay1ON.UseVisualStyleBackColor = False
        '
        'btnRelay2ON
        '
        Me.btnRelay2ON.BackColor = System.Drawing.Color.Black
        Me.btnRelay2ON.ForeColor = System.Drawing.Color.White
        Me.btnRelay2ON.Location = New System.Drawing.Point(361, 346)
        Me.btnRelay2ON.Name = "btnRelay2ON"
        Me.btnRelay2ON.Size = New System.Drawing.Size(190, 77)
        Me.btnRelay2ON.TabIndex = 32
        Me.btnRelay2ON.Text = "Remote Relay Power On"
        Me.btnRelay2ON.UseVisualStyleBackColor = False
        '
        'btnRelay2OFF
        '
        Me.btnRelay2OFF.BackColor = System.Drawing.Color.Black
        Me.btnRelay2OFF.ForeColor = System.Drawing.Color.White
        Me.btnRelay2OFF.Location = New System.Drawing.Point(361, 429)
        Me.btnRelay2OFF.Name = "btnRelay2OFF"
        Me.btnRelay2OFF.Size = New System.Drawing.Size(190, 77)
        Me.btnRelay2OFF.TabIndex = 33
        Me.btnRelay2OFF.Text = "Remote Relay Power Off"
        Me.btnRelay2OFF.UseVisualStyleBackColor = False
        '
        'btnRelay1OFF
        '
        Me.btnRelay1OFF.BackColor = System.Drawing.Color.Black
        Me.btnRelay1OFF.ForeColor = System.Drawing.Color.White
        Me.btnRelay1OFF.Location = New System.Drawing.Point(361, 260)
        Me.btnRelay1OFF.Name = "btnRelay1OFF"
        Me.btnRelay1OFF.Size = New System.Drawing.Size(190, 77)
        Me.btnRelay1OFF.TabIndex = 34
        Me.btnRelay1OFF.Text = "Monitor On"
        Me.btnRelay1OFF.UseVisualStyleBackColor = False
        '
        'btnLights
        '
        Me.btnLights.BackColor = System.Drawing.Color.Black
        Me.btnLights.BackgroundImage = Global.CarPC.My.Resources.Resources.LightsOff
        Me.btnLights.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLights.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLights.ForeColor = System.Drawing.Color.White
        Me.btnLights.Location = New System.Drawing.Point(309, 8)
        Me.btnLights.Name = "btnLights"
        Me.btnLights.Size = New System.Drawing.Size(152, 150)
        Me.btnLights.TabIndex = 47
        Me.btnLights.UseVisualStyleBackColor = False
        '
        'btnDSC
        '
        Me.btnDSC.BackColor = System.Drawing.Color.Black
        Me.btnDSC.BackgroundImage = CType(resources.GetObject("btnDSC.BackgroundImage"), System.Drawing.Image)
        Me.btnDSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDSC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDSC.ForeColor = System.Drawing.Color.White
        Me.btnDSC.Location = New System.Drawing.Point(156, 8)
        Me.btnDSC.Name = "btnDSC"
        Me.btnDSC.Size = New System.Drawing.Size(152, 150)
        Me.btnDSC.TabIndex = 46
        Me.btnDSC.UseVisualStyleBackColor = False
        '
        'btnLock
        '
        Me.btnLock.BackColor = System.Drawing.Color.Black
        Me.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLock.ForeColor = System.Drawing.Color.Transparent
        Me.btnLock.Image = CType(resources.GetObject("btnLock.Image"), System.Drawing.Image)
        Me.btnLock.Location = New System.Drawing.Point(462, 8)
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(152, 150)
        Me.btnLock.TabIndex = 45
        Me.btnLock.UseVisualStyleBackColor = False
        '
        'btnUnlock
        '
        Me.btnUnlock.BackColor = System.Drawing.Color.Black
        Me.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnlock.ForeColor = System.Drawing.Color.White
        Me.btnUnlock.Image = CType(resources.GetObject("btnUnlock.Image"), System.Drawing.Image)
        Me.btnUnlock.Location = New System.Drawing.Point(615, 8)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(152, 150)
        Me.btnUnlock.TabIndex = 44
        Me.btnUnlock.UseVisualStyleBackColor = False
        '
        'btnHazards
        '
        Me.btnHazards.BackColor = System.Drawing.Color.Black
        Me.btnHazards.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHazards.ForeColor = System.Drawing.Color.White
        Me.btnHazards.Image = CType(resources.GetObject("btnHazards.Image"), System.Drawing.Image)
        Me.btnHazards.Location = New System.Drawing.Point(3, 8)
        Me.btnHazards.Name = "btnHazards"
        Me.btnHazards.Size = New System.Drawing.Size(152, 150)
        Me.btnHazards.TabIndex = 43
        Me.btnHazards.UseVisualStyleBackColor = False
        '
        'tmrDSC
        '
        Me.tmrDSC.Interval = 250
        '
        'btnSaveHomeGPS
        '
        Me.btnSaveHomeGPS.BackColor = System.Drawing.Color.Black
        Me.btnSaveHomeGPS.ForeColor = System.Drawing.Color.White
        Me.btnSaveHomeGPS.Location = New System.Drawing.Point(557, 177)
        Me.btnSaveHomeGPS.Name = "btnSaveHomeGPS"
        Me.btnSaveHomeGPS.Size = New System.Drawing.Size(190, 77)
        Me.btnSaveHomeGPS.TabIndex = 48
        Me.btnSaveHomeGPS.Text = "Save Current Position as Home"
        Me.btnSaveHomeGPS.UseVisualStyleBackColor = False
        '
        'Car_Status
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.btnSaveHomeGPS)
        Me.Controls.Add(Me.btnLights)
        Me.Controls.Add(Me.btnDSC)
        Me.Controls.Add(Me.btnLock)
        Me.Controls.Add(Me.btnUnlock)
        Me.Controls.Add(Me.btnHazards)
        Me.Controls.Add(Me.btnRelay1OFF)
        Me.Controls.Add(Me.btnRelay2OFF)
        Me.Controls.Add(Me.btnRelay2ON)
        Me.Controls.Add(Me.btnRelay1ON)
        Me.Controls.Add(Me.gbxCarStatus)
        Me.Name = "Car_Status"
        Me.Size = New System.Drawing.Size(909, 896)
        Me.gbxCarStatus.ResumeLayout(False)
        Me.gbxCarStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxCarStatus As System.Windows.Forms.GroupBox
    Friend WithEvents lblInteriorLights As System.Windows.Forms.Label
    Friend WithEvents lblLockState As System.Windows.Forms.Label
    Friend WithEvents lblHeadlights As System.Windows.Forms.Label
    Friend WithEvents lblRearRightDoor As System.Windows.Forms.Label
    Friend WithEvents lblRearLeftDoor As System.Windows.Forms.Label
    Friend WithEvents lblPassengerDoor As System.Windows.Forms.Label
    Friend WithEvents lblDriverDoor As System.Windows.Forms.Label
    Friend WithEvents tmrUpdate As System.Windows.Forms.Timer
    Friend WithEvents lblIndicators As System.Windows.Forms.Label
    Friend WithEvents lblHighBeams As System.Windows.Forms.Label
    Friend WithEvents lblAutoLights As System.Windows.Forms.Label
    Friend WithEvents lblFogLights As System.Windows.Forms.Label
    Friend WithEvents lblIgnitionState As System.Windows.Forms.Label
    Friend WithEvents btnRelay1ON As System.Windows.Forms.Button
    Friend WithEvents btnRelay2ON As System.Windows.Forms.Button
    Friend WithEvents btnRelay2OFF As System.Windows.Forms.Button
    Friend WithEvents btnRelay1OFF As System.Windows.Forms.Button
    Friend WithEvents lblBrakes As System.Windows.Forms.Label
    Friend WithEvents btnLights As Button
    Friend WithEvents btnDSC As Button
    Friend WithEvents btnLock As Button
    Friend WithEvents btnUnlock As Button
    Friend WithEvents btnHazards As Button
    Friend WithEvents tmrDSC As Timer
    Friend WithEvents btnSaveHomeGPS As Button
End Class
