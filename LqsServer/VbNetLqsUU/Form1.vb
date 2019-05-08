'引入命名空间
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class CBallornot
    '全局变量
    Public SvrIp As IPAddress                 '服务器IP地址 127.0.0.1 
    Public SvrPort As Integer                 '服务器端口号 502
    Public Svr As IPEndPoint                  '服务器地址簇  包含IP和端口号
    Public SvrListenSocket As Socket          '服务器用于侦听的socket   
    Public SvrListenThread As Thread          '服务器socket侦听线程 
    Public Const IntMaxUser As Integer = 96   '允许的最大连接用户数，可以自己定义
    Delegate Sub UpdateUIHandler(ByVal RTBoxstr As String, ByVal Label1Str As String)

    Public Sub ChangUI(ByVal RTBoxstr As String, ByVal Label1Str As String)
        If RTBoxstr.Length > 0 Then RichTextBox1.AppendText(RTBoxstr & vbCrLf)
        If Label1Str.Length > 0 Then Label1.Text = Label1Str
    End Sub

    '下边是事件控制的方法更新用户线情况 
    Private Sub doeventSo(ByVal RTBoxstr As String, ByVal Label1Str As String)
        Dim handler As New UpdateUIHandler(AddressOf ChangUI)
        Dim args() As Object = {RTBoxstr, Label1Str}
        Me.BeginInvoke(handler, args)
    End Sub


    Delegate Sub UpdateUIOnLine(ByVal LblOnlineStr As String, ByVal LBuserOnLineStr As String)

    Public Sub ChangUIOnLine(ByVal LblOnlineStr As String, ByVal LBuserOnLineStr As String)
        If LblOnlineStr.Length > 0 Then LblOnline.Text = LblOnlineStr
        If LBuserOnLineStr.StartsWith("1") Then
            LBuserOnLine.Items.Add(LBuserOnLineStr.Substring(1)) '1往里面加ep
        Else
            LBuserOnLine.Items.Remove(LBuserOnLineStr.Substring(1)) '否则移除ep
        End If


    End Sub

    '下边是事件控制的方法更新UI 
    Private Sub UpdateOnLine(ByVal LblOnlineStr As String, ByVal LBuserOnLineStr As String)
        Dim handler As New UpdateUIOnLine(AddressOf ChangUIOnLine)
        Dim args() As Object = {LblOnlineStr, LBuserOnLineStr}
        Me.BeginInvoke(handler, args)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '只允许一个实例运行
        If UBound(Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)) > 0 Then
            MessageBox.Show("应用程序已经运行!", "Lqs提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.Dispose(True)
        End If

        LBLcount.Text = "/" & IntMaxUser.ToString '显示 "在线用户数/允许最大用户数"
        '开始侦听
        '判断主机IP格式是否正确   
        Try
            SvrIp = IPAddress.Parse("127.0.0.1") '要换成自己服务器的IP地址
        Catch ex As Exception
            MsgBox("服务器端的IP地址设置不正确!")
            Me.Dispose(True)
        End Try

        SvrPort = CInt("502")    ' 服务器端监听的端口号

        '侦听IntMaxUser=96个客户端   并启动监听线程 
        Try
            Svr = New IPEndPoint(SvrIp, Int32.Parse(SvrPort))
            SvrListenSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            SvrListenSocket.Bind(Svr)

            SvrListenSocket.Listen(IntMaxUser) '允许连接最大客户端数IntMaxUser 96
            SvrListenThread = New Thread(AddressOf ListenThread)
            SvrListenThread.IsBackground = True
            SvrListenThread.Start() '启动监听线程

            Label1.Text = "提示信息: 侦听线程已执行，准备接收客户端。   " & Now

        Catch ex As Exception
            Label1.Text = ex.Message.ToString
        End Try



    End Sub

    '服务器端 侦听线程  特别说明，这里接收客户端连接的Accept是用的同步的，我个人认为在这里用同步的会比用异步好一些。因为这样代码简单而且没有性能上的损失
    Public Sub ListenThread()
        While (True)  '在一个线程中，同步监听,接受后开始异步传输数据

            Dim UserConnected As New StateObject  '服务器端 定义1个新的客户信息储存类

            '服务器端创建一个socket，用来和接入的客户端进行通讯
            '给用户信息储存类赋值，服务器端创建的哪个socket与用户连接的
            doeventSo("监听线程运行中，等待客户连接......", "")
            UserConnected.workSocket = SvrListenSocket.Accept()
            StateObject.socketArrayList.Add(UserConnected)
            doeventSo(CType(UserConnected.workSocket.RemoteEndPoint, IPEndPoint).ToString & " 已接入。", "")
            'UserConnected.UserEP = CType(UserConnected.workSocket.RemoteEndPoint, IPEndPoint)
            UpdateOnLine(StateObject.socketArrayList.Count.ToString, "1" & CType(UserConnected.workSocket.RemoteEndPoint, IPEndPoint).ToString)

            UserConnected.workSocket.BeginReceive(UserConnected.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), UserConnected) '服务器端创建的socket开始异步接收此用户的数据

        End While
    End Sub

    Public Sub CloseConnectedUser(ByVal state As StateObject) '关闭客户连接
        StateObject.socketArrayList.Remove(state) '移除此客户端
        UpdateOnLine(StateObject.socketArrayList.Count.ToString, "2" & CType(state.workSocket.RemoteEndPoint, IPEndPoint).ToString)

        If state.workSocket.Connected Then
            state.workSocket.Shutdown(SocketShutdown.Both)
            state.workSocket.Close()
        End If
    End Sub

    '异步接收客户端socket发来的数据
    Public Sub ReceiveCallback(ByVal ar As IAsyncResult)

        Dim state As StateObject = CType(ar.AsyncState, StateObject)
        Dim handler As Socket = state.workSocket

        Dim IntbytesRead As Integer

        Try
            '接收客户端发来的数据. 
            IntbytesRead = handler.EndReceive(ar)
        Catch ex As SocketException
            ' ''If ex.ErrorCode = 10054 Then doeventSo("客户端断开了。", "")
            CloseConnectedUser(state) '这个函数用来关闭客户端连接
        Catch

        End Try

        If IntbytesRead > 0 Then

            state.sb.Append(Encoding.Unicode.GetString(state.buffer, 0, IntbytesRead))
            LqsAnalyzer(state) '这个函数用来处理接收到的信息      

            Try
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state) '向系统投递下一个接收请求
            Catch ex As SocketException

                CloseConnectedUser(state) '这个函数用来关闭客户端连接
            Catch

            End Try

        Else '如果接收到0字节的数据说明客户端关闭了Socket，那我们也要关闭Socket 
            CloseConnectedUser(state) '这个函数用来关闭客户端连接
            doeventSo(CType(state.workSocket.RemoteEndPoint, IPEndPoint).ToString & " 客户端断开了。", "")
        End If

    End Sub

    Public Sub LqsAnalyzer(ByVal state As StateObject) '这个函数用来处理接收到的信息,为执行效率，使用的是多线程，子线程不能直接操作主线程控件，需要通过委托

        doeventSo(CType(state.workSocket.RemoteEndPoint, IPEndPoint).ToString & ": " & state.sb.ToString, "收到客户信息")
        Send(state, state.sb.ToString) '把收到的信息再发送到客户端去
        state.sb.Remove(0, state.sb.Length) '清空
    End Sub

    '发送数据给客户端
    Public Sub Send(ByVal state As StateObject, ByVal data As String)

        Dim byteData As Byte() = Encoding.Unicode.GetBytes(data) ' Convert the string data to byte data using Unicode encoding.
        Try
            state.workSocket.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), state) ' Begin sending the data to the remote device.
        Catch ex As SocketException
            CloseConnectedUser(state) '这个函数用来关闭客户端连接
        Catch

        End Try

    End Sub

    '定义发送回调函数
    Public Sub SendCallback(ByVal ar As IAsyncResult)
        Dim state As StateObject = CType(ar.AsyncState, StateObject)
        Dim IntbytesSent As Integer
        Try
            IntbytesSent = state.workSocket.EndSend(ar)
        Catch ex As SocketException
            CloseConnectedUser(state) '这个函数用来关闭客户端连接
        Catch
        End Try

    End Sub

    '定义类 StateObject 储存相关连接信息
    Public Class StateObject
        Public Shared socketArrayList As New ArrayList '保存所有服务器分配与各个客户端通讯的socket.
        Public UserZH As Integer '用户帐号
        Public UserName As String = Nothing '用户姓名
        Public UserPwd As String = Nothing '用户米面
        Public workSocket As Socket = Nothing   ' 客户端与服务器连接，服务器分配的socket.
        Public Const BufferSize As Integer = 1024  ' 接收缓冲区大小.
        Public buffer(BufferSize) As Byte  '接收缓冲区
        Public sb As New StringBuilder  '接收的字符串
    End Class

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        '退出程序

        If SvrListenSocket.Connected = True Then
            SvrListenSocket.Shutdown(SocketShutdown.Both)
            SvrListenSocket.Close()
        End If

        SvrListenThread.Abort() '监听线程

        Me.Dispose(True)
    End Sub

    Private Sub ContextMenuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuExit.Click
        '退出程序
        Call mnuFileExit_Click(sender, e)
    End Sub

    Private Sub ContextMenuShowme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuShowme.Click
        '显示窗体
        Me.Show()
        Me.Focus()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '关闭窗体时...
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub mnuFileAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileAbout.Click
        '关于
        FormAbout.Show()
        FormAbout.Focus()
    End Sub

    Private Sub ContextMenuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuAbout.Click
        '关于
        FormAbout.Show()
        FormAbout.Focus()
    End Sub


    Private Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        '群发消息 给所有选中的用户发消息

        Dim IntCount As Integer
        IntCount = LBuserOnLine.Items.Count - 1
        If IntCount < 0 Then Exit Sub '没有在线用户

        Dim strForAllSend As String
        strForAllSend = TBsend.Text.Trim() '要群发的消息内容

        Dim i As Integer
        If StateObject.socketArrayList.Count > 0 And Len(strForAllSend) > 0 Then  '如果有用户在线，且信息不为空
            For Each state As StateObject In StateObject.socketArrayList
                For i = 0 To IntCount
                    If LBuserOnLine.GetItemChecked(i) = True Then '选中的用户
                        If LBuserOnLine.GetItemText(LBuserOnLine.Items(i)) = CType(state.workSocket.RemoteEndPoint, IPEndPoint).ToString Then
                            Send(state, strForAllSend)
                        End If
                    End If

                Next
            Next
        End If
    End Sub

    '全选 框 控制 是否发信息给所有用户的操作
    Private Sub select_all_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles select_all.CheckedChanged

        Dim i As Integer
        Dim IntCount As Integer
        IntCount = LBuserOnLine.Items.Count - 1
        If IntCount < 0 Then Exit Sub

        If select_all.Checked = True Then
            For i = 0 To IntCount
                LBuserOnLine.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To IntCount
                LBuserOnLine.SetItemChecked(i, False)
            Next
        End If

    End Sub


    '让RichTextBox显示的信息滚动到最新的
    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.ScrollToCaret()
    End Sub
End Class
