Public Class Pruebas
    Dim em = "S1"
    Dim cont = 1
    Dim entrada As String
    Dim res As String
    Private Sub Pruebas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub s1()
        Application.DoEvents()
        Threading.Thread.Sleep(900)
        Application.DoEvents()
        If res(cont) = "X" Then
            cont += -1
            em = "S1"
            ListBox1.Items.Add(res + " " + Str(cont))
            s1()
        ElseIf res(cont) = "1" Then
            res = res.Substring(0, cont) + "X" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            cont += 1
            em = "S2"
            ListBox1.Items.Add(res + " " + Str(cont))
            s2()
        ElseIf res(cont) = " " Then
            em = "S3"
            cont += 1
            s3()
        End If
    End Sub

    Sub s2()
        Application.DoEvents()
        Threading.Thread.Sleep(900)
        Application.DoEvents()
        If res(cont) = "1" Then
            cont += 1
            em = "S2"
            ListBox1.Items.Add(res + " " + Str(cont))
            s2()
        ElseIf res(cont) = "X" Then
            cont += 1
            em = "S2"
            ListBox1.Items.Add(res + " " + Str(cont))
            s2()
        ElseIf res(cont) = " " Then
            res = res.Substring(0, cont) + "X" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            cont -= 1
            em = "S1"
            s1()
        End If
    End Sub

    Sub s3()
        Application.DoEvents()
        Threading.Thread.Sleep(900)
        Application.DoEvents()
        If res(cont) = "X" Then
            res = res.Substring(0, cont) + "1" + res.Substring(cont + 1, res.Length - cont - 1) + " "
            cont += 1
            em = "S3"
            ListBox1.Items.Add(res + " " + Str(cont))
            s3()
        ElseIf res(cont) = " " Then
            em = "S4"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        entrada = " " + TextBox1.Text + " "
        res = entrada
        s1()
        TBRes.Text = res
    End Sub

End Class