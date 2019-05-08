<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNconnectSvr = New System.Windows.Forms.Button
        Me.BTNsenmsg = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TBTP = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TBPort = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(2, 37)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(725, 240)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 295)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "内容："
        '
        'BTNconnectSvr
        '
        Me.BTNconnectSvr.Location = New System.Drawing.Point(576, 0)
        Me.BTNconnectSvr.Name = "BTNconnectSvr"
        Me.BTNconnectSvr.Size = New System.Drawing.Size(141, 32)
        Me.BTNconnectSvr.TabIndex = 2
        Me.BTNconnectSvr.Text = "连接服务器"
        Me.BTNconnectSvr.UseVisualStyleBackColor = True
        '
        'BTNsenmsg
        '
        Me.BTNsenmsg.Location = New System.Drawing.Point(576, 283)
        Me.BTNsenmsg.Name = "BTNsenmsg"
        Me.BTNsenmsg.Size = New System.Drawing.Size(141, 32)
        Me.BTNsenmsg.TabIndex = 3
        Me.BTNsenmsg.Text = "发送信息到服务器"
        Me.BTNsenmsg.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 335)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "备注："
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(41, 290)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(529, 21)
        Me.TextBox1.TabIndex = 6
        '
        'TBTP
        '
        Me.TBTP.Location = New System.Drawing.Point(89, 7)
        Me.TBTP.Name = "TBTP"
        Me.TBTP.Size = New System.Drawing.Size(145, 21)
        Me.TBTP.TabIndex = 7
        Me.TBTP.Text = "127.0.0.1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "服务器IP地址:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(323, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "端口:"
        '
        'TBPort
        '
        Me.TBPort.Location = New System.Drawing.Point(364, 7)
        Me.TBPort.Name = "TBPort"
        Me.TBPort.Size = New System.Drawing.Size(129, 21)
        Me.TBPort.TabIndex = 10
        Me.TBPort.Text = "502"
        '
        'FrmMain
        '
        Me.AcceptButton = Me.BTNsenmsg
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 380)
        Me.Controls.Add(Me.TBPort)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TBTP)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTNsenmsg)
        Me.Controls.Add(Me.BTNconnectSvr)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "客户端 同步"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNconnectSvr As System.Windows.Forms.Button
    Friend WithEvents BTNsenmsg As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TBTP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TBPort As System.Windows.Forms.TextBox

End Class
