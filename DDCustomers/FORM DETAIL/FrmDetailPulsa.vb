Imports DevExpress.XtraEditors
Public Class FrmDetailPulsa

    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        txtnota.Text = ""
        FrmPulsa.loaddata()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SQLQuery("update transaksi_pulsa tp,transaksi t set tp.ket='" & txtketerangan.Text & "' where t.id_trx=tp.id_trx and t.id_trx=" & txtid.Text & "")
        Call setelahsimpan()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

End Class