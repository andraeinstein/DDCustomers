Imports DevExpress.XtraEditors
Public Class FrmAbout
    
    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub FrmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtcode.Text = My.Settings.code
        If My.Settings.demo = "yes" Then
            lblstatus.Text = "Demo"
        Else
            lblstatus.Text = "Full"
        End If
    End Sub
End Class