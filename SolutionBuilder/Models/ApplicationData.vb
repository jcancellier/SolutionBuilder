Namespace Models
    Public Class ApplicationData
        Private Shared _instance As ApplicationData = New ApplicationData()

        Private Sub New()
        End Sub

        Public Shared ReadOnly Property Instance As ApplicationData
            Get
                Return _instance
            End Get
        End Property

        Public Property MSBuildFileLocation As String
    End Class
End Namespace

