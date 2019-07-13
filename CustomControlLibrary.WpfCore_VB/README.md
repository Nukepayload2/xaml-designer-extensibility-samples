# CustomControlLibrary.WpfCore Code Sample
Code sample shows various features added to a button. CustomControlLibrary.WpfCore project has a custom button and
various features are added to it by using different Feature Providers present in CustomControlLibrary.WpfCore.DesignTools project. 
Below is the details of various Feature Providers present in extension code:

  - **CustomButtonDefaultInitializer**: A DefaultInitializer feature provider is used to configure a new object in the designer. This extension is usually invoked when an object is dropped off the toolbox by user.
In this case it is configuring defaults for custom button.
  - **OpacitySliderAdornerProvider**: An AdornerProvider is a feature provider you can add to a class to automatically add adorners to the designer's surface. In this case when user clicks on custom button a 
slider control is shown which changes the Background opacity of the adorned control.
  - **CustomContextMenuProvider**: ContextMenuProvider feature provider is used when user wants to add a context menu item to a particular context menu. This extension adds custom context menu to custom button.
 When user right clicks a Set Background option is shown which provides option to set background to blue.
  - **CustomButtonParentAdapter**: The ParentAdapter class should be offered as an extension to any object that can parent child objects. This extension allows only textbox to be added as child to button during 
drag and drop, also it modifies the text of textbox. 
  - **CustomButtonPlacementAdapter**: A PlacementAdapter is an adapter that is used to get and set positions of objects in parent coordinates. This extension is setting the width of textbox dropped on custom button.

Code sample also includes PropertyValueEditors which gives custom experience to edit properties through Property Inspector. The PropertyValueEditors are
also added to different properties of custon button. Below are the details of various PropertyValueEditors present here:

  - **DateInlinePropertyValueEditor**: An InlinePropertyValueEditor to edit dates using date picker. Date property is added to custom button class and InlinePropertyValueEditor is used to edit date through PropertyInspector.  
  - **BrushExtendedPropertyValueEditor**: PropertyValueEditor to edit BackGround property of custom button. This uses ExtendedPropertyValueEditor which shows ColorsList user control in Property Inspector to edit BackGround property. 
