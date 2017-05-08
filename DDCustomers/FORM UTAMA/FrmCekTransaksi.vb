Imports DevExpress.XtraEditors
Public Class FrmCekTransaksi
    Private Enum Exec
        OLECMDID_OPTICAL_ZOOM = 63
    End Enum
    Private Enum ExecOpt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3
    End Enum
    Private Sub FrmCekTransaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        WebBrowser1.Refresh()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub bbtambah_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtambah.ItemClick
        WebBrowser1.Navigate("180.247.38.113")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Try
            Dim Res As Object = Nothing
            Dim MyWeb As Object
            MyWeb = Me.WebBrowser1.ActiveXInstance
            MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, _
                  ExecOpt.OLECMDEXECOPT_DONTPROMPTUSER, 90, IntPtr.Zero)
        Catch ex As Exception
            MsgBox("Error:" & ex.Message)
        End Try
        lblstatusweb.Text = "Connected"
        lblstatusweb.ForeColor = Color.Green
    End Sub
End Class