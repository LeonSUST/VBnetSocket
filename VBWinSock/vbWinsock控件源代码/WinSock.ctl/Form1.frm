VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "服务器"
   ClientHeight    =   6420
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5220
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6420
   ScaleWidth      =   5220
   StartUpPosition =   3  '窗口缺省
   Begin VB.Frame Frame1 
      Caption         =   "服务器"
      Height          =   6135
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   4935
      Begin VB.CommandButton cmdSVRDiscon 
         Caption         =   "断开"
         Enabled         =   0   'False
         Height          =   375
         Left            =   3480
         TabIndex        =   7
         Top             =   360
         Width           =   855
      End
      Begin VB.CommandButton cmdListen 
         Caption         =   "监听"
         Height          =   375
         Left            =   2520
         TabIndex        =   6
         Top             =   360
         Width           =   855
      End
      Begin VB.TextBox txtSvrPort 
         Height          =   270
         Left            =   1320
         TabIndex        =   4
         Text            =   "9958"
         Top             =   480
         Width           =   855
      End
      Begin VB.TextBox txtSeversend 
         Height          =   375
         Left            =   240
         TabIndex        =   3
         Text            =   "你好，客户机"
         Top             =   5520
         Width           =   3375
      End
      Begin VB.CommandButton cmdSever 
         Caption         =   "发送"
         Enabled         =   0   'False
         Height          =   375
         Left            =   3840
         TabIndex        =   2
         Top             =   5520
         Width           =   855
      End
      Begin VB.TextBox txtSeverget 
         Height          =   4455
         Left            =   240
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   1
         Top             =   960
         Width           =   4455
      End
      Begin 工程1.WinSock Socketsvr 
         Left            =   4425
         Top             =   165
         _ExtentX        =   741
         _ExtentY        =   741
      End
      Begin VB.Label Label1 
         Caption         =   "监听端口"
         Height          =   255
         Left            =   480
         TabIndex        =   5
         Top             =   480
         Width           =   855
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'Download by http://www.codefans.net
Private Sub cmdListen_Click()
Socketsvr.CloseSck
Socketsvr.LocalPort = txtSvrPort
Socketsvr.Listen
cmdListen.Enabled = False
cmdSVRDiscon.Enabled = True
End Sub

Private Sub cmdSever_Click()
Socketsvr.SendData Socketsvr.LocalIP & "说：" & txtSeversend.Text
End Sub

Private Sub cmdSVRDiscon_Click()
Socketsvr.CloseSck
cmdSVRDiscon.Enabled = False
cmdListen.Enabled = True
cmdSever.Enabled = False
End Sub



Private Sub Form_Load()
Form2.Show

End Sub

Private Sub Form_Unload(Cancel As Integer)
Unload Form2
End Sub

Private Sub Socketsvr_CloseSck()
cmdSever.Enabled = False
MsgBox "连接是被 客户机  关闭的", , "我是服务器"
Socketsvr.CloseSck
Socketsvr.Listen
End Sub

Private Sub Socketsvr_ConnectionRequest(ByVal requestID As Long)
If Socketsvr.State <> sckConnected Then
    Socketsvr.CloseSck
    Socketsvr.Accept requestID
    cmdSever.Enabled = True
End If

End Sub

Private Sub Socketsvr_DataArrival(ByVal bytesTotal As Long)
Dim tmp As String
Socketsvr.GetData tmp
txtSeverget.Text = IIf(txtSeverget.Text = "", tmp, txtSeverget.Text & vbCrLf & tmp)
End Sub

Private Sub Socketsvr_Error(ByVal Number As Integer, Description As String, ByVal sCode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
MsgBox "发生错误：" & vbCrLf & Description, , "我是服务器"
Socketsvr.CloseSck
Socketsvr.Listen
End Sub

Private Sub txtSeverget_Change()
txtSeverget.SelStart = Len(txtSeverget.Text)
End Sub
