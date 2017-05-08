Imports DevExpress.XtraEditors
Public Class FrmPesanKeluar

    Sub loaddata()
        SQLCari("select tgl_sms 'TANGGAL PESAN', no_hp 'NO. HP', pesan PESAN from sms_outbox order by id desc")
        GridControl1.DataSource = objDataTable
        GridView1.Columns("TANGGAL PESAN").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        GridView1.BestFitColumns()
    End Sub

    Private Sub FrmPesanKeluar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loaddata()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loaddata()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub bbhapus_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbhapus.ItemClick
        If GridView1.RowCount > 0 Then
            Dim result As Integer = XtraMessageBox.Show("Apakah anda ingin menghapus pesan " & GridView1.GetFocusedRow(2).ToString & " dari pesan antrian?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                SQLQuery("delete from sms_outbox where pesan='" & GridView1.GetFocusedRow(2).ToString & "'")
                loaddata()
            End If
        Else
            XtraMessageBox.Show("Tidak ada pesan antrian", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        
    End Sub
End Class