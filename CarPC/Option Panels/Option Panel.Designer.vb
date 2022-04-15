<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Option_Panel
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
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnErrorLog = New System.Windows.Forms.Button()
        Me.btnButtonControls = New System.Windows.Forms.Button()
        Me.btnCarStatus = New System.Windows.Forms.Button()
        Me.btnJourneylog = New System.Windows.Forms.Button()
        Me.btnCANDecoder = New System.Windows.Forms.Button()
        Me.btnCameraSetupPanel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Black
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(3, 6)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(105, 56)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "Update Software"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnErrorLog
        '
        Me.btnErrorLog.BackColor = System.Drawing.Color.Black
        Me.btnErrorLog.ForeColor = System.Drawing.Color.White
        Me.btnErrorLog.Location = New System.Drawing.Point(406, 6)
        Me.btnErrorLog.Name = "btnErrorLog"
        Me.btnErrorLog.Size = New System.Drawing.Size(80, 56)
        Me.btnErrorLog.TabIndex = 2
        Me.btnErrorLog.Text = "Error Log"
        Me.btnErrorLog.UseVisualStyleBackColor = False
        '
        'btnButtonControls
        '
        Me.btnButtonControls.BackColor = System.Drawing.Color.Black
        Me.btnButtonControls.ForeColor = System.Drawing.Color.White
        Me.btnButtonControls.Location = New System.Drawing.Point(492, 6)
        Me.btnButtonControls.Name = "btnButtonControls"
        Me.btnButtonControls.Size = New System.Drawing.Size(103, 56)
        Me.btnButtonControls.TabIndex = 3
        Me.btnButtonControls.Text = "Button Controls"
        Me.btnButtonControls.UseVisualStyleBackColor = False
        '
        'btnCarStatus
        '
        Me.btnCarStatus.BackColor = System.Drawing.Color.Black
        Me.btnCarStatus.ForeColor = System.Drawing.Color.White
        Me.btnCarStatus.Location = New System.Drawing.Point(114, 6)
        Me.btnCarStatus.Name = "btnCarStatus"
        Me.btnCarStatus.Size = New System.Drawing.Size(81, 56)
        Me.btnCarStatus.TabIndex = 4
        Me.btnCarStatus.Text = "Car Settings"
        Me.btnCarStatus.UseVisualStyleBackColor = False
        '
        'btnJourneylog
        '
        Me.btnJourneylog.BackColor = System.Drawing.Color.Black
        Me.btnJourneylog.ForeColor = System.Drawing.Color.White
        Me.btnJourneylog.Location = New System.Drawing.Point(201, 6)
        Me.btnJourneylog.Name = "btnJourneylog"
        Me.btnJourneylog.Size = New System.Drawing.Size(93, 56)
        Me.btnJourneylog.TabIndex = 5
        Me.btnJourneylog.Text = "Journey Logs"
        Me.btnJourneylog.UseVisualStyleBackColor = False
        '
        'btnCANDecoder
        '
        Me.btnCANDecoder.BackColor = System.Drawing.Color.Black
        Me.btnCANDecoder.ForeColor = System.Drawing.Color.White
        Me.btnCANDecoder.Location = New System.Drawing.Point(300, 6)
        Me.btnCANDecoder.Name = "btnCANDecoder"
        Me.btnCANDecoder.Size = New System.Drawing.Size(100, 56)
        Me.btnCANDecoder.TabIndex = 6
        Me.btnCANDecoder.Text = "CAN Decoder"
        Me.btnCANDecoder.UseVisualStyleBackColor = False
        '
        'btnCameraSetupPanel
        '
        Me.btnCameraSetupPanel.BackColor = System.Drawing.Color.Black
        Me.btnCameraSetupPanel.ForeColor = System.Drawing.Color.White
        Me.btnCameraSetupPanel.Location = New System.Drawing.Point(601, 6)
        Me.btnCameraSetupPanel.Name = "btnCameraSetupPanel"
        Me.btnCameraSetupPanel.Size = New System.Drawing.Size(103, 56)
        Me.btnCameraSetupPanel.TabIndex = 7
        Me.btnCameraSetupPanel.Text = "Camera Setup"
        Me.btnCameraSetupPanel.UseVisualStyleBackColor = False
        '
        'Option_Panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.btnCameraSetupPanel)
        Me.Controls.Add(Me.btnCANDecoder)
        Me.Controls.Add(Me.btnJourneylog)
        Me.Controls.Add(Me.btnCarStatus)
        Me.Controls.Add(Me.btnButtonControls)
        Me.Controls.Add(Me.btnErrorLog)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "Option_Panel"
        Me.Size = New System.Drawing.Size(771, 72)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnErrorLog As System.Windows.Forms.Button
    Friend WithEvents btnButtonControls As System.Windows.Forms.Button
    Friend WithEvents btnCarStatus As System.Windows.Forms.Button
    Friend WithEvents btnJourneylog As System.Windows.Forms.Button
    Friend WithEvents btnCANDecoder As System.Windows.Forms.Button
    Friend WithEvents btnCameraSetupPanel As Button
End Class
