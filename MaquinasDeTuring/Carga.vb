Public Class Carga
    Dim cont As Integer = 0
    Private Sub Carga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = My.Resources.Fondo1
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Main.Show()
            Timer1.Enabled = False
            Me.Close()
        Else
            ProgressBar1.Value += 2
        End If

        If ProgressBar1.Value = 50 Then
            Me.BackgroundImage = My.Resources.Fondo2
        End If

        If cont = 0 Then
            Label3.Text = "Cargando."
            If ProgressBar1.Value Mod 4 = 0 Then
                cont = 1
            End If
        ElseIf cont = 1 Then
            Label3.Text = "Cargando.."
            If ProgressBar1.Value Mod 6 = 0 Then
                cont = 2
            End If
        ElseIf cont = 2 Then
            Label3.Text = "Cargando..."
            If ProgressBar1.Value Mod 10 = 0 Then
                cont = 0
            End If
        End If
    End Sub
End Class