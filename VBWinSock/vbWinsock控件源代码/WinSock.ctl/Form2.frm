VERSION 5.00
Begin VB.Form Form2 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "�ͻ���"
   ClientHeight    =   6210
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5010
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6210
   ScaleWidth      =   5010
   StartUpPosition =   3  '����ȱʡ
   Begin VB.Frame Frame2 
      Caption         =   "�ͻ���"
      Height          =   6135
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   4935
      Begin VB.TextBox txtClientget 
         Height          =   4455
         Left            =   240
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   7
         Top             =   960
         Width           =   4455
      End
      Begin VB.CommandButton cmdClient 
         Caption         =   "����"
         Enabled         =   0   'False
         Height          =   375
         Left            =   3840
         TabIndex        =   6
         Top             =   5520
         Width           =   855
      End
      Begin VB.TextBox txtClientsend 
         Height          =   375
         Left            =   240
         TabIndex        =   5
         Text            =   "��ã�������"
         Top             =   5520
         Width           =   3375
      End
      Begin VB.CommandButton cmdconnect 
         Caption         =   "����"
         Height          =   375
         Left            =   2880
         TabIndex        =   4
         Top             =   360
         Width           =   855
      End
      Begin VB.TextBox txtRemotPort 
         Height          =   270
         Left            =   1320
         TabIndex        =   3
         Text            =   "9958"
         Top             =   240
         Width           =   1455
      End
      Begin VB.CommandButton cmdCLIDiscon 
         Caption         =   "�Ͽ�"
         Enabled         =   0   'False
         Height          =   375
         Left            =   3840
         TabIndex        =   2
         Top             =   360
         Width           =   855
      End
      Begin VB.TextBox txtRemotIP 
         Height          =   270
         Left            =   1320
         TabIndex        =   1
         Text            =   "210.43.239.67"
         Top             =   600
         Width           =   1455
      End
      Begin ����1.WinSock Socketclient 
         Left            =   4410
         Top             =   150
         _extentx        =   741
         _extenty        =   741
      End
      Begin VB.Label Label2 
         Caption         =   "Զ�̶˿�"
         Height          =   255
         Left            =   240
         TabIndex        =   9
         Top             =   360
         Width           =   1095
      End
      Begin VB.Label Label3 
         Caption         =   "Զ��IP"
         Height          =   255
         Left            =   360
         TabIndex        =   8
         Top             =   720
         Width           =   855
      End
   End
End
Attribute VB_Name = "Form2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'Download by http://www.codefans.net
Private Sub cmdCLIDiscon_Click()
Socketclient.CloseSck
cmdconnect.Enabled = True
cmdCLIDiscon.Enabled = False
cmdClient.Enabled = False
End Sub

Private Sub cmdClient_Click()
Socketclient.SendData Socketclient.LocalIP & "˵��" & txtClientsend.Text
End Sub

Private Sub cmdconnect_Click()
Socketclient.CloseSck
Socketclient.Connect txtRemotIP.Text, txtRemotPort
cmdconnect.Enabled = False
End Sub

Private Sub Form_Load()
txtRemotIP.Text = Socketclient.LocalIP
End Sub

Private Sub Form_Unload(Cancel As Integer)
Unload Form1
End Sub

Private Sub Socketclient_CloseSck()
cmdClient.Enabled = False
cmdCLIDiscon.Enabled = False
cmdconnect.Enabled = True
MsgBox "�����Ǳ� ������ �رյ�", , "���ǿͻ���"
End Sub

Private Sub Socketclient_Connect()
cmdClient.Enabled = True
cmdCLIDiscon.Enabled = True
cmdconnect.Enabled = False
Me.Caption = Socketclient.RemoteHost
End Sub

Private Sub Socketclient_DataArrival(ByVal bytesTotal As Long)
Dim tmp As String
Socketclient.GetData tmp
txtClientget.Text = IIf(txtClientget.Text = "", tmp, txtClientget.Text & vbCrLf & tmp)
End Sub

Private Sub Socketclient_Error(ByVal Number As Integer, Description As String, ByVal sCode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
Socketclient.CloseSck
cmdconnect.Enabled = True
MsgBox "��������" & vbCrLf & Description, , "���ǿͻ���"
End Sub




Private Sub txtClientget_Change()
txtClientget.SelStart = Len(txtClientget.Text)
End Sub
