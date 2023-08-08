Public Class MainRibbonForm

    Private _themeColor As ThemeColor = ThemeColor.Orange
    Private _themeLightness As ThemeLightness = ThemeLightness.LightGray

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        RibbonStyle.UpdateInstance(_themeColor, _themeLightness)
    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Close()
    End Sub

    Private Sub MainRibbonForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case c1Ribbon1.VisualStyle
            Case VisualStyle.Custom
                customButton.Pressed = True
            Case VisualStyle.Office2007Blue
                blue2007Button.Pressed = True
            Case VisualStyle.Office2007Silver
                silver2007Button.Pressed = True
            Case VisualStyle.Office2007Black
                black2007Button.Pressed = True
            Case VisualStyle.Office2010Blue
                blue2010Button.Pressed = True
            Case VisualStyle.Office2010Silver
                silver2010Button.Pressed = True
            Case VisualStyle.Office2010Black
                black2010Button.Pressed = True
            Case VisualStyle.Windows7
                windows7Button.Pressed = True
        End Select

        Select _themeColor
            Case ThemeColor.Azure
                azureButton.Pressed = True
            Case ThemeColor.Blue
                blueButton.Pressed = True
            Case ThemeColor.Green
                greenButton.Pressed = True
            Case ThemeColor.Orange
                orangeButton.Pressed = True
            Case ThemeColor.Orchid
                orchidButton.Pressed = True
            Case ThemeColor.Red
                redButton.Pressed = True
            Case ThemeColor.Teal
                tealButton.Pressed = True
            Case ThemeColor.Violet
                violetButton.Pressed = True
        End Select

        Select _themeLightness
            Case ThemeLightness.DarkGray
                darkGrayButton.Pressed = True
            Case ThemeLightness.LightGray
                lightGrayButton.Pressed = True
            Case ThemeLightness.White
                whiteButton.Pressed = True
        End Select

        ctgColorSelector.SelectedIndex = 3
    End Sub

    Private Sub visualStyle_PressedButtonChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles black2007Button.PressedButtonChanged
        If blue2007Button.Pressed Then
            c1Ribbon1.VisualStyle = VisualStyle.Office2007Blue
        ElseIf silver2007Button.Pressed Then
            c1Ribbon1.VisualStyle = VisualStyle.Office2007Silver
        ElseIf black2007Button.Pressed Then
            c1Ribbon1.VisualStyle = VisualStyle.Office2007Black
        ElseIf blue2010Button.Pressed Then
            c1Ribbon1.VisualStyle = VisualStyle.Office2010Blue
        ElseIf silver2010Button.Pressed Then
            c1Ribbon1.VisualStyle = VisualStyle.Office2010Silver
        ElseIf black2010Button.Pressed Then
            c1Ribbon1.VisualStyle = VisualStyle.Office2010Black
        ElseIf windows7Button.Pressed Then
            c1Ribbon1.VisualStyle = VisualStyle.Windows7
        ElseIf customButton.Pressed Then
            c1Ribbon1.VisualStyle = VisualStyle.Custom
        End If
    End Sub

    Private Sub azureButton_PressedButtonChanged(sender As Object, e As EventArgs) Handles azureButton.PressedButtonChanged

        If azureButton.Pressed Then
            _themeColor = ThemeColor.Azure
        ElseIf blueButton.Pressed Then
            _themeColor = ThemeColor.Blue
        ElseIf greenButton.Pressed Then
            _themeColor = ThemeColor.Green
        ElseIf orangeButton.Pressed Then
            _themeColor = ThemeColor.Orange
        ElseIf orchidButton.Pressed Then
            _themeColor = ThemeColor.Orchid
        ElseIf redButton.Pressed Then
            _themeColor = ThemeColor.Red
        ElseIf tealButton.Pressed Then
            _themeColor = ThemeColor.Teal
        ElseIf violetButton.Pressed Then
            _themeColor = ThemeColor.Violet
        End If

        RibbonStyle.UpdateInstance(_themeColor, _themeLightness)
    End Sub

    Private Sub darkGrayButton_PressedButtonChanged(sender As Object, e As EventArgs) Handles darkGrayButton.PressedButtonChanged

        If darkGrayButton.Pressed Then
            _themeLightness = ThemeLightness.DarkGray
        ElseIf lightGrayButton.Pressed Then
            _themeLightness = ThemeLightness.LightGray
        ElseIf whiteButton.Pressed Then
            _themeLightness = ThemeLightness.White
        End If

        RibbonStyle.UpdateInstance(_themeColor, _themeLightness)
    End Sub

    Private Sub ctgColorSelector_ChangeCommitted(sender As Object, e As EventArgs) Handles ctgColorSelector.ChangeCommitted

        Dim b As RibbonButton = CType(ctgColorSelector.SelectedItem, RibbonButton)
        drawingToolsCTG.Color = CType(System.Enum.Parse(GetType(ContextualTabColor), b.Text), ContextualTabColor)

    End Sub

    Private Sub c1Ribbon1_MinimizedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1Ribbon1.MinimizedChanged
        If c1Ribbon1.Minimized Then
            MinimizeRibbonButton.Visible = False
            ExpandRibbonButton.Visible = True
        Else
            MinimizeRibbonButton.Visible = True
            ExpandRibbonButton.Visible = False
        End If
    End Sub

    Private Sub MinimizeRibbonButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeRibbonButton.Click
        c1Ribbon1.Minimized = True
    End Sub

    Private Sub ExpandRibbonButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandRibbonButton.Click
        c1Ribbon1.Minimized = False
    End Sub

    Private Sub rcListPinButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rcListPinButton1.Click, rcListPinButton2.Click
        Dim pin As RibbonToggleButton = CType(sender, RibbonToggleButton)
        If pin.Pressed Then
            pin.SmallImage = My.Resources.Pinned
        Else
            pin.SmallImage = My.Resources.Unpinned
        End If
    End Sub

    Private Sub newWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newWindowButton.Click
        IsMdiContainer = True
        Dim crf As ChildRibbonForm = New ChildRibbonForm
        crf.MdiParent = Me
        crf.Text = String.Format("MDI Child Form {0:d}", MdiChildren.Length)
        crf.Show()
    End Sub

    Protected Overrides Sub OnMdiChildActivate(ByVal e As System.EventArgs)
        MyBase.OnMdiChildActivate(e)
        If Not _windowSwitching Then
            RefreshMdiWindowList(Me, switchWindowsMenu)
        End If
    End Sub

#Region "MDI Window Switching Code"

    Private _windowSwitching As Boolean
    Private _turnOffMdi As Boolean

    Friend ReadOnly Property WindowSwitching() As Boolean
        Get
            Return _windowSwitching
        End Get
    End Property

    Private Sub RefreshMdiWindowList(ByVal parentForm As Form, ByVal menu As RibbonMenu)
        Dim items As RibbonItemCollection = menu.Items
        items.ClearAndDisposeItems()

        Dim forms() As Form = parentForm.MdiChildren
        Dim activeChild As Form = parentForm.ActiveMdiChild
        Dim n As Int32 = 1
        For i As Int32 = 0 To forms.Length - 1
            Dim f As Form = forms(i)
            If f IsNot Nothing AndAlso Not f.Disposing AndAlso Not f.IsDisposed Then
                Dim tb As RibbonToggleButton = New RibbonToggleButton()
                AddHandler tb.Click, AddressOf activateWindow_Click
                tb.CanDepress = False
                tb.Pressed = Object.ReferenceEquals(f, activeChild)
                Dim t As String = f.Text
                If n < 10 Then
                    t = "&" + n.ToString() + " " + t
                    n += 1
                End If
                tb.Text = t
                tb.Tag = f
                tb.ToggleGroupName = "MdiChildren"
                items.Add(tb)
            End If
        Next i
        If items.Count > 0 Then
            menu.Enabled = True
        Else
            menu.Enabled = False
            _turnOffMdi = True
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        If _turnOffMdi Then
            IsMdiContainer = False
            _turnOffMdi = False
        End If
    End Sub

    Private Sub activateWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TypeOf sender Is RibbonToggleButton Then
            _windowSwitching = True
            With CType(CType(sender, RibbonToggleButton).Tag, Form)
                .Activate()
                If .WindowState = FormWindowState.Minimized Then
                    .WindowState = FormWindowState.Normal
                End If
            End With
            _windowSwitching = False
        End If
    End Sub

#End Region

End Class
