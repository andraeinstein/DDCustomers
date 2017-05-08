Imports System.IO
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraEditors
Public Class FrmDatabase

    Private Sub FrmDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        Select Case database
            Case 1
                GroupControl1.Visible = True
                GroupControl2.Visible = False
                lblnama.Visible = True
                lblsql.Visible = True
                txtfile.Text = True
                BBbackres.Caption = "Backup Database"
                GroupControl1.Text = "Backup Database"
                btnpath.Visible = False
                txtpath.Text = "C:\DDExport\Backup\"
                txtfile.Text = "Backup-" & String.Format("{0:ddMMyyyy}", DateTime.Now)
            Case 2
                GroupControl1.Visible = True
                GroupControl2.Visible = False
                lblnama.Visible = False
                lblsql.Visible = False
                txtfile.Visible = False
                BBbackres.Caption = "Restore Database"
                GroupControl1.Text = "Restore Database"
                btnpath.Visible = True
                txtpath.Text = "C:\DDExport\Backup\"
                txtfile.Text = ""
            Case 3
                GroupControl1.Visible = False
                GroupControl2.Visible = True
                GroupControl2.Text = "Hapus Data"
                BBbackres.Caption = "Hapus Data"
        End Select
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub BBbackres_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBbackres.ItemClick
        Select Case database
            Case 1
                Dim tanya As Integer = XtraMessageBox.Show("Backup database ke directory " & txtpath.Text & " ?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If tanya = vbYes Then
                    If (Not System.IO.Directory.Exists(txtpath.Text)) Then
                        System.IO.Directory.CreateDirectory(txtpath.Text)
                    End If

                    Dim constring As String = "Server='" & My.Settings.ip & "';port=3306;user id='" & My.Settings.userdb & "';password='" & My.Settings.passdb & "';database='ddpulsa'"
                    Using conn As New MySqlConnection(constring)
                        Using cm As New MySqlCommand()
                            Using mb As New MySqlBackup(cm)
                                cm.Connection = conn
                                conn.Open()
                                mb.ExportToFile(txtpath.Text & txtfile.Text & ".sql")
                                conn.Close()
                            End Using
                        End Using
                    End Using
                    XtraMessageBox.Show("Backup database berhasil dan di export ke " & txtpath.Text & "", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case 2
                Dim tanya As Integer = XtraMessageBox.Show("Restore database dari directory " & txtpath.Text & "\" & txtfile.Text & "", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If tanya = vbYes Then
                    Dim constring As String = "Server='" & My.Settings.ip & "';port=3306;user id='" & My.Settings.userdb & "';password='" & My.Settings.passdb & "';database='ddpulsa'"
                    Using conn As New MySqlConnection(constring)
                        Using cm As New MySqlCommand()
                            Using mb As New MySqlBackup(cm)
                                cm.Connection = conn
                                conn.Open()
                                mb.ImportFromFile(txtpath.Text)
                                conn.Close()
                            End Using
                        End Using
                    End Using
                    XtraMessageBox.Show("Backup database berhasil dan di export ke " & txtpath.Text & " ?", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case 3
                Select Case cmbtable.Text
                    Case "Transaksi Pulsa"
                        Dim tanya As Integer = XtraMessageBox.Show("Hapus data transaksi pulsa?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If tanya = vbYes Then
                            SQLQuery("delete tp,t from transaksi_pulsa tp,transaksi t where tp.id_trx=t.id_trx and date(t.tgl_trx) <= '" & DEtgl.DateTime.Date.ToString("yyyy-MM-dd") & "'")
                            XtraMessageBox.Show("Data Transaksi telah dihapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case "Log History"
                        Dim tanya As Integer = XtraMessageBox.Show("Hapus log history?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If tanya = vbYes Then
                            SQLQuery("delete from sms_history where date(tgl_input) <= '" & DEtgl.DateTime.Date.ToString("yyyy-MM-dd") & "'")
                            XtraMessageBox.Show("Data history telah dihapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                End Select

        End Select
    End Sub

    Private Sub btnpath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpath.Click
        Dim mystream As Stream
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            mystream = openFileDialog1.OpenFile()
            If (mystream IsNot Nothing) Then
                txtpath.Text = openFileDialog1.FileName
            End If
        End If
    End Sub
End Class