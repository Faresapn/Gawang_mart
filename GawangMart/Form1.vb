Public Class Form1

    Public Sub login(kodee As String, level As String)

        If level = "admin" Then


        Else

            Lap_jual.Visible = False
            Lap_beli.Visible = False
            UserToolStripMenuItem.Visible = False
            HutangToolStripMenuItem.Visible = False
            TambahProdukToolStripMenuItem.Visible = False
            TambahSupplierToolStripMenuItem.Visible = False
        End If

    End Sub
    Private Sub change(frm As Form)
        frm.TopLevel = False
        frm.TopMost = True
        Panel1.Controls.Add(frm)
        frm.Show()

    End Sub
    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        Penjualan.Show()
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        Pembelian.Show()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        User.Show()
    End Sub

    Private Sub ProdukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProdukToolStripMenuItem.Click

    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click

    End Sub

    Private Sub Lap_jual_Click(sender As Object, e As EventArgs) Handles Lap_jual.Click
        LaporanPembelian.Show()
    End Sub

    Private Sub TambahProdukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TambahProdukToolStripMenuItem.Click
        Addproduk.Show()
    End Sub

    Private Sub DaftarProdukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarProdukToolStripMenuItem.Click
        Produk.Show()
    End Sub

    Private Sub TambahSupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TambahSupplierToolStripMenuItem.Click
        Addsuplier.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem1.Click
        Supplier.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub HutangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HutangToolStripMenuItem.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
