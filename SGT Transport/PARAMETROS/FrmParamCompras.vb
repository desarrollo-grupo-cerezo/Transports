Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmParamCompras
    Private Sub FrmParamCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Me.WindowState = FormWindowState.Maximized
        Dim SERIE_COMPRA_OT As String = "", SERIE_RECEPCION_OT As String = "", SERIE_ORDEN_COMPRA_OT As String = "", SERIE_COMPRA_OTEXT As String = ""
        Dim SERIE_RECEPCION_OTEXT As String = "", SERIE_ORDEN_COMPRA_OTEXT As String = "", SERIE_RECEPCION As String = "", SERIE_ORDEN_COMPRA As String = ""
        Dim ALM_COTI As Integer, ALM_ROTI As Integer, ALM_OOTI As Integer, ALM_COTE As Integer, ALM_ROTE As Integer, ALM_OOTE As Integer
        Dim SERIE_COMPRA As String = "", SERIE_COMPRA_DEV As String = "", SERIE_COMP_CONCI_VAL_DIESEL As String = "", SERIE_GASTOS As String = ""
        Dim SERIE_PRE_OC As String = "", SERIE_OC_DESDE_PRE_OC As String = ""
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            C1DockingTab1.SelectedIndex = 0

            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA, LOWER(TIP_DOC) AS T_DOC
                FROM FOLIOSC" & Empresa
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            CboSerieRecepcionOT.Items.Clear()
            Do While dr.Read
                If dr("T_DOC") = "c" Then
                    CboSerieCompraOT.Items.Add(dr("LETRA"))
                    CboSerieCompraOTEXT.Items.Add(dr("LETRA"))
                    CboSerieCompra.Items.Add(dr("LETRA"))
                    CboSerieComConciVesDie.Items.Add(dr("LETRA"))
                End If
                If dr("T_DOC") = "r" Then CboSerieRecepcionOT.Items.Add(dr("LETRA"))
                If dr("T_DOC") = "r" Then CboSerieRecepcionOTEXT.Items.Add(dr("LETRA"))
                If dr("T_DOC") = "o" Then CboSerieOrdenCompraOT.Items.Add(dr("LETRA"))
                If dr("T_DOC") = "o" Then CboSerieOrdenCompraOTEXT.Items.Add(dr("LETRA"))
                If dr("T_DOC") = "d" Then CboSerieCompraDev.Items.Add(dr("LETRA"))
                If dr("T_DOC") = "g" Then CboSerieGastos.Items.Add(dr("LETRA"))
                If dr("T_DOC") = "p" Then CboSeriePreOC.Items.Add(dr("LETRA"))
                If dr("T_DOC") = "o" Then CboSerieOcDesdePreOC.Items.Add(dr("LETRA"))

            Loop
            dr.Close()

            Try
                cmd.Connection = cnSAE
                SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                Do While dr.Read
                    CboAlmCOTI.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                    CboAlmROTI.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                    CboAlmOOTI.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))

                    CboAlmCOTE.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                    CboAlmROTE.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                    CboAlmOOTE.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                Loop
                dr.Close()
            Catch ex As Exception
                Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            CboAlmCOTI.SelectedIndex = 0
            CboAlmROTI.SelectedIndex = 0
            CboAlmOOTI.SelectedIndex = 0

            CboAlmCOTE.SelectedIndex = 0
            CboAlmROTE.SelectedIndex = 0
            CboAlmOOTE.SelectedIndex = 0

            CboModuloCompra.Items.Add("Compras por defecto")
            CboModuloCompra.Items.Add("ComprasAP")
            CboModuloCompra.SelectedIndex = 0

        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(CAPTURA_PAGO_COMPRAS,0) AS C_PAGO_COMPRAS, ISNULL(C_ALTA_PROVEEDORES,0) AS ALTA_PROVEEDORES, 
                ISNULL(C_ALTA_PRODUCTOS,0) AS ALTA_PRODUCTOS, ISNULL(OBSER_X_DOCUMENTO, 0) AS OBSER_X_DOC, ISNULL(OBSER_X_PARTIDA, 0) AS OBSER_X_PAR, 
                ISNULL(INDIRECTOS_X_PARTIDA, 0) AS IND_X_PAR, ISNULL(IMPUESTOS, 0) AS C_IMPUESTOS, ISNULL(ALMACEN, 0) AS C_ALMACEN, 
                ISNULL(SERIE_COMPRA,'') AS S_COMPRA, ISNULL(SERIE_COMPRA_DEV,'') AS S_COMPRA_DEV, ISNULL(SERIE_ORDEN_COMPRA,'') AS S_ORDEN_COMPRA, 
                ISNULL(SERIE_RECEPCION,'') AS S_RECEPCION, ISNULL(SERIE_COMPRA_OT,'') AS S_COMPRA_OT, ISNULL(SERIE_ORDEN_COMPRA_OT,'') AS S_ORDEN_COMPRA_OT, 
                ISNULL(SERIE_RECEPCION_OT,'') AS S_RECEPCION_OT, ISNULL(SERIE_COMPRA_OTEXT,'') AS S_COMPRA_OTEXT, 
                ISNULL(SERIE_ORDEN_COMPRA_OTEXT,'') AS S_ORDEN_COMPRA_OTEXT, ISNULL(SERIE_RECEPCION_OTEXT,'') AS S_RECEPCION_OTEXT, ALM_COTI, ALM_ROTI, 
                ALM_OOTI, ALM_COTE, ALM_ROTE, ALM_OOTE, FTO_COMP, FTO_ODEC, FTO_RECE, FTO_REQU, FTO_DEVO, SEL_FTO, SERIE_COMP_CONCI_VAL_DIESEL,
                ISNULL(SERIE_GASTO,'') AS SERIE_G, ISNULL(SERIE_PRE_OC,'') AS SER_PRE_OC, ISNULL(SERIE_OC_DESDE_PRE_OC,'') AS SER_OC_DESDE_PRE_OC,
                ISNULL(MODULO_COMPRAS,0) AS MOD_COMPRA
                FROM GCPARAMCOMPRAS"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Try
                    TFTO_COMP.Text = dr("FTO_COMP")
                    TFTO_ODEC.Text = dr("FTO_COMP")
                    TFTO_RECE.Text = dr("FTO_COMP")
                    TFTO_REQU.Text = dr("FTO_COMP")
                    TFTO_DEVO.Text = dr("FTO_COMP")
                    If dr("SEL_FTO") = 1 Then
                        CHSEL_FTO.Checked = True
                    Else
                        CHSEL_FTO.Checked = False
                    End If

                    CboModuloCompra.SelectedIndex = dr.ReadNullAsEmptyInteger("MOD_COMPRA")
                Catch ex As Exception
                    Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                ChCAPTURA_PAGO_COMPRAS.Value = dr("C_PAGO_COMPRAS")
                ChALTA_PROVEEDORES.Value = dr("ALTA_PROVEEDORES")
                ChALTA_PRODUCTOS.Value = dr("ALTA_PRODUCTOS")
                ChOBSER_X_PARTIDA.Value = dr("OBSER_X_PAR")
                ChOBSER_X_DOC.Value = dr("OBSER_X_DOC")
                ChINDIRECTOS_X_PARTIDA.Value = dr("IND_X_PAR")
                ChIMPUESTOS.Value = dr("C_IMPUESTOS")
                ChALMACEN.Value = dr("C_ALMACEN")

                SERIE_RECEPCION = dr("S_RECEPCION")
                SERIE_ORDEN_COMPRA = dr("S_ORDEN_COMPRA")
                SERIE_COMPRA = dr("S_COMPRA")
                SERIE_GASTOS = dr("SERIE_G")
                SERIE_COMPRA_DEV = dr("S_COMPRA_DEV")

                SERIE_RECEPCION_OT = dr("S_RECEPCION_OT")
                SERIE_ORDEN_COMPRA_OT = dr("S_ORDEN_COMPRA_OT")
                SERIE_COMPRA_OT = dr("S_COMPRA_OT")

                SERIE_RECEPCION_OTEXT = dr("S_RECEPCION_OTEXT")
                SERIE_ORDEN_COMPRA_OTEXT = dr("S_ORDEN_COMPRA_OTEXT")
                SERIE_COMPRA_OTEXT = dr("S_COMPRA_OTEXT")

                ALM_COTI = dr.ReadNullAsEmptyInteger("ALM_COTI")
                ALM_ROTI = dr.ReadNullAsEmptyInteger("ALM_ROTI")
                ALM_OOTI = dr.ReadNullAsEmptyInteger("ALM_OOTI")
                ALM_COTE = dr.ReadNullAsEmptyInteger("ALM_COTE")
                ALM_ROTE = dr.ReadNullAsEmptyInteger("ALM_ROTE")
                ALM_OOTE = dr.ReadNullAsEmptyInteger("ALM_OOTE")

                SERIE_COMP_CONCI_VAL_DIESEL = dr.ReadNullAsEmptyString("SERIE_COMP_CONCI_VAL_DIESEL")
                SERIE_PRE_OC = dr.ReadNullAsEmptyString("SER_PRE_OC")
                SERIE_OC_DESDE_PRE_OC = dr.ReadNullAsEmptyString("SER_OC_DESDE_PRE_OC")
            Else
                SQL = "INSERT INTO GCPARAMCOMPRAS (CAPTURA_PAGO_COMPRAS, C_ALTA_PROVEEDORES, C_ALTA_PRODUCTOS, OBSER_X_PARTIDA, INDIRECTOS_X_PARTIDA, 
                    Impuestos, ALMACEN, SERIE_COMPRA, SERIE_COMPRA_DEV, SERIE_ORDEN_COMPRA, SERIE_RECEPCION, SERIE_COMPRA_OT, SERIE_ORDEN_COMPRA_OT, 
                    SERIE_RECEPCION_OT, SERIE_COMPRA_OTEXT, SERIE_ORDEN_COMPRA_OTEXT, SERIE_RECEPCION_OTEXT, ALM_COTI, ALM_ROTI, ALM_OOTI, ALM_COTE, 
                    ALM_ROTE, ALM_OOTE, OBSER_X_DOCUMENTO, FTO_COMP, FTO_ODEC, FTO_RECE, FTO_REQU, FTO_DEVO, SEL_FTO, SERIE_COMP_CONCI_VAL_DIESEL, 
                    SERIE_REMISION, AFEC_TABLA_INVE, SERIE_PEDIDOS, SERIE_GASTO, SERIE_PRE_OC, IMPUESTOS, SERIE_OC_DESDE_PRE_OC) VALUES
                    (0, 0, 0, 0, 0, 0, 0, ' ', '  ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 1, 1, 1, 1, 1, 1, CONVERT(bit, 'False'), 
                    ' ', ' ', ' ', ' ', ' ', 0, 0, ' ', 9, ' ', ' ', ' ', NULL, ' ')"
                EXECUTE_QUERY_NET(SQL)

            End If
            dr.Close()

            If SERIE_PRE_OC.Trim.Length > 0 Then
                For k = 0 To CboSeriePreOC.Items.Count - 1
                    If CboSeriePreOC.Items(k) = SERIE_PRE_OC Then
                        CboSeriePreOC.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If

            For k = 0 To CboSerieOcDesdePreOC.Items.Count - 1
                If CboSerieOcDesdePreOC.Items(k) = SERIE_OC_DESDE_PRE_OC Then
                    CboSerieOcDesdePreOC.SelectedIndex = k
                    Exit For
                End If
            Next

            For k = 0 To CboAlmCOTI.Items.Count - 1
                If Val(CboAlmCOTI.Items(k).ToString.Substring(0, 2)) = ALM_COTI Then
                    CboAlmCOTI.SelectedIndex = k
                    Exit For
                End If
            Next
            For k = 0 To CboAlmROTI.Items.Count - 1
                If Val(CboAlmROTI.Items(k).ToString.Substring(0, 2)) = ALM_ROTI Then
                    CboAlmROTI.SelectedIndex = k
                    Exit For
                End If
            Next
            For k = 0 To CboAlmOOTI.Items.Count - 1
                If Val(CboAlmOOTI.Items(k).ToString.Substring(0, 2)) = ALM_OOTI Then
                    CboAlmOOTI.SelectedIndex = k
                    Exit For
                End If
            Next

            For k = 0 To CboAlmCOTE.Items.Count - 1
                If Val(CboAlmCOTE.Items(k).ToString.Substring(0, 2)) = ALM_COTE Then
                    CboAlmCOTE.SelectedIndex = k
                    Exit For
                End If
            Next
            For k = 0 To CboAlmROTE.Items.Count - 1
                If Val(CboAlmROTE.Items(k).ToString.Substring(0, 2)) = ALM_ROTE Then
                    CboAlmROTE.SelectedIndex = k
                    Exit For
                End If
            Next
            For k = 0 To CboAlmOOTE.Items.Count - 1
                If Val(CboAlmOOTE.Items(k).ToString.Substring(0, 2)) = ALM_OOTE Then
                    CboAlmOOTE.SelectedIndex = k
                    Exit For
                End If
            Next
            If SERIE_COMPRA.Trim.Length > 0 Then
                For k = 0 To CboSerieCompra.Items.Count - 1
                    If CboSerieCompra.Items(k) = SERIE_COMPRA Then
                        CboSerieCompra.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_COMPRA_DEV.Trim.Length > 0 Then
                For k = 0 To CboSerieCompraDev.Items.Count - 1
                    If CboSerieCompraDev.Items(k) = SERIE_COMPRA_DEV Then
                        CboSerieCompraDev.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_COMP_CONCI_VAL_DIESEL.Trim.Length > 0 Then
                For k = 0 To CboSerieComConciVesDie.Items.Count - 1
                    If CboSerieComConciVesDie.Items(k) = SERIE_COMP_CONCI_VAL_DIESEL Then
                        CboSerieComConciVesDie.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If

            If SERIE_COMPRA_OT.Trim.Length > 0 Then
                For k = 0 To CboSerieCompraOT.Items.Count - 1
                    If CboSerieCompraOT.Items(k) = SERIE_COMPRA_OT Then
                        CboSerieCompraOT.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_ORDEN_COMPRA_OT.Trim.Length > 0 Then
                For k = 0 To CboSerieOrdenCompraOT.Items.Count - 1
                    If CboSerieOrdenCompraOT.Items(k) = SERIE_ORDEN_COMPRA_OT Then
                        CboSerieOrdenCompraOT.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_RECEPCION_OT.Trim.Length > 0 Then
                For k = 0 To CboSerieRecepcionOT.Items.Count - 1
                    If CboSerieRecepcionOT.Items(k) = SERIE_RECEPCION_OT Then
                        CboSerieRecepcionOT.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            '************************
            If SERIE_COMPRA_OTEXT.Trim.Length > 0 Then
                For k = 0 To CboSerieCompraOTEXT.Items.Count - 1
                    If CboSerieCompraOTEXT.Items(k) = SERIE_COMPRA_OTEXT Then
                        CboSerieCompraOTEXT.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_ORDEN_COMPRA_OTEXT.Trim.Length > 0 Then
                For k = 0 To CboSerieOrdenCompraOTEXT.Items.Count - 1
                    If CboSerieOrdenCompraOTEXT.Items(k) = SERIE_ORDEN_COMPRA_OTEXT Then
                        CboSerieOrdenCompraOTEXT.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_RECEPCION_OTEXT.Trim.Length > 0 Then
                For k = 0 To CboSerieRecepcionOTEXT.Items.Count - 1
                    If CboSerieRecepcionOTEXT.Items(k) = SERIE_RECEPCION_OTEXT Then
                        CboSerieRecepcionOTEXT.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_GASTOS.Trim.Length > 0 Then
                For k = 0 To CboSerieGastos.Items.Count - 1
                    If CboSerieGastos.Items(k) = SERIE_GASTOS Then
                        CboSerieGastos.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            If CboModuloCompra.SelectedIndex = -1 Then CboModuloCompra.SelectedIndex = 0
            Dim cmd As New SqlCommand With {
                .Connection = cnSAE
            }

            SQL = "UPDATE GCPARAMCOMPRAS SET CAPTURA_PAGO_COMPRAS = " & IIf(ChCAPTURA_PAGO_COMPRAS.Value, 1, 0) & ",
                C_ALTA_PROVEEDORES = " & IIf(ChALTA_PROVEEDORES.Value, 1, 0) & ", C_ALTA_PRODUCTOS = " & IIf(ChALTA_PRODUCTOS.Value, 1, 0) & ",
                OBSER_X_DOCUMENTO = " & IIf(ChOBSER_X_DOC.Value, 1, 0) & ", OBSER_X_PARTIDA = " & IIf(ChOBSER_X_PARTIDA.Value, 1, 0) & ",
                INDIRECTOS_X_PARTIDA = " & IIf(ChINDIRECTOS_X_PARTIDA.Value, 1, 0) & ", IMPUESTOS = " & IIf(ChIMPUESTOS.Value, 1, 0) & ",
                ALMACEN = " & IIf(ChALMACEN.Value, 1, 0) & ", SERIE_COMPRA = '" & CboSerieCompra.Text & "', 
                SERIE_COMPRA_DEV = '" & CboSerieCompraDev.Text & "', SERIE_COMPRA_OT = '" & CboSerieCompraOT.Text & "', 
                SERIE_COMP_CONCI_VAL_DIESEL = '" & CboSerieComConciVesDie.Text & "', SERIE_RECEPCION_OT = '" & CboSerieRecepcionOT.Text & "', 
                SERIE_ORDEN_COMPRA_OT = '" & CboSerieOrdenCompraOT.Text & "', SERIE_COMPRA_OTEXT = '" & CboSerieCompraOTEXT.Text & "', 
                SERIE_RECEPCION_OTEXT = '" & CboSerieRecepcionOTEXT.Text & "',
                SERIE_ORDEN_COMPRA_OTEXT = '" & CboSerieOrdenCompraOTEXT.Text & "',
                ALM_COTI = " & CboAlmCOTI.Items(CboAlmCOTI.SelectedIndex).ToString.Substring(0, 2) & ",
                ALM_ROTI = " & CboAlmROTI.Items(CboAlmROTI.SelectedIndex).ToString.Substring(0, 2) & ",
                ALM_OOTI = " & CboAlmOOTI.Items(CboAlmOOTI.SelectedIndex).ToString.Substring(0, 2) & ",
                ALM_COTE = " & CboAlmCOTE.Items(CboAlmCOTE.SelectedIndex).ToString.Substring(0, 2) & ",
                ALM_ROTE = " & CboAlmROTE.Items(CboAlmROTE.SelectedIndex).ToString.Substring(0, 2) & ",
                ALM_OOTE = " & CboAlmOOTE.Items(CboAlmOOTE.SelectedIndex).ToString.Substring(0, 2) & ", 
                FTO_COMP = '" & TFTO_COMP.Text & "', FTO_ODEC = '" & TFTO_ODEC.Text & "', 
                FTO_RECE = '" & TFTO_RECE.Text & "', FTO_REQU = '" & TFTO_REQU.Text & "', 
                FTO_DEVO = '" & TFTO_DEVO.Text & "', SEL_FTO = " & IIf(CHSEL_FTO.Checked, 1, 0) & ", 
                SERIE_GASTO = '" & CboSerieGastos.Text & "', SERIE_PRE_OC  = '" & CboSeriePreOC.Text & "',
                SERIE_OC_DESDE_PRE_OC = '" & CboSerieOcDesdePreOC.Text & "', MODULO_COMPRAS = " & CboModuloCompra.SelectedIndex
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()

            MsgBox("Los datos se grabaron satisfactoriamente")

            Me.Close()
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmParamCompras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab2("Configuración compras")
        Me.Dispose()
    End Sub
    Private Sub FrmParamCompras_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub BtnSeries_Click(sender As Object, e As EventArgs) Handles BtnSeries.Click
        FrmFOLIOSC.ShowDialog()
    End Sub
End Class
