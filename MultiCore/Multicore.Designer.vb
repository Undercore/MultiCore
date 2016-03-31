<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Multicore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Multicore))
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Parse = New System.Windows.Forms.Button()
        Me.scrape = New System.Windows.Forms.Button()
        Me.btn_Check = New System.Windows.Forms.Button()
        Me.ThreadCOUNT = New System.Windows.Forms.NumericUpDown()
        Me.btn_Scrape = New System.Windows.Forms.Button()
        Me.LB_Grab = New System.Windows.Forms.ListBox()
        CType(Me.ThreadCOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(922, 503)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(132, 33)
        Me.btn_Save.TabIndex = 2
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(784, 503)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(132, 33)
        Me.btn_Clear.TabIndex = 4
        Me.btn_Clear.Text = "Clear"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Parse
        '
        Me.btn_Parse.Location = New System.Drawing.Point(647, 504)
        Me.btn_Parse.Name = "btn_Parse"
        Me.btn_Parse.Size = New System.Drawing.Size(131, 33)
        Me.btn_Parse.TabIndex = 6
        Me.btn_Parse.Text = "Parse"
        Me.btn_Parse.UseVisualStyleBackColor = True
        '
        'scrape
        '
        Me.scrape.Location = New System.Drawing.Point(510, 503)
        Me.scrape.Name = "scrape"
        Me.scrape.Size = New System.Drawing.Size(131, 33)
        Me.scrape.TabIndex = 9
        Me.scrape.Text = "Scrape"
        Me.scrape.UseVisualStyleBackColor = True
        '
        'btn_Check
        '
        Me.btn_Check.Location = New System.Drawing.Point(373, 503)
        Me.btn_Check.Name = "btn_Check"
        Me.btn_Check.Size = New System.Drawing.Size(131, 33)
        Me.btn_Check.TabIndex = 7
        Me.btn_Check.Text = "Check"
        Me.btn_Check.UseVisualStyleBackColor = True
        '
        'ThreadCOUNT
        '
        Me.ThreadCOUNT.Location = New System.Drawing.Point(150, 515)
        Me.ThreadCOUNT.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ThreadCOUNT.Name = "ThreadCOUNT"
        Me.ThreadCOUNT.Size = New System.Drawing.Size(96, 26)
        Me.ThreadCOUNT.TabIndex = 3
        Me.ThreadCOUNT.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'btn_Scrape
        '
        Me.btn_Scrape.Location = New System.Drawing.Point(13, 511)
        Me.btn_Scrape.Name = "btn_Scrape"
        Me.btn_Scrape.Size = New System.Drawing.Size(131, 33)
        Me.btn_Scrape.TabIndex = 1
        Me.btn_Scrape.Text = "Grab"
        Me.btn_Scrape.UseVisualStyleBackColor = True
        '
        'LB_Grab
        '
        Me.LB_Grab.FormattingEnabled = True
        Me.LB_Grab.ItemHeight = 20
        Me.LB_Grab.Location = New System.Drawing.Point(13, 13)
        Me.LB_Grab.Name = "LB_Grab"
        Me.LB_Grab.Size = New System.Drawing.Size(1041, 484)
        Me.LB_Grab.TabIndex = 8
        '
        'Multicore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 553)
        Me.Controls.Add(Me.scrape)
        Me.Controls.Add(Me.LB_Grab)
        Me.Controls.Add(Me.btn_Check)
        Me.Controls.Add(Me.btn_Parse)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.ThreadCOUNT)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.btn_Scrape)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Multicore"
        Me.Text = "MultiCore "
        CType(Me.ThreadCOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_Save As Button
    Friend WithEvents btn_Clear As Button
    Friend WithEvents btn_Parse As Button
    Friend WithEvents scrape As Button
    Friend WithEvents btn_Check As Button
    Friend WithEvents ThreadCOUNT As NumericUpDown
    Friend WithEvents btn_Scrape As Button
    Friend WithEvents LB_Grab As ListBox
End Class
