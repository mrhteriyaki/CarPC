<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlaylistLibrary
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
        Me.gbxPlayLists = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'gbxPlayLists
        '
        Me.gbxPlayLists.ForeColor = System.Drawing.Color.White
        Me.gbxPlayLists.Location = New System.Drawing.Point(3, 3)
        Me.gbxPlayLists.Name = "gbxPlayLists"
        Me.gbxPlayLists.Size = New System.Drawing.Size(556, 397)
        Me.gbxPlayLists.TabIndex = 9
        Me.gbxPlayLists.TabStop = False
        Me.gbxPlayLists.Text = "PlayLists"
        '
        'PlaylistLibrary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.gbxPlayLists)
        Me.Name = "PlaylistLibrary"
        Me.Size = New System.Drawing.Size(583, 424)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxPlayLists As System.Windows.Forms.GroupBox

End Class
