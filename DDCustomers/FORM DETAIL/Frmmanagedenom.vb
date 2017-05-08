Imports DevExpress.XtraEditors
Public Class FrmManageDenom
    Friend denomlama As String

    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        txtdenom.Text = ""
        FrmDenom.loaddata()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If Me.Text = "Tambah Data Denom" Then
            SQLCari("select * from denom where denom='" & txtdenom.Text & "'")
            If objDataTable.Rows.Count > 0 Then
                XtraMessageBox.Show("Data sudah ada !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                SQLQuery("insert into denom values('" & txtdenom.Text & "')")
                Call setelahsimpan()
            End If
        Else
            SQLQuery("update denom set denom=" & txtdenom.Text & " where denom=" & denomlama & "")
            Call setelahsimpan()
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub txtdenom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdenom.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub
End Class