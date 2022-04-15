<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MusicLibrary
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
        Me.gbxLibrary = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClearPlaylist = New System.Windows.Forms.Button()
        Me.btnPlaylists = New System.Windows.Forms.Button()
        Me.btnLibFileBrowse = New System.Windows.Forms.Button()
        Me.gbxLibrary.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxLibrary
        '
        Me.gbxLibrary.BackColor = System.Drawing.Color.Black
        Me.gbxLibrary.Controls.Add(Me.btnSearch)
        Me.gbxLibrary.Controls.Add(Me.btnClearPlaylist)
        Me.gbxLibrary.Controls.Add(Me.btnPlaylists)
        Me.gbxLibrary.Controls.Add(Me.btnLibFileBrowse)
        Me.gbxLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxLibrary.ForeColor = System.Drawing.Color.White
        Me.gbxLibrary.Location = New System.Drawing.Point(3, 3)
        Me.gbxLibrary.Name = "gbxLibrary"
        Me.gbxLibrary.Size = New System.Drawing.Size(735, 65)
        Me.gbxLibrary.TabIndex = 15
        Me.gbxLibrary.TabStop = False
        Me.gbxLibrary.Text = "Music Library"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Black
        Me.btnSearch.Enabled = False
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(286, 19)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(134, 39)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnClearPlaylist
        '
        Me.btnClearPlaylist.BackColor = System.Drawing.Color.Black
        Me.btnClearPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearPlaylist.Location = New System.Drawing.Point(562, 15)
        Me.btnClearPlaylist.Name = "btnClearPlaylist"
        Me.btnClearPlaylist.Size = New System.Drawing.Size(167, 46)
        Me.btnClearPlaylist.TabIndex = 6
        Me.btnClearPlaylist.Text = "Clear Playlist"
        Me.btnClearPlaylist.UseVisualStyleBackColor = False
        '
        'btnPlaylists
        '
        Me.btnPlaylists.BackColor = System.Drawing.Color.Black
        Me.btnPlaylists.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlaylists.Location = New System.Drawing.Point(6, 19)
        Me.btnPlaylists.Name = "btnPlaylists"
        Me.btnPlaylists.Size = New System.Drawing.Size(134, 39)
        Me.btnPlaylists.TabIndex = 1
        Me.btnPlaylists.Text = "PlayLists"
        Me.btnPlaylists.UseVisualStyleBackColor = False
        '
        'btnLibFileBrowse
        '
        Me.btnLibFileBrowse.BackColor = System.Drawing.Color.Black
        Me.btnLibFileBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLibFileBrowse.Location = New System.Drawing.Point(146, 19)
        Me.btnLibFileBrowse.Name = "btnLibFileBrowse"
        Me.btnLibFileBrowse.Size = New System.Drawing.Size(134, 39)
        Me.btnLibFileBrowse.TabIndex = 0
        Me.btnLibFileBrowse.Text = "File Browser"
        Me.btnLibFileBrowse.UseVisualStyleBackColor = False
        '
        'MusicLibrary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.gbxLibrary)
        Me.Name = "MusicLibrary"
        Me.Size = New System.Drawing.Size(743, 75)
        Me.gbxLibrary.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxLibrary As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClearPlaylist As System.Windows.Forms.Button
    Friend WithEvents btnPlaylists As System.Windows.Forms.Button
    Friend WithEvents btnLibFileBrowse As System.Windows.Forms.Button

End Class
