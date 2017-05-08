Imports DevExpress.XtraEditors
Public Class FrmManagePrefix
    Friend prefixlama, operatorlama As String

    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        txtprefix.Text = ""
        FrmPrefix.loaddata()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If Me.Text = "Tambah Data Prefix" Then
            SQLCari("select prefix from prefix where prefix='" & txtprefix.Text & "'")
            If objDataTable.Rows.Count > 0 Then
                XtraMessageBox.Show("Data sudah ada !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                SQLQuery("insert into prefix(prefix,id_operator) select '" & txtprefix.Text & "',id_operator from operator where nama='" & cmboperator.Text & "'")
                Call setelahsimpan()
            End If
        Else
            SQLQuery("update prefix set prefix='" & txtprefix.Text & "', id_operator=(select id_operator from operator where nama='" & cmboperator.Text & "') " _
                     & "where prefix='" & prefixlama & "' and id_operator=(select id_operator from operator where nama='" & operatorlama & "')")
            Call setelahsimpan()
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub FrmManagePrefix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLCari("select nama from operator order by id_operator")
        With cmboperator
            .DataSource = objDataTable
            .DisplayMember = "nama"
            .ValueMember = "nama"
        End With

        If Me.Text = "Ubah Data Prefix" Then
            cmboperator.SelectedIndex = cmboperator.FindString(FrmPrefix.GridView1.GetFocusedRow(1).ToString)
        End If

    End Sub

    Private Sub txtprefix_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtprefix.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub

End Class