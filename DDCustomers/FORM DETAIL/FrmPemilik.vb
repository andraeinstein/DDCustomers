Imports DevExpress.XtraEditors
Public Class FrmPemilik
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SQLQuery("update informasi set pemilik='" & txtnama.Text & "',alamat='" & txtalamat.Text & "',telp='" & txttelepon.Text & "',toko='" & txttoko.Text & "'")
        XtraMessageBox.Show("Data telah disimpan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub FrmPemilik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLCari("select * from informasi")
        txtnama.Text = objDataTable.Rows(0).Item("pemilik").ToString
        txttoko.Text = objDataTable.Rows(0).Item("toko").ToString
        txtalamat.Text = objDataTable.Rows(0).Item("alamat").ToString
        txttelepon.Text = objDataTable.Rows(0).Item("telp").ToString
    End Sub

    Private Sub txttoko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttoko.TextChanged

    End Sub
End Class