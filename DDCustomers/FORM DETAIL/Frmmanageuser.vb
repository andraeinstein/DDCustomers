Imports DevExpress.XtraEditors
Public Class Frmmanageuser
    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        For Each ctr As Control In Me.Controls
            If ctr.GetType() Is GetType(TextBox) Then
                ctr.Text = ""
            End If
        Next
        FrmUser.loaddata()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If Me.Text = "Tambah User" Then
            If txtnama.Text = "" Or txtpassword.Text = "" Or txtpassword2.Text = "" Or txtusername.Text = "" Or cmbhak.Text = "" Then
                XtraMessageBox.Show("Data tidak lengkap !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                SQLCari("select * from user where username='" & txtusername.Text & "'")
                If objDataTable.Rows.Count > 0 Then
                    XtraMessageBox.Show("Data sudah ada !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If txtpassword.Text = txtpassword2.Text Then
                        SQLQuery("insert into user(username,pass,nama,hak_akses) values('" & txtusername.Text & "','" & computeHash(txtpassword.Text) & "','" & txtnama.Text & "','" & cmbhak.Text & "')")
                        Call setelahsimpan()
                    Else
                        XtraMessageBox.Show("Password tidak sama !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            SQLCari("select * from user where pass='" & computeHash(txtpassword.Text) & "' and username='" & txtusername.Text & "' ")
            If objDataTable.Rows.Count > 0 Then
                SQLQuery("update user set pass='" & computeHash(txtpassword2.Text) & "',hak_akses='" & cmbhak.Text & "' where username='" & txtusername.Text & "' and pass='" & computeHash(txtpassword.Text) & "'")
                Call setelahsimpan()
            Else
                XtraMessageBox.Show("Password lama salah !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub txtdenom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnama.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub

    Private Sub Frmmanageuser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Text = "Tambah User" Then
            For Each ctr As Control In Me.Controls
                If ctr.GetType() Is GetType(TextBox) Then
                    ctr.Text = ""
                    ctr.Enabled = True
                End If
            Next
            lblpass1.Text = "Password"
            lblpass2.Text = "Ulangi Password"
        Else
            lblpass1.Text = "Password lama"
            lblpass2.Text = "Password baru"
            txtnama.Enabled = False
            txtusername.Enabled = False
        End If
    End Sub
End Class