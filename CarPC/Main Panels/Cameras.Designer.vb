<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cameras
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
        Me.bwCamera0 = New System.ComponentModel.BackgroundWorker()
        Me.bwCamera1 = New System.ComponentModel.BackgroundWorker()
        Me.bwCamera2 = New System.ComponentModel.BackgroundWorker()
        Me.pbxFrontBar = New System.Windows.Forms.PictureBox()
        Me.pbxDashCam = New System.Windows.Forms.PictureBox()
        Me.pbxRearCamera = New System.Windows.Forms.PictureBox()
        Me.bwDashRecorder = New System.ComponentModel.BackgroundWorker()
        CType(Me.pbxFrontBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxDashCam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRearCamera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bwCamera0
        '
        Me.bwCamera0.WorkerSupportsCancellation = True
        '
        'bwCamera1
        '
        Me.bwCamera1.WorkerSupportsCancellation = True
        '
        'bwCamera2
        '
        Me.bwCamera2.WorkerSupportsCancellation = True
        '
        'pbxFrontBar
        '
        Me.pbxFrontBar.BackColor = System.Drawing.Color.Silver
        Me.pbxFrontBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbxFrontBar.Location = New System.Drawing.Point(0, 0)
        Me.pbxFrontBar.Name = "pbxFrontBar"
        Me.pbxFrontBar.Size = New System.Drawing.Size(320, 240)
        Me.pbxFrontBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxFrontBar.TabIndex = 0
        Me.pbxFrontBar.TabStop = False
        '
        'pbxDashCam
        '
        Me.pbxDashCam.BackColor = System.Drawing.Color.Silver
        Me.pbxDashCam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbxDashCam.Location = New System.Drawing.Point(0, 246)
        Me.pbxDashCam.Name = "pbxDashCam"
        Me.pbxDashCam.Size = New System.Drawing.Size(320, 240)
        Me.pbxDashCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxDashCam.TabIndex = 1
        Me.pbxDashCam.TabStop = False
        '
        'pbxRearCamera
        '
        Me.pbxRearCamera.BackColor = System.Drawing.Color.Silver
        Me.pbxRearCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbxRearCamera.Location = New System.Drawing.Point(0, 501)
        Me.pbxRearCamera.Name = "pbxRearCamera"
        Me.pbxRearCamera.Size = New System.Drawing.Size(320, 240)
        Me.pbxRearCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRearCamera.TabIndex = 2
        Me.pbxRearCamera.TabStop = False
        '
        'bwDashRecorder
        '
        '
        'Cameras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.pbxRearCamera)
        Me.Controls.Add(Me.pbxDashCam)
        Me.Controls.Add(Me.pbxFrontBar)
        Me.Name = "Cameras"
        Me.Size = New System.Drawing.Size(768, 756)
        CType(Me.pbxFrontBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxDashCam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRearCamera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bwCamera0 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwCamera1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwCamera2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pbxFrontBar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxDashCam As System.Windows.Forms.PictureBox
    Friend WithEvents pbxRearCamera As System.Windows.Forms.PictureBox
    Friend WithEvents bwDashRecorder As System.ComponentModel.BackgroundWorker
End Class
