Imports System.IO
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraEditors
Public Class MainForm

    Sub hakakses()
        Select Case FrmLogin.hakakses
            Case "Administrator"
            Case "Operator 1"
                rbmaster.Visible = False
                rbmaintenance.Visible = False
                BBAdministrator.Enabled = False
                BBInformasi.Enabled = False
            Case "Operator 2"
                rbmaintenance.Visible = False
                rbmaster.Visible = False
                BBDeposit.Enabled = False
                BBKirimPesan.Enabled = False
                BBHistory.Enabled = False
                BBCekTransaksi.Enabled = False
                BBDeposit.Enabled = False
                BBAdministrator.Enabled = False
                BBInformasi.Enabled = False
        End Select
    End Sub

    Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                tutupform()
                FrmPulsa.MdiParent = Me
                FrmPulsa.Show()
                Ribbon.SelectedPage = rbtrx
            Case (Keys.F2)
                tutupform()
                FrmKomplain.MdiParent = Me
                FrmKomplain.Show()
                Ribbon.SelectedPage = rbreport
            Case Keys.F3
                tutupform()
                FrmFormat.MdiParent = Me
                FrmFormat.Show()
                Ribbon.SelectedPage = rbpengaturan
        End Select
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.demo = "yes" Then
            Dim tglreg As DateTime = My.Settings.tgl_reg
            Dim tgl As DateTime
            tgl = tglreg.AddDays(15)
            If DateTime.Today > tgl Then
                My.Settings.lisensi = "no"
                My.Settings.Save()
            Else
                My.Settings.lisensi = "yes"
                My.Settings.Save()
            End If
        End If

        If My.Settings.lisensi = "no" Then
            FrmRegister.ShowDialog()
        Else
            Dim tanggal As DateTime = My.Settings.tgl_reg
            If tanggal.ToString("MM") = DateTime.Now.ToString("MM") Then
                FrmLogin.ShowDialog()
                Call hakakses()
            Else
                SQLCari("SELECT * FROM sms_history WHERE YEAR(tgl_input) = YEAR(CURRENT_DATE - INTERVAL 1 MONTH) AND MONTH(tgl_input) = MONTH(CURRENT_DATE - INTERVAL 1 MONTH) and tipe=1")
                If objDataTable.Rows.Count > 0 Then
                    FrmLogin.ShowDialog()
                    Call hakakses()
                Else
                    FrmRegister.ShowDialog()
                End If
            End If
        End If
        '    'SQLCari("select hak_akses hak from user where username='" & FrmLogin.txtuser.Text & "'")
        '    'Dim hak As String = objDataTable.Rows(0).Item("hak").ToString
        '    For i As Integer = 0 To RibbonControl1.Items.Count - 1
        '        If TypeOf RibbonControl1.Items(i) Is DevExpress.XtraBars.BarButtonItem Then
        '            Dim aName As String = (CType(RibbonControl1.Items(i), DevExpress.XtraBars.BarButtonItem)).Name
        '            'Dim hasil As String = String.Join(",", aName)

        '        End If

        '    Next
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBOperator.ItemClick
        tutupform()
        FrmOperator.MdiParent = Me
        FrmOperator.Show()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDenom.ItemClick
        tutupform()
        FrmDenom.MdiParent = Me
        FrmDenom.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPrefix.ItemClick
        tutupform()
        FrmPrefix.MdiParent = Me
        FrmPrefix.Show()
    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBProduk.ItemClick
        tutupform()
        FrmProduk.MdiParent = Me
        FrmProduk.Show()
    End Sub

    Private Sub BarButtonItem6_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBTransaksi.ItemClick
        tutupform()
        FrmPulsa.MdiParent = Me
        FrmPulsa.Show()
    End Sub

    Private Sub BarButtonItem12_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBKirimPesan.ItemClick
        tutupform()
        FrmKomplain.MdiParent = Me
        FrmKomplain.Show()
    End Sub

    Private Sub BarButtonItem13_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        tutupform()
        FrmComingSoon.MdiParent = Me
        FrmComingSoon.Show()
    End Sub

    Private Sub BarButtonItem14_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        tutupform()
        FrmComingSoon.MdiParent = Me
        FrmComingSoon.Show()
    End Sub

    Private Sub BarButtonItem8_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBFormat.ItemClick
        tutupform()
        FrmFormat.MdiParent = Me
        FrmFormat.Show()
    End Sub

    Private Sub BarButtonItem9_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPesanAntrian.ItemClick
        tutupform()
        FrmPesanKeluar.MdiParent = Me
        FrmPesanKeluar.Show()
    End Sub

    Private Sub BarButtonItem15_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBAbout.ItemClick
        FrmAbout.ShowDialog()
    End Sub

    Private Sub BarButtonItem7_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBAdministrator.ItemClick
        tutupform()
        FrmUser.MdiParent = Me
        FrmUser.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDeposit.ItemClick
        tutupform()
        FrmComingSoon.MdiParent = Me
        FrmComingSoon.Show()
    End Sub

    Private Sub BarButtonItem10_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBHistory.ItemClick
        tutupform()
        Frmhistory.MdiParent = Me
        Frmhistory.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Struk.ShowDialog()
    End Sub

    Private Sub BarButtonItem16_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBInformasi.ItemClick
        FrmPemilik.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        FrmPenjualan.ShowDialog()
    End Sub

    Private Sub BarButtonItem17_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBCekTransaksi.ItemClick
        tutupform()
        FrmCekTransaksi.MdiParent = Me
        FrmCekTransaksi.Show()
    End Sub

    Private Sub BarButtonItem1_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        tutupform()
        FrmPassOtoritas.MdiParent = Me
        FrmPassOtoritas.Show()

    End Sub

    Private Sub BarButtonItem2_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        database = 1
        tutupform()
        FrmDatabase.MdiParent = Me
        FrmDatabase.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        database = 2
        tutupform()
        FrmDatabase.MdiParent = Me
        FrmDatabase.Show()
    End Sub

    Private Sub BarButtonItem4_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        database = 3
        tutupform()
        FrmDatabase.MdiParent = Me
        FrmDatabase.Show()
    End Sub

End Class