Imports Microsoft.VisualStudio.DesignTools.Extensibility.Interaction
Imports Microsoft.VisualStudio.DesignTools.Extensibility.Model

Friend Class CustomContextMenuProvider
    Inherits PrimarySelectionContextMenuProvider

    WithEvents SetBackgroundToBlueMenuAction As MenuAction
    WithEvents ClearBackgroundMenuAction As MenuAction

    ' The provider's constructor sets up the MenuAction objects 
    ' and the the MenuGroup which holds them.
    Public Sub New()
        ' Set up the MenuAction which sets the control's 
        ' background to Blue.
        SetBackgroundToBlueMenuAction = New MenuAction("Blue") With {
            .Checkable = True
        }

        ' Set up the MenuAction which sets the control's 
        ' background to its default value.
        ClearBackgroundMenuAction = New MenuAction("Cleared") With {
            .Checkable = True
        }

        ' Set up the MenuGroup which holds the MenuAction items.
        Dim backgroundFlyoutGroup As New MenuGroup("SetBackgroundsGroup", "Set Background")

        ' If HasDropDown is false, the group appears inline, 
        ' instead of as a flyout. Set to true.
        With backgroundFlyoutGroup
            .HasDropDown = True
            .Items.Add(SetBackgroundToBlueMenuAction)
            .Items.Add(ClearBackgroundMenuAction)
        End With
        Items.Add(backgroundFlyoutGroup)
    End Sub

    ' The UpdateItemStatus event is raised immediately before 
    ' this provider shows its tabs, which provides the opportunity 
    ' to set states.

    ' The following method handles the UpdateItemStatus event.
    ' It sets the MenuAction states according to the state
    ' of the control's Background property. This method is
    ' called before the context menu is shown.
    Private Sub CustomContextMenuProvider_UpdateItemStatus(sender As Object, e As MenuActionEventArgs) Handles Me.UpdateItemStatus
        ' Turn everything on, and then based on the value 
        ' of the BackgroundProperty, selectively turn some off.
        ClearBackgroundMenuAction.Checked = False
        ClearBackgroundMenuAction.Enabled = True
        SetBackgroundToBlueMenuAction.Checked = False
        SetBackgroundToBlueMenuAction.Enabled = True

        ' Get a ModelItem which represents the selected control. 
        Dim selectedControl As ModelItem = e.Selection.PrimarySelection

        ' Get the value of the Background property from the ModelItem.
        Dim backgroundProperty As ModelProperty = selectedControl.Properties("Background")

        ' Set the MenuAction items appropriately.
        If Not backgroundProperty.IsSet Then
            ClearBackgroundMenuAction.Checked = True
            ClearBackgroundMenuAction.Enabled = False
        Else ' If backgroundProperty.ComputedValue = Brushes.Blue
            SetBackgroundToBlueMenuAction.Checked = True
            SetBackgroundToBlueMenuAction.Enabled = False
        End If
    End Sub

    ' The following method handles the Execute event. 
    ' It sets the Background property to its default value.
    Private Sub ClearBackground_Execute(sender As Object, e As MenuActionEventArgs) Handles ClearBackgroundMenuAction.Execute
        Dim selectedControl As ModelItem = e.Selection.PrimarySelection
        selectedControl.Properties!Background.ClearValue()
    End Sub

    ' The following method handles the Execute event. 
    ' It sets the Background property to Brushes.Blue.
    Private Sub SetBackgroundToBlue_Execute(sender As Object, e As MenuActionEventArgs) Handles SetBackgroundToBlueMenuAction.Execute
        Dim selectedControl As ModelItem = e.Selection.PrimarySelection
        selectedControl.Properties!Background.SetValue(Brushes.Blue)
    End Sub
End Class
