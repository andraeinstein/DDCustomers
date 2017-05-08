Imports MySql.Data.MySqlClient
Public Class Struk
    Dim objRpt As New XtraReport1()
    Friend tipestruk As Integer

    Private Sub Struk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If tipestruk = 1 Then
            SQLCari("select t.id_trx,t.nota,t.tgl_trx,tp.kode_produk,tp.no_tujuan,tp.harga_jual,i.pemilik,i.alamat,i.telp,i.toko " _
                & "from transaksi_pulsa tp,transaksi t,informasi i where(tp.id_trx = t.id_trx) and t.nota=" & FrmPulsa.GridView1.GetFocusedRow(11).ToString & "")
        Else
            SQLCari("select t.id_trx,t.nota,t.tgl_trx,tp.kode_produk,tp.no_tujuan,tp.harga_jual,i.pemilik,i.alamat,i.telp,i.toko " _
                & "from transaksi_pulsa tp,transaksi t,informasi i where(tp.id_trx = t.id_trx) and tp.kode_produk='" & FrmIsiPulsa.txtkodeproduk.Text & "' and tp.no_tujuan='" & FrmIsiPulsa.txtnohp.Text & "'")
        End If
        objRpt.DataSource = objDataTable
        objRpt.CreateDocument(True)
        DocumentViewer1.DocumentSource = objRpt
        DocumentViewer1.Refresh()
    End Sub
End Class