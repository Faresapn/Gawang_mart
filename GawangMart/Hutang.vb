Public Class Hutang
    Dim kode As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Bayarutang.Show()
    End Sub

    Private Sub Hutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hhutang()
    End Sub
    Private Sub hhutang()
        Using Adapter As New lat_duaDataSetTableAdapters.PembelianTableAdapter
            Using ds As New lat_duaDataSet.PembelianDataTable
                ds.Reset()
                Adapter.hutang(ds)
                dgv_hutang.DataSource = ds
            End Using
        End Using
    End Sub
    Private Sub dgv_hutang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_hutang.CellContentClick
        Dim row As DataGridViewRow = dgv_hutang.CurrentRow
        kode = row.Cells(0).Value.ToString
        TextBox1.Text = row.Cells(1).Value.ToString
        TextBox2.Text = row.Cells(2).Value.ToString
        DateTimePicker1.Value = row.Cells(3).Value
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Using Adapter As New lat_duaDataSetTableAdapters.PembelianTableAdapter
                Using ds As New lat_duaDataSet.PembelianDataTable
                    ds.Reset()
                    Adapter.FillBy(ds, Now.Date)
                    dgv_hutang.DataSource = ds
                End Using
            End Using
        Else
            hhutang()
        End If
    End Sub
End Class