Imports System.Collections.ObjectModel
Imports System.Reflection

Public Class ColorsList
    Inherits ObservableCollection(Of Color)

    Public Sub New()
        Dim type As Type = GetType(Colors)
        For Each propertyInfo As PropertyInfo In type.GetProperties(BindingFlags.Public Or BindingFlags.Static)
            If propertyInfo.PropertyType Is GetType(Color) Then
                Add(DirectCast(propertyInfo.GetValue(Nothing, Nothing), Color))
            End If
        Next
    End Sub
End Class
