Imports System.Globalization
Imports DevExpress.XtraEditors
Public Class Frmhistory

    Sub loaddata()
        'tipe 1 = pesan masuk, tipe 2 = pesan keluar
        SQLCari("select tgl_input 'TANGGAL', pesan 'PESAN', if(tipe=1,'MASUK','KELUAR') 'TIPE' from sms_history where date(tgl_input)=curdate() order by id desc")
        GridControl1.DataSource = objDataTable
        GridView1.Columns("TANGGAL").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        GridView1.BestFitColumns()
    End Sub

    Private Sub Frmhistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loaddata()

        DEawal.DateTime = Now()
        DEakhir.DateTime = Now()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loaddata()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        SQLCari("select tgl_input 'TANGGAL', pesan 'PESAN', if(tipe=1,'MASUK','KELUAR') 'TIPE' from sms_history where date(tgl_input) between '" & DEawal.DateTime.ToString("yyy/MM/dd", CultureInfo.InvariantCulture) & "' and '" & DEakhir.DateTime.ToString("yyy/MM/dd", CultureInfo.InvariantCulture) & "' order by id desc")
        GridControl1.DataSource = objDataTable
        GridView1.BestFitColumns()
    End Sub
End Class