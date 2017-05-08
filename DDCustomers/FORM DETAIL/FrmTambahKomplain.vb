Imports DevExpress.XtraEditors
Public Class FrmTambahKomplain

    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah terkirim !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        txtkomplain.Text = ""
        FrmKomplain.loadjawaban()
        FrmKomplain.loadkomplain()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SQLCari("select format from formatpesan where jenis='KOMPLAIN'")
        Dim format As String = objDataTable.Rows(0).Item("format").ToString & txtkomplain.Text

        SQLQuery("insert into komplainkeluar(tgl,komplain) values(now(),'" & format & "')")
        SQLQuery("insert into sms_outbox(tgl_sms,no_hp,pesan) select now(),format,'" & format & "' from formatpesan where jenis='NOMOR HP'")
        SQLQuery("insert into sms_history(tgl_input,pesan,tipe) values(now(),'" & format & "',2)")
        Call setelahsimpan()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub txtdenom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkomplain.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub
End Class