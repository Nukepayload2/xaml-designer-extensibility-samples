Imports Microsoft.VisualStudio.DesignTools.Extensibility.Metadata
Imports Microsoft.VisualStudio.DesignTools.Extensibility.Features
Imports Microsoft.VisualStudio.DesignTools.Extensibility.PropertyEditing

' The ProvideMetadata assembly-level attribute indicates to designers
' that this assembly contains a class that provides an attribute table. 
<Assembly: ProvideMetadata(GetType(Metadata))>

' Container for any general design-time metadata to initialize.
' Designers look for a type in the design-time assembly that 
' implements IProvideAttributeTable. If found, designers instantiate 
' this class and access its AttributeTable property automatically.
Friend Class Metadata
    Implements IProvideAttributeTable

    ' Accessed by the designer to register any design-time metadata.
    Public ReadOnly Property AttributeTable As AttributeTable Implements IProvideAttributeTable.AttributeTable
        Get
            Dim builder As New AttributeTableBuilder

            ' Add the providers to the design-time metadata.
            builder.AddCustomAttributes("CustomControlLibrary.WpfCore.CustomButton", New FeatureAttribute(GetType(CustomButtonDefaultInitializer)))
            builder.AddCustomAttributes("CustomControlLibrary.WpfCore.CustomButton", New FeatureAttribute(GetType(OpacitySliderAdornerProvider)))
            builder.AddCustomAttributes("CustomControlLibrary.WpfCore.CustomButton", New FeatureAttribute(GetType(CustomContextMenuProvider)))
            builder.AddCustomAttributes("CustomControlLibrary.WpfCore.CustomButton", New FeatureAttribute(GetType(CustomButtonParentAdapter)))
            builder.AddCustomAttributes("CustomControlLibrary.WpfCore.CustomButton", New FeatureAttribute(GetType(CustomButtonPlacementAdapter)))

            ' Add the propertyvalueeditors to the design-time metadata.
            builder.AddCustomAttributes("CustomControlLibrary.WpfCore.CustomButton", "Date", PropertyValueEditor.CreateEditorAttribute(GetType(DateInlinePropertyValueEditor)))
            builder.AddCustomAttributes("CustomControlLibrary.WpfCore.CustomButton", "Background", PropertyValueEditor.CreateEditorAttribute(GetType(BrushExtendedPropertyValueEditor)))

            Return builder.CreateTable()
        End Get
    End Property
End Class
