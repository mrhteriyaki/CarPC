<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YouTube
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
        Me.WebBrowserControl = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'WebBrowserControl
        '
        Me.WebBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowserControl.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowserControl.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowserControl.Name = "WebBrowserControl"
        Me.WebBrowserControl.Size = New System.Drawing.Size(551, 466)
        Me.WebBrowserControl.TabIndex = 2
        Me.WebBrowserControl.Url = New System.Uri("http://m.youtube.com", System.UriKind.Absolute)
        '
        'YouTube
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WebBrowserControl)
        Me.Name = "YouTube"
        Me.Size = New System.Drawing.Size(551, 466)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowserControl As System.Windows.Forms.WebBrowser

End Class
