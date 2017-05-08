Imports DevExpress.XtraEditors
Public Class FrmLogin
    Friend hakakses As String
    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtip.Text = My.Settings.ip
        txtuserdb.Text = My.Settings.userdb
        txtpassdb.Text = My.Settings.passdb
        txtuser.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        My.Settings.ip = txtip.Text
        My.Settings.userdb = txtuserdb.Text
        My.Settings.passdb = txtpassdb.Text
        My.Settings.Save()

        If txtuser.Text = "" Or txtpass.Text = "" Then
            XtraMessageBox.Show("Username dan Password harus diisi !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SQLCari("select nama,hak_akses from user where username='" & txtuser.Text & "' and pass='" & computeHash(txtpass.Text) & "'")
            If objDataTable.Rows.Count > 0 Then
                Me.Close()
                MainForm.Show()
                MainForm.TSuser.Text = "User : " & objDataTable.Rows(0).Item("nama").ToString
            Else
                XtraMessageBox.Show("Login gagal !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
            hakakses = objDataTable.Rows(0).Item("hak_akses").ToString
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        MainForm.Close()
        Me.Close()
    End Sub

    Private Sub txtuser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtuser.KeyDown
        If e.KeyCode = Keys.Enter Then
            SimpleButton1.PerformClick()
        End If
    End Sub

    Private Sub txtpass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpass.KeyDown
        If e.KeyCode = Keys.Enter Then
            SimpleButton1.PerformClick()
        End If
    End Sub
End Class