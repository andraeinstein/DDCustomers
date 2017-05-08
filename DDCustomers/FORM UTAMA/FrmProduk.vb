Imports DevExpress.XtraEditors
Public Class FrmProduk
    Sub loaddata()
        SQLCari("select o.nama OPERATOR,h.denom DENOM,h.harga_beli 'HARGA BELI',h.harga_jual 'HARGA JUAL',h.kode_produk 'KODE PRODUK',if(right(h.denom,1)=1,'PULSA INTERNET',if(right(h.denom,1)=2,'PULSA SMS','PULSA REGULAR')) TYPE from operator o,produk h where o.id_operator=h.id_operator order by o.nama asc,h.denom asc")
        GridControl1.DataSource = objDataTable
        GridView1.BestFitColumns()
    End Sub

    Private Sub FrmPoduk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        loaddata()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        loaddata()
    End Sub

    Private Sub bbtambah_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtambah.ItemClick
        FrmManageProduk.Text = "Tambah Data Produk"
        FrmManageProduk.txthargabeli.Text = ""
        FrmManageProduk.txtproduk.Text = ""
        FrmManageProduk.ShowDialog()
    End Sub

    Private Sub bbedit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbedit.ItemClick
        FrmManageProduk.Text = "Ubah Data Produk"
        FrmManageProduk.txthargabeli.Text = GridView1.GetFocusedRow(2).ToString
        FrmManageProduk.txtproduk.Text = GridView1.GetFocusedRow(4).ToString
        FrmManageProduk.txthargajual.Text = GridView1.GetFocusedRow(3).ToString
        FrmManageProduk.produklama = GridView1.GetFocusedRow(4).ToString
        FrmManageProduk.ShowDialog()
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub bbhapus_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbhapus.ItemClick
        Dim result As Integer = XtraMessageBox.Show("Apakah anda ingin menghapus " & GridView1.GetFocusedRow(4).ToString & " dari data Produk?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            SQLQuery("delete from produk where kode_produk='" & GridView1.GetFocusedRow(4).ToString & "' and denom=" & GridView1.GetFocusedRow(1).ToString & "")
            loaddata()
        Else
        End If
    End Sub
End Class