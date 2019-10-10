Public Class Pembelian
    Dim id As Integer
    Public total As Integer
    Private Sub Pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Visible = False
        Label4.Visible = False
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            DateTimePicker1.Visible = False
            Label4.Visible = False


        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            DateTimePicker1.Visible = True
            Label4.Visible = True


        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using user As New Pilihuser
            user.ShowDialog()
            TextBox1.Text = user.kode
        End Using
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If RadioButton1.Checked Then
            If CInt(TextBox3.Text) < CInt(TextBox7.Text) Then
                MessageBox.Show("duit kurang")
            Else
                Try
                    Using Adapter As New lat_duaDataSetTableAdapters.PembelianTableAdapter
                        Dim kk As String
                        Dim max As String = Adapter.ScalarQuery
                        If max = "" Then
                            max = "1"
                            While max.Length < 5
                                max = "0" + max
                            End While
                            kk = Now.Year.ToString + Now.Month.ToString + max
                        Else
                            Dim temp As Integer = CInt(max.Substring(5, max.Length - 5)) + 1
                            max = temp.ToString
                            While max.Length < 5
                                max = "0" + max
                            End While
                            kk = Now.Year.ToString + Now.Month.ToString + max
                        End If
                        '   Adapter.InsertQuery(kk, TextBox1.Text, 2020, Now.Date, Now.Date, 1)
                        Adapter.InsertQuery(kk, TextBox1.Text, CStr(TextBox2.Text), Now.Date, Now.Date, 1)
                        For a As Integer = 0 To DataGridView1.Rows.Count - 2
                            Using produk As New lat_duaDataSetTableAdapters.ProdukTableAdapter
                                Using ds As New lat_duaDataSet.ProdukDataTable
                                    Dim old As Integer
                                    produk.FillBy(ds, DataGridView1.Rows(a).Cells(0).Value)
                                    old = CInt(ds.Rows(0)(6).ToString)
                                    Dim now As Integer = DataGridView1.Rows(a).Cells(1).Value + old
                                    produk.UpdateQuery(now, DataGridView1.Rows(a).Cells(2).Value, DataGridView1.Rows(a).Cells(0).Value.ToString)
                                    Using detail As New lat_duaDataSetTableAdapters.Pembelian_DetailTableAdapter
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
                                        detail.Insert(id, DataGridView1.Rows(a).Cells(0).Value, kk, DataGridView1.Rows(a).Cells(1).Value, DataGridView1.Rows(a).Cells(2).Value)
                                    End Using
                                End Using
                            End Using
                        Next
                        DataGridView1.Rows.Clear()
                        kk = ""
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                        TextBox3.Text = ""
                        TextBox7.Text = ""
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        Else
            Try
                Using Adapter As New lat_duaDataSetTableAdapters.PembelianTableAdapter
                    Dim kk As String
                    Dim max As String = Adapter.ScalarQuery
                    If max = "" Then
                        max = "1"
                        While max.Length < 5
                            max = "0" + max
                        End While
                        kk = Now.Year.ToString + Now.Month.ToString + max
                    Else
                        Dim temp As Integer = CInt(max.Substring(5, max.Length - 5)) + 1
                        max = temp.ToString
                        While max.Length < 5
                            max = "0" + max
                        End While
                        kk = Now.Year.ToString + Now.Month.ToString + max
                    End If
                    '   Adapter.InsertQuery(kk, TextBox1.Text, 2020, Now.Date, Now.Date, 1)
                    Adapter.InsertQuery(kk, TextBox1.Text, CStr(TextBox2.Text), Now.Date, DateTimePicker1.Value, 0)
                    For a As Integer = 0 To DataGridView1.Rows.Count - 2
                        Using produk As New lat_duaDataSetTableAdapters.ProdukTableAdapter
                            Using ds As New lat_duaDataSet.ProdukDataTable
                                Dim old As Integer
                                produk.FillBy(ds, DataGridView1.Rows(a).Cells(0).Value)
                                old = CInt(ds.Rows(0)(6).ToString)
                                Dim now As Integer = DataGridView1.Rows(a).Cells(1).Value + old
                                produk.UpdateQuery(now, DataGridView1.Rows(a).Cells(2).Value, DataGridView1.Rows(a).Cells(0).Value.ToString)
                                Using detail As New lat_duaDataSetTableAdapters.Pembelian_DetailTableAdapter

                                    Dim m As String = detail.ScalarQuery()
                                    If m = "" Then
                                        m = "1"
                                        id = CInt(m)
                                    Else
                                        Dim f As String = CInt(m) + 1
                                        m = f.ToString
                                        id = m
                                    End If
                                    detail.Insert(id, DataGridView1.Rows(a).Cells(0).Value, kk, DataGridView1.Rows(a).Cells(1).Value, DataGridView1.Rows(a).Cells(2).Value)
                                End Using
                            End Using
                        End Using
                    Next
                    Using hutang As New lat_duaDataSetTableAdapters.Pembayaran_hutangTableAdapter
                        hutang.Insert(id, kk, 1, CInt(TextBox3.Text), Now.Date)
                    End Using
                    DataGridView1.Rows.Clear()
                        kk = ""
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                        TextBox3.Text = ""
                        TextBox7.Text = ""
                    End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Using supplier As New Supplier
            supplier.ShowDialog()
            TextBox2.Text = supplier.kode
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using pk As New Produk
            pk.ShowDialog()
            TextBox4.Text = pk.kode
        End Using
    End Sub
End Class