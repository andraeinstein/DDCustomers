<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPenjualan
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm
    
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPenjualan))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.bbtambah = New DevExpress.XtraBars.BarButtonItem()
        Me.bbedit = New DevExpress.XtraBars.BarButtonItem()
        Me.bbhapus = New DevExpress.XtraBars.BarButtonItem()
        Me.bbrefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbtutup = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnindosat = New System.Windows.Forms.Button()
        Me.btnxl = New System.Windows.Forms.Button()
        Me.btntelkomsel = New System.Windows.Forms.Button()
        Me.btnesia = New System.Windows.Forms.Button()
        Me.btntri = New System.Windows.Forms.Button()
        Me.btnsmart = New System.Windows.Forms.Button()
        Me.btnflexi = New System.Windows.Forms.Button()
        Me.btnstarone = New System.Windows.Forms.Button()
        Me.lbltoko = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.AllowMdiChildButtons = False
        Me.RibbonControl1.AllowMinimizeRibbon = False
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4, Me.BarButtonItem5, Me.BarButtonItem6, Me.BarButtonItem7, Me.BarButtonItem8, Me.bbtambah, Me.bbedit, Me.bbhapus, Me.bbrefresh, Me.bbtutup, Me.BarButtonItem9})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 15
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages
        Me.RibbonControl1.ShowQatLocationSelector = False
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(945, 122)
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Data Operator"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Data Denom"
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Data Prefix"
        Me.BarButtonItem3.Glyph = CType(resources.GetObject("BarButtonItem3.Glyph"), System.Drawing.Image)
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Data Produk"
        Me.BarButtonItem4.Glyph = CType(resources.GetObject("BarButtonItem4.Glyph"), System.Drawing.Image)
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Data Deposit"
        Me.BarButtonItem5.Glyph = CType(resources.GetObject("BarButtonItem5.Glyph"), System.Drawing.Image)
        Me.BarButtonItem5.Id = 5
        Me.BarButtonItem5.Name = "BarButtonItem5"
        Me.BarButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem6
        '
        Me.BarButtonItem6.Caption = "Data Transaksi Pulsa"
        Me.BarButtonItem6.Glyph = CType(resources.GetObject("BarButtonItem6.Glyph"), System.Drawing.Image)
        Me.BarButtonItem6.Id = 6
        Me.BarButtonItem6.Name = "BarButtonItem6"
        Me.BarButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "Setting Administrator"
        Me.BarButtonItem7.Glyph = CType(resources.GetObject("BarButtonItem7.Glyph"), System.Drawing.Image)
        Me.BarButtonItem7.Id = 7
        Me.BarButtonItem7.Name = "BarButtonItem7"
        Me.BarButtonItem7.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Caption = "Format Transaksi"
        Me.BarButtonItem8.Glyph = CType(resources.GetObject("BarButtonItem8.Glyph"), System.Drawing.Image)
        Me.BarButtonItem8.Id = 8
        Me.BarButtonItem8.Name = "BarButtonItem8"
        Me.BarButtonItem8.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bbtambah
        '
        Me.bbtambah.Caption = "Tambah"
        Me.bbtambah.Glyph = CType(resources.GetObject("bbtambah.Glyph"), System.Drawing.Image)
        Me.bbtambah.Id = 9
        Me.bbtambah.Name = "bbtambah"
        Me.bbtambah.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bbedit
        '
        Me.bbedit.Caption = "Ubah"
        Me.bbedit.Glyph = CType(resources.GetObject("bbedit.Glyph"), System.Drawing.Image)
        Me.bbedit.Id = 10
        Me.bbedit.Name = "bbedit"
        Me.bbedit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bbhapus
        '
        Me.bbhapus.Caption = "Hapus"
        Me.bbhapus.Glyph = CType(resources.GetObject("bbhapus.Glyph"), System.Drawing.Image)
        Me.bbhapus.Id = 11
        Me.bbhapus.Name = "bbhapus"
        Me.bbhapus.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bbrefresh
        '
        Me.bbrefresh.Caption = "Refresh"
        Me.bbrefresh.Glyph = CType(resources.GetObject("bbrefresh.Glyph"), System.Drawing.Image)
        Me.bbrefresh.Id = 12
        Me.bbrefresh.Name = "bbrefresh"
        Me.bbrefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bbtutup
        '
        Me.bbtutup.Caption = "Tutup"
        Me.bbtutup.Glyph = CType(resources.GetObject("bbtutup.Glyph"), System.Drawing.Image)
        Me.bbtutup.Id = 13
        Me.bbtutup.Name = "bbtutup"
        Me.bbtutup.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem9
        '
        Me.BarButtonItem9.Caption = "Export"
        Me.BarButtonItem9.Glyph = CType(resources.GetObject("BarButtonItem9.Glyph"), System.Drawing.Image)
        Me.BarButtonItem9.Id = 14
        Me.BarButtonItem9.Name = "BarButtonItem9"
        Me.BarButtonItem9.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Master Data"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnindosat, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnxl, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btntelkomsel, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnesia, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btntri, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnsmart, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnflexi, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnstarone, 3, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(10, 130)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(925, 307)
        Me.TableLayoutPanel1.TabIndex = 36
        '
        'Button4
        '
        Me.Button4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button4.Location = New System.Drawing.Point(465, 207)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(225, 97)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "TELKOMSEL DATA"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(3, 207)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(225, 97)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "INDOSAT DATA"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(696, 105)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(226, 96)
        Me.Button2.TabIndex = 11
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(234, 207)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(225, 97)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "THREE DATA"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnindosat
        '
        Me.btnindosat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnindosat.BackgroundImage = CType(resources.GetObject("btnindosat.BackgroundImage"), System.Drawing.Image)
        Me.btnindosat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnindosat.Location = New System.Drawing.Point(3, 3)
        Me.btnindosat.Name = "btnindosat"
        Me.btnindosat.Size = New System.Drawing.Size(225, 96)
        Me.btnindosat.TabIndex = 0
        Me.btnindosat.UseVisualStyleBackColor = True
        '
        'btnxl
        '
        Me.btnxl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxl.BackgroundImage = CType(resources.GetObject("btnxl.BackgroundImage"), System.Drawing.Image)
        Me.btnxl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnxl.Location = New System.Drawing.Point(234, 3)
        Me.btnxl.Name = "btnxl"
        Me.btnxl.Size = New System.Drawing.Size(225, 96)
        Me.btnxl.TabIndex = 1
        Me.btnxl.UseVisualStyleBackColor = True
        '
        'btntelkomsel
        '
        Me.btntelkomsel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btntelkomsel.BackgroundImage = CType(resources.GetObject("btntelkomsel.BackgroundImage"), System.Drawing.Image)
        Me.btntelkomsel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btntelkomsel.Location = New System.Drawing.Point(465, 3)
        Me.btntelkomsel.Name = "btntelkomsel"
        Me.btntelkomsel.Size = New System.Drawing.Size(225, 96)
        Me.btntelkomsel.TabIndex = 2
        Me.btntelkomsel.UseVisualStyleBackColor = True
        '
        'btnesia
        '
        Me.btnesia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnesia.BackgroundImage = CType(resources.GetObject("btnesia.BackgroundImage"), System.Drawing.Image)
        Me.btnesia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnesia.Location = New System.Drawing.Point(696, 3)
        Me.btnesia.Name = "btnesia"
        Me.btnesia.Size = New System.Drawing.Size(226, 96)
        Me.btnesia.TabIndex = 3
        Me.btnesia.UseVisualStyleBackColor = True
        '
        'btntri
        '
        Me.btntri.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btntri.BackgroundImage = CType(resources.GetObject("btntri.BackgroundImage"), System.Drawing.Image)
        Me.btntri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btntri.Location = New System.Drawing.Point(3, 105)
        Me.btntri.Name = "btntri"
        Me.btntri.Size = New System.Drawing.Size(225, 96)
        Me.btntri.TabIndex = 4
        Me.btntri.UseVisualStyleBackColor = True
        '
        'btnsmart
        '
        Me.btnsmart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsmart.BackgroundImage = CType(resources.GetObject("btnsmart.BackgroundImage"), System.Drawing.Image)
        Me.btnsmart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnsmart.Location = New System.Drawing.Point(234, 105)
        Me.btnsmart.Name = "btnsmart"
        Me.btnsmart.Size = New System.Drawing.Size(225, 96)
        Me.btnsmart.TabIndex = 5
        Me.btnsmart.UseVisualStyleBackColor = True
        '
        'btnflexi
        '
        Me.btnflexi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnflexi.BackgroundImage = CType(resources.GetObject("btnflexi.BackgroundImage"), System.Drawing.Image)
        Me.btnflexi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnflexi.Location = New System.Drawing.Point(465, 105)
        Me.btnflexi.Name = "btnflexi"
        Me.btnflexi.Size = New System.Drawing.Size(225, 96)
        Me.btnflexi.TabIndex = 6
        Me.btnflexi.UseVisualStyleBackColor = True
        '
        'btnstarone
        '
        Me.btnstarone.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnstarone.BackgroundImage = CType(resources.GetObject("btnstarone.BackgroundImage"), System.Drawing.Image)
        Me.btnstarone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnstarone.Location = New System.Drawing.Point(696, 207)
        Me.btnstarone.Name = "btnstarone"
        Me.btnstarone.Size = New System.Drawing.Size(226, 97)
        Me.btnstarone.TabIndex = 7
        Me.btnstarone.UseVisualStyleBackColor = True
        '
        'lbltoko
        '
        Me.lbltoko.AutoSize = True
        Me.lbltoko.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbltoko.Font = New System.Drawing.Font("Cambria", 40.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltoko.ForeColor = System.Drawing.Color.Black
        Me.lbltoko.Location = New System.Drawing.Point(12, 47)
        Me.lbltoko.Name = "lbltoko"
        Me.lbltoko.Size = New System.Drawing.Size(311, 63)
        Me.lbltoko.TabIndex = 38
        Me.lbltoko.Text = "Nama Toko"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox1.BackgroundImage = Global.DDCustomers.My.Resources.Resources.ahtefe
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(766, 47)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(119, 67)
        Me.PictureBox1.TabIndex = 50
        Me.PictureBox1.TabStop = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(891, 55)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(42, 39)
        Me.SimpleButton1.TabIndex = 12
        '
        'FrmPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 447)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.lbltoko)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPenjualan"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Penjualan Pulsa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbtambah As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents bbedit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbhapus As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbrefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbtutup As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnindosat As System.Windows.Forms.Button
    Friend WithEvents btnxl As System.Windows.Forms.Button
    Friend WithEvents btntelkomsel As System.Windows.Forms.Button
    Friend WithEvents btnesia As System.Windows.Forms.Button
    Friend WithEvents btntri As System.Windows.Forms.Button
    Friend WithEvents btnsmart As System.Windows.Forms.Button
    Friend WithEvents btnstarone As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnflexi As System.Windows.Forms.Button
    Friend WithEvents lbltoko As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
