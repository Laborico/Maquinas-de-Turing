Public Class SucesorBinario
    Dim res As String = ""
    Dim entrada As String
    Dim cont = 0
    Dim em As String = "S1"
    Dim esp As Boolean
    Dim historial As New List(Of String)

    Private Sub SucesorBinario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        If Not System.Text.RegularExpressions.Regex.IsMatch(TBEntrada.Text, "^[0-1]+$") Then
            Label1.Visible = True
            Button1.Enabled = False
        End If
        PBEstados.Image = ImageList1.Images.Item(0)
        ListBox1.Visible = False
        Me.BackgroundImage = My.Resources.MTfondo1
        LAnt.Text = ""
        LAct.Text = "S1"
    End Sub

    Private Sub TBEntrada_TextChanged(sender As Object, e As EventArgs) Handles TBEntrada.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(TBEntrada.Text, "^[0-1]+$") Then
            Label1.Visible = True
            Button1.Enabled = False
        Else
            Label1.Visible = False
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        entrada = TBEntrada.Text + " "
        res = " "
        BtnLento.Enabled = True
        BtnRapido.Enabled = True
        BTNsgp.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = True
        PBEstados.Image = ImageList1.Images.Item(1)
        My.Computer.Audio.Play(My.Resources.Inicio, AudioPlayMode.WaitToComplete)
        Label2.Visible = True
        Label3.Visible = True
        LAnt.Visible = True
        LAct.Visible = True
        ListBox1.Visible = True
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
        End While
        PBEstados.Image = ImageList1.Images.Item(4)
        My.Computer.Audio.Play(My.Resources.Fin, AudioPlayMode.Background)
        Salir.Enabled = True
        LAct.Text = "S4"
        TBRes.Text = res
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
        TBRes.Text = res
    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        My.Computer.Audio.Stop()
        Main.Show()
        Me.Close()
    End Sub

    Sub s1()
        If entrada(cont) = "1" Then
            res += "1"
            cont += 1
            em = "S1"
            ListBox1.Items.Add("Estas en S1 recibes un 1 y se cambia por un 1.Pasas a S1 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la derecha.")
            s1()
        ElseIf entrada(cont) = "0" Then
            res += "0"
            cont += 1
            em = "S1"
            ListBox1.Items.Add("Estas en S1 recibes un 0 y se cambia por un 0.Pasas a S1 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la derecha.")
            s1()
        ElseIf entrada(cont) = " " Then
            em = "S2"
            ListBox1.Items.Add("Estas en S1 recibes un b y se cambia por un b.Pasas a S2 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            s2()
        End If
    End Sub

    Sub s2()
        If res(cont) = "1" Then
            res = res.Substring(0, cont) + "0" + res.Substring(cont + 1, res.Length - cont - 1)
            cont -= 1
            em = "S2"
            ListBox1.Items.Add("Estas en S2 recibes un 1 y se cambia por un 0.Pasas a S2 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            s2()
        ElseIf res(cont) = "0" Then
            res = res.Substring(0, cont) + "1" + res.Substring(cont + 1, res.Length - cont - 1)
            cont -= 1
            em = "S3"
            ListBox1.Items.Add("Estas en S2 recibes un 0 y se cambia por un 1.Pasas a S3 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            s3()
        ElseIf res(cont) = " " Then
            res = res.Substring(0, cont) + "1" + res.Substring(cont + 1, res.Length - cont - 1)
            cont += 1
            ListBox1.Items.Add("Estas en S2 recibes un b y se cambia por un 1.Pasas a S4 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la derecha.")
        End If
    End Sub

    Sub s3()
        If res(cont) = "0" Then
            cont -= 1
            em = "S3"
            ListBox1.Items.Add("Estas en S3 recibes un 0 y se cambia por un 0.Pasas a S3 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            s3()
        ElseIf res(cont) = "1" Then
            cont -= 1
            em = "S3"
            ListBox1.Items.Add("Estas en S3 recibes un 1 y se cambia por un 1.Pasas a S3 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            s3()
        ElseIf res(cont) = " " Then
            cont += 1
            ListBox1.Items.Add("Estas en S3 recibes un b y se cambia por un b.Pasas a S4 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la derecha.")
        End If
    End Sub

    Sub ms1()
        If entrada(cont) = "1" Then
            res += "1"
            cont += 1
            ListBox1.Items.Add("Estas en S1 recibes un 1 y se cambia por un 1.Pasas a S1 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la derecha.")
            LAnt.Text = em
            em = "S1"
            LAct.Text = em
            historial.Add(em)
            TBRes.Text = res
        ElseIf entrada(cont) = "0" Then
            res += "0"
            cont += 1
            ListBox1.Items.Add("Estas en S1 recibes un 0 y se cambia por un 0.Pasas a S1 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la derecha.")
            LAnt.Text = em
            em = "S1"
            LAct.Text = em
            historial.Add(em)
            TBRes.Text = res
        ElseIf entrada(cont) = " " Then
            ListBox1.Items.Add("Estas en S1 recibes un b y se cambia por un b.Pasas a S2 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
            historial.Add(em)
            TBRes.Text = res
        End If
    End Sub

    Sub ms2()
        If res(cont) = "1" Then
            res = res.Substring(0, cont) + "0" + res.Substring(cont + 1, res.Length - cont - 1)
            cont -= 1
            ListBox1.Items.Add("Estas en S2 recibes un 1 y se cambia por un 0.Pasas a S2 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            TBRes.Text = res
            LAnt.Text = em
            em = "S2"
            LAct.Text = em
        ElseIf res(cont) = "0" Then
            res = res.Substring(0, cont) + "1" + res.Substring(cont + 1, res.Length - cont - 1)
            cont -= 1
            ListBox1.Items.Add("Estas en S2 recibes un 0 y se cambia por un 1.Pasas a S3 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            TBRes.Text = res
            LAnt.Text = em
            em = "S3"
            LAct.Text = em
        ElseIf res(cont) = " " Then
            res = res.Substring(0, cont) + "1" + res.Substring(cont + 1, res.Length - cont - 1)
            cont += 1
            em = "S4"
            ListBox1.Items.Add("Estas en S2 recibes un b y se cambia por un 1.Pasas a S4 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la derecha.")
            TBRes.Text = res
        End If
    End Sub

    Sub ms3()
        If res(cont) = "0" Then
            cont -= 1
            ListBox1.Items.Add("Estas en S3 recibes un 0 y se cambia por un 0.Pasas a S3 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            LAnt.Text = em
            em = "S3"
            LAct.Text = em
        ElseIf res(cont) = "1" Then
            cont -= 1
            ListBox1.Items.Add("Estas en S3 recibes un 1 y se cambia por un 1.Pasas a S3 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la izquierda.")
            LAnt.Text = em
            em = "S3"
            LAct.Text = em
        ElseIf res(cont) = " " Then
            cont += 1
            em = "S4"
            ListBox1.Items.Add("Estas en S3 recibes un b y se cambia por un b.Pasas a S4 resultado: " + res)
            ListBox1.Items.Add("El cabezal se mueve a la derecha.")
            TBRes.Text = res
        End If
    End Sub

    Sub Reiniciar()
        ListBox1.Items.Clear()
        ListBox1.Visible = False
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

End Class