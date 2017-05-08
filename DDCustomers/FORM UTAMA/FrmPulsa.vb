Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors
Imports System.Globalization
Imports DevExpress.XtraGrid

Public Class FrmPulsa

    Sub gantiwarna(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        If (e.RowHandle >= 0) Then
            Dim category As String = GridView1.GetRowCellDisplayText(e.RowHandle, GridView1.Columns("STATUS"))
            Select Case category
                Case "SUKSES"
                    e.Appearance.BackColor = Color.FromArgb(&H76, &HFC, &H76)
                    e.Appearance.BackColor2 = Color.FromArgb(&HD9, &HFD, &HB5)
                Case "GAGAL"
                    e.Appearance.BackColor = Color.FromArgb(&HFB, &H69, &H69)
                    e.Appearance.BackColor2 = Color.FromArgb(&HFC, &HB3, &HB3)
                Case "PENDING"
                    e.Appearance.BackColor = Color.FromArgb(&HF9, &HFB, &H69)
                    e.Appearance.BackColor2 = Color.FromArgb(&HFC, &HF9, &HB3)
            End Select
        End If
    End Sub

    Sub loaddata()
        SQLCari("select t.id_trx 'ID', t.tgl_trx 'TGL TRANSAKSI', o.nama 'OPERATOR', tp.kode_produk 'KODE PRODUK', tp.no_tujuan 'NO TUJUAN', tp.ulang ULANG, tp.harga_beli 'HARGA BELI', " _
                & "tp.harga_jual 'HARGA JUAL', tp.harga_jual-tp.harga_beli 'LABA', if(t.status=1,'SUKSES',if(t.status=2,'GAGAL','PENDING')) as STATUS, tp.ket 'KETERANGAN',t.nota NOTA " _
                & "from transaksi t,transaksi_pulsa tp, operator o " _
                & "where t.id_trx = tp.id_trx and date(t.tgl_trx)=curdate() and o.id_operator=tp.id_operator " _
                & "order by t.nota asc;")
        GridControl1.DataSource = objDataTable
        GridView1.Columns("TGL TRANSAKSI").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        GridView1.BestFitColumns()

        GridView1.UpdateTotalSummary()
    End Sub

    Private Sub FrmPoduk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        Call loaddata()

        DEawal.DateTime = Now()
        DEakhir.DateTime = Now()

        GridView1.Columns("LABA").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "LABA", "LABA = Rp {0}")
        GridView1.Columns("HARGA BELI").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "HARGA BELI", "BELI = Rp {0}")
        GridView1.Columns("HARGA JUAL").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "HARGA JUAL", "JUAL = Rp {0}")
        GridView1.BestFitColumns()
    End Sub

    Public Sub bbrefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbrefresh.ItemClick
        Call loaddata()
    End Sub

    Private Sub bbtambah_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtambah.ItemClick
        FrmTambahPulsa.txtnotujuan.Text = ""
        FrmTambahPulsa.ShowDialog()
    End Sub

    Private Sub bbedit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbedit.ItemClick
        If GridView1.RowCount > 0 Then
            FrmDetailPulsa.txtnota.Text = GridView1.GetFocusedRow(11).ToString
            FrmDetailPulsa.txttanggal.Text = GridView1.GetFocusedRow(1).ToString
            FrmDetailPulsa.txtkodeproduk.Text = GridView1.GetFocusedRow(3).ToString
            FrmDetailPulsa.txtnotujuan.Text = GridView1.GetFocusedRow(4).ToString
            FrmDetailPulsa.txtbeli.Text = GridView1.GetFocusedRow(6).ToString
            FrmDetailPulsa.txtjual.Text = GridView1.GetFocusedRow(7).ToString
            FrmDetailPulsa.txtlaba.Text = GridView1.GetFocusedRow(8).ToString
            FrmDetailPulsa.txtketerangan.Text = GridView1.GetFocusedRow(10).ToString
            FrmDetailPulsa.txtid.Text = GridView1.GetFocusedRow(0).ToString
            FrmDetailPulsa.ShowDialog()
        Else
            XtraMessageBox.Show("Tidak ada transaksi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        
    End Sub

    Private Sub bbtutup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbtutup.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem10_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        If GridView1.RowCount > 0 Then
            Dim result As Integer = XtraMessageBox.Show("Sukseskan transaksi " & GridView1.GetFocusedRow(3).ToString & "." & GridView1.GetFocusedRow(4).ToString & " ?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                SQLQuery("update transaksi set status=1 where id_trx=" & GridView1.GetFocusedRow(0).ToString & "")
                loaddata()
            Else
            End If
        Else
            XtraMessageBox.Show("Tidak ada transaksi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BarButtonItem11_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If GridView1.RowCount > 0 Then
            Dim result As Integer = XtraMessageBox.Show("Gagalkan transaksi " & GridView1.GetFocusedRow(3).ToString & "." & GridView1.GetFocusedRow(4).ToString & " ?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                SQLQuery("update transaksi set status=2 where id_trx=" & GridView1.GetFocusedRow(0).ToString & "")
                loaddata()
            Else
            End If
        Else
            XtraMessageBox.Show("Tidak ada transaksi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        If GridView1.RowCount > 0 Then
            Dim result As Integer = XtraMessageBox.Show("Pendingkan transaksi " & GridView1.GetFocusedRow(3).ToString & "." & GridView1.GetFocusedRow(4).ToString & " ?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                SQLQuery("update transaksi set status=0 where id_trx=" & GridView1.GetFocusedRow(0).ToString & "")
                loaddata()
            Else
            End If
        Else
            XtraMessageBox.Show("Tidak ada transaksi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        
    End Sub

    Private Sub BarButtonItem9_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If GridView1.RowCount > 0 Then
            GridView1.Columns("KETERANGAN").Visible = False
            Dim tanya As Integer = XtraMessageBox.Show("Export data ke file Excel (.xls)?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If tanya = vbYes Then
                If (Not System.IO.Directory.Exists("C:\DDExport\Report\")) Then
                    System.IO.Directory.CreateDirectory("C:\DDExport\Report\")
                End If

                Dim ps As New DevExpress.XtraPrinting.PrintingSystem()
                Dim link As New DevExpress.XtraPrinting.PrintableComponentLink(ps)
                link.Component = GridControl1
                link.CreateDocument()
                link.Margins.Bottom = 10
                link.Margins.Top = 10
                link.Margins.Left = 10
                link.Margins.Right = 10
                'link.PaperKind = Printing.PaperKind.A4
                Dim filePath As String = "C:\DDExport\Report\" & DateTime.Now.ToString("dd-MM-yyyy") & ".xls"
                link.PrintingSystem.ExportToXls(filePath)
                XtraMessageBox.Show("Data berhasil di export ke C:\DDExport\Report\", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Try
                    Dim process As New System.Diagnostics.Process()
                    process.StartInfo.FileName = filePath
                    process.Start()
                Catch ex As Exception
                End Try
                GridView1.Columns("KETERANGAN").Visible = True
            End If
        Else
            XtraMessageBox.Show("Tidak ada transaksi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        
    End Sub

    Private Sub BarButtonItem14_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        If GridView1.RowCount > 0 Then
            Struk.tipestruk = 1
            Struk.ShowDialog()
        Else
            XtraMessageBox.Show("Tidak ada transaksi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim sstatus As Integer
        Select Case cmbstatus.Text
            Case "Semua"
                sstatus = 3
            Case "Sukses"
                sstatus = 1
            Case "Pending"
                sstatus = 0
            Case "Gagal"
                sstatus = 2
        End Select

        If sstatus = 3 Then
            SQLCari("select t.id_trx 'ID', DATE_FORMAT(t.tgl_trx, '%d/%m/%Y %H:%i:%s') 'TGL TRANSAKSI', o.nama 'OPERATOR', tp.kode_produk 'KODE PRODUK', tp.no_tujuan 'NO TUJUAN',tp.ulang ULANG, tp.harga_beli 'HARGA BELI', " _
                & "tp.harga_jual 'HARGA JUAL', tp.harga_jual-tp.harga_beli 'LABA', if(t.status=1,'SUKSES',if(t.status=2,'GAGAL','PENDING')) as STATUS, tp.ket 'KETERANGAN',t.nota NOTA " _
                & "from transaksi t,transaksi_pulsa tp, operator o, produk h " _
                & "where(t.id_trx = tp.id_trx And tp.kode_produk = h.kode_produk And h.id_operator = o.id_operator) " _
                & "and date(t.tgl_trx) between '" & DEawal.DateTime.ToString("yyy/MM/dd", CultureInfo.InvariantCulture) & "' and '" & DEakhir.DateTime.ToString("yyy/MM/dd", CultureInfo.InvariantCulture) & "' " _
                & "order by t.nota asc;")
        Else
            SQLCari("select t.id_trx 'ID', DATE_FORMAT(t.tgl_trx, '%d/%m/%Y %H:%i:%s') 'TGL TRANSAKSI', o.nama 'OPERATOR', tp.kode_produk 'KODE PRODUK', tp.no_tujuan 'NO TUJUAN',tp.ulang ULANG, tp.harga_beli 'HARGA BELI', " _
                & "tp.harga_jual 'HARGA JUAL', tp.harga_jual-tp.harga_beli 'LABA', if(t.status=1,'SUKSES',if(t.status=2,'GAGAL','PENDING')) as STATUS, tp.ket 'KETERANGAN',t.nota NOTA " _
                & "from transaksi t,transaksi_pulsa tp, operator o, produk h " _
                & "where(t.id_trx = tp.id_trx And tp.kode_produk = h.kode_produk And h.id_operator = o.id_operator) and t.status=" & sstatus & " " _
                & "and date(t.tgl_trx) between '" & DEawal.DateTime.ToString("yyy/MM/dd", CultureInfo.InvariantCulture) & "' and '" & DEakhir.DateTime.ToString("yyy/MM/dd", CultureInfo.InvariantCulture) & "' " _
                & "order by t.nota asc;")
        End If
        
        GridControl1.DataSource = objDataTable
        GridView1.BestFitColumns()
    End Sub

    Private Sub BarButtonItem13_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        If GridView1.RowCount > 0 Then
            Dim pesan As String
            SQLCari("select format from formatpesan where jenis='PIN'")
            Dim pin As String = objDataTable.Rows(0).Item("format").ToString

            SQLQuery("update transaksi_pulsa set ulang=ulang+1 where kode_produk='" & GridView1.GetFocusedRow(3).ToString & "' and no_tujuan='" & GridView1.GetFocusedRow(4).ToString & "'")
            SQLCari("select replace(replace(replace(format,'<KODE_PRODUK>','" & GridView1.GetFocusedRow(3).ToString & "'),'<NO_TUJUAN>','" & GridView1.GetFocusedRow(4).ToString & "'),'<PIN>','" & pin & "') pesan from formatpesan where jenis='TRANSAKSI'")
            pesan = objDataTable.Rows(0).Item("pesan").ToString

            'tipe 1 = pesan masuk, tipe 2 = pesan keluar
            SQLQuery("insert into sms_outbox(tgl_sms,no_hp,pesan) select now(),format,'" & pesan & "' from formatpesan where jenis='NOMOR HP'")
            SQLQuery("insert into sms_history(tgl_input,pesan,tipe) values(now(),'" & pesan & "',2)")

            XtraMessageBox.Show("Transaksi pulsa telah di ulang !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call loaddata()
        Else
            XtraMessageBox.Show("Tidak ada transaksi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        loaddata()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If

    End Sub
End Class