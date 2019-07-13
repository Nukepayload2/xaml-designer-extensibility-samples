Imports Microsoft.VisualStudio.DesignTools.Extensibility.Interaction
Imports Microsoft.VisualStudio.DesignTools.Extensibility.Model

' The following class implements an PlacementAdapter for the 
' custom buttom. PlacementAdapter is invoked when the 
' controls are dragged from toolbox to custom button.
Public Class CustomButtonPlacementAdapter
    Inherits PlacementAdapter

    ' Returns true if the given coordinate can be set
    Public Overrides Function CanSetPosition(intent As PlacementIntent, position As RelativePosition) As Boolean
        Return False
    End Function

    ' Returns collection of positions that describe this placement of the item.
    Public Overrides Function GetPlacement(item As ModelItem, ParamArray positions() As RelativePosition) As RelativeValueCollection
        Dim bounds As New RelativeValueCollection
        Return bounds
    End Function

    ' Retrieves the boundary to the parent edge for the given item
    Public Overrides Function GetPlacementBoundary(item As ModelItem, intent As PlacementIntent, ParamArray positions() As RelativeValue) As Rect
        If item Is Nothing Then
            Throw New ArgumentNullException("item")
        End If

        Return New Rect
    End Function

    ' Retrieves the boundary to the parent edge for the given item
    Public Overrides Function GetPlacementBoundary(item As ModelItem) As Rect
        If item Is Nothing Then
            Throw New ArgumentNullException("item")
        End If

        Return New Rect
    End Function

    ' Sets the given collection of positions into the item.
    Public Overrides Sub SetPlacements(item As ModelItem, intent As PlacementIntent, placement As RelativeValueCollection)
        If item Is Nothing Then
            Throw New ArgumentNullException("item")
        End If

        item.Properties!Width.SetValue("50")
    End Sub

    ' Sets the given set of positions into the item.
    Public Overrides Sub SetPlacements(item As ModelItem, intent As PlacementIntent, ParamArray positions() As RelativeValue)
    End Sub
End Class
