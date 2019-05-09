
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class FrmMain
    '全局变量
    Public RemoteSvrIp As IPAddress                 '服务器IP地址 127.0.0.1 
    Public RemoteSvrPort As Integer                 '服务器socket监听的端口号 502
    Public RemoteSvrEP As IPEndPoint                '服务器地址簇  包含IP和端口号
    Public MySocket As Socket   '客户端用于连接的socket  

    Dim myThread As Thread
    Public Delegate Sub UpdateUIHandler(ByVal str1 As String) '委托 多线程中子线程更新主线程变量或界面，否则无法跨线程操作
    Public Sub ChangUI(ByVal str1 As String)
        If str1.Length > 0 Then RichTextBox1.AppendText(str1 & vbCrLf)
        If str1 = "服务器端主动断开了，待服务器端重新开启后再连接" Then
            BTNconnectSvr.Enabled = True
            BTNsenmsg.Enabled = False
            MySocket = Nothing
        End If

    End Sub
    Public Sub doeventSo(ByVal str1 As String) '下边是事件控制的方法更新UI 
        Dim handler As New UpdateUIHandler(AddressOf ChangUI)
        Dim args() As Object = {str1}
        Me.BeginInvoke(handler, args)
    End Sub


    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BTNsenmsg.Enabled = False
        RichTextBox1.AppendText("此处显示服务器端发来的信息:" & vbCrLf)
    End Sub


    '连接服务器
    Private Sub BTNconnectSvr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNconnectSvr.Click
        Try
            RemoteSvrIp = IPAddress.Parse(TBTP.Text.Trim)
        Catch ex As Exception
            Label2.Text = "IP地址输入错误"
            Exit Sub
        End Try

        Try
            RemoteSvrPort = CInt(TBPort.Text.Trim)
        Catch ex As Exception
            Label2.Text = "端口号输入错误"
            Exit Sub
        End Try


        RemoteSvrEP = New IPEndPoint(RemoteSvrIp, Int32.Parse(RemoteSvrPort)) '远程服务器地址和端口号
        MySocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)       '客户端用于连接的socket  

        Try
            MySocket.Connect(RemoteSvrEP)
            Label2.Text = "连接服务器成功！"
            BTNsenmsg.Enabled = True
            myThread = New Thread(AddressOf ReceiveThread)
            myThread.IsBackground = True
            myThread.Start()
            BTNconnectSvr.Enabled = False
        Catch ex As Exception
            Label2.Text = ex.ToString
        End Try

    End Sub

    '接收数据
    Public Sub ReceiveThread()
        Dim IntbytesReceive As Integer
        Dim bytes(256) As Byte
        If MySocket.Connected = True Then
            While (True)
                Try
                    IntbytesReceive = MySocket.Receive(bytes)

                    If IntbytesReceive > 0 Then '处理接收到的数据字节

                        '字节数组转16进制字符串()
                        Dim returnstr As String = ""
                        Dim i As Integer
                        Debug.Print(IntbytesReceive.ToString)
                        For i = 0 To IntbytesReceive - 1
                            returnstr += bytes(i).ToString("X2") & " "
                            'returnstr += bytes(i).ToString() & " "
                        Next

                        'doeventSo("接收：" & Encoding.Unicode.GetString(bytes, 0, IntbytesReceive).ToString)
                        doeventSo("接收：" & returnstr)
                    End If

                Catch ex As SocketException
                    MySocket.Shutdown(SocketShutdown.Both)
                    MySocket.Close()
                    doeventSo("服务器端主动断开了，待服务器端重新开启后再连接")
                    Exit While
                End Try
            End While
        End If
    End Sub

    '发送信息
    Private Sub BTNsenmsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNsenmsg.Click
        If MySocket.Connected = True Then
            Dim msg As Byte() = Encoding.Unicode.GetBytes(TextBox1.Text.ToString)

            Try
                MySocket.Send(msg)
                RichTextBox1.SelectionColor = Color.Blue
                RichTextBox1.AppendText("发送:" & TextBox1.Text.ToString & vbCrLf)
            Catch ex As Exception
                Label2.Text = ex.ToString
            End Try

        Else
            Label2.Text = "没有连接到服务器"
        End If
    End Sub

    '让RichTextBox始终显示最新来的数据
    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.ScrollToCaret()
    End Sub
End Class
