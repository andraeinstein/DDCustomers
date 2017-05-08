Imports DevExpress.XtraEditors
Public Class FrmManageOperator
    Friend namalama As String

    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        txtoperator.Text = ""
        FrmOperator.loaddata()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If Me.Text = "Tambah Data Operator" Then
            SQLCari("select * from operator where nama='" & txtoperator.Text & "'")
            If objDataTable.Rows.Count > 0 Then
                XtraMessageBox.Show("Data sudah ada !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                SQLQuery("insert into operator(nama) values('" & txtoperator.Text & "')")
                Call setelahsimpan()
            End If
        Else
            SQLQuery("update operator set nama='" & txtoperator.Text & "' where nama='" & namalama & "'")
            Call setelahsimpan()
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub txtoperator_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtoperator.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub
End Class