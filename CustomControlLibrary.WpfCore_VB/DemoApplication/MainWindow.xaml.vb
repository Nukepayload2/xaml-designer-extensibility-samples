Partial Public Class MainWindow

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ButtonExit_Click(sender As Object, e As RoutedEventArgs)
        Application.Current.Shutdown()
    End Sub
End Class
