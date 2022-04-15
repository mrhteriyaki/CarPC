<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Playlist
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
        Me.tmrButtonPressDelay = New System.Windows.Forms.Timer(Me.components)
        Me.lbxPlaylist = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'tmrButtonPressDelay
        '
        Me.tmrButtonPressDelay.Enabled = True
        Me.tmrButtonPressDelay.Interval = 50
        '
        'lbxPlaylist
        '
        Me.lbxPlaylist.BackColor = System.Drawing.Color.Black
        Me.lbxPlaylist.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.lbxPlaylist.ForeColor = System.Drawing.Color.White
        Me.lbxPlaylist.FormattingEnabled = True
        Me.lbxPlaylist.ItemHeight = 29
        Me.lbxPlaylist.Location = New System.Drawing.Point(3, 10)
        Me.lbxPlaylist.Name = "lbxPlaylist"
        Me.lbxPlaylist.Size = New System.Drawing.Size(299, 294)
        Me.lbxPlaylist.TabIndex = 22
        '
        'Playlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.lbxPlaylist)
        Me.Name = "Playlist"
        Me.Size = New System.Drawing.Size(305, 318)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrButtonPressDelay As System.Windows.Forms.Timer
    Friend WithEvents lbxPlaylist As System.Windows.Forms.ListBox

End Class
