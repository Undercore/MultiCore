<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Scrape
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Scrape))
        Me.RTB_UnParsed = New System.Windows.Forms.RichTextBox()
        Me.LB_ParsedProxies = New System.Windows.Forms.ListBox()
        Me.btn_Parse = New System.Windows.Forms.Button()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RTB_UnParsed
        '
        Me.RTB_UnParsed.Location = New System.Drawing.Point(13, 13)
        Me.RTB_UnParsed.Name = "RTB_UnParsed"
        Me.RTB_UnParsed.Size = New System.Drawing.Size(398, 364)
        Me.RTB_UnParsed.TabIndex = 0
        Me.RTB_UnParsed.Text = ""
        '
        'LB_ParsedProxies
        '
        Me.LB_ParsedProxies.FormattingEnabled = True
        Me.LB_ParsedProxies.ItemHeight = 20
        Me.LB_ParsedProxies.Location = New System.Drawing.Point(478, 13)
        Me.LB_ParsedProxies.Name = "LB_ParsedProxies"
        Me.LB_ParsedProxies.Size = New System.Drawing.Size(398, 364)
        Me.LB_ParsedProxies.TabIndex = 1
        '
        'btn_Parse
        '
        Me.btn_Parse.Location = New System.Drawing.Point(13, 395)
        Me.btn_Parse.Name = "btn_Parse"
        Me.btn_Parse.Size = New System.Drawing.Size(144, 34)
        Me.btn_Parse.TabIndex = 5
        Me.btn_Parse.Text = "Parse"
        Me.btn_Parse.UseVisualStyleBackColor = True
        '
        'btn_Close
        '
        Me.btn_Close.Location = New System.Drawing.Point(163, 395)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(144, 34)
        Me.btn_Close.TabIndex = 6
        Me.btn_Close.Text = "Close"
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(582, 395)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(144, 34)
        Me.btn_Clear.TabIndex = 7
        Me.btn_Clear.Text = "Clear"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(732, 395)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(144, 34)
        Me.btn_Save.TabIndex = 8
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'Scrape
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 444)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.btn_Parse)
        Me.Controls.Add(Me.LB_ParsedProxies)
        Me.Controls.Add(Me.RTB_UnParsed)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Scrape"
        Me.Text = "Scrape"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RTB_UnParsed As RichTextBox
    Friend WithEvents LB_ParsedProxies As ListBox
    Friend WithEvents btn_Parse As Button
    Friend WithEvents btn_Close As Button
    Friend WithEvents btn_Clear As Button
    Friend WithEvents btn_Save As Button
End Class
