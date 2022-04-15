<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchControl
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
        Me.txtSearchQuery = New System.Windows.Forms.TextBox()
        Me.bwSearch = New System.ComponentModel.BackgroundWorker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnAddtoPlaylist = New System.Windows.Forms.Button()
        Me.btnAddSelected = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnKeyboard = New System.Windows.Forms.Button()
        Me.lbxSearch = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'txtSearchQuery
        '
        Me.txtSearchQuery.BackColor = System.Drawing.Color.Black
        Me.txtSearchQuery.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchQuery.ForeColor = System.Drawing.Color.White
        Me.txtSearchQuery.Location = New System.Drawing.Point(14, 35)
        Me.txtSearchQuery.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearchQuery.Name = "txtSearchQuery"
        Me.txtSearchQuery.Size = New System.Drawing.Size(1099, 80)
        Me.txtSearchQuery.TabIndex = 0
        '
        'bwSearch
        '
        Me.bwSearch.WorkerReportsProgress = True
        Me.bwSearch.WorkerSupportsCancellation = True
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Black
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(818, 168)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(297, 92)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnAddtoPlaylist
        '
        Me.btnAddtoPlaylist.BackColor = System.Drawing.Color.Black
        Me.btnAddtoPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddtoPlaylist.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddtoPlaylist.ForeColor = System.Drawing.Color.White
        Me.btnAddtoPlaylist.Location = New System.Drawing.Point(818, 642)
        Me.btnAddtoPlaylist.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddtoPlaylist.Name = "btnAddtoPlaylist"
        Me.btnAddtoPlaylist.Size = New System.Drawing.Size(297, 92)
        Me.btnAddtoPlaylist.TabIndex = 3
        Me.btnAddtoPlaylist.Text = "Add All to Playlist"
        Me.btnAddtoPlaylist.UseVisualStyleBackColor = False
        '
        'btnAddSelected
        '
        Me.btnAddSelected.BackColor = System.Drawing.Color.Black
        Me.btnAddSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSelected.ForeColor = System.Drawing.Color.White
        Me.btnAddSelected.Location = New System.Drawing.Point(818, 540)
        Me.btnAddSelected.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddSelected.Name = "btnAddSelected"
        Me.btnAddSelected.Size = New System.Drawing.Size(297, 92)
        Me.btnAddSelected.TabIndex = 4
        Me.btnAddSelected.Text = "Add Selected to Playlist"
        Me.btnAddSelected.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Black
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(818, 269)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(297, 92)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnKeyboard
        '
        Me.btnKeyboard.BackColor = System.Drawing.Color.Black
        Me.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKeyboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeyboard.ForeColor = System.Drawing.Color.White
        Me.btnKeyboard.Location = New System.Drawing.Point(818, 371)
        Me.btnKeyboard.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnKeyboard.Name = "btnKeyboard"
        Me.btnKeyboard.Size = New System.Drawing.Size(297, 92)
        Me.btnKeyboard.TabIndex = 6
        Me.btnKeyboard.Text = "Show / Close Keyboard"
        Me.btnKeyboard.UseVisualStyleBackColor = False
        '
        'lbxSearch
        '
        Me.lbxSearch.BackColor = System.Drawing.Color.Black
        Me.lbxSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbxSearch.ForeColor = System.Drawing.Color.White
        Me.lbxSearch.FormattingEnabled = True
        Me.lbxSearch.ItemHeight = 31
        Me.lbxSearch.Location = New System.Drawing.Point(14, 168)
        Me.lbxSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbxSearch.Name = "lbxSearch"
        Me.lbxSearch.Size = New System.Drawing.Size(793, 655)
        Me.lbxSearch.TabIndex = 7
        '
        'SearchControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.lbxSearch)
        Me.Controls.Add(Me.btnKeyboard)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnAddSelected)
        Me.Controls.Add(Me.btnAddtoPlaylist)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearchQuery)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "SearchControl"
        Me.Size = New System.Drawing.Size(1126, 855)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearchQuery As System.Windows.Forms.TextBox
    Friend WithEvents bwSearch As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnAddtoPlaylist As System.Windows.Forms.Button
    Friend WithEvents btnAddSelected As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnKeyboard As System.Windows.Forms.Button
    Friend WithEvents lbxSearch As System.Windows.Forms.ListBox

End Class
