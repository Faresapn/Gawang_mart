Public Class Penjualan
    Public total As Integer
    Private Sub Penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using user As New Pilihuser
            user.ShowDialog()
            TextBox1.Text = user.kode
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using pilih As New Produk
            pilih.ShowDialog()
            TextBox4.Text = pilih.kode
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MessageBox.Show("isi semua")
        Else
            Dim row As Integer = DataGridView1.Rows.Add
            DataGridView1.Rows.Item(row).Cells(0).Value = TextBox4.Text
            DataGridView1.Rows.Item(row).Cells(1).Value = TextBox5.Text
            DataGridView1.Rows.Item(row).Cells(2).Value = TextBox6.Text

            If total = 0 Then
                total = DataGridView1.Rows.Item(row).Cells(1).Value * DataGridView1.Rows.Item(row).Cells(2).Value
                TextBox7.Text = total
            Else
                total = DataGridView1.Rows.Item(row).Cells(1).Value * DataGridView1.Rows.Item(row).Cells(2).Value
                TextBox7.Text = CInt(TextBox7.Text) + total
            End If
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("isi woy")
        Else
            If CInt(TextBox3.Text) < CInt(TextBox7.Text) Then
                MessageBox.Show("Uang Kurang")
            Else
                If RadioButton1.Checked Then
                    Using Adapter As New lat_duaDataSetTableAdapters.PenjualaanTableAdapter
                        Dim kode As String
                        Dim max As String = Adapter.ScalarQuery
                        If max = "" Then
                            max = "1"
                            While max.Length < 5
                                max = "0" + max

                            End While
                            kode = Now.Year.ToString + Now.Month.ToString + max
                        Else
                            Dim temp As Integer = CInt(max.Substring(5, max.Length - 5)) + 1
                            max = temp.ToString
                            While max.Length < 5
                                max = "0" + max

                            End While
                            kode = Now.Year.ToString + Now.Month.ToString + max
                        End If
                        Adapter.Insert(kode, TextBox1.Text, TextBox2.Text, Now.Date, 0)
                        For i As Integer = 0 To DataGridView1.Rows.Count - 2
                            Using produk As New lat_duaDataSetTableAdapters.ProdukTableAdapter
                                Using ds As New lat_duaDataSet.ProdukDataTable
                                    Dim old As Integer
                                    produk.FillBy(ds, DataGridView1.Rows(i).Cells(0).Value)
                                    old = CInt(ds.Rows(0)(6).ToString)
                                    Dim now As Integer = old - DataGridView1.Rows(i).Cells(0).Value
                                    produk.UpdateQuery(now, DataGridView1.Rows(i).Cells(2).Value, DataGridView1.Rows(i).Cells(0).Value.ToString)
                                    Using detail As New lat_duaDataSetTableAdapters.Penjualan_DetailTableAdapter
                                        Dim id As Integer
                                        Dim m As String = detail.ScalarQuery()
                                        If m = "" Then
                                            m = "1"
                                            id = CInt(m)
                                        Else
                                            Dim f As String = CInt(m) + 1
                                            m = f.ToString
                                            id = m
                                        End If
                                        detail.Insert(id, kode, DataGridView1.Rows(i).Cells(0).Value, DataGridView1.Rows(i).Cells(1).Value, DataGridView1.Rows(i).Cells(2).Value)
                                    End Using
                                End Using
                            End Using
                        Next

                    End Using
                Else
                    Using Adapter As New lat_duaDataSetTableAdapters.PenjualaanTableAdapter
                        Dim kode As String
                        Dim max As String = Adapter.ScalarQuery
                        If max = "" Then
                            max = "1"
                            While max.Length < 5
                                max = "0" + max

                            End While
                            kode = Now.Year.ToString + Now.Month.ToString + max
                        Else
                            Dim temp As Integer = CInt(max.Substring(5, max.Length - 5)) + 1
                            max = temp.ToString
                            While max.Length < 5
                                max = "0" + max

                            End While
                            kode = Now.Year.ToString + Now.Month.ToString + max
                        End If
                        Adapter.Insert(kode, TextBox1.Text, TextBox2.Text, Now.Date, 1)
                        For i As Integer = 0 To DataGridView1.Rows.Count - 2
                            Using produk As New lat_duaDataSetTableAdapters.ProdukTableAdapter
                                Using ds As New lat_duaDataSet.ProdukDataTable
                                    Dim old As Integer
                                    produk.FillBy(ds, DataGridView1.Rows(i).Cells(0).Value)
                                    old = CInt(ds.Rows(0)(6).ToString)
                                    Dim now As Integer = old - DataGridView1.Rows(i).Cells(0).Value
                                    produk.UpdateQuery(now, DataGridView1.Rows(i).Cells(2).Value, DataGridView1.Rows(i).Cells(0).Value.ToString)
                                    Using detail As New lat_duaDataSetTableAdapters.Penjualan_DetailTableAdapter
                                        Dim id As Integer
                                        Dim m As String = detail.ScalarQuery()
                                        If m = "" Then
                                            m = "1"
                                            id = CInt(m)
                                        Else
                                            Dim f As String = CInt(m) + 1
                                            m = f.ToString
                                            id = m
                                        End If
                                        detail.Insert(id, kode, DataGridView1.Rows(i).Cells(0).Value, DataGridView1.Rows(i).Cells(1).Value, DataGridView1.Rows(i).Cells(2).Value)
                                    End Using
                                End Using
                            End Using

                        Next
                    End Using
                End If
            End If
        End If
    End Sub
End Class