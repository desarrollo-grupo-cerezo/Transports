Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Public Class FrmParamOPciones
    Private Sub FrmParamOPciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        'SplitM.Dock = DockStyle.Fill
        'Tab1.Dock = DockStyle.Fill
        'Tab2.Dock = DockStyle.Fill

        Me.CenterToScreen()

    End Sub

    Private Sub FrmParamOPciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmParamOPciones_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Tab1.SelectedIndex = 1
            SplitM.SplitterWidth = 0
            SplitM.BorderWidth = 0
            Split1.BorderWidth = 0

            Tab1.ItemSize = New Size(140, 40)
            Tab1.SelectedIndex = 0

            Dim SPOR1 As Decimal

            SPOR1 = (Tab1.Height / Me.Height) * 100
            Split1.SizeRatio = SPOR1 - 1
            Split2.SizeRatio = 100 - Split1.SizeRatio
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tab3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedIndexChanged
        Select Case Tab1.SelectedTab.Name
            Case "PagGenerales"
                CloseTabAll()
                CREA_TAB2(FrmParamOpcGen, "Generales")
            Case "PagInvent"
                CloseTabAll()
                CREA_TAB2(FrmParamOpcInvent, "Inventario")
            Case "PagVentas"
                CloseTabAll()
                CREA_TAB2(FrmParamOpcVentas, "Ventas")
            Case "PagCompras"
                CloseTabAll()
                CREA_TAB2(FrmParamOpcCompras, "Compras")
            Case "PagClientes"
                CloseTabAll()
                CREA_TAB2(FrmParamOpcClientes, "Clientes")
            Case "PagProv"
                CloseTabAll()
                CREA_TAB2(FrmParamOpcProv, "Proveedores")
            Case "PagFE"
                CloseTabAll()
                CREA_TAB2(FrmFacturaElectronica, "Factura electrónica")
        End Select
    End Sub
    Private Sub Tab2_TabPageClosing(sender As Object, e As TabPageCancelEventArgs) Handles Tab2.TabPageClosing
        Try
            Select Case Tab2.TabPages(Tab2.SelectedIndex).Text
                Case "Generales"
                    FrmParamOpcGen.Dispose()
                Case "Inventario"
                    FrmParamOpcInvent.Dispose()
                Case "ACUM_VTAS"
                    If FORM_IS_OPEN("frmParamVentas") Then
                        FrmParamOpcVentas.Close()
                    End If
                    FrmParamOpcVentas.Dispose()
                Case "Compras"
                    FrmParamOpcCompras.Dispose()
                Case "Clientes"
                    FrmParamOpcClientes.Dispose()
                Case "Proveedores"
                    FrmParamOpcProv.Dispose()
                Case "Factura electrónica"
                    FrmFacturaElectronica.Dispose()
            End Select
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CloseTabAll()
        Try
            For k = Tab2.TabPages.Count - 1 To 0 Step -1
                Try
                    Select Case Tab2.TabPages(k).Text
                        Case "Generales"
                            Tab2.TabPages.RemoveAt(k)
                            If Application.OpenForms().OfType(Of FrmParamOpcGen).Any Then
                                FrmParamOpcGen.Close()
                            End If
                            FrmParamGenerales.Dispose()
                        Case "Inventario"
                            Tab2.TabPages.RemoveAt(k)
                            If Application.OpenForms().OfType(Of FrmParamOpcInvent).Any Then
                                FrmParamOpcInvent.Close()
                            End If
                            FrmParamOpcInvent.Dispose()
                        Case "Ventas"
                            Tab2.TabPages.RemoveAt(k)
                            If Application.OpenForms().OfType(Of FrmParamOpcVentas).Any Then
                                FrmParamOpcVentas.Close()
                            End If
                            FrmParamOpcVentas.Dispose()
                        Case "Compras"
                            Tab2.TabPages.RemoveAt(k)
                            If Application.OpenForms().OfType(Of FrmParamOpcCompras).Any Then
                                FrmParamOpcCompras.Close()
                            End If
                            FrmParamOpcCompras.Dispose()
                        Case "Clientes"
                            Tab2.TabPages.RemoveAt(k)
                            If Application.OpenForms().OfType(Of FrmParamOpcGen).Any Then
                                FrmParamOpcGen.Close()
                            End If
                            FrmParamOpcClientes.Dispose()
                        Case "Proveedores"
                            Tab2.TabPages.RemoveAt(k)
                            If Application.OpenForms().OfType(Of FrmParamOpcProv).Any Then
                                FrmParamOpcProv.Close()
                            End If
                            FrmParamOpcProv.Dispose()
                        Case "Factura electrónica"
                            Tab2.TabPages.RemoveAt(k)
                            If Application.OpenForms().OfType(Of FrmFacturaElectronica).Any Then
                                FrmFacturaElectronica.Close()
                            End If
                            FrmFacturaElectronica.Dispose()
                        Case Else
                            Debug.Print(Tab2.TabPages(k).Text)
                    End Select
                Catch ex As Exception
                    Bitacora("571. " & ex.Message & Environment.NewLine & ex.StackTrace)
                    MsgBox("571. " & ex.Message & Environment.NewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("571. " & ex.Message & Environment.NewLine & ex.StackTrace)
            MsgBox("571. " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub CREA_TAB2(fFrm As Form, fTab As String)

        If Not ExisteTab2(fTab) Then
            Try
                fFrm.TopLevel = False
                fFrm.TopMost = True
                Dim newpage As C1.Win.C1Command.C1DockingTabPage = New C1.Win.C1Command.C1DockingTabPage()
                newpage.Text = fTab '& (Tab1.TabPages.Count + 1)
                newpage.Tag = fFrm
                'newpage.TabBackColor = Color.PaleGreen
                'newpage.BackColor = Color.PaleGreen
                Tab2.TabPages.Add(newpage)
                Tab2.Dock = DockStyle.Fill

                newpage.Controls.Add(fFrm)

                Tab2.SelectedTab = newpage
                fFrm.Show()

            Catch ex As Exception
                Bitacora("500. " & ex.Message & Environment.NewLine & ex.StackTrace)
                MsgBox("500. " & ex.Message & Environment.NewLine & ex.StackTrace)
            End Try
        Else
            Try
                For k = 0 To Tab2.TabPages.Count - 1
                    If Tab2.TabPages(k).Text = fTab Then
                        Tab2.SelectedIndex = k
                        Exit For
                    End If
                Next
            Catch ex As Exception
                Bitacora("565. " & ex.Message & Environment.NewLine & ex.StackTrace)
                MsgBox("565. " & ex.Message & Environment.NewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Public Function ExisteTab2(fTab As String) As Boolean
        Dim ExisT As Boolean = False
        Try
            For k = 0 To Tab2.TabPages.Count - 1
                If Tab2.TabPages(k).Text = fTab Then
                    ExisT = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            Bitacora("566. " & ex.Message & Environment.NewLine & ex.StackTrace)
            MsgBox("566. " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
        Return ExisT
    End Function
End Class