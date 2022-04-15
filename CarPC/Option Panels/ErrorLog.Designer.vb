<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorLog
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
        Me.txtDebugLog = New System.Windows.Forms.TextBox()
        Me.btnDebugModeOn = New System.Windows.Forms.Button()
        Me.btnDebugModeOff = New System.Windows.Forms.Button()
        Me.tmrErroLog = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'txtDebugLog
        '
        Me.txtDebugLog.BackColor = System.Drawing.Color.Black
        Me.txtDebugLog.ForeColor = System.Drawing.Color.White
        Me.txtDebugLog.Location = New System.Drawing.Point(5, 15)
        Me.txtDebugLog.Multiline = True
        Me.txtDebugLog.Name = "txtDebugLog"
        Me.txtDebugLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDebugLog.Size = New System.Drawing.Size(555, 550)
        Me.txtDebugLog.TabIndex = 1
        '
        'btnDebugModeOn
        '
        Me.btnDebugModeOn.BackColor = System.Drawing.Color.Black
        Me.btnDebugModeOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDebugModeOn.ForeColor = System.Drawing.Color.White
        Me.btnDebugModeOn.Location = New System.Drawing.Point(566, 15)
        Me.btnDebugModeOn.Name = "btnDebugModeOn"
        Me.btnDebugModeOn.Size = New System.Drawing.Size(235, 69)
        Me.btnDebugModeOn.TabIndex = 47
        Me.btnDebugModeOn.Text = "Debug Mode On"
        Me.btnDebugModeOn.UseVisualStyleBackColor = False
        '
        'btnDebugModeOff
        '
        Me.btnDebugModeOff.BackColor = System.Drawing.Color.Black
        Me.btnDebugModeOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDebugModeOff.ForeColor = System.Drawing.Color.White
        Me.btnDebugModeOff.Location = New System.Drawing.Point(566, 90)
        Me.btnDebugModeOff.Name = "btnDebugModeOff"
        Me.btnDebugModeOff.Size = New System.Drawing.Size(235, 69)
        Me.btnDebugModeOff.TabIndex = 48
        Me.btnDebugModeOff.Text = "Debug Mode Off"
        Me.btnDebugModeOff.UseVisualStyleBackColor = False
        '
        'tmrErroLog
        '
        '
        'ErrorLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.btnDebugModeOff)
        Me.Controls.Add(Me.btnDebugModeOn)
        Me.Controls.Add(Me.txtDebugLog)
        Me.Name = "ErrorLog"
        Me.Size = New System.Drawing.Size(827, 570)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDebugLog As System.Windows.Forms.TextBox
    Friend WithEvents btnDebugModeOn As System.Windows.Forms.Button
    Friend WithEvents btnDebugModeOff As System.Windows.Forms.Button
    Friend WithEvents tmrErroLog As System.Windows.Forms.Timer

End Class
