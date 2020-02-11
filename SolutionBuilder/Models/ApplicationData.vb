Imports System.Configuration

Namespace Models
    Public Class ApplicationData
        Inherits ApplicationSettingsBase
        Private Shared _instance As ApplicationData = New ApplicationData()

        Private Sub New()
        End Sub

        Public Shared ReadOnly Property Instance As ApplicationData
            Get
                Return _instance
            End Get
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("")>
        Public Property MSBuildFileLocation As String
            Get
                Return CType(Me(NameOf(MSBuildFileLocation)), String)
            End Get
            Set(value As String)
                Me(NameOf(MSBuildFileLocation)) = value
            End Set
        End Property
    End Class
End Namespace

