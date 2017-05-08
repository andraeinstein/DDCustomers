Imports DevExpress.XtraEditors
Public Class FrmTiket

    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah terkirim !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        txtkomplain.Text = ""
        FrmKomplain.loadjawaban()
        FrmKomplain.loadkomplain()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SQLCari("select format from formatpesan where jenis='PIN'")
        Dim pin As String = objDataTable.Rows(0).Item("format").ToString

        SQLCari("select replace(replace(format,'<NOMINAL>','" & txtkomplain.Text & "'),'<PIN>','" & pin & "') pesan from formatpesan where jenis='TIKET'")
        Dim pesan As String = objDataTable.Rows(0).Item("pesan").ToString

        SQLQuery("insert into komplainkeluar(tgl,komplain) values(now(),'" & pesan & "')")
        SQLQuery("insert into sms_outbox(tgl_sms,no_hp,pesan) select now(),format,'" & pesan & "' from formatpesan where jenis='NOMOR HP'")
        SQLQuery("insert into sms_history(tgl_input,pesan,tipe) values(now(),'" & pesan & "',2)")
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

    Private Sub txtkomplain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkomplain.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub
End Class