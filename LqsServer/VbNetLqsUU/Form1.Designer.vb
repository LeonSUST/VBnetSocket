<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CBallornot
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CBallornot))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblOnline = New System.Windows.Forms.Label
        Me.LBLcount = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuLqs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuShowme = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.ContextMenuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ContextMenuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuFile = New System.Windows.Forms.MenuStrip
        Me.文件FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFileAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BtnSend = New System.Windows.Forms.Button
        Me.TBsend = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LBuserOnLine = New System.Windows.Forms.CheckedListBox
        Me.select_all = New System.Windows.Forms.CheckBox
        Me.ContextMenuLqs.SuspendLayout()
        Me.MenuFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(2, 27)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(589, 533)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(599, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "在线用户:"
        '
        'LblOnline
        '
        Me.LblOnline.AutoSize = True
        Me.LblOnline.Location = New System.Drawing.Point(664, 30)
        Me.LblOnline.Name = "LblOnline"
        Me.LblOnline.Size = New System.Drawing.Size(11, 12)
        Me.LblOnline.TabIndex = 6
        Me.LblOnline.Text = "0"
        '
        'LBLcount
        '
        Me.LBLcount.AutoSize = True
        Me.LBLcount.Location = New System.Drawing.Point(715, 29)
        Me.LBLcount.Name = "LBLcount"
        Me.LBLcount.Size = New System.Drawing.Size(29, 12)
        Me.LBLcount.TabIndex = 7
        Me.LBLcount.Text = "/100"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuLqs
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "镇江雨水情 server端"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuLqs
        '
        Me.ContextMenuLqs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuShowme, Me.ToolStripMenuItem2, Me.ContextMenuAbout, Me.ToolStripMenuItem1, Me.ContextMenuExit})
        Me.ContextMenuLqs.Name = "ContextMenuLqs"
        Me.ContextMenuLqs.Size = New System.Drawing.Size(134, 82)
        '
        'ContextMenuShowme
        '
        Me.ContextMenuShowme.Name = "ContextMenuShowme"
        Me.ContextMenuShowme.Size = New System.Drawing.Size(133, 22)
        Me.ContextMenuShowme.Text = "显示程序"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(130, 6)
        '
        'ContextMenuAbout
        '
        Me.ContextMenuAbout.Name = "ContextMenuAbout"
        Me.ContextMenuAbout.Size = New System.Drawing.Size(133, 22)
        Me.ContextMenuAbout.Text = "关于程序..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(130, 6)
        '
        'ContextMenuExit
        '
        Me.ContextMenuExit.Name = "ContextMenuExit"
        Me.ContextMenuExit.Size = New System.Drawing.Size(133, 22)
        Me.ContextMenuExit.Text = "退出程序"
        '
        'MenuFile
        '
        Me.MenuFile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件FToolStripMenuItem})
        Me.MenuFile.Location = New System.Drawing.Point(0, 0)
        Me.MenuFile.Name = "MenuFile"
        Me.MenuFile.Size = New System.Drawing.Size(770, 25)
        Me.MenuFile.TabIndex = 8
        Me.MenuFile.Text = "MenuStrip1"
        '
        '文件FToolStripMenuItem
        '
        Me.文件FToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileAbout, Me.mnuFileExit})
        Me.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem"
        Me.文件FToolStripMenuItem.Size = New System.Drawing.Size(58, 21)
        Me.文件FToolStripMenuItem.Text = "文件(&F)"
        '
        'mnuFileAbout
        '
        Me.mnuFileAbout.Name = "mnuFileAbout"
        Me.mnuFileAbout.Size = New System.Drawing.Size(133, 22)
        Me.mnuFileAbout.Text = "关于程序..."
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(133, 22)
        Me.mnuFileExit.Text = "退出程序"
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Location = New System.Drawing.Point(661, 566)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(97, 24)
        Me.BtnSend.TabIndex = 9
        Me.BtnSend.Text = "群发消息"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'TBsend
        '
        Me.TBsend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TBsend.Location = New System.Drawing.Point(2, 566)
        Me.TBsend.Name = "TBsend"
        Me.TBsend.Size = New System.Drawing.Size(589, 21)
        Me.TBsend.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 590)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Label1"
        '
        'LBuserOnLine
        '
        Me.LBuserOnLine.CheckOnClick = True
        Me.LBuserOnLine.FormattingEnabled = True
        Me.LBuserOnLine.Location = New System.Drawing.Point(597, 45)
        Me.LBuserOnLine.Name = "LBuserOnLine"
        Me.LBuserOnLine.Size = New System.Drawing.Size(171, 516)
        Me.LBuserOnLine.TabIndex = 12
        '
        'select_all
        '
        Me.select_all.AutoSize = True
        Me.select_all.Location = New System.Drawing.Point(601, 571)
        Me.select_all.Name = "select_all"
        Me.select_all.Size = New System.Drawing.Size(48, 16)
        Me.select_all.TabIndex = 13
        Me.select_all.Text = "全选"
        Me.select_all.UseVisualStyleBackColor = True
        '
        'CBallornot
        '
        Me.AcceptButton = Me.BtnSend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 602)
        Me.Controls.Add(Me.LBuserOnLine)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBsend)
        Me.Controls.Add(Me.select_all)
        Me.Controls.Add(Me.LblOnline)
        Me.Controls.Add(Me.LBLcount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnSend)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuFile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuFile
        Me.MaximizeBox = False
        Me.Name = "CBallornot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "vb.net   服务器端   同步Accept   异步接收发送  V1.0版"
        Me.ContextMenuLqs.ResumeLayout(False)
        Me.MenuFile.ResumeLayout(False)
        Me.MenuFile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblOnline As System.Windows.Forms.Label
    Friend WithEvents LBLcount As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents MenuFile As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件FToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuLqs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuShowme As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BtnSend As System.Windows.Forms.Button
    Friend WithEvents TBsend As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBuserOnLine As System.Windows.Forms.CheckedListBox
    Friend WithEvents select_all As System.Windows.Forms.CheckBox

End Class
