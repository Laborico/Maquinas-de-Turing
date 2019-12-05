Public Class P101
    Dim res As String
    Dim entrada As String
    Dim cont = 0
    Dim em As String = "S1"
    Dim esp As Boolean
    Dim historial As New List(Of String)

    Private Sub P101_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        PBEstados.Image = ImageList1.Images.Item(0)
        Me.BackgroundImage = My.Resources.MTfondo1
        Cabezal.Image = ImageList3.Images.Item(0)
        LAnt.Text = ""
        LAct.Text = "S1"
    End Sub

    Private Sub P101_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Carga.Close()
    End Sub

    Private Sub TBEntrada_TextChanged(sender As Object, e As EventArgs) Handles TBEntrada.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(TBEntrada.Text, "^[0-1- ]+$") Then
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

        If cont = entrada.Length - 1 Then
            BTNsgp.Enabled = False
            My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        End If

        If em = "S1" Then
            ms1()
        ElseIf em = "S2" Then
            ms2()
        ElseIf em = "S3" Then
            ms3()
        ElseIf em = "S4" Then
            BTNsgp.Enabled = False
            PBEstados.Image = ImageList1.Images.Item(3)
        End If

        If em = "S2" Then
            TBRes.Text = "Cadena Aceptada"
        Else
            TBRes.Text = "Cadena NO Aceptada"
        End If

        If cont <= 2 Then
            BTNpant.Enabled = False
        Else
            BTNpant.Enabled = True
        End If
        cambiar()
    End Sub

    Private Sub BTNpant_Click(sender As Object, e As EventArgs) Handles BTNpant.Click
        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        cont -= 1
        historial.RemoveAt(cont)
        em = historial(cont - 1)

        If cont <= 2 Then
            BTNpant.Enabled = False
        Else
            BTNpant.Enabled = True
        End If

        If Not cont = entrada.Length - 1 Then
            BTNsgp.Enabled = True
        End If

        If em = "S1" Then
            Cabezal.Image = ImageList3.Images.Item(0)
        ElseIf em = "S2" Then
            Cabezal.Image = ImageList3.Images.Item(1)
        End If
        LAct.Text = em
        LAnt.Text = historial(cont - 2)
        cambiar()
        mover("L")
        correcion("D")
        Cabezal.Image = ImageList3.Images.Item(2)

    End Sub

    Private Sub BtnLento_Click(sender As Object, e As EventArgs) Handles BtnLento.Click
        Salir.Enabled = False
        Button2.Enabled = True
        BTNpant.Enabled = False
        BtnLento.Enabled = False
        BtnRapido.Enabled = False
        BTNsgp.Enabled = False

        esp = True
        My.Computer.Audio.Play(My.Resources.Giro, AudioPlayMode.BackgroundLoop)
        While esp
            Application.DoEvents()
            Threading.Thread.Sleep(900)
            Application.DoEvents()
            If cont = entrada.Length - 1 Then
                esp = False
            End If
            If em = "S1" Then
                ms1()
            ElseIf em = "S2" Then
                ms2()
            ElseIf em = "S3" Then
                ms3()
            ElseIf em = "S4" Then
                esp = False
                PBEstados.Image = ImageList1.Images.Item(3)
            End If

            cambiar()
        End While

        If em = "S2" Then
            TBRes.Text = "Cadena Aceptada"
        Else
            TBRes.Text = "Cadena NO Aceptada"
        End If

        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        Salir.Enabled = True
    End Sub

    Private Sub BtnRapido_Click(sender As Object, e As EventArgs) Handles BtnRapido.Click
        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        s1()
        Button2.Enabled = True
        BTNpant.Enabled = False
        BtnLento.Enabled = False
        BtnRapido.Enabled = False
        BTNsgp.Enabled = False
        If em = "S2" Then
            TBRes.Text = "Cadena Aceptada"
            PBEstados.Image = ImageList1.Images.Item(2)


            Dim pos As Integer = 0
            Dim lon = cont - 4
            If lon > 4 Then
                lon = 4
            ElseIf lon < 0 Then
                lon = 0
            End If
            For i As Integer = cont - 1 To lon Step -1
                If pos = 0 Then
                    If entrada(i) = "1" Then
                        PictureBox4.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox4.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox3.Image = Nothing
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 1 Then
                    If entrada(i) = "1" Then
                        PictureBox3.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox3.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 2 Then
                    If entrada(i) = "1" Then
                        PictureBox2.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox2.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox1.Image = Nothing
                End If

                If pos = 3 Then
                    If entrada(i) = "1" Then
                        PictureBox1.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox1.Image = ImageList2.Images.Item(0)
                    End If
                End If
                pos += 1
            Next
            PictureBox5.Image = Nothing
            PictureBox6.Image = Nothing
            PictureBox7.Image = Nothing
            PictureBox8.Image = Nothing
            PictureBox9.Image = Nothing


        Else
            TBRes.Text = "Cadena NO Aceptada"

            Dim pos As Integer = 0
            Dim lon = cont - 4
            If lon > 4 Then
                lon = 4
            ElseIf lon < 0 Then
                lon = 0
            End If
            For i As Integer = cont - 1 To lon Step -1
                If pos = 0 Then
                    If entrada(i) = "1" Then
                        PictureBox4.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox4.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox3.Image = Nothing
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 1 Then
                    If entrada(i) = "1" Then
                        PictureBox3.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox3.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 2 Then
                    If entrada(i) = "1" Then
                        PictureBox2.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox2.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox1.Image = Nothing
                End If

                If pos = 3 Then
                    If entrada(i) = "1" Then
                        PictureBox1.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox1.Image = ImageList2.Images.Item(0)
                    End If
                End If
                pos += 1
            Next
            correcion("D")
        End If
        If em = "S2" Then
            PBEstados.Image = ImageList1.Images.Item(2)
        ElseIf em = "S3" Then
            PBEstados.Image = ImageList1.Images.Item(3)
        End If

    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        My.Computer.Audio.Stop()
        Main.Show()
        Me.Close()
    End Sub

    Sub s1()
        If entrada(cont) = "0" Then
            LAnt.Text = em
            em = "S4"
            LAct.Text = "Sumidero"
        ElseIf entrada(cont) = "1" Then
            cont += 1
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            s2()
        ElseIf entrada(cont) = " " Then
            LAnt.Text = em
            em = "S1"
            LAct.Text = em
            Button2.Enabled = True
            Button1.Enabled = False
        End If
    End Sub

    Sub s2()
        If entrada(cont) = "0" Then
            cont += 1
            LAnt.Text = em
            em = "S3"
            LAct.Text = em
            s3()
        ElseIf entrada(cont) = "1" Then
            cont += 1
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            s2()
        End If
    End Sub

    Sub s3()
        If entrada(cont) = "0" Then
            LAnt.Text = em
            em = "S4"
            LAct.Text = "Sumidero"
        ElseIf entrada(cont) = "1" Then
            cont += 1
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            s2()
        End If
    End Sub

    Sub ms1()
        If entrada(cont) = "0" Then
            cambio()
            LAnt.Text = em
            em = "S4"
            LAct.Text = "Sumidero"
            historial.Add(em)
            Cabezal.Image = ImageList3.Images.Item(0)
        ElseIf entrada(cont) = "1" Then
            res += "1"
            cambio()
            cont += 1
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            historial.Add(em)
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        ElseIf entrada(cont) = " " Then
            Button2.Enabled = True
            Button1.Enabled = False
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(0)
            correcion("L")
            cambio()
            LAct.Text = em
            em = "S1"
            LAnt.Text = em
            My.Computer.Audio.Stop()
        End If
    End Sub

    Sub ms2()
        If entrada(cont) = "0" Then
            cambio()
            cont += 1
            LAnt.Text = em
            em = "S3"
            LAct.Text = em
            historial.Add(em)
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        ElseIf entrada(cont) = "1" Then
            cambio()
            cont += 1
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            historial.Add(em)
            mover("D")
            Cabezal.Image = ImageList3.Images.Item(1)
            correcion("L")
        End If
    End Sub

    Sub ms3()
        If entrada(cont) = "0" Then
            cambio()
            LAnt.Text = em
            em = "S4"
            LAct.Text = "Sumidero"
            historial.Add(em)
            Cabezal.Image = ImageList3.Images.Item(0)
        ElseIf entrada(cont) = "1" Then
            cambio()
            cont += 1
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            historial.Add(em)
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
        BTNpant.Enabled = False
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
        ElseIf em = "S4" Then
            PBEstados.Image = ImageList1.Images.Item(4)
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
                If entrada(i) = "1" Then
                    PictureBox5.Image = ImageList2.Images.Item(1)
                ElseIf entrada(i) = "0" Then
                    PictureBox5.Image = ImageList2.Images.Item(0)
                End If
            End If

            If pos = 1 Then
                If entrada(i) = "1" Then
                    PictureBox6.Image = ImageList2.Images.Item(1)
                ElseIf entrada(i) = "0" Then
                    PictureBox6.Image = ImageList2.Images.Item(0)
                End If
            End If

            If pos = 2 Then
                If entrada(i) = "1" Then
                    PictureBox7.Image = ImageList2.Images.Item(1)
                ElseIf entrada(i) = "0" Then
                    PictureBox7.Image = ImageList2.Images.Item(0)
                End If
            End If

            If pos = 3 Then
                If entrada(i) = "1" Then
                    PictureBox8.Image = ImageList2.Images.Item(1)
                ElseIf entrada(i) = "0" Then
                    PictureBox8.Image = ImageList2.Images.Item(0)
                End If
            End If

            If pos = 4 Then
                If entrada(i) = "1" Then
                    PictureBox9.Image = ImageList2.Images.Item(1)
                ElseIf entrada(i) = "0" Then
                    PictureBox9.Image = ImageList2.Images.Item(0)
                End If
            End If

            pos += 1
        Next
    End Sub

    Sub cambio()
        If entrada(cont) = "0" Then
            PictureBox5.Image = ImageList2.Images.Item(0)
        ElseIf entrada(cont) = "1" Then
            PictureBox5.Image = ImageList2.Images.Item(1)
        End If
    End Sub

    Sub mover(dir As String)
        If dir = "D" Then
            Dim pos As Integer = 0
            Dim lon = entrada.Length - cont
            If lon > 5 Then
                lon = 5
            End If
            For i As Integer = cont To lon + cont - 1
                If pos = 0 Then
                    If entrada(i) = "1" Then
                        PictureBox5.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
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
                    If entrada(i) = "1" Then
                        PictureBox6.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox6.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox6.Image = Nothing
                    End If
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 2 Then
                    If entrada(i) = "1" Then
                        PictureBox7.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox7.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox7.Image = Nothing
                    End If
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 3 Then
                    If entrada(i) = "1" Then
                        PictureBox8.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox8.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox8.Image = Nothing
                    End If
                    PictureBox9.Image = Nothing
                End If

                If pos = 4 Then
                    If entrada(i) = "1" Then
                        PictureBox9.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
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
                    If entrada(i) = "1" Then
                        PictureBox4.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox4.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox3.Image = Nothing
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 1 Then
                    If entrada(i) = "1" Then
                        PictureBox3.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox3.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 2 Then
                    If entrada(i) = "1" Then
                        PictureBox2.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox2.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox1.Image = Nothing
                End If

                If pos = 3 Then
                    If entrada(i) = "1" Then
                        PictureBox1.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
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
                    If entrada(i) = "1" Then
                        PictureBox4.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox4.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox3.Image = Nothing
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 1 Then
                    If entrada(i) = "1" Then
                        PictureBox3.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox3.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox2.Image = Nothing
                    PictureBox1.Image = Nothing
                End If

                If pos = 2 Then
                    If entrada(i) = "1" Then
                        PictureBox2.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox2.Image = ImageList2.Images.Item(0)
                    End If
                    PictureBox1.Image = Nothing
                End If

                If pos = 3 Then
                    If entrada(i) = "1" Then
                        PictureBox1.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox1.Image = ImageList2.Images.Item(0)
                    End If
                End If
                pos += 1
            Next
        ElseIf dir = "D" Then
            Dim pos As Integer = 0
            Dim lon = entrada.Length - cont
            If lon > 5 Then
                lon = 5
            End If
            For i As Integer = cont To lon + cont - 1
                If pos = 0 Then
                    If entrada(i) = "1" Then
                        PictureBox5.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
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
                    If entrada(i) = "1" Then
                        PictureBox6.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox6.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox6.Image = Nothing
                    End If
                    PictureBox7.Image = Nothing
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 2 Then
                    If entrada(i) = "1" Then
                        PictureBox7.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox7.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox7.Image = Nothing
                    End If
                    PictureBox8.Image = Nothing
                    PictureBox9.Image = Nothing
                End If

                If pos = 3 Then
                    If entrada(i) = "1" Then
                        PictureBox8.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
                        PictureBox8.Image = ImageList2.Images.Item(0)
                    Else
                        PictureBox8.Image = Nothing
                    End If
                    PictureBox9.Image = Nothing
                End If

                If pos = 4 Then
                    If entrada(i) = "1" Then
                        PictureBox9.Image = ImageList2.Images.Item(1)
                    ElseIf entrada(i) = "0" Then
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