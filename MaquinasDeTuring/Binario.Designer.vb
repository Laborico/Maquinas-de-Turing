<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Binario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Binario))
        Me.TBEntrada = New System.Windows.Forms.TextBox()
        Me.TBRes = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BTNsgp = New System.Windows.Forms.Button()
        Me.BtnRapido = New System.Windows.Forms.Button()
        Me.BtnLento = New System.Windows.Forms.Button()
        Me.PBEstados = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Cabezal = New System.Windows.Forms.PictureBox()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LAnt = New System.Windows.Forms.Label()
        Me.LAct = New System.Windows.Forms.Label()
        Me.Salir = New System.Windows.Forms.Button()
        CType(Me.PBEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cabezal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TBEntrada
        '
        Me.TBEntrada.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBEntrada.Location = New System.Drawing.Point(29, 367)
        Me.TBEntrada.Name = "TBEntrada"
        Me.TBEntrada.Size = New System.Drawing.Size(315, 25)
        Me.TBEntrada.TabIndex = 0
        '
        'TBRes
        '
        Me.TBRes.Enabled = False
        Me.TBRes.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBRes.Location = New System.Drawing.Point(29, 496)
        Me.TBRes.Name = "TBRes"
        Me.TBRes.Size = New System.Drawing.Size(315, 25)
        Me.TBRes.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(142, 423)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Listo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(25, 395)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Texto Invalido"
        Me.Label1.Visible = False
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(99, 548)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(161, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Reiniciar Maquina"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BTNsgp
        '
        Me.BTNsgp.Enabled = False
        Me.BTNsgp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNsgp.Location = New System.Drawing.Point(430, 367)
        Me.BTNsgp.Name = "BTNsgp"
        Me.BTNsgp.Size = New System.Drawing.Size(116, 25)
        Me.BTNsgp.TabIndex = 5
        Me.BTNsgp.Text = "Siguiente Paso"
        Me.BTNsgp.UseVisualStyleBackColor = True
        '
        'BtnRapido
        '
        Me.BtnRapido.Enabled = False
        Me.BtnRapido.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRapido.Location = New System.Drawing.Point(430, 535)
        Me.BtnRapido.Name = "BtnRapido"
        Me.BtnRapido.Size = New System.Drawing.Size(116, 27)
        Me.BtnRapido.TabIndex = 8
        Me.BtnRapido.Text = "Rapido"
        Me.BtnRapido.UseVisualStyleBackColor = True
        '
        'BtnLento
        '
        Me.BtnLento.Enabled = False
        Me.BtnLento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLento.Location = New System.Drawing.Point(430, 496)
        Me.BtnLento.Name = "BtnLento"
        Me.BtnLento.Size = New System.Drawing.Size(116, 23)
        Me.BtnLento.TabIndex = 7
        Me.BtnLento.Text = "Lento"
        Me.BtnLento.UseVisualStyleBackColor = True
        '
        'PBEstados
        '
        Me.PBEstados.BackColor = System.Drawing.Color.Transparent
        Me.PBEstados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBEstados.Location = New System.Drawing.Point(625, 325)
        Me.PBEstados.Name = "PBEstados"
        Me.PBEstados.Size = New System.Drawing.Size(331, 268)
        Me.PBEstados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBEstados.TabIndex = 9
        Me.PBEstados.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "SB1.png")
        Me.ImageList1.Images.SetKeyName(1, "SB2.png")
        Me.ImageList1.Images.SetKeyName(2, "SB3.png")
        Me.ImageList1.Images.SetKeyName(3, "SB4.png")
        Me.ImageList1.Images.SetKeyName(4, "SB5.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(28, 65)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Location = New System.Drawing.Point(133, 65)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Location = New System.Drawing.Point(235, 65)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Location = New System.Drawing.Point(339, 65)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox4.TabIndex = 13
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Location = New System.Drawing.Point(443, 65)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox5.TabIndex = 14
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Location = New System.Drawing.Point(545, 65)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox6.TabIndex = 15
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Location = New System.Drawing.Point(649, 65)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox7.TabIndex = 16
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Location = New System.Drawing.Point(752, 65)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox8.TabIndex = 17
        Me.PictureBox8.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.Location = New System.Drawing.Point(856, 65)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox9.TabIndex = 18
        Me.PictureBox9.TabStop = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "0.png")
        Me.ImageList2.Images.SetKeyName(1, "1.png")
        '
        'Cabezal
        '
        Me.Cabezal.BackColor = System.Drawing.Color.Transparent
        Me.Cabezal.Location = New System.Drawing.Point(443, 172)
        Me.Cabezal.Name = "Cabezal"
        Me.Cabezal.Size = New System.Drawing.Size(96, 135)
        Me.Cabezal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cabezal.TabIndex = 19
        Me.Cabezal.TabStop = False
        Me.Cabezal.Visible = False
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "cabezal1.png")
        Me.ImageList3.Images.SetKeyName(1, "CabezalD.png")
        Me.ImageList3.Images.SetKeyName(2, "CabezalI.png")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(742, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 21)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Estado Actual:"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(728, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 21)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Estado Anterior:"
        Me.Label3.Visible = False
        '
        'LAnt
        '
        Me.LAnt.AutoSize = True
        Me.LAnt.BackColor = System.Drawing.Color.Transparent
        Me.LAnt.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LAnt.ForeColor = System.Drawing.Color.White
        Me.LAnt.Location = New System.Drawing.Point(852, 189)
        Me.LAnt.Name = "LAnt"
        Me.LAnt.Size = New System.Drawing.Size(42, 21)
        Me.LAnt.TabIndex = 22
        Me.LAnt.Text = "1s1s"
        Me.LAnt.Visible = False
        '
        'LAct
        '
        Me.LAct.AutoSize = True
        Me.LAct.BackColor = System.Drawing.Color.Transparent
        Me.LAct.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LAct.ForeColor = System.Drawing.Color.White
        Me.LAct.Location = New System.Drawing.Point(852, 261)
        Me.LAct.Name = "LAct"
        Me.LAct.Size = New System.Drawing.Size(42, 21)
        Me.LAct.TabIndex = 23
        Me.LAct.Text = "1s1s"
        Me.LAct.Visible = False
        '
        'Salir
        '
        Me.Salir.Location = New System.Drawing.Point(386, 629)
        Me.Salir.Name = "Salir"
        Me.Salir.Size = New System.Drawing.Size(221, 23)
        Me.Salir.TabIndex = 24
        Me.Salir.Text = "Menu"
        Me.Salir.UseVisualStyleBackColor = True
        '
        'Binario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MaquinasDeTuring.My.Resources.Resources.MTfondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(984, 681)
        Me.Controls.Add(Me.Salir)
        Me.Controls.Add(Me.LAct)
        Me.Controls.Add(Me.LAnt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cabezal)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PBEstados)
        Me.Controls.Add(Me.BtnRapido)
        Me.Controls.Add(Me.BtnLento)
        Me.Controls.Add(Me.BTNsgp)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TBRes)
        Me.Controls.Add(Me.TBEntrada)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Binario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sucesor Binario"
        CType(Me.PBEstados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cabezal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TBEntrada As System.Windows.Forms.TextBox
    Friend WithEvents TBRes As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BTNsgp As System.Windows.Forms.Button
    Friend WithEvents BtnRapido As System.Windows.Forms.Button
    Friend WithEvents BtnLento As System.Windows.Forms.Button
    Friend WithEvents PBEstados As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Cabezal As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LAnt As System.Windows.Forms.Label
    Friend WithEvents LAct As System.Windows.Forms.Label
    Friend WithEvents Salir As System.Windows.Forms.Button
End Class
