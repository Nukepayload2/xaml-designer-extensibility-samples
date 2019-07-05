using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;
using Microsoft.VisualStudio.DesignTools.Extensibility.Features;
using Microsoft.VisualStudio.DesignTools.Extensibility.PropertyEditing;

// The ProvideMetadata assembly-level attribute indicates to designers
// that this assembly contains a class that provides an attribute table. 
[assembly: ProvideMetadata(typeof(CustomControlLibrary.WpfCore.DesignTools.Metadata))]
namespace CustomControlLibrary.WpfCore.DesignTools
{
    // Container for any general design-time metadata to initialize.
    // Designers look for a type in the design-time assembly that 
    // implements IProvideAttributeTable. If found, designers instantiate 
    // this class and access its AttributeTable property automatically.
    internal class Metadata : IProvideAttributeTable
    {
        // Accessed by the designer to register any design-time metadata.
        public AttributeTable AttributeTable
        {
            get
            {
                AttributeTableBuilder builder = new AttributeTableBuilder();

                // Add the providers to the design-time metadata.
                builder.AddCustomAttributes(
                    "CustomControlLibrary.WpfCore.CustomButton",
                    new FeatureAttribute(typeof(CustomButtonDefaultInitializer)));
                builder.AddCustomAttributes(
                    "CustomControlLibrary.WpfCore.CustomButton",
                    new FeatureAttribute(typeof(OpacitySliderAdornerProvider)));
                builder.AddCustomAttributes(
                    "CustomControlLibrary.WpfCore.CustomButton",
                    new FeatureAttribute(typeof(CustomContextMenuProvider)));
                builder.AddCustomAttributes(
                    "CustomControlLibrary.WpfCore.CustomButton",
                    new FeatureAttribute(typeof(CustomButtonParentAdapter)));
                builder.AddCustomAttributes(
                    "CustomControlLibrary.WpfCore.CustomButton",
                    new FeatureAttribute(typeof(CustomButtonPlacementAdapter)));


                // Add the propertyvalueeditors to the design-time metadata.
                builder.AddCustomAttributes(
                    "CustomControlLibrary.WpfCore.CustomButton", "Date",
                    PropertyValueEditor.CreateEditorAttribute(
                    typeof(DateInlinePropertyValueEditor)));
                builder.AddCustomAttributes(
                    "CustomControlLibrary.WpfCore.CustomButton", "Background",
                    PropertyValueEditor.CreateEditorAttribute(
                    typeof(BrushExtendedPropertyValueEditor)));

                return builder.CreateTable();
            }
        }
    }
}