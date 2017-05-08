Imports DevExpress.XtraEditors
Public Class FrmTambahPulsa
    Dim kode As String
    Dim harga As Double

    Sub inputtransaksi()
        Dim nota As New Integer
        SQLCari("select nota from transaksi order by id_trx desc limit 1")
        If objDataTable.Rows.Count > 0 Then
            nota = Convert.ToInt32(objDataTable.Rows(0).Item("nota").ToString) + 1
        Else
            nota = 1
        End If
        SQLQuery("insert into transaksi(tgl_trx,kode_trx,status,nota) values(now(),1,0," & nota & ")")
        SQLQuery("insert into transaksi_pulsa(id_trx,kode_produk,id_operator,no_tujuan,harga_beli,harga_jual,laba) " _
        & "select last_insert_id(),'" & kode & "',o.id_operator,'" & txtnotujuan.Text & "',p.harga_beli,p.harga_jual,p.harga_jual-p.harga_beli from produk p,operator o " _
        & "where p.kode_produk='" & kode & "' and o.nama='" & cmboperator.Text & "'")

        'ambil pin
        SQLCari("select format from formatpesan where jenis='PIN'")
        Dim pin As String = objDataTable.Rows(0).Item("format").ToString

        SQLCari("select replace(replace(replace(format,'<KODE_PRODUK>','" & kode & "'),'<NO_TUJUAN>','" & txtnotujuan.Text & "'),'<PIN>','" & pin & "') pesan from formatpesan where jenis='TRANSAKSI'")
        Dim pesan As String = objDataTable.Rows(0).Item("pesan").ToString

        'tipe 1 = pesan masuk, tipe 2 = pesan keluar
        SQLQuery("insert into sms_outbox(tgl_sms,no_hp,pesan) select now(),format,'" & pesan & "' from formatpesan where jenis='NOMOR HP'")
        SQLQuery("insert into sms_history(tgl_input,pesan,tipe) values(now(),'" & pesan & "',2)")

        XtraMessageBox.Show("Data telah tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        FrmPulsa.loaddata()
    End Sub

    Sub loadoperator()
        SQLCari("select nama NAMA from operator order by id_operator")
        With cmboperator
            .DataSource = objDataTable
            .DisplayMember = "nama"
            .ValueMember = "nama"
        End With
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SQLCari("select tp.no_tujuan from transaksi_pulsa tp, transaksi t where tp.kode_produk='" & kode & "' and tp.no_tujuan='" & txtnotujuan.Text & "' and date(t.tgl_trx)=curdate() and t.id_trx=tp.id_trx")
        If objDataTable.Rows.Count > 0 Then
            Dim result As Integer = XtraMessageBox.Show("Sudah ada nomor dan kode produk yang sama, apakah tetap akan melanjutkan transaksi?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
                Call inputtransaksi()
            Else
            End If
        Else
            Call inputtransaksi()
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.Close()
    End Sub

    Private Sub FrmTambahPulsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadoperator()
        cmboperator.SelectedIndex = 0
    End Sub

    Private Sub cmboperator_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmboperator.SelectedIndexChanged
        SQLCari("select h.denom DENOM,h.harga_jual 'HARGA',h.kode_produk 'KODE' from produk h,operator o where h.id_operator=o.id_operator and o.nama='" & cmboperator.Text & "'")
        If objDataTable.Rows.Count > 0 Then
            With LUproduk
                .Properties.DataSource = objDataTable
                .Properties.ValueMember = objDataTable.Columns(2).ToString 'saat di pilih, ini menjadi key / kode produk
                .Properties.DisplayMember = objDataTable.Columns(2).ToString
                .Properties.AutoSearchColumnIndex = 2 'aktifkan pencarian saat ketik keyboard
                .Properties.BestFit()
            End With
        Else
        End If
    End Sub

    Private Sub LUproduk_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LUproduk.EditValueChanged
        kode = LUproduk.GetSelectedDataRow("KODE").ToString
        harga = LUproduk.GetSelectedDataRow("HARGA").ToString
        lblproduk.Text = kode & " Harga : " & harga
    End Sub

    Private Sub txtnotujuan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnotujuan.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem1.PerformClick()
        End If
    End Sub

    Private Sub txtnotujuan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnotujuan.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub
End Class




'catatan
'insert into transaksi(tgl_trx,jumlah,kode_trx,status,ket,nota) values(now(),50000,1,1,'',1);
'insert into transaksi_pulsa(id_trx,kode_produk,no_tujuan,harga_beli,harga_jual,laba,ulang,ulang_tgl,suplier) 
'values(last_insert_id(),'M5','0856',5550,7000,7000-5550,0,'',0);