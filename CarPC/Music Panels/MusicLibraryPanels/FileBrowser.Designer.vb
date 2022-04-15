<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileBrowser))
        Me.gbxFileBrowser = New System.Windows.Forms.GroupBox()
        Me.lbxDownFolder = New System.Windows.Forms.ListBox()
        Me.lbxCurrentFolder = New System.Windows.Forms.ListBox()
        Me.btnDownFolder = New System.Windows.Forms.Button()
        Me.btnUpDirectory = New System.Windows.Forms.Button()
        Me.btnAddFile = New System.Windows.Forms.Button()
        Me.btnAddFolder = New System.Windows.Forms.Button()
        Me.gbxFileBrowser.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxFileBrowser
        '
        Me.gbxFileBrowser.Controls.Add(Me.lbxDownFolder)
        Me.gbxFileBrowser.Controls.Add(Me.lbxCurrentFolder)
        Me.gbxFileBrowser.Controls.Add(Me.btnDownFolder)
        Me.gbxFileBrowser.Controls.Add(Me.btnUpDirectory)
        Me.gbxFileBrowser.Controls.Add(Me.btnAddFile)
        Me.gbxFileBrowser.Controls.Add(Me.btnAddFolder)
        Me.gbxFileBrowser.ForeColor = System.Drawing.Color.White
        Me.gbxFileBrowser.Location = New System.Drawing.Point(3, -2)
        Me.gbxFileBrowser.Name = "gbxFileBrowser"
        Me.gbxFileBrowser.Size = New System.Drawing.Size(737, 660)
        Me.gbxFileBrowser.TabIndex = 3
        Me.gbxFileBrowser.TabStop = False
        Me.gbxFileBrowser.Text = "File Browser"
        '
        'lbxDownFolder
        '
        Me.lbxDownFolder.BackColor = System.Drawing.Color.Black
        Me.lbxDownFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!)
        Me.lbxDownFolder.ForeColor = System.Drawing.Color.White
        Me.lbxDownFolder.FormattingEnabled = True
        Me.lbxDownFolder.ItemHeight = 33
        Me.lbxDownFolder.Location = New System.Drawing.Point(375, 14)
        Me.lbxDownFolder.Name = "lbxDownFolder"
        Me.lbxDownFolder.Size = New System.Drawing.Size(350, 565)
        Me.lbxDownFolder.TabIndex = 25
        '
        'lbxCurrentFolder
        '
        Me.lbxCurrentFolder.BackColor = System.Drawing.Color.Black
        Me.lbxCurrentFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!)
        Me.lbxCurrentFolder.ForeColor = System.Drawing.Color.White
        Me.lbxCurrentFolder.FormattingEnabled = True
        Me.lbxCurrentFolder.ItemHeight = 33
        Me.lbxCurrentFolder.Location = New System.Drawing.Point(10, 14)
        Me.lbxCurrentFolder.Name = "lbxCurrentFolder"
        Me.lbxCurrentFolder.Size = New System.Drawing.Size(360, 565)
        Me.lbxCurrentFolder.TabIndex = 24
        '
        'btnDownFolder
        '
        Me.btnDownFolder.BackColor = System.Drawing.Color.Black
        Me.btnDownFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnDownFolder.Image = CType(resources.GetObject("btnDownFolder.Image"), System.Drawing.Image)
        Me.btnDownFolder.Location = New System.Drawing.Point(190, 585)
        Me.btnDownFolder.Name = "btnDownFolder"
        Me.btnDownFolder.Size = New System.Drawing.Size(180, 70)
        Me.btnDownFolder.TabIndex = 6
        Me.btnDownFolder.UseVisualStyleBackColor = False
        '
        'btnUpDirectory
        '
        Me.btnUpDirectory.BackColor = System.Drawing.Color.Black
        Me.btnUpDirectory.Enabled = False
        Me.btnUpDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.btnUpDirectory.Image = CType(resources.GetObject("btnUpDirectory.Image"), System.Drawing.Image)
        Me.btnUpDirectory.Location = New System.Drawing.Point(10, 585)
        Me.btnUpDirectory.Name = "btnUpDirectory"
        Me.btnUpDirectory.Size = New System.Drawing.Size(180, 70)
        Me.btnUpDirectory.TabIndex = 5
        Me.btnUpDirectory.UseVisualStyleBackColor = False
        '
        'btnAddFile
        '
        Me.btnAddFile.BackColor = System.Drawing.Color.Black
        Me.btnAddFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddFile.Image = CType(resources.GetObject("btnAddFile.Image"), System.Drawing.Image)
        Me.btnAddFile.Location = New System.Drawing.Point(550, 585)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(175, 70)
        Me.btnAddFile.TabIndex = 4
        Me.btnAddFile.UseVisualStyleBackColor = False
        '
        'btnAddFolder
        '
        Me.btnAddFolder.BackColor = System.Drawing.Color.Black
        Me.btnAddFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddFolder.Image = CType(resources.GetObject("btnAddFolder.Image"), System.Drawing.Image)
        Me.btnAddFolder.Location = New System.Drawing.Point(375, 585)
        Me.btnAddFolder.Name = "btnAddFolder"
        Me.btnAddFolder.Size = New System.Drawing.Size(175, 70)
        Me.btnAddFolder.TabIndex = 3
        Me.btnAddFolder.UseVisualStyleBackColor = False
        '
        'FileBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.gbxFileBrowser)
        Me.Name = "FileBrowser"
        Me.Size = New System.Drawing.Size(748, 664)
        Me.gbxFileBrowser.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxFileBrowser As System.Windows.Forms.GroupBox
    Friend WithEvents btnDownFolder As System.Windows.Forms.Button
    Friend WithEvents btnUpDirectory As System.Windows.Forms.Button
    Friend WithEvents btnAddFile As System.Windows.Forms.Button
    Friend WithEvents btnAddFolder As System.Windows.Forms.Button
    Friend WithEvents lbxDownFolder As System.Windows.Forms.ListBox
    Friend WithEvents lbxCurrentFolder As System.Windows.Forms.ListBox

End Class
