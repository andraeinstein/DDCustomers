Imports DevExpress.XtraEditors
Public Class FrmPenjualan

    Private Sub FrmPenjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLCari("select toko from informasi ")
        If objDataTable.Rows.Count > 0 Then
            lbltoko.Text = objDataTable.Rows(0).Item("toko").ToString
        End If
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnindosat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnindosat.Click
        FrmIsiPulsa.lbloperator.Text = "INDOSAT"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub btnxl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnxl.Click
        FrmIsiPulsa.lbloperator.Text = "TELKOMSEL"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub btntelkomsel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntelkomsel.Click
        FrmIsiPulsa.lbloperator.Text = "XL"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub btnesia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnesia.Click
        FrmIsiPulsa.lbloperator.Text = "AXIS"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub btntri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntri.Click
        FrmIsiPulsa.lbloperator.Text = "SMARTFREN"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub btnsmart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsmart.Click
        FrmIsiPulsa.lbloperator.Text = "THREE"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub btnflexi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnflexi.Click
        FrmIsiPulsa.lbloperator.Text = "STARONE"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub btnstarone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstarone.Click
        FrmIsiPulsa.lbloperator.Text = "PLN"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FrmIsiPulsa.lbloperator.Text = "INDOSAT DATA"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        FrmIsiPulsa.lbloperator.Text = "TELKOMSEL DATA"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FrmIsiPulsa.lbloperator.Text = "THREE DATA"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FrmIsiPulsa.lbloperator.Text = "CERIA"
        FrmIsiPulsa.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub
End Class