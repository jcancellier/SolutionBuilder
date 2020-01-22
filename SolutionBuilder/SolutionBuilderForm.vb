Public Class SolutionBuilderForm
    Private Sub btnAddSolution_Click(sender As Object, e As EventArgs) Handles btnAddSolution.Click
        'Open File Dialog
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Solution Files | *.sln"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                chklistSolutions.Items.Add(openFileDialog.FileName, True)
            End If
        End Using
    End Sub

    Private Sub btnBuildSolutions_Click(sender As Object, e As EventArgs) Handles btnBuildSolutions.Click
        'Clear build output
        txtboxBuildOutput.Clear()

        Dim msbuildPath As String = """c:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\amd64\MSbuild.exe"""
        Dim solutionList As String = String.Join(" ", chklistSolutions.CheckedItems.Cast(Of String))
        Dim buildCommand As String = $"/c ""{msbuildPath} -m:4 {solutionList}"" " '{msbuildPath} {solutionList} pause"

        'Dim buildCommand As String = $"/c ""{msbuildPath} {solution}"" "

        'TODO: use Process.Exited event to start next build

        Dim processStartInfo As New ProcessStartInfo() With {
            .FileName = "cmd.exe",
            .Arguments = buildCommand,
            .UseShellExecute = False,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .CreateNoWindow = True
        }

        Using process As Process = Process.Start(processStartInfo)
            AddHandler process.OutputDataReceived, AddressOf HandleBuildOutput
            AddHandler process.ErrorDataReceived, AddressOf HandleBuildError
            process.BeginOutputReadLine()
            process.BeginErrorReadLine()
        End Using
    End Sub

    Private Sub HandleBuildOutput(sender As Object, e As DataReceivedEventArgs)
        If e.Data = Nothing Then
            Exit Sub
        End If
        txtboxBuildOutput.BeginInvoke(New MethodInvoker(
            Sub()
                txtboxBuildOutput.AppendText(vbCrLf & e.Data)
            End Sub))
    End Sub

    Private Sub HandleBuildError(sender As Object, e As DataReceivedEventArgs)
        If e.Data = Nothing Then
            Exit Sub
        End If
        txtboxBuildOutput.BeginInvoke(New MethodInvoker(
            Sub()
                txtboxBuildOutput.AppendText(vbCrLf & e.Data)
            End Sub))
    End Sub
End Class
