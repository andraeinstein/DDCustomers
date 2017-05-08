Imports DevExpress.XtraEditors
Imports System.Text.RegularExpressions
Public Class FrmIsiPulsa
    Friend denomlama As String

    Sub setelahsimpan()
        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        'txtdenom.Text = ""
        FrmDenom.loaddata()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub FrmIsiPulsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLCari("select o.nama OPERATOR,p.denom NOMINAL,p.harga_jual 'HARGA',if(right(p.denom,1)=1,'PULSA INTERNET'," _
                & "if(right(p.denom,1)=2,'PULSA SMS','PULSA REGULAR')) TYPE,p.kode_produk from produk p,operator o " _
                & "where p.id_operator=o.id_operator and o.nama='" & lbloperator.Text & "'")
        If objDataTable.Rows.Count > 0 Then
            GridControl1.DataSource = objDataTable
            GridView1.BestFitColumns()
        End If
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        txtdetoperator.Text = GridView1.GetFocusedRow(0).ToString
        txtdetharga.Text = GridView1.GetFocusedRow(2).ToString
        txtdetnominal.Text = GridView1.GetFocusedRow(1).ToString
        txtkodeproduk.Text = GridView1.GetFocusedRow(4).ToString
        txttype.Text = GridView1.GetFocusedRow(3).ToString
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
        txtnohp.Text = ""
        For Each c As Control In GroupControl1.Controls
            If TypeOf c Is TextBox Then
                CType(c, TextBox).Text = String.Empty
            End If
        Next
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim cekpass As Integer
        SQLCari("select pass from passotoritas where pass='" & computeHash(Regex.Replace(txtpass.Text, "[^A-Za-z]", String.Empty)) & "'")
        If objDataTable.Rows.Count > 0 Then
            If Regex.Replace(txtpass.Text, "[^0-9]", String.Empty) = Date.Today.Day Then
                cekpass = 1
            Else
                cekpass = 0
            End If
        End If


        If txtdetnominal.Text = "" Or cekpass = 0 Then
            XtraMessageBox.Show("Produk belum dipilih / Password salahl !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SQLCari("select p.prefix,o.nama FROM prefix p,operator o WHERE INSTR('" & txtnohp.Text & "',prefix)>0 and p.id_operator=o.id_operator limit 1")
            If objDataTable.Rows.Count > 0 Then
                Dim namaoperator As String = objDataTable.Rows(0).Item("nama").ToString
                If namaoperator = lbloperator.Text Then
                    Dim result As Integer = XtraMessageBox.Show("Setuju pembelian pulsa dengan nomor HP " & txtnohp.Text & " seharga Rp " & txtdetharga.Text & "", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        Dim nota As New Integer
                        SQLCari("select nota from transaksi order by id_trx desc limit 1")
                        If objDataTable.Rows.Count > 0 Then
                            nota = Convert.ToInt32(objDataTable.Rows(0).Item("nota").ToString) + 1
                        Else
                            nota = 1
                        End If
                        SQLQuery("insert into transaksi(tgl_trx,kode_trx,status,nota) values(now(),1,0," & nota & ")")
                        SQLQuery("insert into transaksi_pulsa(id_trx,kode_produk,id_operator,no_tujuan,harga_beli,harga_jual,laba) " _
                        & "select last_insert_id(),'" & txtkodeproduk.Text & "',o.id_operator,'" & txtnohp.Text & "',p.harga_beli,p.harga_jual,p.harga_jual-p.harga_beli from produk p,operator o " _
                        & "where p.kode_produk='" & txtkodeproduk.Text & "' and o.nama='" & txtdetoperator.Text & "'")

                        'ambil pin
                        SQLCari("select format from formatpesan where jenis='PIN'")
                        Dim pin As String = objDataTable.Rows(0).Item("format").ToString

                        SQLCari("select replace(replace(replace(format,'<KODE_PRODUK>','" & txtkodeproduk.Text & "'),'<NO_TUJUAN>','" & txtnohp.Text & "'),'<PIN>','" & pin & "') pesan from formatpesan where jenis='TRANSAKSI'")
                        Dim pesan As String = objDataTable.Rows(0).Item("pesan").ToString

                        'tipe 1 = pesan masuk, tipe 2 = pesan keluar
                        SQLQuery("insert into sms_outbox(tgl_sms,no_hp,pesan) select now(),format,'" & pesan & "' from formatpesan where jenis='NOMOR HP'")
                        SQLQuery("insert into sms_history(tgl_input,pesan,tipe) values(now(),'" & pesan & "',2)")

                        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Struk.tipestruk = 2
                        Struk.ShowDialog()
                        SimpleButton2.PerformClick()
                    Else
                    End If
                Else
                    XtraMessageBox.Show("Nomor HP tidak cocok dengan prefix / belum ada prefix dengan nomor HP ini !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub txtnohp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnohp.KeyDown
        If e.KeyCode = Keys.Enter Then
            SimpleButton1.PerformClick()
        End If
    End Sub

    Private Sub txtnohp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnohp.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub
End Class