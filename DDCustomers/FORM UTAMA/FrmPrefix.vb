Imports DevExpress.XtraEditors
Public Class FrmPrefix

    Sub loaddata()
        SQLCari("select p.prefix PREFIX,o.nama OPERATOR from prefix p,operator o where o.id_operator=p.id_operator order by o.nama ")
        GridControl1.DataSource = objDataTable
        GridView1.BestFitColumns()
    End Sub

    Private Sub FrmPrefix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loaddata()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loaddata()
    End Sub

    Private Sub bbtambah_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtambah.ItemClick
        FrmManagePrefix.Text = "Tambah Data Prefix"
        FrmManagePrefix.txtprefix.Text = ""
        FrmManagePrefix.ShowDialog()
    End Sub

    Private Sub bbedit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbedit.ItemClick
        FrmManagePrefix.Text = "Ubah Data Prefix"
        FrmManagePrefix.txtprefix.Text = GridView1.GetFocusedRow(0).ToString
        FrmManagePrefix.cmboperator.Text = GridView1.GetFocusedRow(1).ToString
        FrmManagePrefix.prefixlama = GridView1.GetFocusedRow(0).ToString
        FrmManagePrefix.operatorlama = GridView1.GetFocusedRow(1).ToString
        FrmManagePrefix.ShowDialog()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub bbhapus_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbhapus.ItemClick
        Dim result As Integer = xtraMessageBox.Show("Apakah anda ingin menghapus " & GridView1.GetFocusedRow(0).ToString & " dari data Prefix?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            SQLQuery("delete from prefix where prefix='" & GridView1.GetFocusedRow(0).ToString & "'")
            loaddata()
        Else
        End If
    End Sub
End Class