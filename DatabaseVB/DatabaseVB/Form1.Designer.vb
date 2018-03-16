<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnConexion = New System.Windows.Forms.Button()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.rdbAgregar = New System.Windows.Forms.RadioButton()
        Me.rdbModificar = New System.Windows.Forms.RadioButton()
        Me.rdbEliminar = New System.Windows.Forms.RadioButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConexion
        '
        Me.btnConexion.Location = New System.Drawing.Point(12, 226)
        Me.btnConexion.Name = "btnConexion"
        Me.btnConexion.Size = New System.Drawing.Size(75, 23)
        Me.btnConexion.TabIndex = 0
        Me.btnConexion.Text = "Conexion"
        Me.btnConexion.UseVisualStyleBackColor = True
        Me.btnConexion.Visible = False
        '
        'txtUsuario
        '
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Location = New System.Drawing.Point(79, 68)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuario.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Contraseña"
        '
        'txtContrasena
        '
        Me.txtContrasena.Enabled = False
        Me.txtContrasena.Location = New System.Drawing.Point(79, 94)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(100, 20)
        Me.txtContrasena.TabIndex = 3
        Me.txtContrasena.UseSystemPasswordChar = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(116, 226)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'rdbAgregar
        '
        Me.rdbAgregar.AutoSize = True
        Me.rdbAgregar.Location = New System.Drawing.Point(43, 22)
        Me.rdbAgregar.Name = "rdbAgregar"
        Me.rdbAgregar.Size = New System.Drawing.Size(62, 17)
        Me.rdbAgregar.TabIndex = 6
        Me.rdbAgregar.TabStop = True
        Me.rdbAgregar.Text = "Agregar"
        Me.rdbAgregar.UseVisualStyleBackColor = True
        '
        'rdbModificar
        '
        Me.rdbModificar.AutoSize = True
        Me.rdbModificar.Location = New System.Drawing.Point(111, 22)
        Me.rdbModificar.Name = "rdbModificar"
        Me.rdbModificar.Size = New System.Drawing.Size(68, 17)
        Me.rdbModificar.TabIndex = 7
        Me.rdbModificar.TabStop = True
        Me.rdbModificar.Text = "Modificar"
        Me.rdbModificar.UseVisualStyleBackColor = True
        '
        'rdbEliminar
        '
        Me.rdbEliminar.AutoSize = True
        Me.rdbEliminar.Location = New System.Drawing.Point(185, 22)
        Me.rdbEliminar.Name = "rdbEliminar"
        Me.rdbEliminar.Size = New System.Drawing.Size(61, 17)
        Me.rdbEliminar.TabIndex = 8
        Me.rdbEliminar.TabStop = True
        Me.rdbEliminar.Text = "Eliminar"
        Me.rdbEliminar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(197, 66)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 9
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.Enabled = False
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"administrador", "general"})
        Me.cmbTipo.Location = New System.Drawing.Point(58, 120)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipo.TabIndex = 11
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(197, 226)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.rdbEliminar)
        Me.Controls.Add(Me.rdbModificar)
        Me.Controls.Add(Me.rdbAgregar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtContrasena)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.btnConexion)
        Me.Name = "Form1"
        Me.Text = "Base datos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConexion As Button
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents rdbAgregar As RadioButton
    Friend WithEvents rdbModificar As RadioButton
    Friend WithEvents rdbEliminar As RadioButton
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents btnCancelar As Button
End Class
