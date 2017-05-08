Imports DevExpress.XtraEditors
Public Class FrmDenom

    Sub loaddata()
        SQLCari("select denom as 'DENOM' from denom order by denom")
        GridControl1.DataSource = objDataTable
        GridView1.BestFitColumns()
    End Sub

    Private Sub FrmDenom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loaddata()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loaddata()
    End Sub

    Private Sub bbtambah_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtambah.ItemClick
        FrmManageDenom.Text = "Tambah Data Denom"
        FrmManageDenom.txtdenom.Text = ""
        FrmManageDenom.ShowDialog()
    End Sub

    Private Sub bbedit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbedit.ItemClick
        FrmManageDenom.Text = "Ubah Data Denom"
        FrmManageDenom.txtdenom.Text = GridView1.GetFocusedRow(0).ToString
        FrmManageDenom.denomlama = GridView1.GetFocusedRow(0).ToString
        FrmManageDenom.ShowDialog()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub bbhapus_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbhapus.ItemClick
        Dim result As Integer = XtraMessageBox.Show("Apakah anda ingin menghapus " & GridView1.GetFocusedRow(0).ToString & " dari data Denom?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            SQLQuery("delete from denom where denom='" & GridView1.GetFocusedRow(0).ToString & "'")
            loaddata()
        Else
        End If
    End Sub
End Class