Imports DevExpress.XtraEditors
Public Class FrmOperator

    Sub loaddata()
        SQLCari("select nama as 'NAMA OPERATOR' from operator order by id_operator")
        GridControl1.DataSource = objDataTable
        GridView1.BestFitColumns()
    End Sub

    Private Sub FrmOperator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loaddata()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loaddata()
    End Sub

    Private Sub bbtambah_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtambah.ItemClick
        FrmManageOperator.Text = "Tambah Data Operator"
        FrmManageOperator.txtoperator.Text = ""
        FrmManageOperator.ShowDialog()
    End Sub

    Private Sub bbedit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbedit.ItemClick
        FrmManageOperator.Text = "Ubah Data Operator"
        FrmManageOperator.txtoperator.Text = GridView1.GetFocusedRow(0).ToString
        FrmManageOperator.namalama = GridView1.GetFocusedRow(0).ToString
        FrmManageOperator.ShowDialog()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub bbhapus_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbhapus.ItemClick
        Dim result As Integer = XtraMessageBox.Show("Apakah anda ingin menghapus " & GridView1.GetFocusedRow(0).ToString & " dari data Operator?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            SQLQuery("delete from operator where nama='" & GridView1.GetFocusedRow(0).ToString & "'")
            loaddata()
        Else
        End If
    End Sub
End Class