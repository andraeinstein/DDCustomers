Imports MySql.Data.MySqlClient
Imports DevExpress.XtraEditors
Module Module1
    Public objDataTable As New DataTable
    Public database As Integer

    Public Sub tutupform()
        For Each frm As Form In MainForm.MdiChildren
            frm.Close()
        Next
    End Sub

    Public Function computeHash(ByVal textToHash As String) As String
        '//dibawah ini adalah sebuah fungsi untuk mengenkripsi text dengan metode MD5
        Dim MD5 As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim Bytes() As Byte = MD5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(textToHash))
        Dim s As String = Nothing
        For Each by As Byte In Bytes
            s += by.ToString("x2")
        Next
        Return s
    End Function

    Public Sub SQLQuery(ByVal SQCommand As String)
        Try
            Using koneksi As New MySqlConnection("Server='" & My.Settings.ip & "';port=3306;user id='" & My.Settings.userdb & "';password='" & My.Settings.passdb & "';database='ddpulsa'")
                Using SQLCMD As New MySqlCommand(SQCommand, koneksi)
                    koneksi.Open()
                    SQLCMD.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("Query salah : " + ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SQLCari(ByVal SQCommand As String)
        Try
            Using koneksi As New MySqlConnection("Server='" & My.Settings.ip & "';port=3306;user id='" & My.Settings.userdb & "';password='" & My.Settings.passdb & "';database='ddpulsa'")
                Using da As New MySqlDataAdapter(SQCommand, koneksi)
                    objDataTable = New DataTable
                    koneksi.Open()
                    da.Fill(objDataTable)
                End Using
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("Query salah : " + ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Module