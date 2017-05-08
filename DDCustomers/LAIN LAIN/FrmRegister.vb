Imports System.Text.RegularExpressions
Imports System.Management
Imports DevExpress.XtraEditors
Public Class FrmRegister

    Friend Function GetProcessorId() As String
        Dim strProcessorId As String = String.Empty
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject

        For Each info In search.Get()
            strProcessorId = info("processorId").ToString()
        Next
        Return strProcessorId
    End Function

    Private Sub FrmRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        txtcode.Text = GetProcessorId()
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        MainForm.Close()
        Me.Close()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim code As String = Regex.Replace(txtcode.Text, "\D", "") & Regex.Replace(txtcode.Text, "\d", "")
        Dim tgl As String = DateTime.Now.ToString("ddMM")
        If txtserial.Text.ToLower = computeHash(code & tgl & 1) Then 'demo
            My.Settings.lisensi = "yes"
            My.Settings.code = txtcode.Text
            My.Settings.demo = "yes"
            My.Settings.tgl_reg = DateTime.Today
            My.Settings.Save()
            XtraMessageBox.Show("Program berhasil di aktivasi (Demo 15 hari)!! ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Close()
            FrmLogin.ShowDialog()
        ElseIf txtserial.Text.ToLower = computeHash(code & tgl & 2) Then 'full
            My.Settings.lisensi = "yes"
            My.Settings.code = txtcode.Text
            My.Settings.demo = "no"
            My.Settings.tgl_reg = DateTime.Today
            My.Settings.Save()
            XtraMessageBox.Show("Program berhasil di aktivasi (Full Aktivasi) !! ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Close()
            FrmLogin.ShowDialog()
        Else
            XtraMessageBox.Show("Aktivasi gagal !! ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class