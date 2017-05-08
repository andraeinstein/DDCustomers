Imports DevExpress.XtraEditors
Public Class FrmUser

    Sub loaddata()
        SQLCari("select nama NAMA,username USERNAME, hak_akses 'HAK AKSES' from user order by id")
        GridControl1.DataSource = objDataTable
        GridView1.BestFitColumns()
    End Sub

    Private Sub FrmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loaddata()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loaddata()
    End Sub

    Private Sub bbtambah_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtambah.ItemClick
        Frmmanageuser.Text = "Tambah User"
        Frmmanageuser.txtnama.Text = ""
        Frmmanageuser.ShowDialog()
    End Sub

    Private Sub bbedit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbedit.ItemClick
        Frmmanageuser.Text = "Ubah User"
        Frmmanageuser.txtnama.Text = GridView1.GetFocusedRow(0).ToString
        Frmmanageuser.txtusername.Text = GridView1.GetFocusedRow(1).ToString
        Frmmanageuser.ShowDialog()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub bbhapus_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbhapus.ItemClick
        Dim result As Integer = XtraMessageBox.Show("Apakah anda ingin menghapus " & GridView1.GetFocusedRow(0).ToString & " dari data User?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            SQLQuery("delete from user where nama='" & GridView1.GetFocusedRow(0).ToString & "' and username='" & GridView1.GetFocusedRow(1).ToString & "'")
            loaddata()
        Else
        End If
    End Sub
End Class