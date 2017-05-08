Imports DevExpress.XtraEditors
Public Class FrmKomplain

    Sub loadkomplain()
        SQLCari("select tgl TANGGAL, komplain KOMPLAIN from komplainkeluar order by id desc limit 200")
        GridControl1.DataSource = objDataTable
        GridView1.Columns("TANGGAL").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        GridView1.BestFitColumns()
    End Sub

    Sub loadjawaban()
        SQLCari("select tgl TANGGAL, jawaban JAWABAN from komplainmasuk order by id desc limit 200")
        GridControl2.DataSource = objDataTable
        GridView2.Columns("TANGGAL").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        GridView2.BestFitColumns()
    End Sub

    Private Sub FrmKomplain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loadjawaban()
        loadkomplain()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loadjawaban()
        loadkomplain()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub bbtambah_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtambah.ItemClick
        FrmTambahKomplain.txtkomplain.Text = ""
        FrmTambahKomplain.ShowDialog()
    End Sub

    Private Sub BarButtonItem10_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        FrmTiket.txtkomplain.Text = ""
        FrmTiket.ShowDialog()
    End Sub
End Class