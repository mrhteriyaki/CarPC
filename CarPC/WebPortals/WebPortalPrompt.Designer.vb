<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebPortalPrompt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WebPortalPrompt))
        Me.btnFacebook = New System.Windows.Forms.Button()
        Me.btnYoutube = New System.Windows.Forms.Button()
        Me.btnSpotify = New System.Windows.Forms.Button()
        Me.btnSoundCloud = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnFacebook
        '
        Me.btnFacebook.BackColor = System.Drawing.Color.Black
        Me.btnFacebook.BackgroundImage = CType(resources.GetObject("btnFacebook.BackgroundImage"), System.Drawing.Image)
        Me.btnFacebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFacebook.Location = New System.Drawing.Point(330, 0)
        Me.btnFacebook.Name = "btnFacebook"
        Me.btnFacebook.Size = New System.Drawing.Size(110, 110)
        Me.btnFacebook.TabIndex = 26
        Me.btnFacebook.UseVisualStyleBackColor = False
        '
        'btnYoutube
        '
        Me.btnYoutube.BackColor = System.Drawing.Color.Black
        Me.btnYoutube.BackgroundImage = CType(resources.GetObject("btnYoutube.BackgroundImage"), System.Drawing.Image)
        Me.btnYoutube.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnYoutube.Location = New System.Drawing.Point(220, 0)
        Me.btnYoutube.Name = "btnYoutube"
        Me.btnYoutube.Size = New System.Drawing.Size(110, 110)
        Me.btnYoutube.TabIndex = 25
        Me.btnYoutube.UseVisualStyleBackColor = False
        '
        'btnSpotify
        '
        Me.btnSpotify.BackColor = System.Drawing.Color.Black
        Me.btnSpotify.BackgroundImage = CType(resources.GetObject("btnSpotify.BackgroundImage"), System.Drawing.Image)
        Me.btnSpotify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSpotify.Location = New System.Drawing.Point(110, 0)
        Me.btnSpotify.Name = "btnSpotify"
        Me.btnSpotify.Size = New System.Drawing.Size(110, 110)
        Me.btnSpotify.TabIndex = 24
        Me.btnSpotify.UseVisualStyleBackColor = False
        '
        'btnSoundCloud
        '
        Me.btnSoundCloud.BackColor = System.Drawing.Color.Black
        Me.btnSoundCloud.BackgroundImage = CType(resources.GetObject("btnSoundCloud.BackgroundImage"), System.Drawing.Image)
        Me.btnSoundCloud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSoundCloud.Location = New System.Drawing.Point(0, 0)
        Me.btnSoundCloud.Name = "btnSoundCloud"
        Me.btnSoundCloud.Size = New System.Drawing.Size(110, 110)
        Me.btnSoundCloud.TabIndex = 23
        Me.btnSoundCloud.UseVisualStyleBackColor = False
        '
        'WebPortalPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(440, 110)
        Me.Controls.Add(Me.btnFacebook)
        Me.Controls.Add(Me.btnYoutube)
        Me.Controls.Add(Me.btnSpotify)
        Me.Controls.Add(Me.btnSoundCloud)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WebPortalPrompt"
        Me.Text = "WebPortalPrompt"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFacebook As System.Windows.Forms.Button
    Friend WithEvents btnYoutube As System.Windows.Forms.Button
    Friend WithEvents btnSpotify As System.Windows.Forms.Button
    Friend WithEvents btnSoundCloud As System.Windows.Forms.Button
End Class
