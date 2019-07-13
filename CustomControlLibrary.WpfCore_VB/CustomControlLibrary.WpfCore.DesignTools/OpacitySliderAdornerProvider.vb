Imports Microsoft.VisualStudio.DesignTools.Extensibility.Interaction
Imports Microsoft.VisualStudio.DesignTools.Extensibility.Model

' The following class implements an adorner provider for the 
' adorned control. The adorner is a slider control, which 
' changes the Background opacity of the adorned control.
Friend Class OpacitySliderAdornerProvider
    Inherits PrimarySelectionAdornerProvider

    WithEvents OpacitySlider As New Slider
    WithEvents AdornedControlModel As ModelItem

    Private _batchedChange As ModelEditingScope
    Private _opacitySliderAdornerPanel As AdornerPanel

    ' The following method is called when the adorner is activated.
    ' It creates the adorner control, sets up the adorner panel,
    ' and attaches a ModelItem to the adorned control.
    Protected Overrides Sub Activate(item As ModelItem)
        ' Save the ModelItem and hook into when it changes.
        ' This enables updating the slider position when 
        ' a new Background value is set.
        AdornedControlModel = item

        ' Setup the slider's min and max values.
        OpacitySlider.Minimum = 0
        OpacitySlider.Maximum = 1

        ' Setup the adorner panel.
        ' All adorners are placed in an AdornerPanel
        ' for sizing and layout support.
        Dim myPanel As AdornerPanel = Panel

        ' The slider extends the full width of the control it adorns.
        AdornerPanel.SetAdornerHorizontalAlignment(OpacitySlider, AdornerHorizontalAlignment.Stretch)

        ' Position the adorner above the control it adorns.
        AdornerPanel.SetAdornerVerticalAlignment(OpacitySlider, AdornerVerticalAlignment.OutsideTop)

        ' Position the adorner 5 pixels above the control. 
        AdornerPanel.SetAdornerMargin(OpacitySlider, New Thickness(0, 0, 0, 5))

        MyBase.Activate(item)
    End Sub

    ' The Panel utility property demand-creates the 
    ' adorner panel and adds it to the provider's 
    ' Adorners collection.
    Public ReadOnly Property Panel As AdornerPanel
        Get
            If _opacitySliderAdornerPanel Is Nothing Then
                _opacitySliderAdornerPanel = New AdornerPanel

                _opacitySliderAdornerPanel.Children.Add(OpacitySlider)

                ' Add the panel to the Adorners collection.
                Adorners.Add(_opacitySliderAdornerPanel)
            End If

            Return _opacitySliderAdornerPanel
        End Get
    End Property

    ' The following method deactivates the adorner.
    Protected Overrides Sub Deactivate()
        AdornedControlModel = Nothing
        MyBase.Deactivate()
    End Sub

    ' The following method handles the PropertyChanged event.
    ' It updates the slider control's value if the adorned control's 
    ' Background property changed,
    Private Sub AdornedControlModel_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles AdornedControlModel.PropertyChanged
        If e.PropertyName = "Background" Then OpacitySlider.Value = GetCurrentOpacity()
    End Sub

    ' The following method handles the Loaded event.
    ' It assigns the slider control's initial value.
    Private Sub Slider_Loaded(sender As Object, e As RoutedEventArgs) Handles OpacitySlider.Loaded
        OpacitySlider.Value = GetCurrentOpacity()
    End Sub

    ' The following method handles the MouseLeftButtonDown event.
    ' It calls the BeginEdit method on the ModelItem which represents 
    ' the adorned control.
    Private Sub Slider_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles OpacitySlider.PreviewMouseLeftButtonDown
        _batchedChange = AdornedControlModel.BeginEdit()
    End Sub

    ' The following method handles the MouseLeftButtonUp event.
    ' It commits any changes made to the ModelItem which represents the
    ' the adorned control.
    Private Sub Slider_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles OpacitySlider.PreviewMouseLeftButtonUp
        If _batchedChange IsNot Nothing Then
            _batchedChange.Complete()
            _batchedChange.Dispose()
            _batchedChange = Nothing
        End If
    End Sub

    ' The following method handles the slider control's 
    ' ValueChanged event. It sets the value of the 
    ' Background opacity by using the ModelProperty type.
    Private Sub Slider_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles OpacitySlider.ValueChanged
        Dim newOpacityValue As Double = e.NewValue

        ' During setup, don't make a value local and set the opacity.
        If newOpacityValue = GetCurrentOpacity() Then Return

        ' Access the adorned control's Background property
        ' by using the ModelProperty type.
        Dim backgroundProperty As ModelProperty = AdornedControlModel.Properties("Background")
        If Not backgroundProperty.IsSet Then backgroundProperty.SetValue(backgroundProperty.ComputedValue)

        ' Set the Opacity property on the Background Brush.
        backgroundProperty.Value.Properties("Opacity").SetValue(newOpacityValue)
    End Sub

    ' This utility method gets the adorned control's
    ' Background brush by using the ModelItem.
    Private Function GetCurrentOpacity() As Double
        Dim backgroundBrushComputedValue = CType(AdornedControlModel.Properties("Background").ComputedValue, Brush)

        Return backgroundBrushComputedValue.Opacity
    End Function
End Class
