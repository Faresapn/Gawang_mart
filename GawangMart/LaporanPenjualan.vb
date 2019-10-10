Public Class LaporanPenjualan
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Using Adapter As New lat_duaDataSetTableAdapters.PenjualaanTableAdapter
            Using ds As New lat_duaDataSet.PenjualaanDataTable
                ds.Reset()
                Adapter.FillBy(ds, TextBox1.Text)
                DataGridView1.DataSource = ds

            End Using
        End Using
    End Sub

    Private Sub LaporanPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using Adapter As New lat_duaDataSetTableAdapters.PenjualaanTableAdapter
            Using ds As New lat_duaDataSet.PenjualaanDataTable
                ds.Reset()
                Adapter.laporan(ds)
                DataGridView1.DataSource = ds
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class