Imports Microsoft.VisualStudio.DesignTools.Extensibility.PropertyEditing
Imports System.Windows.Markup

Friend Class DateInlinePropertyValueEditor
    Inherits PropertyValueEditor

    Private Shared ReadOnly _editorTemplate As String =
    <DataTemplate xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
        <DatePicker SelectedDate="{Binding StringValue, Mode=TwoWay}"/>
    </DataTemplate>.ToString()

    Public Sub New()
        Dim template As DataTemplate = TryCast(XamlReader.Parse(_editorTemplate), DataTemplate)
        InlineEditorTemplate = template
    End Sub
End Class
