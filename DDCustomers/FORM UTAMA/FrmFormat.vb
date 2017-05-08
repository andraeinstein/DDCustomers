Imports DevExpress.XtraEditors
Public Class FrmFormat

    Sub loaddata()
        SQLCari("select format FORMAT,ket KETERANGAN,jenis JENIS from formatpesan")
        GridControl1.DataSource = objDataTable
        GridView1.BestFitColumns()
    End Sub

    Private Sub FrmFormat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loaddata()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loaddata()
    End Sub

    Private Sub bbedit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbedit.ItemClick
        FrmManageFormat.txtformat.Text = GridView1.GetFocusedRow(0).ToString
        FrmManageFormat.jenis = GridView1.GetFocusedRow(2).ToString
        FrmManageFormat.ShowDialog()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub
End Class