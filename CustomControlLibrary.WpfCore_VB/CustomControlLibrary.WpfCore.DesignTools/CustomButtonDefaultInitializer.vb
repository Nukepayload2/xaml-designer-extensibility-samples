Imports Microsoft.VisualStudio.DesignTools.Extensibility.Model

' The following class implements an default initializer for the 
' custom buttom. Default initializer is invoked when the custom 
' button is dragged from toolbox to designer.
Public Class CustomButtonDefaultInitializer
    Inherits DefaultInitializer

    ' The following method is called when the custom button is dragged
    ' from toolbox to designer. It initializes the default settings.
    Public Overrides Sub InitializeDefaults(item As ModelItem)
        item.Properties!Name.SetValue("button1")
        item.Properties!Width.SetValue("300")
        item.Properties!Content.SetValue("Custom Button")
        item.Properties!FontFamily.SetValue(New FontFamily("Arial"))
        item.Properties!Margin.SetValue(New Thickness(100, 20, 30, 40))
        item.Properties!Background.SetValue(New LinearGradientBrush(Colors.White, Colors.Black, 45))
        item.Properties!RenderTransform.SetValue(New RotateTransform(45))
    End Sub
End Class
