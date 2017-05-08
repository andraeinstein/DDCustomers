Imports DevExpress.XtraEditors
Public Class FrmPassOtoritas
    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        txtlama.Text = ""
        txtbaru.Text = ""
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If txtbaru.Text = "" Or txtlama.Text = "" Then
            XtraMessageBox.Show("Data tidak lengkap !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SQLCari("select pass from passotoritas limit 1")
            If objDataTable.Rows.Count > 0 Then
                If computeHash(txtlama.Text) = objDataTable.Rows(0).Item("pass").ToString Then
                    SQLQuery("update passotoritas set pass='" & computeHash(txtbaru.Text) & "'")
                    Call setelahsimpan()
                Else
                    XtraMessageBox.Show("Password lama tidak cocok !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub txtbaru_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbaru.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub

    Private Sub txtlama_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlama.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub
End Class