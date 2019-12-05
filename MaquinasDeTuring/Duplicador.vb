Public Class Duplicador
    Dim res As String
    Dim entrada As String
    Dim cont = 1
    Dim em As String = "S1"
    Dim esp As Boolean
    Dim historial As New List(Of String)

    Private Sub Duplicador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        If Not System.Text.RegularExpressions.Regex.IsMatch(TBEntrada.Text, "^[1]+$") Then
            Label1.Visible = True
            Button1.Enabled = False
        End If
        PBEstados.Image = ImageList1.Images.Item(0)
        Me.BackgroundImage = My.Resources.MTfondo1
        Cabezal.Image = ImageList3.Images.Item(0)
        LAnt.Text = ""
        LAct.Text = "S1"
    End Sub

    Private Sub Duplicador_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Carga.Close()
    End Sub

    Private Sub TBEntrada_TextChanged(sender As Object, e As EventArgs) Handles TBEntrada.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(TBEntrada.Text, "^[1]+$") Then
            Label1.Visible = True
            Button1.Enabled = False
        Else
            Label1.Visible = False
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        entrada = " " + TBEntrada.Text + " "
        res = entrada
        BtnLento.Enabled = True
        BtnRapido.Enabled = True
        BTNsgp.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = True
        PBEstados.Image = ImageList1.Images.Item(1)
        Me.BackgroundImage = My.Resources.MTfondo2
        calcular()
        My.Computer.Audio.Play(My.Resources.Inicio, AudioPlayMode.WaitToComplete)
        Label2.Visible = True
        Label3.Visible = True
        LAnt.Visible = True
        LAct.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Reiniciar()
    End Sub

    Private Sub BTNsgp_Click(sender As Object, e As EventArgs) Handles BTNsgp.Click
        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        BtnLento.Enabled = False
        BtnRapido.Enabled = False

        If em = "S1" Then
            ms1()
        ElseIf em = "S2" Then
            ms2()
        ElseIf em = "S3" Then
            ms3()
        ElseIf em = "S4" Then
            BTNsgp.Enabled = False
            Cabezal.Image = ImageList3.Images.Item(0)
            PBEstados.Image = ImageList1.Images.Item(3)
            LAnt.Text = "S4"
        End If
            cambiar()
    End Sub

    Private Sub BtnLento_Click(sender As Object, e As EventArgs) Handles BtnLento.Click
        Salir.Enabled = False
        Button2.Enabled = True
        BtnLento.Enabled = False
        BtnRapido.Enabled = False
        BTNsgp.Enabled = False

        esp = True
        My.Computer.Audio.Play(My.Resources.Giro, AudioPlayMode.BackgroundLoop)
        While esp
            Application.DoEvents()
            Threading.Thread.Sleep(900)
            Application.DoEvents()
            If em = "S1" Then
                ms1()
            ElseIf em = "S2" Then
                ms2()
            ElseIf em = "S3" Then
                ms3()
            ElseIf em = "S4" Then
                esp = False
            End If
            cambiar()
            If cont = 0 Then
                PictureBox4.Image = Nothing
            End If
        End While
        LAct.Text = "S4"
        PBEstados.Image = ImageList1.Images.Item(4)
        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        Salir.Enabled = True
    End Sub

    Private Sub BtnRapido_Click(sender As Object, e As EventArgs) Handles BtnRapido.Click
        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        s1()
        TBRes.Text = res
        Button2.Enabled = True
        BtnLento.Enabled = False
        BtnRapido.Enabled = False
        BTNsgp.Enabled = False
        PBEstados.Image = ImageList1.Images.Item(3)

        Dim pos As Integer = 0
        Dim lon = cont - 4
        If lon > 4 Then
            lon = 4
        ElseIf lon < 0 Then
            lon = 0
        End If
        For i As Integer = cont - 1 To lon Step -1
            If pos = 0 Then
                If res(i) = "1" Then
                    PictureBox4.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox4.Image = ImageList2.Images.Item(0)
                End If
                PictureBox3.Image = Nothing
                PictureBox2.Image = Nothing
                PictureBox1.Image = Nothing
            End If

            If pos = 1 Then
                If res(i) = "1" Then
                    PictureBox3.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox3.Image = ImageList2.Images.Item(0)
                End If
                PictureBox2.Image = Nothing
                PictureBox1.Image = Nothing
            End If

            If pos = 2 Then
                If res(i) = "1" Then
                    PictureBox2.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox2.Image = ImageList2.Images.Item(0)
                End If
                PictureBox1.Image = Nothing
            End If

            If pos = 3 Then
                If res(i) = "1" Then
                    PictureBox1.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox1.Image = ImageList2.Images.Item(0)
                End If
            End If
            pos += 1
        Next
        PictureBox6.Image = Nothing
        PictureBox7.Image = Nothing
        PictureBox8.Image = Nothing
        PictureBox9.Image = Nothing
        LAct.Text = "S4"
        LAnt.Text = em
    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        My.Computer.Audio.Stop()
        Main.Show()
        Me.Close()
    End Sub

    Sub s1()
        If res(cont) = "X" Then
            cont -= 1
            em = "S1"
            s1()
        ElseIf res(cont) = "1" Then
            res = res.Substring(0, cont) + "X" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            cont += 1
            em = "S2"
            s2()
        ElseIf res(cont) = " " Then
            em = "S3"
            cont += 1
            s3()
        End If
    End Sub

    Sub s2()
        If res(cont) = "1" Then
            cont += 1
            em = "S2"
            s2()
        ElseIf res(cont) = "X" Then
            cont += 1
            em = "S2"
            s2()
        ElseIf res(cont) = " " Then
            res = res.Substring(0, cont) + "X" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            cont -= 1
            em = "S1"
            s1()
        End If
    End Sub

    Sub s3()
        If res(cont) = "X" Then
            res = res.Substring(0, cont) + "1" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            cont += 1
            em = "S3"
            s3()
        ElseIf res(cont) = " " Then
            em = "S4"
        End If
    End Sub

    Sub ms1()
        If res(cont) = "X" Then
            cambio()
            cont -= 1
            LAnt.Text = em
            em = "S1"
            LAct.Text = em
            historial.Add(em)
            TBRes.Text = res
            mover("L")
            Cabezal.Image = ImageList3.Images.Item(2)
            correcion("D")
        ElseIf res(cont) = "1" Then
            res = res.Substring(0, cont) + "X" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            cambio()
            cont += 1
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            historial.Add(em)
            TBRes.Text = res
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        ElseIf res(cont) = " " Then
            LAnt.Text = em
            em = "S3"
            cont += 1
            TBRes.Text = res
            Button2.Enabled = True
            Button1.Enabled = False
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(0)
            correcion("L")
            cambio()
            LAct.Text = "S3"
        End If
    End Sub

    Sub ms2()
        If res(cont) = "X" Then
            cont += 1
            em = "S2"
            cambio()
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            historial.Add(em)
            TBRes.Text = res
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        ElseIf res(cont) = "1" Then
            cont += 1
            cambio()
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            historial.Add(em)
            TBRes.Text = res
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        ElseIf res(cont) = " " Then
            res = res.Substring(0, cont) + "X" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            LAnt.Text = em
            em = "S1"
            LAct.Text = em
            cont -= 1
            TBRes.Text = res
            mover("L")
            Cabezal.Image = ImageList3.Images.Item(2)
            correcion("D")
            cambio()
        End If
    End Sub

    Sub ms3()
        If res(cont) = "X" Then
            res = res.Substring(0, cont) + "1" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            cambio()
            cont += 1
            LAnt.Text = em
            em = "S3"
            LAct.Text = em
            historial.Add(em)
            TBRes.Text = res
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        ElseIf res(cont) = " " Then
            LAnt.Text = em
            em = "S4"
            TBRes.Text = res
            Button2.Enabled = True
            Button1.Enabled = False
            Cabezal.Image = ImageList3.Images.Item(0)
            My.Computer.Audio.Stop()
        End If
    End Sub

    Sub Reiniciar()
        TBEntrada.Text = ""
        TBRes.Text = ""
        res = ""
        entrada = ""
        em = "S1"
        cont = 1
        Button2.Enabled = False
        BtnLento.Enabled = False
        BtnRapido.Enabled = False
        BTNsgp.Enabled = False
        Button1.Enabled = True
        PBEstados.Image = ImageList1.Images.Item(0)
        Me.BackgroundImage = My.Resources.MTfondo1
        Cabezal.Image = ImageList3.Images.Item(0)
        Cabezal.Visible = False
        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PictureBox5.Image = Nothing
        PictureBox6.Image = Nothing
        PictureBox7.Image = Nothing
        PictureBox8.Image = Nothing
        PictureBox9.Image = Nothing
        LAnt.Text = ""
        LAct.Text = "S1"
        LAct.Visible = False
        LAnt.Visible = False
    End Sub

    Sub cambiar()
        If em = "S1" Then
            PBEstados.Image = ImageList1.Images.Item(1)
        ElseIf em = "S2" Then
            PBEstados.Image = ImageList1.Images.Item(2)
        ElseIf em = "S3" Then
            PBEstados.Image = ImageList1.Images.Item(3)
        End If
    End Sub

    Sub calcular()
        Cabezal.Visible = True
        Dim pos As Integer = 0
        Dim lon = res.Length
        If lon > 5 Then
            lon = 5
        End If

        For i As Integer = 1 To lon - 1
            If pos = 0 Then
                If res(i) = "1" Then
                    PictureBox5.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox5.Image = ImageList2.Images.Item(0)
                End If
            End If

            If pos = 1 Then
                If res(i) = "1" Then
                    PictureBox6.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox6.Image = ImageList2.Images.Item(0)
                End If
            End If

            If pos = 2 Then
                If res(i) = "1" Then
                    PictureBox7.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox7.Image = ImageList2.Images.Item(0)
                End If
            End If

            If pos = 3 Then
                If res(i) = "1" Then
                    PictureBox8.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox8.Image = ImageList2.Images.Item(0)
                End If
            End If

            If pos = 4 Then
                If res(i) = "1" Then
                    PictureBox9.Image = ImageList2.Images.Item(1)
                ElseIf res(i) = "X" Then
                    PictureBox9.Image = ImageList2.Images.Item(0)
                End If
            End If

            pos += 1
        Next
    End Sub

    Sub cambio()
        If res(cont) = "X" Then
            PictureBox5.Image = ImageList2.Images.Item(0)
        ElseIf res(cont) = "1" Then
            PictureBox5.Image = ImageList2.Images.Item(1)
        End If
    End Sub

    Sub mover(dir As String)
        If dir = "D" Then
            Dim pos As Integer = 0
            Dim lon = res.Length - cont
            If lon > 5 Then
                lon = 5
            End If
            For i As Integer = cont To lon + cont - 1
                If pos = 0 Then
                    If res(i) = "1" Then
                        PictureBox5.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox5.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox5.Image = Nothing
                    End If
                    PictureBox6.Image = Nothing
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 1 Then
                    If res(i) = "1" Then
                        PictureBox6.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox6.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox6.Image = Nothing
                    End If
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 2 Then
                    If res(i) = "1" Then
                        PictureBox7.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox7.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox7.Image = Nothing
                    End If
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 3 Then
                    If res(i) = "1" Then
                        PictureBox8.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox8.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox8.Image = Nothing
                    End If
                    PictureBox9.Image = Nothing
                End If

                If pos = 4 Then
                    If res(i) = "1" Then
                        PictureBox9.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox9.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox9.Image = Nothing
                    End If
                End If

                pos += 1
            Next

        ElseIf dir = "L" Then
            Dim pos As Integer = 0
            Dim lon = cont - 4
            If lon > 4 Then
                lon = 4
            ElseIf lon < 0 Then
                lon = 0
            End If
            For i As Integer = cont - 1 To lon Step -1
                If pos = 0 Then
                    If res(i) = "1" Then
                        PictureBox4.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox4.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox3.Image = Nothing
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 1 Then
                    If res(i) = "1" Then
                        PictureBox3.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox3.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 2 Then
                    If res(i) = "1" Then
                        PictureBox2.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox2.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox1.Image = Nothing
                End If

                If pos = 3 Then
                    If res(i) = "1" Then
                        PictureBox1.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox1.Image = ImageList2.Images.Item(0)
                    End If
                End If
                pos += 1
            Next
        End If
    End Sub

    Sub correcion(dir As String)
        If dir = "L" Then
            Dim pos As Integer = 0
            Dim lon = cont - 4
            If lon > 4 Then
                lon = 4
            ElseIf lon < 0 Then
                lon = 0
            End If
            For i As Integer = cont - 1 To lon Step -1
                If pos = 0 Then
                    If res(i) = "1" Then
                        PictureBox4.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox4.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox4.Image = Nothing
                    End If
                    PictureBox3.Image = Nothing
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 1 Then
                    If res(i) = "1" Then
                        PictureBox3.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox3.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox3.Image = Nothing
                    End If
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 2 Then
                    If res(i) = "1" Then
                        PictureBox2.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox2.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox2.Image = Nothing
                    End If
                    PictureBox1.Image = Nothing
                End If

                If pos = 3 Then
                    If res(i) = "1" Then
                        PictureBox1.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox1.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox1.Image = Nothing
                    End If
                End If
                pos += 1
            Next
        ElseIf dir = "D" Then
            Dim pos As Integer = 0
            Dim lon = res.Length - cont
            If lon > 5 Then
                lon = 5
            End If
            For i As Integer = cont To lon + cont - 1
                If pos = 0 Then
                    If res(i) = "1" Then
                        PictureBox5.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox5.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox5.Image = Nothing
                    End If
                    PictureBox6.Image = Nothing
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 1 Then
                    If res(i) = "1" Then
                        PictureBox6.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox6.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox6.Image = Nothing
                    End If
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 2 Then
                    If res(i) = "1" Then
                        PictureBox7.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox7.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox7.Image = Nothing
                    End If
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 3 Then
                    If res(i) = "1" Then
                        PictureBox8.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox8.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox8.Image = Nothing
                    End If
                    PictureBox9.Image = Nothing
                End If

                If pos = 4 Then
                    If res(i) = "1" Then
                        PictureBox9.Image = ImageList2.Images.Item(1)
                    ElseIf res(i) = "X" Then
                        PictureBox9.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox9.Image = Nothing
                    End If
                End If

                pos += 1
            Next
        End If
    End Sub

End Class