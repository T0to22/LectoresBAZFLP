<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtipdestino = New System.Windows.Forms.TextBox()
        Me.cmdDesconectar = New System.Windows.Forms.Button()
        Me.cmdConectar = New System.Windows.Forms.Button()
        Me.t_placa1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdLimpioLista = New System.Windows.Forms.Button()
        Me.list_registros = New System.Windows.Forms.ListView()
        Me.fechayhora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nrotarjeta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nrolector = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txttotallecturas = New System.Windows.Forms.TextBox()
        Me.ss_status = New System.Windows.Forms.StatusStrip()
        Me.tt_versionapi = New System.Windows.Forms.ToolStripStatusLabel()
        Me.t_reset = New System.Windows.Forms.Timer(Me.components)
        Me.lblIPDestino = New System.Windows.Forms.Label()
        Me.tsEstadoConexion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.groupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ss_status.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.lblIPDestino)
        Me.groupBox1.Controls.Add(Me.txtipdestino)
        Me.groupBox1.Controls.Add(Me.cmdDesconectar)
        Me.groupBox1.Controls.Add(Me.cmdConectar)
        resources.ApplyResources(Me.groupBox1, "groupBox1")
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.TabStop = False
        '
        'txtipdestino
        '
        resources.ApplyResources(Me.txtipdestino, "txtipdestino")
        Me.txtipdestino.Name = "txtipdestino"
        '
        'cmdDesconectar
        '
        resources.ApplyResources(Me.cmdDesconectar, "cmdDesconectar")
        Me.cmdDesconectar.Name = "cmdDesconectar"
        Me.cmdDesconectar.UseVisualStyleBackColor = True
        '
        'cmdConectar
        '
        resources.ApplyResources(Me.cmdConectar, "cmdConectar")
        Me.cmdConectar.Name = "cmdConectar"
        Me.cmdConectar.UseVisualStyleBackColor = True
        '
        't_placa1
        '
        Me.t_placa1.Interval = 50
        '
        'cmdLimpioLista
        '
        resources.ApplyResources(Me.cmdLimpioLista, "cmdLimpioLista")
        Me.cmdLimpioLista.Name = "cmdLimpioLista"
        Me.cmdLimpioLista.UseVisualStyleBackColor = True
        '
        'list_registros
        '
        Me.list_registros.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.fechayhora, Me.nrotarjeta, Me.nrolector})
        Me.list_registros.GridLines = True
        Me.list_registros.HideSelection = False
        resources.ApplyResources(Me.list_registros, "list_registros")
        Me.list_registros.Name = "list_registros"
        Me.list_registros.UseCompatibleStateImageBehavior = False
        Me.list_registros.View = System.Windows.Forms.View.Details
        '
        'fechayhora
        '
        resources.ApplyResources(Me.fechayhora, "fechayhora")
        '
        'nrotarjeta
        '
        resources.ApplyResources(Me.nrotarjeta, "nrotarjeta")
        '
        'nrolector
        '
        resources.ApplyResources(Me.nrolector, "nrolector")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txttotallecturas)
        Me.GroupBox2.Controls.Add(Me.list_registros)
        Me.GroupBox2.Controls.Add(Me.cmdLimpioLista)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txttotallecturas
        '
        resources.ApplyResources(Me.txttotallecturas, "txttotallecturas")
        Me.txttotallecturas.Name = "txttotallecturas"
        Me.txttotallecturas.ReadOnly = True
        '
        'ss_status
        '
        Me.ss_status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tt_versionapi, Me.tsEstadoConexion})
        resources.ApplyResources(Me.ss_status, "ss_status")
        Me.ss_status.Name = "ss_status"
        '
        'tt_versionapi
        '
        Me.tt_versionapi.Name = "tt_versionapi"
        resources.ApplyResources(Me.tt_versionapi, "tt_versionapi")
        '
        't_reset
        '
        Me.t_reset.Interval = 300000
        '
        'lblIPDestino
        '
        resources.ApplyResources(Me.lblIPDestino, "lblIPDestino")
        Me.lblIPDestino.Name = "lblIPDestino"
        '
        'tsEstadoConexion
        '
        resources.ApplyResources(Me.tsEstadoConexion, "tsEstadoConexion")
        Me.tsEstadoConexion.Name = "tsEstadoConexion"
        Me.tsEstadoConexion.Spring = True
        '
        'Main
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ss_status)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ss_status.ResumeLayout(False)
        Me.ss_status.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents cmdDesconectar As System.Windows.Forms.Button
    Private WithEvents cmdConectar As System.Windows.Forms.Button
    Private WithEvents t_placa1 As System.Windows.Forms.Timer
    Private WithEvents cmdLimpioLista As System.Windows.Forms.Button
    Private WithEvents list_registros As System.Windows.Forms.ListView
    Private WithEvents fechayhora As System.Windows.Forms.ColumnHeader
    Private WithEvents nrotarjeta As System.Windows.Forms.ColumnHeader
    Private WithEvents nrolector As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtipdestino As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttotallecturas As System.Windows.Forms.TextBox
    Friend WithEvents ss_status As System.Windows.Forms.StatusStrip
    Friend WithEvents tt_versionapi As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblIPDestino As Label
    Friend WithEvents tsEstadoConexion As ToolStripStatusLabel
    Friend WithEvents t_reset As Timer
End Class
