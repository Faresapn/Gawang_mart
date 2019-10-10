Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("isi semua")
        Else
            Using Adapter As New lat_duaDataSetTableAdapters.usersTableAdapter
                Using ds As New lat_duaDataSet.usersDataTable
                    ds.Reset()
                    Adapter.FillBy(ds, TextBox1.Text, TextBox2.Text)
                    If ds.Rows.Count > 0 Then
                        Using form1 As New Form1
                            form1.login(ds.Rows(0)(0).ToString, ds.Rows(0)(3).ToString)
                            form1.ShowDialog()

                        End Using
                    Else
                        MessageBox.Show("Username atau Password anda Mungkin Salah")

                    End If
                End Using
            End Using
        End If
    End Sub
End Class