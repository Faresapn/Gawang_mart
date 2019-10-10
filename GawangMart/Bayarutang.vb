Public Class Bayarutang
    Private Sub Bayarutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using Adapter As New lat_duaDataSetTableAdapters.Pembayaran_hutangTableAdapter
            Using ds As New lat_duaDataSet.Pembayaran_hutangDataTable
                Adapter.FillBy(ds, TextBox1.Text)
                Dim count As Integer = ds.Rows.Count
                TextBox2.Text = count + 1
            End Using
        End Using
        Using Adapter As New lat_duaDataSetTableAdapters.Pembelian_DetailTableAdapter
            Using ds As New lat_duaDataSet.Pembelian_DetailDataTable
                Adapter.FillBy(ds, TextBox1.Text)
                Dim qty, harga, total As Integer
                For i As Integer = 0 To ds.Rows.Count - 2
                    qty = CInt(ds.Rows(i)(4).ToString)
                    harga = CInt(ds.Rows(i)(5).ToString)
                    If total = 0 Then
                        total = qty * harga
                    Else
                        total = total + (qty * harga)

                    End If
                Next
                TextBox4.Text = total
            End Using
        End Using
    End Sub
End Class