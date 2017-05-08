Imports DevExpress.XtraEditors
Public Class FrmManageProduk
    Friend produklama As String

    Sub loadoperator()
        SQLCari("select nama NAMA from operator order by id_operator")
        With cmboperator
            .DataSource = objDataTable
            .DisplayMember = "nama"
            .ValueMember = "nama"
        End With
    End Sub

    Sub loaddenom()
        SQLCari("select denom DENOM from denom order by denom asc")
        With cmbdenom
            .DataSource = objDataTable
            .DisplayMember = "denom"
            .ValueMember = "denom"
        End With
    End Sub

    Sub setelahsimpan()
        Me.Close()
        txthargabeli.Text = ""
        txtproduk.Text = ""
        txthargajual.Text = ""
        FrmProduk.loaddata()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If Me.Text = "Tambah Data Produk" Then
            SQLCari("select * from produk where kode_produk='" & txtproduk.Text & "' and denom=" & cmbdenom.Text & "")
            If objDataTable.Rows.Count > 0 Then
                XtraMessageBox.Show("Data sudah ada !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                SQLQuery("insert into produk(id_operator,denom,harga_beli,harga_jual,kode_produk) select id_operator," & cmbdenom.Text & "," & txthargabeli.Text & ",'" & txthargajual.Text & "','" & txtproduk.Text & "' " _
                         & "from operator where nama='" & cmboperator.Text & "'")
                XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim result As Integer = XtraMessageBox.Show("Apakah anda ingin tambah produk lagi?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    txthargabeli.Text = ""
                    txtproduk.Text = ""
                    txthargajual.Text = ""
                Else
                    Call setelahsimpan()
                End If
            End If
        Else
            SQLQuery("update produk set id_operator=(select id_operator from operator where nama='" & cmboperator.Text & "'), " _
                     & "denom=" & cmbdenom.Text & ", harga_beli=" & txthargabeli.Text & ", harga_jual=" & txthargajual.Text & ", " _
                     & "kode_produk='" & txtproduk.Text & "' where kode_produk='" & produklama & "'")
            XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call setelahsimpan()
        End If
        
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub FrmManageProduk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loaddenom()
        loadoperator()

        If Me.Text = "Ubah Data Produk" Then
            cmboperator.SelectedIndex = cmboperator.FindString(FrmProduk.GridView1.GetFocusedRow(0).ToString)
            cmbdenom.SelectedIndex = cmbdenom.FindString(FrmProduk.GridView1.GetFocusedRow(1).ToString)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cmbdenom.SelectedIndex = 1
    End Sub

#Region "PerformClickButtonSimpan"

    Private Sub txthargabeli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txthargabeli.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub

    Private Sub txthargajual_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txthargajual.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub

    Private Sub txtproduk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtproduk.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub
#End Region
End Class