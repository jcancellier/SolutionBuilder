Imports LibGit2Sharp

Namespace GitServices
    Public Module RetrieveCurrentGitBranchService
        ''' <summary>
        ''' Service which returns the current git branch for a git repository in the specified path
        ''' </summary>
        ''' <param name="repositoryFilePath">Path where git repository resides</param>
        ''' <returns>String denoting the current branch of the git repository</returns>
        Public Function Execute(repositoryFilePath As String) As String
            Dim branch As String
            Try
                Using repo As New Repository(repositoryFilePath)
                    branch = (From b In repo.Branches
                              Where b.IsCurrentRepositoryHead = True).FirstOrDefault().FriendlyName()
                    Return branch
                End Using
            Catch ex As Exception
                Return String.Empty
            End Try

            Return String.Empty
        End Function
    End Module
End Namespace