<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Parse
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Parse))
        Me.btn_Parse = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.LB_ParsedProxies = New System.Windows.Forms.ListBox()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.TB_ParseFromPage = New System.Windows.Forms.TextBox()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_Parse
        '
        Me.btn_Parse.Location = New System.Drawing.Point(16, 383)
        Me.btn_Parse.Name = "btn_Parse"
        Me.btn_Parse.Size = New System.Drawing.Size(144, 34)
        Me.btn_Parse.TabIndex = 4
        Me.btn_Parse.Text = "Parse"
        Me.btn_Parse.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(688, 383)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(144, 34)
        Me.btn_Save.TabIndex = 5
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'LB_ParsedProxies
        '
        Me.LB_ParsedProxies.FormattingEnabled = True
        Me.LB_ParsedProxies.ItemHeight = 20
        Me.LB_ParsedProxies.Location = New System.Drawing.Point(16, 12)
        Me.LB_ParsedProxies.Name = "LB_ParsedProxies"
        Me.LB_ParsedProxies.Size = New System.Drawing.Size(816, 344)
        Me.LB_ParsedProxies.TabIndex = 8
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(538, 383)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(144, 34)
        Me.btn_Clear.TabIndex = 11
        Me.btn_Clear.Text = "Clear"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'TB_ParseFromPage
        '
        Me.TB_ParseFromPage.Location = New System.Drawing.Point(16, 12)
        Me.TB_ParseFromPage.Name = "TB_ParseFromPage"
        Me.TB_ParseFromPage.Size = New System.Drawing.Size(241, 26)
        Me.TB_ParseFromPage.TabIndex = 12
        Me.TB_ParseFromPage.Text = "Enter website to parse"
        '
        'btn_Close
        '
        Me.btn_Close.Location = New System.Drawing.Point(166, 383)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(144, 34)
        Me.btn_Close.TabIndex = 13
        Me.btn_Close.Text = "Close"
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'Parse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 432)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.TB_ParseFromPage)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.LB_ParsedProxies)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.btn_Parse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Parse"
        Me.Text = "Parse"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Parse As Button
    Friend WithEvents btn_Save As Button
    Friend WithEvents LB_ParsedProxies As ListBox
    Friend WithEvents btn_Clear As Button
    Friend WithEvents TB_ParseFromPage As TextBox
    Friend WithEvents btn_Close As Button
End Class
