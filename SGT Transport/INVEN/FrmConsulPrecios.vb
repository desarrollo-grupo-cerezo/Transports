Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Command
Public Class FrmConsulPrecios
    Private ReadOnly BindingSource1 As New BindingSource
    Private CADENA As String
    Private CADENA_SQ As String
    Private CADENA_SQP As String
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg.Dock = DockStyle.Fill
        Catch ex As Exception
        End Try

        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 20

            CADENA = ""
            CADENA_SQP = ""
            CADENA_SQ = ""
            Dim Z As Integer = 5
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_PRECIO, DESCRIPCION 
                    FROM PRECIOS" & Empresa & " 
                    WHERE STATUS = 'A'
                    ORDER BY CVE_PRECIO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg(0, Z) = Format(dr("CVE_PRECIO"), "00") & " " & dr("DESCRIPCION")
                        CADENA_SQP += "SQ" & dr("CVE_PRECIO") & ".PRECIO AS '" & Fg(0, Z) & "', "
                        CADENA_SQ += "OUTER APPLY (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = " & dr("CVE_PRECIO") & ") AS SQ" & dr("CVE_PRECIO") & vbNewLine
                        Z += 1
                    End While
                End Using
            End Using
            If CADENA_SQ <> "" Then
                CADENA_SQ = CADENA_SQ.Substring(0, CADENA_SQ.Length - 2)
                CADENA_SQP = CADENA_SQP.Substring(0, CADENA_SQP.Length - 2)
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmConsulPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        DESPLEGAR()
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ds As New DataSet

            Fg.Redraw = False
            Fg.AllowEditing = False

            SQL = "SELECT I.CVE_ART AS 'Articulo', I.DESCR as 'Descripción', I.LIN_PROD as 'Linea', I.EXIST as 'Existencia', " & CADENA_SQP & "
                FROM INVE" & Empresa & " I 
                LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                CADENA_SQ & "
                WHERE I.STATUS = 'A' " & CADENA & " ORDER BY DESCR"
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource
            Lt.Text = "Registros encontrados: " & Fg.Rows.Count - 1

            For k = 4 To Fg.Cols.Count - 1
                Dim c5 As Column = Fg.Cols(k)
                c5.DataType = GetType(Decimal)
                Fg.Cols(k).Format = "###,###,##0.00"
            Next
            Fg.AutoSizeCols()
            Fg.Cols(0).Width = 40

            Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            AJUSTA_COLUMNAS_FG(Fg, 0)

            Fg.Redraw = True
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmConsulPrecios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Lista de precios")
    End Sub
    Private Sub BarFiltrar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarFiltrar.Click
        Try
            Var2 = "" 'LINEA
            Var3 = "" 'S - SOLO CON EXISTENCIA
            CADENA = ""
            Dim f As New FrmFiltroInve With {.MdiParent = MainRibbonForm.Owner}
            f.ShowDialog()
            If Var47.Trim.Length > 0 Or Var3.Trim.Length > 0 Then
                CADENA = Var47
                If Var3.Trim.Length > 0 Then
                    CADENA += " AND I.EXIST > 0 "
                End If

                DESPLEGAR()
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarImprimir.Click

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Lista de precios")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
End Class