Imports System
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.Web
Imports System.Drawing
Imports System.Threading.Tasks

Public Class Main

    Private placa1 As IntPtr = IntPtr.Zero

    Dim contador_lecturas As Integer

    <DllImport("C:\WINDOWS\system32\plcommpro.dll", EntryPoint:="Connect")>
    Public Shared Function Conectar(ByVal parametros As String) As IntPtr

    End Function

    <DllImport("plcommpro.dll", EntryPoint:="Disconnect")>
    Public Shared Sub Desconectar(ByVal h As IntPtr)

    End Sub

    <DllImport("plcommpro.dll", EntryPoint:="GetRTLog")>
    Public Shared Function GetRTLog(ByVal h As IntPtr, ByRef buffer As Byte, ByVal buffersize As Integer) As Integer
    End Function

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'SET TITULO
        Me.Text = "Lector de Tarjetas"

        'LEO Y SETEO VERSION DE LA API
        tt_versionapi.Text = Application.ProductVersion.Substring(0, 5)

        'TEXTO TIMER RESET
        tsEstadoConexion.Text = "DESCONECTADO"

    End Sub

    Private Async Sub CmdConectar_Click(sender As Object, e As EventArgs) Handles cmdConectar.Click

        'PLACA 1

        If txtipdestino.Text = "" Then

        Else

            Dim ipDestino As String = Trim(txtipdestino.Text)

            Dim cadenaConex As String = "protocol=TCP,ipaddress=" & ipDestino & ",port=4370,timeout=2000,passwd="

            Cursor = Cursors.WaitCursor

            If IntPtr.Zero = placa1 Then

                t_placa1.Enabled = True 'START AL TIMER TICK

                placa1 = Conectar(cadenaConex)
                Cursor = Cursors.[Default]
                cmdDesconectar.Enabled = True
                    cmdConectar.Enabled = False
                    tsEstadoConexion.Text = "CONECTADO"
                    tsEstadoConexion.ForeColor = Color.DarkGreen
                Else
                    tsEstadoConexion.Text = "ERROR DE CONEXION"
                    tsEstadoConexion.ForeColor = Color.Red
                    Await BlinkText()

            End If

        End If

    End Sub

    Private Sub CmdDesconectar_Click(sender As Object, e As EventArgs) Handles cmdDesconectar.Click


        'CONEX PLACA 1
        If IntPtr.Zero <> placa1 Then
            Desconectar(placa1)
            placa1 = IntPtr.Zero
            t_placa1.Enabled = False 'STOP AL TIMER TICK
            cmdDesconectar.Enabled = False
            cmdConectar.Enabled = True
            tsEstadoConexion.Text = "DESCONECTADO"
        End If

    End Sub

    Private Sub CmdLimpioLista_Click(sender As Object, e As EventArgs) Handles cmdLimpioLista.Click

        'LIMPIO EL DATAGRID
        Me.list_registros.Items.Clear()

        'REINICIO EL CONTADOR
        contador_lecturas = 0
        txttotallecturas.Text = "0"

    End Sub

    Private Sub Placa1_tick(sender As Object, e As EventArgs) Handles t_placa1.Tick
        Dim buffersize As Integer = 256
        Dim buffer As Byte() = New Byte(255) {}
        Dim i As Integer = Me.list_registros.Items.Count

        If IntPtr.Zero <> placa1 Then

            Dim ret As Integer = GetRTLog(placa1, buffer(0), buffersize)

            If ret >= 0 Then
                Dim str As String = Encoding.[Default].GetString(buffer)
                Dim tmp As String() = str.Split(","c)

                Dim tipo_movi As String = tmp(4).ToString

                If tipo_movi <> "255" Then

                    Dim fechayhora, nrotarjeta, nrolector_inicial, nrolector_final, placa As String

                    fechayhora = tmp(0).ToString 'FECHA Y HORA DE LA LECTURA
                    nrotarjeta = tmp(2).ToString 'NRO DE LA TARJETA
                    nrolector_inicial = tmp(3).ToString 'LECTOR


                    'RENOMBRO PLACAS

                    Dim lector As Integer = CInt(nrolector_inicial)

                    Select Case lector

                        Case 1 'INGRESO PEATONAL

                            placa = 1
                            nrolector_final = 1

                        Case 2 'EGRESO PEATONAL

                            placa = 1
                            nrolector_final = 2

                        Case 3 'INGRESO VEHICULOS LIVIANOS

                            placa = 2
                            nrolector_final = 1

                        Case 4 'EGRESO VEHICULOS LIVIANOS

                            placa = 2
                            nrolector_final = 2

                    End Select

                    'END RENOMBRO PLACAS


                    'FACILITY CODE

                    Dim nro_leido As Integer = tmp(2)
                    Dim nro_final As String = Binario(nro_leido)
                    Dim facilitycode As String = nro_final.Substring(0, 8)
                    Dim adecimal1 As Integer = ADecimal(facilitycode)

                    'END FACILITY CODE


                    'NRO TARJETA

                    Dim subnrotarjeta As String = nro_final.Substring(8)
                    Dim adecimal2 As Integer = ADecimal(subnrotarjeta)

                    Dim largo As Integer = CStr(adecimal2).Length
                    Dim intermedio As String = CStr(adecimal2)
                    Dim cuenta As Integer = 5 - largo

                    Do While cuenta > 0

                        intermedio = "0" + intermedio
                        cuenta -= 1

                    Loop

                    Dim nro_tarjeta As String = adecimal1.ToString + intermedio.ToString

                    'END TARJETA


                    'ENVIO A FRANCIA

                    Dim let_fecha As Date = CDate(fechayhora)
                    Dim let_placa As Integer = CInt(placa)
                    Dim let_barrera As Integer = CInt(nrolector_final)
                    Dim let_tarje As String = nro_tarjeta

                    Dim envio_datos As String = EnvioDatos(let_fecha, let_placa, let_barrera, let_tarje)

                    'FIN ENVIO A FRANCIA


                    'AGREGO AL CUADRO
                    Me.list_registros.Items.Add(tmp(0)) 'FECHA Y HORA
                    Me.list_registros.Items(i).SubItems.Add(nro_tarjeta) 'NRO DE TARJETA

                    Select Case tmp(3)

                        Case 1
                            Me.list_registros.Items(i).SubItems.Add("INGRESO PEATONAL") 'LECTOR
                        Case 2
                            Me.list_registros.Items(i).SubItems.Add("EGRESO PEATONAL") 'LECTOR
                        Case 3
                            Me.list_registros.Items(i).SubItems.Add("INGRESO VEHICULAR") 'LECTOR
                        Case 4
                            Me.list_registros.Items(i).SubItems.Add("EGRESO VEHICULAR") 'LECTOR

                    End Select

                    'contador
                    contador_lecturas += 1
                    txttotallecturas.Text = contador_lecturas.ToString

                    'FIN AGREGO AL CUADRO

                End If

            End If

        Else

            Return
            End

        End If

    End Sub

    Public Function EnvioDatos(ByVal fecha As Date, ByVal placa As Integer, ByVal barrera As Integer, ByVal tarjeta As String)

        Try

            'VARIABLES
            Dim url As String = "https://concesionaria.bazflp.com/api/socket.io/tarjProd.php"
            Dim metodo As String = "POST"
            Dim let_fecha As String = CDate(fecha).ToShortDateString
            Dim let_placa As String = CStr(CInt(placa))
            Dim let_barrera As String = barrera
            Dim let_tarje As String = tarjeta.ToString
            Dim pwd As String = "DcNrimAxvKKX8Th1sdX0xjZVxBZDqUW9TDpSi3p301u062LIUkiTCAH1OlHNhxhLiCb6xPmPLC7oSpsZthrJSotyw2MbbpXu1"

            'METODO
            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(url)
            request.Method = metodo

            'DATOS
            Dim postData As String = "let_fecha=" + let_fecha + "&let_placa=" + let_placa + "&let_barrera=" + let_barrera + "&let_tarje=" + let_tarje + "&pwd=" + pwd + ""

            'CODIFICACION
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()

            'RESPUESTA
            Dim respuesta As WebResponse = request.GetResponse()
            dataStream = respuesta.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            respuesta.Close()
            Return (responseFromServer)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Function

    Function Binario(ByVal valor As Integer) As String

        Dim mayor As Integer
        Dim retorno As String
        Dim a As Integer

        'Busca el mayor exponente
        mayor = 0
        Do While True
            If 2 ^ mayor > valor Then
                If mayor > 0 Then
                    mayor -= 1
                End If
                Exit Do
            End If
            mayor += 1
        Loop

        'Calculo del valor binario
        retorno = ""
        For a = mayor To 0 Step -1
            If valor < (2 ^ a) Then
                retorno &= "0"
            Else
                retorno &= "1"
                valor -= (2 ^ a)
            End If
        Next a

        Dim largo As Integer = retorno.Length
        Dim cuenta As Integer = 24 - largo

        Do While cuenta > 0

            retorno = "0" + retorno
            cuenta -= 1

        Loop

        'Pasa el valor como resultado de la función
        Binario = retorno

    End Function

    Function ADecimal(ByVal valor As String) As Integer

        valor = StrReverse(valor)
        Dim largo As Integer = Len(valor)
        Dim x, suma As Integer

        For I = 1 To largo
            x = 2 ^ (I - 1)
            suma += (Int(Mid$(valor, I, 1)) * x)
        Next I
        Return suma

    End Function

    Async Function BlinkText() As Task

        For i = 0 To 10
            Await Task.Delay(500)
            tsEstadoConexion.Visible = Not tsEstadoConexion.Visible
        Next

        tsEstadoConexion.Visible = True

    End Function

End Class



