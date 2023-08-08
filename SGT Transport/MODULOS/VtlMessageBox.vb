
Imports C1.Win.C1Input
Imports C1.Win.C1Ribbon
Imports C1.Win.C1SuperTooltip
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Graphics
Imports System.Media
Imports System.Windows.Forms.Control

'''-------------------------------------------------------------------------------------------------
''' <summary>   Vtl message box.
''' 			An extended Message box designed to allow message boxes to provide additional
''' 			features and to be rendered in C1 Visual Styles. </summary>
'''
''' <remarks>   Dom Sinclair, 17 July 2012. </remarks>
'''-------------------------------------------------------------------------------------------------

Public Class VtlMessageBox

#Region "Constants, Fields and Properties"

    Private _allowCancel As Boolean
    Private _buttons As ArrayList = New ArrayList
    Private _CustomCancelButton As VTLMessageBoxButton
    Private _endUserDecissionText As String
    Private _customFont As Font
    Private _messageStartPosition As FormStartPosition
    Private _moreTextColour As Color
    Private _messageTextColour As Color
    Private _textColour As Color
    Private _secondsToAutoClose As Integer
    Private _moreText As String
    Private _result As String

    Private _caption As String
    Private _messageText As String
    Private _icon As MessageBoxIcon
    Private _customIcon As Icon = Nothing

    Private AllowUserToSaveResponse As Boolean
    Private DisplayedCaptionText As String
    Private IconSelected As Boolean
    Private Const LeftPadding As Integer = 12
    Private MoreTextLabelLocation As Point
    Private OldButtonMoreLocation As Point
    Private OldClientHeight As Integer
    Private OldClientWidth As Integer
    Private OldFormHeight As Integer
    Private OldFormWidth As Integer
    Private Const RightPadding As Integer = 12
    Private TimeRemaining As Integer
    Private Const TopPadding As Integer = 12
    Private Const BottomPadding As Integer = 12

    Private Const ButtonLeftPadding As Integer = 4
    Private Const ButtonRightPadding As Integer = 4
    Private Const ButtonTopPadding As Integer = 4
    Private Const ButtonBottomPadding As Integer = 4

    Private Const MinimumButtonHeight As Integer = 23
    Private Const MinimumButtonWidth As Integer = 75

    Private Const ButtonPadding As Integer = 8
    Private Const ItemPadding As Integer = 10
    Private Const IconToMessagePadding As Integer = 15
    Private Const CheckBoxToLabelPadding As Integer = 15

    Private Const CheckBoxWidth As Integer = 20

    Private Const CloseButtonWidth As Integer = 75
    Private Const MoreButtonWidth As Integer = 75

    Private Const _intSpacing As Integer = 10



    Private WithEvents Sl As C1SuperLabel
    Private WithEvents Sl1 As C1SuperLabel
    Private WithEvents Frm As Form
    Private WithEvents RbnForm As C1RibbonForm
    Private WithEvents ChkSave As CheckBox
    Private WithEvents BtnMore As Button
    Private WithEvents BtnC1More As C1Button
    Private WithEvents AutoTimer As Timer
    Private IconPanel As PictureBox
    Private UseMoreText As Boolean
    Private UseStandardForm As Boolean
    Private visStyle As C1.Win.C1Ribbon.VisualStyle
    Private _maximumWidth As Integer
    Private _maximumHeight As Integer
    Private _iconImage As Icon
    Private _maximumLayoutWidth As Integer
    Private _maximumLayoutHeight As Integer
    Private _buttonControlsTable As Hashtable = New Hashtable()
    Private _defaultButtonControl As Button = Nothing
    Private _defaultC1ButtonControl As C1Button = Nothing
    Private _extendWidthOfForm As Boolean
    Private _extraWidthRequiredForeMoreText As Integer
    Private _oldButtonMoreLeft As Integer
    Private _cancelButton As VTLMessageBoxButton



    ''' <summary>   The text to be displayed the message box.
    ''' 			This could be an application resource. </summary>
    Public WriteOnly Property MessageText As String
        Set(ByVal Value As String)
            If sl Is Nothing Then
                sl = New C1SuperLabel
            End If
            AddHandler sl.LinkClicked, AddressOf SuperLabelClicked
            sl.Text = Value
        End Set
    End Property


    ''' <summary>   The text to be displayed in the more text area. This could be an application resource.</summary>
    Public WriteOnly Property MoreText As String
        Set(ByVal Value As String)
            If sl1 Is Nothing Then
                sl1 = New C1SuperLabel
            End If
            sl1.Text = Value
            UseMoreText = True
        End Set
    End Property



    ''' <summary>   The colour in which the Message Text should be displayed. 
    ''' 			This is intended primarily to provide the ability to display 
    ''' 			text in a light colour on dark backgrounds.
    ''' 			
    '''NB: it will not override  any colour formatting contained in HTML markup. </summary>
    Public WriteOnly Property MessageTextColour As Color
        Set(ByVal Value As Color)
            sl.ForeColor = Value
        End Set
    End Property

    ''' <summary>   The colour in which Text in the more text area should be displayed. 
    ''' 			This is intended primarily to provide the ability to display 
    ''' 			text in a light colour on dark backgrounds.
    ''' 			
    '''NB: It will not override  any colour formatting contained in HTML markup. </summary>
    Public WriteOnly Property MoreTextColour As Color
        Set(ByVal Value As Color)
            sl1.ForeColor = Value
        End Set
    End Property


    ''' <summary>   The caption to be used on the message box. </summary>
    Public WriteOnly Property Caption As String
        Set(ByVal Value As String)
            _caption = Value
        End Set
    End Property

    ''' <summary>   The standard message box icon to use. </summary>
    Public WriteOnly Property Icon As MessageBoxIcon
        Set(value As MessageBoxIcon)
            _icon = value
            _iconImage = GetCorrectIconImage(value)
            IconSelected = True
        End Set
    End Property

    ''' <summary>   The custom icon to be used instead of the standard message box icon (if specified). </summary>
    Public WriteOnly Property CustomIcon As Icon
        Set(value As Icon)
            _icon = MessageBoxIcon.None
            _iconImage = value
            IconSelected = True
        End Set
    End Property


    ''' <summary>   The text that should appear next to the check box when offering them a choice for future instances of this message. </summary>
    Public WriteOnly Property EndUserDecissionText As String
        Set(ByVal Value As String)
            AllowUserToSaveResponse = True
            _endUserDecissionText = Value
        End Set
    End Property




    ''' <summary>   The number of seconds to elapse before the VTL Message Box should close automatically. </summary>
    Public WriteOnly Property SecondsToAutoClose As Integer
        Set(ByVal Value As Integer)
            _secondsToAutoClose = Value * 1000
        End Set
    End Property


    ''' <summary>   The position where you would like the VtlMessageBox to open.  This is a standard FormStartPosition. </summary>
    Public WriteOnly Property MessageBoxPosition As FormStartPosition
        Set(value As FormStartPosition)
            If UseStandardForm Then
                frm.StartPosition = value
            Else
                rbnForm.StartPosition = value
            End If
            ' _messageStartPosition = value
        End Set
    End Property

    ''' <summary>   The result to be returned if the Vtl Message Box is allowed to close automatically. </summary>
    Public Property AutoCloseResult As AutoCloseResult

    ''' <summary>   Appends the number of seconds to Auto Close to the caption of the Vtl Message Box. </summary>
    Public Property DisplaySecondsToAutoClose As Boolean

    Friend Property VtlSound As SystemSound


    Friend ReadOnly Property Buttons As ArrayList
        Get
            Return _buttons
        End Get
    End Property

    Friend ReadOnly Property Result As String
        Get
            Return _result
        End Get
    End Property



    Friend WriteOnly Property CustomCancelButton As VTLMessageBoxButton
        Set(value As VTLMessageBoxButton)
            _CustomCancelButton = value
        End Set
    End Property
#End Region

#Region "Constructors"


    '''-------------------------------------------------------------------------------------------------
    ''' <summary>   Initializes a new instance of a Vtl standard looking message box.</summary>
    '''
    ''' <remarks>   Dom Sinclair, 17 July 2012. </remarks>
    '''-------------------------------------------------------------------------------------------------

    Public Sub New()
        _maximumWidth = CType((SystemInformation.WorkingArea.Width * 0.6), Integer)
        _maximumHeight = CType((SystemInformation.WorkingArea.Height * 0.9), Integer)
        frm = New Form
        With frm
            .MaximizeBox = False
            .MinimizeBox = False
            .ShowIcon = False
            .ShowInTaskbar = False
            .FormBorderStyle = FormBorderStyle.FixedDialog
        End With
        AddHandler frm.Load, AddressOf FormLoad
        AddHandler frm.Shown, AddressOf FormShown
        AddHandler frm.FormClosing, AddressOf FormClosing
        AddHandler frm.DoubleClick, AddressOf CopyContents

        UseStandardForm = True
    End Sub


    '''-------------------------------------------------------------------------------------------------
    ''' <summary>   Initializes a new instance of a Vtl c1 visual style aware message box.</summary>
    '''
    ''' <remarks>   Dom Sinclair, 17 July 2012. </remarks>
    '''
    ''' <param name="visualStyle">  The visual style to be used. </param>
    '''-------------------------------------------------------------------------------------------------

    Public Sub New(ByVal visualStyle As C1.Win.C1Ribbon.VisualStyle)
        _maximumWidth = CType((SystemInformation.WorkingArea.Width * 0.6), Integer)
        _maximumHeight = CType((SystemInformation.WorkingArea.Height * 0.9), Integer)
        visStyle = visualStyle
        rbnForm = New C1RibbonForm With {.VisualStyle = visualStyle}
        With rbnForm
            .MaximizeBox = False
            .MinimizeBox = False
            .ShowIcon = False
            .ShowInTaskbar = False
            .FormBorderStyle = FormBorderStyle.FixedDialog
        End With
        AddHandler rbnForm.Load, AddressOf FormLoad
        AddHandler rbnForm.Shown, AddressOf FormShown
        AddHandler rbnForm.FormClosing, AddressOf FormClosing
        AddHandler rbnForm.PreviewKeyDown, AddressOf FormKeyPressed
        AddHandler rbnForm.DoubleClick, AddressOf CopyContents


    End Sub

#End Region

#Region "Events"

    '''-------------------------------------------------------------------------------------------------
    ''' <summary>  Shows the Vtl Message Box.</summary>
    '''
    ''' <remarks>   Dom Sinclair, 17 July 2012. </remarks>
    '''
    ''' <returns>  The result as a string. </returns>
    '''-------------------------------------------------------------------------------------------------

    Public Function Show() As String
        If UseStandardForm Then
            frm.ShowDialog()
            Return Result
        Else
            rbnForm.ShowDialog()
            Return Result
        End If
    End Function





    Private Sub FormLoad(ByVal sender As Object, ByVal e As EventArgs)

        Dim myfrm As Form = If(TypeOf sender Is Form, CType(sender, Form), Nothing)
        Dim myRbnfrm As C1RibbonForm = If(TypeOf sender Is C1RibbonForm, CType(sender, C1RibbonForm), Nothing)
        If UseStandardForm Then
            myfrm.Size = New Size(_maximumWidth, _maximumHeight)
            _maximumLayoutWidth = myfrm.ClientSize.Width - LeftPadding - RightPadding
            _maximumLayoutHeight = myfrm.ClientSize.Height - TopPadding - BottomPadding
        Else
            myRbnfrm.Size = New Size(_maximumWidth, _maximumHeight)
            _maximumLayoutWidth = myRbnfrm.ClientSize.Width - LeftPadding - RightPadding
            _maximumLayoutHeight = myRbnfrm.ClientSize.Height - TopPadding - BottomPadding
        End If
        _result = String.Empty
        AddDefaultOkButton()

        If IconSelected Then
            CreateAndPositionIconOnForm()
        End If
        PositionAndSizeTheSuperLabel()
        If AllowUserToSaveResponse Then
            CreateAndPositionCheckBoxOnForm()
        End If
        If UseMoreText Then
            CreateMoreTextButton()
        End If
        SetTheOptimumSizeForTheForm()
        LayoutTheForm()
        If UseStandardForm Then

            If myfrm Is Nothing Then
                Return
            Else

                myfrm.Text = _caption
                If IconSelected Then
                    myfrm.Controls.Add(IconPanel)
                End If
                myfrm.Controls.Add(sl)
                If AllowUserToSaveResponse Then
                    myfrm.Controls.Add(chkSave)
                End If
            End If
        Else

            If myRbnfrm Is Nothing Then
                Return
            Else

                myRbnfrm.Text = _caption
                If IconSelected Then
                    myRbnfrm.Controls.Add(IconPanel)
                End If
                myRbnfrm.Controls.Add(sl)
                If AllowUserToSaveResponse Then
                    myRbnfrm.Controls.Add(chkSave)
                    chkSave.BackColor = myRbnfrm.BackgroundColor
                End If
            End If
        End If
        DisableCloseWhenNoCancelButtonIsPresent()
        StartAutoTimerIfRequired()
    End Sub
    Private Sub FormShown(ByVal sender As Object, ByVal e As EventArgs)
        'Intercept OnShown to play the sound
        If VtlSound Is Nothing Then
            SystemSounds.Asterisk.Play()
        Else
            VtlSound.Play()
        End If
        Return
    End Sub




    Private Sub FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        If _result = Nothing Then
            If _allowCancel Then
                _result = _cancelButton.Value
            Else
                e.Cancel = True
                Return
            End If
        End If
        If AutoTimer IsNot Nothing Then
            AutoTimer.Stop()
        End If
    End Sub


    Private Sub CopyContents(ByVal sender As Object, ByVal e As EventArgs)
        If UseMoreText Then
            Clipboard.SetText(sl.Text & Environment.NewLine & Environment.NewLine & sl1.Text)
        Else
            Clipboard.SetText(sl.Text)
        End If
    End Sub
    Private Sub FormKeyPressed(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.Control Then
            If e.KeyCode = Keys.C Then
                Clipboard.SetText(sl.Text)
            End If

        End If
    End Sub
    Private Sub SetResultAndClose(ByVal result As String)
        _result = result
        If UseStandardForm Then
            frm.DialogResult = DialogResult.OK
        Else
            rbnForm.DialogResult = DialogResult.OK
        End If

    End Sub


    Private Sub DisableCloseWhenNoCancelButtonIsPresent()
        If _buttons.Count > 1 Then
            If _cancelButton IsNot Nothing Then
                Return
            End If


            For Each button As VTLMessageBoxButton In _buttons
                If button.Text = VTLMessageBoxButtons.Cancel.ToString And button.Value = VTLMessageBoxButtons.Cancel.ToString Then
                    _cancelButton = button
                    Return
                End If
            Next

            If UseStandardForm Then
                Disable(frm)
            Else
                Disable(rbnForm)
            End If

            _allowCancel = False
        Else

            If _buttons.Count = 1 Then
                _cancelButton = If(TypeOf _buttons(0) Is VTLMessageBoxButton, CType(_buttons(0), VTLMessageBoxButton), Nothing)
            Else
                _allowCancel = False
            End If
        End If
    End Sub

#Region "Disable the close Button"

    'This contains the bits needed to disable the close button on the message box when either yesNo or AbortRetryIgnore buttons are selected

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0



    Public Shared Sub Disable(ByVal form As Form)

        ' The return value specifies the previous state of the menu item (it is either     
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.     

        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)

            Case MF_ENABLED

            Case MF_GRAYED

            Case &HFFFFFFFF

                Throw New Exception("The Close menu item does not exist.")

            Case Else

        End Select

    End Sub
#End Region

#Region "Icon Handling"




    Friend Function GetCorrectIconImage(ByVal icon As MessageBoxIcon) As Icon
        Select Case icon
            Case MessageBoxIcon.None
                Return Nothing
            Case MessageBoxIcon.Hand
                Return SystemIcons.Hand
            Case MessageBoxIcon.Question
                Return SystemIcons.Question
            Case MessageBoxIcon.Exclamation
                Return SystemIcons.Exclamation
            Case MessageBoxIcon.Asterisk
                Return SystemIcons.Asterisk
            Case MessageBoxIcon.Stop
                Return SystemIcons.Error
            Case MessageBoxIcon.Error
                Return SystemIcons.Error
            Case MessageBoxIcon.Warning
                Return SystemIcons.Warning
            Case MessageBoxIcon.Information
                Return SystemIcons.Information
            Case Else
                Return SystemIcons.Exclamation
        End Select
    End Function


    Private Sub CreateAndPositionIconOnForm()
        IconPanel = New PictureBox
        Dim w As Integer = 32
        Dim h As Integer = 32
        Dim sz As New Size(w, h)
        IconPanel.Size = sz
        Dim pos As New Point(LeftPadding, TopPadding)
        IconPanel.Location = pos
        IconPanel.Image = _iconImage.ToBitmap
    End Sub

#End Region

#Region "Saving User Responses"


    Private Sub CreateAndPositionCheckBoxOnForm()
        chkSave = New CheckBox
        AddHandler chkSave.CheckedChanged, AddressOf CheckBoxCheckChanged
        Dim pos As New Point(sl.Left, TopPadding + sl.Height + CheckBoxToLabelPadding)
        With chkSave
            .Text = _endUserDecissionText
            .Location = pos
            .AutoSize = True
        End With
    End Sub


    Private Sub CheckBoxCheckChanged(ByVal sender As Object, ByVal e As EventArgs)
        'Throw New System.NotImplementedException()
    End Sub
#End Region

#Region "Super Label Handling"


    Private Sub PositionAndSizeTheSuperLabel()
        Dim pos As New Point(LeftPadding + IconPanel.Width + IconToMessagePadding, TopPadding)
        Dim posWithoutIcon As New Point(LeftPadding, TopPadding)
        If IconSelected Then
            sl.Location = pos
            sl.Height = sl.Measure.Height
            sl.Width = sl.Measure.Width
        Else
            sl.Location = posWithoutIcon
            sl.Height = sl.Measure.Height
            sl.Width = sl.Measure.Width
        End If
    End Sub


    Private Sub SuperLabelClicked(ByVal sender As Object, ByVal e As C1SuperLabelLinkClickedEventArgs)
        Try
            System.Diagnostics.Process.Start(e.HRef)
        Catch ex As System.Security.SecurityException
            '-- do nothing; we can't launch without full trust.
        End Try
    End Sub
#End Region

#Region "Sizing"

    Private Sub SetTheOptimumSizeForTheForm()
        Dim ncWidth As Integer
        Dim ncHeight As Integer
        If UseStandardForm Then
            ncWidth = frm.Width - frm.ClientSize.Width
            ncHeight = frm.Height - frm.ClientSize.Height
        Else
            ncWidth = rbnForm.Width - rbnForm.ClientSize.Width
            ncHeight = rbnForm.Height - rbnForm.ClientSize.Height
        End If
        Dim iconAndMessageRowWidth As Integer = sl.Width + IconToMessagePadding + IconPanel.Width
        Dim saveResponseRowWidth As Integer = 0
        If AllowUserToSaveResponse Then
            saveResponseRowWidth = chkSave.Width + CType((IconPanel.Width / 2), Integer)
        End If

        Dim buttonsRowWidth As Integer = GetWidthOfAllAvailableButtons()
        Dim captionWidth As Integer = GetCaptionSize().Width + CloseButtonWidth

        Dim maxItemWidth As Integer = Math.Max(saveResponseRowWidth, Math.Max(iconAndMessageRowWidth, buttonsRowWidth))
        

        Dim requiredWidth As Integer = LeftPadding + maxItemWidth + RightPadding + ncWidth
        'Since Caption width is not client width, we do the check here
        If requiredWidth < captionWidth Then
            requiredWidth = captionWidth

        End If
        Dim requiredHeight As Integer   ' = TopPadding + Math.Max(sl.Height, IconPanel.Height) + ItemPadding + chkSave.Height + ItemPadding + GetButtonSize().Height + BottomPadding + ncHeight
        If AllowUserToSaveResponse Then
            requiredHeight = TopPadding + Math.Max(sl.Height, IconPanel.Height) + ItemPadding + chkSave.Height + ItemPadding + GetButtonSize().Height + BottomPadding + ncHeight
        Else
            requiredHeight = TopPadding + Math.Max(sl.Height, IconPanel.Height) + ItemPadding + ItemPadding + GetButtonSize().Height + BottomPadding + ncHeight
        End If
        If requiredHeight > _maximumHeight Then
            sl.Height -= requiredHeight - _maximumHeight
        End If
        Dim height As Integer = Math.Min(requiredHeight, _maximumHeight)
        Dim width As Integer = Math.Min(requiredWidth, _maximumWidth)
        If UseStandardForm Then
            frm.Size = New Size(width, height)
        Else
            rbnForm.Size = New Size(width, height)
        End If

    End Sub






    Private Sub LayoutTheForm()
        IconPanel.Location = New Point(LeftPadding, TopPadding)
        sl.Location = New Point(LeftPadding + IconPanel.Width + IconToMessagePadding * (If(IconPanel.Width = 0, 0, 1)), TopPadding)
        If AllowUserToSaveResponse Then
            chkSave.Location = New Point(LeftPadding + CType((IconPanel.Width / 2), Integer), TopPadding + Math.Max(IconPanel.Height, sl.Height) + ItemPadding)
        End If

        Dim buttonSize As Size = GetButtonSize()

        'buttons need to be positioned from the right of the message box
        Dim allButtonsWidth As Integer = GetWidthOfAllButtons() + ButtonPadding
        Dim firstButtonX As Integer
        Dim firstButtonY As Integer
        If UseStandardForm Then
            firstButtonX = CType(frm.ClientSize.Width - allButtonsWidth, Integer)
            firstButtonY = frm.ClientSize.Height - BottomPadding - buttonSize.Height
        Else
            firstButtonX = CType(rbnForm.ClientSize.Width - allButtonsWidth, Integer)
            firstButtonY = rbnForm.ClientSize.Height - BottomPadding - buttonSize.Height
        End If

        Dim nextButtonLocation As Point = New Point(firstButtonX, firstButtonY)
        Dim foundDefaultButton As Boolean = False
        Dim i As Integer
        If UseStandardForm Then

            For Each button As VTLMessageBoxButton In _buttons
                Dim buttonCtrl As Button = GetButton(button, buttonSize, nextButtonLocation)

                If Not foundDefaultButton Then
                    _defaultButtonControl = buttonCtrl
                    foundDefaultButton = True
                    frm.AcceptButton = buttonCtrl
                End If
                If buttonCtrl.Text = "&Cancel" Then
                    frm.CancelButton = buttonCtrl
                End If
                nextButtonLocation.X += buttonSize.Width + ButtonPadding
                i = buttonCtrl.Location.Y
                buttonCtrl.Anchor = AnchorStyles.Bottom And AnchorStyles.Right
            Next
            If UseMoreText Then
                btnMore.Size = GetButtonSize()
                btnMore.Location = New Point(LeftPadding, i)
            End If
            OldClientWidth = frm.ClientSize.Width
            OldClientHeight = frm.ClientSize.Height
            OldFormWidth = frm.Width
            OldFormHeight = frm.Height
        Else
            For Each button As VTLMessageBoxButton In _buttons
                Dim buttonCtrl As C1Button = GetButton(button, buttonSize, nextButtonLocation)
                If Not foundDefaultButton Then
                    _defaultC1ButtonControl = buttonCtrl
                    foundDefaultButton = True
                    rbnForm.AcceptButton = buttonCtrl
                End If
                If buttonCtrl.Text = "&Cancel" Then
                    rbnForm.CancelButton = buttonCtrl
                End If
                nextButtonLocation.X += buttonSize.Width + ButtonPadding
                i = buttonCtrl.Location.Y
                buttonCtrl.Anchor = AnchorStyles.Bottom And AnchorStyles.Right
            Next
            If UseMoreText Then
                btnC1More.Size = GetButtonSize()
                btnC1More.Location = New Point(LeftPadding, i)
            End If
            OldClientWidth = rbnForm.ClientSize.Width
            OldClientHeight = rbnForm.ClientSize.Height
            OldFormWidth = rbnForm.Width
            OldFormHeight = rbnForm.Height
        End If


    End Sub




    Private Function GetCaptionSize() As Size
        Dim captionFont As Font = SystemFonts.CaptionFont
        If captionFont Is Nothing Then
            'some error occurred while determining system font
            captionFont = New Font("Tahoma", 11)
        End If
        Dim availableWidth As Integer = _maximumWidth - SystemInformation.CaptionButtonSize.Width - SystemInformation.Border3DSize.Width * 2
        Dim captionSize As Size = MeasureString(_caption, availableWidth)
        captionSize.Width += SystemInformation.CaptionButtonSize.Width + SystemInformation.Border3DSize.Width * 2
        Return captionSize
    End Function


    '''
    ''' <remarks>   Dom Sinclair, 04 July 2012. </remarks>
    '''
    ''' <param name="str">      The String to measure. </param>
    ''' <param name="maxWidth"> Width of the maximum. </param>
    ''' <param name="font">     The font. </param>
    '''
    ''' <returns>   Returns the size of the string </returns>
    '''-------------------------------------------------------------------------------------------------

    Private Function MeasureString(ByVal str As String, ByVal maxWidth As Integer, ByVal font As Font) As Size

        Dim g As Graphics
        If UseStandardForm Then
            g = frm.CreateGraphics()
        Else
            g = rbnForm.CreateGraphics()
        End If
        Dim strRectSizeF As SizeF = g.MeasureString(str, font, maxWidth)
        g.Dispose()
        Return New Size(CType(Math.Ceiling(strRectSizeF.Width), Integer), CType(Math.Ceiling(strRectSizeF.Height), Integer))
    End Function


    '''-------------------------------------------------------------------------------------------------
    ''' <summary>   Measure string. </summary>
    '''
    ''' <remarks>   Dom Sinclair, 01 July 2012. </remarks>
    '''
    ''' <param name="str">      The String to Measure. </param>
    ''' <param name="maxWidth"> Width of the maximum. </param>
    '''
    ''' <returns>   . </returns>
    '''-------------------------------------------------------------------------------------------------

    Private Function MeasureString(ByVal str As String, ByVal maxWidth As Integer) As Size
        Return MeasureString(str, maxWidth, SystemFonts.CaptionFont)
    End Function

#End Region

#Region "Buttons"

    Private Sub CreateMoreTextButton()
        If UseStandardForm Then
            btnMore = New Button() With {.Text = "&More >>", .Anchor = AnchorStyles.Bottom And AnchorStyles.Left}
            AddHandler btnMore.Click, AddressOf ButtonMoreClick
            frm.Controls.Add(btnMore)
        Else
            btnC1More = New C1Button() With {.Text = "&More >>", .Anchor = AnchorStyles.Bottom And AnchorStyles.Left}
            AddHandler btnC1More.Click, AddressOf ButtonMoreClick
            rbnForm.Controls.Add(btnC1More)
        End If
    End Sub


    Private Sub ButtonMoreClick(ByVal sender As Object, ByVal e As EventArgs)

        Dim ButtonX As Integer
        Dim ButtonY As Integer

        If UseStandardForm Then
            OldButtonMoreLocation = btnMore.Location
            If btnMore.Text = "&More >>" Then
                frm.SuspendLayout()
                With sl1
                    .Location = New Point(OldButtonMoreLocation)
                    .Height = .Measure.Height
                    If sl1.Measure.Width > frm.ClientSize.Width Then
                        .Width = sl1.Measure.Width
                        _extendWidthOfForm = True
                    Else
                        .Width = frm.ClientSize.Width - LeftPadding - RightPadding
                    End If
                    .BorderStyle = BorderStyle.None
                End With
                frm.Controls.Add(sl1)
                AddHandler sl1.LinkClicked, AddressOf SuperLabelClicked
                btnMore.Text = "&More <<"
                If sl1.Height > 0 Then
                    frm.Height = frm.Height + sl1.Height + BottomPadding
                Else
                    frm.Height = frm.Height + 120
                End If
                If _extendWidthOfForm Then
                    _extraWidthRequiredForeMoreText = sl1.Measure.Width - frm.Width
                    frm.Width = frm.Width + _extraWidthRequiredForeMoreText + LeftPadding + RightPadding
                End If
                ' if the form has been extended widthways as well then we need to re jig the location of the standard buttons
                _oldButtonMoreLeft = btnMore.Left
                If _extendWidthOfForm Then
                    For Each ctrl As Control In frm.Controls
                        If TypeOf (ctrl) Is Button Then
                            ButtonX = ctrl.Left + _extraWidthRequiredForeMoreText + RightPadding + ButtonPadding
                            ButtonY = OldClientHeight + sl1.Height - ctrl.Height
                            Dim loc As New Point(ButtonX, ButtonY)
                            ctrl.Location = loc
                        End If
                    Next
                    Dim newloc As New Point(_oldButtonMoreLeft, OldClientHeight + sl1.Height - btnMore.Height)
                    btnMore.Location = newloc
                Else
                    For Each ctrl As Control In frm.Controls
                        If TypeOf (ctrl) Is Button Then
                            ButtonX = ctrl.Left
                            ButtonY = OldClientHeight + sl1.Height - ctrl.Height
                            Dim loc As New Point(ButtonX, ButtonY)
                            ctrl.Location = loc
                        End If
                    Next
                End If
                frm.ResumeLayout()
            Else
                frm.SuspendLayout()
                btnMore.Text = "&More >>"
                frm.Controls.Remove(sl1)
                btnMore.Location = OldButtonMoreLocation
                frm.Width = OldFormWidth
                frm.Height = OldFormHeight
                If _extendWidthOfForm Then
                    For Each ctrl As Control In frm.Controls
                        If TypeOf (ctrl) Is Button Then
                            ButtonX = ctrl.Left - _extraWidthRequiredForeMoreText - RightPadding - ButtonPadding
                            ButtonY = OldClientHeight - BottomPadding - ctrl.Height
                            Dim loc As New Point(ButtonX, ButtonY)
                            ctrl.Location = loc
                        End If
                    Next

                Else
                    For Each ctrl As Control In frm.Controls
                        If TypeOf (ctrl) Is Button Then
                            ButtonX = ctrl.Left
                            ButtonY = OldClientHeight - BottomPadding - ctrl.Height
                            Dim loc As New Point(ButtonX, ButtonY)
                            ctrl.Location = loc
                        End If
                    Next
                End If
                btnMore.Location = OldButtonMoreLocation
                btnMore.Top = OldClientHeight - BottomPadding - btnMore.Height
                frm.ResumeLayout()
            End If

        Else 'it's a ribbon form
            OldButtonMoreLocation = btnC1More.Location
            If btnC1More.Text = "&More >>" Then
                rbnForm.SuspendLayout()
                With sl1
                    .Location = New Point(OldButtonMoreLocation)
                    .Height = .Measure.Height
                    If sl1.Measure.Width > rbnForm.ClientSize.Width Then
                        .Width = sl1.Measure.Width
                        _extendWidthOfForm = True
                    Else
                        .Width = rbnForm.ClientSize.Width - LeftPadding - RightPadding
                    End If
                    .BorderStyle = BorderStyle.None
                End With
                rbnForm.Controls.Add(sl1)
                AddHandler sl1.LinkClicked, AddressOf SuperLabelClicked
                btnC1More.Text = "&More <<"
                If sl1.Height > 0 Then
                    rbnForm.Height = rbnForm.Height + sl1.Height + BottomPadding
                Else
                    rbnForm.Height = rbnForm.Height + 120
                End If
                If _extendWidthOfForm Then
                    _extraWidthRequiredForeMoreText = sl1.Measure.Width - rbnForm.Width
                    rbnForm.Width = rbnForm.Width + _extraWidthRequiredForeMoreText + LeftPadding + RightPadding
                End If
                ' if the form has been extended widthways as well then we need to re jig the location of the standard buttons
                _oldButtonMoreLeft = btnC1More.Left
                If _extendWidthOfForm Then
                    For Each ctrl As Control In rbnForm.Controls
                        If TypeOf (ctrl) Is C1Button Then
                            ButtonX = ctrl.Left + _extraWidthRequiredForeMoreText + RightPadding + ButtonPadding
                            ButtonY = OldClientHeight + sl1.Height - ctrl.Height
                            Dim loc As New Point(ButtonX, ButtonY)
                            ctrl.Location = loc
                        End If
                    Next
                    Dim newloc As New Point(_oldButtonMoreLeft, OldClientHeight + sl1.Height - btnC1More.Height)
                    btnC1More.Location = newloc
                Else
                    For Each ctrl As Control In rbnForm.Controls
                        If TypeOf (ctrl) Is C1Button Then
                            ButtonX = ctrl.Left
                            ButtonY = OldClientHeight + sl1.Height - ctrl.Height
                            Dim loc As New Point(ButtonX, ButtonY)
                            ctrl.Location = loc
                        End If
                    Next
                End If

                rbnForm.ResumeLayout()
            Else
                rbnForm.SuspendLayout()
                btnC1More.Text = "&More >>"
                rbnForm.Controls.Remove(sl1)
                btnC1More.Location = OldButtonMoreLocation
                rbnForm.Width = OldFormWidth
                rbnForm.Height = OldFormHeight
                If _extendWidthOfForm Then
                    For Each ctrl As Control In rbnForm.Controls
                        If TypeOf (ctrl) Is C1Button Then
                            ButtonX = ctrl.Left - _extraWidthRequiredForeMoreText - RightPadding - ButtonPadding
                            ButtonY = OldClientHeight - BottomPadding - ctrl.Height
                            Dim loc As New Point(ButtonX, ButtonY)
                            ctrl.Location = loc
                        End If
                    Next

                Else
                    For Each ctrl As Control In rbnForm.Controls
                        If TypeOf (ctrl) Is C1Button Then
                            ButtonX = ctrl.Left
                            ButtonY = OldClientHeight - BottomPadding - ctrl.Height
                            Dim loc As New Point(ButtonX, ButtonY)
                            ctrl.Location = loc
                        End If
                    Next
                End If
                btnC1More.Location = OldButtonMoreLocation
                btnC1More.Top = OldClientHeight - BottomPadding - btnC1More.Height
                rbnForm.ResumeLayout()
            End If
        End If
    End Sub
    Private Sub AddDefaultOkButton()
        If _buttons.Count = 0 Then
            Dim okButton As VTLMessageBoxButton = New VTLMessageBoxButton() With {.Text = VTLMessageBoxButtons.OK.ToString, .Value = VTLMessageBoxButtons.OK.ToString}
            _buttons.Add(okButton)
        End If
    End Sub
    Private Sub AddButton(ByVal button As VTLMessageBoxButton)
        If button Is Nothing Then
            Throw New ArgumentNullException()
        End If

        Buttons.Add(button)
        If button.IsCancelButton Then
            CustomCancelButton = button
        End If

    End Sub


    '''-------------------------------------------------------------------------------------------------
    ''' <summary>   Adds a standard button to the VTL Message Box. </summary>
    '''
    ''' <remarks>   Dom Sinclair, 07 July 2012. </remarks>
    '''
    ''' <param name="button">   The standard Message Box button. </param>
    '''-------------------------------------------------------------------------------------------------

    Private Sub AddButton(ByVal button As VTLMessageBoxButtons)

        Dim btn As New VTLMessageBoxButton
        Select Case button
            Case VTLMessageBoxButtons.OK
                btn.Text = button.ToString
                btn.Value = button.ToString
            Case VTLMessageBoxButtons.Cancel
                btn.Text = button.ToString
                btn.Value = button.ToString
            Case VTLMessageBoxButtons.Yes
                btn.Text = button.ToString
                btn.Value = button.ToString
            Case VTLMessageBoxButtons.No
                btn.Text = button.ToString
                btn.Value = button.ToString
            Case VTLMessageBoxButtons.Abort
                btn.Text = button.ToString
                btn.Value = button.ToString
            Case VTLMessageBoxButtons.Retry
                btn.Text = button.ToString
                btn.Value = button.ToString
            Case VTLMessageBoxButtons.Ignore
                btn.Text = button.ToString
                btn.Value = button.ToString
        End Select

        If button = VTLMessageBoxButtons.Cancel Then
            btn.IsCancelButton = True
        End If
        AddButton(btn)
    End Sub


    '''-------------------------------------------------------------------------------------------------
    ''' <summary>   Adds a custom button to the Vtl Message Box. </summary>
    '''
    ''' <remarks>   Dom Sinclair, 07 July 2012. </remarks>
    '''
    ''' <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
    '''                                             null. </exception>
    '''
    ''' <param name="Text">     The text to appear in the button. </param>
    ''' <param name="Value">    The value to be returned by the button if clicked  (typically this would be the same as the text). </param>
    '''-------------------------------------------------------------------------------------------------

    Public Sub AddCustomButton(ByVal Text As String, ByVal Value As String)
        If Text = String.Empty Then
            Throw New ArgumentNullException
        End If
        If Value = String.Empty Then
            Throw New ArgumentNullException
        End If
        Dim button As New VTLMessageBoxButton() With {.Text = Text, .Value = Value}
        AddButton(button)
    End Sub



    '''-------------------------------------------------------------------------------------------------
    ''' <summary>   Adds the standard message box buttons to the Vtl Message Box. </summary>
    '''
    ''' <remarks>   Dom Sinclair, 09 July 2012. </remarks>
    '''
    ''' <param name="Buttons">  The Message Box buttons to add. </param>
    '''-------------------------------------------------------------------------------------------------

    Public Sub AddStandardButtons(ByVal Buttons As MessageBoxButtons)
        Select Case Buttons
            Case MessageBoxButtons.OK
                AddButton(VTLMessageBoxButtons.OK)
            Case MessageBoxButtons.OKCancel
                AddButton(VTLMessageBoxButtons.OK)
                AddButton(VTLMessageBoxButtons.Cancel)
            Case MessageBoxButtons.AbortRetryIgnore
                AddButton(VTLMessageBoxButtons.Abort)
                AddButton(VTLMessageBoxButtons.Retry)
                AddButton(VTLMessageBoxButtons.Ignore)
            Case MessageBoxButtons.YesNoCancel
                AddButton(VTLMessageBoxButtons.Yes)
                AddButton(VTLMessageBoxButtons.No)
                AddButton(VTLMessageBoxButtons.Cancel)
            Case MessageBoxButtons.YesNo
                AddButton(VTLMessageBoxButtons.Yes)
                AddButton(VTLMessageBoxButtons.No)
            Case MessageBoxButtons.RetryCancel
                AddButton(VTLMessageBoxButtons.Retry)
                AddButton(VTLMessageBoxButtons.Cancel)
        End Select
    End Sub


    Private Function GetWidthOfAllButtons() As System.Int32
        Dim buttonSize As Size = GetButtonSize()
        Dim allButtonsWidth As Integer = buttonSize.Width * _buttons.Count + ButtonPadding * (_buttons.Count - 1)
        Return allButtonsWidth
    End Function


    Private Function GetWidthOfAllAvailableButtons() As Integer
        Dim buttonSize As Size = GetButtonSize()
        Dim allButtonsWidth As Integer
        If UseMoreText Then
            allButtonsWidth = buttonSize.Width * _buttons.Count + ButtonPadding + MoreButtonWidth * (_buttons.Count - 1)
        Else
            allButtonsWidth = buttonSize.Width * _buttons.Count + ButtonPadding * (_buttons.Count - 1)
        End If

        Return allButtonsWidth
    End Function


    Private Function GetButtonSize() As Size
        Dim longestButtonText As String = GetLongestButtonText()
        If longestButtonText = Nothing Then
            'TODO:Handle this case  suggests that we have no button so add default button.
        End If
        Dim buttonTextSize As Size = MeasureString(longestButtonText, _maximumLayoutWidth)
        Dim buttonSize As Size = New Size(buttonTextSize.Width + ButtonLeftPadding + ButtonRightPadding, buttonTextSize.Height + ButtonTopPadding + ButtonBottomPadding)
        If buttonSize.Width < MinimumButtonWidth Then
            buttonSize.Width = MinimumButtonWidth
        End If
        If buttonSize.Height < MinimumButtonHeight Then
            buttonSize.Height = MinimumButtonHeight
        End If
        Return buttonSize
    End Function


    Private Function GetLongestButtonText() As String
        Dim maxLen As Integer = 0
        Dim maxStr As String = Nothing
        For Each button As VTLMessageBoxButton In _buttons
            If button.Text <> Nothing AndAlso button.Text.Length > maxLen Then
                maxLen = button.Text.Length
                maxStr = button.Text
            End If
        Next
        Return maxStr
    End Function

    Private Function GetButton(ByVal button As VTLMessageBoxButton, ByVal buttonSize As Size, ByVal nextButtonLocation As Point) As Button
        If UseStandardForm Then
            Dim buttonCtrl As Button = Nothing
            If _buttonControlsTable.ContainsKey(button) Then
                buttonCtrl = If(TypeOf _buttonControlsTable(button) Is VTLMessageBoxButton, CType(_buttonControlsTable(button), Button), Nothing)
                buttonCtrl.Size = buttonSize
                buttonCtrl.Location = nextButtonLocation
            Else
                buttonCtrl = CreateButton(button, buttonSize, nextButtonLocation)
                _buttonControlsTable(button) = buttonCtrl
                frm.Controls.Add(buttonCtrl)
            End If
            Return buttonCtrl
        Else
            Dim buttonCtrl As C1Button = Nothing
            If _buttonControlsTable.ContainsKey(button) Then
                buttonCtrl = If(TypeOf _buttonControlsTable(button) Is VTLMessageBoxButton, CType(_buttonControlsTable(button), C1Button), Nothing)
                buttonCtrl.Size = buttonSize
                buttonCtrl.Location = nextButtonLocation
            Else
                buttonCtrl = CreateButton(button, buttonSize, nextButtonLocation)
                _buttonControlsTable(button) = buttonCtrl
                rbnForm.Controls.Add(buttonCtrl)
            End If
            Return buttonCtrl
        End If


    End Function


    Private Function CreateButton(ByVal button As VTLMessageBoxButton, ByVal size As Size, ByVal location As Object) As Button
        If UseStandardForm Then
            Dim buttonCtrl As Button = New Button
            With buttonCtrl
                .Size = size
                .Text = GetButtonText(button.Text)  'button.Text
                .TextAlign = ContentAlignment.MiddleCenter
                .FlatStyle = FlatStyle.System
                .Location = location
                .Tag = button.Value
            End With
            AddHandler buttonCtrl.Click, AddressOf ButtonClick
            Return buttonCtrl
        Else
            Dim buttonCtrl As C1Button = New C1Button
            With buttonCtrl
                .Size = size
                .Text = GetButtonText(button.Text)  'button.Text
                .TextAlign = ContentAlignment.MiddleCenter
                .VisualStyle = button.VisualStyle
                .Location = location
                .Tag = button.Value
            End With
            AddHandler buttonCtrl.Click, AddressOf ButtonClick
            Return buttonCtrl
        End If
    End Function


    Private Function GetButtonText(ByVal text As String) As String
        Return GetButtonTextExtracted(text)
    End Function


    Private Function GetButtonTextExtracted(ByVal text As String) As String
        Select Case text
            Case "OK"
                Return " &OK"
            Case "No"
                Return "&No"
            Case "Yes"
                Return "&Yes"
            Case "Abort"
                Return "&Abort"
            Case "Retry"
                Return "&Retry"
            Case "Ignore"
                Return "&Ignore"
            Case "Cancel"
                Return "&Cancel"
            Case Else
                Return text
        End Select
    End Function


    Private Sub ButtonClick(ByVal sender As Object, ByVal e As EventArgs)

        If UseStandardForm Then
            Dim btn As Button = If(TypeOf sender Is Button, CType(sender, Button), Nothing)
            If btn Is Nothing OrElse btn.Tag = Nothing Then
                Return
            End If

            Dim result As String = If(TypeOf btn.Tag Is String, CType(btn.Tag, String), Nothing)
            SetResultAndClose(result)

        Else
            Dim btn As C1Button = If(TypeOf sender Is C1Button, CType(sender, C1Button), Nothing)
            If btn Is Nothing OrElse btn.Tag = Nothing Then
                Return
            End If

            Dim result As String = If(TypeOf btn.Tag Is String, CType(btn.Tag, String), Nothing)
            SetResultAndClose(result)
        End If
    End Sub
#End Region

#Region "Auto Close"

    Private Sub StartAutoTimerIfRequired()
        If _secondsToAutoClose > 0 Then
            If AutoTimer Is Nothing Then
                AutoTimer = New Timer
                AddHandler AutoTimer.Tick, AddressOf AutoTimerTick
            End If
            If Not AutoTimer.Enabled Then
                AutoTimer.Interval = 1000
                TimeRemaining = _secondsToAutoClose / 1000
                If UseStandardForm Then
                    DisplayedCaptionText = frm.Text
                Else
                    DisplayedCaptionText = rbnForm.Text
                End If
                AutoTimer.Start()
            End If
        End If
    End Sub

    Private Sub AutoTimerTick(ByVal sender As Object, ByVal e As EventArgs) Handles AutoTimer.Tick
        TimeRemaining -= 1

        If TimeRemaining <= 0 Then
            AutoTimer.Stop()
            Select Case AutoCloseResult
                Case AutoCloseResult.[Default]
                    _defaultButtonControl.PerformClick()
                Case AutoCloseResult.Cancel
                    SetResultAndClose(_cancelButton.Value)
                Case AutoCloseResult.TimedOut
                    SetResultAndClose("TimedOut")
            End Select
        Else

            If DisplaySecondsToAutoClose Then
                If UseStandardForm Then
                    frm.Text = String.Format("{0}   {1}", DisplayedCaptionText, TimeRemaining)
                Else
                    rbnForm.Text = String.Format("{0}   {1}", DisplayedCaptionText, TimeRemaining)
                End If

            End If

        End If
    End Sub

#End Region

#Region "Add Images"

    '''-------------------------------------------------------------------------------------------------
    ''' <summary>   Adds an image to the message text that will appear in the main part of the Vtl Message Box. </summary>
    '''
    ''' <remarks>   Dom Sinclair, 19 July 2012. </remarks>
    '''
    ''' <param name="ImageName">    Name of the image (used by the c1 super label to reference the image. </param>
    ''' <param name="Image">        The image itself. </param>
    '''-------------------------------------------------------------------------------------------------

    Public Sub AddImageToMessageText(ByVal ImageName As String, Image As Image)
        If sl Is Nothing Then
            sl = New C1SuperLabel
        End If
        sl.Images.Add(ImageName, Image)
    End Sub



    '''-------------------------------------------------------------------------------------------------
    ''' <summary>   Adds an image to the more text area that will appear in the Vtl Message Box. </summary>
    '''
    ''' <remarks>   Dom Sinclair, 19 July 2012. </remarks>
    '''
    ''' <param name="ImageName">    Name of the image (used by the c1 super label to reference the image. </param>
    ''' <param name="Image">        The image itself. </param>
    '''---------------------------------------
    Public Sub AddImageToMoreText(ByVal ImageName As String, ByVal Image As Image)
        If sl1 Is Nothing Then
            sl1 = New C1SuperLabel
        End If
        sl1.Images.Add(ImageName, Image)
    End Sub

#End Region
#End Region

End Class
