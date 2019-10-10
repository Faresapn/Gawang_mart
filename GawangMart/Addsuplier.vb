Public Class Addsuplier
    Dim kode As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("isi semua")
        Else
            Try
                Using Adapter As New lat_duaDataSetTableAdapters.SupplierTableAdapter
                    Dim max As String = Adapter.ScalarQuery
                    If max = "" Then
                        max = "1"

                        While max.Length < 5
                            max = "0" + max

                        End While
                        kode = "SU" + Now.Year.ToString + max
                    Else
                        Dim sp As String = CInt(max.Substring(4, max.Length - 4)) + 1
                        max = sp.ToString
                        While max.Length < 5
                            max = "0" + max
                        End While
                        kode = Now.Year.ToString + max
                    End If
                    Adapter.Insert(kode, TextBox1.Text, TextBox2.Text, TextBox3.Text)
                End Using

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class