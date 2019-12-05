Public Class ContadorLetras
    Dim res As String = ""
    Dim entrada As String
    Dim cont = 0
    Dim em As String = "S1"
    Dim esp As Boolean
    Dim historial As New List(Of String)

    Private Sub ContadorLetras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        If Not System.Text.RegularExpressions.Regex.IsMatch(TBEntrada.Text, "^[a-b-c]+$") Then
            Label1.Visible = True
            Button1.Enabled = False
        End If
        PBEstados.Image = ImageList1.Images.Item(0)
        Me.BackgroundImage = My.Resources.MTfondo1
        Cabezal.Image = ImageList3.Images.Item(0)
        LAnt.Text = ""
        LAct.Text = "S1"
    End Sub

    Private Sub TBEntrada_TextChanged(sender As Object, e As EventArgs) Handles TBEntrada.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(TBEntrada.Text, "^[a-b-c]+$") Then
            Label1.Visible = True
            Button1.Enabled = False
        Else
            Label1.Visible = False
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        entrada = TBEntrada.Text + " "
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

        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        If em = "S1" Then
            ms1()
        ElseIf em = "S2" Then
            ms2()
        ElseIf em = "S3" Then
            ms3()
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
            End If

            If cont = 0 Then
                PictureBox4.Image = Nothing
            End If
            cambiar()
        End While
        PBEstados.Image = ImageList1.Images.Item(4)
        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        Salir.Enabled = True
    End Sub

    Private Sub BtnRapido_Click(sender As Object, e As EventArgs) Handles BtnRapido.Click
        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        s1()
        Button2.Enabled = True
        BtnLento.Enabled = False
        BtnRapido.Enabled = False
        BTNsgp.Enabled = False
        PBEstados.Image = ImageList1.Images.Item(4)

        LAct.Text = "S4"
        LAnt.Text = em

        Dim pos As Integer = 0
        Dim lon = TBEntrada.Text.Length
        If lon > 4 Then
            lon = 4
        End If
        For i As Integer = lon - 1 To 0 Step -1
            If pos = 0 Then
                If TBRes.Text(i) = "a" Then
                    PictureBox4.Image = ImageList2.Images.Item(0)
                ElseIf TBRes.Text(i) = "b" Then
                    PictureBox4.Image = ImageList2.Images.Item(2)
                ElseIf TBRes.Text(i) = "c" Then
                    PictureBox4.Image = ImageList2.Images.Item(4)
                ElseIf TBRes.Text(i) = "A" Then
                    PictureBox4.Image = ImageList2.Images.Item(1)
                ElseIf TBRes.Text(i) = "B" Then
                    PictureBox4.Image = ImageList2.Images.Item(3)
                ElseIf TBRes.Text(i) = "C" Then
                    PictureBox4.Image = ImageList2.Images.Item(5)
                ElseIf TBRes.Text(i) = "1" Then
                    PictureBox4.Image = ImageList2.Images.Item(6)
                End If
                PictureBox3.Image = Nothing
                PictureBox2.Image = Nothing
                PictureBox1.Image = Nothing
            End If

            If pos = 1 Then
                If TBRes.Text(i) = "a" Then
                    PictureBox3.Image = ImageList2.Images.Item(0)
                ElseIf TBRes.Text(i) = "b" Then
                    PictureBox3.Image = ImageList2.Images.Item(2)
                ElseIf TBRes.Text(i) = "c" Then
                    PictureBox3.Image = ImageList2.Images.Item(4)
                ElseIf TBRes.Text(i) = "A" Then
                    PictureBox3.Image = ImageList2.Images.Item(1)
                ElseIf TBRes.Text(i) = "B" Then
                    PictureBox3.Image = ImageList2.Images.Item(3)
                ElseIf TBRes.Text(i) = "C" Then
                    PictureBox3.Image = ImageList2.Images.Item(5)
                ElseIf TBRes.Text(i) = "1" Then
                    PictureBox3.Image = ImageList2.Images.Item(6)
                End If
                PictureBox2.Image = Nothing
                PictureBox1.Image = Nothing
            End If

            If pos = 2 Then
                If TBRes.Text(i) = "a" Then
                    PictureBox2.Image = ImageList2.Images.Item(0)
                ElseIf TBRes.Text(i) = "b" Then
                    PictureBox2.Image = ImageList2.Images.Item(2)
                ElseIf TBRes.Text(i) = "c" Then
                    PictureBox2.Image = ImageList2.Images.Item(4)
                ElseIf TBRes.Text(i) = "A" Then
                    PictureBox2.Image = ImageList2.Images.Item(1)
                ElseIf TBRes.Text(i) = "B" Then
                    PictureBox2.Image = ImageList2.Images.Item(3)
                ElseIf TBRes.Text(i) = "C" Then
                    PictureBox2.Image = ImageList2.Images.Item(5)
                ElseIf TBRes.Text(i) = "1" Then
                    PictureBox2.Image = ImageList2.Images.Item(6)
                End If
                PictureBox1.Image = Nothing
            End If

            If pos = 3 Then
                If TBRes.Text(i) = "a" Then
                    PictureBox1.Image = ImageList2.Images.Item(0)
                ElseIf TBRes.Text(i) = "b" Then
                    PictureBox1.Image = ImageList2.Images.Item(2)
                ElseIf TBRes.Text(i) = "c" Then
                    PictureBox1.Image = ImageList2.Images.Item(4)
                ElseIf TBRes.Text(i) = "A" Then
                    PictureBox1.Image = ImageList2.Images.Item(1)
                ElseIf TBRes.Text(i) = "B" Then
                    PictureBox1.Image = ImageList2.Images.Item(3)
                ElseIf TBRes.Text(i) = "C" Then
                    PictureBox1.Image = ImageList2.Images.Item(5)
                ElseIf TBRes.Text(i) = "1" Then
                    PictureBox1.Image = ImageList2.Images.Item(6)
                End If
            End If
            pos += 1
        Next
        pos = 0
        lon = TBEntrada.Text.Length
        If lon > 4 Then
            lon = 4
        End If
        For i As Integer = 0 To lon - 1
            If pos = 0 Then
                PictureBox5.Image = ImageList2.Images.Item(6)
                PictureBox6.Image = Nothing
                PictureBox7.Image = Nothing
                PictureBox8.Image = Nothing
                PictureBox9.Image = Nothing
            End If

            If pos = 1 Then
                PictureBox6.Image = ImageList2.Images.Item(6)
                PictureBox7.Image = Nothing
                PictureBox8.Image = Nothing
                PictureBox9.Image = Nothing
            End If

            If pos = 2 Then
                PictureBox7.Image = ImageList2.Images.Item(6)
                PictureBox8.Image = Nothing
                PictureBox9.Image = Nothing
            End If

            If pos = 3 Then
                PictureBox8.Image = ImageList2.Images.Item(6)
                PictureBox9.Image = Nothing
            End If

            If pos = 4 Then
                PictureBox9.Image = ImageList2.Images.Item(6)
            End If
            pos += 1
        Next


    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        My.Computer.Audio.Stop()
        Main.Show()
        Me.Close()
    End Sub

    Sub s1()
        If entrada(cont) = "a" Then
            res = entrada.Substring(0, cont) + "A" + entrada.Substring(cont + 1, entrada.Length - cont - 2)
            cont += 1
            TBRes.Text = res
            em = "S2"
            s2()
        ElseIf entrada(cont) = "b" Then
            res = entrada.Substring(0, cont) + "B" + entrada.Substring(cont + 1, entrada.Length - cont - 2)
            cont += 1
            TBRes.Text = res
            em = "S2"
            s2()
        ElseIf entrada(cont) = "c" Then
            res = entrada.Substring(0, cont) + "C" + entrada.Substring(cont + 1, entrada.Length - cont - 2)
            cont += 1
            TBRes.Text = res
            em = "S2"
            s2()
        ElseIf entrada(cont) = "1" Then
            TBRes.Text = res
            Button1.Enabled = False
        End If
    End Sub

    Sub s2()
        If entrada(cont) = " " Then
            cont -= 1
            TBRes.Text = res
            em = "S3"
            s3()
        Else
            cont += 1
            em = "S2"
            s2()
        End If
    End Sub

    Sub s3()
        If res(cont) = "a" Or res(cont) = "b" Or res(cont) = "c" Or res(cont) = "1" Then
            cont -= 1
            em = "S3"
            s3()
        ElseIf res(cont) = "A" Then
            res = entrada.Substring(0, cont) + "a" + entrada.Substring(cont + 1, entrada.Length - cont - 2) + "1"
            TBRes.Text = res
            cont += 1
            entrada = res + " "
            s1()
        ElseIf res(cont) = "B" Then
            res = entrada.Substring(0, cont) + "b" + entrada.Substring(cont + 1, entrada.Length - cont - 2) + "1"
            TBRes.Text = res
            cont += 1
            entrada = res + " "
            s1()
        ElseIf res(cont) = "C" Then
            res = entrada.Substring(0, cont) + "c" + entrada.Substring(cont + 1, entrada.Length - cont - 2) + "1"
            TBRes.Text = res
            cont += 1
            entrada = res + " "
            s1()
        End If
    End Sub

    Sub ms1()
        If entrada(cont) = "a" Then
            res = entrada.Substring(0, cont) + "A" + entrada.Substring(cont + 1, entrada.Length - cont - 2)
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
        ElseIf entrada(cont) = "b" Then
            res = entrada.Substring(0, cont) + "B" + entrada.Substring(cont + 1, entrada.Length - cont - 2)
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
        ElseIf entrada(cont) = "c" Then
            res = entrada.Substring(0, cont) + "C" + entrada.Substring(cont + 1, entrada.Length - cont - 2)
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
        ElseIf entrada(cont) = "1" Then
            TBRes.Text = res
            Button1.Enabled = False
            Button2.Enabled = True
            Button1.Enabled = False
            Cabezal.Image = ImageList3.Images.Item(0)
            PBEstados.Image = ImageList1.Images.Item(4)
            cambio()
            LAct.Text = "S4"
            LAnt.Text = em
            esp = False
            My.Computer.Audio.Stop()
        End If
    End Sub

    Sub ms2()
        If entrada(cont) = " " Then
            cont -= 1
            res += "1"
            TBRes.Text = res
            cambio()
            LAnt.Text = em
            em = "S3"
            LAct.Text = em
            mover("L")
            Cabezal.Image = ImageList3.Images.Item(2)
            correcion("D")
        Else
            cont += 1
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        End If
    End Sub

    Sub ms3()
        If res(cont) = "a" Or res(cont) = "b" Or res(cont) = "c" Or res(cont) = "1" Then
            cont -= 1
            TBRes.Text = res
            LAnt.Text = em
            em = "S3"
            LAct.Text = em
            mover("L")
            Cabezal.Image = ImageList3.Images.Item(2)
            correcion("D")
        ElseIf res(cont) = "A" Then
            res = entrada.Substring(0, cont) + "a" + entrada.Substring(cont + 1, entrada.Length - cont - 2) + "1"
            cambio()
            cont += 1
            TBRes.Text = res
            entrada = res + " "
            LAnt.Text = em
            em = "S1"
            LAct.Text = em
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        ElseIf res(cont) = "B" Then
            res = entrada.Substring(0, cont) + "b" + entrada.Substring(cont + 1, entrada.Length - cont - 2) + "1"
            cambio()
            cont += 1
            TBRes.Text = res
            entrada = res + " "
            LAnt.Text = em
            em = "S1"
            LAct.Text = em
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        ElseIf res(cont) = "C" Then
            res = entrada.Substring(0, cont) + "c" + entrada.Substring(cont + 1, entrada.Length - cont - 2) + "1"
            cambio()
            cont += 1
            TBRes.Text = res
            entrada = res + " "
            LAnt.Text = em
            em = "S1"
            LAct.Text = em
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        End If
    End Sub

    Sub Reiniciar()
        TBEntrada.Text = ""
        TBRes.Text = ""
        res = ""
        entrada = ""
        em = "S1"
        cont = 0
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
        Dim lon = entrada.Length
        If lon > 5 Then
            lon = 5
        End If

        For i As Integer = 0 To lon - 1
            If pos = 0 Then
                If entrada(i) = "a" Then
                    PictureBox5.Image = ImageList2.Images.Item(0)
                ElseIf entrada(i) = "b" Then
                    PictureBox5.Image = ImageList2.Images.Item(2)
                ElseIf entrada(i) = "c" Then
                    PictureBox5.Image = ImageList2.Images.Item(4)
                End If
            End If

            If pos = 1 Then
                If entrada(i) = "a" Then
                    PictureBox6.Image = ImageList2.Images.Item(0)
                ElseIf entrada(i) = "b" Then
                    PictureBox6.Image = ImageList2.Images.Item(2)
                ElseIf entrada(i) = "c" Then
                    PictureBox6.Image = ImageList2.Images.Item(4)
                End If
            End If

            If pos = 2 Then
                If entrada(i) = "a" Then
                    PictureBox7.Image = ImageList2.Images.Item(0)
                ElseIf entrada(i) = "b" Then
                    PictureBox7.Image = ImageList2.Images.Item(2)
                ElseIf entrada(i) = "c" Then
                    PictureBox7.Image = ImageList2.Images.Item(4)
                End If
            End If

            If pos = 3 Then
                If entrada(i) = "a" Then
                    PictureBox8.Image = ImageList2.Images.Item(0)
                ElseIf entrada(i) = "b" Then
                    PictureBox8.Image = ImageList2.Images.Item(2)
                ElseIf entrada(i) = "c" Then
                    PictureBox8.Image = ImageList2.Images.Item(4)
                End If
            End If

            If pos = 4 Then
                If entrada(i) = "a" Then
                    PictureBox9.Image = ImageList2.Images.Item(0)
                ElseIf entrada(i) = "b" Then
                    PictureBox9.Image = ImageList2.Images.Item(2)
                ElseIf entrada(i) = "c" Then
                    PictureBox9.Image = ImageList2.Images.Item(4)
                End If
            End If

            pos += 1
        Next
    End Sub

    Sub cambio()
        If entrada(cont + 1) = " " Then
            PictureBox5.Image = ImageList2.Images.Item(6)
        ElseIf res(cont) = "A" Then
            PictureBox5.Image = ImageList2.Images.Item(1)
        ElseIf res(cont) = "B" Then
            PictureBox5.Image = ImageList2.Images.Item(3)
        ElseIf res(cont) = "C" Then
            PictureBox5.Image = ImageList2.Images.Item(5)
        ElseIf res(cont) = "a" Then
            PictureBox5.Image = ImageList2.Images.Item(0)
        ElseIf res(cont) = "b" Then
            PictureBox5.Image = ImageList2.Images.Item(2)
        ElseIf res(cont) = "c" Then
            PictureBox5.Image = ImageList2.Images.Item(4)
        End If
    End Sub

    Sub mover(dir As String)
        TBRes.Text += " "
        If dir = "D" Then
            Dim pos As Integer = 0
            Dim lon = TBRes.Text.Length - cont
            If lon > 5 Then
                lon = 5
            End If
            For i As Integer = cont To lon + cont - 1
                If pos = 0 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox5.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox5.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox5.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox5.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox5.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox5.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox5.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox5.Image = Nothing
                    End If
                    PictureBox6.Image = Nothing
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 1 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox6.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox6.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox6.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox6.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox6.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox6.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox6.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox6.Image = Nothing
                    End If
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 2 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox7.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox7.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox7.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox7.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox7.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox7.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox7.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox7.Image = Nothing
                    End If
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 3 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox8.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox8.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox8.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox8.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox8.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox8.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox8.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox8.Image = Nothing
                    End If
                    PictureBox9.Image = Nothing
                End If

                If pos = 4 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox9.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox9.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox9.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox9.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox9.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox9.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox9.Image = ImageList2.Images.Item(6)
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
                    If TBRes.Text(i) = "a" Then
                        PictureBox4.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox4.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox4.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox4.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox4.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox4.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox4.Image = ImageList2.Images.Item(6)
                    End If
                    PictureBox3.Image = Nothing
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 1 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox3.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox3.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox3.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox3.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox3.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox3.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox3.Image = ImageList2.Images.Item(6)
                    End If
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 2 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox2.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox2.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox2.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox2.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox2.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox2.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox2.Image = ImageList2.Images.Item(6)
                    End If
                    PictureBox1.Image = Nothing
                End If

                If pos = 3 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox1.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox1.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox1.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox1.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox1.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox1.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox1.Image = ImageList2.Images.Item(6)
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
                    If TBRes.Text(i) = "a" Then
                        PictureBox4.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox4.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox4.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox4.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox4.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox4.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox4.Image = ImageList2.Images.Item(6)
                    End If
                    PictureBox3.Image = Nothing
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 1 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox3.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox3.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox3.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox3.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox3.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox3.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox3.Image = ImageList2.Images.Item(6)
                    End If
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 2 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox2.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox2.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox2.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox2.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox2.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox2.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox2.Image = ImageList2.Images.Item(6)
                    End If
                    PictureBox1.Image = Nothing
                End If

                If pos = 3 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox1.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox1.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox1.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox1.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox1.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox1.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox1.Image = ImageList2.Images.Item(6)
                    End If
                End If
                pos += 1
            Next
        ElseIf dir = "D" Then
            Dim pos As Integer = 0
            Dim lon = TBRes.Text.Length - cont
            If lon > 5 Then
                lon = 5
            End If
            For i As Integer = cont To lon + cont - 1
                If pos = 0 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox5.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox5.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox5.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox5.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox5.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox5.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox5.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox5.Image = Nothing
                    End If
                    PictureBox6.Image = Nothing
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 1 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox6.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox6.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox6.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox6.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox6.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox6.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox6.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox6.Image = Nothing
                    End If
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 2 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox7.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox7.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox7.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox7.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox7.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox7.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox7.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox7.Image = Nothing
                    End If
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 3 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox8.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox8.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox8.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox8.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox8.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox8.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox8.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox8.Image = Nothing
                    End If
                    PictureBox9.Image = Nothing
                End If

                If pos = 4 Then
                    If TBRes.Text(i) = "a" Then
                        PictureBox9.Image = ImageList2.Images.Item(0)
                    ElseIf TBRes.Text(i) = "b" Then
                        PictureBox9.Image = ImageList2.Images.Item(2)
                    ElseIf TBRes.Text(i) = "c" Then
                        PictureBox9.Image = ImageList2.Images.Item(4)
                    ElseIf TBRes.Text(i) = "A" Then
                        PictureBox9.Image = ImageList2.Images.Item(1)
                    ElseIf TBRes.Text(i) = "B" Then
                        PictureBox9.Image = ImageList2.Images.Item(3)
                    ElseIf TBRes.Text(i) = "C" Then
                        PictureBox9.Image = ImageList2.Images.Item(5)
                    ElseIf TBRes.Text(i) = "1" Then
                        PictureBox9.Image = ImageList2.Images.Item(6)
                    Else
                        PictureBox9.Image = Nothing
                    End If
                End If
                pos += 1
            Next
        End If
    End Sub

End Class