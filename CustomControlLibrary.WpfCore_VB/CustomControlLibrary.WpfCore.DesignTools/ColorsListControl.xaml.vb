''' <summary>
''' Interaction logic for ColorsListControl.xaml
''' </summary>
Partial Public Class ColorsListControl
    Inherits UserControl

    Public Shared ReadOnly SelectedColorProperty As DependencyProperty = DependencyProperty.Register("SelectedColor", GetType(Color), GetType(ColorsListControl), New FrameworkPropertyMetadata(Nothing))
    Public Property SelectedColor As Color
        Get
            Return DirectCast(GetValue(SelectedColorProperty), Color)
        End Get
        Set(value As Color)
            SetValue(SelectedColorProperty, value)
        End Set
    End Property

    Public Shared ReadOnly SelectedBrushProperty As DependencyProperty = DependencyProperty.Register("SelectedBrush", GetType(SolidColorBrush), GetType(ColorsListControl), New FrameworkPropertyMetadata(Nothing))
    Public Property SelectedBrush As SolidColorBrush
        Get
            Return DirectCast(GetValue(SelectedBrushProperty), SolidColorBrush)
        End Get
        Set(value As SolidColorBrush)
            SetValue(SelectedBrushProperty, value)
        End Set
    End Property

    Private Sub ItemsControl_Click(sender As Object, e As RoutedEventArgs)
        SelectedColor = DirectCast((DirectCast(sender, Button)).Tag, Color)
        SelectedBrush = New SolidColorBrush(SelectedColor)
    End Sub
End Class
