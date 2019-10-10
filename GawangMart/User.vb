Public Class User
    Dim kode As String
    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaduser()
    End Sub
    Private Sub loaduser()
        Using Adapter As New lat_duaDataSetTableAdapters.usersTableAdapter
            Using ds As New lat_duaDataSet.usersDataTable
                Adapter.Fill(ds)
                DataGridView1.DataSource = ds
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("isi semua")
        Else
            Try


                Using Adapter As New lat_duaDataSetTableAdapters.usersTableAdapter

                    Dim max As String = Adapter.ScalarQuery()
                    If max = "" Then
                        max = "1"
                        While max.Length < 5
                            max = "0" + max
                        End While
                        kode = Now.Year.ToString + max
                    Else
                        Dim f As String = CInt(max.Substring(4, max.Length - 4)) + 1
                        max = f.ToString
                        While max.Length < 5
                            max = "0" + max
                        End While
                        kode = Now.Year.ToString + max
                    End If

                    Dim level As String
                    If RadioButton1.Checked Then
                        level = "admin"
                    Else
                        level = "user"
                    End If
                    Adapter.Insert(kode, TextBox2.Text, TextBox3.Text, TextBox4.Text, level)
                    loaduser()

                End Using
            Catch ex As Exception
                MessageBox.Show(kode)
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        baris()
    End Sub
    Private Sub baris()
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        kode = Row.Cells(0).Value.ToString
        TextBox2.Text = Row.Cells(1).Value.ToString
        TextBox3.Text = Row.Cells(2).Value.ToString
        TextBox4.Text = Row.Cells(3).Value.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If kode = "" Then
                MessageBox.Show("Data Masih Kosong")
            ElseIf TextBox2.Text = "Nama" Then
                MessageBox.Show("data tidak boleh dihapus")
            Else
                Using delete As New lat_duaDataSetTableAdapters.usersTableAdapter
                    delete.DeleteQuery(kode)
                    loaduser()
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("isi semua")
        Else
            Try


                Using Adapter As New lat_duaDataSetTableAdapters.usersTableAdapter


                    Dim level As String
                    If RadioButton1.Checked Then
                        level = "Admin"
                    Else
                        level = "User"
                    End If
                    Adapter.UpdateQuery(kode, TextBox2.Text, TextBox3.Text, TextBox4.Text, level, kode)
                    loaduser()

                End Using
            Catch ex As Exception

                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub
End Class