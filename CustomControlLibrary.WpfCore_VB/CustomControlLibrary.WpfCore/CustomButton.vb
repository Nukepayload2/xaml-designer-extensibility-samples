Imports System.ComponentModel

Public Class CustomButton
    Inherits Button

    Public Sub New()
        ' The GetIsInDesignMode check and the following design-time 
        ' code are optional and shown only for demonstration.
        If DesignerProperties.GetIsInDesignMode(Me) Then
            Content = "Design mode active"
        End If
    End Sub

    ' Adding a Date property to CustomButton to provide sample code for PropertyValueEditor
    Public Shared ReadOnly DateProperty As DependencyProperty =
        DependencyProperty.Register("Date", GetType(Date),
                                    GetType(CustomButton),
                                    New PropertyMetadata(Date.MinValue, AddressOf OnDateChanged))

    Public Property [Date] As Date
        Get
            Return CDate(GetValue(DateProperty))
        End Get
        Set(value As Date)
            SetValue(DateProperty, value)
        End Set
    End Property

    Private Shared Sub OnDateChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim presenter = TryCast(d, CustomButton)
        presenter.Date = CDate(e.NewValue)
    End Sub

End Class
