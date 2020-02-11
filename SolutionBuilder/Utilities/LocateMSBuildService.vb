Imports System.IO

Namespace Utilities
    Public Module LocateMSBuildService
        ''' <summary>
        ''' Returns the full file path where MSBuild.exe is located on the user's system
        ''' </summary>
        ''' <param name="filePathStartSearch">String containing a default path to start searching for MSBuild (not required)</param>
        ''' <returns></returns>
        Public Function Execute(Optional filePathStartSearch As String = Constants.VisualStudioFilePath) As String
            Dim msBuildFilePathList As String()
            Try
                msBuildFilePathList = Directory.GetFiles(filePathStartSearch, Constants.MSBuildExe, SearchOption.AllDirectories)
            Catch ex As Exception
                Return String.Empty
            End Try

            ' If MSBuild is not found return empty string
            If msBuildFilePathList.Count < 1 Then
                Return String.Empty
            End If

            ' Retrieve MSBuild for latest version of Visual Studio
            Dim msBuildFilePath As String = msBuildFilePathList.Last()

            Return msBuildFilePath
        End Function
    End Module
End Namespace