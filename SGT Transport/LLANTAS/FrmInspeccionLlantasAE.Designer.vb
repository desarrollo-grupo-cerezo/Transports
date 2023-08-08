<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInspeccionLlantasAE
    Inherits C1.Win.C1Ribbon.C1RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInspeccionLlantasAE))
        Me.LtDel = New System.Windows.Forms.Label()
        Me.TFECHA = New C1.Win.Calendar.C1DateEdit()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.TPOSICION1 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TMARCA1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TMODELO1 = New System.Windows.Forms.TextBox()
        Me.TTIPO_LLANTA1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TCOSTO_LLANTA1 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TDESGASTE1 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TObs1 = New System.Windows.Forms.TextBox()
        Me.LtObser = New System.Windows.Forms.Label()
        Me.TKMS_MONTAR1 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR1 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL1 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL11 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.BtnUnidades = New C1.Win.C1Input.C1Button()
        Me.TCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TKM_RECORRIDOS12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE12 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA12 = New System.Windows.Forms.TextBox()
        Me.TObs12 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL112 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA12 = New System.Windows.Forms.TextBox()
        Me.TMARCA12 = New System.Windows.Forms.TextBox()
        Me.TMODELO12 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS11 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE11 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA11 = New System.Windows.Forms.TextBox()
        Me.TObs11 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL111 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL11 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE11 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR11 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR11 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION11 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA11 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA11 = New System.Windows.Forms.TextBox()
        Me.TMARCA11 = New System.Windows.Forms.TextBox()
        Me.TMODELO11 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS10 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE10 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA10 = New System.Windows.Forms.TextBox()
        Me.TObs10 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL110 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL10 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE10 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR10 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR10 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION10 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA10 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA10 = New System.Windows.Forms.TextBox()
        Me.TMARCA10 = New System.Windows.Forms.TextBox()
        Me.TMODELO10 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS9 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE9 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA9 = New System.Windows.Forms.TextBox()
        Me.TObs9 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL19 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL9 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE9 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR9 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR9 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION9 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA9 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA9 = New System.Windows.Forms.TextBox()
        Me.TMARCA9 = New System.Windows.Forms.TextBox()
        Me.TMODELO9 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS8 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE8 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA8 = New System.Windows.Forms.TextBox()
        Me.TObs8 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL18 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL8 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE8 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR8 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR8 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION8 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA8 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA8 = New System.Windows.Forms.TextBox()
        Me.TMARCA8 = New System.Windows.Forms.TextBox()
        Me.TMODELO8 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS7 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE7 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA7 = New System.Windows.Forms.TextBox()
        Me.TObs7 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL17 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL7 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE7 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR7 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR7 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION7 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA7 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA7 = New System.Windows.Forms.TextBox()
        Me.TMARCA7 = New System.Windows.Forms.TextBox()
        Me.TMODELO7 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS6 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE6 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA6 = New System.Windows.Forms.TextBox()
        Me.TObs6 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL16 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL6 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE6 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR6 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR6 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION6 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA6 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA6 = New System.Windows.Forms.TextBox()
        Me.TMARCA6 = New System.Windows.Forms.TextBox()
        Me.TMODELO6 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS5 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE5 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA5 = New System.Windows.Forms.TextBox()
        Me.TObs5 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL15 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL5 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE5 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR5 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR5 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION5 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA5 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA5 = New System.Windows.Forms.TextBox()
        Me.TMARCA5 = New System.Windows.Forms.TextBox()
        Me.TMODELO5 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS4 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE4 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA4 = New System.Windows.Forms.TextBox()
        Me.TObs4 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL14 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL4 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE4 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR4 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR4 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION4 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA4 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA4 = New System.Windows.Forms.TextBox()
        Me.TMARCA4 = New System.Windows.Forms.TextBox()
        Me.TMODELO4 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS3 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE3 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA3 = New System.Windows.Forms.TextBox()
        Me.TObs3 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL13 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL3 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE3 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR3 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR3 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION3 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA3 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA3 = New System.Windows.Forms.TextBox()
        Me.TMARCA3 = New System.Windows.Forms.TextBox()
        Me.TMODELO3 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS2 = New C1.Win.C1Input.C1NumericEdit()
        Me.TFECHA_MONTAJE2 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA2 = New System.Windows.Forms.TextBox()
        Me.TObs2 = New System.Windows.Forms.TextBox()
        Me.TPROFUNDIDAD_ACTUAL12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDA_ORIGINAL2 = New C1.Win.C1Input.C1NumericEdit()
        Me.TDESGASTE2 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_DESMONTAR2 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKMS_MONTAR2 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPOSICION2 = New C1.Win.C1Input.C1NumericEdit()
        Me.TCOSTO_LLANTA2 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_LLANTA2 = New System.Windows.Forms.TextBox()
        Me.TMARCA2 = New System.Windows.Forms.TextBox()
        Me.TMODELO2 = New System.Windows.Forms.TextBox()
        Me.TKM_RECORRIDOS1 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TFECHA_MONTAJE1 = New System.Windows.Forms.TextBox()
        Me.TNUEVA_RENOVADA1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TLL12 = New System.Windows.Forms.TextBox()
        Me.Et12 = New System.Windows.Forms.Label()
        Me.TLL11 = New System.Windows.Forms.TextBox()
        Me.Et11 = New System.Windows.Forms.Label()
        Me.TLL10 = New System.Windows.Forms.TextBox()
        Me.Et10 = New System.Windows.Forms.Label()
        Me.TLL9 = New System.Windows.Forms.TextBox()
        Me.Et9 = New System.Windows.Forms.Label()
        Me.TLL8 = New System.Windows.Forms.TextBox()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.TLL6 = New System.Windows.Forms.TextBox()
        Me.TLL7 = New System.Windows.Forms.TextBox()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.Label129 = New System.Windows.Forms.Label()
        Me.TLL5 = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.TLL4 = New System.Windows.Forms.TextBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.TLL3 = New System.Windows.Forms.TextBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.TLL1 = New System.Windows.Forms.TextBox()
        Me.TLL2 = New System.Windows.Forms.TextBox()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.LtSt = New System.Windows.Forms.Label()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.TKM_ACTUAL5 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL6 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL4 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL11 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TKM_ACTUAL7 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL3 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL10 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL1 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL8 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL2 = New C1.Win.C1Input.C1NumericEdit()
        Me.TKM_ACTUAL9 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL15 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL112 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL14 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL16 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL111 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL13 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL17 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL110 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TPRESION_ACTUAL12 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL11 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL18 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPRESION_ACTUAL19 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL45 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL412 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL44 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL46 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL411 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL43 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL47 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL410 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TPROFUNDIDAD_ACTUAL42 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL41 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL48 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL49 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL35 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL312 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL34 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL36 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL311 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL33 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL37 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL310 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TPROFUNDIDAD_ACTUAL32 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL31 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL38 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL39 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL25 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL212 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL24 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL26 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL211 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL23 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL27 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL210 = New C1.Win.C1Input.C1NumericEdit()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TPROFUNDIDAD_ACTUAL22 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL21 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL28 = New C1.Win.C1Input.C1NumericEdit()
        Me.TPROFUNDIDAD_ACTUAL29 = New C1.Win.C1Input.C1NumericEdit()
        Me.TTIPO_RIN12 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN5 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN4 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN11 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN6 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN3 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN10 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TTIPO_RIN7 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN2 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN9 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN8 = New System.Windows.Forms.TextBox()
        Me.TTIPO_RIN1 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LtCve_Ins = New System.Windows.Forms.Label()
        CType(Me.TFECHA, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL112, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL111, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS10, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL110, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL10, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE10, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR10, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR10, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION10, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA10, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS9, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL19, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL9, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE9, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR9, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR9, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION9, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA9, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS8, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL18, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL8, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE8, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR8, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR8, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION8, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA8, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS7, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL17, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL7, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE7, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR7, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR7, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION7, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA7, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL16, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS5, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL15, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL5, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE5, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR5, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR5, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION5, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA5, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS4, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL14, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL4, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE4, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR4, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR4, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION4, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA4, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS3, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL13, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL3, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE3, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR3, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR3, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION3, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA3, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS2, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDA_ORIGINAL2, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TDESGASTE2, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_DESMONTAR2, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKMS_MONTAR2, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPOSICION2, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TCOSTO_LLANTA2, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_RECORRIDOS1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitM.SuspendLayout
        Me.Split1.SuspendLayout
        Me.Split2.SuspendLayout
        CType(Me.TKM_ACTUAL5, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL4, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL7, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL3, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL10, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL8, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL2, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TKM_ACTUAL9, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL15, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL112, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL14, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL16, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL111, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL13, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL17, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL110, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL12, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL11, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL18, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPRESION_ACTUAL19, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL45, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL412, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL44, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL46, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL411, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL43, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL47, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL410, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL42, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL41, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL48, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL49, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL35, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL312, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL34, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL36, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL311, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL33, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL37, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL310, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL32, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL31, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL38, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL39, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL25, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL212, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL24, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL26, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL211, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL23, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL27, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL210, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL22, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL21, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL28, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TPROFUNDIDAD_ACTUAL29, System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.BackColor = System.Drawing.Color.Transparent
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.ForeColor = System.Drawing.Color.Black
        Me.LtDel.Location = New System.Drawing.Point(55, 110)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(113, 16)
        Me.LtDel.TabIndex = 598
        Me.LtDel.Text = "Fecha inspección"
        '
        'TFECHA
        '
        Me.TFECHA.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TFECHA.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TFECHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.TFECHA.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.TFECHA.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TFECHA.Location = New System.Drawing.Point(172, 108)
        Me.TFECHA.Name = "TFECHA"
        Me.TFECHA.Size = New System.Drawing.Size(122, 20)
        Me.TFECHA.TabIndex = 1
        Me.TFECHA.Tag = Nothing
        Me.TFECHA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.TFECHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.Text = "Grabar"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 90
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1491, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'TPOSICION1
        '
        Me.TPOSICION1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION1.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION1.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION1.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION1.InterceptArrowKeys = False
        Me.TPOSICION1.Location = New System.Drawing.Point(1086, 38)
        Me.TPOSICION1.MaxLength = 5
        Me.TPOSICION1.Name = "TPOSICION1"
        Me.TPOSICION1.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION1.TabIndex = 17
        Me.TPOSICION1.Tag = Nothing
        Me.TPOSICION1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(1082, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 604
        Me.Label15.Text = "Posición"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(445, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 608
        Me.Label1.Text = "Fecha montaje"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(135, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 612
        Me.Label4.Text = "Marca"
        '
        'TMARCA1
        '
        Me.TMARCA1.AcceptsReturn = True
        Me.TMARCA1.AcceptsTab = True
        Me.TMARCA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA1.ForeColor = System.Drawing.Color.Black
        Me.TMARCA1.Location = New System.Drawing.Point(110, 37)
        Me.TMARCA1.MaxLength = 10
        Me.TMARCA1.Name = "TMARCA1"
        Me.TMARCA1.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA1.TabIndex = 1
        Me.TMARCA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(225, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 616
        Me.Label3.Text = "Modelo"
        '
        'TMODELO1
        '
        Me.TMODELO1.AcceptsReturn = True
        Me.TMODELO1.AcceptsTab = True
        Me.TMODELO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO1.ForeColor = System.Drawing.Color.Black
        Me.TMODELO1.Location = New System.Drawing.Point(210, 37)
        Me.TMODELO1.MaxLength = 10
        Me.TMODELO1.Name = "TMODELO1"
        Me.TMODELO1.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO1.TabIndex = 2
        Me.TMODELO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_LLANTA1
        '
        Me.TTIPO_LLANTA1.AcceptsReturn = True
        Me.TTIPO_LLANTA1.AcceptsTab = True
        Me.TTIPO_LLANTA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA1.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA1.Location = New System.Drawing.Point(281, 37)
        Me.TTIPO_LLANTA1.MaxLength = 10
        Me.TTIPO_LLANTA1.Name = "TTIPO_LLANTA1"
        Me.TTIPO_LLANTA1.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA1.TabIndex = 3
        Me.TTIPO_LLANTA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(282, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 621
        Me.Label14.Text = "Tipo llanta"
        '
        'TCOSTO_LLANTA1
        '
        Me.TCOSTO_LLANTA1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA1.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA1.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA1.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA1.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA1.Location = New System.Drawing.Point(524, 38)
        Me.TCOSTO_LLANTA1.Name = "TCOSTO_LLANTA1"
        Me.TCOSTO_LLANTA1.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA1.TabIndex = 6
        Me.TCOSTO_LLANTA1.Tag = Nothing
        Me.TCOSTO_LLANTA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(528, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 31)
        Me.Label5.TabIndex = 624
        Me.Label5.Text = "Costo llanta"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(875, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 31)
        Me.Label6.TabIndex = 626
        Me.Label6.Text = "Prof.  actual"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(649, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 31)
        Me.Label8.TabIndex = 629
        Me.Label8.Text = "Profun. original"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(587, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 30)
        Me.Label13.TabIndex = 633
        Me.Label13.Text = "Kms. al montar"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(698, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 31)
        Me.Label17.TabIndex = 634
        Me.Label17.Text = "Kms. al desmontar"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TDESGASTE1
        '
        Me.TDESGASTE1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE1.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE1.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE1.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE1.InterceptArrowKeys = False
        Me.TDESGASTE1.Location = New System.Drawing.Point(1127, 38)
        Me.TDESGASTE1.Name = "TDESGASTE1"
        Me.TDESGASTE1.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE1.TabIndex = 18
        Me.TDESGASTE1.Tag = Nothing
        Me.TDESGASTE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(1126, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 638
        Me.Label7.Text = "Desgaste"
        '
        'TObs1
        '
        Me.TObs1.AcceptsReturn = True
        Me.TObs1.AcceptsTab = True
        Me.TObs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs1.ForeColor = System.Drawing.Color.Black
        Me.TObs1.Location = New System.Drawing.Point(1288, 37)
        Me.TObs1.MaxLength = 255
        Me.TObs1.Multiline = True
        Me.TObs1.Name = "TObs1"
        Me.TObs1.Size = New System.Drawing.Size(154, 20)
        Me.TObs1.TabIndex = 19
        '
        'LtObser
        '
        Me.LtObser.AutoSize = True
        Me.LtObser.BackColor = System.Drawing.Color.Transparent
        Me.LtObser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtObser.ForeColor = System.Drawing.Color.Black
        Me.LtObser.Location = New System.Drawing.Point(1303, 21)
        Me.LtObser.Name = "LtObser"
        Me.LtObser.Size = New System.Drawing.Size(78, 13)
        Me.LtObser.TabIndex = 640
        Me.LtObser.Text = "Observaciones"
        '
        'TKMS_MONTAR1
        '
        Me.TKMS_MONTAR1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR1.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR1.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR1.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR1.InterceptArrowKeys = False
        Me.TKMS_MONTAR1.Location = New System.Drawing.Point(582, 38)
        Me.TKMS_MONTAR1.Name = "TKMS_MONTAR1"
        Me.TKMS_MONTAR1.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR1.TabIndex = 7
        Me.TKMS_MONTAR1.Tag = Nothing
        Me.TKMS_MONTAR1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR1
        '
        Me.TKMS_DESMONTAR1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR1.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR1.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR1.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR1.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR1.Location = New System.Drawing.Point(698, 38)
        Me.TKMS_DESMONTAR1.Name = "TKMS_DESMONTAR1"
        Me.TKMS_DESMONTAR1.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR1.TabIndex = 9
        Me.TKMS_DESMONTAR1.Tag = Nothing
        Me.TKMS_DESMONTAR1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL1
        '
        Me.TPROFUNDIDA_ORIGINAL1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL1.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL1.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL1.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL1.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL1.Location = New System.Drawing.Point(650, 38)
        Me.TPROFUNDIDA_ORIGINAL1.Name = "TPROFUNDIDA_ORIGINAL1"
        Me.TPROFUNDIDA_ORIGINAL1.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL1.TabIndex = 8
        Me.TPROFUNDIDA_ORIGINAL1.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL11
        '
        Me.TPROFUNDIDAD_ACTUAL11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL11.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL11.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL11.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL11.Location = New System.Drawing.Point(876, 38)
        Me.TPROFUNDIDAD_ACTUAL11.Name = "TPROFUNDIDAD_ACTUAL11"
        Me.TPROFUNDIDAD_ACTUAL11.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL11.TabIndex = 12
        Me.TPROFUNDIDAD_ACTUAL11.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(89, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 16)
        Me.Label9.TabIndex = 652
        Me.Label9.Text = "Descripción"
        '
        'L2
        '
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(172, 79)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(271, 20)
        Me.L2.TabIndex = 651
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnUnidades
        '
        Me.BtnUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnidades.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnUnidades.Location = New System.Drawing.Point(260, 48)
        Me.BtnUnidades.Name = "BtnUnidades"
        Me.BtnUnidades.Size = New System.Drawing.Size(23, 20)
        Me.BtnUnidades.TabIndex = 650
        Me.BtnUnidades.UseVisualStyleBackColor = True
        Me.BtnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_UNI
        '
        Me.TCVE_UNI.AcceptsReturn = True
        Me.TCVE_UNI.AcceptsTab = True
        Me.TCVE_UNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_UNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_UNI.Location = New System.Drawing.Point(172, 47)
        Me.TCVE_UNI.Name = "TCVE_UNI"
        Me.TCVE_UNI.Size = New System.Drawing.Size(87, 22)
        Me.TCVE_UNI.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(117, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 16)
        Me.Label10.TabIndex = 649
        Me.Label10.Text = "Unidad"
        '
        'TKM_RECORRIDOS12
        '
        Me.TKM_RECORRIDOS12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_RECORRIDOS12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_RECORRIDOS12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_RECORRIDOS12.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS12.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS12.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS12.Location = New System.Drawing.Point(819, 281)
        Me.TKM_RECORRIDOS12.Name = "TKM_RECORRIDOS12"
        Me.TKM_RECORRIDOS12.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS12.TabIndex = 232
        Me.TKM_RECORRIDOS12.Tag = Nothing
        Me.TKM_RECORRIDOS12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE12
        '
        Me.TFECHA_MONTAJE12.AcceptsReturn = True
        Me.TFECHA_MONTAJE12.AcceptsTab = True
        Me.TFECHA_MONTAJE12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE12.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE12.Location = New System.Drawing.Point(443, 280)
        Me.TFECHA_MONTAJE12.MaxLength = 10
        Me.TFECHA_MONTAJE12.Name = "TFECHA_MONTAJE12"
        Me.TFECHA_MONTAJE12.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE12.TabIndex = 226
        Me.TFECHA_MONTAJE12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA12
        '
        Me.TNUEVA_RENOVADA12.AcceptsReturn = True
        Me.TNUEVA_RENOVADA12.AcceptsTab = True
        Me.TNUEVA_RENOVADA12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA12.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA12.Location = New System.Drawing.Point(362, 280)
        Me.TNUEVA_RENOVADA12.MaxLength = 10
        Me.TNUEVA_RENOVADA12.Name = "TNUEVA_RENOVADA12"
        Me.TNUEVA_RENOVADA12.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA12.TabIndex = 225
        Me.TNUEVA_RENOVADA12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs12
        '
        Me.TObs12.AcceptsReturn = True
        Me.TObs12.AcceptsTab = True
        Me.TObs12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs12.ForeColor = System.Drawing.Color.Black
        Me.TObs12.Location = New System.Drawing.Point(1288, 280)
        Me.TObs12.MaxLength = 255
        Me.TObs12.Multiline = True
        Me.TObs12.Name = "TObs12"
        Me.TObs12.Size = New System.Drawing.Size(154, 20)
        Me.TObs12.TabIndex = 240
        '
        'TPROFUNDIDAD_ACTUAL112
        '
        Me.TPROFUNDIDAD_ACTUAL112.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL112.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPROFUNDIDAD_ACTUAL112.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL112.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL112.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL112.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL112.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL112.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL112.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL112.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL112.Location = New System.Drawing.Point(876, 281)
        Me.TPROFUNDIDAD_ACTUAL112.Name = "TPROFUNDIDAD_ACTUAL112"
        Me.TPROFUNDIDAD_ACTUAL112.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL112.TabIndex = 233
        Me.TPROFUNDIDAD_ACTUAL112.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL112.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL112.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL112.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL112.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL12
        '
        Me.TPROFUNDIDA_ORIGINAL12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL12.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL12.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL12.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL12.Location = New System.Drawing.Point(650, 281)
        Me.TPROFUNDIDA_ORIGINAL12.Name = "TPROFUNDIDA_ORIGINAL12"
        Me.TPROFUNDIDA_ORIGINAL12.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL12.TabIndex = 229
        Me.TPROFUNDIDA_ORIGINAL12.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE12
        '
        Me.TDESGASTE12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE12.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE12.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE12.InterceptArrowKeys = False
        Me.TDESGASTE12.Location = New System.Drawing.Point(1127, 281)
        Me.TDESGASTE12.Name = "TDESGASTE12"
        Me.TDESGASTE12.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE12.TabIndex = 239
        Me.TDESGASTE12.Tag = Nothing
        Me.TDESGASTE12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR12
        '
        Me.TKMS_DESMONTAR12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR12.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR12.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR12.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR12.Location = New System.Drawing.Point(698, 281)
        Me.TKMS_DESMONTAR12.Name = "TKMS_DESMONTAR12"
        Me.TKMS_DESMONTAR12.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR12.TabIndex = 230
        Me.TKMS_DESMONTAR12.Tag = Nothing
        Me.TKMS_DESMONTAR12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR12
        '
        Me.TKMS_MONTAR12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR12.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR12.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR12.InterceptArrowKeys = False
        Me.TKMS_MONTAR12.Location = New System.Drawing.Point(582, 281)
        Me.TKMS_MONTAR12.Name = "TKMS_MONTAR12"
        Me.TKMS_MONTAR12.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR12.TabIndex = 228
        Me.TKMS_MONTAR12.Tag = Nothing
        Me.TKMS_MONTAR12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION12
        '
        Me.TPOSICION12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION12.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION12.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION12.InterceptArrowKeys = False
        Me.TPOSICION12.Location = New System.Drawing.Point(1086, 281)
        Me.TPOSICION12.MaxLength = 5
        Me.TPOSICION12.Name = "TPOSICION12"
        Me.TPOSICION12.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION12.TabIndex = 238
        Me.TPOSICION12.Tag = Nothing
        Me.TPOSICION12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA12
        '
        Me.TCOSTO_LLANTA12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA12.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA12.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA12.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA12.Location = New System.Drawing.Point(524, 281)
        Me.TCOSTO_LLANTA12.Name = "TCOSTO_LLANTA12"
        Me.TCOSTO_LLANTA12.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA12.TabIndex = 227
        Me.TCOSTO_LLANTA12.Tag = Nothing
        Me.TCOSTO_LLANTA12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA12
        '
        Me.TTIPO_LLANTA12.AcceptsReturn = True
        Me.TTIPO_LLANTA12.AcceptsTab = True
        Me.TTIPO_LLANTA12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA12.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA12.Location = New System.Drawing.Point(281, 280)
        Me.TTIPO_LLANTA12.MaxLength = 10
        Me.TTIPO_LLANTA12.Name = "TTIPO_LLANTA12"
        Me.TTIPO_LLANTA12.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA12.TabIndex = 224
        Me.TTIPO_LLANTA12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA12
        '
        Me.TMARCA12.AcceptsReturn = True
        Me.TMARCA12.AcceptsTab = True
        Me.TMARCA12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA12.ForeColor = System.Drawing.Color.Black
        Me.TMARCA12.Location = New System.Drawing.Point(110, 280)
        Me.TMARCA12.MaxLength = 10
        Me.TMARCA12.Name = "TMARCA12"
        Me.TMARCA12.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA12.TabIndex = 221
        Me.TMARCA12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO12
        '
        Me.TMODELO12.AcceptsReturn = True
        Me.TMODELO12.AcceptsTab = True
        Me.TMODELO12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO12.ForeColor = System.Drawing.Color.Black
        Me.TMODELO12.Location = New System.Drawing.Point(210, 280)
        Me.TMODELO12.MaxLength = 10
        Me.TMODELO12.Name = "TMODELO12"
        Me.TMODELO12.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO12.TabIndex = 222
        Me.TMODELO12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS11
        '
        Me.TKM_RECORRIDOS11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKM_RECORRIDOS11.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS11.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS11.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS11.Location = New System.Drawing.Point(819, 259)
        Me.TKM_RECORRIDOS11.Name = "TKM_RECORRIDOS11"
        Me.TKM_RECORRIDOS11.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS11.TabIndex = 211
        Me.TKM_RECORRIDOS11.Tag = Nothing
        Me.TKM_RECORRIDOS11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE11
        '
        Me.TFECHA_MONTAJE11.AcceptsReturn = True
        Me.TFECHA_MONTAJE11.AcceptsTab = True
        Me.TFECHA_MONTAJE11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE11.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE11.Location = New System.Drawing.Point(443, 258)
        Me.TFECHA_MONTAJE11.MaxLength = 10
        Me.TFECHA_MONTAJE11.Name = "TFECHA_MONTAJE11"
        Me.TFECHA_MONTAJE11.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE11.TabIndex = 205
        Me.TFECHA_MONTAJE11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA11
        '
        Me.TNUEVA_RENOVADA11.AcceptsReturn = True
        Me.TNUEVA_RENOVADA11.AcceptsTab = True
        Me.TNUEVA_RENOVADA11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA11.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA11.Location = New System.Drawing.Point(362, 258)
        Me.TNUEVA_RENOVADA11.MaxLength = 10
        Me.TNUEVA_RENOVADA11.Name = "TNUEVA_RENOVADA11"
        Me.TNUEVA_RENOVADA11.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA11.TabIndex = 204
        Me.TNUEVA_RENOVADA11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs11
        '
        Me.TObs11.AcceptsReturn = True
        Me.TObs11.AcceptsTab = True
        Me.TObs11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs11.ForeColor = System.Drawing.Color.Black
        Me.TObs11.Location = New System.Drawing.Point(1288, 258)
        Me.TObs11.MaxLength = 255
        Me.TObs11.Multiline = True
        Me.TObs11.Name = "TObs11"
        Me.TObs11.Size = New System.Drawing.Size(154, 20)
        Me.TObs11.TabIndex = 219
        '
        'TPROFUNDIDAD_ACTUAL111
        '
        Me.TPROFUNDIDAD_ACTUAL111.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL111.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPROFUNDIDAD_ACTUAL111.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL111.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL111.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL111.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL111.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL111.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL111.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL111.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL111.Location = New System.Drawing.Point(876, 259)
        Me.TPROFUNDIDAD_ACTUAL111.Name = "TPROFUNDIDAD_ACTUAL111"
        Me.TPROFUNDIDAD_ACTUAL111.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL111.TabIndex = 212
        Me.TPROFUNDIDAD_ACTUAL111.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL111.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL111.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL111.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL111.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL11
        '
        Me.TPROFUNDIDA_ORIGINAL11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL11.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL11.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL11.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL11.Location = New System.Drawing.Point(650, 259)
        Me.TPROFUNDIDA_ORIGINAL11.Name = "TPROFUNDIDA_ORIGINAL11"
        Me.TPROFUNDIDA_ORIGINAL11.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL11.TabIndex = 208
        Me.TPROFUNDIDA_ORIGINAL11.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE11
        '
        Me.TDESGASTE11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE11.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE11.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE11.InterceptArrowKeys = False
        Me.TDESGASTE11.Location = New System.Drawing.Point(1127, 259)
        Me.TDESGASTE11.Name = "TDESGASTE11"
        Me.TDESGASTE11.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE11.TabIndex = 218
        Me.TDESGASTE11.Tag = Nothing
        Me.TDESGASTE11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR11
        '
        Me.TKMS_DESMONTAR11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR11.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR11.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR11.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR11.Location = New System.Drawing.Point(698, 259)
        Me.TKMS_DESMONTAR11.Name = "TKMS_DESMONTAR11"
        Me.TKMS_DESMONTAR11.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR11.TabIndex = 209
        Me.TKMS_DESMONTAR11.Tag = Nothing
        Me.TKMS_DESMONTAR11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR11
        '
        Me.TKMS_MONTAR11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR11.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR11.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR11.InterceptArrowKeys = False
        Me.TKMS_MONTAR11.Location = New System.Drawing.Point(582, 259)
        Me.TKMS_MONTAR11.Name = "TKMS_MONTAR11"
        Me.TKMS_MONTAR11.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR11.TabIndex = 207
        Me.TKMS_MONTAR11.Tag = Nothing
        Me.TKMS_MONTAR11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION11
        '
        Me.TPOSICION11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION11.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION11.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION11.InterceptArrowKeys = False
        Me.TPOSICION11.Location = New System.Drawing.Point(1086, 259)
        Me.TPOSICION11.MaxLength = 5
        Me.TPOSICION11.Name = "TPOSICION11"
        Me.TPOSICION11.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION11.TabIndex = 217
        Me.TPOSICION11.Tag = Nothing
        Me.TPOSICION11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA11
        '
        Me.TCOSTO_LLANTA11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA11.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA11.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA11.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA11.Location = New System.Drawing.Point(524, 259)
        Me.TCOSTO_LLANTA11.Name = "TCOSTO_LLANTA11"
        Me.TCOSTO_LLANTA11.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA11.TabIndex = 206
        Me.TCOSTO_LLANTA11.Tag = Nothing
        Me.TCOSTO_LLANTA11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA11
        '
        Me.TTIPO_LLANTA11.AcceptsReturn = True
        Me.TTIPO_LLANTA11.AcceptsTab = True
        Me.TTIPO_LLANTA11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA11.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA11.Location = New System.Drawing.Point(281, 258)
        Me.TTIPO_LLANTA11.MaxLength = 10
        Me.TTIPO_LLANTA11.Name = "TTIPO_LLANTA11"
        Me.TTIPO_LLANTA11.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA11.TabIndex = 203
        Me.TTIPO_LLANTA11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA11
        '
        Me.TMARCA11.AcceptsReturn = True
        Me.TMARCA11.AcceptsTab = True
        Me.TMARCA11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA11.ForeColor = System.Drawing.Color.Black
        Me.TMARCA11.Location = New System.Drawing.Point(110, 258)
        Me.TMARCA11.MaxLength = 10
        Me.TMARCA11.Name = "TMARCA11"
        Me.TMARCA11.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA11.TabIndex = 201
        Me.TMARCA11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO11
        '
        Me.TMODELO11.AcceptsReturn = True
        Me.TMODELO11.AcceptsTab = True
        Me.TMODELO11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO11.ForeColor = System.Drawing.Color.Black
        Me.TMODELO11.Location = New System.Drawing.Point(210, 258)
        Me.TMODELO11.MaxLength = 10
        Me.TMODELO11.Name = "TMODELO11"
        Me.TMODELO11.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO11.TabIndex = 202
        Me.TMODELO11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS10
        '
        Me.TKM_RECORRIDOS10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS10.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_RECORRIDOS10.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS10.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_RECORRIDOS10.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_RECORRIDOS10.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS10.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS10.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS10.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS10.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS10.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS10.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS10.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS10.Location = New System.Drawing.Point(819, 237)
        Me.TKM_RECORRIDOS10.Name = "TKM_RECORRIDOS10"
        Me.TKM_RECORRIDOS10.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS10.TabIndex = 191
        Me.TKM_RECORRIDOS10.Tag = Nothing
        Me.TKM_RECORRIDOS10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS10.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS10.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE10
        '
        Me.TFECHA_MONTAJE10.AcceptsReturn = True
        Me.TFECHA_MONTAJE10.AcceptsTab = True
        Me.TFECHA_MONTAJE10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE10.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE10.Location = New System.Drawing.Point(443, 236)
        Me.TFECHA_MONTAJE10.MaxLength = 10
        Me.TFECHA_MONTAJE10.Name = "TFECHA_MONTAJE10"
        Me.TFECHA_MONTAJE10.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE10.TabIndex = 185
        Me.TFECHA_MONTAJE10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA10
        '
        Me.TNUEVA_RENOVADA10.AcceptsReturn = True
        Me.TNUEVA_RENOVADA10.AcceptsTab = True
        Me.TNUEVA_RENOVADA10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA10.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA10.Location = New System.Drawing.Point(362, 236)
        Me.TNUEVA_RENOVADA10.MaxLength = 10
        Me.TNUEVA_RENOVADA10.Name = "TNUEVA_RENOVADA10"
        Me.TNUEVA_RENOVADA10.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA10.TabIndex = 184
        Me.TNUEVA_RENOVADA10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs10
        '
        Me.TObs10.AcceptsReturn = True
        Me.TObs10.AcceptsTab = True
        Me.TObs10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs10.ForeColor = System.Drawing.Color.Black
        Me.TObs10.Location = New System.Drawing.Point(1288, 236)
        Me.TObs10.MaxLength = 255
        Me.TObs10.Multiline = True
        Me.TObs10.Name = "TObs10"
        Me.TObs10.Size = New System.Drawing.Size(154, 20)
        Me.TObs10.TabIndex = 199
        '
        'TPROFUNDIDAD_ACTUAL110
        '
        Me.TPROFUNDIDAD_ACTUAL110.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL110.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL110.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL110.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL110.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL110.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL110.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL110.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL110.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL110.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL110.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL110.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL110.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL110.Location = New System.Drawing.Point(876, 237)
        Me.TPROFUNDIDAD_ACTUAL110.Name = "TPROFUNDIDAD_ACTUAL110"
        Me.TPROFUNDIDAD_ACTUAL110.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL110.TabIndex = 192
        Me.TPROFUNDIDAD_ACTUAL110.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL110.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL110.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL110.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL110.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL10
        '
        Me.TPROFUNDIDA_ORIGINAL10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL10.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL10.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL10.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL10.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL10.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL10.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL10.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL10.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL10.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL10.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL10.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL10.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL10.Location = New System.Drawing.Point(650, 237)
        Me.TPROFUNDIDA_ORIGINAL10.Name = "TPROFUNDIDA_ORIGINAL10"
        Me.TPROFUNDIDA_ORIGINAL10.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL10.TabIndex = 188
        Me.TPROFUNDIDA_ORIGINAL10.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL10.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL10.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE10
        '
        Me.TDESGASTE10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE10.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE10.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE10.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE10.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE10.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE10.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE10.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE10.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE10.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE10.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE10.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE10.InterceptArrowKeys = False
        Me.TDESGASTE10.Location = New System.Drawing.Point(1127, 237)
        Me.TDESGASTE10.Name = "TDESGASTE10"
        Me.TDESGASTE10.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE10.TabIndex = 198
        Me.TDESGASTE10.Tag = Nothing
        Me.TDESGASTE10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE10.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE10.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR10
        '
        Me.TKMS_DESMONTAR10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR10.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR10.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR10.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR10.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR10.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR10.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR10.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR10.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR10.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR10.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR10.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR10.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR10.Location = New System.Drawing.Point(698, 237)
        Me.TKMS_DESMONTAR10.Name = "TKMS_DESMONTAR10"
        Me.TKMS_DESMONTAR10.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR10.TabIndex = 189
        Me.TKMS_DESMONTAR10.Tag = Nothing
        Me.TKMS_DESMONTAR10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR10.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR10.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR10
        '
        Me.TKMS_MONTAR10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR10.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR10.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR10.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR10.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR10.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR10.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR10.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR10.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR10.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR10.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR10.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR10.InterceptArrowKeys = False
        Me.TKMS_MONTAR10.Location = New System.Drawing.Point(582, 237)
        Me.TKMS_MONTAR10.Name = "TKMS_MONTAR10"
        Me.TKMS_MONTAR10.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR10.TabIndex = 187
        Me.TKMS_MONTAR10.Tag = Nothing
        Me.TKMS_MONTAR10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR10.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR10.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION10
        '
        Me.TPOSICION10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION10.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION10.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION10.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION10.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION10.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION10.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION10.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION10.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION10.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION10.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION10.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION10.InterceptArrowKeys = False
        Me.TPOSICION10.Location = New System.Drawing.Point(1086, 237)
        Me.TPOSICION10.MaxLength = 5
        Me.TPOSICION10.Name = "TPOSICION10"
        Me.TPOSICION10.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION10.TabIndex = 197
        Me.TPOSICION10.Tag = Nothing
        Me.TPOSICION10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION10.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION10.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA10
        '
        Me.TCOSTO_LLANTA10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA10.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA10.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA10.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA10.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA10.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA10.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA10.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA10.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA10.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA10.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA10.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA10.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA10.Location = New System.Drawing.Point(524, 237)
        Me.TCOSTO_LLANTA10.Name = "TCOSTO_LLANTA10"
        Me.TCOSTO_LLANTA10.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA10.TabIndex = 186
        Me.TCOSTO_LLANTA10.Tag = Nothing
        Me.TCOSTO_LLANTA10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA10.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA10.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA10
        '
        Me.TTIPO_LLANTA10.AcceptsReturn = True
        Me.TTIPO_LLANTA10.AcceptsTab = True
        Me.TTIPO_LLANTA10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA10.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA10.Location = New System.Drawing.Point(281, 236)
        Me.TTIPO_LLANTA10.MaxLength = 10
        Me.TTIPO_LLANTA10.Name = "TTIPO_LLANTA10"
        Me.TTIPO_LLANTA10.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA10.TabIndex = 183
        Me.TTIPO_LLANTA10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA10
        '
        Me.TMARCA10.AcceptsReturn = True
        Me.TMARCA10.AcceptsTab = True
        Me.TMARCA10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA10.ForeColor = System.Drawing.Color.Black
        Me.TMARCA10.Location = New System.Drawing.Point(110, 236)
        Me.TMARCA10.MaxLength = 10
        Me.TMARCA10.Name = "TMARCA10"
        Me.TMARCA10.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA10.TabIndex = 181
        Me.TMARCA10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO10
        '
        Me.TMODELO10.AcceptsReturn = True
        Me.TMODELO10.AcceptsTab = True
        Me.TMODELO10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO10.ForeColor = System.Drawing.Color.Black
        Me.TMODELO10.Location = New System.Drawing.Point(210, 236)
        Me.TMODELO10.MaxLength = 10
        Me.TMODELO10.Name = "TMODELO10"
        Me.TMODELO10.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO10.TabIndex = 182
        Me.TMODELO10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS9
        '
        Me.TKM_RECORRIDOS9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS9.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKM_RECORRIDOS9.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS9.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS9.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS9.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS9.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS9.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS9.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS9.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS9.Location = New System.Drawing.Point(819, 215)
        Me.TKM_RECORRIDOS9.Name = "TKM_RECORRIDOS9"
        Me.TKM_RECORRIDOS9.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS9.TabIndex = 171
        Me.TKM_RECORRIDOS9.Tag = Nothing
        Me.TKM_RECORRIDOS9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS9.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS9.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS9.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE9
        '
        Me.TFECHA_MONTAJE9.AcceptsReturn = True
        Me.TFECHA_MONTAJE9.AcceptsTab = True
        Me.TFECHA_MONTAJE9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE9.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE9.Location = New System.Drawing.Point(443, 214)
        Me.TFECHA_MONTAJE9.MaxLength = 10
        Me.TFECHA_MONTAJE9.Name = "TFECHA_MONTAJE9"
        Me.TFECHA_MONTAJE9.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE9.TabIndex = 165
        Me.TFECHA_MONTAJE9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA9
        '
        Me.TNUEVA_RENOVADA9.AcceptsReturn = True
        Me.TNUEVA_RENOVADA9.AcceptsTab = True
        Me.TNUEVA_RENOVADA9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA9.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA9.Location = New System.Drawing.Point(362, 214)
        Me.TNUEVA_RENOVADA9.MaxLength = 10
        Me.TNUEVA_RENOVADA9.Name = "TNUEVA_RENOVADA9"
        Me.TNUEVA_RENOVADA9.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA9.TabIndex = 164
        Me.TNUEVA_RENOVADA9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs9
        '
        Me.TObs9.AcceptsReturn = True
        Me.TObs9.AcceptsTab = True
        Me.TObs9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs9.ForeColor = System.Drawing.Color.Black
        Me.TObs9.Location = New System.Drawing.Point(1288, 214)
        Me.TObs9.MaxLength = 255
        Me.TObs9.Multiline = True
        Me.TObs9.Name = "TObs9"
        Me.TObs9.Size = New System.Drawing.Size(154, 20)
        Me.TObs9.TabIndex = 179
        '
        'TPROFUNDIDAD_ACTUAL19
        '
        Me.TPROFUNDIDAD_ACTUAL19.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL19.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL19.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL19.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL19.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL19.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL19.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL19.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL19.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL19.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL19.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL19.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL19.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL19.Location = New System.Drawing.Point(876, 215)
        Me.TPROFUNDIDAD_ACTUAL19.Name = "TPROFUNDIDAD_ACTUAL19"
        Me.TPROFUNDIDAD_ACTUAL19.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL19.TabIndex = 172
        Me.TPROFUNDIDAD_ACTUAL19.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL19.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL19.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL19.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL9
        '
        Me.TPROFUNDIDA_ORIGINAL9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL9.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL9.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL9.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL9.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL9.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL9.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL9.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL9.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL9.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL9.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL9.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL9.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL9.Location = New System.Drawing.Point(650, 215)
        Me.TPROFUNDIDA_ORIGINAL9.Name = "TPROFUNDIDA_ORIGINAL9"
        Me.TPROFUNDIDA_ORIGINAL9.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL9.TabIndex = 168
        Me.TPROFUNDIDA_ORIGINAL9.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL9.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL9.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL9.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE9
        '
        Me.TDESGASTE9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE9.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE9.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE9.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE9.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE9.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE9.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE9.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE9.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE9.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE9.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE9.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE9.InterceptArrowKeys = False
        Me.TDESGASTE9.Location = New System.Drawing.Point(1127, 215)
        Me.TDESGASTE9.Name = "TDESGASTE9"
        Me.TDESGASTE9.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE9.TabIndex = 178
        Me.TDESGASTE9.Tag = Nothing
        Me.TDESGASTE9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE9.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE9.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE9.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR9
        '
        Me.TKMS_DESMONTAR9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR9.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR9.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR9.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR9.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR9.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR9.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR9.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR9.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR9.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR9.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR9.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR9.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR9.Location = New System.Drawing.Point(698, 215)
        Me.TKMS_DESMONTAR9.Name = "TKMS_DESMONTAR9"
        Me.TKMS_DESMONTAR9.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR9.TabIndex = 169
        Me.TKMS_DESMONTAR9.Tag = Nothing
        Me.TKMS_DESMONTAR9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR9.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR9.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR9.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR9
        '
        Me.TKMS_MONTAR9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR9.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR9.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR9.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR9.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR9.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR9.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR9.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR9.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR9.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR9.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR9.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR9.InterceptArrowKeys = False
        Me.TKMS_MONTAR9.Location = New System.Drawing.Point(582, 215)
        Me.TKMS_MONTAR9.Name = "TKMS_MONTAR9"
        Me.TKMS_MONTAR9.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR9.TabIndex = 167
        Me.TKMS_MONTAR9.Tag = Nothing
        Me.TKMS_MONTAR9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR9.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR9.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR9.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION9
        '
        Me.TPOSICION9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION9.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION9.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION9.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION9.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION9.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION9.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION9.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION9.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION9.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION9.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION9.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION9.InterceptArrowKeys = False
        Me.TPOSICION9.Location = New System.Drawing.Point(1086, 215)
        Me.TPOSICION9.MaxLength = 5
        Me.TPOSICION9.Name = "TPOSICION9"
        Me.TPOSICION9.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION9.TabIndex = 177
        Me.TPOSICION9.Tag = Nothing
        Me.TPOSICION9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION9.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION9.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION9.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA9
        '
        Me.TCOSTO_LLANTA9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA9.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA9.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA9.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA9.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA9.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA9.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA9.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA9.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA9.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA9.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA9.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA9.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA9.Location = New System.Drawing.Point(524, 215)
        Me.TCOSTO_LLANTA9.Name = "TCOSTO_LLANTA9"
        Me.TCOSTO_LLANTA9.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA9.TabIndex = 166
        Me.TCOSTO_LLANTA9.Tag = Nothing
        Me.TCOSTO_LLANTA9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA9.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA9.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA9.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA9
        '
        Me.TTIPO_LLANTA9.AcceptsReturn = True
        Me.TTIPO_LLANTA9.AcceptsTab = True
        Me.TTIPO_LLANTA9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA9.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA9.Location = New System.Drawing.Point(281, 214)
        Me.TTIPO_LLANTA9.MaxLength = 10
        Me.TTIPO_LLANTA9.Name = "TTIPO_LLANTA9"
        Me.TTIPO_LLANTA9.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA9.TabIndex = 163
        Me.TTIPO_LLANTA9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA9
        '
        Me.TMARCA9.AcceptsReturn = True
        Me.TMARCA9.AcceptsTab = True
        Me.TMARCA9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA9.ForeColor = System.Drawing.Color.Black
        Me.TMARCA9.Location = New System.Drawing.Point(110, 214)
        Me.TMARCA9.MaxLength = 10
        Me.TMARCA9.Name = "TMARCA9"
        Me.TMARCA9.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA9.TabIndex = 161
        Me.TMARCA9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO9
        '
        Me.TMODELO9.AcceptsReturn = True
        Me.TMODELO9.AcceptsTab = True
        Me.TMODELO9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO9.ForeColor = System.Drawing.Color.Black
        Me.TMODELO9.Location = New System.Drawing.Point(210, 214)
        Me.TMODELO9.MaxLength = 10
        Me.TMODELO9.Name = "TMODELO9"
        Me.TMODELO9.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO9.TabIndex = 162
        Me.TMODELO9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS8
        '
        Me.TKM_RECORRIDOS8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS8.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_RECORRIDOS8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS8.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_RECORRIDOS8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_RECORRIDOS8.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS8.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS8.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS8.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS8.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS8.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS8.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS8.Location = New System.Drawing.Point(819, 192)
        Me.TKM_RECORRIDOS8.Name = "TKM_RECORRIDOS8"
        Me.TKM_RECORRIDOS8.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS8.TabIndex = 151
        Me.TKM_RECORRIDOS8.Tag = Nothing
        Me.TKM_RECORRIDOS8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS8.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE8
        '
        Me.TFECHA_MONTAJE8.AcceptsReturn = True
        Me.TFECHA_MONTAJE8.AcceptsTab = True
        Me.TFECHA_MONTAJE8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE8.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE8.Location = New System.Drawing.Point(443, 191)
        Me.TFECHA_MONTAJE8.MaxLength = 10
        Me.TFECHA_MONTAJE8.Name = "TFECHA_MONTAJE8"
        Me.TFECHA_MONTAJE8.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE8.TabIndex = 145
        Me.TFECHA_MONTAJE8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA8
        '
        Me.TNUEVA_RENOVADA8.AcceptsReturn = True
        Me.TNUEVA_RENOVADA8.AcceptsTab = True
        Me.TNUEVA_RENOVADA8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA8.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA8.Location = New System.Drawing.Point(362, 191)
        Me.TNUEVA_RENOVADA8.MaxLength = 10
        Me.TNUEVA_RENOVADA8.Name = "TNUEVA_RENOVADA8"
        Me.TNUEVA_RENOVADA8.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA8.TabIndex = 144
        Me.TNUEVA_RENOVADA8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs8
        '
        Me.TObs8.AcceptsReturn = True
        Me.TObs8.AcceptsTab = True
        Me.TObs8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs8.ForeColor = System.Drawing.Color.Black
        Me.TObs8.Location = New System.Drawing.Point(1288, 191)
        Me.TObs8.MaxLength = 255
        Me.TObs8.Multiline = True
        Me.TObs8.Name = "TObs8"
        Me.TObs8.Size = New System.Drawing.Size(154, 20)
        Me.TObs8.TabIndex = 159
        '
        'TPROFUNDIDAD_ACTUAL18
        '
        Me.TPROFUNDIDAD_ACTUAL18.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL18.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL18.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL18.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL18.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL18.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL18.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL18.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL18.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL18.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL18.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL18.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL18.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL18.Location = New System.Drawing.Point(876, 192)
        Me.TPROFUNDIDAD_ACTUAL18.Name = "TPROFUNDIDAD_ACTUAL18"
        Me.TPROFUNDIDAD_ACTUAL18.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL18.TabIndex = 152
        Me.TPROFUNDIDAD_ACTUAL18.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL18.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL18.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL18.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL8
        '
        Me.TPROFUNDIDA_ORIGINAL8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL8.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL8.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL8.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL8.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL8.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL8.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL8.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL8.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL8.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL8.Location = New System.Drawing.Point(650, 192)
        Me.TPROFUNDIDA_ORIGINAL8.Name = "TPROFUNDIDA_ORIGINAL8"
        Me.TPROFUNDIDA_ORIGINAL8.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL8.TabIndex = 148
        Me.TPROFUNDIDA_ORIGINAL8.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL8.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE8
        '
        Me.TDESGASTE8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE8.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE8.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE8.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE8.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE8.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE8.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE8.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE8.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE8.InterceptArrowKeys = False
        Me.TDESGASTE8.Location = New System.Drawing.Point(1127, 192)
        Me.TDESGASTE8.Name = "TDESGASTE8"
        Me.TDESGASTE8.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE8.TabIndex = 158
        Me.TDESGASTE8.Tag = Nothing
        Me.TDESGASTE8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE8.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR8
        '
        Me.TKMS_DESMONTAR8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR8.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR8.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR8.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR8.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR8.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR8.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR8.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR8.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR8.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR8.Location = New System.Drawing.Point(698, 192)
        Me.TKMS_DESMONTAR8.Name = "TKMS_DESMONTAR8"
        Me.TKMS_DESMONTAR8.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR8.TabIndex = 149
        Me.TKMS_DESMONTAR8.Tag = Nothing
        Me.TKMS_DESMONTAR8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR8.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR8
        '
        Me.TKMS_MONTAR8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR8.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR8.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR8.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR8.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR8.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR8.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR8.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR8.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR8.InterceptArrowKeys = False
        Me.TKMS_MONTAR8.Location = New System.Drawing.Point(582, 192)
        Me.TKMS_MONTAR8.Name = "TKMS_MONTAR8"
        Me.TKMS_MONTAR8.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR8.TabIndex = 147
        Me.TKMS_MONTAR8.Tag = Nothing
        Me.TKMS_MONTAR8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR8.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION8
        '
        Me.TPOSICION8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION8.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION8.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION8.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION8.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION8.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION8.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION8.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION8.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION8.InterceptArrowKeys = False
        Me.TPOSICION8.Location = New System.Drawing.Point(1086, 192)
        Me.TPOSICION8.MaxLength = 5
        Me.TPOSICION8.Name = "TPOSICION8"
        Me.TPOSICION8.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION8.TabIndex = 157
        Me.TPOSICION8.Tag = Nothing
        Me.TPOSICION8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION8.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA8
        '
        Me.TCOSTO_LLANTA8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA8.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA8.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA8.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA8.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA8.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA8.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA8.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA8.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA8.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA8.Location = New System.Drawing.Point(524, 192)
        Me.TCOSTO_LLANTA8.Name = "TCOSTO_LLANTA8"
        Me.TCOSTO_LLANTA8.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA8.TabIndex = 146
        Me.TCOSTO_LLANTA8.Tag = Nothing
        Me.TCOSTO_LLANTA8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA8.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA8
        '
        Me.TTIPO_LLANTA8.AcceptsReturn = True
        Me.TTIPO_LLANTA8.AcceptsTab = True
        Me.TTIPO_LLANTA8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA8.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA8.Location = New System.Drawing.Point(281, 191)
        Me.TTIPO_LLANTA8.MaxLength = 10
        Me.TTIPO_LLANTA8.Name = "TTIPO_LLANTA8"
        Me.TTIPO_LLANTA8.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA8.TabIndex = 143
        Me.TTIPO_LLANTA8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA8
        '
        Me.TMARCA8.AcceptsReturn = True
        Me.TMARCA8.AcceptsTab = True
        Me.TMARCA8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA8.ForeColor = System.Drawing.Color.Black
        Me.TMARCA8.Location = New System.Drawing.Point(110, 191)
        Me.TMARCA8.MaxLength = 10
        Me.TMARCA8.Name = "TMARCA8"
        Me.TMARCA8.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA8.TabIndex = 141
        Me.TMARCA8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO8
        '
        Me.TMODELO8.AcceptsReturn = True
        Me.TMODELO8.AcceptsTab = True
        Me.TMODELO8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO8.ForeColor = System.Drawing.Color.Black
        Me.TMODELO8.Location = New System.Drawing.Point(210, 191)
        Me.TMODELO8.MaxLength = 10
        Me.TMODELO8.Name = "TMODELO8"
        Me.TMODELO8.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO8.TabIndex = 142
        Me.TMODELO8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS7
        '
        Me.TKM_RECORRIDOS7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS7.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKM_RECORRIDOS7.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS7.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS7.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS7.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS7.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS7.Location = New System.Drawing.Point(819, 170)
        Me.TKM_RECORRIDOS7.Name = "TKM_RECORRIDOS7"
        Me.TKM_RECORRIDOS7.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS7.TabIndex = 131
        Me.TKM_RECORRIDOS7.Tag = Nothing
        Me.TKM_RECORRIDOS7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS7.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE7
        '
        Me.TFECHA_MONTAJE7.AcceptsReturn = True
        Me.TFECHA_MONTAJE7.AcceptsTab = True
        Me.TFECHA_MONTAJE7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE7.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE7.Location = New System.Drawing.Point(443, 169)
        Me.TFECHA_MONTAJE7.MaxLength = 10
        Me.TFECHA_MONTAJE7.Name = "TFECHA_MONTAJE7"
        Me.TFECHA_MONTAJE7.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE7.TabIndex = 125
        Me.TFECHA_MONTAJE7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA7
        '
        Me.TNUEVA_RENOVADA7.AcceptsReturn = True
        Me.TNUEVA_RENOVADA7.AcceptsTab = True
        Me.TNUEVA_RENOVADA7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA7.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA7.Location = New System.Drawing.Point(362, 169)
        Me.TNUEVA_RENOVADA7.MaxLength = 10
        Me.TNUEVA_RENOVADA7.Name = "TNUEVA_RENOVADA7"
        Me.TNUEVA_RENOVADA7.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA7.TabIndex = 124
        Me.TNUEVA_RENOVADA7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs7
        '
        Me.TObs7.AcceptsReturn = True
        Me.TObs7.AcceptsTab = True
        Me.TObs7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs7.ForeColor = System.Drawing.Color.Black
        Me.TObs7.Location = New System.Drawing.Point(1288, 169)
        Me.TObs7.MaxLength = 255
        Me.TObs7.Multiline = True
        Me.TObs7.Name = "TObs7"
        Me.TObs7.Size = New System.Drawing.Size(154, 20)
        Me.TObs7.TabIndex = 139
        '
        'TPROFUNDIDAD_ACTUAL17
        '
        Me.TPROFUNDIDAD_ACTUAL17.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL17.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL17.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL17.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL17.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL17.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL17.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL17.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL17.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL17.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL17.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL17.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL17.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL17.Location = New System.Drawing.Point(876, 170)
        Me.TPROFUNDIDAD_ACTUAL17.Name = "TPROFUNDIDAD_ACTUAL17"
        Me.TPROFUNDIDAD_ACTUAL17.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL17.TabIndex = 132
        Me.TPROFUNDIDAD_ACTUAL17.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL17.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL17.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL17.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL7
        '
        Me.TPROFUNDIDA_ORIGINAL7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL7.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL7.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL7.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL7.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL7.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL7.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL7.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL7.Location = New System.Drawing.Point(650, 170)
        Me.TPROFUNDIDA_ORIGINAL7.Name = "TPROFUNDIDA_ORIGINAL7"
        Me.TPROFUNDIDA_ORIGINAL7.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL7.TabIndex = 128
        Me.TPROFUNDIDA_ORIGINAL7.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL7.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE7
        '
        Me.TDESGASTE7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE7.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE7.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE7.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE7.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE7.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE7.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE7.InterceptArrowKeys = False
        Me.TDESGASTE7.Location = New System.Drawing.Point(1127, 170)
        Me.TDESGASTE7.Name = "TDESGASTE7"
        Me.TDESGASTE7.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE7.TabIndex = 138
        Me.TDESGASTE7.Tag = Nothing
        Me.TDESGASTE7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE7.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR7
        '
        Me.TKMS_DESMONTAR7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR7.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR7.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR7.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR7.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR7.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR7.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR7.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR7.Location = New System.Drawing.Point(698, 170)
        Me.TKMS_DESMONTAR7.Name = "TKMS_DESMONTAR7"
        Me.TKMS_DESMONTAR7.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR7.TabIndex = 129
        Me.TKMS_DESMONTAR7.Tag = Nothing
        Me.TKMS_DESMONTAR7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR7.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR7
        '
        Me.TKMS_MONTAR7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR7.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR7.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR7.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR7.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR7.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR7.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR7.InterceptArrowKeys = False
        Me.TKMS_MONTAR7.Location = New System.Drawing.Point(582, 170)
        Me.TKMS_MONTAR7.Name = "TKMS_MONTAR7"
        Me.TKMS_MONTAR7.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR7.TabIndex = 127
        Me.TKMS_MONTAR7.Tag = Nothing
        Me.TKMS_MONTAR7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR7.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION7
        '
        Me.TPOSICION7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION7.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION7.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION7.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION7.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION7.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION7.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION7.InterceptArrowKeys = False
        Me.TPOSICION7.Location = New System.Drawing.Point(1086, 170)
        Me.TPOSICION7.MaxLength = 5
        Me.TPOSICION7.Name = "TPOSICION7"
        Me.TPOSICION7.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION7.TabIndex = 137
        Me.TPOSICION7.Tag = Nothing
        Me.TPOSICION7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION7.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA7
        '
        Me.TCOSTO_LLANTA7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA7.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA7.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA7.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA7.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA7.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA7.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA7.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA7.Location = New System.Drawing.Point(524, 170)
        Me.TCOSTO_LLANTA7.Name = "TCOSTO_LLANTA7"
        Me.TCOSTO_LLANTA7.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA7.TabIndex = 126
        Me.TCOSTO_LLANTA7.Tag = Nothing
        Me.TCOSTO_LLANTA7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA7.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA7
        '
        Me.TTIPO_LLANTA7.AcceptsReturn = True
        Me.TTIPO_LLANTA7.AcceptsTab = True
        Me.TTIPO_LLANTA7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA7.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA7.Location = New System.Drawing.Point(281, 169)
        Me.TTIPO_LLANTA7.MaxLength = 10
        Me.TTIPO_LLANTA7.Name = "TTIPO_LLANTA7"
        Me.TTIPO_LLANTA7.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA7.TabIndex = 123
        Me.TTIPO_LLANTA7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA7
        '
        Me.TMARCA7.AcceptsReturn = True
        Me.TMARCA7.AcceptsTab = True
        Me.TMARCA7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA7.ForeColor = System.Drawing.Color.Black
        Me.TMARCA7.Location = New System.Drawing.Point(110, 169)
        Me.TMARCA7.MaxLength = 10
        Me.TMARCA7.Name = "TMARCA7"
        Me.TMARCA7.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA7.TabIndex = 121
        Me.TMARCA7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO7
        '
        Me.TMODELO7.AcceptsReturn = True
        Me.TMODELO7.AcceptsTab = True
        Me.TMODELO7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO7.ForeColor = System.Drawing.Color.Black
        Me.TMODELO7.Location = New System.Drawing.Point(210, 169)
        Me.TMODELO7.MaxLength = 10
        Me.TMODELO7.Name = "TMODELO7"
        Me.TMODELO7.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO7.TabIndex = 122
        Me.TMODELO7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS6
        '
        Me.TKM_RECORRIDOS6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS6.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_RECORRIDOS6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS6.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_RECORRIDOS6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_RECORRIDOS6.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS6.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS6.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS6.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS6.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS6.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS6.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS6.Location = New System.Drawing.Point(819, 148)
        Me.TKM_RECORRIDOS6.Name = "TKM_RECORRIDOS6"
        Me.TKM_RECORRIDOS6.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS6.TabIndex = 111
        Me.TKM_RECORRIDOS6.Tag = Nothing
        Me.TKM_RECORRIDOS6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE6
        '
        Me.TFECHA_MONTAJE6.AcceptsReturn = True
        Me.TFECHA_MONTAJE6.AcceptsTab = True
        Me.TFECHA_MONTAJE6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE6.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE6.Location = New System.Drawing.Point(443, 147)
        Me.TFECHA_MONTAJE6.MaxLength = 10
        Me.TFECHA_MONTAJE6.Name = "TFECHA_MONTAJE6"
        Me.TFECHA_MONTAJE6.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE6.TabIndex = 105
        Me.TFECHA_MONTAJE6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA6
        '
        Me.TNUEVA_RENOVADA6.AcceptsReturn = True
        Me.TNUEVA_RENOVADA6.AcceptsTab = True
        Me.TNUEVA_RENOVADA6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA6.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA6.Location = New System.Drawing.Point(362, 147)
        Me.TNUEVA_RENOVADA6.MaxLength = 10
        Me.TNUEVA_RENOVADA6.Name = "TNUEVA_RENOVADA6"
        Me.TNUEVA_RENOVADA6.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA6.TabIndex = 104
        Me.TNUEVA_RENOVADA6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs6
        '
        Me.TObs6.AcceptsReturn = True
        Me.TObs6.AcceptsTab = True
        Me.TObs6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs6.ForeColor = System.Drawing.Color.Black
        Me.TObs6.Location = New System.Drawing.Point(1288, 147)
        Me.TObs6.MaxLength = 255
        Me.TObs6.Multiline = True
        Me.TObs6.Name = "TObs6"
        Me.TObs6.Size = New System.Drawing.Size(154, 20)
        Me.TObs6.TabIndex = 119
        '
        'TPROFUNDIDAD_ACTUAL16
        '
        Me.TPROFUNDIDAD_ACTUAL16.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL16.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL16.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL16.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL16.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL16.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL16.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL16.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL16.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL16.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL16.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL16.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL16.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL16.Location = New System.Drawing.Point(876, 148)
        Me.TPROFUNDIDAD_ACTUAL16.Name = "TPROFUNDIDAD_ACTUAL16"
        Me.TPROFUNDIDAD_ACTUAL16.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL16.TabIndex = 112
        Me.TPROFUNDIDAD_ACTUAL16.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL16.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL16.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL16.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL6
        '
        Me.TPROFUNDIDA_ORIGINAL6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL6.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL6.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL6.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL6.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL6.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL6.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL6.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL6.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL6.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL6.Location = New System.Drawing.Point(650, 148)
        Me.TPROFUNDIDA_ORIGINAL6.Name = "TPROFUNDIDA_ORIGINAL6"
        Me.TPROFUNDIDA_ORIGINAL6.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL6.TabIndex = 108
        Me.TPROFUNDIDA_ORIGINAL6.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE6
        '
        Me.TDESGASTE6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE6.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE6.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE6.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE6.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE6.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE6.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE6.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE6.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE6.InterceptArrowKeys = False
        Me.TDESGASTE6.Location = New System.Drawing.Point(1127, 148)
        Me.TDESGASTE6.Name = "TDESGASTE6"
        Me.TDESGASTE6.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE6.TabIndex = 118
        Me.TDESGASTE6.Tag = Nothing
        Me.TDESGASTE6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR6
        '
        Me.TKMS_DESMONTAR6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR6.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR6.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR6.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR6.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR6.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR6.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR6.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR6.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR6.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR6.Location = New System.Drawing.Point(698, 148)
        Me.TKMS_DESMONTAR6.Name = "TKMS_DESMONTAR6"
        Me.TKMS_DESMONTAR6.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR6.TabIndex = 109
        Me.TKMS_DESMONTAR6.Tag = Nothing
        Me.TKMS_DESMONTAR6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR6
        '
        Me.TKMS_MONTAR6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR6.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR6.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR6.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR6.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR6.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR6.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR6.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR6.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR6.InterceptArrowKeys = False
        Me.TKMS_MONTAR6.Location = New System.Drawing.Point(582, 148)
        Me.TKMS_MONTAR6.Name = "TKMS_MONTAR6"
        Me.TKMS_MONTAR6.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR6.TabIndex = 107
        Me.TKMS_MONTAR6.Tag = Nothing
        Me.TKMS_MONTAR6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION6
        '
        Me.TPOSICION6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION6.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION6.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION6.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION6.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION6.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION6.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION6.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION6.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION6.InterceptArrowKeys = False
        Me.TPOSICION6.Location = New System.Drawing.Point(1086, 148)
        Me.TPOSICION6.MaxLength = 5
        Me.TPOSICION6.Name = "TPOSICION6"
        Me.TPOSICION6.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION6.TabIndex = 117
        Me.TPOSICION6.Tag = Nothing
        Me.TPOSICION6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA6
        '
        Me.TCOSTO_LLANTA6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA6.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA6.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA6.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA6.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA6.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA6.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA6.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA6.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA6.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA6.Location = New System.Drawing.Point(524, 148)
        Me.TCOSTO_LLANTA6.Name = "TCOSTO_LLANTA6"
        Me.TCOSTO_LLANTA6.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA6.TabIndex = 106
        Me.TCOSTO_LLANTA6.Tag = Nothing
        Me.TCOSTO_LLANTA6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA6
        '
        Me.TTIPO_LLANTA6.AcceptsReturn = True
        Me.TTIPO_LLANTA6.AcceptsTab = True
        Me.TTIPO_LLANTA6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA6.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA6.Location = New System.Drawing.Point(281, 147)
        Me.TTIPO_LLANTA6.MaxLength = 10
        Me.TTIPO_LLANTA6.Name = "TTIPO_LLANTA6"
        Me.TTIPO_LLANTA6.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA6.TabIndex = 103
        Me.TTIPO_LLANTA6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA6
        '
        Me.TMARCA6.AcceptsReturn = True
        Me.TMARCA6.AcceptsTab = True
        Me.TMARCA6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA6.ForeColor = System.Drawing.Color.Black
        Me.TMARCA6.Location = New System.Drawing.Point(110, 147)
        Me.TMARCA6.MaxLength = 10
        Me.TMARCA6.Name = "TMARCA6"
        Me.TMARCA6.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA6.TabIndex = 101
        Me.TMARCA6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO6
        '
        Me.TMODELO6.AcceptsReturn = True
        Me.TMODELO6.AcceptsTab = True
        Me.TMODELO6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO6.ForeColor = System.Drawing.Color.Black
        Me.TMODELO6.Location = New System.Drawing.Point(210, 147)
        Me.TMODELO6.MaxLength = 10
        Me.TMODELO6.Name = "TMODELO6"
        Me.TMODELO6.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO6.TabIndex = 102
        Me.TMODELO6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS5
        '
        Me.TKM_RECORRIDOS5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS5.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKM_RECORRIDOS5.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS5.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS5.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS5.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS5.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS5.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS5.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS5.Location = New System.Drawing.Point(819, 126)
        Me.TKM_RECORRIDOS5.Name = "TKM_RECORRIDOS5"
        Me.TKM_RECORRIDOS5.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS5.TabIndex = 91
        Me.TKM_RECORRIDOS5.Tag = Nothing
        Me.TKM_RECORRIDOS5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE5
        '
        Me.TFECHA_MONTAJE5.AcceptsReturn = True
        Me.TFECHA_MONTAJE5.AcceptsTab = True
        Me.TFECHA_MONTAJE5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE5.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE5.Location = New System.Drawing.Point(443, 125)
        Me.TFECHA_MONTAJE5.MaxLength = 10
        Me.TFECHA_MONTAJE5.Name = "TFECHA_MONTAJE5"
        Me.TFECHA_MONTAJE5.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE5.TabIndex = 85
        Me.TFECHA_MONTAJE5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA5
        '
        Me.TNUEVA_RENOVADA5.AcceptsReturn = True
        Me.TNUEVA_RENOVADA5.AcceptsTab = True
        Me.TNUEVA_RENOVADA5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA5.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA5.Location = New System.Drawing.Point(362, 125)
        Me.TNUEVA_RENOVADA5.MaxLength = 10
        Me.TNUEVA_RENOVADA5.Name = "TNUEVA_RENOVADA5"
        Me.TNUEVA_RENOVADA5.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA5.TabIndex = 84
        Me.TNUEVA_RENOVADA5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs5
        '
        Me.TObs5.AcceptsReturn = True
        Me.TObs5.AcceptsTab = True
        Me.TObs5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs5.ForeColor = System.Drawing.Color.Black
        Me.TObs5.Location = New System.Drawing.Point(1288, 125)
        Me.TObs5.MaxLength = 255
        Me.TObs5.Multiline = True
        Me.TObs5.Name = "TObs5"
        Me.TObs5.Size = New System.Drawing.Size(154, 20)
        Me.TObs5.TabIndex = 99
        '
        'TPROFUNDIDAD_ACTUAL15
        '
        Me.TPROFUNDIDAD_ACTUAL15.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL15.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL15.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL15.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL15.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL15.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL15.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL15.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL15.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL15.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL15.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL15.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL15.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL15.Location = New System.Drawing.Point(876, 126)
        Me.TPROFUNDIDAD_ACTUAL15.Name = "TPROFUNDIDAD_ACTUAL15"
        Me.TPROFUNDIDAD_ACTUAL15.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL15.TabIndex = 92
        Me.TPROFUNDIDAD_ACTUAL15.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL15.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL15.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL15.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL5
        '
        Me.TPROFUNDIDA_ORIGINAL5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL5.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL5.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL5.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL5.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL5.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL5.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL5.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL5.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL5.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL5.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL5.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL5.Location = New System.Drawing.Point(650, 126)
        Me.TPROFUNDIDA_ORIGINAL5.Name = "TPROFUNDIDA_ORIGINAL5"
        Me.TPROFUNDIDA_ORIGINAL5.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL5.TabIndex = 88
        Me.TPROFUNDIDA_ORIGINAL5.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE5
        '
        Me.TDESGASTE5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE5.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE5.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE5.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE5.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE5.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE5.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE5.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE5.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE5.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE5.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE5.InterceptArrowKeys = False
        Me.TDESGASTE5.Location = New System.Drawing.Point(1127, 126)
        Me.TDESGASTE5.Name = "TDESGASTE5"
        Me.TDESGASTE5.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE5.TabIndex = 98
        Me.TDESGASTE5.Tag = Nothing
        Me.TDESGASTE5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR5
        '
        Me.TKMS_DESMONTAR5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR5.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR5.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR5.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR5.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR5.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR5.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR5.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR5.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR5.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR5.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR5.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR5.Location = New System.Drawing.Point(698, 126)
        Me.TKMS_DESMONTAR5.Name = "TKMS_DESMONTAR5"
        Me.TKMS_DESMONTAR5.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR5.TabIndex = 89
        Me.TKMS_DESMONTAR5.Tag = Nothing
        Me.TKMS_DESMONTAR5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR5
        '
        Me.TKMS_MONTAR5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR5.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR5.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR5.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR5.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR5.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR5.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR5.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR5.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR5.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR5.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR5.InterceptArrowKeys = False
        Me.TKMS_MONTAR5.Location = New System.Drawing.Point(582, 126)
        Me.TKMS_MONTAR5.Name = "TKMS_MONTAR5"
        Me.TKMS_MONTAR5.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR5.TabIndex = 87
        Me.TKMS_MONTAR5.Tag = Nothing
        Me.TKMS_MONTAR5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION5
        '
        Me.TPOSICION5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION5.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION5.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION5.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION5.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION5.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION5.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION5.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION5.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION5.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION5.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION5.InterceptArrowKeys = False
        Me.TPOSICION5.Location = New System.Drawing.Point(1086, 126)
        Me.TPOSICION5.MaxLength = 5
        Me.TPOSICION5.Name = "TPOSICION5"
        Me.TPOSICION5.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION5.TabIndex = 97
        Me.TPOSICION5.Tag = Nothing
        Me.TPOSICION5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA5
        '
        Me.TCOSTO_LLANTA5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA5.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA5.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA5.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA5.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA5.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA5.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA5.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA5.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA5.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA5.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA5.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA5.Location = New System.Drawing.Point(524, 126)
        Me.TCOSTO_LLANTA5.Name = "TCOSTO_LLANTA5"
        Me.TCOSTO_LLANTA5.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA5.TabIndex = 86
        Me.TCOSTO_LLANTA5.Tag = Nothing
        Me.TCOSTO_LLANTA5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA5
        '
        Me.TTIPO_LLANTA5.AcceptsReturn = True
        Me.TTIPO_LLANTA5.AcceptsTab = True
        Me.TTIPO_LLANTA5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA5.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA5.Location = New System.Drawing.Point(281, 125)
        Me.TTIPO_LLANTA5.MaxLength = 10
        Me.TTIPO_LLANTA5.Name = "TTIPO_LLANTA5"
        Me.TTIPO_LLANTA5.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA5.TabIndex = 83
        Me.TTIPO_LLANTA5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA5
        '
        Me.TMARCA5.AcceptsReturn = True
        Me.TMARCA5.AcceptsTab = True
        Me.TMARCA5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA5.ForeColor = System.Drawing.Color.Black
        Me.TMARCA5.Location = New System.Drawing.Point(110, 125)
        Me.TMARCA5.MaxLength = 10
        Me.TMARCA5.Name = "TMARCA5"
        Me.TMARCA5.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA5.TabIndex = 81
        Me.TMARCA5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO5
        '
        Me.TMODELO5.AcceptsReturn = True
        Me.TMODELO5.AcceptsTab = True
        Me.TMODELO5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO5.ForeColor = System.Drawing.Color.Black
        Me.TMODELO5.Location = New System.Drawing.Point(210, 125)
        Me.TMODELO5.MaxLength = 10
        Me.TMODELO5.Name = "TMODELO5"
        Me.TMODELO5.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO5.TabIndex = 82
        Me.TMODELO5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS4
        '
        Me.TKM_RECORRIDOS4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS4.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_RECORRIDOS4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_RECORRIDOS4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_RECORRIDOS4.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS4.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS4.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS4.Location = New System.Drawing.Point(819, 104)
        Me.TKM_RECORRIDOS4.Name = "TKM_RECORRIDOS4"
        Me.TKM_RECORRIDOS4.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS4.TabIndex = 71
        Me.TKM_RECORRIDOS4.Tag = Nothing
        Me.TKM_RECORRIDOS4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE4
        '
        Me.TFECHA_MONTAJE4.AcceptsReturn = True
        Me.TFECHA_MONTAJE4.AcceptsTab = True
        Me.TFECHA_MONTAJE4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE4.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE4.Location = New System.Drawing.Point(443, 103)
        Me.TFECHA_MONTAJE4.MaxLength = 10
        Me.TFECHA_MONTAJE4.Name = "TFECHA_MONTAJE4"
        Me.TFECHA_MONTAJE4.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE4.TabIndex = 65
        Me.TFECHA_MONTAJE4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA4
        '
        Me.TNUEVA_RENOVADA4.AcceptsReturn = True
        Me.TNUEVA_RENOVADA4.AcceptsTab = True
        Me.TNUEVA_RENOVADA4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA4.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA4.Location = New System.Drawing.Point(362, 103)
        Me.TNUEVA_RENOVADA4.MaxLength = 10
        Me.TNUEVA_RENOVADA4.Name = "TNUEVA_RENOVADA4"
        Me.TNUEVA_RENOVADA4.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA4.TabIndex = 64
        Me.TNUEVA_RENOVADA4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs4
        '
        Me.TObs4.AcceptsReturn = True
        Me.TObs4.AcceptsTab = True
        Me.TObs4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs4.ForeColor = System.Drawing.Color.Black
        Me.TObs4.Location = New System.Drawing.Point(1288, 103)
        Me.TObs4.MaxLength = 255
        Me.TObs4.Multiline = True
        Me.TObs4.Name = "TObs4"
        Me.TObs4.Size = New System.Drawing.Size(154, 20)
        Me.TObs4.TabIndex = 79
        '
        'TPROFUNDIDAD_ACTUAL14
        '
        Me.TPROFUNDIDAD_ACTUAL14.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL14.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL14.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL14.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL14.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL14.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL14.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL14.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL14.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL14.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL14.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL14.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL14.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL14.Location = New System.Drawing.Point(876, 104)
        Me.TPROFUNDIDAD_ACTUAL14.Name = "TPROFUNDIDAD_ACTUAL14"
        Me.TPROFUNDIDAD_ACTUAL14.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL14.TabIndex = 72
        Me.TPROFUNDIDAD_ACTUAL14.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL14.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL14.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL14.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL4
        '
        Me.TPROFUNDIDA_ORIGINAL4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL4.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL4.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL4.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL4.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL4.Location = New System.Drawing.Point(650, 104)
        Me.TPROFUNDIDA_ORIGINAL4.Name = "TPROFUNDIDA_ORIGINAL4"
        Me.TPROFUNDIDA_ORIGINAL4.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL4.TabIndex = 68
        Me.TPROFUNDIDA_ORIGINAL4.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE4
        '
        Me.TDESGASTE4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE4.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE4.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE4.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE4.InterceptArrowKeys = False
        Me.TDESGASTE4.Location = New System.Drawing.Point(1127, 104)
        Me.TDESGASTE4.Name = "TDESGASTE4"
        Me.TDESGASTE4.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE4.TabIndex = 78
        Me.TDESGASTE4.Tag = Nothing
        Me.TDESGASTE4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR4
        '
        Me.TKMS_DESMONTAR4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR4.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR4.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR4.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR4.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR4.Location = New System.Drawing.Point(698, 104)
        Me.TKMS_DESMONTAR4.Name = "TKMS_DESMONTAR4"
        Me.TKMS_DESMONTAR4.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR4.TabIndex = 69
        Me.TKMS_DESMONTAR4.Tag = Nothing
        Me.TKMS_DESMONTAR4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR4
        '
        Me.TKMS_MONTAR4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR4.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR4.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR4.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR4.InterceptArrowKeys = False
        Me.TKMS_MONTAR4.Location = New System.Drawing.Point(582, 104)
        Me.TKMS_MONTAR4.Name = "TKMS_MONTAR4"
        Me.TKMS_MONTAR4.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR4.TabIndex = 67
        Me.TKMS_MONTAR4.Tag = Nothing
        Me.TKMS_MONTAR4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION4
        '
        Me.TPOSICION4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION4.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION4.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION4.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION4.InterceptArrowKeys = False
        Me.TPOSICION4.Location = New System.Drawing.Point(1086, 104)
        Me.TPOSICION4.MaxLength = 5
        Me.TPOSICION4.Name = "TPOSICION4"
        Me.TPOSICION4.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION4.TabIndex = 77
        Me.TPOSICION4.Tag = Nothing
        Me.TPOSICION4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA4
        '
        Me.TCOSTO_LLANTA4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA4.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA4.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA4.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA4.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA4.Location = New System.Drawing.Point(524, 104)
        Me.TCOSTO_LLANTA4.Name = "TCOSTO_LLANTA4"
        Me.TCOSTO_LLANTA4.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA4.TabIndex = 66
        Me.TCOSTO_LLANTA4.Tag = Nothing
        Me.TCOSTO_LLANTA4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA4
        '
        Me.TTIPO_LLANTA4.AcceptsReturn = True
        Me.TTIPO_LLANTA4.AcceptsTab = True
        Me.TTIPO_LLANTA4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA4.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA4.Location = New System.Drawing.Point(281, 103)
        Me.TTIPO_LLANTA4.MaxLength = 10
        Me.TTIPO_LLANTA4.Name = "TTIPO_LLANTA4"
        Me.TTIPO_LLANTA4.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA4.TabIndex = 63
        Me.TTIPO_LLANTA4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA4
        '
        Me.TMARCA4.AcceptsReturn = True
        Me.TMARCA4.AcceptsTab = True
        Me.TMARCA4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA4.ForeColor = System.Drawing.Color.Black
        Me.TMARCA4.Location = New System.Drawing.Point(110, 103)
        Me.TMARCA4.MaxLength = 10
        Me.TMARCA4.Name = "TMARCA4"
        Me.TMARCA4.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA4.TabIndex = 61
        Me.TMARCA4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO4
        '
        Me.TMODELO4.AcceptsReturn = True
        Me.TMODELO4.AcceptsTab = True
        Me.TMODELO4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO4.ForeColor = System.Drawing.Color.Black
        Me.TMODELO4.Location = New System.Drawing.Point(210, 103)
        Me.TMODELO4.MaxLength = 10
        Me.TMODELO4.Name = "TMODELO4"
        Me.TMODELO4.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO4.TabIndex = 62
        Me.TMODELO4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS3
        '
        Me.TKM_RECORRIDOS3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKM_RECORRIDOS3.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS3.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS3.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS3.Location = New System.Drawing.Point(819, 82)
        Me.TKM_RECORRIDOS3.Name = "TKM_RECORRIDOS3"
        Me.TKM_RECORRIDOS3.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS3.TabIndex = 51
        Me.TKM_RECORRIDOS3.Tag = Nothing
        Me.TKM_RECORRIDOS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE3
        '
        Me.TFECHA_MONTAJE3.AcceptsReturn = True
        Me.TFECHA_MONTAJE3.AcceptsTab = True
        Me.TFECHA_MONTAJE3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE3.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE3.Location = New System.Drawing.Point(443, 81)
        Me.TFECHA_MONTAJE3.MaxLength = 10
        Me.TFECHA_MONTAJE3.Name = "TFECHA_MONTAJE3"
        Me.TFECHA_MONTAJE3.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE3.TabIndex = 45
        Me.TFECHA_MONTAJE3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA3
        '
        Me.TNUEVA_RENOVADA3.AcceptsReturn = True
        Me.TNUEVA_RENOVADA3.AcceptsTab = True
        Me.TNUEVA_RENOVADA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA3.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA3.Location = New System.Drawing.Point(362, 81)
        Me.TNUEVA_RENOVADA3.MaxLength = 10
        Me.TNUEVA_RENOVADA3.Name = "TNUEVA_RENOVADA3"
        Me.TNUEVA_RENOVADA3.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA3.TabIndex = 44
        Me.TNUEVA_RENOVADA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs3
        '
        Me.TObs3.AcceptsReturn = True
        Me.TObs3.AcceptsTab = True
        Me.TObs3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs3.ForeColor = System.Drawing.Color.Black
        Me.TObs3.Location = New System.Drawing.Point(1288, 81)
        Me.TObs3.MaxLength = 255
        Me.TObs3.Multiline = True
        Me.TObs3.Name = "TObs3"
        Me.TObs3.Size = New System.Drawing.Size(154, 20)
        Me.TObs3.TabIndex = 59
        '
        'TPROFUNDIDAD_ACTUAL13
        '
        Me.TPROFUNDIDAD_ACTUAL13.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL13.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL13.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL13.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL13.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL13.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL13.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL13.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL13.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL13.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL13.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL13.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL13.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL13.Location = New System.Drawing.Point(876, 82)
        Me.TPROFUNDIDAD_ACTUAL13.Name = "TPROFUNDIDAD_ACTUAL13"
        Me.TPROFUNDIDAD_ACTUAL13.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL13.TabIndex = 52
        Me.TPROFUNDIDAD_ACTUAL13.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL13.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL13.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL13.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL3
        '
        Me.TPROFUNDIDA_ORIGINAL3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL3.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL3.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL3.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL3.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL3.Location = New System.Drawing.Point(650, 82)
        Me.TPROFUNDIDA_ORIGINAL3.Name = "TPROFUNDIDA_ORIGINAL3"
        Me.TPROFUNDIDA_ORIGINAL3.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL3.TabIndex = 48
        Me.TPROFUNDIDA_ORIGINAL3.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE3
        '
        Me.TDESGASTE3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE3.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE3.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE3.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE3.InterceptArrowKeys = False
        Me.TDESGASTE3.Location = New System.Drawing.Point(1127, 82)
        Me.TDESGASTE3.Name = "TDESGASTE3"
        Me.TDESGASTE3.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE3.TabIndex = 59
        Me.TDESGASTE3.Tag = Nothing
        Me.TDESGASTE3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR3
        '
        Me.TKMS_DESMONTAR3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR3.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR3.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR3.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR3.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR3.Location = New System.Drawing.Point(698, 82)
        Me.TKMS_DESMONTAR3.Name = "TKMS_DESMONTAR3"
        Me.TKMS_DESMONTAR3.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR3.TabIndex = 49
        Me.TKMS_DESMONTAR3.Tag = Nothing
        Me.TKMS_DESMONTAR3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR3
        '
        Me.TKMS_MONTAR3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR3.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR3.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR3.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR3.InterceptArrowKeys = False
        Me.TKMS_MONTAR3.Location = New System.Drawing.Point(582, 82)
        Me.TKMS_MONTAR3.Name = "TKMS_MONTAR3"
        Me.TKMS_MONTAR3.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR3.TabIndex = 47
        Me.TKMS_MONTAR3.Tag = Nothing
        Me.TKMS_MONTAR3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION3
        '
        Me.TPOSICION3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION3.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION3.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION3.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION3.InterceptArrowKeys = False
        Me.TPOSICION3.Location = New System.Drawing.Point(1086, 82)
        Me.TPOSICION3.MaxLength = 5
        Me.TPOSICION3.Name = "TPOSICION3"
        Me.TPOSICION3.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION3.TabIndex = 57
        Me.TPOSICION3.Tag = Nothing
        Me.TPOSICION3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA3
        '
        Me.TCOSTO_LLANTA3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA3.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA3.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA3.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA3.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA3.Location = New System.Drawing.Point(524, 82)
        Me.TCOSTO_LLANTA3.Name = "TCOSTO_LLANTA3"
        Me.TCOSTO_LLANTA3.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA3.TabIndex = 46
        Me.TCOSTO_LLANTA3.Tag = Nothing
        Me.TCOSTO_LLANTA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA3
        '
        Me.TTIPO_LLANTA3.AcceptsReturn = True
        Me.TTIPO_LLANTA3.AcceptsTab = True
        Me.TTIPO_LLANTA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA3.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA3.Location = New System.Drawing.Point(281, 81)
        Me.TTIPO_LLANTA3.MaxLength = 10
        Me.TTIPO_LLANTA3.Name = "TTIPO_LLANTA3"
        Me.TTIPO_LLANTA3.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA3.TabIndex = 43
        Me.TTIPO_LLANTA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA3
        '
        Me.TMARCA3.AcceptsReturn = True
        Me.TMARCA3.AcceptsTab = True
        Me.TMARCA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA3.ForeColor = System.Drawing.Color.Black
        Me.TMARCA3.Location = New System.Drawing.Point(110, 81)
        Me.TMARCA3.MaxLength = 10
        Me.TMARCA3.Name = "TMARCA3"
        Me.TMARCA3.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA3.TabIndex = 41
        Me.TMARCA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO3
        '
        Me.TMODELO3.AcceptsReturn = True
        Me.TMODELO3.AcceptsTab = True
        Me.TMODELO3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO3.ForeColor = System.Drawing.Color.Black
        Me.TMODELO3.Location = New System.Drawing.Point(210, 81)
        Me.TMODELO3.MaxLength = 10
        Me.TMODELO3.Name = "TMODELO3"
        Me.TMODELO3.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO3.TabIndex = 42
        Me.TMODELO3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS2
        '
        Me.TKM_RECORRIDOS2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS2.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_RECORRIDOS2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_RECORRIDOS2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_RECORRIDOS2.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS2.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS2.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS2.Location = New System.Drawing.Point(819, 60)
        Me.TKM_RECORRIDOS2.Name = "TKM_RECORRIDOS2"
        Me.TKM_RECORRIDOS2.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS2.TabIndex = 31
        Me.TKM_RECORRIDOS2.Tag = Nothing
        Me.TKM_RECORRIDOS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFECHA_MONTAJE2
        '
        Me.TFECHA_MONTAJE2.AcceptsReturn = True
        Me.TFECHA_MONTAJE2.AcceptsTab = True
        Me.TFECHA_MONTAJE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE2.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE2.Location = New System.Drawing.Point(443, 59)
        Me.TFECHA_MONTAJE2.MaxLength = 10
        Me.TFECHA_MONTAJE2.Name = "TFECHA_MONTAJE2"
        Me.TFECHA_MONTAJE2.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE2.TabIndex = 25
        Me.TFECHA_MONTAJE2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA2
        '
        Me.TNUEVA_RENOVADA2.AcceptsReturn = True
        Me.TNUEVA_RENOVADA2.AcceptsTab = True
        Me.TNUEVA_RENOVADA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA2.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA2.Location = New System.Drawing.Point(362, 59)
        Me.TNUEVA_RENOVADA2.MaxLength = 10
        Me.TNUEVA_RENOVADA2.Name = "TNUEVA_RENOVADA2"
        Me.TNUEVA_RENOVADA2.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA2.TabIndex = 24
        Me.TNUEVA_RENOVADA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObs2
        '
        Me.TObs2.AcceptsReturn = True
        Me.TObs2.AcceptsTab = True
        Me.TObs2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TObs2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObs2.ForeColor = System.Drawing.Color.Black
        Me.TObs2.Location = New System.Drawing.Point(1288, 59)
        Me.TObs2.MaxLength = 255
        Me.TObs2.Multiline = True
        Me.TObs2.Name = "TObs2"
        Me.TObs2.Size = New System.Drawing.Size(154, 20)
        Me.TObs2.TabIndex = 39
        '
        'TPROFUNDIDAD_ACTUAL12
        '
        Me.TPROFUNDIDAD_ACTUAL12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL12.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL12.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL12.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL12.Location = New System.Drawing.Point(876, 60)
        Me.TPROFUNDIDAD_ACTUAL12.Name = "TPROFUNDIDAD_ACTUAL12"
        Me.TPROFUNDIDAD_ACTUAL12.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL12.TabIndex = 32
        Me.TPROFUNDIDAD_ACTUAL12.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDA_ORIGINAL2
        '
        Me.TPROFUNDIDA_ORIGINAL2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL2.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDA_ORIGINAL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDA_ORIGINAL2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDA_ORIGINAL2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDA_ORIGINAL2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDA_ORIGINAL2.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL2.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDA_ORIGINAL2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDA_ORIGINAL2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDA_ORIGINAL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDA_ORIGINAL2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDA_ORIGINAL2.InterceptArrowKeys = False
        Me.TPROFUNDIDA_ORIGINAL2.Location = New System.Drawing.Point(650, 60)
        Me.TPROFUNDIDA_ORIGINAL2.Name = "TPROFUNDIDA_ORIGINAL2"
        Me.TPROFUNDIDA_ORIGINAL2.Size = New System.Drawing.Size(47, 18)
        Me.TPROFUNDIDA_ORIGINAL2.TabIndex = 28
        Me.TPROFUNDIDA_ORIGINAL2.Tag = Nothing
        Me.TPROFUNDIDA_ORIGINAL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDA_ORIGINAL2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDA_ORIGINAL2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDA_ORIGINAL2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TDESGASTE2
        '
        Me.TDESGASTE2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE2.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TDESGASTE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TDESGASTE2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TDESGASTE2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TDESGASTE2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TDESGASTE2.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE2.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TDESGASTE2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDESGASTE2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDESGASTE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDESGASTE2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TDESGASTE2.InterceptArrowKeys = False
        Me.TDESGASTE2.Location = New System.Drawing.Point(1127, 60)
        Me.TDESGASTE2.Name = "TDESGASTE2"
        Me.TDESGASTE2.Size = New System.Drawing.Size(45, 18)
        Me.TDESGASTE2.TabIndex = 38
        Me.TDESGASTE2.Tag = Nothing
        Me.TDESGASTE2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDESGASTE2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TDESGASTE2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TDESGASTE2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_DESMONTAR2
        '
        Me.TKMS_DESMONTAR2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR2.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_DESMONTAR2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_DESMONTAR2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_DESMONTAR2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_DESMONTAR2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_DESMONTAR2.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR2.EditFormat.CustomFormat = "###,###,##0"
        Me.TKMS_DESMONTAR2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_DESMONTAR2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_DESMONTAR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_DESMONTAR2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_DESMONTAR2.InterceptArrowKeys = False
        Me.TKMS_DESMONTAR2.Location = New System.Drawing.Point(698, 60)
        Me.TKMS_DESMONTAR2.Name = "TKMS_DESMONTAR2"
        Me.TKMS_DESMONTAR2.Size = New System.Drawing.Size(59, 18)
        Me.TKMS_DESMONTAR2.TabIndex = 29
        Me.TKMS_DESMONTAR2.Tag = Nothing
        Me.TKMS_DESMONTAR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_DESMONTAR2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_DESMONTAR2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_DESMONTAR2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKMS_MONTAR2
        '
        Me.TKMS_MONTAR2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR2.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKMS_MONTAR2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMS_MONTAR2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMS_MONTAR2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKMS_MONTAR2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMS_MONTAR2.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKMS_MONTAR2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR2.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMS_MONTAR2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMS_MONTAR2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMS_MONTAR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMS_MONTAR2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMS_MONTAR2.InterceptArrowKeys = False
        Me.TKMS_MONTAR2.Location = New System.Drawing.Point(582, 60)
        Me.TKMS_MONTAR2.Name = "TKMS_MONTAR2"
        Me.TKMS_MONTAR2.Size = New System.Drawing.Size(66, 18)
        Me.TKMS_MONTAR2.TabIndex = 27
        Me.TKMS_MONTAR2.Tag = Nothing
        Me.TKMS_MONTAR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMS_MONTAR2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKMS_MONTAR2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMS_MONTAR2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPOSICION2
        '
        Me.TPOSICION2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION2.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPOSICION2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPOSICION2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPOSICION2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPOSICION2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPOSICION2.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION2.EditFormat.CustomFormat = "###,###,##0"
        Me.TPOSICION2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPOSICION2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPOSICION2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPOSICION2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPOSICION2.InterceptArrowKeys = False
        Me.TPOSICION2.Location = New System.Drawing.Point(1086, 60)
        Me.TPOSICION2.MaxLength = 5
        Me.TPOSICION2.Name = "TPOSICION2"
        Me.TPOSICION2.Size = New System.Drawing.Size(40, 18)
        Me.TPOSICION2.TabIndex = 37
        Me.TPOSICION2.Tag = Nothing
        Me.TPOSICION2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPOSICION2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPOSICION2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPOSICION2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCOSTO_LLANTA2
        '
        Me.TCOSTO_LLANTA2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA2.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TCOSTO_LLANTA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCOSTO_LLANTA2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCOSTO_LLANTA2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TCOSTO_LLANTA2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCOSTO_LLANTA2.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA2.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TCOSTO_LLANTA2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TCOSTO_LLANTA2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCOSTO_LLANTA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCOSTO_LLANTA2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCOSTO_LLANTA2.InterceptArrowKeys = False
        Me.TCOSTO_LLANTA2.Location = New System.Drawing.Point(524, 60)
        Me.TCOSTO_LLANTA2.Name = "TCOSTO_LLANTA2"
        Me.TCOSTO_LLANTA2.Size = New System.Drawing.Size(57, 18)
        Me.TCOSTO_LLANTA2.TabIndex = 26
        Me.TCOSTO_LLANTA2.Tag = Nothing
        Me.TCOSTO_LLANTA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCOSTO_LLANTA2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TCOSTO_LLANTA2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCOSTO_LLANTA2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_LLANTA2
        '
        Me.TTIPO_LLANTA2.AcceptsReturn = True
        Me.TTIPO_LLANTA2.AcceptsTab = True
        Me.TTIPO_LLANTA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_LLANTA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_LLANTA2.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_LLANTA2.Location = New System.Drawing.Point(281, 59)
        Me.TTIPO_LLANTA2.MaxLength = 10
        Me.TTIPO_LLANTA2.Name = "TTIPO_LLANTA2"
        Me.TTIPO_LLANTA2.Size = New System.Drawing.Size(80, 20)
        Me.TTIPO_LLANTA2.TabIndex = 23
        Me.TTIPO_LLANTA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMARCA2
        '
        Me.TMARCA2.AcceptsReturn = True
        Me.TMARCA2.AcceptsTab = True
        Me.TMARCA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMARCA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMARCA2.ForeColor = System.Drawing.Color.Black
        Me.TMARCA2.Location = New System.Drawing.Point(110, 59)
        Me.TMARCA2.MaxLength = 10
        Me.TMARCA2.Name = "TMARCA2"
        Me.TMARCA2.Size = New System.Drawing.Size(99, 20)
        Me.TMARCA2.TabIndex = 21
        Me.TMARCA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMODELO2
        '
        Me.TMODELO2.AcceptsReturn = True
        Me.TMODELO2.AcceptsTab = True
        Me.TMODELO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TMODELO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMODELO2.ForeColor = System.Drawing.Color.Black
        Me.TMODELO2.Location = New System.Drawing.Point(210, 59)
        Me.TMODELO2.MaxLength = 10
        Me.TMODELO2.Name = "TMODELO2"
        Me.TMODELO2.Size = New System.Drawing.Size(70, 20)
        Me.TMODELO2.TabIndex = 22
        Me.TMODELO2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TKM_RECORRIDOS1
        '
        Me.TKM_RECORRIDOS1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS1.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_RECORRIDOS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_RECORRIDOS1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_RECORRIDOS1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_RECORRIDOS1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_RECORRIDOS1.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS1.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKM_RECORRIDOS1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_RECORRIDOS1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_RECORRIDOS1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_RECORRIDOS1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_RECORRIDOS1.InterceptArrowKeys = False
        Me.TKM_RECORRIDOS1.Location = New System.Drawing.Point(819, 38)
        Me.TKM_RECORRIDOS1.Name = "TKM_RECORRIDOS1"
        Me.TKM_RECORRIDOS1.Size = New System.Drawing.Size(56, 18)
        Me.TKM_RECORRIDOS1.TabIndex = 11
        Me.TKM_RECORRIDOS1.Tag = Nothing
        Me.TKM_RECORRIDOS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_RECORRIDOS1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_RECORRIDOS1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_RECORRIDOS1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(819, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 31)
        Me.Label12.TabIndex = 645
        Me.Label12.Text = "Kms. recorridos"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TFECHA_MONTAJE1
        '
        Me.TFECHA_MONTAJE1.AcceptsReturn = True
        Me.TFECHA_MONTAJE1.AcceptsTab = True
        Me.TFECHA_MONTAJE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFECHA_MONTAJE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFECHA_MONTAJE1.ForeColor = System.Drawing.Color.Black
        Me.TFECHA_MONTAJE1.Location = New System.Drawing.Point(443, 37)
        Me.TFECHA_MONTAJE1.MaxLength = 10
        Me.TFECHA_MONTAJE1.Name = "TFECHA_MONTAJE1"
        Me.TFECHA_MONTAJE1.Size = New System.Drawing.Size(80, 20)
        Me.TFECHA_MONTAJE1.TabIndex = 5
        Me.TFECHA_MONTAJE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNUEVA_RENOVADA1
        '
        Me.TNUEVA_RENOVADA1.AcceptsReturn = True
        Me.TNUEVA_RENOVADA1.AcceptsTab = True
        Me.TNUEVA_RENOVADA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNUEVA_RENOVADA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNUEVA_RENOVADA1.ForeColor = System.Drawing.Color.Black
        Me.TNUEVA_RENOVADA1.Location = New System.Drawing.Point(362, 37)
        Me.TNUEVA_RENOVADA1.MaxLength = 10
        Me.TNUEVA_RENOVADA1.Name = "TNUEVA_RENOVADA1"
        Me.TNUEVA_RENOVADA1.Size = New System.Drawing.Size(80, 20)
        Me.TNUEVA_RENOVADA1.TabIndex = 4
        Me.TNUEVA_RENOVADA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(364, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 31)
        Me.Label2.TabIndex = 641
        Me.Label2.Text = "Nueva / Renovada"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(41, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 30)
        Me.Label11.TabIndex = 216
        Me.Label11.Text = "Núm. económico"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TLL12
        '
        Me.TLL12.AcceptsReturn = True
        Me.TLL12.AcceptsTab = True
        Me.TLL12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL12.Location = New System.Drawing.Point(39, 279)
        Me.TLL12.Name = "TLL12"
        Me.TLL12.Size = New System.Drawing.Size(70, 20)
        Me.TLL12.TabIndex = 220
        '
        'Et12
        '
        Me.Et12.AutoSize = True
        Me.Et12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Et12.Location = New System.Drawing.Point(4, 282)
        Me.Et12.Name = "Et12"
        Me.Et12.Size = New System.Drawing.Size(32, 15)
        Me.Et12.TabIndex = 197
        Me.Et12.Text = "L-12"
        '
        'TLL11
        '
        Me.TLL11.AcceptsReturn = True
        Me.TLL11.AcceptsTab = True
        Me.TLL11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL11.Location = New System.Drawing.Point(39, 257)
        Me.TLL11.Name = "TLL11"
        Me.TLL11.Size = New System.Drawing.Size(70, 20)
        Me.TLL11.TabIndex = 200
        '
        'Et11
        '
        Me.Et11.AutoSize = True
        Me.Et11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Et11.Location = New System.Drawing.Point(4, 260)
        Me.Et11.Name = "Et11"
        Me.Et11.Size = New System.Drawing.Size(32, 15)
        Me.Et11.TabIndex = 194
        Me.Et11.Text = "L-11"
        '
        'TLL10
        '
        Me.TLL10.AcceptsReturn = True
        Me.TLL10.AcceptsTab = True
        Me.TLL10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL10.Location = New System.Drawing.Point(39, 235)
        Me.TLL10.Name = "TLL10"
        Me.TLL10.Size = New System.Drawing.Size(70, 20)
        Me.TLL10.TabIndex = 180
        '
        'Et10
        '
        Me.Et10.AutoSize = True
        Me.Et10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Et10.Location = New System.Drawing.Point(4, 238)
        Me.Et10.Name = "Et10"
        Me.Et10.Size = New System.Drawing.Size(32, 15)
        Me.Et10.TabIndex = 189
        Me.Et10.Text = "L-10"
        '
        'TLL9
        '
        Me.TLL9.AcceptsReturn = True
        Me.TLL9.AcceptsTab = True
        Me.TLL9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL9.Location = New System.Drawing.Point(39, 213)
        Me.TLL9.Name = "TLL9"
        Me.TLL9.Size = New System.Drawing.Size(70, 20)
        Me.TLL9.TabIndex = 160
        '
        'Et9
        '
        Me.Et9.AutoSize = True
        Me.Et9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Et9.Location = New System.Drawing.Point(11, 216)
        Me.Et9.Name = "Et9"
        Me.Et9.Size = New System.Drawing.Size(25, 15)
        Me.Et9.TabIndex = 186
        Me.Et9.Text = "L-9"
        '
        'TLL8
        '
        Me.TLL8.AcceptsReturn = True
        Me.TLL8.AcceptsTab = True
        Me.TLL8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL8.Location = New System.Drawing.Point(39, 191)
        Me.TLL8.Name = "TLL8"
        Me.TLL8.Size = New System.Drawing.Size(70, 20)
        Me.TLL8.TabIndex = 140
        '
        'Label127
        '
        Me.Label127.AutoSize = True
        Me.Label127.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label127.Location = New System.Drawing.Point(11, 194)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(25, 15)
        Me.Label127.TabIndex = 179
        Me.Label127.Text = "L-8"
        '
        'TLL6
        '
        Me.TLL6.AcceptsReturn = True
        Me.TLL6.AcceptsTab = True
        Me.TLL6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL6.Location = New System.Drawing.Point(39, 147)
        Me.TLL6.Name = "TLL6"
        Me.TLL6.Size = New System.Drawing.Size(70, 20)
        Me.TLL6.TabIndex = 100
        '
        'TLL7
        '
        Me.TLL7.AcceptsReturn = True
        Me.TLL7.AcceptsTab = True
        Me.TLL7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL7.Location = New System.Drawing.Point(39, 169)
        Me.TLL7.Name = "TLL7"
        Me.TLL7.Size = New System.Drawing.Size(70, 20)
        Me.TLL7.TabIndex = 120
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label128.Location = New System.Drawing.Point(11, 172)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(25, 15)
        Me.Label128.TabIndex = 177
        Me.Label128.Text = "L-7"
        '
        'Label129
        '
        Me.Label129.AutoSize = True
        Me.Label129.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label129.Location = New System.Drawing.Point(11, 150)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(25, 15)
        Me.Label129.TabIndex = 178
        Me.Label129.Text = "L-6"
        '
        'TLL5
        '
        Me.TLL5.AcceptsReturn = True
        Me.TLL5.AcceptsTab = True
        Me.TLL5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL5.Location = New System.Drawing.Point(39, 125)
        Me.TLL5.Name = "TLL5"
        Me.TLL5.Size = New System.Drawing.Size(70, 20)
        Me.TLL5.TabIndex = 80
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.Location = New System.Drawing.Point(11, 128)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(25, 15)
        Me.Label91.TabIndex = 169
        Me.Label91.Text = "L-5"
        '
        'TLL4
        '
        Me.TLL4.AcceptsReturn = True
        Me.TLL4.AcceptsTab = True
        Me.TLL4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL4.Location = New System.Drawing.Point(39, 103)
        Me.TLL4.Name = "TLL4"
        Me.TLL4.Size = New System.Drawing.Size(70, 20)
        Me.TLL4.TabIndex = 60
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.Location = New System.Drawing.Point(11, 107)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(25, 15)
        Me.Label95.TabIndex = 166
        Me.Label95.Text = "L-4"
        '
        'TLL3
        '
        Me.TLL3.AcceptsReturn = True
        Me.TLL3.AcceptsTab = True
        Me.TLL3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL3.Location = New System.Drawing.Point(39, 81)
        Me.TLL3.Name = "TLL3"
        Me.TLL3.Size = New System.Drawing.Size(70, 20)
        Me.TLL3.TabIndex = 40
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label117.Location = New System.Drawing.Point(11, 84)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(25, 15)
        Me.Label117.TabIndex = 159
        Me.Label117.Text = "L-3"
        '
        'TLL1
        '
        Me.TLL1.AcceptsReturn = True
        Me.TLL1.AcceptsTab = True
        Me.TLL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL1.Location = New System.Drawing.Point(39, 37)
        Me.TLL1.Name = "TLL1"
        Me.TLL1.Size = New System.Drawing.Size(70, 20)
        Me.TLL1.TabIndex = 0
        '
        'TLL2
        '
        Me.TLL2.AcceptsReturn = True
        Me.TLL2.AcceptsTab = True
        Me.TLL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TLL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLL2.Location = New System.Drawing.Point(39, 59)
        Me.TLL2.Name = "TLL2"
        Me.TLL2.Size = New System.Drawing.Size(70, 20)
        Me.TLL2.TabIndex = 20
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.Location = New System.Drawing.Point(11, 62)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(25, 15)
        Me.Label118.TabIndex = 157
        Me.Label118.Text = "L-2"
        '
        'Label119
        '
        Me.Label119.AutoSize = True
        Me.Label119.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label119.Location = New System.Drawing.Point(11, 39)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(25, 15)
        Me.Label119.TabIndex = 158
        Me.Label119.Text = "L-1"
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(0, 49)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.Split1)
        Me.SplitM.Panels.Add(Me.Split2)
        Me.SplitM.Size = New System.Drawing.Size(1479, 522)
        Me.SplitM.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.TabIndex = 654
        Me.SplitM.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'Split1
        '
        Me.Split1.AutoScroll = True
        Me.Split1.Controls.Add(Me.Label23)
        Me.Split1.Controls.Add(Me.LtCve_Ins)
        Me.Split1.Controls.Add(Me.LtSt)
        Me.Split1.Controls.Add(Me.TCVE_UNI)
        Me.Split1.Controls.Add(Me.Label9)
        Me.Split1.Controls.Add(Me.LtDel)
        Me.Split1.Controls.Add(Me.L2)
        Me.Split1.Controls.Add(Me.TFECHA)
        Me.Split1.Controls.Add(Me.BtnUnidades)
        Me.Split1.Controls.Add(Me.Label10)
        Me.Split1.Height = 184
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1477, 184)
        Me.Split1.SizeRatio = 35.619R
        Me.Split1.TabIndex = 0
        '
        'LtSt
        '
        Me.LtSt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSt.Location = New System.Drawing.Point(869, 18)
        Me.LtSt.Name = "LtSt"
        Me.LtSt.Size = New System.Drawing.Size(152, 25)
        Me.LtSt.TabIndex = 653
        Me.LtSt.Text = "FINALIZADO"
        Me.LtSt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Split2
        '
        Me.Split2.AutoScroll = True
        Me.Split2.Controls.Add(Me.TTIPO_RIN12)
        Me.Split2.Controls.Add(Me.TTIPO_RIN5)
        Me.Split2.Controls.Add(Me.TTIPO_RIN4)
        Me.Split2.Controls.Add(Me.TTIPO_RIN11)
        Me.Split2.Controls.Add(Me.TTIPO_RIN6)
        Me.Split2.Controls.Add(Me.TTIPO_RIN3)
        Me.Split2.Controls.Add(Me.TTIPO_RIN10)
        Me.Split2.Controls.Add(Me.Label22)
        Me.Split2.Controls.Add(Me.TTIPO_RIN7)
        Me.Split2.Controls.Add(Me.TTIPO_RIN2)
        Me.Split2.Controls.Add(Me.TTIPO_RIN9)
        Me.Split2.Controls.Add(Me.TTIPO_RIN8)
        Me.Split2.Controls.Add(Me.TTIPO_RIN1)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL5)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL12)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL6)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL4)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL11)
        Me.Split2.Controls.Add(Me.Label21)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL7)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL3)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL10)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL1)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL8)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL2)
        Me.Split2.Controls.Add(Me.TKM_ACTUAL9)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL15)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL112)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL14)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL16)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL111)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL13)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL17)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL110)
        Me.Split2.Controls.Add(Me.Label20)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL12)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL11)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL18)
        Me.Split2.Controls.Add(Me.TPRESION_ACTUAL19)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL45)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL412)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL44)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL46)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL411)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL43)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL47)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL410)
        Me.Split2.Controls.Add(Me.Label18)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL42)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL41)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL48)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL49)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL35)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL312)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL34)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL36)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL311)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL33)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL37)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL310)
        Me.Split2.Controls.Add(Me.Label19)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL32)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL31)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL38)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL39)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL25)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL212)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL24)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL26)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL211)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL23)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL27)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL210)
        Me.Split2.Controls.Add(Me.Label16)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL22)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL21)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL28)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL29)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS12)
        Me.Split2.Controls.Add(Me.TLL1)
        Me.Split2.Controls.Add(Me.TDESGASTE5)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE12)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR5)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL5)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA12)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR5)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL15)
        Me.Split2.Controls.Add(Me.TObs12)
        Me.Split2.Controls.Add(Me.TPOSICION5)
        Me.Split2.Controls.Add(Me.TMODELO1)
        Me.Split2.Controls.Add(Me.TObs5)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL112)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA5)
        Me.Split2.Controls.Add(Me.Label3)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA5)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL12)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA5)
        Me.Split2.Controls.Add(Me.Label14)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE5)
        Me.Split2.Controls.Add(Me.TDESGASTE12)
        Me.Split2.Controls.Add(Me.TMARCA5)
        Me.Split2.Controls.Add(Me.Label4)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS5)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR12)
        Me.Split2.Controls.Add(Me.TMODELO5)
        Me.Split2.Controls.Add(Me.TMARCA1)
        Me.Split2.Controls.Add(Me.TMODELO6)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR12)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS4)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA1)
        Me.Split2.Controls.Add(Me.TMARCA6)
        Me.Split2.Controls.Add(Me.TPOSICION12)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE4)
        Me.Split2.Controls.Add(Me.Label119)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA6)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA12)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA4)
        Me.Split2.Controls.Add(Me.Label118)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA6)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA12)
        Me.Split2.Controls.Add(Me.TObs4)
        Me.Split2.Controls.Add(Me.TLL2)
        Me.Split2.Controls.Add(Me.TPOSICION6)
        Me.Split2.Controls.Add(Me.TMARCA12)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL14)
        Me.Split2.Controls.Add(Me.Label117)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR6)
        Me.Split2.Controls.Add(Me.TMODELO12)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL4)
        Me.Split2.Controls.Add(Me.TLL3)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR6)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS11)
        Me.Split2.Controls.Add(Me.TDESGASTE4)
        Me.Split2.Controls.Add(Me.Label5)
        Me.Split2.Controls.Add(Me.TDESGASTE6)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE11)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR4)
        Me.Split2.Controls.Add(Me.Label95)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL6)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA11)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR4)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA1)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL16)
        Me.Split2.Controls.Add(Me.TObs11)
        Me.Split2.Controls.Add(Me.TPOSICION4)
        Me.Split2.Controls.Add(Me.TLL4)
        Me.Split2.Controls.Add(Me.TObs6)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL111)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA4)
        Me.Split2.Controls.Add(Me.Label91)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA6)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL11)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA4)
        Me.Split2.Controls.Add(Me.TLL5)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE6)
        Me.Split2.Controls.Add(Me.TDESGASTE11)
        Me.Split2.Controls.Add(Me.TMARCA4)
        Me.Split2.Controls.Add(Me.Label129)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS6)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR11)
        Me.Split2.Controls.Add(Me.TMODELO4)
        Me.Split2.Controls.Add(Me.Label13)
        Me.Split2.Controls.Add(Me.TMODELO7)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR11)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS3)
        Me.Split2.Controls.Add(Me.Label15)
        Me.Split2.Controls.Add(Me.TMARCA7)
        Me.Split2.Controls.Add(Me.TPOSICION11)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE3)
        Me.Split2.Controls.Add(Me.Label128)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA7)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA11)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA3)
        Me.Split2.Controls.Add(Me.TLL7)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA7)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA11)
        Me.Split2.Controls.Add(Me.TObs3)
        Me.Split2.Controls.Add(Me.Label17)
        Me.Split2.Controls.Add(Me.TPOSICION7)
        Me.Split2.Controls.Add(Me.TMARCA11)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL13)
        Me.Split2.Controls.Add(Me.TPOSICION1)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR7)
        Me.Split2.Controls.Add(Me.TMODELO11)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL3)
        Me.Split2.Controls.Add(Me.TLL6)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR7)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS10)
        Me.Split2.Controls.Add(Me.TDESGASTE3)
        Me.Split2.Controls.Add(Me.Label127)
        Me.Split2.Controls.Add(Me.TDESGASTE7)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE10)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR3)
        Me.Split2.Controls.Add(Me.Label8)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL7)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA10)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR3)
        Me.Split2.Controls.Add(Me.TLL8)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL17)
        Me.Split2.Controls.Add(Me.TObs10)
        Me.Split2.Controls.Add(Me.TPOSICION3)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR1)
        Me.Split2.Controls.Add(Me.TObs7)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL110)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA3)
        Me.Split2.Controls.Add(Me.Et9)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA7)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL10)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA3)
        Me.Split2.Controls.Add(Me.Label1)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE7)
        Me.Split2.Controls.Add(Me.TDESGASTE10)
        Me.Split2.Controls.Add(Me.TMARCA3)
        Me.Split2.Controls.Add(Me.Label6)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS7)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR10)
        Me.Split2.Controls.Add(Me.TMODELO3)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR1)
        Me.Split2.Controls.Add(Me.TMODELO8)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR10)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS2)
        Me.Split2.Controls.Add(Me.TLL9)
        Me.Split2.Controls.Add(Me.TMARCA8)
        Me.Split2.Controls.Add(Me.TPOSICION10)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE2)
        Me.Split2.Controls.Add(Me.Label7)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA8)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA10)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA2)
        Me.Split2.Controls.Add(Me.Et10)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA8)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA10)
        Me.Split2.Controls.Add(Me.TObs2)
        Me.Split2.Controls.Add(Me.TDESGASTE1)
        Me.Split2.Controls.Add(Me.TPOSICION8)
        Me.Split2.Controls.Add(Me.TMARCA10)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL12)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL1)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR8)
        Me.Split2.Controls.Add(Me.TMODELO10)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL2)
        Me.Split2.Controls.Add(Me.LtObser)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR8)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS9)
        Me.Split2.Controls.Add(Me.TDESGASTE2)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL11)
        Me.Split2.Controls.Add(Me.TDESGASTE8)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE9)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR2)
        Me.Split2.Controls.Add(Me.TObs1)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL8)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA9)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR2)
        Me.Split2.Controls.Add(Me.TLL10)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL18)
        Me.Split2.Controls.Add(Me.TObs9)
        Me.Split2.Controls.Add(Me.TPOSICION2)
        Me.Split2.Controls.Add(Me.Et11)
        Me.Split2.Controls.Add(Me.TObs8)
        Me.Split2.Controls.Add(Me.TPROFUNDIDAD_ACTUAL19)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA2)
        Me.Split2.Controls.Add(Me.TLL11)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA8)
        Me.Split2.Controls.Add(Me.TPROFUNDIDA_ORIGINAL9)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA2)
        Me.Split2.Controls.Add(Me.Et12)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE8)
        Me.Split2.Controls.Add(Me.TDESGASTE9)
        Me.Split2.Controls.Add(Me.TMARCA2)
        Me.Split2.Controls.Add(Me.TLL12)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS8)
        Me.Split2.Controls.Add(Me.TKMS_DESMONTAR9)
        Me.Split2.Controls.Add(Me.TMODELO2)
        Me.Split2.Controls.Add(Me.Label11)
        Me.Split2.Controls.Add(Me.TMODELO9)
        Me.Split2.Controls.Add(Me.TKMS_MONTAR9)
        Me.Split2.Controls.Add(Me.TKM_RECORRIDOS1)
        Me.Split2.Controls.Add(Me.Label2)
        Me.Split2.Controls.Add(Me.TMARCA9)
        Me.Split2.Controls.Add(Me.TPOSICION9)
        Me.Split2.Controls.Add(Me.Label12)
        Me.Split2.Controls.Add(Me.TNUEVA_RENOVADA1)
        Me.Split2.Controls.Add(Me.TTIPO_LLANTA9)
        Me.Split2.Controls.Add(Me.TCOSTO_LLANTA9)
        Me.Split2.Controls.Add(Me.TFECHA_MONTAJE1)
        Me.Split2.Height = 332
        Me.Split2.Location = New System.Drawing.Point(1, 189)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1477, 332)
        Me.Split2.TabIndex = 1
        '
        'TKM_ACTUAL5
        '
        Me.TKM_ACTUAL5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL5.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL5.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL5.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL5.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL5.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL5.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL5.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL5.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL5.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL5.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL5.Enabled = False
        Me.TKM_ACTUAL5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL5.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL5.InterceptArrowKeys = False
        Me.TKM_ACTUAL5.Location = New System.Drawing.Point(760, 127)
        Me.TKM_ACTUAL5.Name = "TKM_ACTUAL5"
        Me.TKM_ACTUAL5.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL5.TabIndex = 90
        Me.TKM_ACTUAL5.Tag = Nothing
        Me.TKM_ACTUAL5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL5.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL12
        '
        Me.TKM_ACTUAL12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL12.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL12.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL12.Enabled = False
        Me.TKM_ACTUAL12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL12.InterceptArrowKeys = False
        Me.TKM_ACTUAL12.Location = New System.Drawing.Point(760, 282)
        Me.TKM_ACTUAL12.Name = "TKM_ACTUAL12"
        Me.TKM_ACTUAL12.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL12.TabIndex = 231
        Me.TKM_ACTUAL12.Tag = Nothing
        Me.TKM_ACTUAL12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL6
        '
        Me.TKM_ACTUAL6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL6.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL6.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL6.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL6.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL6.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL6.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL6.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL6.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL6.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL6.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL6.Enabled = False
        Me.TKM_ACTUAL6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL6.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL6.InterceptArrowKeys = False
        Me.TKM_ACTUAL6.Location = New System.Drawing.Point(760, 149)
        Me.TKM_ACTUAL6.Name = "TKM_ACTUAL6"
        Me.TKM_ACTUAL6.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL6.TabIndex = 110
        Me.TKM_ACTUAL6.Tag = Nothing
        Me.TKM_ACTUAL6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL6.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL4
        '
        Me.TKM_ACTUAL4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL4.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL4.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL4.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL4.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL4.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL4.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL4.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL4.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL4.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL4.Enabled = False
        Me.TKM_ACTUAL4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL4.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL4.InterceptArrowKeys = False
        Me.TKM_ACTUAL4.Location = New System.Drawing.Point(760, 105)
        Me.TKM_ACTUAL4.Name = "TKM_ACTUAL4"
        Me.TKM_ACTUAL4.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL4.TabIndex = 70
        Me.TKM_ACTUAL4.Tag = Nothing
        Me.TKM_ACTUAL4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL4.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL11
        '
        Me.TKM_ACTUAL11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL11.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL11.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL11.Enabled = False
        Me.TKM_ACTUAL11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL11.InterceptArrowKeys = False
        Me.TKM_ACTUAL11.Location = New System.Drawing.Point(760, 260)
        Me.TKM_ACTUAL11.Name = "TKM_ACTUAL11"
        Me.TKM_ACTUAL11.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL11.TabIndex = 210
        Me.TKM_ACTUAL11.Tag = Nothing
        Me.TKM_ACTUAL11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(758, 4)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 31)
        Me.Label21.TabIndex = 710
        Me.Label21.Text = "Kms. actual"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TKM_ACTUAL7
        '
        Me.TKM_ACTUAL7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL7.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL7.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL7.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL7.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL7.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL7.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL7.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL7.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL7.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL7.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL7.Enabled = False
        Me.TKM_ACTUAL7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL7.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL7.InterceptArrowKeys = False
        Me.TKM_ACTUAL7.Location = New System.Drawing.Point(760, 171)
        Me.TKM_ACTUAL7.Name = "TKM_ACTUAL7"
        Me.TKM_ACTUAL7.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL7.TabIndex = 130
        Me.TKM_ACTUAL7.Tag = Nothing
        Me.TKM_ACTUAL7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL7.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL7.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL3
        '
        Me.TKM_ACTUAL3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL3.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL3.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL3.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL3.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL3.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL3.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL3.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL3.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL3.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL3.Enabled = False
        Me.TKM_ACTUAL3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL3.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL3.InterceptArrowKeys = False
        Me.TKM_ACTUAL3.Location = New System.Drawing.Point(760, 83)
        Me.TKM_ACTUAL3.Name = "TKM_ACTUAL3"
        Me.TKM_ACTUAL3.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL3.TabIndex = 50
        Me.TKM_ACTUAL3.Tag = Nothing
        Me.TKM_ACTUAL3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL3.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL10
        '
        Me.TKM_ACTUAL10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL10.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL10.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL10.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL10.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL10.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL10.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL10.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL10.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL10.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL10.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL10.Enabled = False
        Me.TKM_ACTUAL10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL10.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL10.InterceptArrowKeys = False
        Me.TKM_ACTUAL10.Location = New System.Drawing.Point(760, 238)
        Me.TKM_ACTUAL10.Name = "TKM_ACTUAL10"
        Me.TKM_ACTUAL10.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL10.TabIndex = 190
        Me.TKM_ACTUAL10.Tag = Nothing
        Me.TKM_ACTUAL10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL10.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL10.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL1
        '
        Me.TKM_ACTUAL1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL1.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL1.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL1.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL1.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL1.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL1.InterceptArrowKeys = False
        Me.TKM_ACTUAL1.Location = New System.Drawing.Point(760, 39)
        Me.TKM_ACTUAL1.Name = "TKM_ACTUAL1"
        Me.TKM_ACTUAL1.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL1.TabIndex = 10
        Me.TKM_ACTUAL1.Tag = Nothing
        Me.TKM_ACTUAL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL8
        '
        Me.TKM_ACTUAL8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL8.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL8.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL8.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL8.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL8.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL8.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL8.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL8.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL8.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL8.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL8.Enabled = False
        Me.TKM_ACTUAL8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL8.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL8.InterceptArrowKeys = False
        Me.TKM_ACTUAL8.Location = New System.Drawing.Point(760, 193)
        Me.TKM_ACTUAL8.Name = "TKM_ACTUAL8"
        Me.TKM_ACTUAL8.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL8.TabIndex = 150
        Me.TKM_ACTUAL8.Tag = Nothing
        Me.TKM_ACTUAL8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL8.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL8.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL8.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL2
        '
        Me.TKM_ACTUAL2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL2.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL2.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL2.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL2.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL2.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL2.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL2.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL2.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL2.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL2.Enabled = False
        Me.TKM_ACTUAL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL2.InterceptArrowKeys = False
        Me.TKM_ACTUAL2.Location = New System.Drawing.Point(760, 61)
        Me.TKM_ACTUAL2.Name = "TKM_ACTUAL2"
        Me.TKM_ACTUAL2.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL2.TabIndex = 30
        Me.TKM_ACTUAL2.Tag = Nothing
        Me.TKM_ACTUAL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TKM_ACTUAL9
        '
        Me.TKM_ACTUAL9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL9.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TKM_ACTUAL9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKM_ACTUAL9.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKM_ACTUAL9.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TKM_ACTUAL9.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKM_ACTUAL9.DisplayFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL9.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL9.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL9.EditFormat.CustomFormat = "###,###,##0"
        Me.TKM_ACTUAL9.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKM_ACTUAL9.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKM_ACTUAL9.Enabled = False
        Me.TKM_ACTUAL9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKM_ACTUAL9.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKM_ACTUAL9.InterceptArrowKeys = False
        Me.TKM_ACTUAL9.Location = New System.Drawing.Point(760, 216)
        Me.TKM_ACTUAL9.Name = "TKM_ACTUAL9"
        Me.TKM_ACTUAL9.Size = New System.Drawing.Size(59, 18)
        Me.TKM_ACTUAL9.TabIndex = 170
        Me.TKM_ACTUAL9.Tag = Nothing
        Me.TKM_ACTUAL9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKM_ACTUAL9.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TKM_ACTUAL9.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKM_ACTUAL9.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL15
        '
        Me.TPRESION_ACTUAL15.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL15.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL15.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL15.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL15.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL15.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL15.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL15.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL15.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL15.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL15.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL15.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL15.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL15.Location = New System.Drawing.Point(1044, 127)
        Me.TPRESION_ACTUAL15.Name = "TPRESION_ACTUAL15"
        Me.TPRESION_ACTUAL15.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL15.TabIndex = 96
        Me.TPRESION_ACTUAL15.Tag = Nothing
        Me.TPRESION_ACTUAL15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL15.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL15.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL15.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL112
        '
        Me.TPRESION_ACTUAL112.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL112.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL112.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL112.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL112.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL112.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL112.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL112.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL112.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL112.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL112.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL112.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL112.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL112.Location = New System.Drawing.Point(1044, 282)
        Me.TPRESION_ACTUAL112.Name = "TPRESION_ACTUAL112"
        Me.TPRESION_ACTUAL112.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL112.TabIndex = 237
        Me.TPRESION_ACTUAL112.Tag = Nothing
        Me.TPRESION_ACTUAL112.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL112.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL112.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL112.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL14
        '
        Me.TPRESION_ACTUAL14.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL14.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL14.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL14.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL14.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL14.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL14.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL14.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL14.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL14.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL14.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL14.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL14.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL14.Location = New System.Drawing.Point(1044, 105)
        Me.TPRESION_ACTUAL14.Name = "TPRESION_ACTUAL14"
        Me.TPRESION_ACTUAL14.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL14.TabIndex = 76
        Me.TPRESION_ACTUAL14.Tag = Nothing
        Me.TPRESION_ACTUAL14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL14.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL14.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL14.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL16
        '
        Me.TPRESION_ACTUAL16.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL16.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL16.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL16.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL16.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL16.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL16.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL16.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL16.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL16.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL16.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL16.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL16.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL16.Location = New System.Drawing.Point(1044, 149)
        Me.TPRESION_ACTUAL16.Name = "TPRESION_ACTUAL16"
        Me.TPRESION_ACTUAL16.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL16.TabIndex = 116
        Me.TPRESION_ACTUAL16.Tag = Nothing
        Me.TPRESION_ACTUAL16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL16.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL16.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL16.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL111
        '
        Me.TPRESION_ACTUAL111.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL111.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL111.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL111.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL111.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL111.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL111.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL111.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL111.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL111.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL111.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL111.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL111.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL111.Location = New System.Drawing.Point(1044, 260)
        Me.TPRESION_ACTUAL111.Name = "TPRESION_ACTUAL111"
        Me.TPRESION_ACTUAL111.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL111.TabIndex = 216
        Me.TPRESION_ACTUAL111.Tag = Nothing
        Me.TPRESION_ACTUAL111.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL111.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL111.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL111.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL13
        '
        Me.TPRESION_ACTUAL13.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL13.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL13.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL13.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL13.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL13.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL13.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL13.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL13.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL13.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL13.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL13.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL13.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL13.Location = New System.Drawing.Point(1044, 83)
        Me.TPRESION_ACTUAL13.Name = "TPRESION_ACTUAL13"
        Me.TPRESION_ACTUAL13.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL13.TabIndex = 56
        Me.TPRESION_ACTUAL13.Tag = Nothing
        Me.TPRESION_ACTUAL13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL13.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL13.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL13.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL17
        '
        Me.TPRESION_ACTUAL17.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL17.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL17.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL17.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL17.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL17.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL17.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL17.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL17.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL17.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL17.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL17.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL17.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL17.Location = New System.Drawing.Point(1044, 171)
        Me.TPRESION_ACTUAL17.Name = "TPRESION_ACTUAL17"
        Me.TPRESION_ACTUAL17.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL17.TabIndex = 136
        Me.TPRESION_ACTUAL17.Tag = Nothing
        Me.TPRESION_ACTUAL17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL17.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL17.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL17.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL110
        '
        Me.TPRESION_ACTUAL110.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL110.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL110.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL110.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL110.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL110.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL110.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL110.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL110.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL110.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL110.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL110.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL110.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL110.Location = New System.Drawing.Point(1044, 238)
        Me.TPRESION_ACTUAL110.Name = "TPRESION_ACTUAL110"
        Me.TPRESION_ACTUAL110.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL110.TabIndex = 196
        Me.TPRESION_ACTUAL110.Tag = Nothing
        Me.TPRESION_ACTUAL110.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL110.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL110.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL110.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(1044, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 31)
        Me.Label20.TabIndex = 697
        Me.Label20.Text = "Presión actual"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TPRESION_ACTUAL12
        '
        Me.TPRESION_ACTUAL12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL12.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL12.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL12.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL12.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL12.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL12.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL12.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL12.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL12.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL12.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL12.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL12.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL12.Location = New System.Drawing.Point(1044, 61)
        Me.TPRESION_ACTUAL12.Name = "TPRESION_ACTUAL12"
        Me.TPRESION_ACTUAL12.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL12.TabIndex = 36
        Me.TPRESION_ACTUAL12.Tag = Nothing
        Me.TPRESION_ACTUAL12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL12.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL12.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL11
        '
        Me.TPRESION_ACTUAL11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL11.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL11.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL11.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL11.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL11.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL11.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL11.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL11.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL11.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL11.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL11.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL11.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL11.Location = New System.Drawing.Point(1044, 39)
        Me.TPRESION_ACTUAL11.Name = "TPRESION_ACTUAL11"
        Me.TPRESION_ACTUAL11.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL11.TabIndex = 16
        Me.TPRESION_ACTUAL11.Tag = Nothing
        Me.TPRESION_ACTUAL11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL11.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL11.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL18
        '
        Me.TPRESION_ACTUAL18.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL18.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL18.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL18.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL18.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL18.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL18.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL18.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL18.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL18.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL18.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL18.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL18.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL18.Location = New System.Drawing.Point(1044, 193)
        Me.TPRESION_ACTUAL18.Name = "TPRESION_ACTUAL18"
        Me.TPRESION_ACTUAL18.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL18.TabIndex = 156
        Me.TPRESION_ACTUAL18.Tag = Nothing
        Me.TPRESION_ACTUAL18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL18.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL18.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL18.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPRESION_ACTUAL19
        '
        Me.TPRESION_ACTUAL19.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL19.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPRESION_ACTUAL19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPRESION_ACTUAL19.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPRESION_ACTUAL19.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPRESION_ACTUAL19.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPRESION_ACTUAL19.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL19.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL19.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL19.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPRESION_ACTUAL19.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPRESION_ACTUAL19.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPRESION_ACTUAL19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPRESION_ACTUAL19.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPRESION_ACTUAL19.InterceptArrowKeys = False
        Me.TPRESION_ACTUAL19.Location = New System.Drawing.Point(1044, 216)
        Me.TPRESION_ACTUAL19.Name = "TPRESION_ACTUAL19"
        Me.TPRESION_ACTUAL19.Size = New System.Drawing.Size(41, 18)
        Me.TPRESION_ACTUAL19.TabIndex = 176
        Me.TPRESION_ACTUAL19.Tag = Nothing
        Me.TPRESION_ACTUAL19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPRESION_ACTUAL19.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPRESION_ACTUAL19.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPRESION_ACTUAL19.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL45
        '
        Me.TPROFUNDIDAD_ACTUAL45.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL45.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL45.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL45.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL45.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL45.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL45.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL45.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL45.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL45.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL45.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL45.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL45.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL45.Location = New System.Drawing.Point(1002, 126)
        Me.TPROFUNDIDAD_ACTUAL45.Name = "TPROFUNDIDAD_ACTUAL45"
        Me.TPROFUNDIDAD_ACTUAL45.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL45.TabIndex = 95
        Me.TPROFUNDIDAD_ACTUAL45.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL45.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL45.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL45.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL45.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL412
        '
        Me.TPROFUNDIDAD_ACTUAL412.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL412.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL412.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL412.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL412.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL412.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL412.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL412.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL412.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL412.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL412.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL412.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL412.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL412.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL412.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL412.Location = New System.Drawing.Point(1002, 281)
        Me.TPROFUNDIDAD_ACTUAL412.Name = "TPROFUNDIDAD_ACTUAL412"
        Me.TPROFUNDIDAD_ACTUAL412.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL412.TabIndex = 236
        Me.TPROFUNDIDAD_ACTUAL412.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL412.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL412.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL412.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL412.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL44
        '
        Me.TPROFUNDIDAD_ACTUAL44.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL44.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL44.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL44.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL44.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL44.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL44.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL44.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL44.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL44.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL44.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL44.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL44.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL44.Location = New System.Drawing.Point(1002, 104)
        Me.TPROFUNDIDAD_ACTUAL44.Name = "TPROFUNDIDAD_ACTUAL44"
        Me.TPROFUNDIDAD_ACTUAL44.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL44.TabIndex = 75
        Me.TPROFUNDIDAD_ACTUAL44.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL44.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL44.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL44.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL44.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL46
        '
        Me.TPROFUNDIDAD_ACTUAL46.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL46.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL46.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL46.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL46.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL46.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL46.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL46.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL46.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL46.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL46.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL46.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL46.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL46.Location = New System.Drawing.Point(1002, 148)
        Me.TPROFUNDIDAD_ACTUAL46.Name = "TPROFUNDIDAD_ACTUAL46"
        Me.TPROFUNDIDAD_ACTUAL46.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL46.TabIndex = 115
        Me.TPROFUNDIDAD_ACTUAL46.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL46.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL46.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL46.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL46.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL411
        '
        Me.TPROFUNDIDAD_ACTUAL411.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL411.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL411.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL411.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL411.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL411.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL411.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL411.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL411.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL411.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL411.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL411.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL411.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL411.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL411.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL411.Location = New System.Drawing.Point(1002, 259)
        Me.TPROFUNDIDAD_ACTUAL411.Name = "TPROFUNDIDAD_ACTUAL411"
        Me.TPROFUNDIDAD_ACTUAL411.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL411.TabIndex = 215
        Me.TPROFUNDIDAD_ACTUAL411.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL411.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL411.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL411.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL411.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL43
        '
        Me.TPROFUNDIDAD_ACTUAL43.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL43.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL43.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL43.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL43.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL43.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL43.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL43.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL43.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL43.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL43.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL43.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL43.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL43.Location = New System.Drawing.Point(1002, 82)
        Me.TPROFUNDIDAD_ACTUAL43.Name = "TPROFUNDIDAD_ACTUAL43"
        Me.TPROFUNDIDAD_ACTUAL43.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL43.TabIndex = 55
        Me.TPROFUNDIDAD_ACTUAL43.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL43.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL43.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL43.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL43.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL47
        '
        Me.TPROFUNDIDAD_ACTUAL47.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL47.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL47.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL47.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL47.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL47.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL47.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL47.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL47.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL47.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL47.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL47.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL47.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL47.Location = New System.Drawing.Point(1002, 170)
        Me.TPROFUNDIDAD_ACTUAL47.Name = "TPROFUNDIDAD_ACTUAL47"
        Me.TPROFUNDIDAD_ACTUAL47.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL47.TabIndex = 135
        Me.TPROFUNDIDAD_ACTUAL47.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL47.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL47.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL47.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL47.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL410
        '
        Me.TPROFUNDIDAD_ACTUAL410.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL410.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL410.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL410.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL410.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL410.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL410.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL410.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL410.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL410.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL410.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL410.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL410.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL410.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL410.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL410.Location = New System.Drawing.Point(1002, 237)
        Me.TPROFUNDIDAD_ACTUAL410.Name = "TPROFUNDIDAD_ACTUAL410"
        Me.TPROFUNDIDAD_ACTUAL410.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL410.TabIndex = 195
        Me.TPROFUNDIDAD_ACTUAL410.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL410.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL410.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL410.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL410.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(1000, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 31)
        Me.Label18.TabIndex = 684
        Me.Label18.Text = "Prof.  actual 4"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TPROFUNDIDAD_ACTUAL42
        '
        Me.TPROFUNDIDAD_ACTUAL42.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL42.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL42.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL42.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL42.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL42.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL42.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL42.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL42.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL42.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL42.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL42.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL42.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL42.Location = New System.Drawing.Point(1002, 60)
        Me.TPROFUNDIDAD_ACTUAL42.Name = "TPROFUNDIDAD_ACTUAL42"
        Me.TPROFUNDIDAD_ACTUAL42.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL42.TabIndex = 35
        Me.TPROFUNDIDAD_ACTUAL42.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL42.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL42.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL42.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL42.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL41
        '
        Me.TPROFUNDIDAD_ACTUAL41.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL41.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL41.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL41.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL41.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL41.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL41.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL41.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL41.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL41.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL41.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL41.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL41.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL41.Location = New System.Drawing.Point(1002, 38)
        Me.TPROFUNDIDAD_ACTUAL41.Name = "TPROFUNDIDAD_ACTUAL41"
        Me.TPROFUNDIDAD_ACTUAL41.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL41.TabIndex = 15
        Me.TPROFUNDIDAD_ACTUAL41.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL41.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL41.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL41.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL41.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL48
        '
        Me.TPROFUNDIDAD_ACTUAL48.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL48.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL48.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL48.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL48.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL48.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL48.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL48.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL48.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL48.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL48.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL48.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL48.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL48.Location = New System.Drawing.Point(1002, 192)
        Me.TPROFUNDIDAD_ACTUAL48.Name = "TPROFUNDIDAD_ACTUAL48"
        Me.TPROFUNDIDAD_ACTUAL48.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL48.TabIndex = 155
        Me.TPROFUNDIDAD_ACTUAL48.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL48.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL48.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL48.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL48.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL49
        '
        Me.TPROFUNDIDAD_ACTUAL49.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL49.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL49.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL49.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL49.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL49.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL49.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL49.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL49.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL49.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL49.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL49.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL49.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL49.Location = New System.Drawing.Point(1002, 215)
        Me.TPROFUNDIDAD_ACTUAL49.Name = "TPROFUNDIDAD_ACTUAL49"
        Me.TPROFUNDIDAD_ACTUAL49.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL49.TabIndex = 175
        Me.TPROFUNDIDAD_ACTUAL49.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL49.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL49.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL49.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL49.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL35
        '
        Me.TPROFUNDIDAD_ACTUAL35.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL35.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL35.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL35.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL35.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL35.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL35.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL35.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL35.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL35.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL35.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL35.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL35.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL35.Location = New System.Drawing.Point(960, 126)
        Me.TPROFUNDIDAD_ACTUAL35.Name = "TPROFUNDIDAD_ACTUAL35"
        Me.TPROFUNDIDAD_ACTUAL35.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL35.TabIndex = 94
        Me.TPROFUNDIDAD_ACTUAL35.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL35.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL35.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL35.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL35.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL312
        '
        Me.TPROFUNDIDAD_ACTUAL312.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL312.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL312.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL312.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL312.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL312.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL312.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL312.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL312.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL312.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL312.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL312.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL312.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL312.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL312.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL312.Location = New System.Drawing.Point(960, 281)
        Me.TPROFUNDIDAD_ACTUAL312.Name = "TPROFUNDIDAD_ACTUAL312"
        Me.TPROFUNDIDAD_ACTUAL312.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL312.TabIndex = 235
        Me.TPROFUNDIDAD_ACTUAL312.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL312.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL312.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL312.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL312.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL34
        '
        Me.TPROFUNDIDAD_ACTUAL34.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL34.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL34.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL34.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL34.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL34.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL34.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL34.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL34.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL34.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL34.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL34.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL34.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL34.Location = New System.Drawing.Point(960, 104)
        Me.TPROFUNDIDAD_ACTUAL34.Name = "TPROFUNDIDAD_ACTUAL34"
        Me.TPROFUNDIDAD_ACTUAL34.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL34.TabIndex = 74
        Me.TPROFUNDIDAD_ACTUAL34.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL34.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL34.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL34.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL34.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL36
        '
        Me.TPROFUNDIDAD_ACTUAL36.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL36.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL36.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL36.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL36.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL36.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL36.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL36.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL36.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL36.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL36.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL36.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL36.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL36.Location = New System.Drawing.Point(960, 148)
        Me.TPROFUNDIDAD_ACTUAL36.Name = "TPROFUNDIDAD_ACTUAL36"
        Me.TPROFUNDIDAD_ACTUAL36.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL36.TabIndex = 114
        Me.TPROFUNDIDAD_ACTUAL36.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL36.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL36.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL36.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL36.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL311
        '
        Me.TPROFUNDIDAD_ACTUAL311.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL311.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL311.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL311.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL311.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL311.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL311.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL311.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL311.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL311.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL311.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL311.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL311.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL311.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL311.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL311.Location = New System.Drawing.Point(960, 259)
        Me.TPROFUNDIDAD_ACTUAL311.Name = "TPROFUNDIDAD_ACTUAL311"
        Me.TPROFUNDIDAD_ACTUAL311.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL311.TabIndex = 214
        Me.TPROFUNDIDAD_ACTUAL311.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL311.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL311.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL311.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL311.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL33
        '
        Me.TPROFUNDIDAD_ACTUAL33.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL33.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL33.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL33.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL33.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL33.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL33.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL33.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL33.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL33.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL33.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL33.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL33.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL33.Location = New System.Drawing.Point(960, 82)
        Me.TPROFUNDIDAD_ACTUAL33.Name = "TPROFUNDIDAD_ACTUAL33"
        Me.TPROFUNDIDAD_ACTUAL33.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL33.TabIndex = 54
        Me.TPROFUNDIDAD_ACTUAL33.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL33.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL33.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL33.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL33.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL37
        '
        Me.TPROFUNDIDAD_ACTUAL37.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL37.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL37.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL37.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL37.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL37.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL37.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL37.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL37.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL37.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL37.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL37.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL37.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL37.Location = New System.Drawing.Point(960, 170)
        Me.TPROFUNDIDAD_ACTUAL37.Name = "TPROFUNDIDAD_ACTUAL37"
        Me.TPROFUNDIDAD_ACTUAL37.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL37.TabIndex = 134
        Me.TPROFUNDIDAD_ACTUAL37.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL37.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL37.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL37.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL37.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL310
        '
        Me.TPROFUNDIDAD_ACTUAL310.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL310.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL310.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL310.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL310.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL310.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL310.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL310.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL310.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL310.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL310.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL310.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL310.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL310.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL310.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL310.Location = New System.Drawing.Point(960, 237)
        Me.TPROFUNDIDAD_ACTUAL310.Name = "TPROFUNDIDAD_ACTUAL310"
        Me.TPROFUNDIDAD_ACTUAL310.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL310.TabIndex = 194
        Me.TPROFUNDIDAD_ACTUAL310.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL310.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL310.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL310.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL310.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(957, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 31)
        Me.Label19.TabIndex = 671
        Me.Label19.Text = "Prof.  actual 3"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TPROFUNDIDAD_ACTUAL32
        '
        Me.TPROFUNDIDAD_ACTUAL32.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL32.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL32.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL32.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL32.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL32.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL32.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL32.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL32.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL32.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL32.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL32.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL32.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL32.Location = New System.Drawing.Point(960, 60)
        Me.TPROFUNDIDAD_ACTUAL32.Name = "TPROFUNDIDAD_ACTUAL32"
        Me.TPROFUNDIDAD_ACTUAL32.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL32.TabIndex = 34
        Me.TPROFUNDIDAD_ACTUAL32.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL32.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL32.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL32.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL32.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL31
        '
        Me.TPROFUNDIDAD_ACTUAL31.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL31.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL31.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL31.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL31.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL31.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL31.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL31.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL31.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL31.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL31.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL31.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL31.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL31.Location = New System.Drawing.Point(960, 38)
        Me.TPROFUNDIDAD_ACTUAL31.Name = "TPROFUNDIDAD_ACTUAL31"
        Me.TPROFUNDIDAD_ACTUAL31.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL31.TabIndex = 14
        Me.TPROFUNDIDAD_ACTUAL31.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL31.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL31.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL31.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL31.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL38
        '
        Me.TPROFUNDIDAD_ACTUAL38.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL38.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL38.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL38.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL38.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL38.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL38.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL38.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL38.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL38.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL38.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL38.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL38.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL38.Location = New System.Drawing.Point(960, 192)
        Me.TPROFUNDIDAD_ACTUAL38.Name = "TPROFUNDIDAD_ACTUAL38"
        Me.TPROFUNDIDAD_ACTUAL38.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL38.TabIndex = 154
        Me.TPROFUNDIDAD_ACTUAL38.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL38.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL38.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL38.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL38.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL39
        '
        Me.TPROFUNDIDAD_ACTUAL39.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL39.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL39.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL39.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL39.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL39.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL39.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL39.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL39.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL39.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL39.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL39.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL39.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL39.Location = New System.Drawing.Point(960, 215)
        Me.TPROFUNDIDAD_ACTUAL39.Name = "TPROFUNDIDAD_ACTUAL39"
        Me.TPROFUNDIDAD_ACTUAL39.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL39.TabIndex = 174
        Me.TPROFUNDIDAD_ACTUAL39.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL39.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL39.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL39.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL39.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL25
        '
        Me.TPROFUNDIDAD_ACTUAL25.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL25.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL25.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL25.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL25.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL25.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL25.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL25.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL25.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL25.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL25.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL25.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL25.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL25.Location = New System.Drawing.Point(918, 126)
        Me.TPROFUNDIDAD_ACTUAL25.Name = "TPROFUNDIDAD_ACTUAL25"
        Me.TPROFUNDIDAD_ACTUAL25.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL25.TabIndex = 93
        Me.TPROFUNDIDAD_ACTUAL25.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL25.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL25.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL25.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL212
        '
        Me.TPROFUNDIDAD_ACTUAL212.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL212.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL212.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL212.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL212.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL212.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL212.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL212.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL212.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL212.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL212.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL212.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL212.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL212.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL212.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL212.Location = New System.Drawing.Point(918, 281)
        Me.TPROFUNDIDAD_ACTUAL212.Name = "TPROFUNDIDAD_ACTUAL212"
        Me.TPROFUNDIDAD_ACTUAL212.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL212.TabIndex = 234
        Me.TPROFUNDIDAD_ACTUAL212.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL212.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL212.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL212.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL212.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL24
        '
        Me.TPROFUNDIDAD_ACTUAL24.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL24.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL24.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL24.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL24.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL24.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL24.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL24.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL24.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL24.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL24.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL24.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL24.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL24.Location = New System.Drawing.Point(918, 104)
        Me.TPROFUNDIDAD_ACTUAL24.Name = "TPROFUNDIDAD_ACTUAL24"
        Me.TPROFUNDIDAD_ACTUAL24.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL24.TabIndex = 73
        Me.TPROFUNDIDAD_ACTUAL24.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL24.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL24.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL24.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL26
        '
        Me.TPROFUNDIDAD_ACTUAL26.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL26.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL26.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL26.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL26.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL26.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL26.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL26.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL26.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL26.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL26.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL26.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL26.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL26.Location = New System.Drawing.Point(918, 148)
        Me.TPROFUNDIDAD_ACTUAL26.Name = "TPROFUNDIDAD_ACTUAL26"
        Me.TPROFUNDIDAD_ACTUAL26.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL26.TabIndex = 113
        Me.TPROFUNDIDAD_ACTUAL26.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL26.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL26.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL26.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL211
        '
        Me.TPROFUNDIDAD_ACTUAL211.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL211.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL211.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL211.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL211.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL211.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL211.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL211.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL211.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL211.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL211.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL211.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL211.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL211.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL211.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL211.Location = New System.Drawing.Point(918, 259)
        Me.TPROFUNDIDAD_ACTUAL211.Name = "TPROFUNDIDAD_ACTUAL211"
        Me.TPROFUNDIDAD_ACTUAL211.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL211.TabIndex = 213
        Me.TPROFUNDIDAD_ACTUAL211.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL211.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL211.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL211.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL211.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL23
        '
        Me.TPROFUNDIDAD_ACTUAL23.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL23.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL23.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL23.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL23.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL23.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL23.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL23.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL23.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL23.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL23.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL23.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL23.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL23.Location = New System.Drawing.Point(918, 82)
        Me.TPROFUNDIDAD_ACTUAL23.Name = "TPROFUNDIDAD_ACTUAL23"
        Me.TPROFUNDIDAD_ACTUAL23.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL23.TabIndex = 53
        Me.TPROFUNDIDAD_ACTUAL23.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL23.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL23.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL23.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL27
        '
        Me.TPROFUNDIDAD_ACTUAL27.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL27.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL27.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL27.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL27.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL27.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL27.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL27.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL27.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL27.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL27.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL27.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL27.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL27.Location = New System.Drawing.Point(918, 170)
        Me.TPROFUNDIDAD_ACTUAL27.Name = "TPROFUNDIDAD_ACTUAL27"
        Me.TPROFUNDIDAD_ACTUAL27.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL27.TabIndex = 133
        Me.TPROFUNDIDAD_ACTUAL27.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL27.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL27.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL27.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL210
        '
        Me.TPROFUNDIDAD_ACTUAL210.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL210.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL210.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL210.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL210.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL210.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL210.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL210.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL210.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL210.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL210.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL210.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL210.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL210.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL210.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL210.Location = New System.Drawing.Point(918, 237)
        Me.TPROFUNDIDAD_ACTUAL210.Name = "TPROFUNDIDAD_ACTUAL210"
        Me.TPROFUNDIDAD_ACTUAL210.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL210.TabIndex = 193
        Me.TPROFUNDIDAD_ACTUAL210.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL210.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL210.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL210.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL210.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(914, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 31)
        Me.Label16.TabIndex = 658
        Me.Label16.Text = "Prof.  actual 2"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TPROFUNDIDAD_ACTUAL22
        '
        Me.TPROFUNDIDAD_ACTUAL22.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL22.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL22.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL22.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL22.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL22.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL22.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL22.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL22.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL22.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL22.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL22.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL22.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL22.Location = New System.Drawing.Point(918, 60)
        Me.TPROFUNDIDAD_ACTUAL22.Name = "TPROFUNDIDAD_ACTUAL22"
        Me.TPROFUNDIDAD_ACTUAL22.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL22.TabIndex = 33
        Me.TPROFUNDIDAD_ACTUAL22.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL22.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL22.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL22.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL21
        '
        Me.TPROFUNDIDAD_ACTUAL21.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL21.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL21.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL21.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL21.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL21.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL21.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL21.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL21.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL21.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL21.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL21.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL21.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL21.Location = New System.Drawing.Point(918, 38)
        Me.TPROFUNDIDAD_ACTUAL21.Name = "TPROFUNDIDAD_ACTUAL21"
        Me.TPROFUNDIDAD_ACTUAL21.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL21.TabIndex = 13
        Me.TPROFUNDIDAD_ACTUAL21.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL21.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL21.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL21.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL28
        '
        Me.TPROFUNDIDAD_ACTUAL28.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL28.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL28.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL28.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL28.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL28.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL28.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL28.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL28.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL28.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL28.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL28.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL28.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL28.Location = New System.Drawing.Point(918, 192)
        Me.TPROFUNDIDAD_ACTUAL28.Name = "TPROFUNDIDAD_ACTUAL28"
        Me.TPROFUNDIDAD_ACTUAL28.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL28.TabIndex = 153
        Me.TPROFUNDIDAD_ACTUAL28.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL28.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL28.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL28.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TPROFUNDIDAD_ACTUAL29
        '
        Me.TPROFUNDIDAD_ACTUAL29.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL29.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.TPROFUNDIDAD_ACTUAL29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TPROFUNDIDAD_ACTUAL29.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TPROFUNDIDAD_ACTUAL29.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.TPROFUNDIDAD_ACTUAL29.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TPROFUNDIDAD_ACTUAL29.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL29.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL29.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL29.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TPROFUNDIDAD_ACTUAL29.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TPROFUNDIDAD_ACTUAL29.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TPROFUNDIDAD_ACTUAL29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPROFUNDIDAD_ACTUAL29.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TPROFUNDIDAD_ACTUAL29.InterceptArrowKeys = False
        Me.TPROFUNDIDAD_ACTUAL29.Location = New System.Drawing.Point(918, 215)
        Me.TPROFUNDIDAD_ACTUAL29.Name = "TPROFUNDIDAD_ACTUAL29"
        Me.TPROFUNDIDAD_ACTUAL29.Size = New System.Drawing.Size(41, 18)
        Me.TPROFUNDIDAD_ACTUAL29.TabIndex = 173
        Me.TPROFUNDIDAD_ACTUAL29.Tag = Nothing
        Me.TPROFUNDIDAD_ACTUAL29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TPROFUNDIDAD_ACTUAL29.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TPROFUNDIDAD_ACTUAL29.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TPROFUNDIDAD_ACTUAL29.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTIPO_RIN12
        '
        Me.TTIPO_RIN12.AcceptsReturn = True
        Me.TTIPO_RIN12.AcceptsTab = True
        Me.TTIPO_RIN12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN12.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN12.Location = New System.Drawing.Point(1173, 279)
        Me.TTIPO_RIN12.MaxLength = 20
        Me.TTIPO_RIN12.Name = "TTIPO_RIN12"
        Me.TTIPO_RIN12.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN12.TabIndex = 722
        Me.TTIPO_RIN12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN5
        '
        Me.TTIPO_RIN5.AcceptsReturn = True
        Me.TTIPO_RIN5.AcceptsTab = True
        Me.TTIPO_RIN5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN5.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN5.Location = New System.Drawing.Point(1173, 124)
        Me.TTIPO_RIN5.MaxLength = 20
        Me.TTIPO_RIN5.Name = "TTIPO_RIN5"
        Me.TTIPO_RIN5.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN5.TabIndex = 715
        Me.TTIPO_RIN5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN4
        '
        Me.TTIPO_RIN4.AcceptsReturn = True
        Me.TTIPO_RIN4.AcceptsTab = True
        Me.TTIPO_RIN4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN4.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN4.Location = New System.Drawing.Point(1173, 102)
        Me.TTIPO_RIN4.MaxLength = 20
        Me.TTIPO_RIN4.Name = "TTIPO_RIN4"
        Me.TTIPO_RIN4.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN4.TabIndex = 714
        Me.TTIPO_RIN4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN11
        '
        Me.TTIPO_RIN11.AcceptsReturn = True
        Me.TTIPO_RIN11.AcceptsTab = True
        Me.TTIPO_RIN11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN11.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN11.Location = New System.Drawing.Point(1173, 257)
        Me.TTIPO_RIN11.MaxLength = 20
        Me.TTIPO_RIN11.Name = "TTIPO_RIN11"
        Me.TTIPO_RIN11.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN11.TabIndex = 721
        Me.TTIPO_RIN11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN6
        '
        Me.TTIPO_RIN6.AcceptsReturn = True
        Me.TTIPO_RIN6.AcceptsTab = True
        Me.TTIPO_RIN6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN6.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN6.Location = New System.Drawing.Point(1173, 146)
        Me.TTIPO_RIN6.MaxLength = 20
        Me.TTIPO_RIN6.Name = "TTIPO_RIN6"
        Me.TTIPO_RIN6.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN6.TabIndex = 716
        Me.TTIPO_RIN6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN3
        '
        Me.TTIPO_RIN3.AcceptsReturn = True
        Me.TTIPO_RIN3.AcceptsTab = True
        Me.TTIPO_RIN3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN3.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN3.Location = New System.Drawing.Point(1173, 80)
        Me.TTIPO_RIN3.MaxLength = 20
        Me.TTIPO_RIN3.Name = "TTIPO_RIN3"
        Me.TTIPO_RIN3.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN3.TabIndex = 713
        Me.TTIPO_RIN3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN10
        '
        Me.TTIPO_RIN10.AcceptsReturn = True
        Me.TTIPO_RIN10.AcceptsTab = True
        Me.TTIPO_RIN10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN10.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN10.Location = New System.Drawing.Point(1173, 235)
        Me.TTIPO_RIN10.MaxLength = 20
        Me.TTIPO_RIN10.Name = "TTIPO_RIN10"
        Me.TTIPO_RIN10.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN10.TabIndex = 720
        Me.TTIPO_RIN10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(1191, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 13)
        Me.Label22.TabIndex = 723
        Me.Label22.Text = "Tipo de Rin"
        '
        'TTIPO_RIN7
        '
        Me.TTIPO_RIN7.AcceptsReturn = True
        Me.TTIPO_RIN7.AcceptsTab = True
        Me.TTIPO_RIN7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN7.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN7.Location = New System.Drawing.Point(1173, 168)
        Me.TTIPO_RIN7.MaxLength = 20
        Me.TTIPO_RIN7.Name = "TTIPO_RIN7"
        Me.TTIPO_RIN7.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN7.TabIndex = 717
        Me.TTIPO_RIN7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN2
        '
        Me.TTIPO_RIN2.AcceptsReturn = True
        Me.TTIPO_RIN2.AcceptsTab = True
        Me.TTIPO_RIN2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN2.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN2.Location = New System.Drawing.Point(1173, 58)
        Me.TTIPO_RIN2.MaxLength = 20
        Me.TTIPO_RIN2.Name = "TTIPO_RIN2"
        Me.TTIPO_RIN2.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN2.TabIndex = 712
        Me.TTIPO_RIN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN9
        '
        Me.TTIPO_RIN9.AcceptsReturn = True
        Me.TTIPO_RIN9.AcceptsTab = True
        Me.TTIPO_RIN9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN9.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN9.Location = New System.Drawing.Point(1173, 213)
        Me.TTIPO_RIN9.MaxLength = 20
        Me.TTIPO_RIN9.Name = "TTIPO_RIN9"
        Me.TTIPO_RIN9.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN9.TabIndex = 719
        Me.TTIPO_RIN9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN8
        '
        Me.TTIPO_RIN8.AcceptsReturn = True
        Me.TTIPO_RIN8.AcceptsTab = True
        Me.TTIPO_RIN8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN8.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN8.Location = New System.Drawing.Point(1173, 190)
        Me.TTIPO_RIN8.MaxLength = 20
        Me.TTIPO_RIN8.Name = "TTIPO_RIN8"
        Me.TTIPO_RIN8.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN8.TabIndex = 718
        Me.TTIPO_RIN8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTIPO_RIN1
        '
        Me.TTIPO_RIN1.AcceptsReturn = True
        Me.TTIPO_RIN1.AcceptsTab = True
        Me.TTIPO_RIN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTIPO_RIN1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTIPO_RIN1.ForeColor = System.Drawing.Color.Black
        Me.TTIPO_RIN1.Location = New System.Drawing.Point(1173, 36)
        Me.TTIPO_RIN1.MaxLength = 20
        Me.TTIPO_RIN1.Name = "TTIPO_RIN1"
        Me.TTIPO_RIN1.Size = New System.Drawing.Size(114, 20)
        Me.TTIPO_RIN1.TabIndex = 711
        Me.TTIPO_RIN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(126, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 16)
        Me.Label23.TabIndex = 655
        Me.Label23.Text = "Clave"
        '
        'LtCve_Ins
        '
        Me.LtCve_Ins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCve_Ins.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCve_Ins.Location = New System.Drawing.Point(172, 18)
        Me.LtCve_Ins.Name = "LtCve_Ins"
        Me.LtCve_Ins.Size = New System.Drawing.Size(88, 20)
        Me.LtCve_Ins.TabIndex = 654
        Me.LtCve_Ins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmInspeccionLlantasAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1491, 573)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInspeccionLlantasAE"
        Me.ShowInTaskbar = False
        Me.Text = "Inspección llanta"
        CType(Me.TFECHA, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BtnUnidades, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL112, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL111, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS10, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL110, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL10, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE10, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR10, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR10, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION10, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA10, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS9, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL19, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL9, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE9, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR9, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR9, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION9, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA9, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS8, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL18, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL8, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE8, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR8, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR8, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION8, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA8, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS7, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL17, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL7, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE7, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR7, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR7, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION7, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA7, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL16, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS5, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL15, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL5, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE5, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR5, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR5, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION5, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA5, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS4, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL14, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL4, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE4, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR4, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR4, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION4, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA4, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS3, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL13, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL3, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE3, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR3, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR3, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION3, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA3, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS2, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDA_ORIGINAL2, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TDESGASTE2, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_DESMONTAR2, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKMS_MONTAR2, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPOSICION2, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TCOSTO_LLANTA2, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_RECORRIDOS1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitM.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout
        Me.Split2.ResumeLayout(False)
        Me.Split2.PerformLayout
        CType(Me.TKM_ACTUAL5, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL4, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL7, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL3, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL10, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL8, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL2, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TKM_ACTUAL9, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL15, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL112, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL14, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL16, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL111, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL13, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL17, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL110, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL12, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL11, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL18, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPRESION_ACTUAL19, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL45, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL412, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL44, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL46, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL411, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL43, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL47, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL410, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL42, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL41, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL48, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL49, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL35, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL312, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL34, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL36, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL311, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL33, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL37, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL310, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL32, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL31, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL38, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL39, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL25, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL212, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL24, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL26, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL211, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL23, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL27, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL210, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL22, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL21, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL28, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TPROFUNDIDAD_ACTUAL29, System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LtDel As Label
    Friend WithEvents TFECHA As C1.Win.Calendar.C1DateEdit
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents TPOSICION1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TMARCA1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TMODELO1 As TextBox
    Friend WithEvents TTIPO_LLANTA1 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TCOSTO_LLANTA1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TDESGASTE1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents TObs1 As TextBox
    Friend WithEvents LtObser As Label
    Friend WithEvents TKMS_DESMONTAR1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents BtnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_UNI As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TLL12 As TextBox
    Friend WithEvents Et12 As Label
    Friend WithEvents TLL11 As TextBox
    Friend WithEvents Et11 As Label
    Friend WithEvents TLL10 As TextBox
    Friend WithEvents Et10 As Label
    Friend WithEvents TLL9 As TextBox
    Friend WithEvents Et9 As Label
    Friend WithEvents TLL8 As TextBox
    Friend WithEvents Label127 As Label
    Friend WithEvents TLL6 As TextBox
    Friend WithEvents TLL7 As TextBox
    Friend WithEvents Label128 As Label
    Friend WithEvents Label129 As Label
    Friend WithEvents TLL5 As TextBox
    Friend WithEvents Label91 As Label
    Friend WithEvents TLL4 As TextBox
    Friend WithEvents Label95 As Label
    Friend WithEvents TLL3 As TextBox
    Friend WithEvents Label117 As Label
    Friend WithEvents TLL1 As TextBox
    Friend WithEvents TLL2 As TextBox
    Friend WithEvents Label118 As Label
    Friend WithEvents Label119 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TFECHA_MONTAJE1 As TextBox
    Friend WithEvents TNUEVA_RENOVADA1 As TextBox
    Friend WithEvents TKM_RECORRIDOS1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label12 As Label
    Friend WithEvents TKM_RECORRIDOS12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE12 As TextBox
    Friend WithEvents TNUEVA_RENOVADA12 As TextBox
    Friend WithEvents TObs12 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL112 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA12 As TextBox
    Friend WithEvents TMARCA12 As TextBox
    Friend WithEvents TMODELO12 As TextBox
    Friend WithEvents TKM_RECORRIDOS11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE11 As TextBox
    Friend WithEvents TNUEVA_RENOVADA11 As TextBox
    Friend WithEvents TObs11 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL111 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA11 As TextBox
    Friend WithEvents TMARCA11 As TextBox
    Friend WithEvents TMODELO11 As TextBox
    Friend WithEvents TKM_RECORRIDOS10 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE10 As TextBox
    Friend WithEvents TNUEVA_RENOVADA10 As TextBox
    Friend WithEvents TObs10 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL110 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL10 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE10 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR10 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR10 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION10 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA10 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA10 As TextBox
    Friend WithEvents TMARCA10 As TextBox
    Friend WithEvents TMODELO10 As TextBox
    Friend WithEvents TKM_RECORRIDOS9 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE9 As TextBox
    Friend WithEvents TNUEVA_RENOVADA9 As TextBox
    Friend WithEvents TObs9 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL19 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL9 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE9 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR9 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR9 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION9 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA9 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA9 As TextBox
    Friend WithEvents TMARCA9 As TextBox
    Friend WithEvents TMODELO9 As TextBox
    Friend WithEvents TKM_RECORRIDOS8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE8 As TextBox
    Friend WithEvents TNUEVA_RENOVADA8 As TextBox
    Friend WithEvents TObs8 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL18 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA8 As TextBox
    Friend WithEvents TMARCA8 As TextBox
    Friend WithEvents TMODELO8 As TextBox
    Friend WithEvents TKM_RECORRIDOS7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE7 As TextBox
    Friend WithEvents TNUEVA_RENOVADA7 As TextBox
    Friend WithEvents TObs7 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL17 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA7 As TextBox
    Friend WithEvents TMARCA7 As TextBox
    Friend WithEvents TMODELO7 As TextBox
    Friend WithEvents TKM_RECORRIDOS6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE6 As TextBox
    Friend WithEvents TNUEVA_RENOVADA6 As TextBox
    Friend WithEvents TObs6 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL16 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA6 As TextBox
    Friend WithEvents TMARCA6 As TextBox
    Friend WithEvents TMODELO6 As TextBox
    Friend WithEvents TKM_RECORRIDOS5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE5 As TextBox
    Friend WithEvents TNUEVA_RENOVADA5 As TextBox
    Friend WithEvents TObs5 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL15 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA5 As TextBox
    Friend WithEvents TMARCA5 As TextBox
    Friend WithEvents TMODELO5 As TextBox
    Friend WithEvents TKM_RECORRIDOS4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE4 As TextBox
    Friend WithEvents TNUEVA_RENOVADA4 As TextBox
    Friend WithEvents TObs4 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL14 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA4 As TextBox
    Friend WithEvents TMARCA4 As TextBox
    Friend WithEvents TMODELO4 As TextBox
    Friend WithEvents TKM_RECORRIDOS3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE3 As TextBox
    Friend WithEvents TNUEVA_RENOVADA3 As TextBox
    Friend WithEvents TObs3 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL13 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA3 As TextBox
    Friend WithEvents TMARCA3 As TextBox
    Friend WithEvents TMODELO3 As TextBox
    Friend WithEvents TKM_RECORRIDOS2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TFECHA_MONTAJE2 As TextBox
    Friend WithEvents TNUEVA_RENOVADA2 As TextBox
    Friend WithEvents TObs2 As TextBox
    Friend WithEvents TPROFUNDIDAD_ACTUAL12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDA_ORIGINAL2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TDESGASTE2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_DESMONTAR2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKMS_MONTAR2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPOSICION2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TCOSTO_LLANTA2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_LLANTA2 As TextBox
    Friend WithEvents TMARCA2 As TextBox
    Friend WithEvents TMODELO2 As TextBox
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents LtSt As Label
    Friend WithEvents TPROFUNDIDAD_ACTUAL45 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL412 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL44 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL46 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL411 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL43 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL47 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL410 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label18 As Label
    Friend WithEvents TPROFUNDIDAD_ACTUAL42 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL41 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL48 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL49 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL35 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL312 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL34 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL36 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL311 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL33 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL37 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL310 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label19 As Label
    Friend WithEvents TPROFUNDIDAD_ACTUAL32 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL31 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL38 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL39 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL25 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL212 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL24 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL26 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL211 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL23 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL27 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL210 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label16 As Label
    Friend WithEvents TPROFUNDIDAD_ACTUAL22 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL21 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL28 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPROFUNDIDAD_ACTUAL29 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL15 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL112 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL14 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL16 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL111 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL13 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL17 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL110 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label20 As Label
    Friend WithEvents TPRESION_ACTUAL12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL18 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TPRESION_ACTUAL19 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL5 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL12 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL6 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL4 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL11 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label21 As Label
    Friend WithEvents TKM_ACTUAL7 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL3 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL10 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL8 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL2 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TKM_ACTUAL9 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TTIPO_RIN12 As TextBox
    Friend WithEvents TTIPO_RIN5 As TextBox
    Friend WithEvents TTIPO_RIN4 As TextBox
    Friend WithEvents TTIPO_RIN11 As TextBox
    Friend WithEvents TTIPO_RIN6 As TextBox
    Friend WithEvents TTIPO_RIN3 As TextBox
    Friend WithEvents TTIPO_RIN10 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TTIPO_RIN7 As TextBox
    Friend WithEvents TTIPO_RIN2 As TextBox
    Friend WithEvents TTIPO_RIN9 As TextBox
    Friend WithEvents TTIPO_RIN8 As TextBox
    Friend WithEvents TTIPO_RIN1 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents LtCve_Ins As Label
End Class
