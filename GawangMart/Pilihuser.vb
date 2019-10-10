Public Class Pilihuser
    Public kode As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        kode = row.Cells(0).Value.ToString
    End Sub

    Private Sub Pilihuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using adapter As New lat_duaDataSetTableAdapters.usersTableAdapter
            Using ds As New lat_duaDataSet.usersDataTable
                adapter.Fill(ds)
                DataGridView1.DataSource = ds
            End Using
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Using adapter As New lat_duaDataSetTableAdapters.usersTableAdapter
            Using ds As New lat_duaDataSet.usersDataTable
                adapter.nama(ds, TextBox1.Text)
                DataGridView1.DataSource = ds
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class