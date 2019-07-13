Imports Microsoft.VisualStudio.DesignTools.Extensibility.Interaction
Imports Microsoft.VisualStudio.DesignTools.Extensibility.Metadata
Imports Microsoft.VisualStudio.DesignTools.Extensibility.Model

' The following class implements an ParentAdapter for the 
' custom button. ParentAdapter is invoked when the 
' controls are dragged from toolbox to custom button.
Friend Class CustomButtonParentAdapter
    Inherits ParentAdapter

    ' The following method is called when any control is dropped over custom button
    ' from toolbox. It checks if custombutton can take this child or not.
    Public Overrides Function CanParent(parent As ModelItem, childType As TypeIdentifier) As Boolean
        If parent Is Nothing Then Throw New ArgumentNullException("parent")
        If childType Is Nothing Then Throw New ArgumentNullException("childType")

        Return (childType.Name.Equals("System.Windows.Controls.TextBox"))
    End Function

    ' The following method is called when allowed control is dropped over custom button
    ' from toolbox. It adds the child and changes the text.
    Public Overrides Sub Parent(newParent As ModelItem, child As ModelItem)
        If newParent Is Nothing Then Throw New ArgumentNullException("newParent")
        If child Is Nothing Then Throw New ArgumentNullException("child")

        Using scope As ModelEditingScope = newParent.BeginEdit()
            child.Properties!Text.SetValue("Button Child")
            newParent.Content.Collection.Add(child)

            scope.Complete()
        End Using

    End Sub

    ' This method can redirect from one parent to another.
    Public Overrides Function RedirectParent(parent As ModelItem, childType As TypeIdentifier) As ModelItem
        If parent Is Nothing Then Throw New ArgumentNullException("parent")
        If childType Is Nothing Then Throw New ArgumentNullException("childType")

        Return MyBase.RedirectParent(parent, childType)
    End Function

    ' The following method is called when child control is dragged away to different parent.
    ' Here we are removing the text.
    Public Overrides Sub RemoveParent(currentParent As ModelItem, newParent As ModelItem, child As ModelItem)
        If currentParent Is Nothing Then Throw New ArgumentNullException("currentParent")
        If newParent Is Nothing Then Throw New ArgumentNullException("newParent")
        If child Is Nothing Then Throw New ArgumentNullException("child")

        Using scope As ModelEditingScope = child.BeginEdit()
            child.Properties("Text").SetValue("")
            newParent.Content.Collection.Remove(child)
            scope.Complete()
        End Using
    End Sub
End Class
