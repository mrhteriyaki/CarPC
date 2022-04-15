<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EngineInfo
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
        Me.gbxAirConControls = New System.Windows.Forms.GroupBox()
        Me.txtFanMode = New System.Windows.Forms.TextBox()
        Me.txtGPSSmell = New System.Windows.Forms.TextBox()
        Me.txtOutsideTempLabel = New System.Windows.Forms.TextBox()
        Me.txtOutsideTemp = New System.Windows.Forms.TextBox()
        Me.txtCabinTempLabel = New System.Windows.Forms.TextBox()
        Me.pbxVentLocation = New System.Windows.Forms.PictureBox()
        Me.btnSetFeetWindow = New System.Windows.Forms.Button()
        Me.btnSetFeetFace = New System.Windows.Forms.Button()
        Me.btnSetFeet = New System.Windows.Forms.Button()
        Me.btnSetFace = New System.Windows.Forms.Button()
        Me.txtCabinTemp = New System.Windows.Forms.TextBox()
        Me.btnTempUp = New System.Windows.Forms.Button()
        Me.btnTempDown = New System.Windows.Forms.Button()
        Me.btnAuto = New System.Windows.Forms.Button()
        Me.btnACOff = New System.Windows.Forms.Button()
        Me.btnRecordLocation = New System.Windows.Forms.Button()
        Me.btnOff = New System.Windows.Forms.Button()
        Me.btnWindowDefog = New System.Windows.Forms.Button()
        Me.btnRearDefog = New System.Windows.Forms.Button()
        Me.btnCloseCabin = New System.Windows.Forms.Button()
        Me.btnFanDown = New System.Windows.Forms.Button()
        Me.btnFanUp = New System.Windows.Forms.Button()
        Me.txtFanSpeed = New System.Windows.Forms.TextBox()
        Me.txtTemperature = New System.Windows.Forms.TextBox()
        Me.gbxEngine = New System.Windows.Forms.GroupBox()
        Me.gbxVoltaes = New System.Windows.Forms.GroupBox()
        Me.gbxOBD = New System.Windows.Forms.GroupBox()
        Me.tmrACAuto = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGaugeLabels = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCycleVents = New System.Windows.Forms.Timer(Me.components)
        Me.GraphicsUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.gbxTransmission = New System.Windows.Forms.GroupBox()
        Me.txtgear = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFuelCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tmrLabelsUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.gbxAirConControls.SuspendLayout()
        CType(Me.pbxVentLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxTransmission.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxAirConControls
        '
        Me.gbxAirConControls.Controls.Add(Me.txtFanMode)
        Me.gbxAirConControls.Controls.Add(Me.txtGPSSmell)
        Me.gbxAirConControls.Controls.Add(Me.txtOutsideTempLabel)
        Me.gbxAirConControls.Controls.Add(Me.txtOutsideTemp)
        Me.gbxAirConControls.Controls.Add(Me.txtCabinTempLabel)
        Me.gbxAirConControls.Controls.Add(Me.pbxVentLocation)
        Me.gbxAirConControls.Controls.Add(Me.btnSetFeetWindow)
        Me.gbxAirConControls.Controls.Add(Me.btnSetFeetFace)
        Me.gbxAirConControls.Controls.Add(Me.btnSetFeet)
        Me.gbxAirConControls.Controls.Add(Me.btnSetFace)
        Me.gbxAirConControls.Controls.Add(Me.txtCabinTemp)
        Me.gbxAirConControls.Controls.Add(Me.btnTempUp)
        Me.gbxAirConControls.Controls.Add(Me.btnTempDown)
        Me.gbxAirConControls.Controls.Add(Me.btnAuto)
        Me.gbxAirConControls.Controls.Add(Me.btnACOff)
        Me.gbxAirConControls.Controls.Add(Me.btnRecordLocation)
        Me.gbxAirConControls.Controls.Add(Me.btnOff)
        Me.gbxAirConControls.Controls.Add(Me.btnWindowDefog)
        Me.gbxAirConControls.Controls.Add(Me.btnRearDefog)
        Me.gbxAirConControls.Controls.Add(Me.btnCloseCabin)
        Me.gbxAirConControls.Controls.Add(Me.btnFanDown)
        Me.gbxAirConControls.Controls.Add(Me.btnFanUp)
        Me.gbxAirConControls.Controls.Add(Me.txtFanSpeed)
        Me.gbxAirConControls.Controls.Add(Me.txtTemperature)
        Me.gbxAirConControls.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAirConControls.ForeColor = System.Drawing.Color.White
        Me.gbxAirConControls.Location = New System.Drawing.Point(3, 596)
        Me.gbxAirConControls.Name = "gbxAirConControls"
        Me.gbxAirConControls.Size = New System.Drawing.Size(762, 395)
        Me.gbxAirConControls.TabIndex = 29
        Me.gbxAirConControls.TabStop = False
        Me.gbxAirConControls.Text = "Air Conditioning Controls"
        '
        'txtFanMode
        '
        Me.txtFanMode.BackColor = System.Drawing.Color.Black
        Me.txtFanMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFanMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFanMode.ForeColor = System.Drawing.Color.White
        Me.txtFanMode.Location = New System.Drawing.Point(324, 351)
        Me.txtFanMode.Name = "txtFanMode"
        Me.txtFanMode.ReadOnly = True
        Me.txtFanMode.Size = New System.Drawing.Size(117, 26)
        Me.txtFanMode.TabIndex = 58
        Me.txtFanMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGPSSmell
        '
        Me.txtGPSSmell.BackColor = System.Drawing.Color.DarkRed
        Me.txtGPSSmell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGPSSmell.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGPSSmell.ForeColor = System.Drawing.Color.White
        Me.txtGPSSmell.Location = New System.Drawing.Point(324, 314)
        Me.txtGPSSmell.Name = "txtGPSSmell"
        Me.txtGPSSmell.ReadOnly = True
        Me.txtGPSSmell.Size = New System.Drawing.Size(117, 35)
        Me.txtGPSSmell.TabIndex = 57
        Me.txtGPSSmell.Text = "Bad Smell"
        Me.txtGPSSmell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOutsideTempLabel
        '
        Me.txtOutsideTempLabel.BackColor = System.Drawing.Color.Black
        Me.txtOutsideTempLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutsideTempLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutsideTempLabel.ForeColor = System.Drawing.Color.White
        Me.txtOutsideTempLabel.Location = New System.Drawing.Point(10, 219)
        Me.txtOutsideTempLabel.Multiline = True
        Me.txtOutsideTempLabel.Name = "txtOutsideTempLabel"
        Me.txtOutsideTempLabel.ReadOnly = True
        Me.txtOutsideTempLabel.Size = New System.Drawing.Size(120, 20)
        Me.txtOutsideTempLabel.TabIndex = 56
        Me.txtOutsideTempLabel.Text = "Outside Temp:"
        Me.txtOutsideTempLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOutsideTemp
        '
        Me.txtOutsideTemp.BackColor = System.Drawing.Color.Black
        Me.txtOutsideTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutsideTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutsideTemp.ForeColor = System.Drawing.Color.White
        Me.txtOutsideTemp.Location = New System.Drawing.Point(10, 240)
        Me.txtOutsideTemp.Multiline = True
        Me.txtOutsideTemp.Name = "txtOutsideTemp"
        Me.txtOutsideTemp.ReadOnly = True
        Me.txtOutsideTemp.Size = New System.Drawing.Size(120, 35)
        Me.txtOutsideTemp.TabIndex = 55
        Me.txtOutsideTemp.Text = "0.0"
        Me.txtOutsideTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCabinTempLabel
        '
        Me.txtCabinTempLabel.BackColor = System.Drawing.Color.Black
        Me.txtCabinTempLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCabinTempLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCabinTempLabel.ForeColor = System.Drawing.Color.White
        Me.txtCabinTempLabel.Location = New System.Drawing.Point(10, 157)
        Me.txtCabinTempLabel.Multiline = True
        Me.txtCabinTempLabel.Name = "txtCabinTempLabel"
        Me.txtCabinTempLabel.ReadOnly = True
        Me.txtCabinTempLabel.Size = New System.Drawing.Size(120, 20)
        Me.txtCabinTempLabel.TabIndex = 54
        Me.txtCabinTempLabel.Text = "Cabin Temp:"
        Me.txtCabinTempLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pbxVentLocation
        '
        Me.pbxVentLocation.BackColor = System.Drawing.Color.Black
        Me.pbxVentLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbxVentLocation.Image = Global.CarPC.My.Resources.Resources.Selected
        Me.pbxVentLocation.Location = New System.Drawing.Point(260, 276)
        Me.pbxVentLocation.Name = "pbxVentLocation"
        Me.pbxVentLocation.Size = New System.Drawing.Size(120, 35)
        Me.pbxVentLocation.TabIndex = 53
        Me.pbxVentLocation.TabStop = False
        '
        'btnSetFeetWindow
        '
        Me.btnSetFeetWindow.BackColor = System.Drawing.Color.Black
        Me.btnSetFeetWindow.BackgroundImage = Global.CarPC.My.Resources.Resources.Feet_and_Window_Vents
        Me.btnSetFeetWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSetFeetWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetFeetWindow.Location = New System.Drawing.Point(510, 156)
        Me.btnSetFeetWindow.Name = "btnSetFeetWindow"
        Me.btnSetFeetWindow.Size = New System.Drawing.Size(120, 120)
        Me.btnSetFeetWindow.TabIndex = 52
        Me.btnSetFeetWindow.UseVisualStyleBackColor = False
        '
        'btnSetFeetFace
        '
        Me.btnSetFeetFace.BackColor = System.Drawing.Color.Black
        Me.btnSetFeetFace.BackgroundImage = Global.CarPC.My.Resources.Resources.Face_and_Feet
        Me.btnSetFeetFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSetFeetFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetFeetFace.Location = New System.Drawing.Point(385, 156)
        Me.btnSetFeetFace.Name = "btnSetFeetFace"
        Me.btnSetFeetFace.Size = New System.Drawing.Size(120, 120)
        Me.btnSetFeetFace.TabIndex = 51
        Me.btnSetFeetFace.UseVisualStyleBackColor = False
        '
        'btnSetFeet
        '
        Me.btnSetFeet.BackColor = System.Drawing.Color.Black
        Me.btnSetFeet.BackgroundImage = Global.CarPC.My.Resources.Resources.Feet_Vents
        Me.btnSetFeet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSetFeet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetFeet.Location = New System.Drawing.Point(260, 156)
        Me.btnSetFeet.Name = "btnSetFeet"
        Me.btnSetFeet.Size = New System.Drawing.Size(120, 120)
        Me.btnSetFeet.TabIndex = 50
        Me.btnSetFeet.UseVisualStyleBackColor = False
        '
        'btnSetFace
        '
        Me.btnSetFace.BackColor = System.Drawing.Color.Black
        Me.btnSetFace.BackgroundImage = Global.CarPC.My.Resources.Resources.Face_Vents
        Me.btnSetFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSetFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetFace.Location = New System.Drawing.Point(135, 156)
        Me.btnSetFace.Name = "btnSetFace"
        Me.btnSetFace.Size = New System.Drawing.Size(120, 120)
        Me.btnSetFace.TabIndex = 49
        Me.btnSetFace.UseVisualStyleBackColor = False
        '
        'txtCabinTemp
        '
        Me.txtCabinTemp.BackColor = System.Drawing.Color.Black
        Me.txtCabinTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCabinTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCabinTemp.ForeColor = System.Drawing.Color.White
        Me.txtCabinTemp.Location = New System.Drawing.Point(10, 178)
        Me.txtCabinTemp.Multiline = True
        Me.txtCabinTemp.Name = "txtCabinTemp"
        Me.txtCabinTemp.ReadOnly = True
        Me.txtCabinTemp.Size = New System.Drawing.Size(120, 35)
        Me.txtCabinTemp.TabIndex = 48
        Me.txtCabinTemp.Text = "0.0"
        Me.txtCabinTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnTempUp
        '
        Me.btnTempUp.BackColor = System.Drawing.Color.Black
        Me.btnTempUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTempUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTempUp.ForeColor = System.Drawing.Color.White
        Me.btnTempUp.Location = New System.Drawing.Point(192, 311)
        Me.btnTempUp.Name = "btnTempUp"
        Me.btnTempUp.Size = New System.Drawing.Size(115, 75)
        Me.btnTempUp.TabIndex = 2
        Me.btnTempUp.Text = "Temp +"
        Me.btnTempUp.UseVisualStyleBackColor = False
        '
        'btnTempDown
        '
        Me.btnTempDown.BackColor = System.Drawing.Color.Black
        Me.btnTempDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTempDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTempDown.ForeColor = System.Drawing.Color.White
        Me.btnTempDown.Location = New System.Drawing.Point(5, 311)
        Me.btnTempDown.Name = "btnTempDown"
        Me.btnTempDown.Size = New System.Drawing.Size(115, 75)
        Me.btnTempDown.TabIndex = 3
        Me.btnTempDown.Text = "Temp -"
        Me.btnTempDown.UseVisualStyleBackColor = False
        '
        'btnAuto
        '
        Me.btnAuto.BackColor = System.Drawing.Color.Black
        Me.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAuto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuto.ForeColor = System.Drawing.Color.White
        Me.btnAuto.Location = New System.Drawing.Point(385, 30)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.Size = New System.Drawing.Size(120, 120)
        Me.btnAuto.TabIndex = 43
        Me.btnAuto.Text = "Auto"
        Me.btnAuto.UseVisualStyleBackColor = False
        '
        'btnACOff
        '
        Me.btnACOff.BackColor = System.Drawing.Color.Black
        Me.btnACOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnACOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnACOff.ForeColor = System.Drawing.Color.White
        Me.btnACOff.Image = Global.CarPC.My.Resources.Resources.On_Button
        Me.btnACOff.Location = New System.Drawing.Point(135, 30)
        Me.btnACOff.Name = "btnACOff"
        Me.btnACOff.Size = New System.Drawing.Size(120, 120)
        Me.btnACOff.TabIndex = 9
        Me.btnACOff.Text = "A/C"
        Me.btnACOff.UseVisualStyleBackColor = False
        '
        'btnRecordLocation
        '
        Me.btnRecordLocation.BackColor = System.Drawing.Color.Black
        Me.btnRecordLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecordLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecordLocation.ForeColor = System.Drawing.Color.White
        Me.btnRecordLocation.Location = New System.Drawing.Point(260, 30)
        Me.btnRecordLocation.Name = "btnRecordLocation"
        Me.btnRecordLocation.Size = New System.Drawing.Size(120, 120)
        Me.btnRecordLocation.TabIndex = 42
        Me.btnRecordLocation.Text = "Mark Bad Smell Zone"
        Me.btnRecordLocation.UseVisualStyleBackColor = False
        '
        'btnOff
        '
        Me.btnOff.BackColor = System.Drawing.Color.Black
        Me.btnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOff.ForeColor = System.Drawing.Color.White
        Me.btnOff.Location = New System.Drawing.Point(10, 30)
        Me.btnOff.Name = "btnOff"
        Me.btnOff.Size = New System.Drawing.Size(120, 120)
        Me.btnOff.TabIndex = 8
        Me.btnOff.Text = "Off"
        Me.btnOff.UseVisualStyleBackColor = False
        '
        'btnWindowDefog
        '
        Me.btnWindowDefog.BackColor = System.Drawing.Color.Black
        Me.btnWindowDefog.BackgroundImage = Global.CarPC.My.Resources.Resources.DefogWindscreen
        Me.btnWindowDefog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnWindowDefog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWindowDefog.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWindowDefog.ForeColor = System.Drawing.Color.White
        Me.btnWindowDefog.Location = New System.Drawing.Point(635, 156)
        Me.btnWindowDefog.Name = "btnWindowDefog"
        Me.btnWindowDefog.Size = New System.Drawing.Size(120, 120)
        Me.btnWindowDefog.TabIndex = 7
        Me.btnWindowDefog.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWindowDefog.UseVisualStyleBackColor = False
        '
        'btnRearDefog
        '
        Me.btnRearDefog.BackColor = System.Drawing.Color.Black
        Me.btnRearDefog.BackgroundImage = Global.CarPC.My.Resources.Resources.Rear_Demister_Off
        Me.btnRearDefog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRearDefog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRearDefog.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRearDefog.ForeColor = System.Drawing.Color.White
        Me.btnRearDefog.Location = New System.Drawing.Point(635, 30)
        Me.btnRearDefog.Name = "btnRearDefog"
        Me.btnRearDefog.Size = New System.Drawing.Size(120, 120)
        Me.btnRearDefog.TabIndex = 6
        Me.btnRearDefog.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRearDefog.UseVisualStyleBackColor = False
        '
        'btnCloseCabin
        '
        Me.btnCloseCabin.BackColor = System.Drawing.Color.Black
        Me.btnCloseCabin.BackgroundImage = Global.CarPC.My.Resources.Resources.Close_Cabin
        Me.btnCloseCabin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCloseCabin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseCabin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseCabin.ForeColor = System.Drawing.Color.White
        Me.btnCloseCabin.Location = New System.Drawing.Point(510, 30)
        Me.btnCloseCabin.Name = "btnCloseCabin"
        Me.btnCloseCabin.Size = New System.Drawing.Size(120, 120)
        Me.btnCloseCabin.TabIndex = 4
        Me.btnCloseCabin.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCloseCabin.UseVisualStyleBackColor = False
        '
        'btnFanDown
        '
        Me.btnFanDown.BackColor = System.Drawing.Color.Black
        Me.btnFanDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFanDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFanDown.ForeColor = System.Drawing.Color.White
        Me.btnFanDown.Location = New System.Drawing.Point(459, 311)
        Me.btnFanDown.Name = "btnFanDown"
        Me.btnFanDown.Size = New System.Drawing.Size(115, 75)
        Me.btnFanDown.TabIndex = 1
        Me.btnFanDown.Text = "Fan -"
        Me.btnFanDown.UseVisualStyleBackColor = False
        '
        'btnFanUp
        '
        Me.btnFanUp.BackColor = System.Drawing.Color.Black
        Me.btnFanUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFanUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFanUp.ForeColor = System.Drawing.Color.White
        Me.btnFanUp.Location = New System.Drawing.Point(643, 311)
        Me.btnFanUp.Name = "btnFanUp"
        Me.btnFanUp.Size = New System.Drawing.Size(115, 75)
        Me.btnFanUp.TabIndex = 0
        Me.btnFanUp.Text = "Fan +"
        Me.btnFanUp.UseVisualStyleBackColor = False
        '
        'txtFanSpeed
        '
        Me.txtFanSpeed.BackColor = System.Drawing.Color.Black
        Me.txtFanSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFanSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFanSpeed.ForeColor = System.Drawing.Color.White
        Me.txtFanSpeed.Location = New System.Drawing.Point(569, 332)
        Me.txtFanSpeed.Name = "txtFanSpeed"
        Me.txtFanSpeed.ReadOnly = True
        Me.txtFanSpeed.Size = New System.Drawing.Size(79, 35)
        Me.txtFanSpeed.TabIndex = 46
        Me.txtFanSpeed.Text = "N/A"
        Me.txtFanSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTemperature
        '
        Me.txtTemperature.BackColor = System.Drawing.Color.Black
        Me.txtTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTemperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemperature.ForeColor = System.Drawing.Color.White
        Me.txtTemperature.Location = New System.Drawing.Point(116, 332)
        Me.txtTemperature.Name = "txtTemperature"
        Me.txtTemperature.ReadOnly = True
        Me.txtTemperature.Size = New System.Drawing.Size(79, 35)
        Me.txtTemperature.TabIndex = 47
        Me.txtTemperature.Text = "N/A"
        Me.txtTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbxEngine
        '
        Me.gbxEngine.BackColor = System.Drawing.Color.Black
        Me.gbxEngine.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxEngine.ForeColor = System.Drawing.Color.White
        Me.gbxEngine.Location = New System.Drawing.Point(3, 0)
        Me.gbxEngine.Name = "gbxEngine"
        Me.gbxEngine.Size = New System.Drawing.Size(762, 265)
        Me.gbxEngine.TabIndex = 46
        Me.gbxEngine.TabStop = False
        Me.gbxEngine.Text = "Engine"
        '
        'gbxVoltaes
        '
        Me.gbxVoltaes.BackColor = System.Drawing.Color.Black
        Me.gbxVoltaes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxVoltaes.ForeColor = System.Drawing.Color.White
        Me.gbxVoltaes.Location = New System.Drawing.Point(3, 271)
        Me.gbxVoltaes.Name = "gbxVoltaes"
        Me.gbxVoltaes.Size = New System.Drawing.Size(385, 158)
        Me.gbxVoltaes.TabIndex = 47
        Me.gbxVoltaes.TabStop = False
        Me.gbxVoltaes.Text = "Voltages"
        '
        'gbxOBD
        '
        Me.gbxOBD.BackColor = System.Drawing.Color.Black
        Me.gbxOBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxOBD.ForeColor = System.Drawing.Color.White
        Me.gbxOBD.Location = New System.Drawing.Point(3, 431)
        Me.gbxOBD.Name = "gbxOBD"
        Me.gbxOBD.Size = New System.Drawing.Size(385, 158)
        Me.gbxOBD.TabIndex = 48
        Me.gbxOBD.TabStop = False
        Me.gbxOBD.Text = "OBD"
        '
        'tmrACAuto
        '
        '
        'tmrGaugeLabels
        '
        Me.tmrGaugeLabels.Interval = 50
        '
        'tmrCycleVents
        '
        Me.tmrCycleVents.Interval = 1500
        '
        'GraphicsUpdate
        '
        Me.GraphicsUpdate.Enabled = True
        Me.GraphicsUpdate.Interval = 5
        '
        'gbxTransmission
        '
        Me.gbxTransmission.BackColor = System.Drawing.Color.Black
        Me.gbxTransmission.Controls.Add(Me.txtgear)
        Me.gbxTransmission.Controls.Add(Me.Label1)
        Me.gbxTransmission.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxTransmission.ForeColor = System.Drawing.Color.White
        Me.gbxTransmission.Location = New System.Drawing.Point(394, 271)
        Me.gbxTransmission.Name = "gbxTransmission"
        Me.gbxTransmission.Size = New System.Drawing.Size(150, 66)
        Me.gbxTransmission.TabIndex = 48
        Me.gbxTransmission.TabStop = False
        Me.gbxTransmission.Text = "Transmission"
        '
        'txtgear
        '
        Me.txtgear.BackColor = System.Drawing.Color.Black
        Me.txtgear.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgear.ForeColor = System.Drawing.Color.White
        Me.txtgear.Location = New System.Drawing.Point(63, 25)
        Me.txtgear.Name = "txtgear"
        Me.txtgear.Size = New System.Drawing.Size(83, 35)
        Me.txtgear.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Gear:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Black
        Me.GroupBox1.Controls.Add(Me.txtFuelCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(549, 271)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 66)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fuel"
        '
        'txtFuelCode
        '
        Me.txtFuelCode.BackColor = System.Drawing.Color.Black
        Me.txtFuelCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFuelCode.ForeColor = System.Drawing.Color.White
        Me.txtFuelCode.Location = New System.Drawing.Point(109, 25)
        Me.txtFuelCode.Name = "txtFuelCode"
        Me.txtFuelCode.Size = New System.Drawing.Size(103, 35)
        Me.txtFuelCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fuel Count:"
        '
        'tmrLabelsUpdate
        '
        Me.tmrLabelsUpdate.Enabled = True
        Me.tmrLabelsUpdate.Interval = 150
        '
        'EngineInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbxTransmission)
        Me.Controls.Add(Me.gbxAirConControls)
        Me.Controls.Add(Me.gbxOBD)
        Me.Controls.Add(Me.gbxVoltaes)
        Me.Controls.Add(Me.gbxEngine)
        Me.Name = "EngineInfo"
        Me.Size = New System.Drawing.Size(768, 994)
        Me.gbxAirConControls.ResumeLayout(False)
        Me.gbxAirConControls.PerformLayout()
        CType(Me.pbxVentLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxTransmission.ResumeLayout(False)
        Me.gbxTransmission.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxAirConControls As System.Windows.Forms.GroupBox
    Friend WithEvents btnFanUp As System.Windows.Forms.Button
    Friend WithEvents btnFanDown As System.Windows.Forms.Button
    Friend WithEvents btnTempDown As System.Windows.Forms.Button
    Friend WithEvents btnTempUp As System.Windows.Forms.Button
    Friend WithEvents btnCloseCabin As System.Windows.Forms.Button
    Friend WithEvents btnWindowDefog As System.Windows.Forms.Button
    Friend WithEvents btnRearDefog As System.Windows.Forms.Button
    Friend WithEvents btnACOff As System.Windows.Forms.Button
    Friend WithEvents btnOff As System.Windows.Forms.Button
    Friend WithEvents btnRecordLocation As System.Windows.Forms.Button
    Friend WithEvents btnAuto As System.Windows.Forms.Button
    Friend WithEvents gbxEngine As System.Windows.Forms.GroupBox
    Friend WithEvents gbxVoltaes As System.Windows.Forms.GroupBox
    Friend WithEvents txtTemperature As System.Windows.Forms.TextBox
    Friend WithEvents txtFanSpeed As System.Windows.Forms.TextBox
    Friend WithEvents gbxOBD As System.Windows.Forms.GroupBox
    Friend WithEvents txtCabinTemp As System.Windows.Forms.TextBox
    Friend WithEvents tmrACAuto As System.Windows.Forms.Timer
    Friend WithEvents btnSetFeet As System.Windows.Forms.Button
    Friend WithEvents btnSetFace As System.Windows.Forms.Button
    Friend WithEvents tmrGaugeLabels As System.Windows.Forms.Timer
    Friend WithEvents tmrCycleVents As System.Windows.Forms.Timer
    Friend WithEvents btnSetFeetFace As System.Windows.Forms.Button
    Friend WithEvents btnSetFeetWindow As System.Windows.Forms.Button
    Friend WithEvents pbxVentLocation As System.Windows.Forms.PictureBox
    Friend WithEvents txtCabinTempLabel As System.Windows.Forms.TextBox
    Friend WithEvents txtOutsideTempLabel As System.Windows.Forms.TextBox
    Friend WithEvents txtOutsideTemp As System.Windows.Forms.TextBox
    Friend WithEvents txtGPSSmell As System.Windows.Forms.TextBox
    Friend WithEvents txtFanMode As System.Windows.Forms.TextBox
    Friend WithEvents GraphicsUpdate As Timer
    Friend WithEvents gbxTransmission As GroupBox
    Friend WithEvents txtgear As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFuelCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tmrLabelsUpdate As Timer
End Class
