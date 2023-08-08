Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Enum AutoCloseResult

    ''' <summary>   When Default is selected the result returned will be that which equates to the default button having been clicked.
    ''' 			In the event that no AutoTimerResult is set then this will be the default setting.</summary>
    [Default]

    ''' <summary>  When Cancel is selected the result returned will be that which equates to the Cancel button having been clicked. </summary>
    Cancel

    ''' <summary>   When TimedOut is selected the result returned will be "TimedOut".  This equates to a null result (no button was clicked).</summary>
    TimedOut

End Enum
