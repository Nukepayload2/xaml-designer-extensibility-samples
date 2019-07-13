Imports Microsoft.VisualStudio.DesignTools.Extensibility.PropertyEditing

Friend Class BrushExtendedPropertyValueEditor
    Inherits ExtendedPropertyValueEditor

    Private _res As New EditorResources

    Public Sub New()
        ExtendedEditorTemplate = TryCast(_res!BrushExtendedEditorTemplate, DataTemplate)
        InlineEditorTemplate = TryCast(_res!BrushInlineEditorTemplate, DataTemplate)
    End Sub
End Class
